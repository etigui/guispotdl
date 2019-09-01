using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace guispotdl
{
    class Download
    {
        #region Vars

        private string output;
        private string id;
        private bool playlist;
        public event EventHandler<StatusEventArgs> StatusEventHandler;
        public event EventHandler<OutputEventArgs> OutputEventHandler;

        public string Output { get => output; set => output = value; }
        public string Id { set => id = value; }
        public bool Playlist { get => playlist; set => playlist = value; }
        #endregion

        #region Construct

        public Download()
        {
        }
        #endregion

        #region Start download

        /// <summary>
        /// Start downloading song
        /// </summary>
        public void Start()
        {
            CheckUp();

            BackgroundWorker bw = new BackgroundWorker()
            {
                WorkerReportsProgress = true,
                WorkerSupportsCancellation = false

            };
            bw.DoWork += BW_DoWork;
            bw.RunWorkerCompleted += BW_RunWorkerCompleted;
            bw.ProgressChanged += BW_ProgressChanged;
            bw.RunWorkerAsync();
        }

        /// <summary>
        /// Remove txt playlist file and create if needed directory to store music file
        /// </summary>
        private void CheckUp()
        {

            // Remove all txt playlist file
            foreach (string file in Directory.GetFiles(Globals.exePath, $"*{Globals.extTxt}"))
            {
                if (File.Exists(file))
                {
                    File.Delete(file);
                }
            }

            // Create directory to store music file
            if (!Directory.Exists(Globals.downloadPath))
            {
                Directory.CreateDirectory(Globals.downloadPath);
            }

            // Check if ffmpeg and spotdl prog exist
            if (!File.Exists(Globals.spotdlPath))
            {
                ProcessOutputEvent("spotdl.exe not exist");
            }
            if (!File.Exists(Globals.ffmpegPath))
            {
                ProcessOutputEvent("ffmpeg.exe not exist");
            }
        }
        #endregion

        #region BackgroundWorker

        /// <summary>
        /// BackgroundWorker "start downloading"
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        void BW_DoWork(object sender, DoWorkEventArgs e)
        {
            // Send "start download event" to main form
            ProcessStatusEvent("downloading...");

            // Check to download playlist or song
            List<string> urlSongs = new List<string>();
            if (playlist)
            {
                urlSongs = GetPlaylistSongs();
            }else
            {
                urlSongs.Add($"https://open.spotify.com/track/{id}");
            }
            DownloadSong(urlSongs);
        }

        /// <summary>
        /// BackgroundWorker "progress changed"
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void BW_ProgressChanged(object sender, ProgressChangedEventArgs e)
        {
            //resultLabel.Text = (e.ProgressPercentage.ToString() + "%");
        }

        /// <summary>
        /// BackgroundWorker "run completed"
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        void BW_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            // Send "end download event" to main form
            ProcessStatusEvent("terminated");
        }
        #endregion

        #region Download song/playlist

        /// <summary>
        /// Download song url from playlist >> playlist.txt
        /// Extract song url from playlist.txt file
        /// </summary>
        /// <returns></returns>
        private List<string> GetPlaylistSongs()
        {

            // Download playlist file (playlist.txt)
            ExecProcess(Globals.spotdlPath, $"{Globals.argPlaylist} {Globals.playlistUrl}{id} {Globals.argWriteTo} {"\""}{Globals.playlistFilePath}{"\""}");

            // Read all line from "playlist.txt" file
            if (File.Exists(Globals.playlistFilePath))
            {
                return File.ReadAllLines(Globals.playlistFilePath).ToList();
            }
            return new List<string>();
        }

        /// <summary>
        /// Download all songs from the url list
        /// </summary>
        /// <param name="urlSongs"></param>
        private void DownloadSong(List<string> urlSongs)
        {   
            // Create a new directory to store all the song
            DateTime date = DateTime.Now;
            string downloadPath = Path.Combine(Globals.downloadPath, $"{date.ToString("ddMMyyyyHHmmss")}_{id}");
            Directory.CreateDirectory(downloadPath);

            // Download all song
            int count = 1;
            foreach (string urlSong in urlSongs)
            {
                ProcessStatusEvent($"downloading ({count}/{urlSongs.Count()})...");
                ExecProcess(Globals.spotdlPath, $"{Globals.argSong} {urlSong} {Globals.argFolder} {"\""}{downloadPath}{"\""} {Globals.argOverwriteSkip}");
                count++;
            }
        }

        /// <summary>
        /// Run process
        /// </summary>
        /// <param name="prog"></param>
        /// <param name="args"></param>
        private void ExecProcess(string prog, string args)
        {
            ProcessOutputEvent($"{prog}");
            ProcessOutputEvent($"{args}");

            ProcessStartInfo pInfo = new ProcessStartInfo()
            {
                FileName = prog,
                UseShellExecute = false,
                CreateNoWindow = true,
                RedirectStandardOutput = true,
                RedirectStandardError = true,
                Arguments = args,
            };

            using (Process process = new Process()
            {
                StartInfo = pInfo,
            })
            {
                process.OutputDataReceived += (ss, ee) => ProcessOutputEvent(ee.Data);
                process.ErrorDataReceived += (ss, ee) => ProcessOutputEvent(ee.Data);
                process.Start();
                process.BeginOutputReadLine();
                process.BeginErrorReadLine();
                process.WaitForExit();
            }
        }
        #endregion

        #region EventHandler fonction

        /// <summary>
        ///  Custom EventHandler for status messsage
        /// </summary>
        /// <param name="e"></param>
        protected virtual void StatusEvent(StatusEventArgs e)
        {
            EventHandler<StatusEventArgs> handler = StatusEventHandler;
            StatusEventHandler?.Invoke(this, e);
        }

        /// <summary>
        /// Custom EventHandler for output console
        /// </summary>
        /// <param name="e"></param>
        protected virtual void OutputEvent(OutputEventArgs e)
        {
            EventHandler<OutputEventArgs> handler = OutputEventHandler;
            OutputEventHandler?.Invoke(this, e);
        }

        /// <summary>
        /// Follow "spotdl.exe" prog console output/error
        /// </summary>
        /// <param name="output"></param>
        private void ProcessOutputEvent(string output)
        {
            if (!String.IsNullOrEmpty(output))
            {
                OutputEventArgs arg = new OutputEventArgs
                {
                    Output = output,
                };
                OutputEvent(arg);
            }
        }

        /// <summary>
        /// Follow "download event" to main form
        /// </summary>
        /// <param name="status"></param>
        private void ProcessStatusEvent(string status)
        {
            StatusEventArgs arg = new StatusEventArgs
            {
                Status = status,
            };
            StatusEvent(arg);
        }
        #endregion
    }

    #region EventArgs class

    /// <summary>
    /// Class to store status message
    /// </summary>
    public class StatusEventArgs : EventArgs
    {
        public string Status { get; set; }
    }

    /// <summary>
    /// Class to store output message
    /// </summary>
    public class OutputEventArgs : EventArgs
    {
        public string Output { get; set; }
    }
    #endregion
}

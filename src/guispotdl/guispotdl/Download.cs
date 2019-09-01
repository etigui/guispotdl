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

        private string output;
        private string id;
        private bool playlist;
        public string Output { get => output; set => output = value; }
        public string Id { set => id = value; }
        public bool Playlist { get => playlist; set => playlist = value; }

        public event EventHandler<StatusEventArgs> StatusEventHandler;
        public event EventHandler<OutputEventArgs> OutputEventHandler;

        public Download()
        {
        }

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

        

        void BW_DoWork(object sender, DoWorkEventArgs e)
        {
            // Send "start download event" to main form
            StatusEventArgs arg = new StatusEventArgs
            {
                Status = "downloading..."
            };
            StatusEvent(arg);

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

        private void BW_ProgressChanged(object sender, ProgressChangedEventArgs e)
        {
            //resultLabel.Text = (e.ProgressPercentage.ToString() + "%");
        }

        void BW_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            // Send "end download event" to main form
            StatusEventArgs arg = new StatusEventArgs
            {
                Status = "terminated"
            };
            StatusEvent(arg);
        }


        protected virtual void StatusEvent(StatusEventArgs e)
        {
            EventHandler<StatusEventArgs> handler = StatusEventHandler;
            StatusEventHandler?.Invoke(this, e);
        }

        protected virtual void OutputEvent(OutputEventArgs e)
        {
            EventHandler<OutputEventArgs> handler = OutputEventHandler;
            OutputEventHandler?.Invoke(this, e);
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
                ProcessOutput("spotdl.exe not exist");
            }
            if (!File.Exists(Globals.ffmpegPath))
            {
                ProcessOutput("ffmpeg.exe not exist");
            }
        }

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

        private void DownloadSong(List<string> urlSongs)
        {
            foreach (string urlSong in urlSongs)
            {
                Console.WriteLine(urlSong);
            }
        }

        private void ExecProcess(string prog, string args)
        {
            ProcessOutput($"{prog}");
            ProcessOutput($"{Environment.NewLine}");
            ProcessOutput($"{args}");

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
                process.OutputDataReceived += (ss, ee) => ProcessOutput(ee.Data);
                process.ErrorDataReceived += (ss, ee) => ProcessOutput(ee.Data);
                process.Start();
                process.BeginOutputReadLine();
                process.BeginErrorReadLine();
                process.WaitForExit();
            }
        }

        private void ProcessOutput(string output)
        {
            if (!String.IsNullOrEmpty(output))
            {
                // Follow "spotdl.exe" prog console output/error
                OutputEventArgs arg = new OutputEventArgs
                {
                    Output = output,
                };
                OutputEvent(arg);
            }
        }
    }
    #region EventArgs class

    public class StatusEventArgs : EventArgs
    {
        public string Status { get; set; }
    }

    public class OutputEventArgs : EventArgs
    {
        public string Output { get; set; }
    }
    #endregion
}

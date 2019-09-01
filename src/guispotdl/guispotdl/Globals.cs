using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace guispotdl
{
    class Globals
    {
        public static string downloadPath = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.MyMusic), "guisptodl");
        public static string exePath = Path.GetDirectoryName(Application.ExecutablePath);
        public static string spotdlPath = Path.Combine(exePath, "spotdl.exe");
        public static string ffmpegPath = Path.Combine(exePath, "ffmpeg.exe");
        public static string playlistFilePath = Path.Combine(exePath, "playlist.txt");

        // Playlist url
        public const string playlistUrl= "https://open.spotify.com/user/nocopyrightsounds/playlist/";

        // Song url
        public const string songUrl = "https://open.spotify.com/track/";
        
        // Playlist file extention
        public const string extTxt = ".txt";

        // Overwrite same song
        public const string argOverwriteSkip = "--overwrite skip";

        // Write tracks from Spotify playlist, album, etc. to this file(default: None)
        public const string argWriteTo = "--write-to";

        // Show only track title and YouTube URL, and then skip to the next track(if any) (default: False)
        public const string argDryRun = "--dry-run";

        // Path to folder where downloaded tracks will be stored in (default: C: \Users\Etienne\Music)
        public const string argFolder = "--folder";

        // Download tracks from a file (default: None)
        public const string argList = "--list";

        // Download track by spotify link or name (default: None)
        public const string argSong = "--song";

        // Load tracks from playlist URL into <playlist_name>.txt (default: None)
        public const string argPlaylist = "--playlist";
    }
}

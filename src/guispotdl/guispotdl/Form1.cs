using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

//this.ClientSize = new Size(633, 60);

namespace guispotdl
{
    public partial class Form1 : Form {

        #region Vars

        private bool playlist = false;
        #endregion

        #region Construct

        public Form1() {
            InitializeComponent();

            // Select first item in checkbox
            CB_type.SelectedIndex = 0;
        }
        #endregion

        #region Controls

        private void BT_download_Click(object sender, EventArgs e)
        {
            Download dl = new Download()
            {
                Id = tb_id.Text,
                Playlist = playlist
            };
            dl.StatusEventHandler += Download_StatusEventHandler;
            dl.OutputEventHandler += Download_OutputEventHandler;
            dl.Start();
        }

        private void CB_type_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (CB_type.Text == "Song")
            {
                playlist = false;
            }
            else if (CB_type.Text == "Playlist")
            {
                playlist = true;
            }
        }
        #endregion

        #region Download class event handler

        /// <summary>
        /// Event handler to get status message from "Download" class
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Download_StatusEventHandler(object sender, StatusEventArgs e)
        {
            if (!String.IsNullOrEmpty(e.Status))
            {
                InvokeTSSLStatus($"Status: {e.Status}");

                if (e.Status == "terminated")
                {
                    InvokeBTDownload(true);
                }
                else if (e.Status == "downloading...")
                {
                    InvokeBTDownload(false);
                }
            }
        }

        // Event handler to get output/error console (spotdl.exe) from "Download" class
        private void Download_OutputEventHandler(object sender, OutputEventArgs e)
        {
            if (!String.IsNullOrEmpty(e.Output))
            {
                InvokeTBOutput(e.Output);
            }
        }
        #endregion

        #region Controls invoke

        // Tools bar status invoke
        private void InvokeTSSLStatus(string status)
        {
            if (TSSL_status.GetCurrentParent().InvokeRequired)
            {
                this.Invoke(new MethodInvoker(delegate
                {
                    TSSL_status.Text = status;
                }));
            }
            else
            {
                TSSL_status.Text = status;
            }
        }

        // Button download invoke
        private void InvokeBTDownload(bool enable)
        {
            if (BT_download.InvokeRequired)
            {
                this.Invoke(new MethodInvoker(delegate
                {
                    BT_download.Enabled = enable;
                }));
            }
            else
            {
                BT_download.Enabled = enable;
            }
        }

        // Textbox output invoke
        private void InvokeTBOutput(string output) {
            if (TB_console.InvokeRequired)
            {
                this.Invoke(new MethodInvoker(delegate
                {
                    TB_console.Text = output;
                }));
            }
            else
            {
                TB_console.Text = output;
            }
        }
        #endregion
    }
}

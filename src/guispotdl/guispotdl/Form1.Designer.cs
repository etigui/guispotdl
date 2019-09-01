namespace guispotdl
{
    partial class Form1
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
            this.BT_download = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.tb_id = new System.Windows.Forms.TextBox();
            this.CB_type = new System.Windows.Forms.ComboBox();
            this.TB_console = new System.Windows.Forms.TextBox();
            this.SS_status = new System.Windows.Forms.StatusStrip();
            this.TSSL_status = new System.Windows.Forms.ToolStripStatusLabel();
            this.SS_status.SuspendLayout();
            this.SuspendLayout();
            // 
            // BT_download
            // 
            this.BT_download.Location = new System.Drawing.Point(617, 24);
            this.BT_download.Name = "BT_download";
            this.BT_download.Size = new System.Drawing.Size(90, 28);
            this.BT_download.TabIndex = 0;
            this.BT_download.Text = "Download";
            this.BT_download.UseVisualStyleBackColor = true;
            this.BT_download.Click += new System.EventHandler(this.BT_download_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 30);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(33, 17);
            this.label1.TabIndex = 1;
            this.label1.Text = "ID : ";
            // 
            // tb_id
            // 
            this.tb_id.Location = new System.Drawing.Point(51, 27);
            this.tb_id.Name = "tb_id";
            this.tb_id.Size = new System.Drawing.Size(420, 22);
            this.tb_id.TabIndex = 2;
            this.tb_id.Text = "3JrASLN8NI6jmnn6T8R0Nr";
            // 
            // CB_type
            // 
            this.CB_type.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.CB_type.FormattingEnabled = true;
            this.CB_type.Items.AddRange(new object[] {
            "Song",
            "Playlist"});
            this.CB_type.Location = new System.Drawing.Point(477, 27);
            this.CB_type.Name = "CB_type";
            this.CB_type.Size = new System.Drawing.Size(134, 24);
            this.CB_type.TabIndex = 3;
            this.CB_type.SelectedIndexChanged += new System.EventHandler(this.CB_type_SelectedIndexChanged);
            // 
            // TB_console
            // 
            this.TB_console.BackColor = System.Drawing.Color.Black;
            this.TB_console.ForeColor = System.Drawing.Color.White;
            this.TB_console.Location = new System.Drawing.Point(15, 67);
            this.TB_console.Multiline = true;
            this.TB_console.Name = "TB_console";
            this.TB_console.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.TB_console.Size = new System.Drawing.Size(692, 329);
            this.TB_console.TabIndex = 4;
            // 
            // SS_status
            // 
            this.SS_status.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.SS_status.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.TSSL_status});
            this.SS_status.Location = new System.Drawing.Point(0, 410);
            this.SS_status.Name = "SS_status";
            this.SS_status.Size = new System.Drawing.Size(723, 25);
            this.SS_status.TabIndex = 5;
            this.SS_status.Text = "statusStrip1";
            // 
            // TSSL_status
            // 
            this.TSSL_status.Name = "TSSL_status";
            this.TSSL_status.Size = new System.Drawing.Size(97, 20);
            this.TSSL_status.Text = "Status : ready";
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(723, 435);
            this.Controls.Add(this.SS_status);
            this.Controls.Add(this.TB_console);
            this.Controls.Add(this.CB_type);
            this.Controls.Add(this.tb_id);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.BT_download);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "Form1";
            this.Text = "Music downloader (Spotify)";
            this.SS_status.ResumeLayout(false);
            this.SS_status.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button BT_download;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox tb_id;
        private System.Windows.Forms.ComboBox CB_type;
        private System.Windows.Forms.TextBox TB_console;
        private System.Windows.Forms.StatusStrip SS_status;
        private System.Windows.Forms.ToolStripStatusLabel TSSL_status;
    }
}


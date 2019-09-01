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
            this.bt_download = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.tb_id = new System.Windows.Forms.TextBox();
            this.cb_type = new System.Windows.Forms.ComboBox();
            this.lb_found = new System.Windows.Forms.ListBox();
            this.lb_download = new System.Windows.Forms.ListBox();
            this.bt_add = new System.Windows.Forms.Button();
            this.bt_remove = new System.Windows.Forms.Button();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // bt_download
            // 
            this.bt_download.Enabled = false;
            this.bt_download.Location = new System.Drawing.Point(742, 26);
            this.bt_download.Name = "bt_download";
            this.bt_download.Size = new System.Drawing.Size(90, 28);
            this.bt_download.TabIndex = 0;
            this.bt_download.Text = "Download";
            this.bt_download.UseVisualStyleBackColor = true;
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
            // cb_type
            // 
            this.cb_type.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cb_type.FormattingEnabled = true;
            this.cb_type.Items.AddRange(new object[] {
            "Song",
            "Playlist"});
            this.cb_type.Location = new System.Drawing.Point(477, 27);
            this.cb_type.Name = "cb_type";
            this.cb_type.Size = new System.Drawing.Size(259, 24);
            this.cb_type.TabIndex = 3;
            this.cb_type.SelectedIndexChanged += new System.EventHandler(this.cb_type_SelectedIndexChanged);
            // 
            // lb_found
            // 
            this.lb_found.FormattingEnabled = true;
            this.lb_found.ItemHeight = 16;
            this.lb_found.Items.AddRange(new object[] {
            "a",
            "b",
            "c",
            "d",
            "d"});
            this.lb_found.Location = new System.Drawing.Point(15, 100);
            this.lb_found.Name = "lb_found";
            this.lb_found.SelectionMode = System.Windows.Forms.SelectionMode.MultiExtended;
            this.lb_found.Size = new System.Drawing.Size(365, 292);
            this.lb_found.TabIndex = 4;
            // 
            // lb_download
            // 
            this.lb_download.FormattingEnabled = true;
            this.lb_download.ItemHeight = 16;
            this.lb_download.Location = new System.Drawing.Point(467, 100);
            this.lb_download.Name = "lb_download";
            this.lb_download.SelectionMode = System.Windows.Forms.SelectionMode.MultiExtended;
            this.lb_download.Size = new System.Drawing.Size(365, 292);
            this.lb_download.TabIndex = 5;
            // 
            // bt_add
            // 
            this.bt_add.Location = new System.Drawing.Point(386, 216);
            this.bt_add.Name = "bt_add";
            this.bt_add.Size = new System.Drawing.Size(75, 23);
            this.bt_add.TabIndex = 6;
            this.bt_add.Text = ">";
            this.bt_add.UseVisualStyleBackColor = true;
            this.bt_add.Click += new System.EventHandler(this.bt_add_Click);
            // 
            // bt_remove
            // 
            this.bt_remove.Location = new System.Drawing.Point(386, 245);
            this.bt_remove.Name = "bt_remove";
            this.bt_remove.Size = new System.Drawing.Size(75, 23);
            this.bt_remove.TabIndex = 7;
            this.bt_remove.Text = "<";
            this.bt_remove.UseVisualStyleBackColor = true;
            this.bt_remove.Click += new System.EventHandler(this.bt_remove_Click);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(12, 80);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(97, 17);
            this.label2.TabIndex = 8;
            this.label2.Text = "Sound found :";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(464, 80);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(137, 17);
            this.label3.TabIndex = 9;
            this.label3.Text = "Sound to download :";
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(844, 408);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.bt_remove);
            this.Controls.Add(this.bt_add);
            this.Controls.Add(this.lb_download);
            this.Controls.Add(this.lb_found);
            this.Controls.Add(this.cb_type);
            this.Controls.Add(this.tb_id);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.bt_download);
            this.Name = "Form1";
            this.Text = "Music downloader (Spotify)";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button bt_download;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox tb_id;
        private System.Windows.Forms.ComboBox cb_type;
        private System.Windows.Forms.ListBox lb_found;
        private System.Windows.Forms.ListBox lb_download;
        private System.Windows.Forms.Button bt_add;
        private System.Windows.Forms.Button bt_remove;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
    }
}


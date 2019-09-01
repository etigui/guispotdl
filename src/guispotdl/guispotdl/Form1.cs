using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace guispotdl
{
    public partial class Form1 : Form {
        public Form1() {
            InitializeComponent();
            this.ClientSize = new Size(633, 60);
            cb_type.SelectedIndex = 0;
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void cb_type_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cb_type.Text == "Song")
            {
                this.ClientSize = new Size(633, 60);

            }
            else if(cb_type.Text == "Playlist")
            {
                this.ClientSize = new Size(633, 332);
            }
        }

        private void bt_add_Click(object sender, EventArgs e)
        {
            List<object> remove = new List<object>();
            foreach (var item in lb_found.SelectedItems)
            {
                if (!lb_download.Items.Contains(item))
                {
                    lb_download.Items.Add(item);
                    remove.Add(item);
                }
            }
            foreach (var item in remove)
            {
                lb_found.Items.Remove(item);
            }
        }

        private void bt_remove_Click(object sender, EventArgs e)
        {
            List<object> remove = new List<object>();
            foreach (var item in lb_download.SelectedItems)
            { 
                lb_found.Items.Add(item);
                remove.Add(item); 
            }
            foreach (var item in remove)
            {
                lb_download.Items.Remove(item);
            }
        }
    }
}

using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Dayton_Digital_Calibration
{
    public partial class Form1 : Form
    {
        TextBox searchbox;
        public Form1()
        {
            InitializeComponent();
            searchbox = new TextBox();
            searchbox.Size=new Size(100,20);
            panel1.Controls.Add(searchbox);
            searchbox.Location = new Point(this.Size.Width - searchbox.Size.Width - 20, searchbox.Location.Y);


        }

        private void listView1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void Form1_ResizeBegin(object sender, EventArgs e)
        {

        }

        private void Form1_ResizeEnd(object sender, EventArgs e)
        {

        }

        private void Form1_SizeChanged(object sender, EventArgs e)
        {
            searchbox.Location = new Point(this.Size.Width - searchbox.Size.Width - 20, searchbox.Location.Y);

        }

        private void toolStripButton1_Click(object sender, EventArgs e)
        {
            //Console.WriteLine(this.Width-(groupBox1.Location.X+groupBox1.Width));
            using (NewDevice nwd = new NewDevice())
            {
                DialogResult dr = nwd.ShowDialog();
                if (dr == DialogResult.OK)
                {
                    device tempdev = new device();
                    tempdev.Company = nwd.company;
                    tempdev.Serial = nwd.serial;
                    tempdev.Technician = nwd.tech;
                    tempdev.InsDate = nwd.insdate;

                    ListViewItem lvi = new ListViewItem();
                    lvi.Text = tempdev.Serial;
                    lvi.Tag = tempdev;
                    //Console.WriteLine(tempdev.Serial);
                    listView1.Items.Add(lvi);
                }
            }
        }

        private void listView1_DoubleClick(object sender, EventArgs e)
        {
            device dev4view = (device)listView1.SelectedItems[0].Tag;
            using (view_device vw = new view_device(dev4view))
            {
                DialogResult dr = vw.ShowDialog();
                if (dr == DialogResult.Yes)
                {
                    dev4view = vw.viewDev;
                }
            }
        }
    }
}

using PdfSharp;
using PdfSharp.Pdf;
using PdfSharp.Pdf.Advanced;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using TheArtOfDev.HtmlRenderer.PdfSharp;

namespace Dayton_Digital_Calibration
{
    public partial class view_device : Form
    {
        public device viewDev = new device();
        public view_device()
        {
            InitializeComponent();
        }
        public view_device(device dev)
        {
            InitializeComponent();
            //initui();
            if (dev != null)
            {
                this.viewDev = dev;
            }
            else
            {
                this.DialogResult = DialogResult.Cancel;
                this.Close();
            }
        }
        private void initui()
        {
            int l = 5;
            textBox1.Size = textBox2.Size = textBox3.Size = textBox4.Size = new Size(40, 20);
            textBox1.Text = textBox2.Text = textBox3.Text = textBox4.Text = "";
            textBox5.Enabled = false;
            checkBox1.Checked = false;
            button1.Enabled = false;
            button3.Enabled = false;
            textBox1.Enabled = false; textBox2.Enabled = false; textBox3.Enabled = false; textBox4.Enabled = false;
            label9.Enabled = label10.Enabled = label11.Enabled = label12.Enabled = false;
            label9.Location = new Point(l, l);
            textBox1.Location = new Point(label9.Location.X, label9.Size.Height + label9.Location.Y + l);
            label10.Location = new Point(textBox1.Location.X + textBox1.Width + l, label9.Location.Y);
            textBox2.Location = new Point(label10.Location.X, label9.Size.Height + label9.Location.Y + l);
            label11.Location = new Point(textBox2.Location.X + textBox2.Width + l, label9.Location.Y);
            textBox3.Location = new Point(label11.Location.X, label9.Size.Height + label9.Location.Y + l);
            label12.Location = new Point(textBox3.Location.X + textBox3.Width + l, label9.Location.Y);
            textBox4.Location = new Point(label12.Location.X, label9.Size.Height + label9.Location.Y + l);
            for (int i = 0; i < listView1.Columns.Count; i++)
            {
                listView1.Columns[i].Width = -2;
                listView2.Columns[i].Width = -2;

            }

        }
        private void view_device_Load(object sender, EventArgs e)
        {
            label5.Text = viewDev.Company;
            label6.Text = viewDev.Serial;
            label7.Text = viewDev.Technician;
            label8.Text = viewDev.InsDate.ToShortDateString();
            textBox5.Text = viewDev.Notes;
            listView1.View = View.Details;
            listView1.GridLines = true;
            listView1.FullRowSelect = true;
            listView2.View = View.Details;
            listView2.GridLines = true;
            listView2.FullRowSelect = true;
            //ListViewItem hzs = new ListViewItem("Hz");
            listView1.Clear();
            listView2.Clear();
            listView1.Columns.Add("Hz");
            listView2.Columns.Add("Hz");
            listView1.Columns.Add("Vert IPS before");
            listView1.Columns.Add("Long IPS before");
            listView1.Columns.Add("Tran IPS before");
            listView2.Columns.Add("Vert IPS after");
            listView2.Columns.Add("Long IPS after");
            listView2.Columns.Add("Tran IPS after");
            foreach (KeyValuePair<int, List<float>> i in viewDev.Response_bef)
            {
                ListViewItem lvi = new ListViewItem(new[] { i.Key.ToString(), i.Value[0].ToString(), i.Value[1].ToString(), i.Value[2].ToString() });
                listView1.Items.Add(lvi).Tag = i.Key;
            }
            foreach (KeyValuePair<int, List<float>> i in viewDev.Response_aft)
            {
                ListViewItem lvi = new ListViewItem(new[] { i.Key.ToString(), i.Value[0].ToString(), i.Value[1].ToString(), i.Value[2].ToString() });
                listView2.Items.Add(lvi).Tag = i.Key;
            }
            initui();
            view_device_SizeChanged(sender, e);

        }

        private void view_device_SizeChanged(object sender, EventArgs e)
        {
            int l = 10;
            int d = (panel1.Width - 2 * l) / 2;
            groupBox2.Width = d;
            groupBox3.Width = d;
            groupBox3.Location = new Point(panel1.Width - d - l / 2, groupBox1.Location.Y + groupBox1.Height + l / 2);
            groupBox2.Location = new Point(panel1.Location.X + l / 2, groupBox1.Location.Y + groupBox1.Height + l / 2);
            groupBox2.Height = panel1.Height - groupBox2.Location.Y - l / 2 - panel2.Height;
            groupBox3.Height = panel1.Height - groupBox3.Location.Y - l / 2 - panel2.Height;
            panel2.Width = panel1.Width;
            panel2.Location = new Point(panel1.Location.X, panel1.Height - panel2.Height);
        }

        private void label10_Click(object sender, EventArgs e)
        {

        }

        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {
            textBox1.Enabled = textBox2.Enabled = textBox3.Enabled = textBox4.Enabled =textBox5.Enabled= !textBox1.Enabled;
            label9.Enabled = label10.Enabled = label11.Enabled = label12.Enabled = !label9.Enabled;
            
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (this.DialogResult == DialogResult.Yes)
            {
                this.Close();
            }
            else
            {
                this.DialogResult = DialogResult.No;
                this.Close();
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (listView1.SelectedItems.Count > 0)
            {
                listView1.SelectedItems[0].SubItems[0].Tag = int.Parse(textBox1.Text);
                listView1.SelectedItems[0].SubItems[0].Text = (textBox1.Text);
                listView1.SelectedItems[0].SubItems[1].Text = (textBox2.Text);
                listView1.SelectedItems[0].SubItems[2].Text = (textBox3.Text);
                listView1.SelectedItems[0].SubItems[3].Text = (textBox4.Text);
            }
            else if (listView2.SelectedItems.Count > 0)
            {
                listView2.SelectedItems[0].SubItems[0].Tag = int.Parse(textBox1.Text);
                listView2.SelectedItems[0].SubItems[0].Text = (textBox1.Text);
                listView2.SelectedItems[0].SubItems[1].Text = (textBox2.Text);
                listView2.SelectedItems[0].SubItems[2].Text = (textBox3.Text);
                listView2.SelectedItems[0].SubItems[3].Text = (textBox4.Text);
            }
            viewDev.Response_bef.Clear();
            viewDev.Response_aft.Clear();
            for (int i = 0; i < listView1.Items.Count; i++)
            {
                viewDev.Response_bef.Add(int.Parse(listView1.Items[i].SubItems[0].Text),new List<float>() { int.Parse(listView1.Items[i].SubItems[1].Text), int.Parse(listView1.Items[i].SubItems[2].Text), int.Parse(listView1.Items[i].SubItems[3].Text) });
            }
            for (int i = 0; i < listView2.Items.Count; i++)
            {
                viewDev.Response_aft.Add(int.Parse(listView2.Items[i].SubItems[0].Text), new List<float>() { int.Parse(listView2.Items[i].SubItems[1].Text), int.Parse(listView2.Items[i].SubItems[2].Text), int.Parse(listView2.Items[i].SubItems[3].Text) });
            }
            viewDev.Notes = textBox5.Text;
            this.DialogResult = DialogResult.Yes;

        }

        private void listView1_SelectedIndexChanged(object sender, EventArgs e)
        {
            listView2.SelectedIndices.Clear();

            if (listView1.SelectedItems.Count > 0)
            {
                ListViewItem lvi = listView1.SelectedItems[0];
                textBox1.Text = lvi.SubItems[0].Text;
                textBox1.Tag = lvi.Tag;
                textBox2.Text = lvi.SubItems[1].Text;
                textBox3.Text = lvi.SubItems[2].Text;
                textBox4.Text = lvi.SubItems[3].Text;
                Console.WriteLine(lvi.Tag);
            }
        }

        private void listView2_SelectedIndexChanged(object sender, EventArgs e)
        {
            listView1.SelectedIndices.Clear();
            if (listView2.SelectedItems.Count > 0)
            {
                ListViewItem lvi = listView2.SelectedItems[0];
                textBox1.Text = lvi.SubItems[0].Text;
                textBox1.Tag = lvi.Tag;
                textBox2.Text = lvi.SubItems[1].Text;
                textBox3.Text = lvi.SubItems[2].Text;
                textBox4.Text = lvi.SubItems[3].Text;
                Console.WriteLine(lvi.Tag);
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            view_device_Load(sender, e);
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            ListViewItem lvi = listView1.SelectedItems.Count>0? listView1.SelectedItems[0] : listView2.SelectedItems.Count>0? listView2.SelectedItems[0]:null;
            if (lvi != null)
            {
                if (textBox1.Text != lvi.SubItems[0].Text || textBox2.Text != lvi.SubItems[1].Text || textBox3.Text != lvi.SubItems[2].Text || textBox4.Text != lvi.SubItems[3].Text||textBox5.Text!=viewDev.Notes)
                {
                    button1.Enabled = true;
                    button3.Enabled = true;
                }
                else
                {
                    button1.Enabled = false;
                    button3.Enabled = false;
                }
            }
        }

        private void button4_Click(object sender, EventArgs e)
        {
            PdfDocument pdf = PdfGenerator.GeneratePdf("<p style='text-align: center;'><img src='https://scontent.fewr1-5.fna.fbcdn.net/v/t1.0-9/88015798_190546708840534_8824736610076590080_n.jpg?_nc_cat=105&amp;_nc_sid=85a577&amp;_nc_ohc=XI_tDXqyW2kAX-jLCnQ&amp;_nc_ht=scontent.fewr1-5.fna&amp;oh=50e8f3b3ff3ac5f47de1667d4299bfd5&amp;oe=5E94C262' alt='' width='740' height='740' /></p> <p style='text-align: center;'>sdfsdf</p> <table style='height: 187px; margin-left: auto; margin-right: auto;' width='574'> <tbody> <tr> <td style='width: 108px;'>sdf</td> <td style='width: 108px;'>sdf</td> <td style='width: 108px;'>&nbsp;</td> <td style='width: 108px; text-align: center;'>&nbsp;</td> <td style='width: 108px;'>&nbsp;</td> </tr> <tr> <td style='width: 108px;'>&nbsp;</td> <td style='width: 108px;'>sdf</td> <td style='width: 108px;'>&nbsp;</td> <td style='width: 108px;'>&nbsp;</td> <td style='width: 108px;'>&nbsp;</td> </tr> <tr> <td style='width: 108px;'>&nbsp;</td> <td style='width: 108px;'>&nbsp;</td> <td style='width: 108px;'>sdf</td> <td style='width: 108px;'>&nbsp;</td> <td style='width: 108px;'>&nbsp;</td> </tr> <tr> <td style='width: 108px;'>&nbsp;</td> <td style='width: 108px;'>&nbsp;</td> <td style='width: 108px;'>&nbsp;</td> <td style='width: 108px;'>sdf</td> <td style='width: 108px;'>&nbsp;</td> </tr> <tr> <td style='width: 108px;'>&nbsp;</td> <td style='width: 108px;'>&nbsp;</td> <td style='width: 108px;'>&nbsp;</td> <td style='width: 108px;'>&nbsp;</td> <td style='width: 108px;'>sdf</td> </tr> </tbody> </table>", PageSize.A4);
            //PdfImage pdi = PdfImage.;
            pdf.Save("document.pdf");
            System.Diagnostics.Process.Start("document.pdf");

        }
    }
}

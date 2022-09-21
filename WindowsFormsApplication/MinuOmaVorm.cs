using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsFormsApplication
{
    public partial class MinuOmaVorm : Form
    {
        Random random = new Random();
        TreeView puu;
        Button nupp;
        Label silt;
        CheckBox mruut1, mruut2;
        RadioButton rnupp, rnupp2, rnupp3, rnupp4;
        PictureBox pilt;
        ProgressBar eriba;
        Timer aeg;
        TextBox tekst;
        public MinuOmaVorm()
        {
            //InitializeComponent();
            Height = 600;
            Width = 900;
            Text = "Minu oma vorm koos elementidega";
            Color color = Color.Aquamarine;
            BackColor = color;
            puu = new TreeView();
            puu.Dock = DockStyle.Left;
            puu.Location = new Point(0, 0);

            TreeNode oksad = new TreeNode("Elemendid");
            oksad.Nodes.Add(new TreeNode("Nupp"));
            oksad.Nodes.Add(new TreeNode("Silt"));
            oksad.Nodes.Add(new TreeNode("Dialoog aken"));
            oksad.Nodes.Add(new TreeNode("Märkeruut"));
            oksad.Nodes.Add(new TreeNode("Radionupp"));
            oksad.Nodes.Add(new TreeNode("Edenemisriba"));
            oksad.Nodes.Add(new TreeNode("Tekstkast"));
            oksad.Nodes.Add(new TreeNode("OmaVorm"));

            puu.AfterSelect += Puu_AfterSelect;
            puu.Nodes.Add(oksad);
            this.Controls.Add(puu);
        }
        private void Puu_AfterSelect(object sender, TreeViewEventArgs e)
        {
            silt = new Label
            {
                Text = "Minu esimene vorm",
                Size = new Size(200, 50),
                Location = new Point(200, 0)
            };
            mruut1 = new CheckBox
            {
                Checked = false,
                Text = "Üks",
                Location = new Point(silt.Left + silt.Width, 0),
                Width = 100,
                Height = 25
            };
            mruut2 = new CheckBox
            {
                Checked = false,
                Text = "Kaks",
                Location = new Point(silt.Left + silt.Width, mruut1.Height),
                Width = 100,
                Height = 25
            };
            pilt = new PictureBox
            {
                Image = new Bitmap(@"..\..\dolphine.png"),
                Location = new Point(300, 450),
                Size = new Size(100, 100),
                SizeMode = PictureBoxSizeMode.Zoom,
            };
            rnupp = new RadioButton
            {
                Text = "Paremale",
                Width = 112,
                Location = new Point(mruut2.Left + mruut2.Width, mruut1.Height + mruut2.Height),
            };
            rnupp2 = new RadioButton
            {
                Text = "Vasakule",
                Width = 112,
                Location = new Point(mruut2.Left + mruut2.Width + rnupp.Width, mruut1.Height + mruut2.Height),
            };
            rnupp3 = new RadioButton
            {
                Text = "Ülesse",
                Width = 112,
                Location = new Point(mruut2.Left + mruut2.Width + rnupp.Width + rnupp2.Width, mruut1.Height + mruut2.Height),
            };
            rnupp4 = new RadioButton
            {
                Text = "Alla",
                Width = 112,
                Location = new Point(mruut2.Left + mruut2.Width + rnupp.Width + rnupp2.Width + rnupp3.Width, mruut1.Height + mruut2.Height),
            };
            eriba = new ProgressBar
            {
                Width = 400,
                Height = 30,
                Location = new Point(350, 500),
                Value = 0,
                Minimum = 0,
                Maximum = 100,
                Step = 1,
                BackColor = Color.Green,
            };
            aeg = new Timer();
            tekst = new TextBox()
            {
                Font = new Font("Arial", 34, FontStyle.Italic),
                Location = new Point(350, 400),
                Enabled = true,
            };

            if (e.Node.Text == "Nupp")
            {
                nupp = new Button();
                nupp.Text = "Vajuta siia";
                nupp.Height = 30;
                nupp.Width = 100;
                nupp.Location = new Point(200, 100);
                nupp.Click += Nupp_Click;
                this.Controls.Add(nupp);
            }
            else if (e.Node.Text == "Silt")
            {
                silt.BorderStyle = BorderStyle.FixedSingle;
                silt.MouseEnter += Silt_MouseEnter;
                silt.MouseLeave += Silt_MouseLeave;
                this.Controls.Add(silt);
            }
            else if (e.Node.Text == "Dialoog aken")
            {
                MessageBox.Show("Hello, my name is Gustavo, but you can call me Gus", "Kõige lihtsam aken");
                var vastus = MessageBox.Show("Kas paneme aken kinni?", "Valik", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (vastus == DialogResult.Yes)
                {
                    this.Close();
                }
                else
                {
                    MessageBox.Show("Siis töötame edasi", "Vastus oli NO");
                }
            }
            else if (e.Node.Text == "Märkeruut")
            {
                mruut1.CheckedChanged += Mruut_Change; //new EventHandler(Mruut_Change)
                mruut2.CheckedChanged += Mruut_Change;

                this.Controls.Add(mruut1);
                this.Controls.Add(mruut2);
            }
            else if (e.Node.Text == "Radionupp")
            {
                
                
                rnupp.CheckedChanged += Rnupp_Change;
                rnupp2.CheckedChanged += Rnupp_Change;
                rnupp3.CheckedChanged += Rnupp_Change;
                rnupp4.CheckedChanged += Rnupp_Change;

                this.Controls.Add(rnupp);
                this.Controls.Add(rnupp2);
                this.Controls.Add(rnupp3);
                this.Controls.Add(rnupp4);
                this.Controls.Add(pilt);
            }
            else if (e.Node.Text == "Edenemisriba")
            {
                aeg.Enabled = true;
                aeg.Tick += Aeg_Tick;
                this.Controls.Add(eriba);
            }
            else if (e.Node.Text == "Tekstkast")
            {
                
                tekst.MouseDoubleClick += Tekst_DoubleClick;
                this.Controls.Add(tekst);
            }
            else if (e.Node.Text == "OmaVorm")
            {
                OmaVorm oma = new OmaVorm("Kuulame muusikat", "Vajuta Siia", @"..\..\bubbles_sfx.wav");
                oma.ShowDialog();
            }
        }
        private void Nupp_Click(object sender, EventArgs e)
        {
            int red, green, blue;
            red = random.Next(100, 255);
            green = random.Next(100, 255);
            blue = random.Next(100, 255);
            this.BackColor = Color.FromArgb(red, green, blue);
            nupp.ForeColor = Color.BlueViolet;
            nupp.Cursor = Cursors.WaitCursor;
        }
        private void Silt_MouseEnter(object sender, EventArgs e)
        {
            silt.ForeColor = Color.White;
            silt.BackColor = Color.Black;
        }
        private void Silt_MouseLeave(object sender, EventArgs e)
        {
            silt.ForeColor = Color.Black;
            silt.BackColor = Color.Transparent;
        }
        private void Mruut_Change(object sender, EventArgs e)
        {
            if (mruut1.Checked == false && mruut2.Checked == false)
            {
                this.ForeColor = Color.Black;
                MessageBox.Show("0");
            }
            else if (mruut1.Checked == true && mruut2.Checked == false)
            {
                this.ForeColor = Color.Red;
                MessageBox.Show("1");
            }
            else if (mruut2.Checked == true && mruut1.Checked == false)
            {
                this.ForeColor = Color.SkyBlue;
                MessageBox.Show("2");
            }
            else if (mruut1.Checked == true && mruut2.Checked == true)
            {
                this.ForeColor = Color.White;
                MessageBox.Show("3");
            }
        }
        private void Rnupp_Change(object sender, EventArgs e)
        {

            if (rnupp.Checked == true)
            {
                pilt.Location = new Point(pilt.Left + 10, pilt.Top);
                rnupp.Checked = false;
            }
            else if (rnupp2.Checked == true)
            {
                pilt.Location = new Point(pilt.Left - 10, pilt.Top);
                rnupp2.Checked = false;
            }
            else if (rnupp3.Checked == true)
            {
                pilt.Location = new Point(pilt.Left, pilt.Top - 10);
                rnupp3.Checked = false;
            }
            else if (rnupp4.Checked == true)
            {
                pilt.Location = new Point(pilt.Left, pilt.Top + 10);
                rnupp4.Checked = false;
            }          
        }
        private void Aeg_Tick(object sender, EventArgs e)
        {
            eriba.PerformStep();
            if (eriba.Value == 100)
            {
                eriba.Value -= 100;
            }
        }
        private void Tekst_DoubleClick(object sender, EventArgs e)
        {
            if (tekst.Enabled == true)
            {
                tekst.Enabled = false;
            }
            else if (tekst.Enabled == false)
            {
                tekst.Enabled = true;
            }
        }
    }
}
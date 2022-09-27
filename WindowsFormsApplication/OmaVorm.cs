using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Media;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Diagnostics;
using System.IO;

namespace WindowsFormsApplication
{
    public class OmaVorm : Form
    {
        Label failNimi;        
        public OmaVorm() { }
        public OmaVorm(string Pealkiri, string Nupp) 
        {            
            this.ClientSize = new System.Drawing.Size(300, 300);
            this.Text = Pealkiri;
            Button nupp = new Button
            {
                Text = Nupp,
                Location = new System.Drawing.Point(50, 50),
                Size = new System.Drawing.Size(100,25),
                BackColor = System.Drawing.Color.Aquamarine,
                ForeColor = System.Drawing.Color.Black,
            };
            
            
            nupp.Click += NuppClick;
            this.Controls.Add(nupp);
            
        }
        bool NuppWasClicked;
        private void NuppClick(object sender, EventArgs e) 
        {
            
            Button nupp_sender = (Button)sender;
            nupp_sender.Enabled = true;

            Label failNimi = new Label
            {
                Text = "",
                Location = new System.Drawing.Point(150, 50),
                Size = new System.Drawing.Size(100, 25),
                BackColor = System.Drawing.Color.Aquamarine,
                ForeColor = System.Drawing.Color.Black,
            };

            Button nupp2 = new Button
            {
                Text = "Play",
                Location = new System.Drawing.Point(50, 100),
                Size = new System.Drawing.Size(100, 25),
                BackColor = System.Drawing.Color.Aquamarine,
                ForeColor = System.Drawing.Color.Black,
            };
            nupp2.Click += NuppClick2;

            OpenFileDialog failiValik = new OpenFileDialog();
            DialogResult tulemus = failiValik.ShowDialog();
            
            if (tulemus == DialogResult.OK)
            {
                if (NuppWasClicked)
                {
                    MuusikaKuulamine(failiValik.FileName);
                    MessageBox.Show("Nice");
                }   
            }        
            
            string[] files = failiValik.FileNames;
            foreach (string item in files)
            {
                string[] asd = item.Split('\\');
                failNimi.Text = asd[asd.Length - 1];                               
            }
            
            this.Controls.Add(failNimi);
            this.Controls.Add(nupp2);
            
        }
        private void MuusikaKuulamine(string file)
        {
            using (var muusika = new SoundPlayer(file))
            {
                muusika.Play();
            }
        }
        private void NuppClick2(object sender, EventArgs e)
        {            
            NuppWasClicked = true;
        }
    }    
}
//Кнопка "Play" с воспроизведением файла >>> после нажатия текст меняется на "Pause" и музыка приостанавливается

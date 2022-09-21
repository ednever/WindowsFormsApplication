using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Media;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsFormsApplication
{
    public class OmaVorm : Form
    {
        public OmaVorm() { }
        public OmaVorm(string Pealkiri, string Nupp, string Fail) 
        {
            this.ClientSize = new System.Drawing.Size(300, 300);
            this.Text = Pealkiri;
            Button nupp = new Button
            {
                Text = Nupp,
                Location = new System.Drawing.Point(50, 50),
                Size = new System.Drawing.Size(100,50),
                BackColor = System.Drawing.Color.Aquamarine,
                ForeColor = System.Drawing.Color.Black,
            };
            
            Label failNimi = new Label
            {
                Text = Fail,
                Location = new System.Drawing.Point(50, 150),
                Size=new System.Drawing.Size(100, 50),
                BackColor=System.Drawing.Color.Aquamarine,
                ForeColor = System.Drawing.Color.Black,
            };
            this.Controls.Add(nupp);
            this.Controls.Add(failNimi);
        }
        private void NuppClick(object sender, EventArgs e)
        {
            Button nupp_sender = (Button)sender;
            var vastus = MessageBox.Show("Kas tahate muusikat kuulata?","Küsimus", MessageBoxButtons.YesNo);
            if (vastus == DialogResult.Yes)
            {
                using (var muusika = new SoundPlayer(Fail))
                {
                    muusika.Play();
                }
            }
            else
            {
                MessageBox.Show(":(");
            }
        }
    }
}

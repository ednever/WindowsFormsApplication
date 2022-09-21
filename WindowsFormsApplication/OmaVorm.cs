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
        string Fail = @"..\..\bubbles_sfx.wav";
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
                Size = new System.Drawing.Size(100, 50),
                BackColor = System.Drawing.Color.Aquamarine,
                ForeColor = System.Drawing.Color.Black,
            };
            nupp.Click += NuppClick;
            this.Controls.Add(nupp);
            this.Controls.Add(failNimi);
        }
        private void NuppClick(object sender, EventArgs e)
        {
            Button nupp_sender = (Button)sender;
            Process.Start("explorer", "C:\\");
            string fileName = "bubbles_sfx.wav";
            string fullPath = Path.GetFullPath(fileName);
            MessageBox.Show(fullPath);
            //Process.Start(fullPath);

            //Cmd(Fail);
            //var vastus = MessageBox.Show("Kas tahate muusikat kuulata?","Küsimus", MessageBoxButtons.YesNo);
            //if (vastus == DialogResult.Yes)
            //{
            //    using (SoundPlayer muusika = new SoundPlayer()) //@"..\..\bubbles_sfx.wav"
            //    {
            //        muusika.SoundLocation = Fail;
            //        muusika.Load();
            //        muusika.Play();
            //        MessageBox.Show("Muusika mängib");
            //    }
            //}
            //else
            //{
            //    MessageBox.Show(":(");
            //}
        }
        //void Cmd(string line) 
        //{
        //    Process.Start(new ProcessStartInfo {FileName = "explorer", Arguments = $"/n, /select, {line}"});
        //}

    }
}
//Открытие формы - DONE
//Кнопка "Выбрать файл из проводника"
//Поиск файла в проводнике
//Сохранение пути выбранного музыкального файла
//Кнопка "Play" с воспроизведением файла >>> после нажатия текст меняется на "Pause" и музыка приостанавливается
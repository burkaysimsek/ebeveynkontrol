using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Drawing.Drawing2D;
using System.Runtime.InteropServices;
using System.Drawing.Imaging;
using System.Net.Mail;
using System.Net;

namespace PC_Kapanma_Ayarlayıcısı



{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();


        }

        bool kapat = false, uyari = false, pcres = false, pcuyku = false, mesaj = false,gizlee = false,giris = false;

        DateTime dt = DateTime.Now;
       
        int saat = 0;
        int sureresim = 0;

       

        private void pckapa()
        {
            System.Diagnostics.Process process = new System.Diagnostics.Process();
            process.StartInfo = new System.Diagnostics.ProcessStartInfo()
            {
                UseShellExecute = false,
                CreateNoWindow = true,
                WindowStyle = System.Diagnostics.ProcessWindowStyle.Hidden,
                FileName = "cmd.exe",
                Arguments = "/C shutdown -s -f -t 1",
                RedirectStandardError = true,
                RedirectStandardOutput = true


            };
            process.Start();

        }

        private void pcrest()
        {
            System.Diagnostics.Process process = new System.Diagnostics.Process();
            process.StartInfo = new System.Diagnostics.ProcessStartInfo()
            {
                UseShellExecute = false,
                CreateNoWindow = true,
                WindowStyle = System.Diagnostics.ProcessWindowStyle.Hidden,
                FileName = "cmd.exe",
                Arguments = "/C shutdown -r",
                RedirectStandardError = true,
                RedirectStandardOutput = true


            };
            process.Start();
        }

        private void uyku()
        {
            System.Diagnostics.Process process = new System.Diagnostics.Process();
            process.StartInfo = new System.Diagnostics.ProcessStartInfo()
            {
                UseShellExecute = false,
                CreateNoWindow = true,
                WindowStyle = System.Diagnostics.ProcessWindowStyle.Hidden,
                FileName = "cmd.exe",
                Arguments = "/C rundll32.exe powrprof.dll,SetSuspendState 0,1,0",
                RedirectStandardError = true,
                RedirectStandardOutput = true


            };
            process.Start();
        }

      
            

        








        private void simpleButton1_Click(object sender, EventArgs e)
        {
            kapat = true;
            groupControl1.Focus();
            
            timer1.Start();
        }

        private void timer1_Tick(object sender, EventArgs e)
        {



            textEdit1.Text = DateTime.Now.ToLongTimeString();
            int saat, dakika, saniye;
            saat = Convert.ToInt32(Ksaat.Text);
            dakika = Convert.ToInt32(comboBox2.Text);
            saniye = Convert.ToInt32(comboBox1.Text);

            textEdit4.ResetText();

            textEdit5.Text = Ksaat.Text + ":" + comboBox2.Text + ":" + comboBox1.Text;

            int Ksa_kalan = saat - DateTime.Now.Hour;
            int Kdk_kalan = dakika - DateTime.Now.Minute;
            int Ksn_kalan = saniye - DateTime.Now.Second;
            dt = DateTime.Now.AddHours(Ksa_kalan).AddMinutes(Kdk_kalan).AddSeconds(Ksn_kalan);
            TimeSpan diff = dt.Subtract(DateTime.Now);
            textEdit4.Text = string.Format("{0:00}:{1:00}:{2:00}", diff.Hours, diff.Minutes, diff.Seconds);


            if (saat == DateTime.Now.Hour && dakika == DateTime.Now.Minute && saniye == DateTime.Now.Second)
            {
                if (kapat == true && uyari == true)
                {
                    timer1.Stop();
                    DialogResult asd = MessageBox.Show("Bilgisayar Kapanıyor", "Uyarı Penceresi", MessageBoxButtons.OKCancel, MessageBoxIcon.Warning);
                    if (asd == DialogResult.OK)
                    {

                        pckapa();

                    }
                    else
                    {
                        saat = 0;
                        timer1.Stop();
                    }


                }


                else if (kapat == true)
                {

                    pckapa();
                }

                if (pcres == true && uyari == true)
                {

                    timer1.Stop();
                    DialogResult asd = MessageBox.Show("Bilgisayar Kapanıyor", "Uyarı Penceresi", MessageBoxButtons.OKCancel, MessageBoxIcon.Warning);
                    if (asd == DialogResult.OK)
                    {


                        pcrest();

                    }
                    else if (pcres == true)
                    {

                        pcrest();
                    }
                    else
                    {
                        saat = 0;
                        timer1.Stop();
                    }




                }
                if (pcuyku == true && uyari == true)
                {
                    timer1.Stop();
                    DialogResult asd = MessageBox.Show("Bilgisayar Kapanıyor", "Uyarı Penceresi", MessageBoxButtons.OKCancel, MessageBoxIcon.Warning);
                    if (asd == DialogResult.OK)
                    {

                        uyku();

                    }

                    else if (pcres == true)
                    {

                        uyku();
                    }

                    else
                    {
                        saat = 0;
                        timer1.Stop();
                    }

                }





            }
        }

        private void groupControl1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void Form1_Load(object sender, EventArgs e)
        {



            label10.Visible = false;






            panel2.Visible = true;
           


          



            timer1.Start();

            simpleButton1.ToolTip = "Bilgisayarı süre dolunca kapatır.";
            simpleButton5.ToolTip = "Bilgisisayar kapatma süresi dolunca onay vermeniz gerekir yoksa pc açık kalır!.";


            for (int i = 0; i < 24; i++)
            {
                if (i < 10)
                    Ksaat.Items.Add("0" + i.ToString());
                else
                    Ksaat.Items.Add(i.ToString());
            }
            for (int i = 0; i < 60; i++)
            {
                if (i < 10)
                { comboBox2.Items.Add("0" + i.ToString()); comboBox2.Items.Add("0" + i.ToString()); }
                else
                { comboBox1.Items.Add(i.ToString()); comboBox2.Items.Add(i.ToString()); }
            }
        }

        private void textEdit1_EditValueChanged(object sender, EventArgs e)
        {

        }

        private void textEdit1_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = Char.IsLetterOrDigit(e.KeyChar) || Char.IsSymbol(e.KeyChar) || Char.IsPunctuation(e.KeyChar) || Char.IsWhiteSpace(e.KeyChar) || Char.IsControl(e.KeyChar) || Char.IsNumber(e.KeyChar);
        }

        private void groupBox1_Enter(object sender, EventArgs e)
        {

        }

        private void simpleButton2_Click(object sender, EventArgs e)
        {
            Application.Restart();
        }

        private void Form1_MouseClick(object sender, MouseEventArgs e)
        {
            groupControl1.Focus();
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            groupControl1.Focus();
        }

        private void comboBox2_SelectedIndexChanged(object sender, EventArgs e)

        {
            textEdit6.Visible = false;
            groupControl1.Focus();
        }

        private void Ksaat_SelectedIndexChanged(object sender, EventArgs e)
        {
            groupControl1.Focus();
            textEdit6.Visible = false;
        }

        private void textEdit3_EditValueChanged(object sender, EventArgs e)
        {

        }

        private void simpleButton3_Click(object sender, EventArgs e)
        {
            
            pcres = true;

            groupControl1.Focus();

            timer1.Start();

        }

        private void simpleButton4_Click(object sender, EventArgs e)
        {

           

            pcuyku = true;
            groupControl1.Focus();

            timer1.Start();
        }

        private void textEdit4_EditValueChanged(object sender, EventArgs e)
        {

        }

        private void textEdit4_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = Char.IsLetterOrDigit(e.KeyChar) || Char.IsSymbol(e.KeyChar) || Char.IsPunctuation(e.KeyChar) || Char.IsWhiteSpace(e.KeyChar) || Char.IsControl(e.KeyChar) || Char.IsNumber(e.KeyChar);
        }

        private void textEdit5_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = Char.IsLetterOrDigit(e.KeyChar) || Char.IsSymbol(e.KeyChar) || Char.IsPunctuation(e.KeyChar) || Char.IsWhiteSpace(e.KeyChar) || Char.IsControl(e.KeyChar) || Char.IsNumber(e.KeyChar);
        }



        private void simpleButton6_Click_1(object sender, EventArgs e)
        {

            gizlee = true;
            DialogResult gizle = MessageBox.Show("Bu işlem programı görev yöneticisinden ve ekrandan gizler. ONAYLIYORMUSUNUZ ?", "Uyarı Penceresi", MessageBoxButtons.OKCancel, MessageBoxIcon.Warning);
            if (gizle == DialogResult.OK)
            {

               
                Hide();

            }
            else
            {
                groupControl1.Focus();
            }

        }

        private void simpleButton5_Click(object sender, EventArgs e)
        {

        }

        private void simpleButton7_Click(object sender, EventArgs e)
        {
           
            groupControl1.Focus();
        }

        private void simpleButton9_Click(object sender, EventArgs e)
        {




            timer3.Start();


            


        }

        private void simpleButton10_Click_1(object sender, EventArgs e)
        {
            panel2.Visible = true;
            giris = false;
            groupControl2.Visible = false;
            label10.Visible = true;
        }

        private void label10_Click(object sender, EventArgs e)
        {
            
        }

        private void simpleButton12_Click(object sender, EventArgs e)
        {
            /*
            int sifre;
            sifre = Convert.ToInt32(textBox2.Text);
            if(sifre == 123321)
            {
                panel3.Visible = false;
                panel2.Visible = false;

            }
            else
            {
                MessageBox.Show("Şifreniz Yanlış!");
            }
            */
        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {

        }

        private void label12_Click(object sender, EventArgs e)
        {

        }

        private void panel3_Paint(object sender, PaintEventArgs e)
        {

        }

       

        private void panel2_Paint(object sender, PaintEventArgs e)
        {
            
        }

        private void label10_Click_1(object sender, EventArgs e)
        {
            groupControl2.Visible = true;
        }

        private void simpleButton13_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void simpleButton12_Click_2(object sender, EventArgs e)
        {
            textBox2.Focus();
            try
            {
                int sifre;
                sifre = Convert.ToInt32(textBox2.Text);

                if (sifre == 123321)
                {

                    giris = true;

                    panel2.Visible = false;
                    textBox2.ResetText();
                }
            }
            catch
            {
                MessageBox.Show("Şifrenizi kontrol ediniz.");
            }

        }

        private void simpleButton9_Click_1(object sender, EventArgs e)
        {
            timer3.Start();
        }

        private void numericUpDown2_ValueChanged(object sender, EventArgs e)
        {

        }

        private void labelControl6_Click(object sender, EventArgs e)
        {

        }

        private void Form1_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (giris != true)
            {
                e.Cancel = true;
                MessageBox.Show("Çıkış yapabilmeniz için giriş yapmanız gerekmekte.");
            }


        }

        private void timer3_Tick(object sender, EventArgs e)
        {
            

            sureresim++;

            

            if(sureresim == 20 && textEdit2.Text != "")


            {
                int sayi = 0;
                Random rastgele = new Random();
                for (int i = 0; i < 5; i++)
                {
                    sayi = rastgele.Next(1, 100);

                }

                sureresim = 0;
                string a = textEdit2.Text;
                DateTime tarihsaat = DateTime.Now;

                Bitmap Screenshot = new Bitmap(Screen.PrimaryScreen.Bounds.Width, Screen.PrimaryScreen.Bounds.Height);
                Graphics GFX = Graphics.FromImage(Screenshot);
                GFX.CopyFromScreen(Screen.PrimaryScreen.Bounds.X, Screen.PrimaryScreen.Bounds.Y, 0, 0, Screen.PrimaryScreen.Bounds.Size);
                

                Screenshot.Save(@"d:\\ss.png"+sayi,ImageFormat.Png);


                try
                {



                    SmtpClient sc = new SmtpClient();
                    sc.Port = 587;
                    sc.Host = "smtp.gmail.com";
                    sc.EnableSsl = true;



                    sc.Credentials = new NetworkCredential("ebeveynkontrolprogrami@gmail.com", "qwe12asd");
                    MailMessage mail = new MailMessage();
                    mail.From = new MailAddress("ebeveynkontrolprogrami@gmail.com", "EBEVEYN KONTROL PROGRAMI SCREENSHOT");
                    mail.To.Add(a);
                    mail.Subject = "Ekran Fotoları";
                    mail.IsBodyHtml = true;
                    mail.Body = "Tarih & Saat : " + tarihsaat;
                    mail.Attachments.Add(new Attachment("d://ss.png"));
                    sc.Send(mail);










                }

                catch
                {
                    MessageBox.Show("Email Adresinizi Doğru Girdiğinizden Emin olun.");
                }




                
            }


            










        }

        public void simpleButton11_Click(object sender, EventArgs e)
        {

           
           
            timer2.Start();
         
           
            mesaj = true;
           


        }

        private void simpleButton10_Click(object sender, EventArgs e)
        {


        }

        public void simpleButton8_Click(object sender, EventArgs e)
        {
            labelControl4.Visible = false;
            comboBox3.Visible = true;
            numericUpDown1.Visible = true;
            textBox1.Visible = false;
            simpleButton8.Visible = false;
            labelControl3.Visible = true;


        }

        private void timer2_Tick(object sender, EventArgs e)
        {
            decimal a, b;

            saat += 1;

            if (comboBox3.SelectedIndex == 0)

            {
                a = 3600 * numericUpDown1.Value;
                if (mesaj == true)

                {

                    if (saat == a)
                    {

                        saat = 0;
                        mesaj = false;
                        MessageBox.Show("Yönetici Mesajı : " + textBox1.Text);

                    }


                }
            }

            else if (comboBox3.SelectedIndex == 1)

            {
                b = 60 * numericUpDown1.Value;
                if (mesaj == true)

                {

                    if (saat == b)
                    {

                        saat = 0;
                        mesaj = false;
                        MessageBox.Show("Yönetici Mesajı : " + textBox1.Text);

                    }
                }

                







            }




        }
    }
}


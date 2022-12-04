using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Paradox_Hr
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {

            if(string.IsNullOrEmpty(Properties.Settings.Default.user))
                timer1.Start();

            else
            {
                this.Hide();
                main main = new main();
                main.Show();
            }
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            if (this.Opacity != 1)
            {
                this.Opacity += 0.1;
            }
            else timer1.Stop();

            
        }

        int Movex;
        int Mouse_X;
        int Mouse_Y;

        private void guna2ShadowPanel1_MouseUp(object sender, MouseEventArgs e)
        {
            Movex = 0;
        }

        private void guna2ShadowPanel1_MouseMove(object sender, MouseEventArgs e)
        {
            if (Movex == 1)
            {
                this.SetDesktopLocation(MousePosition.X - Mouse_X, MousePosition.Y - Mouse_Y);
            }
        }

        private void guna2ShadowPanel1_MouseDown(object sender, MouseEventArgs e)
        {
            Movex = 1;
            Mouse_X = e.X;
            Mouse_Y = e.Y;
        }

        private void guna2Button1_Click(object sender, EventArgs e)
        {
            using (WebClient client = new WebClient())
            {
                try
                {
                    #region POST YAPILIYOR
                    client.Headers.Add("user-agent", "Mozilla/4.0 (compatible; MSIE 6.0; " +
                                  "Windows NT 5.2; .NET CLR 1.0.3705;)");
                    string postUrl = "https://www.ripeapplessoftware.com/paradox";
                    var gelenYanit = client.UploadValues(postUrl, new NameValueCollection() { { "i", "login" }, { "mail", guna2TextBox1.Text },{ "pass", guna2TextBox2.Text } });
                    #endregion
                    #region POST NETİCESİNDE ÇIKTI ALINIYOR
                    string result = System.Text.Encoding.UTF8.GetString(gelenYanit);
                   if(result != "Giriş Başarılı")
                    {
                        guna2Button1.Text = result;
                    }

                    else
                    {
                        Properties.Settings.Default.user = guna2TextBox1.Text;
                        Properties.Settings.Default.Save();
                        this.Hide();
                        main main = new main();
                        main.Show();
                    }
                    #endregion
                }
                catch 
                {
                
                }
            }
        }

        private void guna2TextBox1_TextChanged(object sender, EventArgs e)
        {
            guna2Button1.Text = "Giriş Yap";
        }

        private void guna2TextBox2_TextChanged(object sender, EventArgs e)
        {
            guna2Button1.Text = "Giriş Yap";
        }

        private void guna2ShadowPanel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void guna2ControlBox1_Click(object sender, EventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void guna2Button2_Click(object sender, EventArgs e)
        {
            
            singup singup = new singup();
            singup.Show();
        }
    }
}

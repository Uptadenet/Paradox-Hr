using Guna.UI2.WinForms;
using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Net;
using System.Reflection.Emit;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Paradox_Hr
{
    public partial class main : Form
    {
        public main()
        {
            InitializeComponent();
        }




        bool devam = true;

        private void timer1_Tick(object sender, EventArgs e)
        {


            label4.Text = DateTime.Now.ToShortTimeString()+":"+DateTime.Now.Second+":"+DateTime.Now.Millisecond;
            if (devam == true)
                label2.Text = RandomString(10);
 
           
        }

        public static string RandomString(int length)
        {
            Random random = new Random();
            const string chars = "ABCDEFGHIJKLMNOPQRSTUVWXYZ0123456789";
            return new string(Enumerable.Repeat(chars, length)
                .Select(s => s[random.Next(s.Length)]).ToArray());
        }

        private void guna2ShadowPanel1_Paint(object sender, PaintEventArgs e)
        {
            timer1.Start();
        }



        NotifyIcon notify_Icon = new NotifyIcon();






        static string sifre = "";
        private void guna2Button1_Click(object sender, EventArgs e)
        {

            if (devam == true)
            {
                

                using (WebClient client = new WebClient())
                {
                    try
                    {

                        client.Headers.Add("user-agent", "Mozilla/4.0 (compatible; MSIE 6.0; " +
                                      "Windows NT 5.2; .NET CLR 1.0.3705;)");
                        string postUrl = "https://www.ripeapplessoftware.com/paradox";
                        var gelenYanit = client.UploadValues(postUrl, new NameValueCollection() { { "i", "create" }, { "user", Properties.Settings.Default.user } });

                
                        string result = System.Text.Encoding.UTF8.GetString(gelenYanit);

                        devam = false;
                        sifre = result;
                        label2.Text = sifre;

                        label3.Visible = true;


                        guna2Button1.Text = "Şifreyi Kopyala";

                    }
                    catch
                    {

                    }
                }
            }
            else
            {

                label3.Visible = false;

                Clipboard.SetText(label2.Text);
                devam = true;
                guna2Button1.Text = "Şifre Oluştur";

            }
        }

        private void guna2ControlBox1_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void guna2Button2_Click(object sender, EventArgs e)
        {
            keys keys = new keys();
            keys.Show();
        }

        private void guna2Button3_Click(object sender, EventArgs e)
        {
            Properties.Settings.Default.user = null;
            Properties.Settings.Default.Save();
            Application.Exit();
        }

        int Movex;
        int Mouse_X;
        int Mouse_Y;
        private void guna2ShadowPanel1_MouseDown(object sender, MouseEventArgs e)
        {
            Movex = 1;
            Mouse_X = e.X;
            Mouse_Y = e.Y;
        }

        private void guna2ShadowPanel1_MouseMove(object sender, MouseEventArgs e)
        {

            if (Movex == 1)
            {
                this.SetDesktopLocation(MousePosition.X - Mouse_X, MousePosition.Y - Mouse_Y);
            }
        }

        private void guna2ShadowPanel1_MouseUp(object sender, MouseEventArgs e)
        {
            Movex = 0;
        }

        private void main_Load(object sender, EventArgs e)
        {

        }
    }
}

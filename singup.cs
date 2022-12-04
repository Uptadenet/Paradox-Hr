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
    public partial class singup : Form
    {
        public singup()
        {
            InitializeComponent();
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
                    var gelenYanit = client.UploadValues(postUrl, new NameValueCollection() { { "i", "singup" }, { "user", guna2TextBox1.Text }, { "pass", guna2TextBox2.Text } });
                    #endregion
                    #region POST NETİCESİNDE ÇIKTI ALINIYOR
                    string result = System.Text.Encoding.UTF8.GetString(gelenYanit);
                    if (result != "Bu Eposta Sisteme Kayıtlı!")
                    {
                        MessageBox.Show("Hesabınız Oluşturuldu. Bilgilerinizi Kullanarak Sisteme Giriş Yapabilirsiniz.", "BAŞARILI");
                        Application.Restart();
                    }

                    else
                    {

                        MessageBox.Show("Girdiğiniz E-Posta Adresinizi Başka Bir Hesap Kullanıyor.", "BAŞARISIZ");
                        guna2TextBox1.Clear();
                        guna2TextBox2.Clear();
                    }
                    #endregion
                }
                catch ( Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
            }
        }

        private void guna2ControlBox1_Click(object sender, EventArgs e)
        {
           
        }
    }
}

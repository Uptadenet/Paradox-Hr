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
using System.Threading.Tasks;
using System.Windows.Forms;
using Label = System.Windows.Forms.Label;

namespace Paradox_Hr
{
    public partial class keys : Form
    {
        public keys()
        {
            InitializeComponent();
        }

        private void keys_Load(object sender, EventArgs e)
        {
           


            using (WebClient client = new WebClient())
            {
                try
                {

                    client.Headers.Add("user-agent", "Mozilla/4.0 (compatible; MSIE 6.0; " +
                                  "Windows NT 5.2; .NET CLR 1.0.3705;)");
                    string postUrl = "https://www.ripeapplessoftware.com/paradox";
                    var gelenYanit = client.UploadValues(postUrl, new NameValueCollection() { { "i", "mycodes" }, { "user", Properties.Settings.Default.user } });


                    string result = System.Text.Encoding.UTF8.GetString(gelenYanit);


                    string[] keys = result.Split('&');

                    int w = 0, h = 0;

                    for(int i = 0; i< keys.Length; i++) 
                    { 
                        Guna2GroupBox box = new Guna2GroupBox();
                        box.Font = new Font("Segoe UI", 15);
                        box.TextAlign = HorizontalAlignment.Center;
                        box.Text = keys[i].Split(',')[0];
                        box.Size = new Size(300, 117);
                        box.Location = new Point(20, 20+h);
                        box.BorderColor = Color.FromArgb(73, 113, 116);
                        box.CustomBorderColor = Color.FromArgb(73, 113, 116);
                        box.ForeColor = Color.White;
                        box.FillColor = Color.White;
                        box.BorderRadius = 7;

                        System.Windows.Forms.Label label = new Label();
                        label.Font = new Font("Segoe UI",9);
                        label.AutoSize = true;
                        label.Text = "Oluşturulma tarihi : " + keys[i].Split(',')[1];
                        label.ForeColor= Color.Black;

                        label.Location = new Point(30, 45);

                        box.Controls.Add(label);


                        Guna2Button button = new Guna2Button();
                        button.Size = new Size(121, 33);
                        button.Location = new Point(90, 75);
                        button.BorderRadius = 4;
                        button.Text = "Kodu Kopyala";
                        button.Font = new Font("Segoe UI", 9);
                        button.Cursor = Cursors.Hand;
                        button.FillColor = Color.FromArgb(73, 113, 116);
                        button.Name = keys[i].Split(',')[0];
                        button.Click += (se, ev) => { Clipboard.SetText(button.Name); };

                        box.Controls.Add(button);

                        panel1.Controls.Add(box);   


                        if (w % 2 == 0)
                        {
                            h += 160;
                            w = 0;
                        }

                        else
                        {
                            w += 338;
                        }

                        








                    }

                }
                catch
                {
                    MessageBox.Show("hata");
                }
            }
        }
    }
}

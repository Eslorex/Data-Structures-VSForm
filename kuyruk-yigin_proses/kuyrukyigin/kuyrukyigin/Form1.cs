using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace kuyrukyigin
{
    public partial class Form : System.Windows.Forms.Form
    {
        public Form()
        {
            // Hocam sadece yığına ekleme, kuyrukta sıralamada ve işlemci hızında sıkıntı var geri kalanı çalışıyor.
            InitializeComponent();
        }

        public class Node
        {
            public string deger;
            public Node sonraki;

            public Node(string deger)
            {
                this.deger = deger;
                this.sonraki = null;
            }
        }

        private void BaslatBtn_Click(object sender, EventArgs e)
        {
            timer1.Enabled = true;
        }

        int[] p1 = new int[50];
        int[] p2 = new int[50];
        int[] p3 = new int[50];
        int[] ana_kuyruk = new int[50];
        int[] ana_kuyruk_p = new int[50];

        int p1_idx = 0;
        int p2_idx = 0;
        int p3_idx = 0;
        int ana_kuyruk_idx = 0;
        int gecici;
        int gecici2;
        int sayac = 0;
        int sayac2 = 0;


        int[] gecicip1p2 = new int[100];
        int[] gecicip1p3 = new int[100];
        int[] gecicip2p3 = new int[100];
        int[] gecicip1p2p3 = new int[150];

        private void DurdurBtn_Click(object sender, EventArgs e)
        {
            timer1.Enabled=false;
        }

        private void GosterBtn_Click(object sender, EventArgs e)
        {
            listBox4.Items.Clear();

            if (checkBox1.Checked == true && checkBox2.Checked == false && checkBox3.Checked == false)
            {
                int gecici0;
                for (int i = 0; i <= p1.Length - 1; i++)
                {
                    for (int j = 1; j <= p1.Length - 1; j++)
                    {
                        if (p1[j - 1] > p1[j])
                        {
                            gecici0 = p1[j - 1];
                            p1[j - 1] = p1[j];
                            p1[j] = gecici;
                        }
                    }
                }

                for (int i = 0; i < p1.Length; i++) {
                    if (p1[i] != 0)
                        listBox4.Items.Add("P1-" + p1[i]);
                }
            }
            else if (checkBox1.Checked == false && checkBox2.Checked == true && checkBox3.Checked == false)
            {
                int gecici0;
                for (int i = 0; i <= p2.Length - 1; i++)
                {
                    for (int j = 1; j <= p2.Length - 1; j++)
                    {
                        if (p2[j - 1] > p2[j])
                        {
                            gecici0 = p2[j - 1];
                            p2[j - 1] = p2[j];
                            p2[j] = gecici;
                        }
                    }
                }
                for (int i = 0; i < p2.Length; i++)
                    if (p2[i] != 0)
                        listBox4.Items.Add("P2-" + p2[i]);
            }
            else if (checkBox1.Checked == false && checkBox2.Checked == false && checkBox3.Checked == true)
            {
                int gecici0;
                for (int i = 0; i <= p3.Length - 1; i++)
                {
                    for (int j = 1; j <= p3.Length - 1; j++)
                    {
                        if (p3[j - 1] > p3[j])
                        {
                            gecici0 = p3[j - 1];
                            p3[j - 1] = p3[j];
                            p3[j] = gecici;
                        }
                    }
                }
                for (int i = 0; i < p3.Length; i++)
                    if (p3[i] != 0)
                        listBox4.Items.Add("P3-" + p3[i]);
            }
            else if (checkBox1.Checked == true && checkBox2.Checked == true && checkBox3.Checked == false)
            {
                for (int i = 0; i < gecicip1p2.Length; i++)
                {
                    if (i < 50)
                    {
                        gecicip1p2[i] = p1[i];
                    }
                    else
                    {
                        gecicip1p2[i] = p2[i - 50];
                    }
                }

                int gecici0;
                for (int i = 0; i <= gecicip1p2.Length - 1; i++)
                {
                    for (int j = 1; j <= gecicip1p2.Length - 1; j++)
                    {
                        if (gecicip1p2[j - 1] > gecicip1p2[j])
                        {
                            gecici0 = gecicip1p2[j - 1];
                            gecicip1p2[j - 1] = gecicip1p2[j];
                            gecicip1p2[j] = gecici;
                        }
                    }
                }


                for (int i = 0; i < gecicip1p2.Length; i++)
                    if (gecicip1p2[i] != 0)
                        listBox4.Items.Add(gecicip1p2[i]);
            }
            else if (checkBox1.Checked == true && checkBox2.Checked == false && checkBox3.Checked == true)
            {
                for (int i = 0; i < gecicip1p3.Length; i++)
                {
                    if (i < 50)
                    {
                        gecicip1p3[i] = p1[i];
                    }
                    else
                    {
                        gecicip1p3[i] = p2[i - 50];
                    }
                }
                int gecici0;
                for (int i = 0; i <= gecicip1p3.Length - 1; i++)
                {
                    for (int j = 1; j <= gecicip1p3.Length - 1; j++)
                    {
                        if (gecicip1p3[j - 1] > gecicip1p3[j])
                        {
                            gecici0 = gecicip1p3[j - 1];
                            gecicip1p3[j - 1] = gecicip1p3[j];
                            gecicip1p3[j] = gecici;
                        }
                    }
                }
                for (int i = 0; i < gecicip1p3.Length; i++)
                    if (gecicip1p3[i] != 0)
                        listBox4.Items.Add(gecicip1p3[i]);
            }
            else if (checkBox1.Checked == false && checkBox2.Checked == true && checkBox3.Checked == true)
            {
                for (int i = 0; i < gecicip2p3.Length; i++)
                {
                    if (i < 50)
                    {
                        gecicip2p3[i] = p2[i];
                    }
                    else
                    {
                        gecicip2p3[i] = p3[i - 50];
                    }
                }
                int gecici0;
                for (int i = 0; i <= gecicip2p3.Length - 1; i++)
                {
                    for (int j = 1; j <= gecicip2p3.Length - 1; j++)
                    {
                        if (gecicip2p3[j - 1] > gecicip2p3[j])
                        {
                            gecici0 = gecicip2p3[j - 1];
                            gecicip2p3[j - 1] = gecicip2p3[j];
                            gecicip2p3[j] = gecici;
                        }
                    }
                }
                for (int i = 0; i < gecicip2p3.Length; i++)
                    if (gecicip2p3[i] != 0)
                        listBox4.Items.Add(gecicip2p3[i]);
            }



            else if (checkBox1.Checked == true && checkBox2.Checked == true && checkBox3.Checked == true)
            {
                for (int i = 0; i < gecicip1p2p3.Length; i++)
                {
                    if (i < 50)
                    {
                        gecicip1p2p3[i] = p1[i];
                    }
                    else if (50 <= i && i < 100)
                    {
                        gecicip1p2p3[i] = p2[i - 50];
                    }
                    else
                    {
                        gecicip1p2p3[i] = p3[i - 100];
                    }
                }

                int gecici0;
                for (int i = 0; i <= gecicip1p2p3.Length - 1; i++)
                {
                    for (int j = 1; j <= gecicip1p2p3.Length - 1; j++)
                    {
                        if (gecicip1p2p3[j - 1] > gecicip1p2p3[j])
                        {
                            gecici0 = gecicip1p2p3[j - 1];
                            gecicip1p2p3[j - 1] = gecicip1p2p3[j];
                            gecicip1p2p3[j] = gecici;
                        }
                    }
                }

                for (int a = 0; a < gecicip1p2p3.Length; a++)
                {
                    if (gecicip1p2p3[a] != 0)
                        listBox4.Items.Add(gecicip1p2p3[a]);
                }
            }



        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            if (!timer1.Enabled)
                timer1.Enabled = true;
            else
            {
                timer1.Interval = 1000;
                timer1.Interval = timer1.Interval - (300 * trackBar2.Value);

                Random rnd = new Random();
                int sayi = rnd.Next(1, 6);
                int p_deger = rnd.Next(1, 4);

                // Diziye tanımlama

                ana_kuyruk[ana_kuyruk_idx] = sayi;
                ana_kuyruk_p[ana_kuyruk_idx] = p_deger;
                ana_kuyruk_idx++;

                for (int i = 0; i < ana_kuyruk.Length; i++)
                {
                    for (int j = i + 1; j < 10; j++)
                    {
                        if (ana_kuyruk[j] < ana_kuyruk[i])
                        {

                            gecici = ana_kuyruk[i];
                            gecici2 = ana_kuyruk_p[i];

                            ana_kuyruk[i] = ana_kuyruk[j];
                            ana_kuyruk_p[i] = ana_kuyruk_p[j];

                            ana_kuyruk[j] = gecici;
                            ana_kuyruk_p[j] = gecici2;

                        }
                    }
                }

                string deger = ("P" + p_deger);

                
                for (int a = sayac2; a < ana_kuyruk_p.Length; a++) {
                    if (ana_kuyruk_p[a] != 0)
                    {
                        textBox1.Text += ("P" + ana_kuyruk_p[sayac] + "-" + ana_kuyruk[sayac] + "-->");
                        sayac++;
                        break;
                    }
                }
                

                if (deger.Substring(0, 2) == "P1") { listBox1.Items.Add("P" + Convert.ToString(p_deger) + "-" + Convert.ToString(sayi) + "-->"); p1[p1_idx] = sayi; p1_idx++; }
                else if (deger.Substring(0, 2) == "P2") { listBox2.Items.Add("P" + Convert.ToString(p_deger) + "-" + Convert.ToString(sayi) + "-->"); p2[p2_idx] = sayi; p2_idx++; }
                else if (deger.Substring(0, 2) == "P3") { listBox3.Items.Add("P" + Convert.ToString(p_deger) + "-" + Convert.ToString(sayi) + "-->"); p3[p3_idx] = sayi; p3_idx++; }
            }
        }

        private void trackBar1_Scroll(object sender, EventArgs e)
        {
            trackBar1.Maximum = 3;
            trackBar1.Minimum = 0;
        }

        private void trackBar2_Scroll(object sender, EventArgs e)
        {
            trackBar2.Maximum = 3;
            trackBar2.Minimum = 0;
        }

        private void trackBar3_Scroll(object sender, EventArgs e)
        {
            trackBar3.Maximum = 5;
            trackBar3.Minimum = 0;
        }

        private void trackBar4_Scroll(object sender, EventArgs e)
        {
            trackBar4.Maximum = 5;
            trackBar4.Minimum = 0;
        }
    }
}

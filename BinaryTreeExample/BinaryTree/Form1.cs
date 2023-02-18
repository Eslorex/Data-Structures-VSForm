using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace BinaryTree
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        public class Node
        {
            public int deger;
            public Node sol;
            public Node sag;
        }
 
        public class Agac
        {
            public Node kok;
            public bool Ekle(int deger)
            {
                Node onceki = null;
                Node sonraki = this.kok;

                while (sonraki != null)
                {
                    onceki = sonraki;
                    if (deger < sonraki.deger)
                        sonraki = sonraki.sol;
                    else if (deger > sonraki.deger)
                        sonraki = sonraki.sag;
                    else
                        return false;
                }

                Node gecici = new Node();
                gecici.deger = deger;

                if (this.kok == null)
                    this.kok = gecici;
                else
                {
                    if (deger < onceki.deger)
                        onceki.sol = gecici;
                    else
                        onceki.sag = gecici;
                }
                return true;
            }

            public Node Bul(int deger)
            {
                return this.Bul(deger, this.kok);
            }
            private Node Bul(int deger, Node buyuk)
            {
                if (buyuk != null)
                {
                    if (deger == buyuk.deger)
                        return buyuk;

                    if (deger < buyuk.deger)
                        return Bul(deger, buyuk.sol);
                    else
                        return Bul(deger, buyuk.sag);
                }
                return null;
            }

            public void Sil(int deger)
            {
                this.kok = Sil(this.kok, deger);
            }
            private Node Sil(Node buyuk, int deger)
            {
                if (buyuk == null)
                    return buyuk;

                if (deger < buyuk.deger)
                    buyuk.sol = Sil(buyuk.sol, deger);
                else if (deger > buyuk.deger)
                    buyuk.sag = Sil(buyuk.sag, deger);
                else
                {
                    if (buyuk.sol == null)
                        return buyuk.sag;
                    else if (buyuk.sag == null)
                        return buyuk.sol;

                    buyuk.deger = EnKucuk(buyuk.sag);
                    buyuk.sag = Sil(buyuk.sag, buyuk.deger);
                }
                return buyuk;
            }
            public int EnKucuk(Node dugum)
            {
                int enkucuk = dugum.deger;

                while (dugum.sol != null)
                {
                    enkucuk = dugum.sol.deger;
                    dugum = dugum.sol;
                }
                return enkucuk;
            }

            public int AgacDerinlik()
            {
                return this.AgacDerinlik(this.kok);
            }
            private int AgacDerinlik(Node buyuk)
            {
                return buyuk == null ? 0 : Math.Max(AgacDerinlik(buyuk.sol), AgacDerinlik(buyuk.sag)) + 1;
            }

            public void Preorder(Node buyuk)
            {
                if(buyuk != null)
                {
                    //Console.Write(parent.Data + " ");
                    Preorder(buyuk.sol);
                    Preorder(buyuk.sag);
                }
            }
            public void Inorder(Node buyuk)
            {
                if(buyuk != null)
                {
                    Inorder(buyuk.sol);
                    //Console.Write(parent.Data + " ");
                    Inorder(buyuk.sag);
                }
            }
            public void Postorder(Node buyuk)
            {
                if(buyuk != null)
                {
                    Postorder(buyuk.sol);
                    Postorder(buyuk.sag);
                    //Console.Write(parent.Data + " ");
                }
            }
        }
        Agac agac = new Agac();
        //Ekleme
        private void button1_Click(object sender, EventArgs e)
        {
            int sayi = Convert.ToInt32(textBox1.Text);
            agac.Ekle(sayi);
            //listBox1.Items.Add(sayi + " ↓");
            textBox1.Text = " ";
        }
        //Silme
        private void button2_Click(object sender, EventArgs e)
        {
            int silinecek = Convert.ToInt32(textBox2.Text);
            agac.Bul(silinecek);
            agac.Sil(silinecek);
            textBox2.Text = " ";
        }
        //Ağaç Bilgileri
        private void button5_Click(object sender, EventArgs e)
        {
            textBox8.Text = agac.AgacDerinlik().ToString();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            listBox1.Items.Add(agac.kok);
        }
    }
}

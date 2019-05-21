using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
//160201150 Akın Arslan 160201083 Furkan Aydoğdu
namespace WindowsFormsApp2
{
    public partial class Form1 : Form
    {
        String DosyaYolu;
        Image KaynakResim;
        Bitmap[,] BitmapDizisi = new Bitmap[4, 4];
        Bitmap[,] BitmapKarmasikDizisi = new Bitmap[4, 4];
        Button[] TiklanmisButonlar = new Button[2];
        Image GeciciResim;
        int ButonKontrolDegiskeni = 2;
        int DogruParcaSayisi = 0;
        int OyunKilidi = 0;
        int Skor = 100;
        int EnYuksekSkor;
        int ParcaEni;
        int ParcaBoyu;
        public Form1()
        {
            InitializeComponent();
        }
        private void Form1_Load(object sender, EventArgs e)
        {
        }
        public void KayitDosyasiOkuma()
        {
            String KayitDosyasiYolu = "C:\\Users\\Admin\\Desktop\\KayitDosyasi.txt";
            Boolean DosyaVarmi = File.Exists(KayitDosyasiYolu);
            String Kayitlar;
            if(DosyaVarmi == true)
            {
                FileStream KayitDosyasi = new FileStream(KayitDosyasiYolu, FileMode.Open, FileAccess.Read);
                StreamReader KayitOkuyucusu = new StreamReader(KayitDosyasi);
                Kayitlar = KayitOkuyucusu.ReadLine();
                EnYuksekSkor = Int32.Parse(Kayitlar);
                while(Kayitlar != null)
                {
                    Kayitlar = KayitOkuyucusu.ReadLine();
                    if (Kayitlar != null)
                    {
                        if (Int32.Parse(Kayitlar) > EnYuksekSkor)
                        {
                            EnYuksekSkor = Int32.Parse(Kayitlar);
                        }
                    }
                }
                KayitOkuyucusu.Close();
                KayitDosyasi.Close();
                label1.Text = EnYuksekSkor.ToString();
            }
            else
            {
                label1.Text = "Kayıt bulunmamaktadır.";
            }
        }
        public void KayitDosyasiYazma()
        {
            String KayitDosyasiYolu = "C:\\Users\\Admin\\Desktop\\KayitDosyasi.txt";
            Boolean DosyaVarmi = File.Exists(KayitDosyasiYolu);
            StreamWriter KayitYazicisi;
            FileStream KayitDosyasi;
            if (DosyaVarmi == true)
            {
                KayitYazicisi = new StreamWriter(KayitDosyasiYolu, true);
                KayitYazicisi.WriteLine(Skor.ToString());
                KayitYazicisi.Flush();
                KayitYazicisi.Close();
            }
            else
            {
                KayitDosyasi = new FileStream(KayitDosyasiYolu, FileMode.OpenOrCreate, FileAccess.Write);
                KayitYazicisi = new StreamWriter(KayitDosyasi);
                KayitYazicisi.WriteLine(Skor.ToString());
                KayitYazicisi.Flush();
                KayitYazicisi.Close();
                KayitDosyasi.Close();
            }
        }
        public void FotografDegisimi(Button Buton)
        {
            if (ButonKontrolDegiskeni == 1 && TiklanmisButonlar[0] != Buton)
            {
                TiklanmisButonlar[1] = Buton;
                ButonKontrolDegiskeni = 2;
            }
            else if (ButonKontrolDegiskeni == 2 && TiklanmisButonlar[1] != Buton)
            {
                TiklanmisButonlar[0] = Buton;
                ButonKontrolDegiskeni = 1;
            }
            if (ButonKontrolDegiskeni == 2 && OyunKilidi != 1)
            {
                GeciciResim = TiklanmisButonlar[0].Image;
                TiklanmisButonlar[0].Image = TiklanmisButonlar[1].Image;
                TiklanmisButonlar[1].Image = GeciciResim;
                TiklanmisButonlar[0] = null;
                TiklanmisButonlar[1] = null;
                ParcaKontrolu();
            }
        }
        public void ParcaKontrolu()
        {
            if (Skor > 3)
            {
                Skor = Skor - 3;
            }
            label2.Text = Skor.ToString();
            DogruParcaSayisi = 0;
            Bitmap[,] BitmapKarsilastirmaDizisi = new Bitmap[4, 4];
            BitmapKarsilastirmaDizisi[0, 0] = new Bitmap(ParcaEni, ParcaBoyu);
            using(Graphics grafik = Graphics.FromImage((System.Drawing.Image)BitmapKarsilastirmaDizisi[0, 0]))
            grafik.DrawImage(button1.Image, 0, 0, ParcaEni, ParcaBoyu);
            BitmapKarsilastirmaDizisi[0, 1] = new Bitmap(ParcaEni, ParcaBoyu);
            using(Graphics grafik = Graphics.FromImage((System.Drawing.Image)BitmapKarsilastirmaDizisi[0, 1]))
            grafik.DrawImage(button2.Image, 0, 0, ParcaEni, ParcaBoyu);
            BitmapKarsilastirmaDizisi[0, 2] = new Bitmap(ParcaEni, ParcaBoyu);
            using(Graphics grafik = Graphics.FromImage((System.Drawing.Image)BitmapKarsilastirmaDizisi[0, 2]))
            grafik.DrawImage(button3.Image, 0, 0, ParcaEni, ParcaBoyu);
            BitmapKarsilastirmaDizisi[0, 3] = new Bitmap(ParcaEni, ParcaBoyu);
            using(Graphics grafik = Graphics.FromImage((System.Drawing.Image)BitmapKarsilastirmaDizisi[0, 3]))
            grafik.DrawImage(button4.Image, 0, 0, ParcaEni, ParcaBoyu);
            BitmapKarsilastirmaDizisi[1, 0] = new Bitmap(ParcaEni, ParcaBoyu);
            using(Graphics grafik = Graphics.FromImage((System.Drawing.Image)BitmapKarsilastirmaDizisi[1, 0]))
            grafik.DrawImage(button5.Image, 0, 0, ParcaEni, ParcaBoyu);
            BitmapKarsilastirmaDizisi[1, 1] = new Bitmap(ParcaEni, ParcaBoyu);
            using(Graphics grafik = Graphics.FromImage((System.Drawing.Image)BitmapKarsilastirmaDizisi[1, 1]))
            grafik.DrawImage(button6.Image, 0, 0, ParcaEni, ParcaBoyu);
            BitmapKarsilastirmaDizisi[1, 2] = new Bitmap(ParcaEni, ParcaBoyu);
            using(Graphics grafik = Graphics.FromImage((System.Drawing.Image)BitmapKarsilastirmaDizisi[1, 2]))
            grafik.DrawImage(button7.Image, 0, 0, ParcaEni, ParcaBoyu);
            BitmapKarsilastirmaDizisi[1, 3] = new Bitmap(ParcaEni, ParcaBoyu);
            using(Graphics grafik = Graphics.FromImage((System.Drawing.Image)BitmapKarsilastirmaDizisi[1, 3]))
            grafik.DrawImage(button8.Image, 0, 0, ParcaEni, ParcaBoyu);
            BitmapKarsilastirmaDizisi[2, 0] = new Bitmap(ParcaEni, ParcaBoyu);
            using(Graphics grafik = Graphics.FromImage((System.Drawing.Image)BitmapKarsilastirmaDizisi[2, 0]))
            grafik.DrawImage(button9.Image, 0, 0, ParcaEni, ParcaBoyu);
            BitmapKarsilastirmaDizisi[2, 1] = new Bitmap(ParcaEni, ParcaBoyu);
            using(Graphics grafik = Graphics.FromImage((System.Drawing.Image)BitmapKarsilastirmaDizisi[2, 1]))
            grafik.DrawImage(button10.Image, 0, 0, ParcaEni, ParcaBoyu);
            BitmapKarsilastirmaDizisi[2, 2] = new Bitmap(ParcaEni, ParcaBoyu);
            using(Graphics grafik = Graphics.FromImage((System.Drawing.Image)BitmapKarsilastirmaDizisi[2, 2]))
            grafik.DrawImage(button11.Image, 0, 0, ParcaEni, ParcaBoyu);
            BitmapKarsilastirmaDizisi[2, 3] = new Bitmap(ParcaEni, ParcaBoyu);
            using(Graphics grafik = Graphics.FromImage((System.Drawing.Image)BitmapKarsilastirmaDizisi[2, 3]))
            grafik.DrawImage(button12.Image, 0, 0, ParcaEni, ParcaBoyu);
            BitmapKarsilastirmaDizisi[3, 0] = new Bitmap(ParcaEni, ParcaBoyu);
            using(Graphics grafik = Graphics.FromImage((System.Drawing.Image)BitmapKarsilastirmaDizisi[3, 0]))
            grafik.DrawImage(button13.Image, 0, 0, ParcaEni, ParcaBoyu);
            BitmapKarsilastirmaDizisi[3, 1] = new Bitmap(ParcaEni, ParcaBoyu);
            using(Graphics grafik = Graphics.FromImage((System.Drawing.Image)BitmapKarsilastirmaDizisi[3, 1]))
            grafik.DrawImage(button14.Image, 0, 0, ParcaEni, ParcaBoyu);
            BitmapKarsilastirmaDizisi[3, 2] = new Bitmap(ParcaEni, ParcaBoyu);
            using(Graphics grafik = Graphics.FromImage((System.Drawing.Image)BitmapKarsilastirmaDizisi[3, 2]))
            grafik.DrawImage(button15.Image, 0, 0, ParcaEni, ParcaBoyu);
            BitmapKarsilastirmaDizisi[3, 3] = new Bitmap(ParcaEni, ParcaBoyu);
            using(Graphics grafik = Graphics.FromImage((System.Drawing.Image)BitmapKarsilastirmaDizisi[3, 3]))
            grafik.DrawImage(button16.Image, 0, 0, ParcaEni, ParcaBoyu);
            int PikselSayisi = ParcaEni * ParcaBoyu;
            int PikselSayisiKontrolu = 0;
            DogruParcaSayisi = 0;
            for(int i = 0;i < 4; i++)
            {
                for(int j = 0;j < 4; j++)
                {
                    for(int x = 0;x < ParcaEni; x++)
                    {
                        for(int y = 0;y < ParcaBoyu; y++)
                        {
                            if(BitmapDizisi[i, j].GetPixel(x, y) == BitmapKarsilastirmaDizisi[i , j].GetPixel(x, y))
                            {
                                PikselSayisiKontrolu++;
                            }
                        }
                    }
                    if(PikselSayisiKontrolu == PikselSayisi)
                    {
                        DogruParcaSayisi++;
                    }
                    PikselSayisiKontrolu = 0;
                } 
            }
            if(DogruParcaSayisi == 16)
            {
                textBox2.Visible = true;
                OyunKilidi = 1;
                KayitDosyasiYazma();
                KayitDosyasiOkuma();
            }
        }
        private void button17_Click(object sender, EventArgs e)
        {
            OyunKilidi = 0;
            Skor = 100;
            DogruParcaSayisi = 0;
                string KaynakDosyaIsmi;
                if (openFileDialog1.ShowDialog() == System.Windows.Forms.DialogResult.OK)
                {
                    KaynakDosyaIsmi = openFileDialog1.FileName;
                if (KaynakDosyaIsmi.EndsWith("jpg") || KaynakDosyaIsmi.EndsWith("jpeg") || KaynakDosyaIsmi.EndsWith("png") || KaynakDosyaIsmi.EndsWith("jpe") || KaynakDosyaIsmi.EndsWith("jfif"))
                {
                    KayitDosyasiOkuma();
                    textBox2.Visible = false;
                    DosyaYolu = KaynakDosyaIsmi;
                    KaynakResim = new Bitmap(DosyaYolu, true);
                    if (KaynakResim.Width > 1000)
                    {
                        Bitmap YeniResim = new Bitmap(1000, KaynakResim.Height);
                        using (Graphics grafik = Graphics.FromImage((System.Drawing.Image)YeniResim))
                            grafik.DrawImage(KaynakResim, 0, 0, 1000, KaynakResim.Height);
                        KaynakResim = YeniResim;
                    }
                    if (KaynakResim.Height > 580)
                    {
                        Bitmap YeniResimBoy = new Bitmap(KaynakResim.Width, 580);
                        using (Graphics grafik = Graphics.FromImage((System.Drawing.Image)YeniResimBoy))
                            grafik.DrawImage(KaynakResim, 0, 0, KaynakResim.Width, 580);
                        KaynakResim = YeniResimBoy;
                    }
                    ParcaEni = (int)((double)KaynakResim.Width / 4.0);
                    ParcaBoyu = (int)((double)KaynakResim.Height / 4.0);
                    Random RastgeleSayiUret = new Random();
                    int[,] KontrolDizisi = new int[4, 4];
                    int RastgeleEn = 0;
                    int RastgeleBoy = 0;
                    int RastgeleSayiKontrolu = 0;
                    for (int i = 0; i < 4; i++)
                    {
                        for (int j = 0; j < 4; j++)
                        {
                            BitmapDizisi[i, j] = new Bitmap(ParcaEni, ParcaBoyu);
                            Graphics grafik = Graphics.FromImage(BitmapDizisi[i, j]);
                            grafik.DrawImage(KaynakResim, new Rectangle(0, 0, ParcaEni, ParcaBoyu), new
                            Rectangle(j * ParcaEni, i * ParcaBoyu, ParcaEni, ParcaBoyu), GraphicsUnit.Pixel);
                            grafik.Dispose();
                        }
                    }
                    for (int i = 0; i < 4; i++)
                    {
                        for (int j = 0; j < 4; j++)
                        {
                            KontrolDizisi[i, j] = 0;
                        }
                    }
                    for (int i = 0; i < 4; i++)
                    {
                        for (int j = 0; j < 4; j++)
                        {
                            while (RastgeleSayiKontrolu != 1)
                            {
                                RastgeleEn = RastgeleSayiUret.Next(0, 4);
                                RastgeleBoy = RastgeleSayiUret.Next(0, 4);
                                if (KontrolDizisi[RastgeleEn, RastgeleBoy] == 0)
                                {
                                    KontrolDizisi[RastgeleEn, RastgeleBoy] = 1;
                                    RastgeleSayiKontrolu = 1;
                                }
                            }
                            RastgeleSayiKontrolu = 0;
                            BitmapKarmasikDizisi[RastgeleEn, RastgeleBoy] = BitmapDizisi[i, j];
                        }
                    }
                    button1.Width = ParcaEni;
                    button1.Height = ParcaBoyu;
                    button2.Width = ParcaEni;
                    button2.Height = ParcaBoyu;
                    button2.Location = new Point(button1.Location.X + ParcaEni, button1.Location.Y);
                    button3.Width = ParcaEni;
                    button3.Height = ParcaBoyu;
                    button3.Location = new Point(button2.Location.X + ParcaEni, button1.Location.Y);
                    button4.Width = ParcaEni;
                    button4.Height = ParcaBoyu;
                    button4.Location = new Point(button3.Location.X + ParcaEni, button1.Location.Y);
                    button5.Width = ParcaEni;
                    button5.Height = ParcaBoyu;
                    button5.Location = new Point(button1.Location.X, button1.Location.Y + ParcaBoyu);
                    button6.Width = ParcaEni;
                    button6.Height = ParcaBoyu;
                    button6.Location = new Point(button2.Location.X, button5.Location.Y);
                    button7.Width = ParcaEni;
                    button7.Height = ParcaBoyu;
                    button7.Location = new Point(button3.Location.X, button5.Location.Y);
                    button8.Width = ParcaEni;
                    button8.Height = ParcaBoyu;
                    button8.Location = new Point(button4.Location.X, button5.Location.Y);
                    button9.Width = ParcaEni;
                    button9.Height = ParcaBoyu;
                    button9.Location = new Point(button1.Location.X, button5.Location.Y + ParcaBoyu);
                    button10.Width = ParcaEni;
                    button10.Height = ParcaBoyu;
                    button10.Location = new Point(button2.Location.X, button9.Location.Y);
                    button11.Width = ParcaEni;
                    button11.Height = ParcaBoyu;
                    button11.Location = new Point(button3.Location.X, button9.Location.Y);
                    button12.Width = ParcaEni;
                    button12.Height = ParcaBoyu;
                    button12.Location = new Point(button4.Location.X, button9.Location.Y);
                    button13.Width = ParcaEni;
                    button13.Height = ParcaBoyu;
                    button13.Location = new Point(button1.Location.X, button9.Location.Y + ParcaBoyu);
                    button14.Width = ParcaEni;
                    button14.Height = ParcaBoyu;
                    button14.Location = new Point(button2.Location.X, button13.Location.Y);
                    button15.Width = ParcaEni;
                    button15.Height = ParcaBoyu;
                    button15.Location = new Point(button3.Location.X, button13.Location.Y);
                    button16.Width = ParcaEni;
                    button16.Height = ParcaBoyu;
                    button16.Location = new Point(button4.Location.X, button13.Location.Y);
                    button1.Visible = true;
                    button2.Visible = true;
                    button3.Visible = true;
                    button4.Visible = true;
                    button5.Visible = true;
                    button6.Visible = true;
                    button7.Visible = true;
                    button8.Visible = true;
                    button9.Visible = true;
                    button10.Visible = true;
                    button11.Visible = true;
                    button12.Visible = true;
                    button13.Visible = true;
                    button14.Visible = true;
                    button15.Visible = true;
                    button16.Visible = true;
                    button1.Image = BitmapKarmasikDizisi[0, 0];
                    button2.Image = BitmapKarmasikDizisi[0, 1];
                    button3.Image = BitmapKarmasikDizisi[0, 2];
                    button4.Image = BitmapKarmasikDizisi[0, 3];
                    button5.Image = BitmapKarmasikDizisi[1, 0];
                    button6.Image = BitmapKarmasikDizisi[1, 1];
                    button7.Image = BitmapKarmasikDizisi[1, 2];
                    button8.Image = BitmapKarmasikDizisi[1, 3];
                    button9.Image = BitmapKarmasikDizisi[2, 0];
                    button10.Image = BitmapKarmasikDizisi[2, 1];
                    button11.Image = BitmapKarmasikDizisi[2, 2];
                    button12.Image = BitmapKarmasikDizisi[2, 3];
                    button13.Image = BitmapKarmasikDizisi[3, 0];
                    button14.Image = BitmapKarmasikDizisi[3, 1];
                    button15.Image = BitmapKarmasikDizisi[3, 2];
                    button16.Image = BitmapKarmasikDizisi[3, 3];
                    ParcaKontrolu();
                    Skor = 100;
                    label2.Text = Skor.ToString();
                    if (DogruParcaSayisi < 1)
                    {
                        OyunKilidi = 1;
                        textBox1.Visible = true;
                    }
                }
            }
        }
        private void button18_Click(object sender, EventArgs e)
        {
            Skor = 100;
            OyunKilidi = 0;
            DogruParcaSayisi = 0;
            if (DosyaYolu != null)
            {
                textBox2.Visible = false;
                int ParcaEni = (int)((double)KaynakResim.Width / 4.0);
                int ParcaBoyu = (int)((double)KaynakResim.Height / 4.0);
                Random RastgeleSayiUret = new Random();
                int[,] KontrolDizisi = new int[4, 4];
                int RastgeleEn = 0;
                int RastgeleBoy = 0;
                int RastgeleSayiKontrolu = 0;
                for (int i = 0; i < 4; i++)
                {
                    for (int j = 0; j < 4; j++)
                    {
                        KontrolDizisi[i, j] = 0;
                    }
                }
                for (int i = 0; i < 4; i++)
                {
                    for (int j = 0; j < 4; j++)
                    {
                        while (RastgeleSayiKontrolu != 1)
                        {
                            RastgeleEn = RastgeleSayiUret.Next(0, 4);
                            RastgeleBoy = RastgeleSayiUret.Next(0, 4);
                            if (KontrolDizisi[RastgeleEn, RastgeleBoy] == 0)
                            {
                                KontrolDizisi[RastgeleEn, RastgeleBoy] = 1;
                                RastgeleSayiKontrolu = 1;
                            }
                        }
                        RastgeleSayiKontrolu = 0;
                        BitmapKarmasikDizisi[RastgeleEn, RastgeleBoy] = BitmapDizisi[i, j];
                    }
                }
                button1.Image = BitmapKarmasikDizisi[0, 0];
                button2.Image = BitmapKarmasikDizisi[0, 1];
                button3.Image = BitmapKarmasikDizisi[0, 2];
                button4.Image = BitmapKarmasikDizisi[0, 3];
                button5.Image = BitmapKarmasikDizisi[1, 0];
                button6.Image = BitmapKarmasikDizisi[1, 1];
                button7.Image = BitmapKarmasikDizisi[1, 2];
                button8.Image = BitmapKarmasikDizisi[1, 3];
                button9.Image = BitmapKarmasikDizisi[2, 0];
                button10.Image = BitmapKarmasikDizisi[2, 1];
                button11.Image = BitmapKarmasikDizisi[2, 2];
                button12.Image = BitmapKarmasikDizisi[2, 3];
                button13.Image = BitmapKarmasikDizisi[3, 0];
                button14.Image = BitmapKarmasikDizisi[3, 1];
                button15.Image = BitmapKarmasikDizisi[3, 2];
                button16.Image = BitmapKarmasikDizisi[3, 3];
                ParcaKontrolu();
                Skor = 100;
                label2.Text = Skor.ToString();
                if (DogruParcaSayisi > 0)
                {
                    OyunKilidi = 0;
                    textBox1.Visible = false;
                }
                else
                {
                    OyunKilidi = 1;
                    textBox1.Visible = true;
                }
            }
        }
        private void groupBox1_Enter(object sender, EventArgs e)
        {

        }
        private void button1_Click(object sender, EventArgs e)
        {
            FotografDegisimi(button1);
        }
        private void button2_Click(object sender, EventArgs e)
        {
            FotografDegisimi(button2);
        }
        private void button3_Click(object sender, EventArgs e)
        {
            FotografDegisimi(button3);
        }
        private void button4_Click(object sender, EventArgs e)
        {
            FotografDegisimi(button4);
        }
        private void button5_Click(object sender, EventArgs e)
        {
            FotografDegisimi(button5);
        }
        private void button6_Click(object sender, EventArgs e)
        {
            FotografDegisimi(button6);
        }
        private void button7_Click(object sender, EventArgs e)
        {
            FotografDegisimi(button7);
        }
        private void button8_Click(object sender, EventArgs e)
        {
            FotografDegisimi(button8);
        }
        private void button9_Click(object sender, EventArgs e)
        {
            FotografDegisimi(button9);
        }
        private void button10_Click(object sender, EventArgs e)
        {
            FotografDegisimi(button10);
        }
        private void button11_Click(object sender, EventArgs e)
        {
            FotografDegisimi(button11);
        }
        private void button12_Click(object sender, EventArgs e)
        {
            FotografDegisimi(button12);
        }
        private void button13_Click(object sender, EventArgs e)
        {
            FotografDegisimi(button13);
        }
        private void button14_Click(object sender, EventArgs e)
        {
            FotografDegisimi(button14);
        }
        private void button15_Click(object sender, EventArgs e)
        {
            FotografDegisimi(button15);
        }
        private void button16_Click(object sender, EventArgs e)
        {
            FotografDegisimi(button16);
        }
    }
}

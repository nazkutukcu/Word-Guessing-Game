using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using MySql.Data.MySqlClient;

namespace kelimeoyunu
{
    public partial class Form1 : Form
    {

        myDBConnection con = new myDBConnection();


        public Form1()
        {
            InitializeComponent();
            con.Connect();
        }

        List<string> sorular = new List<string>();
        List<string> cevaplar = new List<string>();
      
        int puan;
        int toplampuan = 0;
        int uzunluk;
        int k = 0;
        char[] harfler;
        Random r = new Random();
        string suanki_kelime="moda";
        int lazım;

        int saniye = 60;
        int dakika =4;

        int saniye2 = 20;
        int harfhakkı = 9;
        int i = 0;
       
        

        private void Form1_Load(object sender, EventArgs e)
        {
            timer1.Start();
            sorularlist();
            cevaplarlist();
        }
       

        void sorularlist()
        {


            MySqlCommand command = new MySqlCommand("Select soru From sorucevap", con.cn);
            con.cn.Open();

            MySqlDataReader oku = command.ExecuteReader();
            while (oku.Read())
            {


                var soru = oku.GetString(0);


                sorular.Add(soru);

            }


            con.cn.Close();


        }

        void cevaplarlist()
        {


            MySqlCommand command = new MySqlCommand("Select cevap From sorucevap", con.cn);
            con.cn.Open();

            MySqlDataReader oku = command.ExecuteReader();
            while (oku.Read())
            {


                var soru = oku.GetString(0);


                cevaplar.Add(soru);

            }


            con.cn.Close();
        }

        void harfkadaryer()
        {

            label3.Text = "";

            for (int b = 0; b < lazım; b++)
            {

                label3.Text += "?";

            }

        }

        void sorugel()
        {
            
            
            if (i< 14) {

                if (i == 13)
                 {
                    timer1.Stop();
                    timer2.Stop();
                    MessageBox.Show("Oyunu bitirdiniz! Puanınız:"+toplampuan);
                    string[] satirlar = { Form2.isim, Form2.tarih, toplampuan.ToString() };

                   System.IO.File.WriteAllLines(@"C:\Users\naz\Desktop\kelimeoyunu\oyun.txt", satirlar);

                   this.Close();


                 }
                
           
            button1.Enabled = true;
            harfal.Enabled = true;
                 
            suanki_kelime = cevaplar[i+1];
            uzunluk = cevaplar[i].Length;
            lazım = cevaplar[i + 1].Length;
                  

            label1.Text = sorular[i + 1];
            textBox1.Text = "";
            timer1.Start();
            timer2.Stop();
            label9.Text = "20";
            saniye2 = 20;
                    

             harfkadaryer();
                
                   

                }
                i++;
            }
        

            private void button1_Click(object sender, EventArgs e)

        {
            string tahmin = textBox1.Text;
            cevaplarlist();
            sorularlist();

            if (cevaplar[i] == tahmin)
            {
                sorugel();
                puan = 100 * uzunluk;
                toplampuan += puan;

                
                label4.Text = "PUAN:" + toplampuan.ToString();
            }

        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void label2_Click(object sender, EventArgs e)
        {

        }



        private void harfal_Click(object sender, EventArgs e)
        {
            
            k = 0;

            harfler = new char[suanki_kelime.Length];

            int[] rasgeleSayilar = new int[harfler.Length];

            for (int i = 0; i < rasgeleSayilar.Length; i++) // içine -1 atıyorum 0 olunca döngü sonsuz döngüye giriyor.

            {

                rasgeleSayilar[i] = -1;

            }


            harfler = suanki_kelime.ToCharArray();

            byte rasgeleHarf = Convert.ToByte(r.Next(0, harfler.Length));

            while (Array.IndexOf(rasgeleSayilar, rasgeleHarf) != -1) // rasgele sayılardan aynısı oluşmasın

            {

                rasgeleHarf = Convert.ToByte(r.Next(0, harfler.Length));

            }

            rasgeleSayilar[k] = rasgeleHarf;

            char verilecekHarf = harfler[rasgeleHarf];



            label3.Text = label3.Text.Remove(rasgeleHarf, 1);

            label3.Text = label3.Text.Insert(Convert.ToInt32(rasgeleHarf), verilecekHarf.ToString());

           


            if (k < harfler.Length -1)
            {
                k++;
                

            }

            else

            {

              MessageBox.Show("Bütün harfler alındı.");
             }

           
            harfhakkı = harfhakkı - 1;
            toplampuan -= 100;
            label13.Text = harfhakkı.ToString();
           
          
            
            if (harfhakkı == 0)
            {
                MessageBox.Show("harf alma hakkınız bitmiştir :( ");
                harfal.Enabled = false;

            }
          

        }

        private void button5_Click(object sender, EventArgs e)
        {

        }

        private void label5_Click(object sender, EventArgs e)
        {

        }

        private void label4_Click(object sender, EventArgs e)
        {

        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            button1.Enabled = false;
            saniye = saniye - 1;
            label6.Text = saniye.ToString();
            label5.Text = (dakika - 1).ToString();
            if (saniye == 0)
            {
                dakika = dakika - 1;
                label5.Text = dakika.ToString();
                saniye = 60;
            }
            if (label5.Text== "-1")
            {
                timer1.Stop();
                label5.Text = "00";
                label6.Text = "00";
                this.BackColor = Color.Red;
                MessageBox.Show("Süreniz Sona Erdi,Puanınız:" + toplampuan);

                string[] satirlar = {"İsim:"+Form2.isim,"Tarih"+Form2.tarih,"ToplamPuan"+toplampuan.ToString()};

                System.IO.File.WriteAllLines(@"C:\Kullanıcılar\naz\source\repos\kelimeoyunu\oyun.txt", satirlar);
                

                puan = 0;
                Form2 f2 = new Form2();
                f2.Show();
                this.Close();


            }
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {
            
            timer2.Start();
            timer1.Stop();
        }

        private void timer2_Tick(object sender, EventArgs e)
        {
            saniye2 = saniye2 - 1;
            label9.Text = saniye2.ToString();
            button1.Enabled = true;
            harfal.Enabled = false;
           
            if (label9.Text== "-1")
            {
                timer2.Stop();
                label9.Text = "00";

                textBox1.Enabled = false;
                timer1.Start();
                puan = puan + 0;
                
                button1.Enabled = false;
                MessageBox.Show("Süreniz doldu. Bir sonraki soruya geçtiniz :/");
                sorugel();
                

            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            Application.Exit();

        }

        private void btn_max1_Click(object sender, EventArgs e)
        {
            WindowState = FormWindowState.Maximized;
            btn_max2.BringToFront();
        }

        private void btn_min_Click(object sender, EventArgs e)
        {
            WindowState = FormWindowState.Minimized;
        }

        private void btn_max2_Click(object sender, EventArgs e)
        {
            WindowState = FormWindowState.Normal;
            btn_max1.BringToFront();
        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void label5_Click_1(object sender, EventArgs e)
        {

        }

        private void label12_Click(object sender, EventArgs e)
        {

        }

        private void label8_Click(object sender, EventArgs e)
        {

        }

        private void label13_Click(object sender, EventArgs e)
        {

        }

        private void label9_Click(object sender, EventArgs e)
        {

        }

        private void button3_Click_1(object sender, EventArgs e)
        {

        }

        private void label6_Click(object sender, EventArgs e)
        {

        }

        private void Form1_Load_1(object sender, EventArgs e)
        {

        }

        private void button3_Click_2(object sender, EventArgs e)
        {
            if (Application.OpenForms[0] == this)//Uygulamanin main form'u
            {
                //uygulamanin ana formunu kapatirsaniz uygulama kapanir, ana formu yeniden baslatmak uygulamayi yeniden baslatmak demektir.
                Application.Restart();
            }
            else
            {
                Form1 f1 = new Form1();
                f1.Show();
                this.Close();
            }
        }

        private void label10_Click(object sender, EventArgs e)
        {

        }

        private void button4_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using MySql.Data.MySqlClient;


namespace kelimeoyunu
{
    public partial class Form3 : Form
    {
        myDBConnection con = new myDBConnection();
        

        public Form3()
        {
            InitializeComponent();
            con.Connect();
        }

        public void VeriTabanınaEkle(string sorgu)
        {
            con.cn.Open();
            MySqlCommand command = new MySqlCommand();
            command.Connection = con.cn;
            command.CommandText = sorgu;
            command.ExecuteNonQuery();
            con.cn.Close();

        }
        private void button1_Click(object sender, EventArgs e)
        {
            string id = textBox3.Text;
            string soru = textBox1.Text;
            string cevap = textBox2.Text;
            string uzunluk = textBox4.Text;
            string sorgu="INSERT INTO sorucevap values('"+id+"','"+soru+"','"+cevap+"','"+uzunluk+"')";
            VeriTabanınaEkle(sorgu);

            MessageBox.Show("eklendi.");
            textBox1.Clear();
            textBox2.Clear();
            textBox3.Clear();
            textBox4.Clear();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            // Form2 f2 = new Form2();

            //f2.ShowDialog();
            this.Close();
        }

        private void Form3_Load(object sender, EventArgs e)
        {

        }
    }
}

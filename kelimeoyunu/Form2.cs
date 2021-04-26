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

namespace kelimeoyunu
{
    public partial class Form2 : Form
    {
        
        public Form2()
        {
            InitializeComponent();

           

        }
        static public string isim;
        static public string tarih;

      
        private void textBox1_TextChanged(object sender, EventArgs e)
        {

           
            
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Form1 f1 = new Form1();
            f1.Show();
            textBox1.Clear();
            textBox2.Clear();
          
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {
            Form3 f3 = new Form3();
            f3.Show();
         

        }

    

        private void button3_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void Form2_Load(object sender, EventArgs e)
        {

        }

        private void button7_Click(object sender, EventArgs e)
        {
            isim = textBox1.Text;
            tarih = textBox2.Text;

        }
    }
}

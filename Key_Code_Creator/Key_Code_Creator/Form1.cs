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

namespace Key_Code_Creator
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
        
      
        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            
            GenerateRandomString();
        }
        public  void GenerateRandomString()
        {
            try
            {
                KeytextBox.Text = "";
                
                int length = Convert.ToInt32(LngtextBox.Text); // Dize uzunluğu
                int dashInterval = Convert.ToInt32(DItextBox.Text); // Tire eklenen karakter aralığı
                string characters = "ABCDEFGHJKLMNPQRSTUVWXYZ23456789"; // Kullanılacak karakterler

                StringBuilder stringBuilder = new StringBuilder();
                Random random = new Random();

                for (int i = 0; i < length; i++)
                {
                    if (i > 0 && i % dashInterval == 0)
                    {
                        stringBuilder.Append("-");
                    }

                    int randomIndex = random.Next(0, characters.Length);
                    char randomChar = characters[randomIndex];
                    stringBuilder.Append(randomChar);
                }
                KeytextBox.Text = stringBuilder.ToString();
                listBox1.Items.Add(KeytextBox.Text);

            }
            catch
            {

            }
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            GenerateRandomString();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (timer1.Enabled == false)

            {
                timer1.Enabled = true;
                LngtextBox.Enabled = false;
                DItextBox.Enabled=false;
                KeytextBox.Enabled = false;
                button1.Enabled = false;
                button3.Enabled = false;
                button4.Enabled = false;






            }
            else if (timer1.Enabled == true)

            {
                timer1.Enabled = false;
                LngtextBox.Enabled = true;
                DItextBox.Enabled = true;
                KeytextBox.Enabled = true;
                button1.Enabled = true;
                button3.Enabled = true;
                button4.Enabled = true;


            }
        }
        
        private void button3_Click(object sender, EventArgs e)
        {

            string dosyaAdi =listBox1.Items.Count +" Key Codes of "+ LngtextBox.Text +" X "+ DItextBox.Text + ".txt";
            using (StreamWriter writer = new StreamWriter(dosyaAdi))
            {
                foreach (string item in listBox1.Items)
                {
                    writer.WriteLine(item);
                }
            }
        }
    }
}

using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsFormsApp1
{
    public partial class Classroom : Form
    {
        public Classroom()
        {
            InitializeComponent();
        }

        private void Form2_Load(object sender, EventArgs e)
        {
            label4.Text = System.DateTime.Today.ToLongDateString();
        }

        private void button1_Click(object sender, EventArgs e)
        {
           
        }

        //functie de validare a campului varsta
        private void textBox3_TextChanged(object sender, EventArgs e)
        {
            if (!System.Text.RegularExpressions.Regex.IsMatch(textBox3.Text, @"^[0-9]*$"))
            {
                MessageBox.Show("Scrieti o varsta valida");
                textBox3.Text = textBox3.Text.Remove(textBox3.Text.Length - 1);
            }

        }

        private void button1_Click_1(object sender, EventArgs e)
        {
            string nume = textBox1.Text;
            string prenume = textBox2.Text;
            string varsta = textBox3.Text;

            //verificare campuri goale
            if ((textBox1.Text == "") || (textBox2.Text == "") || (textBox3.Text == ""))
                MessageBox.Show("Completati toate campurile!");
            else
            {
                //alta metoda de verificare camp - sa contina doar litere
                if (!Regex.Match(textBox1.Text, "^[A-Z][a-zA-Z]*$").Success)
                {
                    // numele este incorect 
                    MessageBox.Show("Nume invalid", "Mesaj", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    textBox1.Focus();
                    return;
                }

                string judet = listBox1.SelectedItem.ToString();
                string gen;

                if (radioButton1.Checked == true)
                    gen = radioButton1.Text;
                else
                    gen = radioButton2.Text;

                //cream lista de limbaje de programare
                string lp = "";
                if (checkBox1.Checked)
                    lp = lp + " " + checkBox1.Text;
                if (checkBox2.Checked)
                    lp = lp + " " + checkBox2.Text;
                if (checkBox3.Checked)
                    lp = lp + " " + checkBox3.Text;
                if (checkBox4.Checked)
                    lp = lp + " " + checkBox4.Text;
                if (checkBox4.Checked)
                    lp = lp + " " + checkBox4.Text;

                string linie = nume + " " + prenume + " " + judet + " " + gen + " " + lp;
                listBox2.Items.Add(linie);
            }
        }
    }
}

    


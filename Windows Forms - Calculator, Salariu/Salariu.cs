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
    public partial class Salariu : Form
    {
        public Salariu()
        {
            InitializeComponent();
        }


        private static readonly string[] Unitati = { "", "Unu", "Doi", "Trei", "Patru", "Cinci", "Șase", "Șapte", "Opt", "Nouă", "Zece", "Unsprezece", "Douăsprezece", "Treisprezece", "Paisprezece", "Cincisprezece", "Șaisprezece", "Șaptesprezece", "Optsprezece", "Nouăsprezece" };
        private static readonly string[] Zeci = { "", "", "Douăzeci", "Treizeci", "Patruzeci", "Cincizeci", "Șaizeci", "Șaptezeci", "Optzeci", "Nouăzeci" };

        public static string CifraInCuvinte(long cifra)
        {
            if (cifra == 0) return "Zero";
            if (cifra < 0) return "Minus " + CifraInCuvinte(Math.Abs(cifra));

            string cuvinte = "";
            if ((cifra / 1000000000) > 0)
            {
                cuvinte += CifraInCuvinte(cifra / 1000000000) + " Miliarde ";
                cifra %= 1000000000;
            }
            if ((cifra / 1000000) > 0)
            {
                cuvinte += CifraInCuvinte(cifra / 1000000) + " Milioane ";
                cifra %= 1000000;
            }
            if ((cifra / 1000) > 0)
            {
                cuvinte += CifraInCuvinte(cifra / 1000) + " Mii ";
                cifra %= 1000;
            }
            if ((cifra / 100) > 0)
            {
                cuvinte += CifraInCuvinte(cifra / 100) + " Sute ";
                cifra %= 100;
            }
            if (cifra > 0)
            {
                if (cuvinte != "")
                    cuvinte += " și ";

                if (cifra < 20)
                    cuvinte += Unitati[cifra];
                else
                {
                    cuvinte += Zeci[cifra / 10];

                    if (cuvinte != "")
                        cuvinte += " și ";
                    if ((cifra % 10) > 0)
                        cuvinte += " " + Unitati[cifra % 10];
                }
            }
            return cuvinte;
        }

        private void button1_Click(object sender, EventArgs e)
        {

            if (!Regex.Match(textBox1.Text, "^[0-9]*$").Success)
            {
                MessageBox.Show("Salariu Introdus Gresit", "Mesaj", MessageBoxButtons.OK, MessageBoxIcon.Error);
                textBox1.Focus();
                return;
            }

            double sbrut = Convert.ToDouble(textBox1.Text);

            label15.Text = Convert.ToString((sbrut / 1000) * 5);                                                        
            label16.Text = Convert.ToString((sbrut / 1000) * 105);                                                       
            label17.Text = Convert.ToString((sbrut / 1000) * 55);                                                       
            label18.Text = Convert.ToString(((sbrut - (sbrut/1000)*5 - (sbrut / 1000) * 105 - (sbrut / 1000) * 55 - 180) / 1000) * 160);
            label19.Text = Convert.ToString((sbrut / 1000) * 208);
            label20.Text = Convert.ToString((sbrut / 1000) * 50);
            label21.Text = Convert.ToString((sbrut / 1000) * 85);
            label22.Text = Convert.ToString((sbrut / 10000) * 25);
            label23.Text = Convert.ToString((sbrut / 1000) * 52);
            label24.Text = Convert.ToString((sbrut / 1000) * 4);


            MessageBox.Show(CifraInCuvinte(int.Parse(textBox1.Text)));



        }

    }
}

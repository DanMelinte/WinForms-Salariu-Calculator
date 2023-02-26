using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Windows.Forms.VisualStyles;

namespace WindowsFormsApp1
{
    public partial class Calculator : Form
    {
        double Result = 0;
        double Argument = 0;
        double ArgumentPoint = 0;
        int n = 0;

        char Operator;
        bool OperatorStatus = false;

        public Calculator()
        {
            InitializeComponent();
        }

        public void ReCalculate(double a) // (false->true) (false->true)
        {
            if (ArgumentPoint != 0)
            {
                n++;

                ArgumentPoint = 0;
                ArgumentPoint += + a / Math.Pow(10,n);
            }
            else if (OperatorStatus == false)
            {
                Result = Result * 10 + a;
            }
            else
            {
                Argument = Argument * 10 + a;
            }

            //OperatorStatus = false;
        }

        public int isOperationEnable()
        {
            if (label1.Text.Length != 0)
            {
                if (label1.Text[label1.Text.Length - 1].CompareTo('0') >= 0 && label1.Text[label1.Text.Length - 1].CompareTo('0') <= 9
                    || label1.Text[label1.Text.Length - 1].CompareTo(')') == 0)
                    return 1;
                else if (label1.Text[label1.Text.Length - 1].CompareTo('*') >= 0 && label1.Text[label1.Text.Length - 1].CompareTo('/') <= 0)
                    return 2;
            }
            return 0;
        }

        public void Operation(char a, char b)
        {
            switch (a)
            {
                case '+':
                    Result += Argument;
                    break;
                case '-':
                    Result -= Argument;
                    break;
                case '*':
                    Result *= Argument;
                    break;
                case '/':
                    Result /= Argument;
                    break;
            }


            if (b != '=')
            {
                Operator = b;
                Argument = 0;
            }

            label1.Text = Convert.ToString(Result);
        }

        private void button15_Click(object sender, EventArgs e)
        {
            label1.Text += '0';
            ReCalculate(0);
        }
        private void button1_Click(object sender, EventArgs e)
        {
            //int aux = Convert.ToInt32(label1.Text);
            //label1.Text = Convert.ToString(aux * 10 + 1);
            label1.Text += '1';
            ReCalculate(1);
        }

        private void button2_Click(object sender, EventArgs e)
        {
            label1.Text += '2';
            ReCalculate(2);
        }

        private void button3_Click(object sender, EventArgs e)
        {
            label1.Text += '3';
            ReCalculate(3);
        }

        private void button4_Click(object sender, EventArgs e)
        {
            label1.Text += '4';
            ReCalculate(4);
        }

        private void button5_Click(object sender, EventArgs e)
        {
            label1.Text += '5';
            ReCalculate(5);
        }

        private void button6_Click(object sender, EventArgs e)
        {
            label1.Text += '6';
            ReCalculate(6);
        }

        private void button7_Click(object sender, EventArgs e)
        {
            label1.Text += '7';
            ReCalculate(7);
        }

        private void button8_Click(object sender, EventArgs e)
        {
            label1.Text += '8';
            ReCalculate(8);
        }

        private void button9_Click(object sender, EventArgs e)
        {
            label1.Text += '9';
            ReCalculate(9);
        }

        private void button20_Click(object sender, EventArgs e)
        {
            Result = 0;
            Argument = 0;
            OperatorStatus = false;
            label1.Text = "";
        }

        private void button16_Click(object sender, EventArgs e)
        {
            if (isOperationEnable() == 1)
            {
                if (OperatorStatus == false)
                {
                    OperatorStatus = true;
                    Operator = '+';
                }
                else if (OperatorStatus == true)
                    Operation(Operator, '+');

                label1.Text += '+';
            }
            else if (isOperationEnable() == 2)
            {
                Operator = '+';
                label1.Text = label1.Text.Remove(label1.Text.Length - 1) + '+';
            }
        }

        private void button10_Click(object sender, EventArgs e)
        {
            if (isOperationEnable() == 1)
            {
                if (OperatorStatus == false)
                {
                    OperatorStatus = true;
                    Operator = '*';
                }
                else if (OperatorStatus == true)
                    Operation(Operator, '*');

                label1.Text += '*';
            }
            else if (isOperationEnable() == 2)
            {
                Operator = '*';
                label1.Text = label1.Text.Remove(label1.Text.Length - 1) + '*';
            }
        }

        private void button11_Click(object sender, EventArgs e)
        {
            if (isOperationEnable() == 1)
            {
                if (OperatorStatus == false)
                {
                    OperatorStatus = true;
                    Operator = '-';
                }
                else if (OperatorStatus == true)
                    Operation(Operator, '-');

                label1.Text += '-';
            }
            else if (isOperationEnable() == 2)
            {
                Operator = '-';
                label1.Text = label1.Text.Remove(label1.Text.Length - 1) + '-';
            }
        }

        private void button12_Click(object sender, EventArgs e)
        {
            if (isOperationEnable() == 1)
            {
                if (OperatorStatus == false)
                {
                    OperatorStatus = true;
                    Operator = '/';
                }
                else if (OperatorStatus == true)
                    Operation(Operator, '/');

                label1.Text += '/';
            }
            else if (isOperationEnable() == 2)
            {
                Operator = '/';
                label1.Text = label1.Text.Remove(label1.Text.Length - 1) + '/';
            }
        }

        private void button17_Click(object sender, EventArgs e)
        {
            String aux;
            if (label1.Text[0] != '-')
            {
                aux = label1.Text;
                label1.Text = "-(";
                label1.Text += aux;
                label1.Text += ")";
            }
            else
            {
                aux = label1.Text;
                label1.Text = "+(";
                label1.Text += aux;
                label1.Text += ")";
            }
        }

        private void button19_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void button18_Click(object sender, EventArgs e)
        {
            Operation(Operator, '=');
            Argument = 0;
            OperatorStatus = false;
        }

        private void button14_Click(object sender, EventArgs e)
        {

            if (label1.Text.Length != 0)
                if (label1.Text.IndexOf(".") == -1 && label1.Text[label1.Text.Length - 1] != ')')
                {
                    ArgumentPoint = -1;
                    label1.Text += '.';
                }

        }

        private void button13_Click(object sender, EventArgs e)
        {
            if (OperatorStatus == false && double.Parse(label1.Text) >= 0)
            {
                double aux = double.Parse(label1.Text);
                label1.Text = Math.Sqrt(aux).ToString();
            }
        }
    }
}

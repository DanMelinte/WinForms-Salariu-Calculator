using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsFormsApp1
{
    public partial class Main : Form
    {
        public Main()
        {
            InitializeComponent();
        }

        private void button2_Click_1(object sender, EventArgs e)
        {
            Form form1 = new Salariu();
            form1.ShowDialog();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            Form form2 = new Calculator();
            form2.ShowDialog();
        }
    }
}

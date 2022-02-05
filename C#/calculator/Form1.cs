using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace calculator
{
    public partial class Calculator : Form
    {
        public Calculator()
        {
            InitializeComponent();
        }
        double a;
        char ch = '0';
      

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (!(textBox1.Text.Length == 1 && textBox1.Text[0] == '0'))
            {
                textBox1.Text += "1";
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (!(textBox1.Text.Length == 1 && textBox1.Text[0] == '0'))
            {
                textBox1.Text += "2";
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            if (!(textBox1.Text.Length == 1 && textBox1.Text[0] == '0'))
            {
                textBox1.Text += "3";
            }
        }

        private void button4_Click(object sender, EventArgs e)
        {
            if (!(textBox1.Text.Length == 1 && textBox1.Text[0] == '0'))
            {
                textBox1.Text += "4";
            }
        }

        private void button5_Click(object sender, EventArgs e)
        {
            if (!(textBox1.Text.Length == 1 && textBox1.Text[0] == '0'))
            {
                textBox1.Text += "5";
            }
        }

        private void button6_Click(object sender, EventArgs e)
        {
            if (!(textBox1.Text.Length == 1 && textBox1.Text[0] == '0'))
            {
                textBox1.Text += "6";
            }
        }

        private void button7_Click(object sender, EventArgs e)
        {
            if (!(textBox1.Text.Length == 1 && textBox1.Text[0] == '0'))
            {
                textBox1.Text += "7";
            }
        }

        private void button8_Click(object sender, EventArgs e)
        {
            if (!(textBox1.Text.Length == 1 && textBox1.Text[0] == '0'))
            {
                textBox1.Text += "8";
            }
        }
        private void button9_Click(object sender, EventArgs e)
        {
            if (!(textBox1.Text.Length == 1 && textBox1.Text[0] == '0'))
            {
                textBox1.Text += "9";
            }
        }
        private void button10_Click(object sender, EventArgs e)
        {
            if (!(textBox1.Text.Length == 1 && textBox1.Text[0] == '0'))
            {
                textBox1.Text += "0";
                if (textBox1.Text[0] == '-' && textBox1.TextLength == 2)
                {
                    textBox1.Text = "0";
                }
            }
        }

        private void znaki(char c)
        {
            if (ch == '+' && textBox1.Text != "")
            {
                textBox1.Text = Convert.ToString(a + Convert.ToDouble(textBox1.Text));
                ch = '0';
            }
            if (ch == '*' && textBox1.Text != "")
            {
                textBox1.Text = Convert.ToString(a * Convert.ToDouble(textBox1.Text));
                ch = '0';
            }
            if (ch == '/' && textBox1.Text != "")
            {
                if (textBox1.Text != "0")
                {
                    textBox1.Text = Convert.ToString(a / Convert.ToDouble(textBox1.Text));
                    ch = '0';
                }
                else
                {
                    MessageBox.Show("Делить на ноль нельзя! Введите другое число!");
                    textBox1.Text = "";
                }
            }
            if (ch == '-' && textBox1.Text != "") 
            {
                textBox1.Text = Convert.ToString(a - Convert.ToDouble(textBox1.Text));
                ch = '0';
            }
        }

        private void buttonPlus_Click(object sender, EventArgs e)
        {
            znaki('+');
            if (textBox1.Text != "")
            {
                a = Convert.ToDouble(textBox1.Text);
                textBox1.Text = "";
                ch = '+';
            }
        }

        private void buttonMinus_Click(object sender, EventArgs e)
        {
            znaki('-');
            if (textBox1.Text != "")
            {
                a = Convert.ToDouble(textBox1.Text);
                textBox1.Text = "";
                ch = '-';
            }
            else
            {
                textBox1.Text += "-";
            }
        }

        private void buttonDel_Click(object sender, EventArgs e)
        {
            znaki('/');
            if (textBox1.Text != "")
            {
                a = Convert.ToDouble(textBox1.Text);
                textBox1.Text = "";
                ch = '/';
            }
        }

       

        private void buttonUmn_Click(object sender, EventArgs e)
        {
            znaki('*');
            if (textBox1.Text != "")
            {
                a = Convert.ToDouble(textBox1.Text);
                textBox1.Text = "";
                ch = '*';
            }
        }

        private void buttonRavno_Click(object sender, EventArgs e)
        {
            if (textBox1.Text != "" && textBox1.Text != "-") 
            {
                znaki('0');
            }
        }

        private void Clear_Click(object sender, EventArgs e)
        {
            textBox1.Text = "";
            ch = '0';
        }

        
    }
}

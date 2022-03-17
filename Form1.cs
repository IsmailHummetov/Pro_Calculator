using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Pro_Calculator
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
        string str;
        bool mathoperator = false, more = false;

        private void button_ClickC(object sender, EventArgs e)
        {
            txtLong.Clear();
            txtShort.Clear();
            str = "";
            more = false;
            mathoperator = false;
        }

        private void button_ClickPoint(object sender, EventArgs e)
        {
            mathoperator = false;
            txtLong.AppendText(".");
            txtShort.AppendText(".");
            str += '.';
        }

        private void button_Click0(object sender, EventArgs e)
        {
            str += '0';
            txtLong.AppendText("0");
            txtShort.AppendText("0");
            mathoperator = false;
        }

        private void button_Click1(object sender, EventArgs e)
        {
            str += '1';
            txtLong.AppendText("1");
            txtShort.AppendText("1");
            mathoperator = false;
        }

        private void button_Click2(object sender, EventArgs e)
        {
            str += '2';
            txtLong.AppendText("2");
            txtShort.AppendText("2");
            mathoperator = false;
        }

        private void button_Click3(object sender, EventArgs e)
        {
            str += '3';
            txtLong.AppendText("3");
            txtShort.AppendText("3");
            mathoperator = false;
        }

        private void button_Click4(object sender, EventArgs e)
        {
            str += '4';
            txtLong.AppendText("4");
            txtShort.AppendText("4");
            mathoperator = false;
        }

        private void button_Click5(object sender, EventArgs e)
        {
            str += '5';
            txtLong.AppendText("5");
            txtShort.AppendText("5");
            mathoperator = false;
        }

        private void button_Click6(object sender, EventArgs e)
        {
            str += '6';
            txtLong.AppendText("6");
            txtShort.AppendText("6");
            mathoperator = false;
        }

        private void button_Click7(object sender, EventArgs e)
        {
            str += '7';
            txtLong.AppendText("7");
            txtShort.AppendText("7");
            mathoperator = false;
        }

        private void button_Click8(object sender, EventArgs e)
        {
            str += '8';
            txtLong.AppendText("8");
            txtShort.AppendText("8");
            mathoperator = false;
        }

        private void button_Click9(object sender, EventArgs e)
        {
            str += '9';
            txtLong.AppendText("9");
            txtShort.AppendText("9");
            mathoperator = false;
        }

        private void textBox_TextChanged1(object sender, EventArgs e)//umumi misal
        {

        }

        private void textBox_TextChanged2(object sender, EventArgs e)//qisa
        {
            
        }

        private void button12_Click(object sender, EventArgs e)//+
        {
            txtShort.Clear();
            if(more==true)
            {
                txtLong.Clear();
                txtLong.AppendText(str);
                more = false;
            }
            if(mathoperator==true)
            {
                string m;
                m = txtLong.Text.Substring(0, txtLong.Text.Length - 1);
                txtLong.Clear();
                str =str.Substring(0,str.Length-1);
                txtLong.AppendText(m);
            }
            mathoperator = true;
            txtLong.AppendText("+");
            str += '+';
        }

        private void button13_Click(object sender, EventArgs e)//-
        {
            if (more == true)
            {
                txtLong.Clear();
                txtLong.AppendText(str);
                more = false;
            }
            if (mathoperator == true)
            {
                string m;
                m = txtLong.Text.Substring(0, txtLong.Text.Length - 1);
                txtLong.Clear();
                str = str.Substring(0, str.Length - 1);
                txtLong.AppendText(m);
            }
            mathoperator = true;
            txtShort.Clear();
            txtLong.AppendText("-");
            str += '-';
        }

        private void button14_Click(object sender, EventArgs e)//*
        {
            if (more == true)
            {
                txtLong.Clear();
                txtLong.AppendText(str);
                more = false;
            }
            if (mathoperator == true)
            {
                string m;
                m = txtLong.Text.Substring(0, txtLong.Text.Length - 1);
                txtLong.Clear();
                str = str.Substring(0, str.Length - 1);
                txtLong.AppendText(m);
            }
            mathoperator = true;
            str += '*';
            txtLong.AppendText("*");
            txtShort.Clear();
        }

        private void button15_Click(object sender, EventArgs e)// /
        {
            if (more == true)
            {
                txtLong.Clear();
                txtLong.AppendText(str);
                more = false;
            }
            if (mathoperator == true)
            {
                string m;
                m = txtLong.Text.Substring(0, txtLong.Text.Length - 1);
                txtLong.Clear();
                str = str.Substring(0, str.Length - 1);
                txtLong.AppendText(m);
            }
            mathoperator = true;
            str += '/';
            txtLong.AppendText("/");
            txtShort.Clear();
        }

        private void button16_Click(object sender, EventArgs e)// (
        {
            str += '(';
            txtLong.AppendText("(");
            mathoperator = false;
        }

        private void button17_Click(object sender, EventArgs e)// )
        {
            str += ')';
            txtLong.AppendText(")");
            mathoperator = false;
        }

        private void button11_Click(object sender, EventArgs e)//=
        {
            more = true;
            txtLong.AppendText("=");
            mathoperator = false;
            txtShort.Clear();
            bool bracket = false;
            for (int i = 0; i < str.Length; i++)
            {
                if (str[i] == '(')
                {
                    bracket = true;
                    break;
                }
            }
            if (bracket)
                str = moterize(str);
            str = hesablama(str);
            txtLong.AppendText(str);
            txtShort.AppendText(str);
        }


        //HESABLAMA
        public static string hesablama(string str1)
        {
            List<string> operation = new List<string>();
            List<float> numbers = new List<float>();
            bool negative = false;
            string num = "";
            int i;
            if (str1[0] == '-')
            {
                negative = true;
                str1 = str1.Remove(0, 1);
            }
            for (i = 0; i < str1.Length; i++)
            {
                if (str1[i] != '+' && str1[i] != '-' && str1[i] != '*'
                    && str1[i] != '/' && str1[i] != '%' && str1[i] != '^')
                {
                    num += str1[i];
                }
                else
                {
                    numbers.Add(float.Parse(num));
                    num = "";
                }
                if (str1[i] == '+' || str1[i] == '-' || str1[i] == '*'
                    || str1[i] == '/' || str1[i] == '^' || str1[i] == '%')
                    operation.Add(str1[i].ToString());
            }
            if (num != "")
                numbers.Add(float.Parse(num));
            if (negative == true)
                numbers[0] *= (-1);
            for (i = 0; i < operation.Count; i++)
            {
                if (operation[i] == "*")
                {
                    numbers[i] = numbers[i] * numbers[i + 1];
                    operation.RemoveAt(i);
                    numbers.RemoveAt(i + 1);
                    i--;
                }
                else if (operation[i] == "/")
                {
                    numbers[i] = numbers[i] / numbers[i + 1];
                    operation.RemoveAt(i);
                    numbers.RemoveAt(i + 1);
                    i--;
                }
                else if (operation[i] == "^")
                {
                    numbers[i] = numbers[i] * numbers[i + 1] * (-1);
                    operation.RemoveAt(i);
                    numbers.RemoveAt(i + 1);
                    i--;
                }
                else if (operation[i] == "%")
                {
                    numbers[i] = numbers[i] / numbers[i + 1] * (-1);
                    operation.RemoveAt(i);
                    numbers.RemoveAt(i + 1);
                    i--;
                }
            }
            for (i = 0; i < operation.Count; i++)
            {
                if (operation[i] == "+")
                {
                    numbers[i] = numbers[i] + numbers[i + 1];
                    operation.RemoveAt(i);
                    numbers.RemoveAt(i + 1);
                    i--;
                }
                else if (operation[i] == "-")
                {
                    numbers[i] = numbers[i] - numbers[i + 1];
                    operation.RemoveAt(i);
                    numbers.RemoveAt(i + 1);
                    i--;
                }
            }
            return numbers[0].ToString();
        }


        //ISHARELER
        public static string isareler(string str1)
        {
            int i;
            for (i = 0; i < str1.Length; i++)
            {
                if (str1[i] == '+' && str1[i + 1] == '-')
                {
                    str1 = str1.Remove(i, 2);
                    str1 = str1.Insert(i, "-");
                }
                else if (str1[i] == '-' && str1[i + 1] == '-')
                {
                    str1 = str1.Remove(i, 2);
                    str1 = str1.Insert(i, "+");
                }
                else if (str1[i] == '*' && str1[i + 1] == '-')
                {
                    str1 = str1.Remove(i, 2);
                    str1 = str1.Insert(i, "^");
                }
                else if (str1[i] == '/' && str1[i + 1] == '-')
                {
                    str1 = str1.Remove(i, 2);
                    str1 = str1.Insert(i, "%");
                }
                else if (str1[i] == '^' && str1[i + 1] == '-')
                {
                    str1 = str1.Remove(i, 2);
                    str1 = str1.Insert(i, "*");
                }
                else if (str1[i] == '%' && str1[i + 1] == '-')
                {
                    str1 = str1.Remove(i, 2);
                    str1 = str1.Insert(i, "/");
                }
            }
            return str1;
        }


        //MOTERIZELER
        public static string moterize(string str1)
        {
            int i, k = 0, l = 0, t = 0, j;
            string m;
            for (i = 0; i < str1.Length; i++)
            {
                if (str1[i] == '(')
                    t++;
            }
            for (j = 0; j < t; j++)
            {
                for (i = str1.Length - 1; i >= 0; i--)
                {
                    if (str1[i] == '(')
                    {
                        k = i;
                        break;
                    }
                }
                for (i = k; i < str1.Length; i++)
                {
                    if (str1[i] == ')')
                    {
                        l = i;
                        break;
                    }
                }
                m = str1.Substring(k + 1, l - k - 1);
                str1 = str1.Remove(k, l - k + 1);
                str1 = str1.Insert(k, hesablama(m));
                str1 = isareler(str1);
            }
            return str1;
        }

    }
}

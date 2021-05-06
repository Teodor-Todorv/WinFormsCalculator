using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsFormsApp2
{
    public partial class Calculator : Form
    {
        private double memory;

        public Calculator()
        {
            InitializeComponent();
            MC_B.Enabled = false;
            MR_B.Enabled = false;
        }
        bool operationPerformed = false;
        string operation = "";
        double result = 0;
        int dotCount = 0;
        
       

        private void button_click(object sender, EventArgs e)
        {
            if ((TResult.Text == "0") || (operationPerformed))
            {
                TResult.Clear();
                dotCount = 0;
            }

            operationPerformed = false;
            Button b = (Button)sender;
            if (b.Text == "." && dotCount < 1)
            {
                dotCount++;
                TResult.Text = TResult.Text + b.Text;
            }
            if (b.Text != ".")
            {
                TResult.Text = TResult.Text + b.Text;
            }

        }

        private void operator_Click(object sender, EventArgs e)
        {
            Button b = (Button)sender;
            if (result != 0)
            {
                button16.PerformClick();
                
                operation = b.Text;
                result = Double.Parse(TResult.Text);
                operationPerformed = true;
                equation.Text = result + " " + operation;
            } else {
                
                operation = b.Text;
                result = Double.Parse(TResult.Text);
                operationPerformed = true;
                equation.Text = result + " " + operation;
            }
            

        }

        private void Equal_Click(object sender, EventArgs e)
        {
            equation.Text = "";
            switch (operation)
            {
                case "+":
                    TResult.Text = (result + Double.Parse(TResult.Text)).ToString();
                    break;
                case "-":
                    TResult.Text = (result - Double.Parse(TResult.Text)).ToString();
                    break;
                case "*":
                    TResult.Text = (result * Double.Parse(TResult.Text)).ToString();
                    break;
                case "/":
                    TResult.Text = (result / Double.Parse(TResult.Text)).ToString();
                    break;
                case "%":
                    TResult.Text = ((result / 100) % Double.Parse(TResult.Text)).ToString();
                    break;
                default:
                    break;
            }
            double answer = double.Parse(TResult.Text);

        }

        private void Clear_B(object sender, EventArgs e)
        {
            TResult.Text = "0";
            equation.Text = "";
            result = 0;
            dotCount = 0;
        }

        private void CE_B(object sender, EventArgs e)
        {
            TResult.Text = "0";
            dotCount = 0;
        }

        

        private void Del_Click(object sender, EventArgs e)
        {
            TResult.Text = TResult.Text.Remove(TResult.Text.Length - 1);
            if (TResult.Text.Length == 0)
                TResult.Text = "0";
        }

        private void MR_B_Click(object sender, EventArgs e)
        {
            TResult.Text = memory.ToString();
        }

        private void MC_B_Click(object sender, EventArgs e)
        {
            TResult.Text = "0";
            memory = 0;
            MR_B.Enabled = false;
            MC_B.Enabled = false; 
        }

        private void MP_B_Click(object sender, EventArgs e)
        {
            memory += Double.Parse(TResult.Text);  
        }

        private void MM_B_Click(object sender, EventArgs e)
        {
            memory -= Double.Parse(TResult.Text);
        }

        private void MS_B_Click(object sender, EventArgs e)
        {
            memory = Double.Parse(TResult.Text);
            MC_B.Enabled = true;
            MR_B.Enabled = true;
        }

    }
}

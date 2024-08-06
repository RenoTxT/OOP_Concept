using System;
using System.CodeDom;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Diagnostics.Eventing.Reader;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

//program start from here
//Created by Reno Mardiputra
//Time: 05/08/2024
//Donation via BRI: 0512 0102 3520 507

namespace calculator
{
    public partial class calculator : Form
    {
        //declaration public variable and flex
        private double a, b,c;
        private string operation = "";
        private bool toB = false;
        private bool clickedOperation = false;
        private bool isResult = false;
        private bool multiplication = false;
        private bool summingnonumber = false;


        public calculator()
        {
            //intialize the component and the methods also setting all the view at 0 for the first time
            InitializeComponent();
            InitializeEventHandlers();
            textBox1.Text = "0";
            angka_history.Text = "0";
        }


        private void NumberButton_Click(object sender, EventArgs e)
        {
            //this program is used for change the number at the text box by using flex, we can add more leght and separate the "a" variable and "b" variable
            Button button = (Button)sender;
            string number = button.Text;
            if (summingnonumber == true)
            {
                textBox1.Text = number;
                summingnonumber = false;
            }
            else
            {
                if (textBox1.Text == "0")
                {
                    // Replace "0" with the clicked number for "a" variable
                    textBox1.Text = number;
                }
                else
                {
                    //when it's "b" variable it stuck at the last number and change to then number which you clicked
                    if (clickedOperation == true || multiplication == true && toB == true)
                    {
                        textBox1.Text = number;
                        clickedOperation = false;
                    }
                    else
                    {
                        // Append the clicked number to the existing text
                        textBox1.Text += number;
                    }
                }
            }
        }

        private void InitializeEventHandlers()
        {
             // Numeric buttons
             this.one1.Click += new System.EventHandler(this.NumberButton_Click);
             this.two2.Click += new System.EventHandler(this.NumberButton_Click);
             this.three3.Click += new System.EventHandler(this.NumberButton_Click);
             this.four4.Click += new System.EventHandler(this.NumberButton_Click);
             this.five5.Click += new System.EventHandler(this.NumberButton_Click);
             this.six6.Click += new System.EventHandler(this.NumberButton_Click);
             this.seven7.Click += new System.EventHandler(this.NumberButton_Click);
             this.eight8.Click += new System.EventHandler(this.NumberButton_Click);
             this.nine9.Click += new System.EventHandler(this.NumberButton_Click);
             this.zero0.Click += new System.EventHandler(this.NumberButton_Click);

             // Methods buttons
             this.deleteAll.Click += new System.EventHandler(this.deleteAll_Click);
             this.pointKoma.Click += new System.EventHandler(this.pointKoma_Click);
        }

        private void deleteAll_Click(object sender, EventArgs e)
        {
            // It's for "C" at calculator when you pressed it, all the variable is gone and all the display set to 0
            textBox1.Clear();
            textBox1.Text = "0";
            a = b = c = 0;
            toB = false;
            clickedOperation = false;
            isResult = false;
            multiplication = false;
            summingnonumber = false;    
            operation = "";
            angka_history.Text = "0";
        }

        private void delete_Click(object sender, EventArgs e)
        {
            if (isResult)
            {
                // When a result is displayed, pressing "CE" should reset the text box for new input
                textBox1.Text = "0";
                isResult = false; // Reset the flag for new input
            }
            else
            {
                // When inputting a number, remove the last character
                if (textBox1.Text.Length > 1)
                {
                    textBox1.Text = textBox1.Text.Remove(textBox1.Text.Length - 1);
                }
                else
                {
                    textBox1.Text = "0";
                }
            }
        }

        private void pointKoma_Click(object sender, EventArgs e)
        {
            // If there's no "." at the textbox, then you can add ".", else the program do nothing because there's no other code for that
            if (!textBox1.Text.Contains("."))
            {
                textBox1.Text += ".";
            }
        }

// problem is from here, need some maintenance
        private void Summing_Click(object sender, EventArgs e)
        {
            if (toB)
            {
                b = double.Parse(textBox1.Text);
            }
            else
            {
                a = double.Parse(textBox1.Text);
            }
            switch (operation)
            {
                case "plus":
                    c = a + b;
                    angka_history.Text = a + " + " + b;
                    multiplication = true;
                    break;
                case "minus":
                    c = a - b;
                    angka_history.Text = a + " - " + b;
                    multiplication = true;
                    break;
                case "multiply":
                    c = a * b;
                    angka_history.Text = a + " × " + b;
                    multiplication = true;
                    break;
                case "divide":
                    if (textBox1.TabStop                                                                                                                                                                                                                                                                                            )
                    {
                        // Perform division
                        c = a / b;
                        angka_history.Text = a + " ÷ " + b;
                        multiplication = true;
                    }
                    else
                    {
                        // Handle division by zero
                        textBox1.Text = "Cannot Divide by 0";
                        // Reset the state of the calculator
                        a = 0;
                        b = 0;
                        c = 0;
                        operation = "";
                        toB = false;
                        clickedOperation = false;
                    }
                    break;
                default:
                    c = double.Parse(textBox1.Text);
                    angka_history.Text = c.ToString();
                    summingnonumber = true;
                    break;
            }
            textBox1.Text = c.ToString();
            toB = false;
            a = c;
            c = 0;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (toB)
            {
                b = 
                c = a / b;
                angka_history.Text = a + " ÷ " + b;
                textBox1.Text = c.ToString();
                a = c;
                c = 0;
                multiplication = true;
            }
            else
            {
                a = double.Parse(textBox1.Text);
                angka_history.Text = textBox1.Text + " ÷ ";
                operation = "divide";
                toB = true;
                clickedOperation = true;
            }
        }

        private void multiply_Click(object sender, EventArgs e)
        {
            if (toB)
            {
                b = double.Parse(textBox1.Text);
                c = a * b;
                angka_history.Text = a + " × " + b;
                textBox1.Text = c.ToString();
                a = c;
                c = 0;
                multiplication = true;
            }
            else
            {
                a = double.Parse(textBox1.Text);
                angka_history.Text = textBox1.Text + " × ";
                operation = "multiply";
                toB = true;
                clickedOperation = true;
            }
        }

        private void plus_Click(object sender, EventArgs e)
        {
            if (toB)
            {
                b = double.Parse(textBox1.Text);
                c = a + b;
                angka_history.Text = a + " + " + b;
                textBox1.Text = c.ToString();
                a = c;
                c = 0;
                multiplication = true;
            }
            else
            {
                a = double.Parse(textBox1.Text);
                angka_history.Text = textBox1.Text + " + ";
                operation = "plus";
                toB = true;
                clickedOperation = true;
            }
        }

        private void minus_Click(object sender, EventArgs e)
        {
            if (toB)
            {
               
                b = double.Parse(textBox1.Text);
                c = a - b;
                angka_history.Text = a + " - " + b;
                textBox1.Text = c.ToString();
                a = c;
                c = 0;
                multiplication = true;
            }
            else
            {
                a = double.Parse(textBox1.Text);
                angka_history.Text = textBox1.Text + " - ";
                operation = "minus";
                toB = true;
                clickedOperation = true;

            }
        }

        private void negate_Click(object sender, EventArgs e)
        {
            if (double.TryParse(textBox1.Text, out double currentValue))
            {
                // Negate the value
                currentValue = -currentValue;

                // Update textBox1 with the negated value
                textBox1.Text = currentValue.ToString();
            }
        }

        private void Form1_Load(object sender, EventArgs e)
        {
        }

        private void zero0_Click(object sender, EventArgs e)
        {
        }
    }
}


//problems:
//1. The divide by 0 still not showing
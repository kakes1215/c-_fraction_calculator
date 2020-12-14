using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsFormsApplication3
{
    public partial class Form1 : Form
    {
        Fraction[] FractionArray = new Fraction[3];
        
        StringBuilder sb = new StringBuilder();
        string op = " ";
        string problem = " ";

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private Button[] buttons;
        public Form1()
        {
            InitializeComponent();
            buttons = new Button[10];
            buttons[0] = button1;
            buttons[1] = button2;
            buttons[2] = button3;
            buttons[3] = button4;
            buttons[4] = button5;
            buttons[5] = button6;
            buttons[6] = button7;
            buttons[7] = button8;
            buttons[8] = button9;
            buttons[9] = button0;


            for (int i = 0; i < buttons.Length; i++)
            {
                buttons[i].Click += new EventHandler(DoSomething);
            }

            Clear.Click += new EventHandler(DoSomething);
            Plus.Click += new EventHandler(DoSomething);
            Minus.Click += new EventHandler(DoSomething);
            Times.Click += new EventHandler(DoSomething);
            Divide.Click += new EventHandler(DoSomething);
            FractionDiv.Click += new EventHandler(DoSomething);
            EqualsButton.Click += new EventHandler(DoSomething);
        }

        private void DoSomething(object sender, EventArgs e)
        {
            Button b = (Button)sender;
                    

            if (b == EqualsButton){
                FractionArray = Split(sb.ToString());
                FractionArray = CalculateResults(FractionArray, op);

               //clear the textbox
                displayBox.Text = " ";
                //Disable buttons 0-9 and / button
                for (int i = 0; i < buttons.Length; i++)
                {
                    buttons[i].Enabled = false;
                }
                FractionDiv.Enabled = false;

                //Display results
                String message = FractionArray[0].ToString() + " " + op + " " + FractionArray[1].ToString() + " = " + FractionArray[2].ToString();

                displayBox.Text = message;
               
               
            }

            if (b == Clear)
            {
                sb = ClearSb(sb);
                displayBox.Text = "";
                for (int i = 0; i < buttons.Length; i++)
                {
                    buttons[i].Enabled = true;
                }
                FractionDiv.Enabled = true;
            }

            if (b == Plus || b == Minus || b == Times || b == Divide)
            {
                //clear the textbox
                displayBox.Text = "";
                
                if (b == Plus)
                {
                    op = " + ";
                    sb.Append(op);
                 
                }
                else if (b == Minus)
                {
                    op = " - ";
                    sb.Append(op);
                   
                }
                else if (b == Times)
                {
                    op = " * ";
                    sb.Append(op);
                   
                } 
                else
                {
                    op = " / ";
                    sb.Append(op);
                  
                }
               
            }

            if (b == button0 || b == button1 || b == button2 || b == button3 || b == button4 || b == button5 || b == button6 || b == button7 || b == button8 || b == button9 || b == FractionDiv)
            {
 
                problem = displayBox.Text += b.Text;
                if (b == button0)
                {
                    problem = "0";
                    sb.Append(problem);
                }
                if (b == button1)
                {
                    problem = "1";
                    sb.Append(problem);
                }
                if (b == button2)
                {
                    problem = "2";
                    sb.Append(problem);
                }
                if (b == button3)
                {
                    problem = "3";
                    sb.Append(problem);
                }
                if (b == button4)
                {
                    problem = "4";
                    sb.Append(problem);
                }
                if (b == button5)
                {
                    problem = "5";
                    sb.Append(problem);
                }
                if (b == button6)
                {
                    problem = "6";
                    sb.Append(problem);
                }
                if (b == button7)
                {
                    problem = "7";
                    sb.Append(problem);
                }
                if (b == button8)
                {
                    problem = "8";
                    sb.Append(problem);
                }
                if (b == button9)
                {
                    problem = "9";
                    sb.Append(problem);
                }
                if (b == FractionDiv)
                {
                    sb.Append("/");
                }
               
               
            }

          
        }


        private StringBuilder ClearSb (StringBuilder value)
        {
            value.Length = 0;
            value.Capacity = 0;
            return value;
        }
        

        

        private Fraction[] Split (string results)
        {
            string[] st = results.Split(' ');
            string first = st[0]; //first Fraction
            string second = st[2]; //second Fraction

            char[] delimiterChar = {'/'};//Split by the fraction sign

            //Determine if the first value is a whole number of fraction
            string[] pieces = first.Split(delimiterChar);

            if (pieces.Length == 1) // whole number, call one-arg constructor

                FractionArray[0] = new Fraction(Convert.ToInt32(pieces[0]));
            else                    // fraction, call two-arg constructor
                                    // Split into numeration and denominator and create fraction object
                FractionArray[0] = new Fraction(Convert.ToInt32(pieces[0]),
                                                    Convert.ToInt32(pieces[1]));

            // Determine if second value is a whole number or fraction
            pieces = second.Split(delimiterChar);
            if (pieces.Length == 1) // whole number, call one-arg constructor
                FractionArray[1] = new Fraction(Convert.ToInt32(pieces[0]));
            else                    // fraction, call two-arg constructor
                                    // Split into numeration and denominator and create fraction object
                FractionArray[1] = new Fraction(Convert.ToInt32(pieces[0]),
                                                    Convert.ToInt32(pieces[1]));

            return FractionArray;
        }

       private Fraction[] CalculateResults(Fraction[] FractionArray, string op)
        {
            switch (op)
            {
                case " + ":
                    // 'plus' returns a reduced fraction object
                    FractionArray[2] = FractionArray[0].Plus(FractionArray[1]);
                    break;
                case " - ":
                    // 'minus' returns a reduced fraction object
                    FractionArray[2] = FractionArray[0].Minus(FractionArray[1]);
                    break;
                case " * ":
                    // 'times' returns a reduced fraction object
                    FractionArray[2] = FractionArray[0].Times(FractionArray[1]);
                    break;
                case " / ":
                    // 'divide' returns a reduced fraction object
                    FractionArray[2] = FractionArray[0].Divide(FractionArray[1]);
                    break;
            }
            return FractionArray;
        }


    }
}


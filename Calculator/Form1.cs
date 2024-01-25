/////////////////////////////////////////////////////////////////////////
/// Change History
/// Date        Developer           Description
/// 2024-01-18  Kush Juneja         Event handler for the GUI
/// 2024-01-23  Kush Juneja         Created event handlers for plus, subtract, multiply, divide, positive / negative button, backspace button, clear button.
/// 2024-01-23  Kush Juneja         Added Switch operation "switch (mathOperation)".
/// 2024-01-23  Kush Juneja         Added C# ternary operator and lambda method. Fixed decimal input in the calc. 
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Calculator
{
    // Event handlers
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        // this event handler will work for all the number key buttons
        private void numBtn_Click(object sender, EventArgs e)
        {
            // the calc initially displays at 0 and we want to get rid of it

            // if display.Text == "0" - removes 0 from the display

            if (display.Text == "0")
            {
                display.Clear();
            }

            // here we are casting the sender parameter pass in to
            // something of type Button for temp getting the text off of the button
            Button btn = (Button)sender;
            display.Text = display.Text + btn.Text;
        }

        // CE. WIll zero out the display
        // or memorize the state of the calculator in place
        private void clearEntryBtn_Click(object sender, EventArgs e)
        {
            // for clear entry we'll clear the display
            // and leave the state variables alone
            display.Text = "0";
        }
        // C (ALL). WIll zero out the display
        // and clear any memorized state of the display
        private void clearBtn_Click(object sender, EventArgs e)
        {
            //reset the state held in the isntance variables
            beginMathOp = false;
            leftOperand = 0.0;
            mathOperation = string.Empty;

            display.Text = "0";

        }

        // these 3 instance vars will hold the state of the calculator before
        // and during math operations
        // storage for the first operand of the math operation
        private double leftOperand = 0.0;

        // need storage for the current selected math operation
        private string mathOperation = string.Empty;

        //signals that we have started into a math operation
        private bool beginMathOp = false;

        // + sign
        private void mathOpBtn_Click(object sender, EventArgs e)
        {
            //signal that a math operation has actually started
            beginMathOp = true;

            // load up the "global" class wide instance vars
            leftOperand = double.Parse(display.Text);

            // Button btn = (Button)sender;
            mathOperation = ((Button)sender).Text;

            // don't forget to clear the display
            display.Clear();
        }

        // the equal sign handler is the one that actually does the
        // math opertiaon of the calc
        private void equalBtn_Click(object sender, EventArgs e)
        {
            //decide what the actual math operation is and do the math!
            switch (mathOperation)
            {
                case "+":
                    display.Text = (leftOperand + double.Parse(display.Text)).ToString();
                    break;
                case "-":
                    display.Text = (leftOperand - double.Parse(display.Text)).ToString();
                    break;
                case "x":
                    display.Text = (leftOperand * double.Parse(display.Text)).ToString();
                    break;
                case "/":
                    display.Text = (leftOperand / double.Parse(display.Text)).ToString();
                    break;
                default:
                    MessageBox.Show("ERROR: This code should be unreachable. :: from the switch in the equals button handler");
                    break;
            }
        }

        // handle the positive/negative button
        private void posNegBtn_Click(object sender, EventArgs e)
        {
            // same basic operation as the "equals handler, but negation is
            // unary and does not need the left operand
            display.Text = (-double.Parse(display.Text)).ToString();
        }

        // backspace button handler
        private void backSpaceBtn_Click(object sender, EventArgs e)
        {
            // some kind of if statement that checks to make sure that
            // there are at least 1 chars in the display text property
            // sunny day scenario
            if (display.Text.Length > 1)
            {
                display.Text = display.Text.Substring(0, display.Text.Length - 1);
            }

            // otherwise nothing happens
        }

        // example of C# lambda expression - THIS IS THE ORIGINAL method (traditional method definition)
        private void decimalBtn_Click(object sender, EventArgs e)
        {
            // example of C# ternary operator
            display.Text = display.Text.Contains(".") ? display.Text : display.Text + ".";
        }

        // example of C# lambda expression - THIS IS THE LAMBDA EXPRESSION version
        private void decimalPBtn_Click(object sender, EventArgs e) => 
            display.Text = display.Text.Contains(".") ? display.Text : display.Text + ".";
    }
}

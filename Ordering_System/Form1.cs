using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Ordering_System
{
    public partial class Form1 : Form
    {
        //Global Variables to Use
        string operation;
        double firstNumber;
        double secondNumber;
        double answer;
        double TAX = 17.5;

        double mangoJuice;
        double orangeJuice;
        double appleJuice;

        double US_DOLLAR = 1.52;
        double CANIDIAN_DOLLAR = 2.03;
        double PAKISTANI_RUPPE = 100.68;
        


        public Form1()
        {
            InitializeComponent();
        }

        

        private void Form1_Load(object sender, EventArgs e)
        {
            // TODO: This line of code loads data into the 'orderSystemDbDataSet.tblOrderSystem' table. You can move, or remove it, as needed.
            this.tblOrderSystemTableAdapter.Fill(this.orderSystemDbDataSet.tblOrderSystem);
            
           
            comboBox_Convertor.Text = "Plz Choose";
            comboBox_Convertor.Items.Add("US DOLLAR");
            comboBox_Convertor.Items.Add("CANIDIAN DOLLAR");
            comboBox_Convertor.Items.Add("PAKISTANI RUPPEE");

            DateTime iDate = DateTime.Now;
            orderDateTextBox.Text = iDate.ToString("dd/MM/yyyy");
            orderTimeTextBox.Text = iDate.ToString("HH:mm:ss");

            qty1TextBox.Text = "0";
            qty2TextBox.Text = "0";
            qty3TextBox.Text = "0";

            unitPrice1TextBox.Text = "0";
            unitPrice2TextBox.Text = "0";
            unitPrice3TextBox.Text = "0";
        }

        private void Button_Click(object sender, EventArgs e)
        {
            
            Button btnNum = (Button)sender;
            
            if (lblDisplayCalText.Text == "0")
            {
                lblDisplayCalText.Text = btnNum.Text;
            }
            else 
            
            lblDisplayCalText.Text += btnNum.Text;
        }

        private void Cal_Operation_Click(object sender, EventArgs e)
        {
            Button btnOps = (Button)sender;
            firstNumber = double.Parse(lblDisplayCalText.Text);
            lblDisplayCalText.Text = " "; 
            operation = btnOps.Text;
            lblShowCal_innerDisplay.Text = firstNumber + " " + operation; //to show the display in inner lable
        }

        private void btnEquals_Click(object sender, EventArgs e)
        {
            lblShowCal_innerDisplay.Text = "";
            secondNumber = double.Parse(lblDisplayCalText.Text);
            switch (operation)
            {
                case "+":
                    answer = firstNumber + secondNumber;
                    lblDisplayCalText.Text = answer.ToString();
                    
                    
                    break;
                
                case "-":
                    answer = firstNumber - secondNumber;
                    lblDisplayCalText.Text = answer.ToString();
                    break;
                
                case "*":
                    answer = firstNumber * secondNumber;
                    lblDisplayCalText.Text = answer.ToString();
                    break;
                
                case "/":

                    if (secondNumber == 0)
                    {
                        lblDisplayCalText.Text = "Error denominator cant be zero";
                    }
                    else
                    {
                        answer = firstNumber / secondNumber;
                        lblDisplayCalText.Text = answer.ToString();
                    }
                        break;
                    
                default:
                    break;
            }
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            lblDisplayCalText.Text = "0";
            lblShowCal_innerDisplay.Text = "";

        }

        private void btnBackSlash_Click(object sender, EventArgs e)
        {
            if (lblDisplayCalText.Text.Length > 0)
            {
                lblDisplayCalText.Text = lblDisplayCalText.Text.Remove(lblDisplayCalText.Text.Length - 1, 1);
            }
        }

        private void btnDot_Click(object sender, EventArgs e)
        {
            Button btndot = (Button)sender;
            if (!lblDisplayCalText.Text.Contains("."))
            {
                lblDisplayCalText.Text += btndot.Text;
            }
        }

        private void currencyConvertorToolStripMenuItem_Click(object sender, EventArgs e)
        {
            btnShowConvertor.Visible = false;
        }

        private void standartToolStripMenuItem_Click(object sender, EventArgs e)
        {
            btnShowConvertor.Visible = true;
        }

        private void btnShowConvertor_Click(object sender, EventArgs e)
        {
            btnShowConvertor.Visible = false;
        }

        private void receiptToolStripMenuItem_Click(object sender, EventArgs e)
        {
            tabControl1.SelectedTab = tabPage2;
        }

        private void viewOrderToolStripMenuItem_Click(object sender, EventArgs e)
        {
            tabControl1.SelectedTab = tabPage3;
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            btnShowConvertor.Visible = true;
        }

        private void btnReset_Click(object sender, EventArgs e)
        {
            qty1TextBox.Text = "0";
            qty2TextBox.Text = "0";
            qty3TextBox.Text = "0";

            unitPrice1TextBox.Text = "0";
            unitPrice2TextBox.Text = "0";
            unitPrice3TextBox.Text = "0";

            subTotal1TextBox.Text = "";
            subTotal2TextBox.Text = "";
            subTotal3TextBox.Text = "";

            netSubTotalTextBox.Text = "";
            taxTextBox.Text = "";
            netTotalTextBox.Text = "";


            customerNameTextBox.Text = "";
            customerPhoneTextBox.Text = "";
            order_RefTextBox.Text = "";

        }

        private void btnReceipt_Click(object sender, EventArgs e)
        {
            tabControl1.SelectedTab = tabPage2;
        }

        private void btnOrder_Click(object sender, EventArgs e)
        {
            tabControl1.SelectedTab = tabPage3;
        }

        private void btnCalculator_Click(object sender, EventArgs e)
        {
            tabControl1.SelectedTab = tabPage1;
        }

        private void btnAddToBaskit_Click(object sender, EventArgs e)
        {
            tabControl1.SelectedTab = tabPage2;
            txtReceipt.AppendText("\t\t\t Ordering System Demo "+Environment.NewLine);
            txtReceipt.AppendText("===================================================================================" + Environment.NewLine);
            txtReceipt.AppendText(Environment.NewLine);
            txtReceipt.AppendText("Name : " + customerNameTextBox.Text + "\tPhone No. : " + customerPhoneTextBox.Text + "\tOrder Ref No. : " + order_RefTextBox.Text + Environment.NewLine);
            txtReceipt.AppendText(Environment.NewLine);
            txtReceipt.AppendText("Order Date : " + orderDateTextBox.Text +"\t Order Time : " + orderTimeTextBox.Text + Environment.NewLine);
            
            txtReceipt.AppendText(Environment.NewLine+"Item Type"+"\t\t Qty" +"\t"+"Unit Price" +"\t"+ " Sub Total" + Environment.NewLine);
            txtReceipt.AppendText(Environment.NewLine + "Orange Juice" + "\t" + qty1TextBox.Text + "\t" + unitPrice1TextBox.Text + "\t" + subTotal1TextBox.Text + Environment.NewLine);
            txtReceipt.AppendText(Environment.NewLine + "Apple Juice" + "\t" + qty2TextBox.Text + "\t" + unitPrice2TextBox.Text + "\t" + subTotal2TextBox.Text + Environment.NewLine);
            txtReceipt.AppendText(Environment.NewLine + "Mango Juice" + "\t" + qty3TextBox.Text + "\t" + unitPrice3TextBox.Text + "\t" + subTotal3TextBox.Text + Environment.NewLine);
            txtReceipt.AppendText(Environment.NewLine+"\t\t\t" + "Order Sub Total " + "\t" + netSubTotalTextBox.Text + Environment.NewLine);
            txtReceipt.AppendText(Environment.NewLine + "\t\t\t" + "Tax on order " + "\t" + taxTextBox.Text + Environment.NewLine);
            txtReceipt.AppendText(Environment.NewLine + "\t\t\t" + "Net Total " + "\t" + netTotalTextBox.Text + Environment.NewLine);
            
            txtReceipt.AppendText(Environment.NewLine+"===================================================================================" +Environment.NewLine);
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            DateTime iDate = DateTime.Now;
            orderDateTextBox.Text = iDate.ToString("dd/MM/yyyy");
           orderTimeTextBox.Text = iDate.ToString("HH:mm:ss");

            
            tabControl1.SelectedTab = tabPage3;
            
            this.Validate();
            this.tblOrderSystemBindingSource.EndEdit();
        }

        private void btnTotal_Click(object sender, EventArgs e)
        {
            //varaibles
            double Ojuice_qty;
            double Ajuice_qty;
            double Mjuice_qty;
            double unitprice1;
            double unitprice2;
            double unitprice3;
            double netTax;
           
            
            
            
            //Assigning values to the varaibles


            Ojuice_qty = Double.Parse(qty1TextBox.Text);
            Ajuice_qty = Double.Parse(qty2TextBox.Text);
            Mjuice_qty = Double.Parse(qty3TextBox.Text);

            unitprice1 = Double.Parse(unitPrice1TextBox.Text);
            unitprice2 = Double.Parse(unitPrice2TextBox.Text);
            unitprice3 = Double.Parse(unitPrice3TextBox.Text);

            orangeJuice = (Ojuice_qty * unitprice1);
            appleJuice = (Ajuice_qty * unitprice2);
            mangoJuice = (Mjuice_qty * unitprice3);

            subTotal1TextBox.Text = orangeJuice.ToString();
            subTotal2TextBox.Text = appleJuice.ToString();
            subTotal3TextBox.Text = mangoJuice.ToString();


            // Calculating values
            
            netTax = ( (orangeJuice + appleJuice + mangoJuice) * TAX ) / 100;

            taxTextBox.Text = Convert.ToString(netTax);
            netSubTotalTextBox.Text = Convert.ToString(orangeJuice + appleJuice + mangoJuice);
            netTotalTextBox.Text = Convert.ToString(netTax + (orangeJuice + appleJuice + mangoJuice));
            


            
            //subTotal = Convert.ToDouble(subTotal1TextBox.Text) + Convert.ToDouble(subTotal2TextBox.Text) + Convert.ToDouble(subTotal3TextBox.Text);
            //netSubTotalTextBox.Text = subTotal.ToString();

            //netTotal = subTotal - netTax;
            //netTotalTextBox.Text = netTotal.ToString();
            
            
            
            // Adding Pound symbol in  following text boxes

            unitPrice1TextBox.Text = string.Format("{0:C}", double.Parse(unitPrice1TextBox.Text));
            unitPrice2TextBox.Text = string.Format("{0:C}", double.Parse(unitPrice2TextBox.Text));
            unitPrice3TextBox.Text = string.Format("{0:C}", double.Parse(unitPrice3TextBox.Text));

            subTotal1TextBox.Text = string.Format("{0:C}", double.Parse(subTotal1TextBox.Text));
            subTotal2TextBox.Text = string.Format("{0:C}", double.Parse(subTotal2TextBox.Text));
            subTotal3TextBox.Text = string.Format("{0:C}", double.Parse(subTotal3TextBox.Text));

            taxTextBox.Text = string.Format("{0:C}", double.Parse(taxTextBox.Text));
            netSubTotalTextBox.Text = string.Format("{0:C}", double.Parse(netSubTotalTextBox.Text));
            netTotalTextBox.Text = string.Format("{0:C}", double.Parse(netTotalTextBox.Text));
        }


        

        

        

      

      
       

       

        
    }
}

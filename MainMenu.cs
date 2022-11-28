using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WaterBillingSystem
{
    public partial class MainMenu : Form
    {


        public MainMenu()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            int PW = Convert.ToInt32(txtPWaterUsed.Text);
            int P_BILL, W_BILL, Total;
            string VAT = "14";

            if (txtUserType.Text == "domestic")
            {
                if (PW <= 5)
                {
                    P_BILL = (int)(PW * 3.60);
                    W_BILL = (int)(PW * 0.65);
                    Total = P_BILL + W_BILL;
                }
                else if (PW > 5 && PW <= 15)
                {
                    P_BILL = (int)((5 * 3.60) + (PW - 5) * 13.43);
                    W_BILL = (int)((5 * 0.65) + (PW - 5) * 3.36);
                    Total = P_BILL + W_BILL;

                }
                else if (PW > 15 && PW <= 25)
                {
                    P_BILL = (int)((5 * 3.60) + (PW - 5) * 23.51);
                    W_BILL = (int)((5 * 0.65) + (PW - 5) * 5.03);
                    Total = P_BILL + W_BILL;

                }
                else if (PW > 25 && PW <= 40)
                {
                    P_BILL = (int)((5 * 3.60) + (PW - 5) * 36.16);
                    W_BILL = (int)((5 * 0.65) + (PW - 5) * 6.71);
                    Total = P_BILL + W_BILL;

                }
                else
                {
                    P_BILL = (int)((5 * 3.60) + (PW - 5) * 45.21);
                    W_BILL = (int)((5 * 0.65) + (PW - 5) * 8.39);
                    Total = P_BILL + W_BILL;

                }
                MessageBox.Show("Name:" + txtFname.Text + txtSname.Text + "   " + "Plot No.:" + txtPnum.Text + "\n" + "Portable Water Used:" + txtPWaterUsed.Text + "\n" + "Portable Water Cost:" + Convert.ToString(P_BILL) + "\n" + "Waste Water Cost:" + Convert.ToString(W_BILL) + "\n" + "VAT:" + VAT + "\n" + "Total:" + Convert.ToString(Total));
                StreamWriter Log = new StreamWriter("WaterBilling.txt", true);// saves ldetails of login in file

                Log.Write("Name:" + txtFname.Text + txtSname.Text + "#" + "Plot No.:" + txtPnum.Text + "#" + "Portable Water Used:" + txtPWaterUsed.Text + "#" + "Portable Water Cost:" + Convert.ToString(P_BILL) + "#" + "Waste Water Cost:" + Convert.ToString(W_BILL) + "#" + "VAT:" + VAT + "#" + "Total Billing:" + Convert.ToString(Total)+"#");
                Log.Close();
            }
            if (txtUserType.Text == "business" || txtUserType.Text == "comercial" || txtUserType.Text == "industrial")
            {
                if (PW <= 5)
                {
                    P_BILL = (int)(PW * 4.92);
                    W_BILL = (int)(PW * 0.74);
                    Total = P_BILL + W_BILL;

                }
                else if (PW > 5 && PW <= 15)
                {
                    P_BILL = (int)((5 * 3.60) + (PW - 5) * 14.16);
                    W_BILL = (int)((5 * 0.65) + (PW - 5) * 3.36);
                    Total = P_BILL + W_BILL;

                }
                else if (PW > 15 && PW <= 25)
                {

                    P_BILL = (int)((PW * 3.60) + (PW - 5) * 25.58);
                    W_BILL = (int)((PW * 0.65) + (PW - 5) * 5.03);
                    Total = P_BILL + W_BILL;

                }
                else if (PW > 25 && PW <= 40)
                {
                    P_BILL = (int)((PW * 3.60) + (PW - 5) * 39.35);
                    W_BILL = (int)((PW * 0.65) + (PW - 5) * 6.71);
                    Total = P_BILL + W_BILL;

                }
                else
                {
                    P_BILL = (int)((5 * 3.60) + (PW - 5) * 49.20);
                    W_BILL = (int)((5 * 0.65) + (PW - 5) * 8.39);
                    Total = P_BILL + W_BILL;

                }

                MessageBox.Show("Name:" + txtFname.Text + txtSname.Text + "   " + "Plot No.:" + txtPnum.Text + "\n" + "Portable Water Used:" + txtPWaterUsed.Text + "\n" + "Portable Water Cost:" + Convert.ToString(P_BILL) + "\n" + "Waste Water Cost:"+Convert.ToString(W_BILL)+ "\n"+ "VAT:"+ VAT +"\n" +"Total:" + Convert.ToString(Total));
                StreamWriter Log = new StreamWriter("WaterBilling.txt", true);// saves ldetails of login in file

                Log.Write("Name:" + txtFname.Text + txtSname.Text + "#" + "Plot No.:" + txtPnum.Text + "#" + "Portable Water Used:" + txtPWaterUsed.Text + "#" + "Portable Water Cost:" + Convert.ToString(P_BILL) + "#" + "Waste Water Cost:" + Convert.ToString(W_BILL) + "#" + "VAT:" + VAT + "#" + "Total:" + Convert.ToString(Total)+"#");
                Log.Close();
            }
           
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Hide();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            System.IO.StreamReader file = new System.IO.StreamReader("WaterBilling.txt");
            string[] columnnames = file.ReadLine().Split('#');
            DataTable dt = new DataTable();
            foreach (string c in columnnames)
            {
                dt.Columns.Add(c);
            }
            string newline;
            while ((newline = file.ReadLine()) != null)
            {
                DataRow dr = dt.NewRow();
                string[] values = newline.Split(' ');
                for (int i = 0; i < values.Length; i++)
                {
                    dr[i] = values[i];
                }
                dt.Rows.Add(dr);
            }
            file.Close();
            dataGridView1.DataSource = dt;
        }

        private void label1_Click(object sender, EventArgs e)
        {
            panel1.BackColor = Color.FromArgb(100,0,0,0);
        }
    }
}


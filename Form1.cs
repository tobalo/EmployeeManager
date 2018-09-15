using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Data.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Employee_Phase2_Windows_CristobalTorres_CooperCarlson
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            // TODO: This line of code loads data into the 'employeeeDataSet.Employee' table. You can move, or remove it, as needed.
            this.employeeTableAdapter.Fill(this.employeeeDataSet.Employee);
            

            button2.Hide();
            button3.Hide();
            button4.Hide();
                                                
        }

        private void button1_Click(object sender, EventArgs e)
        {
            
            button2.Show();
            button3.Show();
            button4.Show();

        }

        private void button3_Click(object sender, EventArgs e)
        {
            try
            {
                this.Validate();
                this.employeeBindingSource.EndEdit();
                this.employeeTableAdapter.Update(employeeeDataSet.Employee);
                MessageBox.Show("Update succesful!");
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {            
            MessageBox.Show("Hello");
        }       

        private void button2_Click(object sender, EventArgs e)
        {
            try
            {                
                EmployeeeDataSet.EmployeeRow newEmploy = employeeeDataSet.Employee.NewEmployeeRow();
                

                int ID;
                int payMonth;

                if (int.TryParse(textBox1.Text, out ID))
                {
                    newEmploy.EmployeeID = ID;

                    if (int.TryParse(textBox5.Text, out payMonth))
                    {
                        newEmploy.Name = textBox2.Text;
                        newEmploy.PhoneNumber = textBox3.Text;
                        newEmploy.RoomNumber = textBox4.Text;
                        newEmploy.PaymentMonth = textBox6.Text;
                        newEmploy.PayMonths = payMonth;
                        try
                        {
                            employeeeDataSet.Employee.Rows.Add(newEmploy);
                            employeeeDataSet.Employee.AcceptChanges();
                            this.employeeBindingSource.EndEdit();
                            if (dataGridView1.BindingContext[employeeeDataSet.Employee] != null)
                            {
                                dataGridView1.BindingContext[employeeeDataSet.Employee].EndCurrentEdit();
                            }
                            this.employeeTableAdapter.Adapter.AcceptChangesDuringUpdate = true;
                            this.employeeTableAdapter.Update(employeeeDataSet.Employee);

                        }
                        catch (Exception ex)
                        {
                            MessageBox.Show(ex.Message);
                        }
                        textBox1.Clear();
                        textBox2.Clear();
                        textBox3.Clear();
                        textBox4.Clear();
                        textBox5.Clear();
                        textBox6.Clear();
                    }
                    else
                    {
                        MessageBox.Show("Pay months must be an integer value");
                    }
                }
                else
                {
                    MessageBox.Show("Invalid input for employee ID. Integer values only.");
                }
            }
            catch (Exception ex)
            {

                MessageBox.Show(ex.Message);
            }
        }

        private void button4_Click(object sender, EventArgs e)
        {
            //this.employeeTableAdapter.Delete(employeeIDDataGridViewTextBoxColumn.Selected);
            /*int selectedRow = dataGridView1.SelectedRows.Count;
            try
            {
                if (selectedRow > 0)
                {
                    selectedRow = dataGridView1.CurrentCell.RowIndex;
                    var rowrow = employeeeDataSet.Tables[0].Rows[selectedRow];
                    this.employeeTableAdapter.Delete(selectedRow);
                }
            }
            catch (Exception ex)
            {

                MessageBox.Show(ex.Message);
            }*/                        
        }
    }
}

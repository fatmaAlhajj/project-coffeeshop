using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;
namespace project_Coffee_Shop
{
    public partial class Form2 : Form
    {
        public Form2()
        {
            InitializeComponent();
        }
        void header()
        {
            dgv1.Columns[0].HeaderText = "ID";
            dgv1.Columns[1].HeaderText = "Coffee Name";
            dgv1.Columns[2].HeaderText = " Type";
            dgv1.Columns[3].HeaderText = "Quantity ";
            dgv1.Columns[4].HeaderText = "Price ";
            dgv1.Columns[5].HeaderText = "Total amount";
        }  
        
                void fill_dgv(DataGridView dgv)
        {
            String conString = @"Data Source = DESKTOP-J5SMBM4; Initial Catalog =coffee_shop; Integrated Security = True";
            SqlConnection con = new SqlConnection(conString);
            String sql = "select * from coffee";
            SqlDataAdapter sda = new SqlDataAdapter(sql, con);
            DataSet sd = new DataSet();
         
            try
            {
                con.Open();
                sda.Fill(sd);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            finally
            {
                con.Close();
            }
        }
   
        private void button1_Click(object sender, EventArgs e)
        {
            if (textBox1.Text != "" && comboBox1.Text != "" && comboBox2.Text != "" && textBox2.Text != "" && textBox3.Text != "" && textBox4.Text !="" ) 
            {
                String conString = @"Data Source = DESKTOP-J5SMBM4; Initial Catalog= coffee_shop; Integrated Security=True";
                SqlConnection con = new SqlConnection(conString);
                String sql = "INSERT INTO  coffee(ID,CoffeeName,Type,Quantity,Price,Total amount) VALUES (@1,@2,@3,@4,@5,@6)";
                SqlCommand cmd = new SqlCommand(sql, con);
                cmd.Parameters.AddWithValue("@1", Convert.ToInt32(textBox1.Text));
                cmd.Parameters.AddWithValue("@2",comboBox1.Text);
                cmd.Parameters.AddWithValue("@3", comboBox2.Text);
                cmd.Parameters.AddWithValue("@4", textBox2.Text);
                cmd.Parameters.AddWithValue("@5", textBox3.Text);
                cmd.Parameters.AddWithValue("@6", textBox4.Text);
                try
                {
                    con.Open();
                    cmd.ExecuteNonQuery();
                    MessageBox.Show("Done", "information", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
                finally
                {
                    con.Close(); fill_dgv(dgv1);
                }
            
            else
            {
                MessageBox.Show("Enter valid data", "warnning", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }
    }

        private void Form2_Load(object sender, EventArgs e)
        {
            fill_dgv(dgv1);
            header();

        }
    }
}



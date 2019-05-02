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
namespace ProjectA
{
    public partial class advisors : Form
    {
        public advisors()
        {

            InitializeComponent();
            DatabaseConnection.getInstance().ConnectionString = "Data Source=HIBA\\SQLSERVER;Initial Catalog=ProjectA;Integrated Security=False;User ID=sa;Password=05feb1999;Connect Timeout=30;Encrypt=False;TrustServerCertificate=True;ApplicationIntent=ReadWrite;MultiSubnetFailover=False";
            
            String cmd = "Select Person.Id, FirstName , LastName,Designation,Salary ,Contact,Email,DateOfBirth ,Person.Gender  from Advisor JOIN Person ON Advisor.Id = Person.Id";
            var reader = DatabaseConnection.getInstance().getData(cmd);
            List<advisor> persons = new List<advisor>();
            while (reader.Read())
            {
                advisor pro = new advisor();
                pro.FirstName = reader.GetString(1);
                pro.LastName = reader.GetString(2);
                pro.Id = (int)reader.GetValue(0);
                pro.Email = reader.GetString(6);
                pro.Contact = reader.GetString(5);
                pro.DateOfBirth = (DateTime)reader.GetValue(7);
                pro.salary = Convert.ToDecimal(reader.GetValue(4));
                
                cmd = "Select Value from Lookup Where Id = (SELECT Designation FROM Advisor where Id = " + pro.Id + ")";



                SqlCommand a = new SqlCommand(cmd, DatabaseConnection.getInstance().getConnection());

                pro.designation = a.ExecuteScalar().ToString();

                cmd = "Select Value from Lookup Where Id = (SELECT Gender FROM Person where Id = " + pro.Id + ")";



                 a = new SqlCommand(cmd, DatabaseConnection.getInstance().getConnection());

                pro.Gender = a.ExecuteScalar().ToString();
                persons.Add(pro);
            }
            dataGridadd.DataSource = persons;
        }

        private void dataGridstudent_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            int id;
            if (e.ColumnIndex == 1)
            {
                id = (int)dataGridadd.Rows[e.RowIndex].Cells[2].Value;
                try
                {
                    String cmd = String.Format("DELETE FROM Advisor WHERE Id = '{0}'", id);
                    DatabaseConnection.getInstance().exectuteQuery(cmd);
                    cmd = String.Format("DELETE FROM Person WHERE Id = '{0}'", id);
                    DatabaseConnection.getInstance().exectuteQuery(cmd);

                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
            }
        }

        private void updateadd_Click(object sender, EventArgs e)
        {
            if (dataGridadd.SelectedCells.Count != 0)
            {


                int rw = dataGridadd.SelectedCells[0].RowIndex;
                int id = (int)dataGridadd.Rows[rw].Cells["Id"].Value;
                addadvics se = new addadvics(id);
                this.Hide();
                se.Show();

            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            addadvics f = new addadvics();
            this.Hide();
            f.Show();
        }

        private void deladd_Click(object sender, EventArgs e)
        {
            if (dataGridadd.SelectedCells.Count != 0)
            {
                int rw = dataGridadd.SelectedCells[0].RowIndex;
                string cmd = string.Format("DELETE FROM Advisor where Id = '{0}'", dataGridadd.Rows[rw].Cells["Id"].Value.ToString());
                SqlCommand del = new SqlCommand(cmd, DatabaseConnection.getInstance().getConnection());
                int count = del.ExecuteNonQuery();
                advisors s = new advisors();
                this.Hide();
                s.Show();
            }
        }

        private void tableLayoutPanel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void tableLayoutPanel2_Paint(object sender, PaintEventArgs e)
        {

        }

        private void tableLayoutPanel3_Paint(object sender, PaintEventArgs e)
        {

        }

        private void back1_Click(object sender, EventArgs e)
        {
            adv s = new adv();
            this.Hide();
            s.Show();
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }
    }
}

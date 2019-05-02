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
    public partial class students : Form
    {
        public students()
        {
            InitializeComponent();
            DatabaseConnection.getInstance().ConnectionString = "Data Source=HIBA\\SQLSERVER;Initial Catalog=ProjectA;Integrated Security=False;User ID=sa;Password=05feb1999;Connect Timeout=30;Encrypt=False;TrustServerCertificate=True;ApplicationIntent=ReadWrite;MultiSubnetFailover=False";

            String cmd = "Select Person.Id, FirstName , LastName,RegistrationNo,Contact,Email,DateOfBirth ,Gender  from Person JOIN student ON Student.Id = Person.Id";
            var reader = DatabaseConnection.getInstance().getData(cmd);

            List<Student> persons = new List<Student>();
            while (reader.Read())
            {
                Student pro = new Student();
                pro.FirstName = reader.GetString(1);
                pro.LastName = reader.GetString(2);
                pro.Id = (int)reader.GetValue(0);
                pro.Email = reader.GetString(5);
                pro.Contact = reader.GetString(4);
                pro.DateOfBirth = (DateTime)reader.GetValue(6);
                pro.RegistrationNumber = reader.GetString(3);
                cmd = "Select Value from Lookup Where Id = (SELECT Gender FROM Person where Id = " + (int)reader.GetValue(0) + ")";
          

                
                SqlCommand a = new SqlCommand(cmd, DatabaseConnection.getInstance().getConnection());

                pro.Gender = a.ExecuteScalar().ToString();
                persons.Add(pro);
            }
            
            dataGridstudent.DataSource = persons;
            

        }

        private void students_Load(object sender, EventArgs e)
        {

        }
        private void datagridstudent_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            int id;
            if (e.ColumnIndex == 1)
            {
                id = (int)dataGridstudent.Rows[e.RowIndex].Cells[2].Value;
                try
                {
                    String cmd = String.Format("DELETE FROM Student WHERE Id = '{0}'", id);
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

        private void updatestu_Click(object sender, EventArgs e)
        {
            if (dataGridstudent.SelectedCells.Count != 0)
            {


                int rw = dataGridstudent.SelectedCells[0].RowIndex;
                int id = (int)dataGridstudent.Rows[rw].Cells["Id"].Value;
                addstudent se = new addstudent(id);

                this.Hide();
                se.Show();
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            addstudent f = new addstudent();
            this.Hide();
            f.Show();
        }

        private void delstu_Click(object sender, EventArgs e)
        {
            if(dataGridstudent.SelectedCells.Count != 0)
            {
                int rw = dataGridstudent.SelectedCells[0].RowIndex;
                string cmd = string.Format("DELETE FROM Student where Id = '{0}'", dataGridstudent.Rows[rw].Cells["Id"].Value.ToString());
                SqlCommand del = new SqlCommand(cmd, DatabaseConnection.getInstance().getConnection());
                int count = del.ExecuteNonQuery();
                students s = new students();
                this.Hide();
                s.Show();
            }
            
        }

        private void dataGridstudent_CellContentClick_1(object sender, DataGridViewCellEventArgs e)
        {

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
            std s = new std();
            this.Hide();
            s.Show();
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }
    }
}

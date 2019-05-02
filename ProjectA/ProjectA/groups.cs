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
    public partial class groups : Form
    {
        int ide;
        public groups()
        {
            InitializeComponent();
        }
        public groups(int i)
        {
            InitializeComponent();
            DatabaseConnection.getInstance().ConnectionString = "Data Source=HIBA\\SQLSERVER;Initial Catalog=ProjectA;Integrated Security=False;User ID=sa;Password=05feb1999;Connect Timeout=30;Encrypt=False;TrustServerCertificate=True;ApplicationIntent=ReadWrite;MultiSubnetFailover=False";

            ide = i;
            DataTable dt = new DataTable();
            String cmd = String.Format("Select FirstName+ ' ' +LastName as[Name], RegistrationNo from Student Join Person ON Student.Id = Person.ID  Where (Student.Id IN (SELECT StudentId FROM GroupStudent Where GroupID = '{0}'))", i);

            SqlDataAdapter adpt = new SqlDataAdapter(cmd, DatabaseConnection.getInstance().getConnection());
            adpt.Fill(dt);
            dataGridadd.DataSource = dt;


        }
        private void groups_Load(object sender, EventArgs e)
        {

        }

        private void dataGridadd_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void deladd_Click(object sender, EventArgs e)
        {
            if (dataGridadd.SelectedCells.Count != 0)
            {
                int rw = dataGridadd.SelectedCells[0].RowIndex;

                String cmd = String.Format("Select Id from Lookup  Where Value = 'Active'");
                SqlCommand a = new SqlCommand(cmd, DatabaseConnection.getInstance().getConnection());
                int st;
                st = (Int32)a.ExecuteScalar();
                cmd = String.Format("Select Person.Id From Person where FirstName + ' ' +LastName ='{0}' ", dataGridadd.Rows[rw].Cells["Name"].Value.ToString());
                a = new SqlCommand(cmd, DatabaseConnection.getInstance().getConnection());
                int id;
                id = (Int32)a.ExecuteScalar();
                cmd = string.Format("UPDATE GroupStudent SET Status = '{1}'  where StudentId = '{0}'",id ,st);
                SqlCommand del = new SqlCommand(cmd, DatabaseConnection.getInstance().getConnection());
                int count = del.ExecuteNonQuery();
                groups  p = new groups();
                this.Hide();
                p.Show();
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            grp g = new grp();
            this.Hide();
            g.Show();
        }
    }
}

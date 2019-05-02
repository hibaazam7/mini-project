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
    public partial class projects : Form
    {
        public projects()
        {
            InitializeComponent();
            DatabaseConnection.getInstance().ConnectionString = "Data Source=HIBA\\SQLSERVER;Initial Catalog=ProjectA;Integrated Security=False;User ID=sa;Password=05feb1999;Connect Timeout=30;Encrypt=False;TrustServerCertificate=True;ApplicationIntent=ReadWrite;MultiSubnetFailover=False";

            String cmd = "Select Id, Title , Description from Project";
            var reader = DatabaseConnection.getInstance().getData(cmd);
            List<Project> s = new List<Project>();
            while (reader.Read())
            {
                Project pro = new Project();
                pro.Id = (int)reader.GetValue(0);
                pro.title = reader.GetString(1);
               
                pro.description = reader.GetString(2);
                s.Add(pro);
            }
            dataGridadd.DataSource = s;
        }

        private void updateadd_Click(object sender, EventArgs e)
        {
            if (dataGridadd.SelectedCells.Count != 0)
            {


                int rw = dataGridadd.SelectedCells[0].RowIndex;
                int id = (int)dataGridadd.Rows[rw].Cells["Id"].Value;
                addproject se = new addproject(id);

                this.Hide();
                se.Show();
            }
        }

        private void deladd_Click(object sender, EventArgs e)
        {
            if (dataGridadd.SelectedCells.Count != 0)
            {
                int rw = dataGridadd.SelectedCells[0].RowIndex;
                string cmd = string.Format("DELETE FROM Project where Id = '{0}'", dataGridadd.Rows[rw].Cells["Id"].Value.ToString());
                SqlCommand del = new SqlCommand(cmd, DatabaseConnection.getInstance().getConnection());
                int count = del.ExecuteNonQuery();
                projects p = new projects();
                this.Hide();
                p.Show();
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            addproject f = new addproject();
            this.Hide();
            f.Show();
        }

        private void back1_Click(object sender, EventArgs e)
        {
            Manage_Project s = new Manage_Project();
            this.Hide();
            s.Show();
        }
    }
}

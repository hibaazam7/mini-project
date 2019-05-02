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
    public partial class Advisos : Form
    {
        public Advisos()
        {
            InitializeComponent();
            DatabaseConnection.getInstance().ConnectionString = "Data Source=HIBA\\SQLSERVER;Initial Catalog=ProjectA;Integrated Security=False;User ID=sa;Password=05feb1999;Connect Timeout=30;Encrypt=False;TrustServerCertificate=True;ApplicationIntent=ReadWrite;MultiSubnetFailover=False";

            DataTable dt = new DataTable();
            String cmd = String.Format("Select Title, FirstName+' ' +LastName As Advisor from Advisor Join Person ON Person.Id = Advisor.ID  Join ProjectAdvisor on ProjectAdvisor.AdvisorId = Advisor.Id JOIN Project ON Project.Id=ProjectAdvisor.ProjectId ");

            SqlDataAdapter adpt = new SqlDataAdapter(cmd, DatabaseConnection.getInstance().getConnection());
            adpt.Fill(dt);
            dataGridstudent.DataSource = dt;
        }

        private void delstu_Click(object sender, EventArgs e)
        {
            if (dataGridstudent.SelectedCells.Count != 0)
            {
                int rw = dataGridstudent.SelectedCells[0].RowIndex;
                String cmd = String.Format("Delete from ProjectAdvisor  Where(ProjectId = (Select Id from Project Where Title = '{0}'))", dataGridstudent.Rows[rw].Cells["Title"].Value.ToString());
                SqlCommand del = new SqlCommand(cmd, DatabaseConnection.getInstance().getConnection());
                int count = del.ExecuteNonQuery();
                Advisos p = new Advisos();
                this.Hide();
                p.Show();
            }
        }
    }
}

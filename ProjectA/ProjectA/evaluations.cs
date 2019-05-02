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
    public partial class evaluations : Form
    {
        public evaluations()
        {
            InitializeComponent();
            DatabaseConnection.getInstance().ConnectionString = "Data Source=HIBA\\SQLSERVER;Initial Catalog=ProjectA;Integrated Security=False;User ID=sa;Password=05feb1999;Connect Timeout=30;Encrypt=False;TrustServerCertificate=True;ApplicationIntent=ReadWrite;MultiSubnetFailover=False";



            DataTable dt = new DataTable();
            String cmd = String.Format("Select Name as[Evaluation Name],Title as[Project Title],ObtainedMarks,TotalMarks,TotalWeightage from Evaluation Join GroupEvaluation ON Evaluation.Id = GroupEvaluation.EvaluationId  JOIN GroupProject ON GroupProject.GroupId = GroupEvaluation.GroupId Join Project ON Project.Id = GroupProject.ProjectId");

            SqlDataAdapter adpt = new SqlDataAdapter(cmd, DatabaseConnection.getInstance().getConnection());
            adpt.Fill(dt);
            dataGridstudent.DataSource = dt;


            
        }

        private void updatestu_Click(object sender, EventArgs e)
        {
            if (dataGridstudent.SelectedCells.Count != 0)
            {


                int rw = dataGridstudent.SelectedCells[0].RowIndex;
                String cmd = String.Format("Select Id from Evaluation  Where Name = '{0}'", dataGridstudent.Rows[rw].Cells["Evaluation Name"].Value.ToString());
                SqlCommand a = new SqlCommand(cmd, DatabaseConnection.getInstance().getConnection());
                int id;
                id = (Int32)a.ExecuteScalar();
                cmd = String.Format("Select GroupId from Project Join GroupProject On Project.Id = GroupProject.ProjectId  Where Title = '{0}'", dataGridstudent.Rows[rw].Cells["Project Title"].Value.ToString());
                a = new SqlCommand(cmd, DatabaseConnection.getInstance().getConnection());
                int idp;
                idp = (Int32)a.ExecuteScalar();
                addeval se = new addeval(id,idp);

                this.Hide();
                se.Show();
            }
        }

        private void delstu_Click(object sender, EventArgs e)
        {
            if (dataGridstudent.SelectedCells.Count != 0)
            {
                int rw = dataGridstudent.SelectedCells[0].RowIndex;
                String cmd = String.Format("Select Id from Evaluation  Where Name = '{0}'", dataGridstudent.Rows[rw].Cells["Evaluation Name"].Value.ToString());
                SqlCommand del = new SqlCommand(cmd, DatabaseConnection.getInstance().getConnection());
                int idp;
                idp = (Int32)del.ExecuteScalar();
                cmd = String.Format("delete from GroupEvaluation Where Evaluation.EvaluationId = '{0}'",idp);
                del = new SqlCommand(cmd, DatabaseConnection.getInstance().getConnection());
                int count = del.ExecuteNonQuery();
                evaluations p = new evaluations();
                this.Hide();
                p.Show();
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            addeval f = new addeval();
            this.Hide();
            f.Show();
        }

        private void back1_Click(object sender, EventArgs e)
        {
            evl s = new evl();
            this.Hide();
            s.Show();
        }
    }
}


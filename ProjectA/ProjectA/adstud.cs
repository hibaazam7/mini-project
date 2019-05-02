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
    public partial class adstud : Form
    {
        public adstud()
        {
            InitializeComponent();
            DatabaseConnection.getInstance().ConnectionString = "Data Source=HIBA\\SQLSERVER;Initial Catalog=ProjectA;Integrated Security=False;User ID=sa;Password=05feb1999;Connect Timeout=30;Encrypt=False;TrustServerCertificate=True;ApplicationIntent=ReadWrite;MultiSubnetFailover=False";
            String cmd = String.Format("SELECT FirstName +' '+ LastName as [Name]  FROM Student Join Person On (Person.Id = Student.Id) WHERE ( Student.Id NOT IN (SELECT StudentId From GroupStudent))");
            SqlDataReader reader = DatabaseConnection.getInstance().getData(cmd);
            while (reader.Read())
            {
                stucombo.Items.Add(reader["Name"].ToString());
            }
            cmd = String.Format("SELECT FirstName +' '+ LastName as [Name]  FROM Student Join Person On (Person.id = Student.id) WHERE ( Student.Id IN (SELECT StudentId From GroupStudent where (Status = (Select Id from Lookup where (Value = 'InActive')))))");
            reader = DatabaseConnection.getInstance().getData(cmd);
            while (reader.Read())
            {
                stucombo.Items.Add(reader["Name"].ToString());
            }
            cmd = String.Format("SELECT Title From GroupProject JOIN Project ON GroupProject.ProjectId = Project.Id ");
            reader = DatabaseConnection.getInstance().getData(cmd);
            while (reader.Read())
            {
                procombo.Items.Add(reader["Title"].ToString());
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {

            String cmd = String.Format("Select Id from Person  Where FirstName +' ' +LastName = '{0}'", stucombo.Text);
            SqlCommand a = new SqlCommand(cmd, DatabaseConnection.getInstance().getConnection());
            int stu;
            stu = (Int32)a.ExecuteScalar();
            cmd = String.Format("Select GroupProject.GroupId from Project Join GroupProject On PRoject.Id = GroupProject.ProjectId Where title = '{0}'", procombo.Text);
            a = new SqlCommand(cmd, DatabaseConnection.getInstance().getConnection());
            int pro;
            pro = (Int32)a.ExecuteScalar();
            cmd = String.Format("Select Id from Lookup  Where Value = 'Active'");
            a = new SqlCommand(cmd, DatabaseConnection.getInstance().getConnection());
            int st;
            st = (Int32)a.ExecuteScalar();
            cmd = String.Format("INSERT INTO GroupStudent(GroupId,StudentId,Status,AssignmentDate) values('{0}','{1}','{2}',GetDate() )",pro , stu,st);
            DatabaseConnection.getInstance().exectuteQuery(cmd);
            grp g = new grp();
            this.Hide();
            g.Show();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            grp g = new grp();
            this.Hide();
            g.Show();
        }
    }
}

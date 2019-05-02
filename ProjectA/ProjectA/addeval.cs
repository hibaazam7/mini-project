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
using System.Text.RegularExpressions;
namespace ProjectA
{
    public partial class addeval : Form
    {
        private int ide;
        public addeval()
        {
           
            InitializeComponent();
            adadd.Text = "ADD EVALUATION";
            saveupadd.Hide();
            DatabaseConnection.getInstance().ConnectionString = "Data Source=HIBA\\SQLSERVER;Initial Catalog=ProjectA;Integrated Security=False;User ID=sa;Password=05feb1999;Connect Timeout=30;Encrypt=False;TrustServerCertificate=True;ApplicationIntent=ReadWrite;MultiSubnetFailover=False";
            String cmd = String.Format("SELECT Title FROM Project WHERE ( Project.Id IN(SELECT ProjectId FROM GroupProject))");
            SqlDataReader reader = DatabaseConnection.getInstance().getData(cmd);
            while (reader.Read())
            {
                procombo.Items.Add(reader["Title"].ToString());
            }
        }
        public addeval(int id,int idp)
        {
            InitializeComponent();
            ide = id;
            adadd.Text = "EDIT EVALUATION";
            DatabaseConnection.getInstance().ConnectionString = "Data Source=HIBA\\SQLSERVER;Initial Catalog=ProjectA;Integrated Security=False;User ID=sa;Password=05feb1999;Connect Timeout=30;Encrypt=False;TrustServerCertificate=True;ApplicationIntent=ReadWrite;MultiSubnetFailover=False";
            String cmd = "SELECT Id, Name, TotalMarks, TotalWeightage FROM Evaluation WHERE Id = " + id.ToString();
            SqlDataReader reader = DatabaseConnection.getInstance().getData(cmd);
            Evaluation e = new Evaluation();
            while (reader.Read())
            {
                e.Id = (int)reader.GetValue(0);
                e.Name = reader.GetString(1);
                e.totalmarks = (int)reader.GetValue(2);
                e.weightage = (int)reader.GetValue(3);
            }
            nametext.Text = e.Name;
            tmrkstxt.Text = e.totalmarks.ToString();
            twttxt.Text = e.weightage.ToString();
            cmd = String.Format("SELECT ObtainedMarks FROM GroupEvaluation WHERE EvaluationId ='{0}'AND GroupId = '{1}' " , id.ToString(),idp.ToString());
            SqlCommand a = new SqlCommand(cmd, DatabaseConnection.getInstance().getConnection());
            int p;
           
            p = (Int32)a.ExecuteScalar();
            cmd = String.Format("SELECT Title FROM GroupProject Join Project On Project.Id = GroupProject.ProjectId WHERE GroupId = '{0}' ", idp.ToString());
            a = new SqlCommand(cmd, DatabaseConnection.getInstance().getConnection());
            String q;

            q = a.ExecuteScalar().ToString();

            procombo.Text = q;
            obttext.Text = p.ToString(); 
        }

        private void createbtn_Click(object sender, EventArgs e)
        {
            Evaluation evl = new Evaluation();
            Regexp(@"^[a-zA-Z]{1,100}", nametext, addnme, "name");
            Regexp(@"^[0-9]{1,20}", tmrkstxt, tmeks, "Contact");
            Regexp(@"^[0-9]{1,20}", obttext, obt, "Contact");
            Regexp(@"^[0-9]{1,20}", twttxt, twt, "Contact");
            if(Convert.ToInt32(obttext.Text) > Convert.ToInt32(tmrkstxt.Text))
            {
                MessageBox.Show("Obtain marks should be less than or equal to Total Marks");
                obttext.Clear();
            }
            else {
                evl.Name = nametext.Text;
                evl.totalmarks = Convert.ToInt32(tmrkstxt.Text);
                evl.weightage = Convert.ToInt32(twttxt.Text);
                String cmd = String.Format("INSERT INTO Evaluation(Name,TotalMarks,TotalWeightage) values('{0}','{1}','{2}' )", evl.Name, evl.totalmarks, evl.weightage);
                DatabaseConnection.getInstance().exectuteQuery(cmd);
                cmd = String.Format("SELECT GroupProject.GroupId FROM Project JOIN GroupProject On (Project.Id = GroupProject.ProjectId) WHERE (title = '{0}')", procombo.Text);
                SqlCommand a = new SqlCommand(cmd, DatabaseConnection.getInstance().getConnection());
                int id;
                id = (Int32)a.ExecuteScalar();
                cmd = String.Format("SELECT Max(Id) FROM Evaluation");
                a = new SqlCommand(cmd, DatabaseConnection.getInstance().getConnection());
                int ide;
                ide = (Int32)a.ExecuteScalar();

                cmd = String.Format("INSERT INTO GroupEvaluation(GroupId,EvaluationId,ObtainedMarks,EvaluationDate) values('{0}','{1}','{2}',GetDate() )", id, ide, obttext.Text);
                DatabaseConnection.getInstance().exectuteQuery(cmd);
                evaluations s = new evaluations();
                this.Hide();
                s.Show();
            }
            
        }
        public void Regexp(string re, TextBox tb, Label lbl, string s)
        {
            Regex regex = new Regex(re);
            if (regex.IsMatch(tb.Text))
            {
                lbl.Text = s + "valid";


            }
            else
            {
                lbl.Text = s + "Invalid";
            }
        }

        private void addeval_Load(object sender, EventArgs e)
        {

        }

        private void saveupadd_Click(object sender, EventArgs e)
        {
            Evaluation evl = new Evaluation();
            Regexp(@"^[a-zA-Z]{1,100}", nametext, addnme, "name");
            Regexp(@"^[0-9]{1,20}", tmrkstxt, tmeks, "Total Marks");
            Regexp(@"^[0-9]{1,20}", twttxt, twt, "Total Weightage");
            evl.Name = nametext.Text;
            evl.totalmarks = Convert.ToInt32(tmrkstxt.Text);
            evl.weightage = Convert.ToInt32(twttxt.Text);
            if (Convert.ToInt32(obttext.Text) > Convert.ToInt32(tmrkstxt.Text))
            {
                MessageBox.Show("Obtain marks should be less than or equal to Total Marks");
                obttext.Clear();
            }
            else
            {
                String cmd = String.Format("UPDATE Evaluation SET Name = '{0}' , TotalMarks = '{1}',TotalWeightage='{2}' WHERE Id ='{3}' ", evl.Name, evl.totalmarks, evl.weightage, ide);
                DatabaseConnection.getInstance().exectuteQuery(cmd);
                cmd = String.Format("SELECT GroupProject.GroupId FROM Project JOIN GroupProject On (Project.Id = GroupProject.ProjectId) WHERE (title = '{0}')", procombo.Text);
                SqlCommand a = new SqlCommand(cmd, DatabaseConnection.getInstance().getConnection());
                int id;
                id = (Int32)a.ExecuteScalar();

                cmd = String.Format("UPDATE  GroupEvaluation SET ObtainedMarks = '{0}',EvaluationDate = GetDate() WHERE EvaluationId = '{1}' AND GroupId= '{2}')", obttext.Text, ide, id );
                DatabaseConnection.getInstance().exectuteQuery(cmd);

                evaluations s = new evaluations();
                this.Hide();
                s.Show();
            }
           
        }
        evaluations s = new evaluations();
        private void button3_Click(object sender, EventArgs e)
        {
            s.Show();
            this.Hide();
        }

        private void back1_Click(object sender, EventArgs e)
        {
            evaluations s = new evaluations();
            this.Hide();
            s.Show();
        }

        private void menu1_Click(object sender, EventArgs e)
        {
            evl s = new evl();
            this.Hide();
            s.Show();

        }
    }
}

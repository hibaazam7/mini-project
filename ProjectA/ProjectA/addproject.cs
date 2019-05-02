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
    public partial class addproject : Form
    {
        private int ide;
        public addproject()
        {
            InitializeComponent();
            adadd.Text = "ADD PROJECT";
            saveupadd.Hide();
            DatabaseConnection.getInstance().ConnectionString = "Data Source=HIBA\\SQLSERVER;Initial Catalog=ProjectA;Integrated Security=False;User ID=sa;Password=05feb1999;Connect Timeout=30;Encrypt=False;TrustServerCertificate=True;ApplicationIntent=ReadWrite;MultiSubnetFailover=False";
            
        }
        public addproject(int id)
        {
            
            InitializeComponent();
            createbtn.Hide();
            ide = id;

            adadd.Text = "EDIT PROJECT";
            DatabaseConnection.getInstance().ConnectionString = "Data Source=HIBA\\SQLSERVER;Initial Catalog=ProjectA;Integrated Security=False;User ID=sa;Password=05feb1999;Connect Timeout=30;Encrypt=False;TrustServerCertificate=True;ApplicationIntent=ReadWrite;MultiSubnetFailover=False";

            
            String cmd = "SELECT Id, Title, Description FROM Project WHERE Id = " + id.ToString();
            SqlDataReader reader = DatabaseConnection.getInstance().getData(cmd);
            Project e = new Project();

            while (reader.Read())
            {
                e.Id = (int)reader.GetValue(0);
                e.title= reader.GetString(1);
                e.description = reader.GetString(2);
               
            }
            
            nametext.Text = e.title;
            desctxt.Text = e.description.ToString();
            
        }

        private void addproject_Load(object sender, EventArgs e)
        {

        }

        private void createbtn_Click(object sender, EventArgs e)
        {
            Project evl = new Project();
            Regexp(@"^[a-zA-Z]{1,100}", nametext, addnme, "name");
            Regexp(@"^[a-zA-Z]{1,100}", desctxt, desc, "name");
            evl.title = nametext.Text;
            evl.description = desctxt.Text;
            
            String cmd = String.Format("INSERT INTO Project(Title,Description) values('{0}','{1}' )", evl.title, evl.description);
            DatabaseConnection.getInstance().exectuteQuery(cmd);
            
            
            projects s = new projects();
            this.Hide();
            s.Show();

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

        private void saveupadd_Click(object sender, EventArgs e)
        {
            Project evl = new Project();
            Regexp(@"^[a-zA-Z]{1,100}", nametext, addnme, "name");
            Regexp(@"^[a-zA-Z]{1,100}", desctxt, desc, "name");
            evl.title = nametext.Text;
            evl.description = desctxt.Text;

            String cmd = String.Format("UPDATE Project SET Title = '{0}' , Description = '{1}' WHERE Id ='{2}' ", evl.title, evl.description, ide);
            DatabaseConnection.getInstance().exectuteQuery(cmd);
            
            projects p = new projects();
            this.Hide();
            p.Show();

        }

        private void menu1_Click(object sender, EventArgs e)
        {
            Manage_Project s = new Manage_Project();
            this.Hide();
            s.Show();
        }

        private void back1_Click(object sender, EventArgs e)
        {
            projects a = new projects();
            this.Hide();
            a.Show();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            projects a = new projects();
            this.Hide();
            a.Show();
        }
    }
}

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
    public partial class addadvics : Form
    {
        int ide;
        public addadvics()
        {
            InitializeComponent();
            saveupadd.Hide();
            adadd.Text = "ADD STUDENT";
            DatabaseConnection.getInstance().ConnectionString = "Data Source=HIBA\\SQLSERVER;Initial Catalog=ProjectA;Integrated Security=False;User ID=sa;Password=05feb1999;Connect Timeout=30;Encrypt=False;TrustServerCertificate=True;ApplicationIntent=ReadWrite;MultiSubnetFailover=False";
            String cmd = String.Format("SELECT Value FROM Lookup WHERE (Category = 'GENDER')");
            SqlDataReader reader = DatabaseConnection.getInstance().getData(cmd);
            while (reader.Read())
            {
                addgendercombo.Items.Add(reader["Value"].ToString());
            }
            cmd = String.Format("SELECT Value FROM Lookup WHERE (Category = 'DESIGNATION')");
            reader = DatabaseConnection.getInstance().getData(cmd);
            while (reader.Read())
            {
                degtext.Items.Add(reader["Value"].ToString());
            }
        }
        public addadvics(int id)
        {
            InitializeComponent();
            ide = id;
            createbtn.Hide();
            adadd.Text = "EDIT ADVISORS";
            DatabaseConnection.getInstance().ConnectionString = "Data Source=HIBA\\SQLSERVER;Initial Catalog=ProjectA;Integrated Security=False;User ID=sa;Password=05feb1999;Connect Timeout=30;Encrypt=False;TrustServerCertificate=True;ApplicationIntent=ReadWrite;MultiSubnetFailover=False";
            String cmd = String.Format("SELECT Value FROM Lookup WHERE (Category = 'GENDER')");
            SqlDataReader read = DatabaseConnection.getInstance().getData(cmd);
            while (read.Read())
            {
                addgendercombo.Items.Add(read["Value"].ToString());
            }
            cmd = "Select Value from Lookup Where Id = (SELECT Gender FROM Person where Id = " + id.ToString() + ")";
            var reader = DatabaseConnection.getInstance().getData(cmd);
            while (reader.Read())
            {
                addgendercombo.SelectedIndex = addgendercombo.Items.IndexOf(reader.GetString(0));
            }
            cmd = String.Format("SELECT Value FROM Lookup WHERE (Category = 'DESIGNATION')");
            reader = DatabaseConnection.getInstance().getData(cmd);
            while (reader.Read())
            {
                degtext.Items.Add(reader["Value"].ToString());
            }
            cmd = "Select Value from Lookup Where Id = (SELECT Designation FROM Advisor where Id = " + id.ToString() + ")";
            reader = DatabaseConnection.getInstance().getData(cmd);
            while (reader.Read())
            {
                degtext.SelectedIndex = degtext.Items.IndexOf (reader.GetString(0));
            }
            cmd = "SELECT Person.Id, FirstName, LastName, Contact, Email, DateOfBirth, Gender, Designation,Salary FROM Person JOIN Advisor ON Person.Id = Advisor.Id where Person.Id = " + id.ToString();
            reader = DatabaseConnection.getInstance().getData(cmd);
            advisor s = new advisor();
            while (reader.Read())
            {
                s.Id = (int)reader.GetValue(0);
                s.FirstName = reader.GetString(1);
                s.LastName = reader.GetString(2);
                s.Contact = reader.GetString(3);
                s.Email = reader.GetString(4);
                s.DateOfBirth = (DateTime)reader.GetValue(5);
                s.salary = Convert.ToDecimal(reader.GetValue(8));
            }
            addfnametext.Text = s.FirstName;
            addlnametext.Text = s.LastName;
            addcontacttxt.Text = s.Contact;
            addemailtext.Text = s.Email;
            addobtext.Value = (DateTime)s.DateOfBirth;
            addsaltext.Text = s.salary.ToString();
            
           
        }

        private void addadvics_Load(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            advisor p = new advisor();
            Regexp(@"^[a-zA-Z]{1,100}", addfnametext, addfnme, "First name");
            Regexp(@"^[a-zA-Z]{1,100}", addlnametext, addlnme, "Last name");
            Regexp(@"^[0-9]{1,20}", addcontacttxt, adcon, "Contact");
            Regexp(@"^([\\w\\.\\-]+)@([\\w\\-]+)((\\.(\\w){2,3})+)$", addemailtext, emailad, "Email");
            
            p.FirstName = addfnametext.Text;
            p.LastName = addlnametext.Text;
            p.Contact = addcontacttxt.Text;
            p.Email = addemailtext.Text;
            p.DateOfBirth = addobtext.Value;
            String cmd = String.Format("Select Id from Lookup Where Value = '{0}'", addgendercombo.Text);
            SqlCommand a = new SqlCommand(cmd, DatabaseConnection.getInstance().getConnection());
            int Gender;
            Gender = (Int32)a.ExecuteScalar();


            cmd = String.Format("INSERT INTO Person(FirstName,LastName,Contact,Email,DateOfBirth,Gender) values('{0}','{1}','{2}','{3}','{4}','{5}' )", p.FirstName, p.LastName, p.Contact, p.Email, p.DateOfBirth, Gender);
            DatabaseConnection.getInstance().exectuteQuery(cmd);

            cmd = "Select MAX(Id) from Person ";
            SqlDataReader reader = DatabaseConnection.getInstance().getData(cmd);
            int? id = null;
            while (reader.Read())
            {

                id = (int)reader.GetValue(0);
            }

            if (id != null)
            {
                p.salary = Convert.ToDecimal(addsaltext.Text);
                cmd = String.Format("Select Id from Lookup Where Value = '{0}'", degtext.Text);
                a = new SqlCommand(cmd, DatabaseConnection.getInstance().getConnection());
                int designation;
                designation = (Int32)a.ExecuteScalar();
                cmd = String.Format("Insert INTO Advisor(Id,Designation,Salary) values('{0}', '{1}','{2}')", id, designation, p.salary);
                DatabaseConnection.getInstance().exectuteQuery(cmd);
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

        private void tableLayoutPanel1_Paint(object sender, PaintEventArgs e)
        {

        }
        advisors s = new advisors();
        private void button3_Click(object sender, EventArgs e)
        {
            s.Show();
            this.Hide();
        }

        private void saveupadd_Click(object sender, EventArgs e)
        {
            advisor p = new advisor();
            Regexp(@"^[a-zA-Z]{1,100}", addfnametext, addfnme, "First name");
            Regexp(@"^[a-zA-Z]{1,100}", addlnametext, addlnme, "Last name");
            Regexp(@"^[0-9]{1,20}", addcontacttxt, adcon, "Contact");
            Regexp(@"^([\\w\\.\\-]+)@([\\w\\-]+)((\\.(\\w){2,3})+)$", addemailtext, emailad, "Email");
            Regexp(@"^[0-9]{1,30}", addsaltext, saladd, "Salary");
            p.FirstName = addfnametext.Text;
            p.LastName = addlnametext.Text;
            p.Contact = addcontacttxt.Text;
            p.Email = addemailtext.Text;
            p.DateOfBirth = addobtext.Value;
            p.salary = Convert.ToDecimal(addsaltext.Text);
            String cmd = String.Format("Select Id from Lookup Where Value = '{0}'", addgendercombo.Text);
            SqlCommand a = new SqlCommand(cmd, DatabaseConnection.getInstance().getConnection());
            int Gender;
            Gender = (Int32)a.ExecuteScalar();

            cmd = String.Format("Update Person SET FirstName = '{0}', LastName = '{1}', Contact = '{2}', Email = '{3}', DateOfBirth = '{4}', Gender = '{5}' WHERE Id = '{6}'", p.FirstName, p.LastName, p.Contact, p.Email, p.DateOfBirth, Gender, ide);
            DatabaseConnection.getInstance().exectuteQuery(cmd);
            cmd = String.Format("Select Id from Lookup Where Value = '{0}'", degtext.Text);
            a = new SqlCommand(cmd, DatabaseConnection.getInstance().getConnection());
            int designation;
            designation = (Int32)a.ExecuteScalar();

            cmd = String.Format("UPDATE Advisor SET Id = '{0}', Designation = '{1}', Salary = '{2}' WHERE Id = '{2}'", ide, designation,p.salary, ide);
            DatabaseConnection.getInstance().exectuteQuery(cmd);

            advisors s = new advisors();
            this.Hide();
            s.Show();
        }

        private void back1_Click(object sender, EventArgs e)
        {
            advisors s = new advisors();
            this.Hide();
            s.Show();
        }

        private void menu1_Click(object sender, EventArgs e)
        {
            adv a = new adv();
            this.Hide();
            a.Show();
        }
    }
}

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
    public partial class addstudent : Form
    {
        private int ide;
        public addstudent()
        {
            
            InitializeComponent();
            saveup.Hide();
            adstud.Text = "ADD STUDENT";
            DatabaseConnection.getInstance().ConnectionString = "Data Source=HIBA\\SQLSERVER;Initial Catalog=ProjectA;Integrated Security=False;User ID=sa;Password=05feb1999;Connect Timeout=30;Encrypt=False;TrustServerCertificate=True;ApplicationIntent=ReadWrite;MultiSubnetFailover=False";
            String cmd = String.Format("SELECT Value FROM Lookup WHERE (Category = 'GENDER')");
            SqlDataReader reader = DatabaseConnection.getInstance().getData(cmd);
            while (reader.Read())
            {
                stugendercombo.Items.Add(reader["Value"].ToString());
            }
        }
        public addstudent(int id)
        {
            InitializeComponent();
            ide = id;
            saveBtn.Hide();
            adstud.Text = "EDIT STUDENT";
            DatabaseConnection.getInstance().ConnectionString = "Data Source=HIBA\\SQLSERVER;Initial Catalog=ProjectA;Integrated Security=False;User ID=sa;Password=05feb1999;Connect Timeout=30;Encrypt=False;TrustServerCertificate=True;ApplicationIntent=ReadWrite;MultiSubnetFailover=False";
            String cmd = String.Format("SELECT Value FROM Lookup WHERE (Category = 'GENDER')");
            SqlDataReader read = DatabaseConnection.getInstance().getData(cmd);
            while (read.Read())
            {
                stugendercombo.Items.Add(read["Value"].ToString());
            }
            cmd = "Select Value from Lookup Where Id = (SELECT Gender FROM Person where Id = " + id.ToString() + ")";
            var reader = DatabaseConnection.getInstance().getData(cmd);
            while (reader.Read())
            {
                stugendercombo.SelectedIndex = stugendercombo.Items.IndexOf(reader.GetString(0));
            }
            cmd = "SELECT Person.Id, FirstName, LastName, Contact, Email, DateOfBirth, Gender, RegistrationNo FROM Person JOIN Student ON Person.Id = Student.Id where Person.Id = " + id.ToString();
            reader = DatabaseConnection.getInstance().getData(cmd);
            Student s = new Student();
          
            while (reader.Read())
            {
                s.Id = (int)reader.GetValue(0);
                s.FirstName = reader.GetString(1);
                s.LastName = reader.GetString(2);
                s.Contact = reader.GetString(3);
                s.Email = reader.GetString(4);
                s.DateOfBirth = (DateTime)reader.GetValue(5);
                
                s.RegistrationNumber = reader.GetString(7);
            }
            firstnameTxtBox.Text = s.FirstName;
            stulastnametext.Text = s.LastName;
            stucontacttext.Text = s.Contact;
            stuemailtext.Text = s.Email;
            regtext.Text = s.RegistrationNumber;
            dobstu.Value = (DateTime)s.DateOfBirth;
            cmd = String.Format("SELECT Value FROM Lookup JOIN Person ON Person.Gender = Lookup.Id WHERE (Person.Id = '"+ id+"')");
            SqlCommand a = new SqlCommand(cmd, DatabaseConnection.getInstance().getConnection());

            String gen = a.ExecuteScalar().ToString();
            
            stugendercombo.Text = gen;
        }

        private void saveBtn_Click(object sender, EventArgs e)
        {
            Student p = new Student();
            Regexp(@"^[a-zA-Z]{1,100}", firstnameTxtBox, stufName, "First name");
            Regexp(@"^[a-zA-Z]{1,100}", stulastnametext, lastnamestu, "Last name");
            Regexp(@"^[0-9]{1,20}", stucontacttext, stucontact, "Contact");
            Regexp(@"^([\\w\\.\\-]+)@([\\w\\-]+)((\\.(\\w){2,3})+)$", stuemailtext, stuemail, "Email");
            Regexp(@"^[0-9]{4}-[A-Z]{2,3}-[0-9]{1,3}$", regtext, label2, "Registration Number");
            p.FirstName = firstnameTxtBox.Text;
            p.LastName = stulastnametext.Text;
            p.Contact = stucontacttext.Text;
            p.Email = stuemailtext.Text;
            p.DateOfBirth = dobstu.Value;
            String cmd = String.Format("Select Id from Lookup Where Value = '{0}'", stugendercombo.Text);
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
                cmd = String.Format("Insert INTO Student(Id, RegistrationNo) values('{0}', '{1}')", id, regtext.Text);
                DatabaseConnection.getInstance().exectuteQuery(cmd);
            }
            firstnameTxtBox.Clear();
            stulastnametext.Clear();
            stucontacttext.Clear();
            regtext.Clear();
            stuemailtext.Clear();

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
        students s = new students();

        private void stulist_Click(object sender, EventArgs e)
        {
            s.Show();
            this.Hide();
        }

        private void saveup_Click(object sender, EventArgs e)
        {
            Student p = new Student();
            Regexp(@"^[a-zA-Z]{1,100}", firstnameTxtBox, stufName, "First name");
            Regexp(@"^[a-zA-Z]{1,100}", stulastnametext, lastnamestu, "Last name");
            Regexp(@"^[0-9]{1,20}", stucontacttext, stucontact, "Contact");
            Regexp(@"^([\\w\\.\\-]+)@([\\w\\-]+)((\\.(\\w){2,3})+)$", stuemailtext, stuemail, "Email");
            Regexp(@"^[0-9]{4}-[A-Z]{2,3}-[0-9]{1,3}$", regtext, label2, "Registration Number");
            p.FirstName = firstnameTxtBox.Text;
            p.LastName = stulastnametext.Text;
            p.Contact = stucontacttext.Text;
            p.Email = stuemailtext.Text;
            p.DateOfBirth = dobstu.Value;
            p.RegistrationNumber = regtext.Text;
            String cmd = String.Format("Select Id from Lookup Where Value = '{0}'", stugendercombo.Text);
            SqlCommand a = new SqlCommand(cmd, DatabaseConnection.getInstance().getConnection());
            int Gender;
            Gender = (Int32)a.ExecuteScalar();

            cmd = String.Format("Update Person SET FirstName = '{0}', LastName = '{1}', Contact = '{2}', Email = '{3}', DateOfBirth = '{4}', Gender = '{5}' WHERE Id = '{6}'", p.FirstName, p.LastName, p.Contact, p.Email, p.DateOfBirth, Gender, ide);
            DatabaseConnection.getInstance().exectuteQuery(cmd);
            cmd = String.Format("UPDATE Student SET Id = '{0}', RegistrationNo = '{1}' WHERE Id = '{2}'", ide, p.RegistrationNumber, ide);
            DatabaseConnection.getInstance().exectuteQuery(cmd);

            students s = new students();
            this.Hide();
            s.Show();
        }

        private void addstudent_Load(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {
            students s = new students();
            this.Hide();
            s.Show();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            std s = new std();
            this.Hide();
            s.Show();
        }
    }
}

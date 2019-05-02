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
    public partial class asad : Form
    {
        public asad()
        {
            InitializeComponent();
            DatabaseConnection.getInstance().ConnectionString = "Data Source=HIBA\\SQLSERVER;Initial Catalog=ProjectA;Integrated Security=False;User ID=sa;Password=05feb1999;Connect Timeout=30;Encrypt=False;TrustServerCertificate=True;ApplicationIntent=ReadWrite;MultiSubnetFailover=False";
            String cmd = String.Format("SELECT FirstName+LastName as [Name] FROM Advisor JOIN Person ON (Advisor.Id = Person.Id)");
            SqlDataReader reader = DatabaseConnection.getInstance().getData(cmd);
            while (reader.Read())
            {
                advcombo.Items.Add(reader["Name"].ToString());
            }
            cmd = String.Format("SELECT Value FROM Lookup WHERE (Category = 'ADVISOR_ROLE')");
            reader = DatabaseConnection.getInstance().getData(cmd);
            while (reader.Read())
            {
                advr.Items.Add(reader["Value"].ToString());
            }
            cmd = String.Format("SELECT Title FROM Project");
            reader = DatabaseConnection.getInstance().getData(cmd);
            while (reader.Read())
            {
                procombo.Items.Add(reader["Title"].ToString());
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            String cmd = String.Format("Select Id from [ProjectA].[dbo].[Project] WHERE [ProjectA].[dbo].[Project].Title = '{0}'", procombo.Text );
            SqlDataReader reader = DatabaseConnection.getInstance().getData(cmd);
            int? id = null;
            while (reader.Read())
            {

                id = (int)reader.GetValue(0);
            }
            cmd = String.Format("Select Advisor.Id from Advisor JOIN Person ON Advisor.Id = Person.Id Where FirstName + LastName = '{0}'", advcombo.Text);
            SqlCommand a = new SqlCommand(cmd, DatabaseConnection.getInstance().getConnection());
            int ad;
            ad = (Int32)a.ExecuteScalar();
            cmd = String.Format("Select Id from Lookup Where Value = '{0}'", advr.Text);
            a = new SqlCommand(cmd, DatabaseConnection.getInstance().getConnection());
            int advor;
            advor = (Int32)a.ExecuteScalar();


            cmd = String.Format("INSERT INTO ProjectAdvisor(AdvisorId,ProjectId,AdvisorRole,AssignmentDate) values('{0}','{1}','{2}',GetDate() )", ad, id, advor);
            DatabaseConnection.getInstance().exectuteQuery(cmd);
            Manage_Project m = new Manage_Project();
            this.Hide();
            m.Show();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Manage_Project m = new Manage_Project();
            this.Hide();
            m.Show();
        }
    }
}

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
    public partial class crestegrp : Form
    {
        public crestegrp()
        {
            InitializeComponent();
            DatabaseConnection.getInstance().ConnectionString = "Data Source=HIBA\\SQLSERVER;Initial Catalog=ProjectA;Integrated Security=False;User ID=sa;Password=05feb1999;Connect Timeout=30;Encrypt=False;TrustServerCertificate=True;ApplicationIntent=ReadWrite;MultiSubnetFailover=False";
            String cmd = String.Format("SELECT Title FROM Project WHERE ( Project.Id NOT IN(SELECT ProjectId FROM GroupProject))");
            SqlDataReader reader = DatabaseConnection.getInstance().getData(cmd);
            while (reader.Read())
            {
                procombo.Items.Add(reader["Title"].ToString());
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            String cmd = String.Format("INSERT INTO [ProjectA].[dbo].[Group] (Created_On) values(GetDate())");
            DatabaseConnection.getInstance().exectuteQuery(cmd);

            cmd = "Select MAX(Id) from [ProjectA].[dbo].[Group] ";
            SqlDataReader reader = DatabaseConnection.getInstance().getData(cmd);
            int? id = null;
            while (reader.Read())
            {

                id = (int)reader.GetValue(0);
            }
            cmd = String.Format("Select Project.Id from Project where title = '{0}'", procombo.Text);
            SqlCommand a = new SqlCommand(cmd, DatabaseConnection.getInstance().getConnection());
            int ad;
            ad = (Int32)a.ExecuteScalar();
            cmd = String.Format("INSERT INTO GroupProject(GroupId,ProjectId,AssignmentDate) values('{0}','{1}',GetDate() )", id, ad);
            DatabaseConnection.getInstance().exectuteQuery(cmd);
            grp p = new grp();
            this.Hide();
            p.Show();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            grp p = new grp();
            this.Hide();
            p.Show();
        }

        private void procombo_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void label2_Click(object sender, EventArgs e)
        {

        }
    }
}

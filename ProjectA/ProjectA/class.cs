using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjectA
{
    
    
    public partial class Student
    {
        public int Id { get; set; }
        public String FirstName
        {

            get; set;

        }
        public String LastName
        {

            get; set;
        }
        public String RegistrationNumber
        {
            get; set;
        }
        public String Contact
        {

            get; set;
        }

        public String Email
        {
            get; set;
        }
        public DateTime? DateOfBirth
        {
            get; set;
        }
        public string Gender
        {
            get; set;
        }
    }
    public partial class advisor 
    {
        public int Id { get; set; }
        public String FirstName
        {

            get; set;

        }
        public String LastName
        {

            get; set;
        }
        public String designation
        {
            get;set;
        }
        public decimal salary
        {
            get;set;
        }
        public String Contact
        {

            get; set;
        }

        public String Email
        {
            get; set;
        }
        public DateTime? DateOfBirth
        {
            get; set;
        }
        public string Gender
        {
            get; set;
        }
    }
    public partial class Evaluation
    {
        public int Id { get; set; }
        public String Name { get; set; }
        public int totalmarks { get; set; }
        public int weightage { get; set; }
    }
    public partial class Project
    {
        public int Id { get; set; }
        public string title { get; set; }
        public String description { get; set; }
    }
}

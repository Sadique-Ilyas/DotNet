using System.ComponentModel.DataAnnotations;

namespace CRUD_Web_App_using_ADO_.NET.Models
{
    public class Employee
    {
        public int EmployeeID { get; set; }
        [Required]
        public string LastName { get; set; }
        [Required]
        public string FirstName { get; set; }

        public Employee()
        {
        }

        public Employee(int employeeID, string lastName, string firstName)
        {
            EmployeeID = employeeID;
            LastName = lastName;
            FirstName = firstName;
        }
        //public string Title { get; set; }
        //public string TitleOfCourtesy { get; set; }
        //public DateTime BirthDate { get; set; }
        //public DateTime HireDate { get; set; }
        //public string Address { get; set; }
        //public string City { get; set; }
        //public string Region { get; set; }
        //public string PostalCode { get; set; }
        //public string Country { get; set; }
        //public string HomePhone { get; set; }
        //public string Extension { get; set; }
        //public byte[] Photo { get; set; }
        //public string Notes { get; set; }
        //public int ReportsTo { get; set; }
        //public string PhotoPath { get; set; }
    }
}

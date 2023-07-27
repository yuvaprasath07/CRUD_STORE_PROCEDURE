using System.ComponentModel.DataAnnotations;

namespace EntityDb
{
    public class EmployeeModel
    {
        [Key]
        public int EmployeID { get; set; }
        public string? EmployeName { get; set; }

        public int EmployeAge { get; set; }
        public int EmployeSalery { get; set; }

    }

    public class PostEmployee
    {
        [Key]
        public string? EmployeName { get; set; }

        public int EmployeAge { get; set; }
        public int EmployeSalery { get; set; }
    }

}
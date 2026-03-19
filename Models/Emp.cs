using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace API_Practice.Models
{
    public class Emp
    {
        [Key]
        public int eid { get; set; }

        public string ename { get; set; }

        public double esalary { get; set; }

        [ForeignKey("manager")]
        public int mid { get; set; }

        public Manager manager { get; set; }
    }
}

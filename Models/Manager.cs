using System.ComponentModel.DataAnnotations;

namespace API_Practice.Models
{
    public class Manager
    {
        [Key]
        public int mid { set; get; }

        public string mname { get; set; }

        public List<Emp> emp { get; set; }

    }
}

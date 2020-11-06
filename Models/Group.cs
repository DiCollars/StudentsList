using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace StudentsList.Models
{
    public class Group
    {
        [Key]
        public int Id { get; set; }

        public string GroupName { get; set; }

        public List<Student> Students { get; set; }
    }
}

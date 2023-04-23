using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace InternsMS.Models
{
    public class Intern
	{
		[Key]
		public int Id { get; set; }
		[Required]
		public string Name { get; set; }
		[Required]
        public string Email { get; set; }
		[Required]
		public string Phone { get; set; }
		[Required]
        [Column(TypeName = "date")]
        public DateTime BirthDate { get; set; }
		[Required]
		public Gender Gender { get; set; }
        [Required]
        public string Address { get; set; }
        [Required]
        public int InternshipId { get; set; }
        public Internship? Internship { get; set; }
        
        public virtual List<Assignment>? Assignments { get; set; }


    }
}

using System.ComponentModel.DataAnnotations;

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
		public DateTime BirthDate { get; set; }
		[Required]
		public string Gender { get; set; }
		[Required]
		public string Address { get; set; }
	}
}

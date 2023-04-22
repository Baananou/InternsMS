using System.ComponentModel.DataAnnotations;

namespace InternsMS.Models
{
	public class Supervisor
	{
		[Key]
		public int Id { get; set; }
		[Required]
		public string Name { get; set; }
		[Required]
		public string Email { get; set; }
		[Required]
		public string Phone { get; set; }
	}
}

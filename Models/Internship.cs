using System.ComponentModel.DataAnnotations;

namespace InternsMS.Models
{
	public class Internship
	{
		[Key]
		public int Id { get; set; }
		[Required]
		public string Title { get; set; }
		[Required]
		public DateTime StartDate { get; set; }
		[Required]
		public DateTime EndDate { get; set; }
		[Required]
		public string Location { get; set; }
		[Required]
		public string Description { get; set; }
	}
}

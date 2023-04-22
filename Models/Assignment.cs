using System.ComponentModel.DataAnnotations;

namespace InternsMS.Models
{
	public class Assignment
	{
		[Key]
		public int Id { get; set; }
		[Required]
		public string Title { get; set; }
		[Required]
		public string Description { get; set; }
		[Required]
		public DateTime Deadline { get; set; }
		[Required]
		public int InternshipId { get; set; }
		[Required]
		public Internship Internship { get; set; }
		[Required]
		public int SupervisorId { get; set; }
		[Required]
		public Supervisor Supervisor { get; set; }
	}
}

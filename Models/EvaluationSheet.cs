using System.ComponentModel.DataAnnotations;

namespace InternsMS.Models
{
	public class EvaluationSheet
	{
		[Key]
		public int Id { get; set; }
		[Required]
		public int InternId { get; set; }
		[Required]
		public Intern Intern { get; set; }
		[Required]
		public int AssignmentId { get; set; }
		[Required]
		public Assignment Assignment { get; set; }
		[Required]
		public int Score { get; set; }
		[Required]
		public string Comments { get; set; }
	}
}

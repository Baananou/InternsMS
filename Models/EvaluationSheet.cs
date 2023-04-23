using System.ComponentModel.DataAnnotations;

namespace InternsMS.Models
{
	public class EvaluationSheet
	{
		[Key]
		public int Id { get; set; }
		[Required]
		public int InternId { get; set; }
		public Intern? Intern { get; set; }
		[Required]
		public int AssignmentId { get; set; }
		public Assignment? Assignment { get; set; }
        [Required]
        public int SupervisorId { get; set; }
        public Supervisor? Supervisor { get; set; }
        [Required]
        [Range(typeof(decimal), "0.00", "20.00")]
        public decimal Score { get; set; }
		[Required]
		public string Comments { get; set; }
	}
}

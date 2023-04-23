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
        [EnsureEndDateAfterStartDate("StartDate")]
        public DateTime EndDate { get; set; }
		[Required]
		public string Location { get; set; }
		[Required]
		public string Description { get; set; }
        public List<Intern>? Interns { get; set; }

    }
    public class EnsureEndDateAfterStartDateAttribute : ValidationAttribute
    {
        private readonly string _startDatePropertyName;

        public EnsureEndDateAfterStartDateAttribute(string startDatePropertyName)
        {
            _startDatePropertyName = startDatePropertyName;
        }

        protected override ValidationResult IsValid(object value, ValidationContext validationContext)
        {
            var startDateProperty = validationContext.ObjectType.GetProperty(_startDatePropertyName);
            var startDate = (DateTime)startDateProperty.GetValue(validationContext.ObjectInstance);

            var endDate = (DateTime)value;

            if (endDate < startDate)
            {
                return new ValidationResult("The EndDate cannot be earlier than the StartDate.");
            }

            return ValidationResult.Success;
        }
    }
}

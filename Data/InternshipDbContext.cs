using InternsMS.Models;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace InternsMS.Data
{
	public class InternshipDbContext : IdentityDbContext
	{
		public InternshipDbContext(DbContextOptions<InternshipDbContext> options) : base(options)
		{
		}

		public DbSet<Supervisor> Supervisors { get; set; }
		public DbSet<Intern> Interns { get; set; }
		public DbSet<Internship> Internships { get; set; }
		public DbSet<Assignment> Assignments { get; set; }
		public DbSet<EvaluationSheet> EvaluationSheets { get; set; }
        public DbSet<ApplicationUser> ApplicationUsers { get; set; }

    }

}

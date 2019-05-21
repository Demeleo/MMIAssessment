using Microsoft.EntityFrameworkCore;

namespace MMIAssess.Infrastructure.Models
{
    public class MMIAssessDbContext: DbContext
    {
        public MMIAssessDbContext(DbContextOptions<MMIAssessDbContext> options) : base(options) 
        {

        }
    }
}

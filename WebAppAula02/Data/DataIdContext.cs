using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace WebAppAula02.Data
{
    public class DataIdContext : IdentityDbContext<IdentityUser>
    {
        public DataIdContext(DbContextOptions<DataIdContext> options) : base(options) { }

    }
}

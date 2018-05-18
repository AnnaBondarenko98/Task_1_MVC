using Microsoft.AspNet.Identity.EntityFramework;

namespace BlogAsp.Models.Identity
{
    public class ApplicationUserStore : UserStore<IdentityUser>
    {
        public ApplicationUserStore(IdentityDbContext context) : base(context)
        {
        }
    }
}

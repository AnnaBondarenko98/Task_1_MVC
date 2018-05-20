using Microsoft.AspNet.Identity;

namespace BlogAsp.Models.Identity
{
    public class ApplicationRoleManager : RoleManager<ApplicationRole>
    {
        public ApplicationRoleManager(IRoleStore<ApplicationRole, string> store) : base(store)
        { }
    }
}

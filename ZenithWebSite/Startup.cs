using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using Microsoft.Owin;
using Owin;
using ZenithDataLib;

[assembly: OwinStartupAttribute(typeof(ZenithWebSite.Startup))]
namespace ZenithWebSite
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
            createRolesandUsers();
        }

        private void createRolesandUsers()
        {
            ZenithDataLib.ApplicationDbContext context = new ZenithDataLib.ApplicationDbContext();

            var roleManager = new RoleManager<IdentityRole>(new RoleStore<IdentityRole>(context));
            var UserManager = new UserManager<ZenithDataLib.ApplicationUser>(new UserStore<ApplicationUser>(context));


            // In Startup iam creating first Admin Role and creating a default Admin User    
            if (!roleManager.RoleExists("Admin"))
            {

                // first we create Admin role   
                var role = new Microsoft.AspNet.Identity.EntityFramework.IdentityRole();
                role.Name = "Admin";
                roleManager.Create(role);

                //Here we create a Admin super user who will maintain the website                  

                var user = new ApplicationUser();
                user.UserName = "a";
                user.Email = "a@a.a";

                string userPWD = "P@$$w0rd";

                var chkUser = UserManager.Create(user, userPWD);

                //Add default User to Role Admin   
                if (chkUser.Succeeded)
                {
                    var result1 = UserManager.AddToRole(user.Id, "Admin");

                }
            }

            // creating Creating Member role    
            if (!roleManager.RoleExists("Member"))
            {
                var role = new Microsoft.AspNet.Identity.EntityFramework.IdentityRole();
                role.Name = "Member";
                roleManager.Create(role);

                var user = new ApplicationUser();
                user.UserName = "m";
                user.Email = "m@m.m";

                string userPWD = "P@$$w0rd";

                var chkUser = UserManager.Create(user, userPWD);

                //Add default User to Role member   
                if (chkUser.Succeeded)
                {
                    var result1 = UserManager.AddToRole(user.Id, "Member");

                }
            }
        }
    }
}

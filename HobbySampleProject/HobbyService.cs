namespace Hobby
{
    using RBAC.Security.Authorisation;
    using RBAC.Security.Context;
    using System.Diagnostics;
    using System.Xml.Linq;

    public class HobbyService
    {

        public HobbyService(SecurityContext context)
        {
            Context = context;
        }
        public void createHobby(string hobby)
        {
            if (!Context.IsUserInRole(["Player"])) return;

            Debug.WriteLine($"{Context.LoggedInUser.Name}: Creating a new hobby:  {hobby}");
            // Create a new hobby
        }

        public void deleteHobby(string hobby)
        {
            if (!Context.IsUserInRole(["Moderator", "Admin"])) return;


            Debug.WriteLine($"{Context.LoggedInUser.Name}: Deleting a hobby:  {hobby}");
            // Delete a hobby
        }

        public SecurityContext Context { get; set; }
    }
}

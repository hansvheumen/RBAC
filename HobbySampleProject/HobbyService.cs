namespace Hobby
{
    using RBAC.Security.Authorisation;
    using RBAC.Security.Context;
    using System.Diagnostics;
    using System.Xml.Linq;

    public class HobbyService(SecurityContext context)
    {
        public void CreateHobby(string hobby)
        {
            Debug.WriteLine("\n++++++++++++++++++++++++++++++");
            if (!Context.IsUserInRole(["Player"])) return;
            Debug.WriteLine($"{Context.LoggedInUser.Name}: Creating a new hobby:  {hobby}");
            // Create a new hobby
        }

        public void DeleteHobby(string hobby)
        {
            if (!Context.IsUserInRole(["Moderator", "Admin"])) return;

            Debug.WriteLine($"{Context.LoggedInUser.Name}: Deleting a hobby:  {hobby}");
            // Delete a hobby
        }

        public SecurityContext Context { get; } = context;
    }
}

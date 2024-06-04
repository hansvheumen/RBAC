namespace Hobby
{
    using RBAC.Security.Authorisation;
    using RBAC.Security.Context;
    using System.Diagnostics;

    public class HobbyService(SecurityContext context)
    {
        public void CreateHobby(string hobby)
        {
            Debug.WriteLine("\n++++++++++++++++++++++++++++++");
            if (!Context.IsUserInRole([new Role("Player")])) return;
            Debug.WriteLine($"{Context.LoggedInUser.Name}: Creating a new hobby:  {hobby}");
            // Create a new hobby
        }

        public void DeleteHobby(string hobby)
        {
            if (!Context.IsUserInRole([new Role("Moderator"), new Role("Admin")])) return;

            Debug.WriteLine($"{Context.LoggedInUser.Name}: Deleting a hobby:  {hobby}");
            // Delete a hobby
        }

        public SecurityContext Context { get; } = context;
    }
}

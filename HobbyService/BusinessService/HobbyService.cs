using HobbyBackend.BusinessService.Interfaces.DAL;
using HobbyBackend.services;
using RBAC.Security.Authorisation;
using RBAC.Security.Context;

namespace HobbyBackend.BusinessService
{
	public class HobbyService(IHobbyDAO hobbyDAO, SecurityContext context)
    {
        public IEnumerable<Hobby> GetHobbies()
        {
            return HobbyDAO.GetHobbies();
        }

        public void CreateHobby(Hobby hobby)
        {
            if (!Context.IsUserInRole([new Role("Player")])) throw new OperationNotAllowedException($"Creating of a Hobby not allowed: {hobby}");
            HobbyDAO.CreateHobby(hobby);
        }

        public void DeleteHobby(Hobby hobby)
        {
            if (!Context.IsUserInRole([new Role("Moderator"), new Role("Admin")])) throw new OperationNotAllowedException($"Deleting hobby not allowed:  {hobby}");
            HobbyDAO.DeleteHobby(hobby);
        }

        public SecurityContext Context { get; } = context;
        private IHobbyDAO HobbyDAO { get; } = hobbyDAO;
    }

    public record Hobby(string Name, string Description);
}
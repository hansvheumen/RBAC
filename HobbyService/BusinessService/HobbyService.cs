using RBAC.Security.Context;
using RBAC.Security.Authorisation;
using System.Collections.Immutable;
using HobbyBackend.services;
using HobbyBackend.BusinessService.Interfaces.DAL;

namespace HobbyBackend.BusinessService
{
    public class HobbyService(IHobbyDAO hobbyDAO, SecurityContext context)
    {
        public ImmutableList<Hobby> GetHobbies()
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
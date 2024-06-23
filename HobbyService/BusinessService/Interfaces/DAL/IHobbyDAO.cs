using System.Collections.Immutable;

namespace HobbyBackend.BusinessService.Interfaces.DAL
{
    public interface IHobbyDAO
    {
        void CreateHobby(Hobby hobby);
        void DeleteHobby(Hobby hobby);
        ImmutableList<Hobby> GetHobbies();
    }
}
using HobbyBackend.services;
using System.Collections.Immutable;

namespace HobbyBackend.DAL
{
	public interface IHobbyDAO
    {
        void CreateHobby(Hobby hobby);
        void DeleteHobby(Hobby hobby);
        ImmutableList<Hobby> GetHobbies();
    }
}
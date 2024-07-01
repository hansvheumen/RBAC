namespace HobbyBackend.BusinessService.Interfaces.DAL
{
	public interface IHobbyDAO
    {
        void CreateHobby(Hobby hobby);
        void DeleteHobby(Hobby hobby);
        IEnumerable<Hobby> GetHobbies();
    }
}
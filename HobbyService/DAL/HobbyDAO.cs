using HobbyBackend.BusinessService;
using HobbyBackend.BusinessService.Interfaces.DAL;

namespace HobbyBackend.DAL
{
	public class HobbyDAO() : IHobbyDAO
    {

        private static readonly Dictionary<string, Hobby> hobbies = new() {
                {"Swimming", new Hobby("Swimming", "Open water")},
                {"Walking", new Hobby("Walking", "Trail walking")},
                {"Biking", new Hobby("Biking", "Gravel")},
            };

        public IEnumerable<Hobby> GetHobbies()
        {
            return [.. hobbies.Values];
        }

        public void CreateHobby(Hobby hobby)
        {
     
            hobbies[hobby.Name] = hobby;
        }

        public void DeleteHobby(Hobby hobby)
        {
     
            hobbies.Remove(hobby.Name);
        }

     
    }

}
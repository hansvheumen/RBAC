using RBAC.Security.Context;
using RBAC.Security.Authorisation;
using System.Collections.Immutable;

namespace HobbyBackend.services
{
	public class HobbyService(SecurityContext context)
	{

		private static readonly Dictionary<string, Hobby> hobbies = new() {
				{"Swimming", new Hobby("Swimming", "Open water")},
				{"Walking", new Hobby("Walking", "Trail walking")},
				{"Biking", new Hobby("Biking", "Gravel")},
			};

		public ImmutableList<Hobby> GetHobbies()
		{
			return [.. hobbies.Values];
		}

		public void CreateHobby(Hobby hobby)
		{
			if (!Context.IsUserInRole([new Role("Player")])) throw new OperationNotAllowedException($"Creating of a Hobby not allowed: {hobby}");
			hobbies[hobby.Name] = hobby;
		}

		public void DeleteHobby(Hobby hobby)
		{
			if (!Context.IsUserInRole([new Role("Moderator"), new Role("Admin")])) throw new OperationNotAllowedException($"Deleting hobby not allowed:  {hobby}");
			hobbies.Remove(hobby.Name);
		}

		public SecurityContext Context { get; } = context;
	}

	public record Hobby(string Name, string Description);
}
using HobbyBackend.services;

namespace RazorCLient.Models
{
	public record HobbyDTO(string Name, string Description)
	{
		public HobbyDTO() : this("", "") { }
		public HobbyDTO(Hobby hobby) : this(hobby.Name, hobby.Description) { }

		public static implicit operator Hobby(HobbyDTO hobby) => new(hobby.Name, hobby.Description);
		public static implicit operator HobbyDTO(Hobby h) => new(h.Name, h.Description);

	}
}

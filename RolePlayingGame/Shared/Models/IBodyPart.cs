namespace RolePlayingGame.Shared.Models
{
	public interface IBodyPart
	{
		BodyPartStatus Status { get; }
		int Size { get; }
	}
}

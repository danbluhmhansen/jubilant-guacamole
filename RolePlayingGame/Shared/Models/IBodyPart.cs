namespace RolePlayingGame.Shared.Models
{
	public interface IBodyPart
	{
		BodyPartStatus Status { get; }
		double Size { get; }
	}
}

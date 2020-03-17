namespace RolePlayingGame.Shared.Models
{
	public interface IBodyPart
	{
		BodyPartStatus Status { get; protected set; }
		int Size { get; }

		void Damage()
		{
			Status += 1;
		}
	}
}

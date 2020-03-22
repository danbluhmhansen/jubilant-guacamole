namespace RolePlayingGame.Shared.Health
{
	using RolePlayingGame.Shared.Combat;

	public interface IBodyPart
	{
		string Name { get; }
		BodyPartStatus Status { get; }
		int Size { get; }
		int Toughness { get; }

		IBodyPart Damage(IAttack attack);
	}
}

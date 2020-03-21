using RolePlayingGame.Shared.Combat;

namespace RolePlayingGame.Shared.Health
{
	public interface IBodyPart
	{
		string Name { get; }
		BodyPartStatus Status { get; }
		int Size { get; }
		int Toughness { get; }

		void Damage (IAttack attack);
	}
}

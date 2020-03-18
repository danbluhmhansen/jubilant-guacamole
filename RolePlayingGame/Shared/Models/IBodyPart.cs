namespace RolePlayingGame.Shared.Models
{
	public interface IBodyPart
	{
		BodyPartStatus Status { get; protected set; }
		int Size { get; }
		int Toughness { get; }

		void Damage(IAttack attack)
		{
			var damageChance = RandomExtensions.Random.Next(attack.Damage);
			if (damageChance < Toughness)
				return;

			Status++;
		}
	}
}

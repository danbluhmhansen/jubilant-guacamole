namespace RolePlayingGame.Shared.Health
{
	using RolePlayingGame.Shared.Combat;

	public abstract class BaseBodyPart : IBodyPart
	{
		protected BaseBodyPart (string name, int size, int toughness, BodyPartStatus status = default)
		{
			Name = name;
			Size = size;
			Toughness = toughness;
			Status = status;
		}

		public string Name { get; }
		public virtual BodyPartStatus Status { get; protected set; }
		public int Size { get; }
		public int Toughness { get; }

		public void Damage (IAttack attack)
		{
			var damageChance = RandomExtensions.Random.Next (attack.Damage);
			if (damageChance < Toughness)
				return;

			Status++;
		}
	}
}

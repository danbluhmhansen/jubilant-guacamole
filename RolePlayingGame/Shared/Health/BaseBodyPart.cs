namespace RolePlayingGame.Shared.Health
{
	using RolePlayingGame.Shared.Combat;

	public abstract class BaseBodyPart : IBodyPart
	{
		protected BaseBodyPart(string name, int size, int toughness, BodyPartStatus status = default)
		{
			this.Name = name;
			this.Size = size;
			this.Toughness = toughness;
			this.Status = status;
		}

		public string Name { get; }
		public virtual BodyPartStatus Status { get; protected set; }
		public int Size { get; }
		public int Toughness { get; }

		public IBodyPart Damage(IAttack attack)
		{
			var damageChance = RandomExtensions.Random.Next(attack.Damage);
			if (damageChance < this.Toughness)
				return this;

			if (this.Status != BodyPartStatus.Destroyed)
				this.Status++;

			return this;
		}
	}
}

namespace RolePlayingGame.Shared.Health
{
	using System.Collections.Generic;
	using System.Linq;

	using RolePlayingGame.Shared.Combat;

	public abstract class BaseAppendage : IAppendage
	{
		protected BaseAppendage(string name, AppendageType type, int size, int toughness, BodyPartStatus status = default, IEnumerable<IInjury>? injuries = default)
		{
			this.Name = name;
			this.Type = type;
			this.Size = size;
			this.Toughness = toughness;
			this.Status = status;
			this.Injuries = injuries?.ToList() ?? new List<IInjury>();
		}

		public string Name { get; }
		public AppendageType Type { get; }
		public virtual BodyPartStatus Status { get; protected set; }
		public int Size { get; }
		public int Toughness { get; }

		public List<IInjury> Injuries { get; }

		public IAppendage Damage(IAttack attack)
		{
			var damageChance = RandomExtensions.Random.Next(attack.Damage.Amount);
			if (damageChance < this.Toughness)
				return this;

			if (this.Status != BodyPartStatus.Destroyed)
				this.Status++;

			return this;
		}
	}
}

namespace RolePlayingGame.Shared.Models
{
	using System;
	using System.Collections.Generic;
	using System.Linq;

	using MoreLinq;

	public interface ICreature
	{
		IEnumerable<IBodyPart> BodyParts { get; }
		int Size { get => BodyParts.Sum(bodyPart => bodyPart.Size); }

		IAttack Attack();

		void Defend(IAttack attack)
		{
			var total = 0;
			var random = new Random().Next(0, Size);
			var bodyPart = this.BodyParts
				.OrderBy(bp => bp.Size)
				.Select(bp => (BodyPart: bp, Chance: total += bp.Size))
				.FirstOrDefault(x => random < x.Chance)
				.BodyPart;
		}
	}
}

namespace RolePlayingGame.Shared.Creatures
{
	using System.Collections.Generic;

	using RolePlayingGame.Shared.Models;

	public class Human : BaseCreature
	{
		public Human(int defence) : base(defence, new BodyPart("Head", 60, 500).Yield(
			new BodyPart("Body", 160, 500),
			new BodyPart("Left arm", 80, 500),
			new BodyPart("Right arm", 80, 500),
			new BodyPart("Left leg", 100, 500),
			new BodyPart("Right leg", 100, 500)))
		{
		}

		public Human(int defence, IEnumerable<IBodyPart> bodyParts) : base(defence, bodyParts)
		{
		}

		public override IAttack Attack() => throw new System.NotImplementedException();
	}
}
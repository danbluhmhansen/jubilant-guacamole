namespace RolePlayingGame.Shared.Creatures
{
	using System.Collections.Generic;

	using RolePlayingGame.Shared.Health;
	using RolePlayingGame.Shared.Resources;

	public class Human : BaseCreature
	{
		public Human() : base(
			new Vigour(500),
			new Mana(500),
			500,
			500,
			new BodyPart("Head", 60, 500).Yield(
				new BodyPart("Body", 160, 500),
				new BodyPart("Left arm", 80, 500),
				new BodyPart("Right arm", 80, 500),
				new BodyPart("Left leg", 100, 500),
				new BodyPart("Right leg", 100, 500)))
		{

		}

		public Human(IResource vigour, IResource mana, int temperature, int defence, IEnumerable<IBodyPart> bodyParts) : base(vigour, mana, temperature, defence, bodyParts) { }
	}
}

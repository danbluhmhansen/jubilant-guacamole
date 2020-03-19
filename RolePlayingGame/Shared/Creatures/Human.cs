namespace RolePlayingGame.Shared.Creatures
{
	using System.Collections.Generic;
	using System.Linq;

	using RolePlayingGame.Shared.Models;

	public class Human : BaseCreature
	{
		public Human() : base(500, 500, 500, 500,
			new BodyPart("Head", 60, 500).Yield(
			new BodyPart("Body", 160, 500),
			new BodyPart("Left arm", 80, 500),
			new BodyPart("Right arm", 80, 500),
			new BodyPart("Left leg", 100, 500),
			new BodyPart("Right leg", 100, 500)), Enumerable.Empty<IEquipment>())
		{

		}

		public Human(int vigor, int mana, int temperature, int defence, IEnumerable<IBodyPart> bodyParts, IEnumerable<IEquipment> equipment) : base(vigor, mana, temperature, defence, bodyParts, equipment)
		{
		}

		public override IAttack Attack() => throw new System.NotImplementedException();
	}
}
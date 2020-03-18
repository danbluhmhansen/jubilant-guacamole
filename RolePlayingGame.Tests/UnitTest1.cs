namespace RolePlayingGame.Tests
{
	using NSubstitute;

	using NUnit.Framework;

	using RolePlayingGame.Shared.Models;

	public class Tests
	{
		[Test]
		public void Test1()
		{
			// Arrange
			var attack = Substitute.For<IAttack>();
			attack.Attack.Returns(1000);
			attack.Damage.Returns(1000);

			var head = Substitute.For<IBodyPart>();
			var body = Substitute.For<IBodyPart>();
			var leftArm = Substitute.For<IBodyPart>();
			var rightArm = Substitute.For<IBodyPart>();
			var leftLeg = Substitute.For<IBodyPart>();
			var rightLeg = Substitute.For<IBodyPart>();

			body.Size.Returns(160);
			head.Size.Returns(60);
			leftArm.Size.Returns(80);
			rightArm.Size.Returns(80);
			leftLeg.Size.Returns(100);
			rightLeg.Size.Returns(100);

			head.Toughness.Returns(500);
			body.Toughness.Returns(500);
			leftArm.Toughness.Returns(500);
			rightArm.Toughness.Returns(500);
			leftLeg.Toughness.Returns(500);
			rightLeg.Toughness.Returns(500);

			var creature = Substitute.For<ICreature>();
			creature.Defence.Returns(500);
			creature.BodyParts.Returns(new[] { head, body, leftArm, rightArm, leftLeg, rightLeg });

			// Act
			var bodyPart = creature.Defend(attack);
		}
	}
}
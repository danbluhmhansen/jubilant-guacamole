namespace RolePlayingGame.Tests
{
	using System.Collections.Generic;

	using FluentAssertions;

	using NUnit.Framework;

	using RolePlayingGame.Shared;
	using RolePlayingGame.Shared.Combat;
	using RolePlayingGame.Shared.Creatures;
	using RolePlayingGame.Shared.Health;

	public class Combat
	{
		public static IEnumerable<TestCaseData> Data => new[]
		{
			// No hit.
			new TestCaseData(1337, new Human(), new Attack(1000, 1000), default(IBodyPart)),
			// Hit 'Left arm' body part, but doesn't damage.
			new TestCaseData(9663, new Human(), new Attack(1000, 1000), new BodyPart("Left arm", 80, 500, BodyPartStatus.Normal)),
			// Hit and damage 'Head' body part.
			new TestCaseData(6541, new Human(), new Attack(1000, 1000), new BodyPart("Head", 60, 500, BodyPartStatus.Impaired)),
		};

		/// <summary>Testing <see cref="ICreature.Defend(IAttack)"/></summary>
		/// <param name="seed">Specific seed for the randomiser.</param>
		/// <param name="creature">The creature that will defend against the <paramref name="attack"/>.</param>
		/// <param name="attack">The attack the <paramref name="creature"/> will defend against.</param>
		/// <param name="expected">Expected result of the attacked body part.</param>
		[TestCaseSource(nameof(Data))]
		public void Defend(int seed, ICreature creature, IAttack attack, IBodyPart? expected)
		{
			// Arrange
			RandomExtensions.Initialise(seed);

			// Act
			var actual = creature.Defend(attack)!;

			// Assert
			actual.Should().BeEquivalentTo(expected);
		}
	}
}

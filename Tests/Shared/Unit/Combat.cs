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
		private static readonly ICreature testHuman = new Human();
		private static readonly IAttack testAttack = new Attack("Test", 1000, 1000, AppendageType.Arm.Yield());

		/// <summary><see cref="Defend(int, ICreature, IAttack, IAppendage?)"/>.</summary>
		public static IEnumerable<TestCaseData> Data => new[]
		{
			// No hit.
			new TestCaseData(1337, testHuman, testAttack, default(IAppendage)),
			// Hit 'Left arm' appendage, but doesn't damage.
			new TestCaseData(9663, testHuman, testAttack, new Appendage("Left arm", AppendageType.Arm, 80, 500, BodyPartStatus.Normal)),
			// Hit and damage 'Head' appendage.
			new TestCaseData(6541, testHuman, testAttack, new Appendage("Head", AppendageType.Head, 60, 500, BodyPartStatus.Impaired)),
		};

		/// <summary>Testing <see cref="ICreature.Defend(IAttack)"/></summary>
		/// <param name="seed">Specific seed for the randomiser.</param>
		/// <param name="creature">The creature that will defend against the <paramref name="attack"/>.</param>
		/// <param name="attack">The attack the <paramref name="creature"/> will defend against.</param>
		/// <param name="expected">Expected result of the attacked appendage, if the attack is a miss this should be null.</param>
		[TestCaseSource(nameof(Data))]
		public void Defend(int seed, ICreature creature, IAttack attack, IAppendage? expected)
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

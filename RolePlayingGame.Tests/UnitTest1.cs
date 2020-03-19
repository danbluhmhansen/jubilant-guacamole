namespace RolePlayingGame.Tests
{
	using System.Collections.Generic;

	using FluentAssertions;

	using NUnit.Framework;

	using RolePlayingGame.Shared;
	using RolePlayingGame.Shared.Creatures;
	using RolePlayingGame.Shared.Models;

	public class Tests
	{
		public static IEnumerable<TestCaseData> Data => new[]
		{
			new TestCaseData
			(
				6554,
				new Human(),
				new Attack(1000, 1000),
				new BodyPart("Body", 160, 500, BodyPartStatus.Impaired)
			),
			new TestCaseData
			(
				9663,
				new Human(),
				new Attack(1000, 1000),
				new BodyPart("Left arm", 80, 500, BodyPartStatus.Normal)
			),
		};

		[TestCaseSource(nameof(Data))]
		public void Test1(int seed, ICreature creature, IAttack attack, IBodyPart expected)
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
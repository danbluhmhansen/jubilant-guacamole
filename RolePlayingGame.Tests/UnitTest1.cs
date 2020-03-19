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
				new Human(500),
				new Attack(1000, 1000)
			),
		};

		[TestCaseSource(nameof(Data))]
		public void Test1(int seed, ICreature creature, IAttack attack)
		{
			// Arrange
			RandomExtensions.Initialise(seed);

			// Act
			var bodyPart = creature.Defend(attack)!;

			// Assert
			bodyPart.Name.Should().Be("Body");
			bodyPart.Status.Should().Be(BodyPartStatus.Impaired);
		}
	}
}
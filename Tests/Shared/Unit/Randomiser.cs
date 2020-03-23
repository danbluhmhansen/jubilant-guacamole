namespace Shared.Tests.Unit
{
	using System.Collections.Generic;
	using System.Diagnostics.CodeAnalysis;

	using FluentAssertions;

	using NUnit.Framework;

	using RolePlayingGame.Shared;

	[SuppressMessage("Style", "IDE0059:Unnecessary assignment of a value", Justification = "To follow 'Arrange -> Act -> Assert' test structure.")]
	public class Randomiser
	{
		/// <summary><see cref="Chance(int, int, int?, double)"/>.</summary>
		public static IEnumerable<TestCaseData> Data => new[]
		{
			new TestCaseData(800, 3200, default(int?), 75)
		};

		/// <summary>Testing <see cref="RandomExtensions.Chance(int, int, int?)"/>.</summary>
		/// <param name="targetNumber">The number to exceed.</param>
		/// <param name="maxValue">The exclusive upper bound of the random number returned. maxValue must be greater than or equal to minValue.</param>
		/// <param name="minValue">The inclusive lower bound of the random number returned.</param>
		/// <param name="expected">Expected result of the chance calculation.</param>
		[TestCaseSource(nameof(Data))]
		public void Chance(int targetNumber, int maxValue, int? minValue, double expected)
		{
			// Arrange
			var actual = 0.0;

			// Act
			actual = targetNumber.Chance(maxValue, minValue);

			// Assert
			actual.Should().Be(expected);
		}
	}
}

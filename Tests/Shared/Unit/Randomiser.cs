namespace Shared.Tests.Unit
{
	using System.Diagnostics.CodeAnalysis;

	using FluentAssertions;

	using NUnit.Framework;

	using RolePlayingGame.Shared;

	[SuppressMessage("Style", "IDE0059:Unnecessary assignment of a value", Justification = "To follow 'Arrange -> Act -> Assert' test structure.")]
	public class Randomiser
	{
		[Test]
		public void Chance()
		{
			// Arrange
			var actual = 0.0;

			// Act
			actual = 800.Chance(3200);

			// Assert
			actual.Should().Be(25);
		}
	}
}

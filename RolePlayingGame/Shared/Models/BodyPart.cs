﻿namespace RolePlayingGame.Shared.Models
{
	public class BodyPart : BaseBodyPart
	{
		public BodyPart(string name, int size, int toughness, BodyPartStatus status = default) : base(name, size, toughness, status)
		{
		}
	}
}
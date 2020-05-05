namespace RolePlayingGame.Shared.Combat
{
	public interface IDamage
	{
		DamageType Type { get; }
		int Amount { get; }
	}
	public enum DamageType
	{
		Physical,
		Fire,
		Cold,
		Lightning,
		Psychic,
	}
}

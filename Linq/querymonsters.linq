<Query Kind="Program">
  <NuGetReference>Newtonsoft.Json</NuGetReference>
  <Namespace>Newtonsoft.Json</Namespace>
</Query>

void Main()
{
	var targetFilePath = Util.ReadLine();

	var monsters = JsonConvert.DeserializeObject<Monster[]>(File.ReadAllText(targetFilePath));
	
	monsters
	
		.Where(f => f.Name.Contains("emplate"))
		.Where(f => !f.IsFromTomeOfBeasts())
		//.OrderBy(f => f.ToChallengeRating())
	
		.Dump();
}

public static class MonsterExtensions
{
	public static bool IsFromTomeOfBeasts(this Monster monster) => monster.Uri.AbsolutePath.Contains("tome-of-beasts");
	public static double ToChallengeRating(this Monster monster) => Convert.ToDouble(FractionToDouble(monster.Challenge.Dump().Split(' ').First()));
	private static double FractionToDouble(string fraction) => fraction.Dump().Contains('/') ? 1f / Convert.ToInt32(fraction.Split('/').First().Dump()) : Convert.ToDouble(fraction);
}

public class Monster
{
	public string Name { get; set; }
	public string Type { get; set; }
	public string ArmorClass { get; set; }
	public string HitPoints { get; set; }
	public string Speed { get; set; }
	public string SavingThrows { get; set; }
	public string Skills { get; set; }
	public string DamageResistance { get; set; }
	public string DamageImmunity { get; set; }
	public string Senses { get; set; }
	public string Languages { get; set; }
	public string Challenge { get; set; }
	public string[] Traits { get; set; }
	public string InnateSpellcasting { get; set; }
	public string Spellcasting { get; set; }
	public string[] Actions { get; set; }
	public string[] LegendaryActions { get; set; }
	public Uri Uri { get; set; }
}
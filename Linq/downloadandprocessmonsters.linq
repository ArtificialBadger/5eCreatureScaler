<Query Kind="Statements">
  <NuGetReference>HtmlAgilityPack</NuGetReference>
  <NuGetReference>Newtonsoft.Json</NuGetReference>
  <Namespace>HtmlAgilityPack</Namespace>
  <Namespace>Newtonsoft.Json</Namespace>
</Query>

var targetFilePath = @"";

var GetPart = new Func<string, HtmlNode, string>((name, article) => string.Join("", article
	.Descendants("p")
	.FirstOrDefault(p => p.InnerText.StartsWith(name))
	?.ChildNodes
	?.Skip(1)
	?.Select(f => f.InnerText) 
	?? Enumerable.Empty<string>())
	.Replace(Environment.NewLine, string.Empty)
	.Trim());
var GetElementsAfterChallenge = new Func<HtmlNode, IEnumerable<HtmlNode>>(article => article
	.ChildNodes
	.First(c => c.Name == "div")
	.ChildNodes
	.Where(c => c.Name == "p")
	.SkipWhile(c => !c.InnerText.StartsWith("Challenge"))
	.Skip(1)
	.Where(f => !f.InnerText.StartsWith("Spellcasting"))
	.Where(f => !f.InnerText.StartsWith("*"))
	.Where(f => !f.InnerText.StartsWith("Innate"))
	.Where(f => !f.InnerText.StartsWith("At will"))
	.Where(f => !f.InnerText.Substring(1).StartsWith("/day each")));
var GetSpellcastingElement = new Func<HtmlNode, HtmlNode>(article => article
	.ChildNodes
	.First(c => c.Name == "div")
	.ChildNodes
	.Where(c => c.Name == "p")
	.SkipWhile(c => !c.InnerText.StartsWith("Challenge"))
	.Skip(1)
	.FirstOrDefault(f => f.InnerText.StartsWith("Spellcasting")));
var GetSpellcastingDetailsElement = new Func<HtmlNode, IEnumerable<HtmlNode>>(article => article
	.ChildNodes
	.First(c => c.Name == "div")
	.ChildNodes
	.Where(c => c.Name == "p" || c.Name == "blockquote")
	.SkipWhile(f => !f.InnerText.StartsWith("Spellcasting"))
	.Skip(1)
	.Take(1)
	.FirstOrDefault()
	?.Descendants("p")
	?? Enumerable.Empty<HtmlNode>());
var GetInnateSpellcastingNodes = new Func<HtmlNode, IEnumerable<HtmlNode>>(article => article
	.ChildNodes
	.First(c => c.Name == "div")
	.ChildNodes
	.Where(c => c.Name == "p")
	.SkipWhile(c => !c.InnerText.StartsWith("Challenge"))
	.Skip(1)
	.SkipWhile(f => !f.InnerText.StartsWith("Innate"))
	.TakeWhile(f => f.InnerText.StartsWith("Innate") || f.InnerText.StartsWith("At will") || f.InnerText.Substring(1).StartsWith("/day each")));
var GetActionElements = new Func<HtmlNode, IEnumerable<HtmlNode>>(article => article
	.Descendants("div")
	.FirstOrDefault(d => d.Id == "actions")
	?.Descendants("p")
	.Where(f => f.InnerHtml.Trim().StartsWith("<"))
	?? Enumerable.Empty<HtmlNode>());
var GetLegendaryActionElements = new Func<HtmlNode, IEnumerable<HtmlNode>>(article => article
	.Descendants("div")
	.FirstOrDefault(d => d.Id == "legendary-actions")
	?.Descendants("p")
	?.Skip(1) 
	?? Enumerable.Empty<HtmlNode>());

var monsters = new HtmlWeb()
	.Load(@"https://open5e.com/monsters/monsters_a-z/index.html")
	.DocumentNode
	.Descendants("div")
	.Where(d => d.Id == "e-core-monsters")
	.SelectMany(d => d.Descendants("a"))
	.Select(a => a.Attributes["href"]?.Value)
	.Where(at => !string.IsNullOrWhiteSpace(at))
	.Select(at => new Uri(new Uri(@"https://open5e.com/monsters/monsters_a-z/"), at).AbsoluteUri)
	.Concat(new HtmlWeb()
		.Load(@"https://open5e.com/monsters/tome-of-beasts/index.html")
		.DocumentNode
		.Descendants("div")
		.Where(d => d.Id == "tome-of-beasts-kobold-press")
		.SelectMany(d => d.Descendants("a"))
		.Select(a => a.Attributes["href"]?.Value)
		.Where(at => !string.IsNullOrWhiteSpace(at))
		.Select(at => new Uri(new Uri(@"https://open5e.com/monsters/tome-of-beasts/"), at).AbsoluteUri))
	.Where(at => !at.EndsWith("index.html"))
	.Where(at => !at.Contains("#"))
	
	.Select(monsterUri => new HtmlWeb().Load(monsterUri.Dump()).DocumentNode)
	.Select(monsterHtml => monsterHtml.Descendants("div").Where(d => d.Attributes["itemprop"]?.Value == "articleBody").First())
	.Select(article => new
	{
		Name = article.Descendants("h1").First().FirstChild.InnerText,
		Type = article.Descendants("p").Skip(1).First().InnerText,
		ArmorClass = GetPart("Armor Class", article),
		HitPoints = GetPart("Hit Points", article),
		Speed = GetPart("Speed", article),


		SavingThrows = GetPart("Saving Throws", article),
		Skills = GetPart("Skills", article),
		DamageResistance = GetPart("Damage Resistance", article),
		DamageImmunity = GetPart("Damage Immunities", article),
		Senses = GetPart("Senses", article),
		Languages = GetPart("Languages", article),
		Challenge = GetPart("Challenge", article),

		Traits = GetElementsAfterChallenge(article).Select(t => t.InnerText).ToArray(),

		InnateSpellcasting = string.Join(Environment.NewLine, GetInnateSpellcastingNodes(article).Select(f => f.InnerText)),

		Spellcasting = string.Join(Environment.NewLine, new[] { GetSpellcastingElement(article)?.InnerText ?? string.Empty }.Concat(GetSpellcastingDetailsElement(article).Select(f => f.InnerText))),

		Actions = GetActionElements(article).Select(t => t.InnerText).ToArray(),

		LegendaryActions = GetLegendaryActionElements(article).Select(t => t.InnerText).ToArray(),
	})
	.Dump();

File.WriteAllText(targetFilePath, JsonConvert.SerializeObject(monsters));
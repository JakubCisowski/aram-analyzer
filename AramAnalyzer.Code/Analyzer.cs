﻿using System;
using System.Collections.Generic;
using System.Linq;

namespace AramAnalyzer.Code
{
	public static class Analyzer
	{
		public static Dictionary<string, double> BlueTeamChampions { get; set; }
		public static Dictionary<string, double> RedTeamChampions { get; set; }

		static Analyzer()
		{
			BlueTeamChampions = new Dictionary<string, double>();
			RedTeamChampions = new Dictionary<string, double>();
		}

		public static void Analyze()
		{
			AnalyzeWinrates();
		}

		public static void AnalyzeWinrates()
		{
			// For each champion show its winrate in console.

			// BLUE TEAM

			Console.WriteLine();
			Console.WriteLine("------------------------------------------------------------------------------------------------");
			Console.BackgroundColor = ConsoleColor.Blue;
			Console.WriteLine(" BLUE TEAM \t\t WINRATE \t DAMAGE DEALT \t DAMAGE RECEIVED ");
			Console.ResetColor();
			foreach (var participant in Riot.CurrentGame.Participants)
			{
				if (participant.TeamId == 100)
				{
					string championName = Ddragon.GetChampionName(participant.ChampionId);
					double championWinrate = Leagueofgraphs.GetWinrate(championName);

					Console.Write($"{championName}{(championName.Length > 7 ? "\t" : "\t\t")}\t");

					// Select winrate text color.

					if (championWinrate >= 52)
					{
						Console.ForegroundColor = ConsoleColor.Green;
					}
					else if (championWinrate >= 50)
					{
						Console.ForegroundColor = ConsoleColor.Cyan;
					}
					else if (championWinrate >= 48)
					{
						Console.ForegroundColor = ConsoleColor.Magenta;
					}
					else
					{
						Console.ForegroundColor = ConsoleColor.Red;
					}

					Console.Write($"{championWinrate}");
					Console.ResetColor();

					string championBuffs = Wiki.GetChampionBuffs(championName);

					if (championBuffs[2] == '+')
					{
						// Champion is buffed.
						Console.ForegroundColor = ConsoleColor.Green;
					}
					else if (championBuffs[2] == '-')
					{
						// Champion is nerfed.
						Console.ForegroundColor = ConsoleColor.Red;
					}
					else if (championBuffs[4] == '-')
					{
						// Champion is buffed (only damage received).
						Console.ForegroundColor = ConsoleColor.Green;

					}
					else
					{
						// Either no changes, or only damage received nerf.
						Console.ForegroundColor = ConsoleColor.Red;
					}

					Console.WriteLine(championBuffs);
					Console.ResetColor();


					// Add champion with winrate to BlueTeam dictionary.
					BlueTeamChampions.Add(championName, championWinrate);
				}
			}
			Console.BackgroundColor = ConsoleColor.Blue;
			Console.WriteLine($" AVERAGE WINRATE: \t{Math.Round(BlueTeamChampions.Values.Average(), 1)}");
			Console.ResetColor();
			Console.WriteLine();

			// RED TEAM

			Console.BackgroundColor = ConsoleColor.Red;
			Console.WriteLine(" RED TEAM \t\t WINRATE \t DAMAGE DEALT \t DAMAGE RECEIVED ");
			Console.ResetColor();
			foreach (var participant in Riot.CurrentGame.Participants)
			{
				if (participant.TeamId == 200)
				{
					string championName = Ddragon.GetChampionName(participant.ChampionId);
					double championWinrate = Leagueofgraphs.GetWinrate(championName);

					Console.Write($"{championName}{(championName.Length > 7 ? "\t" : "\t\t")}\t");

					// Select winrate text color.

					if (championWinrate >= 52)
					{
						Console.ForegroundColor = ConsoleColor.Green;
					}
					else if (championWinrate >= 50)
					{
						Console.ForegroundColor = ConsoleColor.Cyan;
					}
					else if (championWinrate >= 48)
					{
						Console.ForegroundColor = ConsoleColor.Magenta;
					}
					else
					{
						Console.ForegroundColor = ConsoleColor.Red;
					}

					Console.Write($"{championWinrate}");
					Console.ResetColor();

					string championBuffs = Wiki.GetChampionBuffs(championName);

					if (championBuffs[2] == '+')
					{
						// Champion is buffed.
						Console.ForegroundColor = ConsoleColor.Green;
					}
					else if (championBuffs[2] == '-')
					{
						// Champion is nerfed.
						Console.ForegroundColor = ConsoleColor.Red;
					}
					else if (championBuffs[4] == '-')
					{
						// Champion is buffed (only damage received).
						Console.ForegroundColor = ConsoleColor.Green;

					}
					else
					{
						// Either no changes, or only damage received nerf.
						Console.ForegroundColor = ConsoleColor.Red;
					}

					Console.WriteLine(championBuffs);
					Console.ResetColor();

					// Add champion with winrate to RedTeam dictionary.
					RedTeamChampions.Add(championName, championWinrate);
				}
			}
			Console.BackgroundColor = ConsoleColor.Red;
			Console.WriteLine($" AVERAGE WINRATE: \t{Math.Round(RedTeamChampions.Values.Average(), 1)}");
			Console.ResetColor();
			Console.WriteLine("------------------------------------------------------------------------------------------------");
			Console.WriteLine();
		}
	}
}
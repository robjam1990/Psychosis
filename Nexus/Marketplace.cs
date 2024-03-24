/*
In the world of Psychosis, where adventure awaits in the vast expanses of Thear, your journey begins amidst the intricate tapestry of the Main Hall of Nexus Tavern, nestled within the bustling town of Nexus, Bractalia. Here, amidst the clinking of tankards and murmurs of patrons, your tale unfurls with boundless possibilities.
As you venture forth, prepare to navigate a fully explorable solar system, where round planets beckon exploration and discovery. Engage in tactical combat, where each move is pivotal, utilizing a limb removal system that adds depth and strategy to every encounter.
But it's not just combat that shapes your journey; immerse yourself in an ecosystem simulation where animal communication hints at the secrets of the wild. Beyond mere survival, aspire to greatness as you raise a nation to power, navigating the complexities of multi-faction warfare while managing logistics, agriculture, commerce, and succession.
Within the social fabric of Thear, navigate a bounty system that tests your mettle and reputation. Forge alliances, create hierarchies, or challenge rivals as you navigate a spectrum of loyalty, fear, respect, and morality, all under the jurisdiction of a dynamic justice system tied to territorial borders.
Time flows seamlessly, marked by day/night cycles and shifting seasons, as you engage in the construction, repair, and destruction of structures, shaping entire villages according to your will. Decide the fate of prisoners, wield influence over named locations and objects, and commandeer the aid of others to build armies or delegate tasks.
Supply and demand drive a barter system fueled by an expansive array of renewable and non-renewable resources, while an in-depth crafting system, intertwined with metallurgy, allows for the creation of powerful artifacts and tools essential for survival.
Survival itself is a challenge, with oxygen, temperature, disease, hunger, energy, sanity, hygiene, and waste all factors to consider. Grow and evolve your character through a comprehensive system of advancement and learning, utilizing futuristic customization options and genetic manipulation to craft unique personas suited to your playstyle.
In Psychosis, every choice matters, every action shapes your destiny.Embark on an odyssey through Thear, where the boundaries of reality blur, and the possibilities are as infinite as the cosmos itself.
Psychosis
A text-based game set in the world of Thear.
Copyright 2017-2024 robjam1990
@license MIT
*/
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Psychosis
{
    public class Marketplace
    {
        public static void Market()
        {
            Console.WriteLine("Welcome to the Marketplace!");
            Console.WriteLine("What would you like to do?");
            Console.WriteLine("1. Buy a sword");
            Console.WriteLine("2. Buy a shield");
            Console.WriteLine("3. Leave");
            string input = Console.ReadLine();

            if (input == "1")
            {
                BuyItem("sword", 100, 3);
            }
            else if (input == "2")
            {
                BuyItem("shield", 100, 3);
            }
            else if (input == "3")
            {
                Console.WriteLine("You leave the Marketplace.");
            }
            else
            {
                Console.WriteLine("Invalid input. Please choose a valid option.");
            }
        }

        private static void BuyItem(string itemName, int cost, int statIncrease)
        {
            if (Psychosis.currentPlayer.coins < cost)
            {
                Console.WriteLine("You don't have enough coins.");
            }
            else
            {
                Console.WriteLine("You buy a " + itemName + ".");
                Console.WriteLine("You feel stronger.");
                Console.WriteLine("You gain " + statIncrease + " " + (itemName == "sword" ? "attack" : "defense") + ".");
                Console.WriteLine("You lose " + cost + " coins.");
                Psychosis.currentPlayer.coins -= cost;

                if (itemName == "sword")
                {
                    Psychosis.currentPlayer.Attack += statIncrease;
                }
                else if (itemName == "shield")
                {
                    Psychosis.currentPlayer.Defense += statIncrease;
                }

                Console.WriteLine("You have " + Psychosis.currentPlayer.coins + " coins left.");
            }
        }

    }
}

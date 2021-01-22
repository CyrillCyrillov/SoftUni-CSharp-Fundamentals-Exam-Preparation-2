using System;
using System.Collections.Generic;
using System.Linq;

namespace Task03_Heroes_of_Code_and_Logic_VII
{
    class Program
    {
        static void Main(string[] args)
        {
            int numberOfHeroes = int.Parse(Console.ReadLine());

            Dictionary<string, List<int>> heroes = new Dictionary<string, List<int>>();

            for (int i = 1; i <= numberOfHeroes; i++)
            {
                string[] nextHeroDatas = Console.ReadLine().Split(' ', StringSplitOptions.RemoveEmptyEntries);

                string name = nextHeroDatas[0];
                int hitPoint = int.Parse(nextHeroDatas[1]);
                int manaPoint = int.Parse(nextHeroDatas[2]);

                heroes.Add(name, new List<int> { hitPoint, manaPoint });
            }


            /*
            foreach (var item in heroes)
            {
                Console.WriteLine($"{item.Key} : {item.Value[0]} : {item.Value[1]}");
            }
            */

            while (true)
            {
                string[] comand = Console.ReadLine().Split(" - ", StringSplitOptions.RemoveEmptyEntries);

                if(comand[0].ToUpper() == "END")
                {
                    break;
                }

                string typeAction = comand[0];

                switch (typeAction.ToUpper())
                {
                    case "CASTSPELL":
                        string name = comand[1];
                        int manaPointNeeded = int.Parse(comand[2]);
                        string spellName = comand[3];

                        if(heroes[name][1] >= manaPointNeeded)
                        {
                            heroes[name][1] -= manaPointNeeded;
                            Console.WriteLine($"{name} has successfully cast {spellName} and now has {heroes[name][1]} MP!");
                        }
                        else
                        {
                            Console.WriteLine($"{name} does not have enough MP to cast {spellName}!");
                        }

                        break;

                    case "TAKEDAMAGE":
                        name = comand[1];
                        int damage = int.Parse(comand[2]);
                        string attacker = comand[3];

                        if(heroes.ContainsKey(name))
                        {
                            heroes[name][0] -= damage;

                            if(heroes[name][0] <= 0)
                            {
                                heroes.Remove(name);
                                Console.WriteLine($"{name} has been killed by {attacker}!");
                            }
                            else
                            {
                                Console.WriteLine($"{name} was hit for {damage} HP by {attacker} and now has {heroes[name][0]} HP left!");
                            }
                        }
                        
                        break;

                    case "RECHARGE":
                        name = comand[1];
                        int amount = int.Parse(comand[2]);

                        if (heroes[name][1] + amount > 200)
                        {
                            amount = 200 - heroes[name][1];
                        }
                            
                        heroes[name][1] += amount;
                        Console.WriteLine($"{name} recharged for {amount} MP!");
                        
                        break;

                    case "HEAL":
                        name = comand[1];
                        amount = int.Parse(comand[2]);

                        if (heroes[name][0] + amount > 100)
                        {
                            amount = 100 - heroes[name][0];
                        }

                        heroes[name][0] += amount;
                        Console.WriteLine($"{name} healed for {amount} HP!");
                        break;


                    default:
                        break;
                }
            }

            foreach (var item in heroes.OrderByDescending(x => x.Value[0]).ThenBy(x => x.Key))
            {
                Console.WriteLine(item.Key);
                Console.WriteLine($"HP: {item.Value[0]}");
                Console.WriteLine($"MP: {item.Value[1]}");
            }
        }
    }
}

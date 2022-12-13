﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSharp_Game
{
    internal class Program
    {
        static void Main(string[] args)
        {

            Level level = new Level(20, 1);
            //Inititaliser les bases
            var Player = new Base() { x = 0, y = 0, life = 100};
            var Ennemy = new Base() { x = 20, y = 0, life = 200};
            char[] niveau = new char[20];
            for (int i = 0; i < niveau.Length; i++)
            {
                niveau[i] = '.';
            }

            //Donner une valeur aléatoire aux troupes ennemies
            Random random = new Random();
            int ennemyLife = random.Next(1, 4);
            int allyLife = 0;
            

            Minion minion = new Minion() { x = 0, y = 1, life = allyLife };
            EnnemyMinion ennemyMinion = new EnnemyMinion() { x = 19, y = 1, life = ennemyLife };

            //Augmente la valeur des ennemis en fonction de la durée de la partie
            if (ennemyMinion.number is 5)
            {
                ennemyLife = random.Next(3, 7);
            }
            if (ennemyMinion.number is 10)
            {
                ennemyLife = random.Next(5, 9);
            }
            ennemyMinion.number += 1;

            //Génère automatiquement les ennemis
            ConsoleKey key;
            while (true)
            {
                key = Console.ReadKey().Key;
                System.Threading.Thread.Sleep(1000);
                if (key == ConsoleKey.RightArrow || key == ConsoleKey.NumPad2 || key == ConsoleKey.NumPad4 || key == ConsoleKey.NumPad6 || key == ConsoleKey.NumPad8)
                {
                    //Ajout des troupes alliées
                    if (minion.money >= 2 && key == ConsoleKey.NumPad2)
                    {
                        new Minion() { x = 0, y = 1, life = allyLife = 2 };
                        minion.money -= 2;
                    }
                    if (minion.money >= 4 && key == ConsoleKey.NumPad4)
                    {
                        new Minion() { x = 0, y = 1, life = allyLife = 4 };
                        minion.money -= 4;
                    }
                    if (minion.money >= 6 && key == ConsoleKey.NumPad6)
                    {
                        new Minion() { x = 0, y = 1, life = allyLife = 6 };
                        minion.money -= 6;
                    }
                    if (minion.money >= 8 && key == ConsoleKey.NumPad8)
                    {
                        new Minion() { x = 0, y = 1, life = allyLife = 8 };
                        minion.money -= 8;
                    }

                    //Mouvement des troupes alliées
                    niveau[minion.x] = '.';
                    minion.x += 1;
                    niveau[minion.x] = char.Parse(allyLife.ToString());

                    //Mouvement des troupes ennemies
                    niveau[ennemyMinion.x] = '.';
                    ennemyMinion.x -= 1;
                    niveau[ennemyMinion.x] = char.Parse(ennemyLife.ToString());

                    if (minion.x == ennemyMinion.x + 1 || minion.x == ennemyMinion.x - 1)
                    {
                        if (allyLife > ennemyLife)
                        {
                            allyLife = allyLife - ennemyLife;
                            ennemyLife = 0;
                        }
                        if (allyLife < ennemyLife)
                        {
                            ennemyLife = ennemyLife - allyLife;
                            allyLife = 0;
                        }
                        if (allyLife == ennemyLife)
                        {
                            allyLife = 0;
                            ennemyLife = 0;
                        }
                    }


                    minion.money += 1;
                }
                Console.Clear();
                for (int i = 0; i < niveau.Length; i++)
                {
                    Console.Write(niveau[i]); 
                }
                Console.WriteLine("");
                Console.WriteLine("Player life : " + Player.life);
                Console.WriteLine("===========");
                Console.WriteLine("Ennemy base life : " + Ennemy.life);
                Console.WriteLine("");

                Console.WriteLine("This game's goal is to attack the ennemy base and defend yours.");
                Console.WriteLine("All minions have to defeat ennemy troops in their ways in orther to deal damage to the ennemy's base ");
                Console.WriteLine("Minions have the same value of attack and life (Indicated by the number) ");
                Console.WriteLine("Good luck and FIGHT");
                Console.WriteLine("Press -> to pass your turn");
                Console.WriteLine("Press 2, 4, 6, 8 to add troops ( The value you press is their lifes)");
                Console.WriteLine("To summon troops, you must have the same money as the value of your troop");
                Console.WriteLine("Money : " + minion.money);

            }


            


            //Affiche la fin du jeu
            if (Player.life is 0)
            {
                Console.WriteLine("You win");
            }

            if (Ennemy.life is 0)
            {
                Console.WriteLine("You lose");
            }
            Console.ReadLine();
        }
    }
}

class Base
{
    public int life;
    public int x;
    public int y;
    public int money;
}

class Minion : Base
{
    public int life;
    public int x;
    public int y;
}

class EnnemyMinion : Minion
{
    public int number;
}

class Plate
{
    public Base base1;
    public Minion minion;
}
// *********************************************************************************
// Author:	Alexander Sidorov (blib0l)
// Email:	blib@inbox.ru
// Date: 	17.01.2021
// Project:	RatKiller v1.2
// *********************************************************************************

#region using
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
#endregion

namespace App
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.SetWindowSize(100, 29);

            Hero hero = new Hero();
            Screensaver scr = new Screensaver();
            Intro intro = new Intro(hero);
            Battle B = new Battle(hero);
        }
    }//end class Program

    class Intro
    {
        #region intro
        public Intro(Hero hero)
        {
            SetNameHero(hero);
            Hello(hero);
            Road();
            In(hero);
        }

        public void SetNameHero(Hero hero)
        {
            Console.Clear();
            Console.WriteLine("Как тебя зовут путник?.");
            hero.name = Console.ReadLine();
            Console.Clear();
        }

        void Hello(Hero hero)
        {
            Console.Clear();
            Console.WriteLine($"Приветствую тебя {hero.name}. Это будет тяжелое приключение!");
            Console.WriteLine("Ты уверен что хочешь продолжить?");
            string answer = Console.ReadLine();
            //Console.Clear();
            if (answer == "да" || answer == "да" || answer == "yes" || answer == "Yes")
            {
                GoRoad(hero);
            }
            else if (answer == "нет" || answer == "нет" || answer == "no" || answer == "No")
            {
                Console.WriteLine("это правильный выбор.");
                Console.WriteLine("прощай.");
                Thread.Sleep(4000);
                Environment.Exit(0);
            }
            else
            {
                Console.WriteLine("это какая-то ерунда.");
                Hello(hero);
            }

        }

        public void GoRoad(Hero hero)
        {
            Console.Clear();
            Console.WriteLine($"Что ж,{hero.name}. Ступай по этой тропинке прямо.");
            Console.WriteLine("Она приведет тебя в корчму \"Пьяный Хрюн\". ");
            Console.WriteLine("Спроси там Джонни Косого. Он расскажет тебе что к чему.");
            Console.WriteLine("Удачи тебе смельчак! Да хронят тебя Боги старые и новые.");
            Console.WriteLine("Идти по указанному пути?");
            string answer = Console.ReadLine();
            Console.Clear();
            if (answer == "да" || answer == "да" || answer == "yes" || answer == "Yes")
            {
             
            }
            else if (answer == "нет" || answer == "нет" || answer == "no" || answer == "No")
            {
                Console.WriteLine("это правильный выбор.");
                Console.WriteLine("прощай.");
                Thread.Sleep(4000);
                Environment.Exit(0);
            }
            else
            {
                Console.WriteLine("это какая-то ерунда.");
                GoRoad(hero);
            }

        }

        public void Road()
        {
            Console.Clear();
            Console.WriteLine("Вы неспешно бредете по тропинке.");
            Console.WriteLine("Вокруг растут ели, поднимаясь высоко ввысь.");
            Console.WriteLine("Через некоторое время вы подходите к корчме \"Пьяный Хрюн\".");
            Console.WriteLine("Войти внутрь?");
            string answer = Console.ReadLine();
            Console.Clear();
            if (answer == "да" || answer == "Да" || answer == "yes" || answer == "Yes")
            {
                Console.WriteLine("Дверь легко поддается и вы входите внутрь.");
            }
            else
            {
                Console.WriteLine("Вы решаете не входить и отказаться от этого приключения, уходя подальше от корчмы.");
                Thread.Sleep(4000);
                Environment.Exit(0);
            }
        }

        public void In(Hero hero)
        {
            Console.Clear();
            Console.WriteLine("Корчмарь добродушно встречает вас.");
            Console.WriteLine("И предлагает работу.");
            Console.WriteLine("Нужно разобраться с крысами заполонившими задний двор.");
            Console.WriteLine("Согласится?");
            string answer1 = Console.ReadLine();
            Console.Clear();
            if (answer1 == "да" || answer1 == "Да" || answer1 == "yes" || answer1 == "Yes")
            {

            }
            else
            {
                Console.WriteLine("Вы решаете отказаться от этого приключения?");
                Console.ReadLine();
                Console.Clear();
                Console.WriteLine("Это правильный выбор.");
                Thread.Sleep(4000);
                Environment.Exit(0);
            }
        }
        #endregion
    }//end class Intro
    class Hero
    {
        //Параметры ГГ:
        public string name { set; get; }//Имя
        public int hp { set; get; }//Здоровье
        public int attack { set; get; }//Атака без оружия
        public int defense { set; get; }//Защита без экипировки

        public Hero()
        {
            name = "Fuck";
            hp = 100;
            attack = 3;
            defense = 0;
        }

        //ГГ умеет:
        public void Attack(Monster monster)//Атаковать
        {
            monster.hp -= (attack);

        }
        public void Defense(Monster monster)//Защищаться
        {
            hp -= (monster.attack);

        }
       
        public void Info()//Сообщать свои параметры (вывод данных о х-ках ГГ)
        {
            Console.WriteLine($"Hero Name: {name}");
            Console.WriteLine($"Hero Helth Points: {hp}");
            Console.WriteLine($"Hero Attack Power: {attack}");
            Console.WriteLine($"Hero Defense Power: {defense}");
        }
        public void Escape()//Побег из боя
        {

        }
    }//end class Hero
    class Monster
    {
        public string name { set; get; }//Имя
        public int hp { set; get; }//Здоровье
        public int attack { set; get; }//Атака
        

        public Monster()
        {
            name = "Rat";
            hp = 3;
            attack = 1;
        }

        //Monsters умеет:
        public void Attack(Hero hero)//Атаковать
        {
            hero.hp -= attack;
        }
    }//end class Monster
    class Battle
    {
        static int pcs = PCS();
        static int PCS()//random pcs monsters
        {
            Random rnd = new Random();
            return rnd.Next(10, 20);
        }
        List<Monster> listRat = new List<Monster>(pcs);

        public void battle1()//write monsters in List
        {
            for (int i = 0; i < pcs; i++)
            {
                Monster rat = new Monster();
                listRat.Add(rat);
            }
        }

        public Battle(Hero hero)
        {
            PCS();
            battle1();
            BattleLoop(hero);
        }

        public void BattleLoop(Hero hero)
        {
            bool inGame = true;
            while (inGame)
            {
                if (listRat.Count <= 0)
                {
                    Console.Clear();
                    Console.WriteLine("All Rat die! You Win!");
                    Thread.Sleep(4000);
                    inGame = false;
                }
                else if (hero.hp <= 0)
                {
                    Console.Clear();
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine("Rat Win! You die!");
                    Thread.Sleep(4000);
                    inGame = false;
                }
                else
                {
                    Console.Clear();
                    Console.WriteLine($"Вас атакует стая крыс.");
                    Console.WriteLine($"Ваши действия?");
                    Console.WriteLine("Menu: 1 - Attack; 2 - Def; 0 - Quit");

                    BattleFunc(listRat, Console.ReadLine(), hero);
                    Console.Clear();
                }
            }
            Console.Clear();
            Console.WriteLine($"Вы победили всех крыс.");
            Console.WriteLine($"Ваши действия?");
            Console.WriteLine("Menu: 1 - Повторить; 0 - Quit");
            string answer = Console.ReadLine();

            if (answer == "1")
            {
                PCS();
                battle1();
                BattleLoop(hero);
            }   
            else
            {
                Console.WriteLine("это правильный выбор.");
                Console.WriteLine("прощай.");
                Thread.Sleep(3000);
                Environment.Exit(0);
            }
        }
       
        public void BattleFunc(List<Monster> listRat, string key, Hero hero)
        {
            if (key == "1")
            {
                AttackAttack(listRat, hero);
            }
            else if (key == "2")
            {
                DefAttack(listRat, hero);
            }
            else if (key == "0")
            {
                Thread.Sleep(4000);
                Environment.Exit(0);
            }
            else
            {
                Console.WriteLine("Это какая-то ерунда.");
                BattleFunc(listRat, key, hero);
            }

        }

        public void AttackAttack(List<Monster> listRat, Hero hero)
        {
            Console.Clear();
            Console.WriteLine($"{hero.name} атакует крысу на:{hero.attack}");
            Console.WriteLine(listRat.Count);
            hero.Attack(listRat[listRat.Count - 1]);
            //Console.WriteLine($"Rat HP: {listRat[listRat.Count - 1].hp}");
            MonstersAttack(listRat, hero);
            if (listRat[listRat.Count - 1].hp <= 0)
            {
                listRat.RemoveAt(listRat.Count - 1);
                Console.WriteLine("You killed 1 rat");
                Thread.Sleep(1000);
            }
        }

        public void DefAttack(List<Monster> listRat, Hero hero)
        {
            Random rnd = new Random();
            Console.Clear();
            Console.WriteLine($"{hero.name} защищается");
            if (listRat.Count > 0) // вынести атаку монстров в отдельную функцию
            {
                if (listRat.Count >= 3)
                {
                    int i = rnd.Next(1, listRat.Count);
                    Console.WriteLine($"Крысы {i} штук, атакуют в ответ на: {i}");
                    int jjj = 0;// hero.DefensePower();
                    hero.hp -= (i - jjj);
                    Console.WriteLine($"{hero.name} блокирует атаку на {jjj}");
                    Console.WriteLine($"{hero.name} Очки Здоровья: {hero.hp}");
                    Thread.Sleep(4000);
                }
                else if (listRat.Count == 2)
                {
                    int i = rnd.Next(1, 2);
                    string j;

                    if (i == 2) { j = "Две крысы атакуют"; }
                    else { j = "Одна крыса атакует"; }

                    Console.WriteLine($"{j} в ответ на: {i}");
                    //hero.HP -= (i - hero.DefensePower());
                    Console.WriteLine($"Hero полностью блокирует атаку");
                    Thread.Sleep(4000);
                }
                else
                {
                    Console.WriteLine($"Крыса атакует в ответ на: {listRat[listRat.Count - 1].attack}");
                    //listRat[listRat.Count - 1].attack(hero);
                    Console.WriteLine($"Hero полностью блокирует атаку");
                    Thread.Sleep(4000);
                }
            }
        }

        public void MonstersAttack(List<Monster> listRat, Hero hero)
        {
            Random rnd = new Random();
            if (listRat.Count >= 3)
            {
                int i = rnd.Next(1, listRat.Count);
                Console.WriteLine($"Крысы {i} штук, атакуют в ответ на: {i}");
                hero.hp -= i;
                Console.WriteLine($"Hero HP: {hero.hp}");
                Thread.Sleep(1000);
            }
            else if (listRat.Count == 2)
            {
                int i = rnd.Next(1, 2);
                string j;

                if (i == 2) { j = "Две крысы атакуют"; }
                else { j = "Одна крыса атакует"; }

                Console.WriteLine($"{j} в ответ на: {i}");
                hero.hp -= i;
                Console.WriteLine($"Hero HP: {hero.hp}");
                Thread.Sleep(1000);
            }
            else
            {
                Console.WriteLine($"Последняя Крыса атакует в ответ на: {listRat[listRat.Count - 1].attack}");
                listRat[listRat.Count - 1].Attack(hero);
                //hero.HP -= listRat[listRat.Count - 1].Attack;
                Console.WriteLine($"{hero.name} Очки Здоровья: {hero.hp}");
                Thread.Sleep(1000);
            }
        }
    }//end class Battle

    class Screensaver
    {
        public char[,] ii = new char[,]
        {
         
         {'_','_','_','_','_','_','_','_','_','_','_','_','_','_','_','@','J','J','J','J','J','J','J','J','J','J','J','J','J','J','J','J','J','J','J','J','J','J','_','_','_','_','_','_','_','_','_','_','_','_','_','_' },
         {'_','_','_','_','_','_','_','_','_','_','_','_','@','J','J','J','J','J','J','J','J','J','J','J','J','J','J','J','J','J','J','J','J','J','J','J','J','J','J','J','J','_','_','_','_','_','_','_','_','_','_','_' },
         {'_','_','_','_','_','_','_','_','_','@','J','J','J','J','J','J','J','J','J','J','J','J','J','J','J','J','J','J','J','J','J','J','J','J','J','J','J','J','J','J','J','J','J','J','_','_','_','_','_','_','_','_' },
         {'_','_','_','_','_','_','_','J','J','J','J','J','J','J','J','J','J','J','J','J','J','J','J','J','J','J','J','J','J','J','J','J','J','J','J','J','J','J','J','J','J','J','J','J','J','_','_','_','_','_','_','_' },
         {'_','_','_','_','_','_','J','J','J','J','J','J','J','J','J','J','J','J','J','J','J','J','J','J','J','J','J','J','J','J','J','J','J','J','J','J','J','J','J','J','J','J','J','J','J','J','_','_','_','_','_','_' },
         {'_','_','_','_','_','J','J','J','J',' ',' ',' ',' ','J','J','J','J','J','J','J','J','J','J','J','J',' ',' ',' ',' ',' ',' ',' ',' ','J','J','J','J','J','J','J','J','J','J','J','J','J','J','J','_','_','_','_' },
         {'_','_','_','_','J','J','J','J',' ','|','R','R',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ','|',' ',' ','K',' ',' ',' ','J','J','J','J','J','J','J','J','J','J','J','J','J','J','J','J','_','_','_' },
         {'_','_','_','J','J','J','J','J',' ','|',' ',' ','R',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ','|',' ',' ','K',' ',' ',' ',' ',' ',' ',' ','J','J','J','J','J','J','J','J','J','J','J','J','J','_','_' },
         {'_','_','J','J','J','J','J','J',' ','|',' ',' ','R',' ',' ',' ',' ',' ',' ',' ','T',' ',' ',' ',' ',' ','|',' ',' ','K',' ',' ',' ','l',' ','l',' ','J','J','J','J','J','J','J','J','J','J','J','J','J','_','_' },
         {'_','J','J','J','J','J','J','J',' ','|',' ',' ','R',' ',' ',' ',' ',' ',' ',' ','T',' ',' ',' ',' ',' ','|',' ',' ','K',' ',' ',' ','l',' ','l',' ','J','J','J','J','J','J','J','J','J','J','J','J','J','J','_' },
         {'_','J','J','J','J','J','J','J',' ','|',' ',' ','R',' ',' ',' ',' ',' ',' ',' ','T',' ',' ',' ',' ',' ','|',' ',' ','K',' ',' ',' ','l',' ','l',' ','J','J','J','J','J','J','J','J','J','J','J','J','J','J','_' },
         {'_','J','J','J','J','J','J','J',' ','|',' ',' ','R',' ',' ',' ',' ',' ',' ',' ','T',' ',' ',' ',' ',' ','|',' ',' ','K',' ',' ',' ','l',' ','l',' ','J','J','J','J','J','J','J','J','J','J','J','J','J','J','_' },
         {'_','J','J','J','J','J','J','J',' ','|',' ','R',' ',' ',' ',' ',' ',' ',' ',' ','T',' ',' ',' ',' ',' ','|',' ','K',' ',' ','i',' ','l',' ','l',' ','J','J','J','J','J','J','J','J','J','J','J','J','J','J','_' },
         {'_','J','J','J','J','J','J','J',' ','|','R',' ',' ',' ',' ',' ',' ',' ','T','T','T','T','T',' ',' ',' ','|','K',' ',' ',' ',' ',' ','l',' ','l',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ','J','J','J','J','J','_' },

         {'_','J','J','J','J','J','J','J',' ','|',' ','R',' ',' ',' ','@','@',' ',' ',' ','T',' ',' ',' ',' ',' ','|',' ','K',' ',' ','I',' ','l',' ','l',' ',' ','e','e',' ',' ','r',' ','r','r',' ',' ','J','J','J','_' },
         {'_','J','J','J','J','J','J','J',' ','|',' ',' ','R',' ','@',' ',' ','@',' ',' ','T',' ',' ',' ',' ',' ','|',' ',' ','K',' ','I',' ','l',' ','l',' ','e',' ',' ','e',' ','r','r',' ',' ','r',' ','J','J','J','_' },
         {'_','J','J','J','J','J','J','J',' ','|',' ',' ','R',' ',' ',' ',' ','@',' ',' ','T',' ',' ',' ',' ',' ','|',' ',' ','K',' ','I',' ','l',' ','l',' ','e',' ',' ','e',' ','r',' ',' ',' ',' ','J','J','J','J','_' },
         {'_','J','J','J','J','J','J','J',' ','|',' ',' ','R',' ',' ','@','@','@',' ',' ','T',' ',' ',' ',' ',' ','|',' ',' ','K',' ','I',' ','l',' ','l',' ','e','e','e',' ',' ','r',' ','J','J','J','J','J','J','J','_' },
         {'_','_','J','J','J','J','J','J',' ','|',' ',' ','R',' ','@',' ',' ','@',' ',' ','T',' ',' ',' ',' ',' ','|',' ',' ','K',' ','I',' ','l',' ','l',' ','e',' ',' ',' ',' ','r',' ','J','J','J','J','J','J','_','_' },
         {'_','_','_','J','J','J','J','J',' ','|',' ',' ','R',' ','@',' ',' ','@',' ',' ','T',' ',' ',' ',' ',' ','|',' ',' ','K',' ','I',' ','l',' ','l',' ','e',' ',' ','e',' ','r',' ','J','J','J','J','J','J','_','_' },
         {'_','_','_','_','J','J','J','J',' ','|',' ',' ','R',' ',' ','@','@','@',' ',' ','T','T','T',' ',' ',' ','|',' ',' ','K',' ','I',' ','l',' ','l',' ',' ','e','e',' ',' ','r',' ','J','J','J','J','J','_','_','_' },
         {'_','_','_','_','_','J','J','J','J',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ','J','J','J','J','J','_','_','_','_' },
         {'_','_','_','_','_','_','J','J','J','J','J','J','J','J','J','J','J','J','J','J','J','J','J','J','J','J','J','J','J','J','J','J','J','J','J','J','J','J','J','J','J','J','J','J','J','J','J','_','_','_','_','_' },
         {'_','_','_','_','_','_','_','J','J','J','J','J','J','J','J','J','J','J','J','J','J','J','J','J','J','J','J','J','J','J','J','J','J','J','J','J','J','J','J','J','J','J','J','J','J','J','_','_','_','_','_','_' },
         {'_','_','_','_','_','_','_','_','_','@','J','J','J','J','J','J','J','J','J','J','J','J','J','J','J','J','J','J','J','J','J','J','J','J','J','J','J','J','J','J','J','J','J','J','_','_','_','_','_','_','_','_' },
         {'_','_','_','_','_','_','_','_','_','_','_','_','J','J','J','J','J','J','J','J','J','J','J','J','J','J','J','J','J','J','J','J','J','J','J','J','J','J','J','J','J','_','_','_','_','_','_','_','_','_','_','_' },
         {'_','_','_','_','_','_','_','_','_','_','_','_','_','_','_','J','J','J','J','J','J','J','J','J','J','J','J','J','J','J','J','J','J','J','J','J','J','J','_','_','_','_','_','_','_','_','_','_','_','_','_','_' },
         { '_','_','_','_','_','_','p','r','e','s','s','_','E','N','T','E','R','_','f','o','r','_','S','T','A','R','T','_','o','r','_','E','S','C','A','P','E','_','f','o','r','_','E','X','I','T','_','_','_','_','_','_'}
        };

        public void Draw()
        {
            for (int i = 0; i < 28; i++)
            {
                for (int j = 0; j < 51; j++)
                {
                    Console.Write(ii[i, j]);
                }
                Console.WriteLine();
            }
        }

        public Screensaver()
        {
            ConsoleKeyInfo cki;
            do
            {
                Draw();

                cki = Console.ReadKey(true);

                if (cki.Key == ConsoleKey.Escape)
                {
                    Thread.Sleep(2000);
                    Environment.Exit(0);
                }
                else
                {
                    Console.Clear();
                }
            } while (cki.Key != ConsoleKey.Enter);
        }
    }//end class Screensaver
}//end namespace

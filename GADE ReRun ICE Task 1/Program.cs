using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GADE_ReRun_ICE_Task_1
{
    class Program
    {
        static void Main(string[] args)
        {
            string heroName;
            int heroHP;
            int heroDamage;
            int heroCrit;
            string enemyName;
            int enemyHP;
            int enemyDamage;
            int enemyCrit;
            string enemyType;

            heroName = "steven";
             
            //hero stats
            string heroTrueName = elvenName(heroName);
            heroHP = randomiseHP(100, 201);
            heroDamage = randomiseDamage(20, 91);
            heroCrit = randomiseCrit(10, 51);

            //enemy stats
            enemyName = getEnemyType(rollEnemyType());
            enemyHP = randomiseHP(150, 300);
            enemyDamage = randomiseDamage(20, 50);
            enemyCrit = randomiseCrit(5, 31);

            //print out stats
            Console.WriteLine("Hero Name: " + heroTrueName);
            Console.WriteLine("Hero HP: " + heroHP);
            Console.WriteLine("Hero Damage: " + heroDamage);
            Console.WriteLine("Hero Critical Chance: " + heroCrit);
            Console.WriteLine("_______________________________________");
            Console.WriteLine("Enemy Name: " + enemyName);
            Console.WriteLine("Enemy HP: " + enemyHP);
            Console.WriteLine("Enemy Damage: " + enemyDamage);
            Console.WriteLine("Enemy Critical Chance: " + enemyCrit);
            Console.WriteLine("________________________________________");
            Console.WriteLine("The Fight Has Begun!");



            while (heroHP > 0 && enemyHP > 0)
            {
                // hero attacks
                Console.WriteLine("Our Hero " + heroTrueName + " , attacks the " + enemyName);
                enemyHP = attack(heroTrueName, heroDamage, heroCrit, enemyHP);
                Console.WriteLine(enemyName + " has " + enemyHP + " health left");

                if(enemyHP <= 0)
                {
                    break;
                }

                //enemy attacks
                Console.WriteLine(enemyName + " attacks " + heroTrueName);
                heroHP = attack(enemyName, enemyDamage, enemyCrit, heroHP);
                Console.WriteLine(heroTrueName + " has " + heroHP + " health left");

            }

            if(heroHP > enemyHP)
            {
                Console.WriteLine("Our Hero " + heroTrueName + " is victorious");
            }
            else
            {
                Console.WriteLine("The " + enemyName + " has defeated our hero");

                //just checking if it was a specific enemy
                if (enemyName == "Ugandan Knuckles")
                {
                    Console.WriteLine("Now you know, DE WAE");
                }
            }





        }

        public static string elvenName(string heroName)
        {
            
            char[] nameArray = heroName.ToCharArray();
            Array.Sort(nameArray);
            string newName = new string(nameArray);

            return newName;
        }

        public static int randomiseHP(int low, int high)
        {
            Random randHP = new Random();
            int hp = randHP.Next(low, high);
            return hp;
        }

        public static int randomiseDamage(int low, int high)
        {
            Random randDamage = new Random();
            int damage = randDamage.Next(low, high);
            return damage;
        }

        public static int randomiseCrit(int low, int high)
        {
            Random randCrit = new Random();
            int crit = randCrit.Next(low, high);
            return crit;
        }

        public static int rollEnemyType()
        {
            Random enemyRoll = new Random();
            int enemyNum = enemyRoll.Next(1, 4);
            return enemyNum;

        }

        public static string getEnemyType(int enemyNum)
        {
           
            switch(enemyNum)
            {
                case 1:
                    return "Goblin";
                    break;

                case 2:
                    return "Dragon";
                    break;

                case 3:
                    return "Ugandan Knuckles";
                    break;

                default:
                    Console.WriteLine("something went wrong");
                    return "something went wrong";
                    break;
            }

           
        }

        public static bool critCheck(int critChance)
        {
            bool doesCrit = false;
            Random roll = new Random();
            int critRoll = roll.Next(0, 101);
            if (critChance >= critRoll)
            {
                doesCrit = true;
            }
            else
            {
                doesCrit = false;
            }

            return doesCrit;
        }

        public static int attack(string attackerName , int attackDamage, int attackerCrit, int targetHP)
        {
            if (critCheck(attackerCrit) == true)
            {
                attackDamage = attackDamage * 3;
                Console.WriteLine(attackerName + " Scores a Critical Hit");
            }

            Console.WriteLine(attackerName + " does " + attackDamage + " Damage!!!");
            int targetNewHP = targetHP - attackDamage;

            return targetNewHP;
        }


        }
    }


using System;
using static System.Runtime.InteropServices.JavaScript.JSType;
using System.ComponentModel;
using System.Runtime.Intrinsics.X86;

namespace catMania
{
    class versionOne
    {
        static void Main(string[] args)
        {
            int cats = 0,health = 0, round = 0, direction = 0;
            Random r = new Random();
            bool win = false;
            Console.Write("What is the name of your cat wrangler? ");
            string name = Console.ReadLine();
            Console.Write($"Welcome, {name}! \nThe goal of the game is to wrangle 15 cats OR make it through all 20 rounds. \n\nIf you lose all the cats or your health reaches zero, you lose. \n\nGood luck!\n");
            
            initValues(ref cats, ref health, r);
            Console.WriteLine($"Starting stats: Cats = {cats}; Health = {health}");

            while (cats > 0 && health > 0 && win == false)
            {
                direction = chooseDirection();
                /* the direction impacts the number passed to the actions method
                 * if they choose left, they will only receive bad outcomes
                 * if they choose right, they have a better chance of receiving 
                 * good outcomes along with the bad outcomes */
                if (direction == 1)
                    actions(r.Next(4), ref cats, ref health);
                else if (direction == 2)
                    actions(r.Next(6), ref cats, ref health);
                else
                    actions(r.Next(10), ref cats, ref health);
                checkResults(ref round, ref cats, ref health, ref win);
            }
            if (win)
                Console.WriteLine("Congratulations on successfully wrangling all the cats!");
            else if (cats <= 0)
                Console.WriteLine("You have failed to wrangle the cats and they have all run away");
            else
                Console.WriteLine("You don't have any health left and cannot wrangle any more cats");

        }
        private static void initValues(ref int cats, ref int health, Random r)
        {
            cats = r.Next(4,10) + 1;
            health = r.Next(14) + 5;
            return;
        }

        private static int chooseDirection()
        {
            Console.WriteLine("You've come to an intersection: enter 1 to search the left road, 2 to search straight ahead, and 3 to search right.");

            int direction = int.Parse(Console.ReadLine());

            while (direction != 1 && direction != 2 && direction != 3)
            {
                Console.WriteLine("You entered an invalid number, please enter 1 to search the left road, 2 to search straight ahead, and 3 to search right.");
                direction = int.Parse(Console.ReadLine());
            }
            return direction;
        }
        private static void actions(int v, ref int cats, ref int health)
        {
            int num = v;
            switch (num)
            {
                case 0:
                    Console.WriteLine("You found a cat but it was running with a pack of wolves.");
                    Console.WriteLine("You lose 2 units of health and 1 cat.");
                    health -= 2;
                    cats -= 1;
                    break;
                case 1:
                    Console.WriteLine("You found a cat hiding in the bushes but stumbled and lost your balance, allowing it to escape.");
                    Console.WriteLine("You lose 2 units of health.");
                    health -= 2;
                    break;
                case 2:
                    Console.WriteLine("You found a colony of cats, but the dander set off your allergies and scared them off.");
                    Console.WriteLine("You lose 3 cats due to your sneezing fit.");
                    cats -= 2;
                    break;

                case 3:
                    Console.WriteLine("You crouched to look into a hole for cats and surprised a hibernating bear.");
                    Console.WriteLine("You lose 3 units of health and 2 cats.");
                    health -= 3;
                    cats -= 3;
                    break;

                case 4:
                    Console.WriteLine("You managed to trap a cat, but not before it fought back.");
                    Console.WriteLine("You gain 1 cat and lose 1 health.");
                    health -= 1;
                    cats += 1;
                    break;

                case 5:
                    Console.WriteLine("You went fishing by the river, luring 2 cats out with your catch.");
                    Console.WriteLine("You gain 2 cats.");
                    cats += 2;
                    break;
                case 6:
                    Console.WriteLine("You find a cat stuck in a tree. You rescue it but realize it has a collar on it, so you return it to its owner.");
                    Console.WriteLine("You lose 1 cat and gain 1 unit of health");
                    health += 1;
                    cats -= 1;
                    break;

                case 7:
                    Console.WriteLine("You take a break and head to a sunny meadow, finding some cats basking in the sun.");
                    Console.WriteLine("You gain 2 cats and 1 health.");
                    cats += 2;
                    health += 1;
                    break;

                case 8:
                    Console.WriteLine("Your shoe comes untied, and you decide to use the string as a lure trailing behind you.");
                    Console.WriteLine("You gain 3 cats and lose 1 health");
                    health -= 1;
                    cats += 3;
                    break;

                case 9:
                    Console.WriteLine("You find a small mirror and use the sun to reflect the light on the ground, attracting cats.");
                    Console.WriteLine("You gain 4 cats.");
                    cats += 4;
                    break;

                default:
                    Console.WriteLine("You brought out your mother's tuna casserole and enticed a colony of cats to follow you.");
                    Console.WriteLine("You gain 5 cats and 2 health.");
                    cats += 5;
                    health += 2;
                    break;
            }
        }
        private static void checkResults(ref int round, ref int cats, ref int health, ref bool win)
        {
            //1) Add 1 to the round variable
            round++;

            //2) Write out the round number
            Console.WriteLine($"\n~~~~~~~~~Round: {round}~~~~~~~~~~~~~~~\n");

            //3) Write out the values for lives, magic and health
            Console.WriteLine($"Cats wrangled: {cats}; Health: {health}");

            //4) Check to see if the round variable >= 20.If it is true, then set win = true.
            if (round >= 20 || cats >= 15)
            {
                win = true;
            }

            //5) Return to the main methodround++;
            return;
        }

    }
}
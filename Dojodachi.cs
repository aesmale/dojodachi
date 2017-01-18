using System.IO;
using System;
using Microsoft.AspNetCore.Hosting;

namespace dojodachi
{
    public class Dojodachi
    {
        public int happiness = 20;
        public int fullness = 20;
        public int energy = 50;
        public int meals = 3;
        public int alive = 0;

        // private static Dojodachi instance;

        // private Dojodachi() {}
        // public static Dojodachi Instance
        //     {
        //         get 
        //         {
        //             if (instance == null)
        //             {
        //                 instance = new Dojodachi();
        //             }
        //             return instance;
        //         }
        //     }
        public bool Feed()
        {
            if (this.meals < 1)
            {
                return false;
            }

            this.meals = this.meals - 1;

            Random rnd = new Random();
            int eaten = rnd.Next(5, 11);
            Random satisfy = new Random();
            int satisfied = satisfy.Next(1, 5);
            this.fullness = this.fullness + 15;
            System.Console.WriteLine("**************" + this.fullness + "IM INSIDE THE FEED FUNCTION!!!!");
            if (satisfied != 1)
            {
                this.fullness = this.fullness + eaten;
                System.Console.WriteLine("Your Dojodachi ate a meal! Fullness went up by " + eaten + "!");
            }
            else
            {
                System.Console.WriteLine("Your Dojodachi ate a meal but didn't enjoy it. Fullness didn't change.");
            }
            return true;
        }

        public bool Play()
        {
            if (this.energy < 5)
            {
                return false;
            }
            this.energy = this.energy - 5;
            Random rnd = new Random();
            int happy = rnd.Next(5, 11);
            Random satisfy = new Random();
            int satisfied = satisfy.Next(1, 5);
            if (satisfied != 1)
            {
                this.happiness = this.happiness + happy;
                System.Console.WriteLine("Your Dojodachi played! Happiness went up by " + happy + "!");
            }
            else
            {
                System.Console.WriteLine("Your Dojodachi played a game but didn't enjoy it. Happiness didn't change.");
            }
            return true;
        }

        public bool Work()
        {
            if (this.energy < 5)
            {
                return false;
            }
            this.energy = this.energy - 5;
            Random rnd = new Random();
            int food = rnd.Next(1, 4);
            this.meals = this.meals + food;
            System.Console.WriteLine("Your Dojodachi went to work! Their energy went down by 5, but they earned " + food + " meals!");
            return true;
        }

        public void Sleep()
        {
            this.energy = this.energy + 15;
            this.happiness = this.happiness - 5;
            this.fullness = this.fullness - 5;
            System.Console.WriteLine("Your Dojodachi went to sleep. Their energy increased by 15, but their happiness and fullness decreased by 5 each.");
        }

        public void Progress()
        {
            if (this.energy == 100 && this.fullness == 100 && this.happiness == 100)
            {
                this.alive = 2;
                System.Console.WriteLine("Congratulations, you won!");
            }
            else if (this.fullness == 0 || this.happiness == 0)
            {
                this.alive = 1;
                System.Console.WriteLine("Your Dojodachi has passed away :(");
            }
            else
            {
                this.alive = 0;

            }
        }
    }
}

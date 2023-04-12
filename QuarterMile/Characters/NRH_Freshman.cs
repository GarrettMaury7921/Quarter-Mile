using System;
using System.Collections.Generic;


namespace QuarterMile.Characters
{
    internal class NRH_Freshman
    {

        public static double money;
        public static double health;
        public static int resiliance;
        public static double chanceToBeDepressed;

        public void SetMoney(double mon)
        {
            money = mon;
        }
        public void AddMoney(double mon)
        {
            money += mon;
        }
        public void SetHealth(double heal)
        {
            health = heal;
        }
        public void AddHealth(double heal)
        {
            health += heal;
        }
        public void SetResiliance(int res)
        {
            resiliance = res;
        }
        public void AddResiliance(int res)
        {
            resiliance += res;
        }

        public double GetMoney()
        {
            return money;
        }

        public double GetHealth()
        {
            return health;
        }

        public NRH_Freshman() {

            money = 500;
            health = 100;
            resiliance = 0;
            chanceToBeDepressed = 0.1;
        }

    }
}

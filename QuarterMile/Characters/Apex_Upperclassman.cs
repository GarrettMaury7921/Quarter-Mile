

namespace QuarterMile.Characters
{
    internal class Apex_Upperclassman
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

        public Apex_Upperclassman()
        {
            money = 1500;
            health = 100;
            resiliance = 3;
            chanceToBeDepressed = 0.4;
        }
    }
}

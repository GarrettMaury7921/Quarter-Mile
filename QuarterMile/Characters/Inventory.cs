
using System;

namespace QuarterMile.Characters
{
    internal class Inventory
    {

        // Attributes
        public double _money;
        public int _semester;
        public int _skateboards;
        public int _food;
        public int _clothing;
        public double _study_guides;
        public int _skate_wheel;
        public int _skate_truck;
        public int _skate_bearing;
        public double _health;
        public string _name1;
        public string _name2;
        public string _name3;
        public string _name4;

        // Initial stats
        private double init_money;
        private int init_semester;
        private int init_skateboards;
        private int init_food;
        private int init_clothing;
        private double init_study_guides;
        private int init_skate_wheel;
        private int init_skate_truck;
        private int init_skate_bearing;
        private double init_health;
        private string init_name1;
        private string init_name2;
        private string init_name3;
        private string init_name4;

        // Variables
        public string month;
        public int day;
        public int year;
        public string weather;
        public string pace;
        public string rations;

        public bool name2Alive;
        public bool name3Alive;
        public bool name4Alive;

        public Inventory(double money, int semester, int skateboards, 
            int food, int clothing, double study_guides, int skate_wheel, 
            int skate_truck, int skate_bearing, double health,
            string name1, string name2, string name3, string name4) {
            
            _money = money;
            _semester = semester;
            _skateboards = skateboards;
            _food = food;
            _clothing = clothing;
            _study_guides = study_guides;
            _skate_wheel = skate_wheel;
            _skate_truck = skate_truck;
            _skate_bearing = skate_bearing;
            _health = health;
            _name1 = name1;
            _name2 = name2;
            _name3 = name3;
            _name4 = name4;

            name2Alive = true;
            name3Alive = true;
            name4Alive = true;

            pace = "steady";
            rations = "meager";

            InitialStats(money, semester, skateboards, food, clothing, study_guides, skate_wheel, skate_truck, skate_bearing, health,
                name1, name2, name3, name4);
            StartDate(semester);
            StartingWeather(semester);
        }

        // For to use later in stats or something
        public void InitialStats(double money, int semester, int skateboards,
            int food, int clothing, double study_guides, int skate_wheel, 
            int skate_truck, int skate_bearing, double health,
            string name1, string name2, string name3, string name4)
        {
            init_money = money;
            init_semester = semester;
            init_skateboards = skateboards;
            init_food = food;
            init_clothing = clothing;
            init_study_guides = study_guides;
            init_skate_wheel = skate_wheel;
            init_skate_truck = skate_truck;
            init_skate_bearing = skate_bearing;
            init_health = health;
            init_name1 = name1;
            init_name2 = name2;
            init_name3 = name3;
            init_name4 = name4;
        }

        public void ChangeRations(int num)
        {
            if (num == 1 && rations.Equals("meager"))
            {
                rations = "filling";
            }
            if (num == 1 && rations.Equals("bare bones"))
            {
                rations = "meager";
            }

            if (num == -1 && rations.Equals("meager"))
            {
                rations = "bare bones";
            }
            if (num == -1 && rations.Equals("filling"))
            {
                rations = "meager";
            }
        }

        public void ChangePace(int num)
        {
            if (num == 1 && pace.Equals("strenuous"))
            {
                pace = "steady";
            }
            if (num == 1 && pace.Equals("grueling"))
            {
                pace = "strenuous";
            }

            if (num == -1 && pace.Equals("strenuous"))
            {
                pace = "grueling";
            }
            if (num == -1 && pace.Equals("steady"))
            {
                pace = "strenuous";
            }
        }

        public string ReportHealth()
        {
            if (_health >= 70)
            {
                return "Good";
            }
            if (_health >= 50 && _health < 70)
            {
                return "Okay";
            }
            if (_health >= 30 && _health < 50)
            {
                return "Poor";
            }
            if (_health >= 20 && _health < 30)
            { 
                return "Very Poor";
            }
            if (_health > 0 && _health < 20)
            {
                return "Close to Death";
            }
            if (_health <= 0)
            {
                return "Dead";
            }

            return null;
        }

        public void StartDate(int semester)
        {
            //fall
            if (semester == 1)
            {
                month = "August";
                day = 22;
                year = 2023;
            }
            if (semester == 2)
            {
                month = "January";
                day = 16;
                year = 2023;
            }
        }

        public void StartingWeather(int semester)
        {
            //fall
            if (semester == 1)
            {
                Random random = new();
                int randomNum = random.Next(1, 6); // x, y-1
                switch (randomNum)
                {
                    case 1:
                        weather = "Hot";
                        break;
                    case 2:
                        weather = "Cold";
                        break;
                    case 3:
                        weather = "High Winds";
                        break;
                    case 4:
                        weather = "Heavy Snow";
                        break;
                    case 5:
                        weather = "Clear";
                        break;
                }
            }
            if (semester == 2)
            {
                Random random = new();
                int randomNum = random.Next(1, 6); // x, y-1
                switch (randomNum)
                {
                    case 1:
                        weather = "Hot";
                        break;
                    case 2:
                        weather = "Cold";
                        break;
                    case 3:
                        weather = "High Winds";
                        break;
                    case 4:
                        weather = "Heavy Rain";
                        break;
                    case 5:
                        weather = "Clear";
                        break;
                }
            }
        }

        public void NextEvent(double money, int semester, int skateboards,
            int food, int clothing, double study_guides, int skate_wheel,
            int skate_truck, int skate_bearing, double health,
            string name1, string name2, string name3, string name4)
        {

        }

    }
}

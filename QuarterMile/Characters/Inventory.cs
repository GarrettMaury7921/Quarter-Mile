
using QuarterMile.States;
using System;
using System.Diagnostics;
using System.Globalization;

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

        public bool _name1_dys;
        public bool _name2_dys;
        public bool _name3_dys;
        public bool _name4_dys;

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
        private int x;
        private int y;

        public bool name2Alive;
        public bool name3Alive;
        public bool name4Alive;

        public string status;

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

        public void Rest()
        {
            Random rand = new();
            int randomNum = rand.Next(1, 4); // x, y-1
            switch (randomNum)
            {
                // Good rest day
                case 1:
                    if (_health < 100)
                    {
                        _health += 20;
                        Random rand2 = new();
                        int randomNum2 = rand.Next(1, 3); // x, y-1
                        if (randomNum2 == 1)
                        {
                            _food -= 1;
                        }
                    }
                    break;
                // Okay
                case 2:
                    if (_health < 100)
                    {
                        _health += 18;
                        Random rand2 = new();
                        int randomNum2 = rand.Next(1, 3); // x, y-1
                        if (randomNum2 == 1)
                        {
                            _food -= 2;
                        }
                    }
                    break;
                // Not Great
                case 3:
                    if (_health < 100)
                    {
                        _health += 10;
                        Random rand2 = new Random();
                        int randomNum2 = rand.Next(1, 3); // x, y-1
                        if (randomNum2 == 1)
                        {
                            _food -= 3;
                        }
                    }
                    break;
            }

            day++;
        } // rest

        public void UpdateMonthAndDay(ref string month, ref int day, int year)
        {

            int lastDayOfMonth = DateTime.DaysInMonth(year, DateTime.ParseExact(month, "MMMM", CultureInfo.InvariantCulture).Month);

            if (day > lastDayOfMonth)
            {
                day -= lastDayOfMonth;
                var nextMonth = DateTime.ParseExact(month, "MMMM", CultureInfo.InvariantCulture).AddMonths(1);
                month = nextMonth.ToString("MMMM", CultureInfo.InvariantCulture);

                if (nextMonth.ToString("MMMM", CultureInfo.InvariantCulture) == "January")
                {
                    year++;
                }
            }
        }

        // Make sure player not dead / items gone
        public bool checkStats()
        {
            if (_health > 100)
            {
                _health = 100;
            }
            if (_health < 100 && _food > 0)
            {
                _food--;
                _health += 10;
            }
            if (_health <= 0)
            {
                return false;
            }
            if (_money <= 0)
            {
                _money = 0;
            }
            if (_skateboards <= 0)
            {
                _skateboards = 0;
            }
            if (_food <= 0)
            {
                _food = 0;
            }
            if (_clothing <= 0)
            {
                _clothing = 0;
            }
            if (_study_guides <= 0)
            {
                _study_guides = 0;
            }
            if (_skate_wheel <= 0)
            {
                _skate_wheel = 0;
            }
            if (_skate_truck <= 0)
            {
                _skate_truck = 0;
            }
            if (_skate_bearing <= 0)
            {
                _skate_bearing = 0;
            }

            return true;
        }

        private void setStatusMessage(string message)
        {
            status = message;
        }

        public void clearStatusMessage()
        {
            status = "";
        }

        public void NextEvent()
        {
            Random rand = new();
            int randomNum = rand.Next(1, 11); // x, y-1
            switch (randomNum)
            {
                // Catalytic Converter Thefts
                case 1:
                    setStatusMessage("Crime Alert - Catalytic Converter \nTheft from a Vehicle Parked \nin K Lot");
                    ActualGameState.statusMessage = true;
                    break;
                // Roll for dysentery
                case 2:
                    Random rand2 = new();
                    int randomNum2 = rand.Next(1, 4); // x, y-1
                    switch (randomNum2)
                    {
                        // Win
                        case 1:
                            break;
                        // Nope
                        case 2:
                            x = 0;
                            y = 0;
                            while (x == 0)
                            {
                                if (!_name1_dys || !_name2_dys || !_name3_dys || !_name4_dys)
                                {
                                    Random rand3 = new();
                                    int randomNum3 = rand.Next(1, 5); // x, y-1
                                    switch (randomNum3)
                                    {
                                        case 1:
                                            if (_name1_dys)
                                            {
                                                continue;
                                            }
                                            else
                                            {
                                                _name1_dys = true;
                                                x++;
                                                y++;
                                            }
                                            break;
                                        case 2:
                                            if (_name2_dys)
                                            {
                                                continue;
                                            }
                                            else
                                            {
                                                _name2_dys = true;
                                                x++;
                                                y = 2;
                                            }
                                            break;
                                        case 3:
                                            if (_name3_dys)
                                            {
                                                continue;
                                            }
                                            else
                                            {
                                                _name3_dys = true;
                                                x++;
                                                y = 3;
                                            }
                                            break;
                                        case 4:
                                            if (_name4_dys)
                                            {
                                                continue;
                                            }
                                            else
                                            {
                                                _name4_dys = true;
                                                x++;
                                                y = 4;
                                            }
                                            break;
                                    }
                                }
                            }
                            switch (y)
                            {
                                case 1:
                                    setStatusMessage(_name1 + "Has dysentery.");
                                    break;
                                case 2:
                                    setStatusMessage(_name2 + "Has dysentery.");
                                    break;
                                case 3:
                                    setStatusMessage(_name3 + "Has dysentery.");
                                    break;
                                case 4:
                                    setStatusMessage(_name4 + "Has dysentery.");
                                    break;
                            }
                            break;
                        // Nope
                        case 3:
                            x = 0;
                            y = 0;
                            while (x == 0)
                            {
                                if (!_name1_dys || !_name2_dys || !_name3_dys || !_name4_dys)
                                {
                                    Random rand3 = new();
                                    int randomNum3 = rand.Next(1, 5); // x, y-1
                                    switch (randomNum3)
                                    {
                                        case 1:
                                            if (_name1_dys)
                                            {
                                                continue;
                                            }
                                            else
                                            {
                                                _name1_dys = true;
                                                x++;
                                                y++;
                                            }
                                            break;
                                        case 2:
                                            if (_name2_dys)
                                            {
                                                continue;
                                            }
                                            else
                                            {
                                                _name2_dys = true;
                                                x++;
                                                y = 2;
                                            }
                                            break;
                                        case 3:
                                            if (_name3_dys)
                                            {
                                                continue;
                                            }
                                            else
                                            {
                                                _name3_dys = true;
                                                x++;
                                                y = 3;
                                            }
                                            break;
                                        case 4:
                                            if (_name4_dys)
                                            {
                                                continue;
                                            }
                                            else
                                            {
                                                _name4_dys = true;
                                                x++;
                                                y = 4;
                                            }
                                            break;
                                    }
                                }
                            }
                            switch (y)
                            {
                                case 1:
                                    setStatusMessage(_name1 + "Has dysentery.");
                                    break;
                                case 2:
                                    setStatusMessage(_name2 + "Has dysentery.");
                                    break;
                                case 3:
                                    setStatusMessage(_name3 + "Has dysentery.");
                                    break;
                                case 4:
                                    setStatusMessage(_name4 + "Has dysentery.");
                                    break;
                            }
                            break;
                    }
                    break;
                // Weather Change
                case 3:
                    StartingWeather(_semester);
                    break;
                // Bad Weather check
                case 4:
                    switch (weather)
                    {
                        case "Hot":
                            setStatusMessage("Too hot, lose clothing!");
                            _clothing--;
                            ActualGameState.statusMessage = true;
                            break;
                        case "Cold":
                            setStatusMessage("Too cold! " + _name2 + " dies!");
                            ActualGameState.statusMessage = true;
                            break;
                        case "High Winds":
                            break;
                        case "Heavy Snow":
                            break;
                        case "Clear":
                            break;
                    }
                    break;
                // RIT Bear Incident!!
                case 5:
                    setStatusMessage("RIT Bear Incident.");
                    ActualGameState.statusMessage = true;
                    _health -= 20;
                    break;
                default:
                    break;
            } // switch

        } // next event

    }
}

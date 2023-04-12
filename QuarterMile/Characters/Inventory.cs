
namespace QuarterMile.Characters
{
    internal class Inventory
    {

        // Attributes
        private double _money;
        private int _semester;
        private int _skateboards;
        private int _food;
        private int _clothing;
        private double _study_guides;
        private int _skate_wheel;
        private int _skate_truck;
        private int _skate_bearing;
        private double _health;
        private string _name1;
        private string _name2;
        private string _name3;
        private string _name4;

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

            InitialStats(money, semester, skateboards, food, clothing, study_guides, skate_wheel, skate_truck, skate_bearing, health,
                name1, name2, name3, name4);

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

    }
}

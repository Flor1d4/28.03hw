using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _28._03hww
{
  
    abstract class MilitaryUn
    {
        public string Image 
        { 
            get; 
            set;
        }
        public int Speed 
        { 
            get;
            set;
        }
        public int Power
        {
            get;
            set; 
        }
        public abstract void Show(int x, int y);
    }
    class LightInfantry : MilitaryUn
    {
        public LightInfantry()
        {
            Image = "Легкая пехота.jpg";
            Speed = 20;
            Power = 10;
        }
        public override void Show(int x, int y)
        {
            Console.WriteLine($"Легкая пехота ({x}, {y})");
        }
    }
    class TransportVehicle : MilitaryUn
    {
        public TransportVehicle()
        {
            Image = "Транспортные автомашины.jpg";
            Speed = 70;
            Power = 0;
        }
        public override void Show(int x, int y)
        {
            Console.WriteLine($"Транспортные автомашины ({x}, {y})");
        }
    }
    class HeavyGroundVehicle : MilitaryUn
    {
        public HeavyGroundVehicle()
        {
            Image = "Тяжелая наземная боевая техника.jpg";
            Speed = 15;
            Power = 150;
        }
        public override void Show(int x, int y)
        {
            Console.WriteLine($"Тяжелая наземная боевая техника ({x}, {y})");
        }
    }
    class LightGroundVehicle : MilitaryUn
    {
        public LightGroundVehicle()
        {
            Image = " Легкая наземная боевая техника.jpg";
            Speed = 50;
            Power = 30;
        }
        public override void Show(int x, int y)
        {
            Console.WriteLine($" Легкая наземная боевая техника ({x}, {y})");
        }
    }
    class Aircraft : MilitaryUn
    {
        public Aircraft()
        {
            Image = " Авиатехника.jpg";
            Speed = 300;
            Power = 100;
        }
        public override void Show(int x, int y)
        {
            Console.WriteLine($" Авиатехника ({x}, {y})");
        }
    }

    class MilitaryUnitFactory
    {
        private Dictionary<string, MilitaryUn> units = new Dictionary<string, MilitaryUn>();

        public MilitaryUn GetUnit(string type)
        {
            if (units.ContainsKey(type))
            {
                return units[type];
            }
            else
            {
                MilitaryUn unit;
                switch (type)
                {
                    case "Легкая пехота":
                        unit = new LightInfantry();
                        break;
                    case "Транспортные автомашины":
                        unit = new TransportVehicle();
                        break;
                    case "Тяжелая наземная боевая техника":
                        unit = new HeavyGroundVehicle();
                        break;
                    case " Легкая наземная боевая техника":
                        unit = new LightGroundVehicle();
                        break;
                    case " Авиатехника":
                        unit = new Aircraft();
                        break;
                    default:
                        throw new ArgumentException("Неверный юнит");
                }
                units.Add(type, unit);
                return unit;
            }
        }
    }
    internal class Program
    {
        static void Main(string[] args)
        {
            Map map = new Map();

            map.AddUnit("Легкая пехота", 20, 10);
            map.AddUnit("Транспортные автомашины", 70, 0);
            map.AddUnit("Тяжелая наземная боевая техника", 15, 150);           
            map.AddUnit("Легкая наземная боевая техника", 50, 30);
            map.AddUnit("Авиатехника", 300, 100);

            Console.ReadKey();
        }
    }
    class Map
    {
        private MilitaryUnitFactory factory = new MilitaryUnitFactory();

        public void AddUnit(string type, int x, int y)
        {
            MilitaryUn unit = factory.GetUnit(type);
            unit.Show(x, y);
        }
    }
}

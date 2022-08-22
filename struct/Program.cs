using System;

namespace structs
{
    class Program
    {
        static void Main(string[] args)
        {
            Coordinates point = new();
            point.CoordinateChange += changeCoordinate;
            point.x = 5;
            point.y = 7;
            point.x = 34;
            point.y = 56;
            point.distance();
            point.setOrigin();

        }

        public static void changeCoordinate(string axis, int oldpoint, int newpoint)
        {
            Console.WriteLine($"The was a change on the {axis}-axis from {oldpoint}units to {newpoint}units");
        }
    }

    struct Coordinates {
        private int _x, _y;
        public event Action<string, int, int> CoordinateChange;
        
        
        public int x
        {
            get
            {
                return _x;
            }
            set
            {
                int o = _x;
                _x = value;
                CoordinateChange?.Invoke("X",o, _x);
            }
        }
        public int y
        {
            get
            {
                return _y;
            }
            set
            {
                int o = _y;
                _y = value;
                CoordinateChange?.Invoke("Y", o, _y);
            }
        }
        public void setOrigin()
        {
            x = 0;
            y = 0;
        }
        public void distance()
        {
            double result = Math.Sqrt((_x * _x) + (_y * _y));
            Console.WriteLine($"The distance between {_x}(x-axis) and {_y}(y-axis) is {result}");
        }

        
        
    
    }

}

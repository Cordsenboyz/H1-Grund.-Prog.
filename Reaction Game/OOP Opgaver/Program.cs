using System;

namespace OOP_Opgaver
{

    class DistanceBetween
    {
        double x, y;
        DistanceBetween(double x, double y)
        {
            this.x = x;
            this.y = x;
        }
        double getDistance()
        {
            return (x - y);
        }
        static void Main(string[] args)
        {
            DistanceBetween r = new DistanceBetween(15, 10);
            Console.WriteLine(r.getDistance());

        }
    }
}

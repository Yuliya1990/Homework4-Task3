using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task3
{
    public abstract class Triangle
    {
        private double[] Side = new double[3];
        private double[] angles = new double[3];
        public Triangle(double side0, double side1, double side2)
        {
            if (IsTriangleExist(side0, side1, side2))
            {
                Side[0] = side0; Side[1] = side1; Side[2] = side2;
            }
            else throw new Exception("Triangle doesn`t exist");
        }

        private bool IsTriangleExist(double side0, double side1, double side2)
        {
            if (side0 > 0 && side1 > 0 && side2 > 0)
            {
                if (side0 + side1 > side2 && side0 + side2 > side1 && side1 + side2 > side0)
                    return true;
            }
            return false;
        }
        public double Perimetr()
        {
            double perimetr = 0;
            for (int i = 0; i < 2; i++)
            {
                perimetr += Side[i];
            }
            return perimetr;
        }
        public virtual double[] GetAngles()
        {
            angles[0] = Math.Acos((Math.Pow(Side[0], 2) + Math.Pow(Side[2], 2) - Math.Pow(Side[1], 2))
                / (2 * Side[0] * Side[2])) * 180 / Math.PI;
            //angle between sides 0 and 2
            angles[1] = Math.Acos((Math.Pow(Side[0], 2) + Math.Pow(Side[1], 2) - Math.Pow(Side[2], 2))
                / (2 * Side[0] * Side[1])) * 180 / Math.PI;
            //angle between sides 0 and 1
            angles[2] = 180 - angles[0] - angles[1];
            return angles;
        }
        public double CalculateArea()
        {
            double angle = 0; //btw side0 and side1
            double area = 0;
            angle = Math.Acos((Math.Pow(Side[0], 2) + Math.Pow(Side[1], 2) - Math.Pow(Side[2], 2))
                 / (2 * Side[0] * Side[1])) * 180 / Math.PI;
            area = Side[0] * Side[1] * Math.Sin(angle) / 2;
            return area;
        }
    }
    public class RightTriangle: Triangle
    {
        public RightTriangle(double side1, double side2, double hyppotenuse):base(side1, side2, hyppotenuse)
        {}
    }
    public class IsoscelesTriangle : Triangle
    {
        public IsoscelesTriangle(double side1, double side2) : base(side1, side1, side2) { }
    }
}

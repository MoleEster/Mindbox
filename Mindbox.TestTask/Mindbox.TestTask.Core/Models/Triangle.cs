using Mindbox.TestTask.Core.Abstract;

namespace Mindbox.TestTask.Core.Models
{
    public class Triangle : IGeometry
    {
        private double xy { get; set; }
        private double yz { get; set; }
        private double zx { get; set; }

        /// <summary>
        /// Первая сторона треугольника
        /// </summary>
        public double XY
        {
            get => xy;
            set
            {
                if (value < 0)
                {
                    throw new ArgumentException("Value can not be negative");
                }
                xy = value;
            }
        }

        /// <summary>
        /// Вторая сторона треугольника
        /// </summary>
        public double YZ
        {
            get => yz;
            set
            {
                if (value < 0)
                {
                    throw new ArgumentException("Value can not be negative");
                }
                yz = value;
            }
        }

        /// <summary>
        /// Третья сторона треугольника
        /// </summary>
        public double ZX
        {
            get => zx;
            set
            {
                if (value < 0)
                {
                    throw new ArgumentException("Value can not be negative");
                }
                zx = value;
            }
        }

        /// <summary>
        /// Вычисление площади треугольника
        /// </summary>
        /// <returns> Площадь треугольника</returns>
        public double GetSquare()
        {
            if (xy != 0 && yz != 0 && zx != 0)
            {
                var square = SquareForRectengular();
                if (square == null)
                {
                    var halfPerimetr = (xy + yz + zx) / 2;
                    square = Math.Sqrt(halfPerimetr * (halfPerimetr - xy) * (halfPerimetr - yz) * (halfPerimetr - zx));
                }
                return square.Value;
            }
            else
            {
                return 0;
            }
        }

        /// <summary>
        /// Вычисление площади для прямоугольного треугольника
        /// </summary>
        /// <returns>Площадь треугольника, если он прямоугольный, null, если нет</returns>
        private double? SquareForRectengular()
        {
            var sides = new List<double>() { xy, zx, yz };
            var maxSide = sides.OrderByDescending(x => x).First();

            double otherSidesPowSum = 0;
            for (int i = 1; i < sides.Count; i++)
            {
                otherSidesPowSum += Math.Pow(sides[i], 2);
            }

            bool isRectangular = Math.Pow(maxSide, 2) == otherSidesPowSum;

            if (isRectangular)
            {
                double square = 1;
                for (int i = 1; i < sides.Count; i++)
                {
                    square *= sides[i];
                }
                return square / 2;
            }
            else
            {
                return null;
            }
        }
    }
}

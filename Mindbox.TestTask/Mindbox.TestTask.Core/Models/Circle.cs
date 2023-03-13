using Mindbox.TestTask.Core.Abstract;

namespace Mindbox.TestTask.Core.Models
{
    public class Circle : IGeometry
    {
        private double radius { get; set; }

        /// <summary>
        /// Радиус круга
        /// </summary>
        public double Radius
        {
            get
            {
                return radius;
            }
            set
            {
                if(value < 0)
                {
                    throw new ArgumentException("Value can not be negative");
                }
                radius = value;
            }
        }

        /// <summary>
        /// Вычисление площади по радиусу
        /// </summary>
        /// <returns> Площадь круга по радиусу</returns>
        public double GetSquare()
        {
            if(radius == 0)
            {
                return 0;
            }
            
            return Math.PI * Math.Pow(radius, 2);
        }
    }
}

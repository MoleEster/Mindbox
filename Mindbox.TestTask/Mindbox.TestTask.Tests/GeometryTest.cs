using Mindbox.TestTask.Core.Abstract;
using Mindbox.TestTask.Core.Models;
using NUnit.Framework;

namespace Mindbox.TestTask.Tests
{
    public class Tests
    {

        #region Circle Tests

        [Test]
        public void Should_ThrowException_On_IncorrectInput_Cicrle()
        {
            try
            {
                var circle = new Circle()
                {
                    Radius = -1,
                };
            }
            catch (Exception ex)
            {
                if (ex is ArgumentException)
                {
                    Assert.Pass();
                }
                else
                {
                    Assert.Fail();
                }
            }
        }

        [Test]
        public void Should_Pass_On_CorrectInput_Cicrle()
        {
            var circle = new Circle()
            {
                Radius = 5,
            };

            var expectedSquare = 25 * Math.PI;
            var actualSquare = circle.GetSquare();

            Assert.That(expectedSquare, Is.EqualTo(actualSquare));

        }

        #endregion

        #region Triangle Tests

        [Test]
        public void Should_ThrowException_On_IncorrectInput_Triangle()
        {
            int correctExceptionsCounter = 0;
            try
            {
                var triangle = new Triangle()
                {
                    XY = -1,
                    YZ = 1,
                    ZX = 1
                };
            }
            catch (Exception ex)
            {
                if (ex is ArgumentException)
                {
                    correctExceptionsCounter++;
                }
                else
                {
                    Assert.Fail();
                }
            }

            try
            {
                var triangle = new Triangle()
                {
                    XY = 1,
                    YZ = -1,
                    ZX = 1
                };
            }
            catch (Exception ex)
            {
                if (ex is ArgumentException)
                {
                    correctExceptionsCounter++;
                }
                else
                {
                    Assert.Fail();
                }
            }

            try
            {
                var triangle = new Triangle()
                {
                    XY = 1,
                    YZ = 1,
                    ZX = -1
                };
            }
            catch (Exception ex)
            {
                if (ex is ArgumentException)
                {
                    correctExceptionsCounter++;
                }
                else
                {
                    Assert.Fail();
                }
            }

            Assert.IsTrue(correctExceptionsCounter == 3);
        }

        [Test]
        public void Should_Pass_On_CorrectInput_Triangle()
        {
            var triangle = new Triangle()
            {
                XY = 1,
                YZ = 1,
                ZX = 1
            };

            double correctHalfPerimeter = (triangle.XY + triangle.YZ + triangle.ZX) / 2;

            var expectedSquare = Math.Sqrt(correctHalfPerimeter * (correctHalfPerimeter - 1) * (correctHalfPerimeter - 1) * (correctHalfPerimeter - 1));

            var actualSquare = triangle.GetSquare();

            Assert.That(expectedSquare, Is.EqualTo(actualSquare));
        }
        #endregion

        [Test]
        public void Should_Pass_On_DifferentModels()
        {
            IGeometry figure = new Circle
            {
                Radius = 5,
            };

            var expectedSquare = 25 * Math.PI;
            var actualSquare = figure.GetSquare();

            Assert.That(expectedSquare, Is.EqualTo(actualSquare));

            figure = new Triangle
            {
                XY = 1,
                YZ = 1,
                ZX = 1,
            };

            double correctHalfPerimeter = 1.5;

            expectedSquare = Math.Sqrt(correctHalfPerimeter * (correctHalfPerimeter - 1) * (correctHalfPerimeter - 1) * (correctHalfPerimeter - 1));

            actualSquare = figure.GetSquare();

            Assert.That(expectedSquare, Is.EqualTo(actualSquare));

        }
    }
}
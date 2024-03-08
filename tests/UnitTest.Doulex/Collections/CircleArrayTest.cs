using Doulex.Collections;

namespace UnitTest.Doulex.Collections
{
    public class CircleArrayTests
    {
        [Fact]
        public void TestCircleArrayAdd()
        {
            // Arrange
            var circleArray = new CircleArray<int>(3);

            // Act
            circleArray.Add(1);
            circleArray.Add(2);
            circleArray.Add(3);
            circleArray.Add(4);

            // Assert
            var expectedArray = new[] { 2, 3, 4 };
            Assert.Equal(expectedArray, circleArray.ToArray());
        }

        [Fact]
        public void TestCircleArrayClear()
        {
            // Arrange
            var circleArray = new CircleArray<int>(3);
            circleArray.Add(1);
            circleArray.Add(2);
            circleArray.Add(3);

            // Act
            circleArray.Clear();

            // Assert
            var expectedArray = Array.Empty<int>();
            Assert.Equal(expectedArray, circleArray.ToArray());
        }

        [Fact]
        public void TestCircleArrayGetEnumerator()
        {
            // Arrange
            var circleArray = new CircleArray<int>(3);
            circleArray.Add(1);
            circleArray.Add(2);
            circleArray.Add(3);

            // Act
            var enumerator = circleArray.GetEnumerator();
            var resultList = new List<int>();
            while (enumerator.MoveNext())
            {
                resultList.Add(enumerator.Current);
            }

            // Assert
            var expectedArray = new[] { 1, 2, 3 };
            Assert.Equal(expectedArray, resultList);
        }

        [Fact]
        public void TestCircleArrayConstructorWithInvalidSize()
        {
            // Arrange & Act & Assert
            Assert.Throws<ArgumentOutOfRangeException>(() => new CircleArray<int>(-1));
        }
    }
}

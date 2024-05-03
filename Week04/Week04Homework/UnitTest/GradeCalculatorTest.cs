using NUnit.Framework;
using NUnit.Framework.Legacy;
using Week04Homework.Source;

[TestFixture]
public class GradeCalculatorTest
{
    private GradeCalculator calculator;

    [SetUp]
    public void Setup()
    {
        calculator = new GradeCalculator();
    }

    [Test]
    public void TestGradeShouldReturnWithA()
    {
        // Arrange
        int score = 95;
        string expectedResult = "A";

        // Act
        string grade = calculator.CalculateGrade(score);

        // Assert
        ClassicAssert.AreEqual(expectedResult, grade);
    }

    [Test]
    public void TestGradeShouldReturnWithB()
    {
        // Arrange
        int score = 85;
        string expectedResult = "B";

        // Act
        string grade = calculator.CalculateGrade(score);

        // Assert
        ClassicAssert.AreEqual(expectedResult, grade);
    }

    [Test]
    public void TestGradeShouldReturnWithC()
    {
        // Arrange
        int score = 75;
        string expectedResult = "C";

        // Act
        string grade = calculator.CalculateGrade(score);

        // Assert
        ClassicAssert.AreEqual(expectedResult, grade);
    }

    [Test]
    public void TestGradeShouldReturnWithD()
    {
        // Arrange
        int score = 65;
        string expectedResult = "D";

        // Act
        string grade = calculator.CalculateGrade(score);

        // Assert
        ClassicAssert.AreEqual(expectedResult, grade);
    }
}
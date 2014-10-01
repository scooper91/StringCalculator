using NUnit.Framework;

namespace StringCalculator.Tests
{
	public class StringCalculatorTests
	{
		[TestCase("0", 0)]
		[TestCase("1", 1)]
		[TestCase("2", 2)]
		public void Should_Return_Single_Number_When_Single_Number_Entered(
			string number, int expectedOutcome)
		{
			var calculator = new Calculator();
			calculator.Add(number);

			Assert.That(calculator.Total(), Is.EqualTo(expectedOutcome));
		}

		[Test]
		public void Should_Return_2_When_11_Entered()
		{
			var calculator = new Calculator();
			calculator.Add("1,1");

			Assert.That(calculator.Total(), Is.EqualTo(2));
		}

		[Test]
		public void Should_Return_5_When_Numbers_Entered()
		{
			var calculator = new Calculator();
			calculator.Add("1,0,2,2");

			Assert.That(calculator.Total(), Is.EqualTo(5));
		}

		[Test]
		public void Should_Return_Total_When_New_Lines_Between_Numbers()
		{
			var calculator = new Calculator();
			calculator.Add("1\n2");

			Assert.That(calculator.Total(), Is.EqualTo(3));
		}
	}
}
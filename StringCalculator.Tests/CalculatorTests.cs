using System;
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

			Assert.That(calculator.Add(number), Is.EqualTo(expectedOutcome));
		}

		[Test]
		public void Should_Return_2_When_1_and_1_Entered()
		{
			var calculator = new Calculator();

			Assert.That(calculator.Add("1,1"), Is.EqualTo(2));
		}

		[Test]
		public void Should_Return_sum_when_multiple_numbers_entered()
		{
			var calculator = new Calculator();

			Assert.That(calculator.Add("1,0,2,2"), Is.EqualTo(5));
		}

		[Test]
		public void Should_Return_Sum_When_New_Lines_Between_Numbers()
		{
			var calculator = new Calculator();

			Assert.That(calculator.Add("1\n2"), Is.EqualTo(3));
		}

		[TestCase("//;\n1;2", 3)]
		[TestCase("//s\n3s4", 7)]
		public void Should_Return_Sum_When_Custom_Delimiter_Is_Defined(
			string numbers, int expectedOutcome)
		{
			var calculator = new Calculator();

			Assert.That(calculator.Add(numbers), Is.EqualTo(expectedOutcome));
		}

		[Test]
		public void Should_return_sum_when_two_delimiters_are_used()
		{
			var calculator = new Calculator();

			Assert.That(calculator.Add("//s\n3s4,5"), Is.EqualTo(12));
		}

		[TestCase("-1", "Negatives are not allowed => -1")]
		[TestCase("-2, -1", "Negatives are not allowed => -2,-1")]
		public void Should_throw_exception_if_negative_number_used(
			string negativeNumbers, string errorMessage)
		{
			var calculator = new Calculator();

			Assert.That(() => calculator.Add(negativeNumbers),
				Throws.TypeOf<Exception>()
					.With.Message.StringContaining(errorMessage));
		}

		[TestCase("1000,1", 1001)]
		[TestCase("1001,1", 1)]
		[TestCase("30000, 2000, 2", 2)]
		public void Should_ignore_numbers_greater_than_1000(string numbers, int expectedOutcome)
		{
			var calculator = new Calculator();

			Assert.That(calculator.Add(numbers), Is.EqualTo(expectedOutcome));
		}

		[TestCase("//[..]\n1..1", 2)]
		[TestCase("//[...]\n1...1", 2)]
		[TestCase("//[abcde]\n1abcde2", 3)]
		public void Should_be_able_to_use_custom_length_delimiters(string numbers, int expectedOutcome)
		{
			var calculator = new Calculator();
			
			Assert.That(calculator.Add(numbers), Is.EqualTo(expectedOutcome));
		}

		[Test, Ignore]
		public void Should_be_able_to_use_more_than_1_delimiter()
		{
			var calculator = new Calculator();

			Assert.That(calculator.Add("//[-][=]\n1-1=1"), Is.EqualTo(3));
		}
	}
}
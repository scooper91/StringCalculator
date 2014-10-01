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
		public void Should_Return_2_When_11_Entered()
		{
			var calculator = new Calculator();

			Assert.That(calculator.Add("1,1"), Is.EqualTo(2));
		}

		[Test]
		public void Should_Return_5_When_Numbers_Entered()
		{
			var calculator = new Calculator();

			Assert.That(calculator.Add("1,0,2,2"), Is.EqualTo(5));
		}

		[Test]
		public void Should_Return_Total_When_New_Lines_Between_Numbers()
		{
			var calculator = new Calculator();

			Assert.That(calculator.Add("1\n2"), Is.EqualTo(3));
		}

		[Test]
		public void Should_Return_Total_When_Custom_Delimiter_Is_Defined()
		{
			var calculator = new Calculator();

			Assert.That(calculator.Add("//;\n1;2"), Is.EqualTo(3));
		}

		[Test]
		public void Should_return_total_when_custom_delimiter_is_defined_2()
		{
			var calculator = new Calculator();

			Assert.That(calculator.Add("//s\n3s4"), Is.EqualTo(7));
		}

		[Test]
		public void Should_return_total_when_two_delimiters_are_used()
		{
			var calculator = new Calculator();

			Assert.That(calculator.Add("//s\n3s4,5"), Is.EqualTo(12));
		}

		[Test]
		public void Should_throw_exception_if_negative_number_used()
		{
			var calculator = new Calculator();

			Assert.That(() => calculator.Add("-1"), Throws.TypeOf<Exception>());
		}

		[Test]
		public void Should_throw_exception_if_negative_number_used2()
		{
			var calculator = new Calculator();

			Assert.That(() => calculator.Add("-2, -1"), Throws.TypeOf<Exception>());
		}
	
		[Test]
		public void Should_throw_exception_if_negative_number_used3()
		{
			var calculator = new Calculator();

			Assert.That(() => calculator.Add("-1, 2"), Throws.TypeOf<Exception>().With.Message.StringContaining("Negatives not allowed"));
		}
	}
}
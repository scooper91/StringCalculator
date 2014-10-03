using System;
using System.Collections.Generic;
using System.Linq;

namespace StringCalculator
{
	public class Calculator
	{
		private const string CustomDelimiterIndicator = "//";

		private readonly List<string> _delimiters = new List<string> { ",", "\n" };

		public int Add(string delimitedNumbers)
		{
			AddAnyCustomDelimiter(delimitedNumbers);

			ErrorIfAnyNegative(delimitedNumbers);

			return SelectNumbersFrom(delimitedNumbers).Sum();
		}

		private void AddAnyCustomDelimiter(string delimitedNumbers)
		{
			//foreach (char delimitedValue in delimitedNumbers)
			//{
			//	if (delimitedValue == '[')
			//	{
			//		_delimiters.Add(delimitedNumbers.Substring(delimitedNumbers.IndexOf('[', delimitedValue) + 1,
			//			(delimitedNumbers.IndexOf(']', delimitedValue) -
			//				(delimitedNumbers.IndexOf('[', delimitedValue) + 1))));
			//	}
			//}

			if (delimitedNumbers.StartsWith(CustomDelimiterIndicator + '['))
			{
				var delimiter = delimitedNumbers.Substring(3, delimitedNumbers.IndexOf('\n') - 4);
				_delimiters.Add(delimiter);
			}
			else if (delimitedNumbers.StartsWith(CustomDelimiterIndicator))
			{
				_delimiters.Add(delimitedNumbers[2].ToString());
			}
		}

		private void ErrorIfAnyNegative(string delimitedNumbers)
		{
			var negativeNumbers = SelectNumbersFrom(delimitedNumbers)
				.Where(number => number < 0)
				.ToList();

			if (negativeNumbers.Any())
			{
				var listOfNegatives = string.Join(",", negativeNumbers);
				throw new Exception("Negatives are not allowed => " + listOfNegatives);
			}
		}

		private IEnumerable<int> SelectNumbersFrom(string delimitedNumbers)
		{
			var startIndex = delimitedNumbers.IndexOf('\n') + 1;
			var body = delimitedNumbers.StartsWith(CustomDelimiterIndicator)
				? delimitedNumbers.Substring(startIndex)
				: delimitedNumbers;

			return body
				.Split(_delimiters.ToArray(), StringSplitOptions.None)
				.Select(int.Parse)
				.Where(number => number <= 1000);
		}
	}
}
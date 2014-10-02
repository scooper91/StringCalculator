using System;
using System.Collections.Generic;
using System.Linq;

namespace StringCalculator
{
	public class Calculator
	{
		private const string CustomDelimiterIndicator = "//";

		private readonly List<char> _delimiters = new List<char> { ',', '\n' };

		public int Add(string delimitedNumbers)
		{
			AddAnyCustomDelimiter(delimitedNumbers);

			ErrorIfAnyNegative(delimitedNumbers);

			return SelectNumbersFrom(delimitedNumbers).Sum();
		}

		private void AddAnyCustomDelimiter(string delimitedNumbers)
		{
			if (delimitedNumbers.StartsWith(CustomDelimiterIndicator))
			{
				_delimiters.Add(delimitedNumbers[2]);
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
			var body = delimitedNumbers.StartsWith(CustomDelimiterIndicator)
				? delimitedNumbers.Substring(4)
				: delimitedNumbers;

			return body
				.Split(_delimiters.ToArray())
				.Select(int.Parse);
		}
	}
}
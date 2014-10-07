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
			if (delimitedNumbers.StartsWith(CustomDelimiterIndicator))
			{
				var lineBreakIndex = delimitedNumbers.IndexOf('\n') - 2;
				var customDelimiters = delimitedNumbers.Substring(2, lineBreakIndex).Split('[');

				foreach (var delimiter in customDelimiters)
				{
						_delimiters.Add(delimiter.Trim(']'));
				}

				// HACK
				_delimiters.Remove("");
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
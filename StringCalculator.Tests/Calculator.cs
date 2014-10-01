using System.Collections.Generic;
using System.Linq;

namespace StringCalculator.Tests
{
	public class Calculator
	{
		public IEnumerable<int> StringToNumbers;
		public int AddNumbers;

		public int Total()
		{
			return AddNumbers;
		}

		public void Add(string numbers)
		{
			StringToNumbers = numbers.Split(',', '\n').Select(int.Parse);
			foreach (var stringToNumber in StringToNumbers)
			{
				AddNumbers += stringToNumber;
			}
		}
	}
}
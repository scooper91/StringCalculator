using System;
using System.Collections.Generic;
using System.Linq;

namespace StringCalculator.Tests
{
	public class Calculator
	{
		public IList<char> Delimiters;

		public int Add(string data)
		{
			IList<char> customDelimiter = new List<char>
			{
				',', '\n'
			};

			for (var i = 0; i < data.Count(); i += 5)
			{
				if (data[i] == '/')
				{
					customDelimiter.Add(data[i + 2]);
					data = data.Remove(0, 4);
				}
				else
				{
					customDelimiter.Add(',');
				}
			}

			var parts = data.Split(
				customDelimiter[0], 
				customDelimiter[1], 
				customDelimiter[2])
				.Select(int.Parse);

			foreach (int part in parts)
			{
				if (part < 0)
				{
					throw new Exception();
				}
			}

			return parts.Sum();
		}
	}
}
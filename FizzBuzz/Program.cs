using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FizzBuzz;
using NUnit.Framework;

namespace FizzBuzz
{
    class Program
    {
        static void Main(string[] args)
        {
            var config = new Tuple<int, string>[]
            {
                    new Tuple<int, string>(3, "Fizz"),
                    new Tuple<int, string>(5, "Buzz"),
                    new Tuple<int, string>(9, "Foo"),
                    new Tuple<int, string>(10, "Bar")
            };

            StringBuilder output = new StringBuilder();

            for (var i = 1; i <= 100; i++)
            {
                output.AppendLine(Program.GenerateOutput(i, config));
            }

            Console.WriteLine(output);
        }

        internal static string GenerateOutput(int i, Tuple<int, string>[] config)
        {
            var line = new StringBuilder();
            bool isDivisible = false;

            foreach (Tuple<int, string> tuple in config)
            {
                if (i % tuple.Item1 == 0)
                {
                    line.Append(tuple.Item2);
                    isDivisible = true;
                }
            }

            if (!isDivisible)
            {
                line.Append($"{i}");
            }

            return line.ToString();
        }
    }
}

namespace FizzBuzzTests
{
    [TestFixture]
    public class ProgramTests
    {
        [TestCase(1, "1")]
        [TestCase(2, "2")]
        [TestCase(3, "Fizz")]
        [TestCase(4, "4")]
        [TestCase(5, "Buzz")]
        [TestCase(6, "Fizz")]
        [TestCase(7, "7")]
        [TestCase(8, "8")]
        [TestCase(9, "FizzFoo")]
        [TestCase(10, "BuzzBar")]
        [TestCase(11, "11")]
        [TestCase(12, "Fizz")]
        [TestCase(13, "13")]
        [TestCase(14, "14")]
        [TestCase(15, "FizzBuzz")]
        [TestCase(30, "FizzBuzzBar")]
        [TestCase(45, "FizzBuzzFoo")]
        [TestCase(50, "BuzzBar")]
        [TestCase(90, "FizzBuzzFooBar")]
        public void GenerateOutputTest(int input, string expectedOutput)
        {
            // Arrange

            var config = new Tuple<int, string>[]
            {
                    new Tuple<int, string>(3, "Fizz"),
                    new Tuple<int, string>(5, "Buzz"),
                    new Tuple<int, string>(9, "Foo"),
                    new Tuple<int, string>(10, "Bar")
            };

            // Act

            string line = Program.GenerateOutput(input, config);

            // Assert

            string actualOutput = line.ToString().Trim();
            Assert.AreEqual(expectedOutput, actualOutput);
        }
    }
}

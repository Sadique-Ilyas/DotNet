using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BasicMathOperations.NUnitTest
{
	[TestFixture]
	public class BasicMathTests
	{
		BasicMath basicMath = new BasicMath();
		int num1 = 10;
		int num2 = 5;

		[SetUp]
		public void SetUp()
		{
            Console.WriteLine("Executed before running each test");
        }

		[Test]
		public void BasicMath_Add_ReturnsSum()
		{
			int sum = basicMath.Add(num1, num2);
			Assert.That(sum, Is.EqualTo(15));
		}

		[Test]
		public void BasicMath_Subtract_ReturnsDifference()
		{
			int difference = basicMath.Subtract(num1, num2);
			Assert.That(difference, Is.EqualTo(5));
		}

		[Test]
		public void BasicMath_Multiply_ReturnsProduct()
		{
			int product = basicMath.Multiply(num1, num2);
			Assert.That(product, Is.EqualTo(50));
		}

		[Test]
		public void BasicMath_Divide_ReturnsQuotient()
		{
			int quotient = basicMath.Divide(num1, num2);
			Assert.That(quotient, Is.EqualTo(2));
		}

		[TearDown]
		public void TearDown()
		{
			Console.WriteLine("Executed after running each test");
		}
	}
}

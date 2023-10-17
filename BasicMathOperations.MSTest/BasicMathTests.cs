using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace BasicMathOperations.MSTest
{
	[TestClass]
	public class BasicMathTests
	{
		BasicMath basicMath = new BasicMath();
		int num1 = 10;
		int num2 = 5;
		[TestMethod]
		public void BasicMath_Add_ReturnsSum()
		{
			int sum = basicMath.Add(num1, num2);
			Assert.AreEqual(15, sum);
		}

		[TestMethod]
		public void BasicMath_Subtract_ReturnsDifference()
		{
			int difference = basicMath.Subtract(num1, num2);
			Assert.AreEqual(5, difference);
		}

		[TestMethod]
		public void BasicMath_Multiply_ReturnsProduct()
		{
			int product = basicMath.Multiply(num1, num2);
			Assert.AreEqual(50, product);
		}

		[TestMethod]
		public void BasicMath_Divide_ReturnsQuotient()
		{
			int quotient = basicMath.Divide(num1, num2);
			Assert.AreEqual(2, quotient);
		}
	}
}

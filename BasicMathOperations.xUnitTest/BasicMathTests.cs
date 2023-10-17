namespace BasicMathOperations.xUnitTest
{
	public class BasicMathTests
	{
		BasicMath basicMath = new BasicMath();
		int num1 = 10;
		int num2 = 5;

		[Fact]
		public void BasicMath_Add_ReturnsSum()
		{
			int sum = basicMath.Add(num1, num2);
			Assert.Equal(15, sum);
		}

		[Fact]
		public void BasicMath_Subtract_ReturnsDifference()
		{
			int difference = basicMath.Subtract(num1, num2);
			Assert.Equal(5, difference);
		}

		[Fact]
		public void BasicMath_Multiply_ReturnsProduct()
		{
			int product = basicMath.Multiply(num1, num2);
			Assert.Equal(50, product);
		}

		[Fact]
		public void BasicMath_Divide_ReturnsQuotient()
		{
			int quotient = basicMath.Divide(num1, num2);
			Assert.Equal(2, quotient);
		}
	}
}

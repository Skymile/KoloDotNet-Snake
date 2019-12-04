using DotNetTest;

using NUnit.Framework;

namespace NUnitTestProject1
{
	public class Tests
	{
		[SetUp]
		public void Setup()
		{
		}

		[Test]
		public void Test1()
		{
			var sample = new UnitTestSample();

			Assert.True(sample.A() == 4);
			Assert.False(sample.A() != 4);
		}

		[Test]
		public void Test2()
		{
			var sample = new UnitTestSample();

			Assert.True(sample.A() == 2);
		}
	}
}
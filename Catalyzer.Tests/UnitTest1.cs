using Catalyzer.Cryptography;
using NUnit.Framework;

namespace Catalyzer.Tests
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
            var input = "hello";
            Assert.AreEqual(input.MD5(), "5D41402ABC4B2A76B9719D911017C592");
            Assert.AreEqual(input.SHA1(), "AAF4C61DDCC5E8A2DABEDE0F3B482CD9AEA9434D");
            Assert.AreEqual(input.SHA256(), "2CF24DBA5FB0A30E26E83B2AC5B9E29E1B161E5C1FA7425E73043362938B9824");
            Assert.AreEqual(input.SHA384(), "59E1748777448C69DE6B800D7A33BBFB9FF1B463E44354C3553BCDB9C666FA90125A3C79F90397BDF5F6A13DE828684F");
            Assert.AreEqual(input.SHA512(), "9B71D224BD62F3785D96D46AD3EA3D73319BFBC2890CAADAE2DFF72519673CA72323C3D99BA5C11D7C7ACC6E14B8C5DA0C4663475C2E5C3ADEF46F73BCDEC043");
        }

        [Test]
        public void Test2()
        {
            for (var i = 0; i < 1000; i++)
            {
                var num = Randomness.RandomInteger(1, 5);
                Assert.IsTrue(num >= 1);
                Assert.IsTrue(num < 5);
            }
        }
    }
}
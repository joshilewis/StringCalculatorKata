using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using NUnit.Framework;

namespace Tests
{
    [TestFixture]
    public class StringCalculatorTests
    {
        [Test]
        public void AddingEmptyStringShouldReturnZero()
        {
            Assert.That(new StringCalculator().Add(""), Is.EqualTo(0));
        }

        [Test]
        public void AddingSingleNumberShouldReturnThatNumber()
        {
            Assert.That(new StringCalculator().Add("1"), Is.EqualTo(1));
        }

        [Test]
        public void AddingTwoNumbersShouldReturnTheirSum()
        {
            Assert.That(new StringCalculator().Add("1, 2"), Is.EqualTo(3));
        }

        [Test]
        public void AddingManyNumbersShouldReturnTheirSum()
        {
            Assert.That(new StringCalculator().Add("1, 2, 3, 4"), Is.EqualTo(10));
        }

        [Test]
        public void NewlineCharacterShouldBeTreatedAsDelimiter()
        {
            Assert.That(new StringCalculator().Add("1\n2, 3"), Is.EqualTo(6));
        }

    }

    public class StringCalculator
    {
        public int Add(string input)
        {
            if (string.IsNullOrEmpty(input))
                return 0;

            return input
                .Split(',', '\n')
                .Select(int.Parse)
                .Sum()
                ;
        }
         
    }
}

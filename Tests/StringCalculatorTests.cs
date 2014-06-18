using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using NUnit.Framework;
using Rhino.Mocks;

namespace Tests
{
    [TestFixture]
    public class StringCalculatorTests
    {
        private ILogger logger;

        [SetUp]
        public void SetUp()
        {
            logger = MockRepository.GenerateMock<ILogger>();
        }

        [TearDown]
        public void TearDown()
        {
            logger = null;
        }

        private void ActAndAssert(string input, int expectedSum)
        {
            logger.Expect(l => l.Write(expectedSum));
            Assert.That(new StringCalculator(logger).Add(input), Is.EqualTo(expectedSum));
            logger.VerifyAllExpectations();
        }

        [Test]
        public void AddingEmptyStringShouldReturnZero()
        {
            ActAndAssert("", 0);
        }

        [Test]
        public void AddingSingleNumberShouldReturnThatNumber()
        {
            ActAndAssert("1", 1);
        }

        [Test]
        public void AddingTwoNumbersShouldReturnTheirSum()
        {
            ActAndAssert("1,2", 3);
        }

        [Test]
        public void AddingManyNumbersShouldReturnTheirSum()
        {
            ActAndAssert("1, 2, 3, 4", 10);
        }

        [Test]
        public void NewlineCharacterShouldBeTreatedAsDelimiter()
        {
            ActAndAssert("1\n2,3", 6);
        }

    }

    public class StringCalculator
    {
        private readonly ILogger logger;

        public StringCalculator(ILogger logger)
        {
            this.logger = logger;
        }

        public int Add(string input)
        {
            int result = AddWithoutLogging(input);
            logger.Write(result);
            return result;

        }

        private int AddWithoutLogging(string input)
        {
            if (string.IsNullOrEmpty(input))
                return 0;

            return Enumerable.Select<string, int>(input
                .Split(',', '\n'), int.Parse)
                .Sum()
                ;
        }
    }

    public interface ILogger
    {
        void Write(int sum);
    }
}

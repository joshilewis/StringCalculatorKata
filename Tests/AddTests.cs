using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using NUnit.Framework;

namespace Tests
{
    [TestFixture]
    public class AddTests
    {
        [Test]
        public void AddingEmptyStringShouldReturnZero()
        {
            Assert.That(Add(""), Is.EqualTo(0));
        }

        private int Add(string input)
        {
            return 0;
        }
    }
}

using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using Takushi.Model;

namespace Takushi.Tests
{
    [TestClass]
    public class WarrantyTestWithDefaults
    {
        private Warranty Target { get; set; }

        [TestInitialize]
        public void BeforeEachTest()
        {
            Target = new Warranty(new DateTime(2016, 2, 22));
        }

        [TestMethod]
        public void HaveAStartingDate()
        {
            Assert.AreEqual<DateTime>(new DateTime(2016, 2, 22), Target.StartDate);
        }

        [TestMethod]
        public void HaveAnEndingDate()
        {
            Assert.IsNotNull(Target.EndDate);
        }

        [TestMethod]
        public void GiveWarrantyLengthInMonths()
        {
            Assert.AreNotEqual<int>(0, Target.WarrantyInMonths);
        }

        [TestMethod]
        public void ChangeEndingDate()
        {
            Target.EndDate = new DateTime(2019, 12, 31);

            Assert.AreEqual<DateTime>(new DateTime(2019, 12, 31), Target.EndDate);
        }

        [TestMethod]
        public void ChangeWarrantyLength()
        {
            Target.WarrantyInMonths = 13;

            Assert.AreEqual<int>(13, Target.WarrantyInMonths);
        }

        [TestMethod]
        public void NotAcceptNonPositiveWarrantyLengths()
        {
            Target.WarrantyInMonths = -1;

            Assert.AreNotEqual<int>(-1, Target.WarrantyInMonths);
        }
    }

    [TestClass]
    public class WarrantyTestWithExactDates
    {
        private Warranty Target { get; set; }

        [TestInitialize]
        public void BeforeEachTest()
        {
            Target = new Warranty(new DateTime(2016, 2, 22), new DateTime(2018, 2, 22));
        }

        [TestMethod]
        public void HaveInitializedEndingDate()
        {
            Assert.AreEqual<DateTime>(new DateTime(2018, 2, 22), Target.EndDate);
        }

        [TestMethod]
        public void ChangeEndingDate()
        {
            Target.EndDate = new DateTime(2019, 12, 31);

            Assert.AreEqual<DateTime>(new DateTime(2019, 12, 31), Target.EndDate);
        }

        [TestMethod]
        public void ChangeWarrantyLengthShouldBeReflected()
        {
            Target.WarrantyInMonths = 3;

            Assert.AreEqual<DateTime>(new DateTime(2016, 5, 22), Target.EndDate);
        }

        [TestMethod]
        public void AllowConstructorWithMonths()
        {
            var warranty = new Warranty(new DateTime(2016, 2, 23), 18);

            Assert.AreEqual<DateTime>(new DateTime(2017, 8, 23), warranty.EndDate);
        }
    }
}

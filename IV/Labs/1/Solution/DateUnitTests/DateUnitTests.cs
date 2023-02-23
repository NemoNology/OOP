using Date;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;


namespace DateUnitTests
{
    [TestClass]
    public class DateUnitTests
    {
        private Date.Date D = new Date.Date();

        string[] monthNames =
        {
            "Junuary", "February", "March", "April",
            "May", "June", "July", "August", "September",
            "October", "November", "December"
        };

        /// <summary>
        /// Test for propery IsLeapYear - test if getter works properly
        /// </summary>
        [TestMethod]
        public void TestIsLeapYear()
        {
            int[] leapYears = { 0, 4, 8, 400, 2020, 2104, 404 };
            int[] notLeapYears = { 1, 5, 9, 100, 2100, 2021, 401 };

            bool result;

            foreach (var Year in leapYears)
            {
                D.Year = Year;

                result = D.YearLeapness;

                Assert.IsTrue(result, $"Expected for {Year}: true; Actual: {result}");
            }

            foreach (var Year in notLeapYears)
            {
                D.Year = Year;

                result = D.YearLeapness;

                Assert.IsFalse(result, $"Expected for {Year}: true; Actual: {result}");
            }

        }

        /// <summary>
        /// Test for propery MonthName - test if getter works properly
        /// </summary>
        [TestMethod]
        public void TestGetMonthName()
        {
            for (int i = 0; i < monthNames.Length; i++)
            {
                D.Month = i;

                string result = D.MonthName;

                Assert.AreEqual(monthNames[i], result, $"Expected: {monthNames[i]}; Actual: {D.MonthName}");
            }
        }

        /// <summary>
        /// Test for function GetMonthNumberByMonthName() - test if function works properly
        /// </summary>
        [TestMethod]
        public void TestGetMonthNumberByMonthName()
        {
            for (int i = 0; i < monthNames.Length; i++)
            {
                int result = Date.Date.GetMonthNumberByMonthName(monthNames[i]);

                Assert.AreEqual(i, result, $"Expected: {i}; Actual: {result}");
            }
        }

        /// <summary>
        /// Test for propery DaysAmount - test if getter works properly
        /// </summary>
        [TestMethod]
        public void TestDaysAmount()
        {
            int[] monthsWith30Days = { 4, 6, 9, 11 };
            int[] monthsWith31Days = { 1, 3, 5, 7, 8, 10, 12 };

            int result;

            foreach (int month in monthsWith30Days)
            {
                D.Month = month - 1;

                result = D.DaysAmount;

                Assert.AreEqual(30, result, $"Expected: 30; Actual: {result}");
            }

            foreach (int month in monthsWith31Days)
            {
                D.Month = month - 1;

                result = D.DaysAmount;

                Assert.AreEqual(31, result, $"Expected: 31; Actual: {result}");
            }

            D.Month = 1;
            D.Year = 3;

            result = D.DaysAmount;

            Assert.AreEqual(28, result, $"Expected: 28; Actual: {result}");


            D.Year = 2020;

            result = D.DaysAmount;

            Assert.AreEqual(29, result, $"Expected: 29; Actual: {result}");
        }

        /// <summary>
        /// Test for throw exceptions in properies:  - test if getter works properly
        /// </summary>
        [TestMethod]
        public void TestExceptionsThrows()
        {
            int[] invalidData = { -1, -9, -28, -12, -120 };

            D.Year = 0;
            D.Day = 0;

            foreach (int month in invalidData)
            {
                var exc = Assert.ThrowsException<Exception>(() => D.Month = month);
                Assert.IsInstanceOfType(exc, typeof(Exception), $"Expected Exception in Month; Actual Type: {exc.GetType()}");
            }

            foreach (int day in invalidData)
            {
                var exc = Assert.ThrowsException<Exception>(() => D.Day = day);
                Assert.IsInstanceOfType(exc, typeof(Exception), $"Expected Exception in Day; Actual Type: {exc.GetType()}");
            }

            foreach (int year in invalidData)
            {
                var exc = Assert.ThrowsException<Exception>(() => D.Year = year);
                Assert.IsInstanceOfType(exc, typeof(Exception), $"Expected Exception in Year; Actual Type: {exc.GetType()}");
            }
        }

        /// <summary>
        /// Test Adding Year, Month and Day 
        /// </summary>
        [TestMethod]
        public void TestOperatorAdding()
        {
            D.Year = 2023;
            D.Month = 1;
            D.Day = 22;

            D.Day += 36;

            Date.Date result = new Date.Date(D.Year, 2, 30);

            Assert.IsTrue(result == D, $"Expected: {result.DateInfo}; Actual: {D.DateInfo}");

            D.Month += 17;

            result.Month = 7;
            result.Year = 2024;

            Assert.IsTrue(result == D, $"Expected: {result.DateInfo}; Actual: {D.DateInfo}");

            result.Year = 2030;

            D.Year += 6;

            Assert.IsTrue(result == D, $"Expected: {result.DateInfo}; Actual: {D.DateInfo}");
        }


        /// <summary>
        /// Test Substraction Year, Month and Day 
        /// </summary>
        [TestMethod]
        public void TestOperatorSubstraction()
        {
            D.Year = 2030;
            D.Month = 7;
            D.Day = 30;

            D.Year -= 6;

            Date.Date result = new Date.Date(2024, 7, 30);

            Assert.IsTrue(result == D, $"Expected: {result.DateInfo}; Actual: {D.DateInfo}");

            D.Month -= 17;

            result.Month = 2;
            result.Year = 2023;

            Assert.IsTrue(result == D, $"Expected: {result.DateInfo}; Actual: {D.DateInfo}");

            D.Day -= 36;

            result.Month = 1;
            result.Day = 22;

            Assert.IsTrue(result == D, $"Expected: {result.DateInfo}; Actual: {D.DateInfo}");
        }

    }
}

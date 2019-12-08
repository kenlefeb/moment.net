using moment.net.Models;
using NUnit.Framework;
using Shouldly;
using System;

namespace moment.net.Tests
{
    public class CalendarTimeTests
    {
        [Test]
        public void CalendarTimeSameDay()
        {
            var today = DateTime.Now.Date.AddHours(2);
            today.CalendarTime().ShouldStartWith("Today at ");
        }

        [Test]
        public void CalendarTimeFromYesterday()
        {
            var yesterday = DateTime.Now.AddDays(-1);
            yesterday.CalendarTime().ShouldStartWith("Tomorrow at ");
        }

        [Test]
        public void CalendarTimeFromTomorrow()
        {
            var tomorrow = DateTime.Now.AddDays(1);
            tomorrow.CalendarTime().ShouldStartWith("Yesterday at ");
        }

        [Test]
        public void CalendarTimeFromTwoFixedDates()
        {
            var initialDate = new DateTime(2012, 12, 12, 0, 0, 0, DateTimeKind.Local);
            var nextDate = new DateTime(2012, 12, 18, 0, 0, 0, DateTimeKind.Local);
            initialDate.CalendarTime(nextDate).ShouldStartWith(nextDate.ToString("dddd 'at' "));
        }

        [Test]
        public void CalendarTimeToTwoFixedDates()
        {
            var earlierDate = new DateTime(2012, 12, 12, 0, 0, 0, DateTimeKind.Local);
            var laterDate = new DateTime(2012, 12, 18, 0, 0, 0, DateTimeKind.Local);
            laterDate.CalendarTime(earlierDate).ShouldStartWith(earlierDate.ToString("'Last' dddd 'at' "));
        }

        [Test]
        public void CalendarTimeForEcessiveTimeSpanWithSpecifiedFormat()
        {
            var initialDate = new DateTime(2012, 12, 12, 0, 0, 0, DateTimeKind.Local);
            var nextDate = new DateTime(2018, 12, 12, 0, 0, 0, DateTimeKind.Local);
            initialDate.CalendarTime(nextDate, new CalendarTimeFormats("", "", "", "", "", "dd/MM/yyyy")).ShouldBe(nextDate.ToString("dd/MM/yyyy"));
        }
    }
}
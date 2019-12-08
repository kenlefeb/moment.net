using NUnit.Framework;
using Shouldly;
using System;

namespace moment.net.Tests
{
    public class UnixTimeTests
    {
        [Test]
        public void UnixTimeInMillisecondsOneYearFromEpoch()
        {
            var dateTime = new DateTime(1971, 01, 01, 0, 0, 0, DateTimeKind.Utc);
            var millisecondsElapsed = dateTime.UnixTimestampInMilliseconds();
            millisecondsElapsed.ShouldBe(365.0 * 24 * 60 * 60 * 1000);
        }

        [Test]
        public void UnixTimeInSecondsOneUtcYearFromEpoch()
        {
            var dateTime = new DateTime(1971, 01, 01, 0, 0, 0, DateTimeKind.Utc);
            var secondsElapsed = dateTime.UnixTimestampInSeconds();
            secondsElapsed.ShouldBe(365.0 * 24 * 60 * 60);
        }

        [Test]
        public void UnixTimeInSecondsOneLocalYearFromEpoch()
        {
            var tz = TimeZoneInfo.Local;
            var dateTime = TimeZoneInfo.ConvertTime(new DateTime(1971, 01, 01, 0, 0, 0, DateTimeKind.Utc), tz);
            var secondsElapsed = dateTime.UnixTimestampInSeconds();
            secondsElapsed.ShouldBe(365.0 * 24 * 60 * 60);
        }
    }
}
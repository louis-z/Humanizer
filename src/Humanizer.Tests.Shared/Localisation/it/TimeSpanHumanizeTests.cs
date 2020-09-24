using System;
using Xunit;

namespace Humanizer.Tests.Localisation.it
{
    [UseCulture("it")]
    public class TimeSpanHumanizeTests
    {

        [Theory]
        [Trait("Translation", "Google")]
        [InlineData(366, "1 anno")]
        [InlineData(731, "2 anni")]
        [InlineData(1096, "3 anni")]
        [InlineData(4018, "11 anni")]
        public void Years(int days, string expected)
        {
            Assert.Equal(expected, TimeSpan.FromDays(days).Humanize(maxUnit: Humanizer.Localisation.TimeUnit.Year));
        }


        [Theory]
        [Trait("Translation", "Google")]
        [InlineData(31, "1 mese")]
        [InlineData(61, "2 mesi")]
        [InlineData(92, "3 mesi")]
        [InlineData(335, "11 mesi")]
        public void Months(int days, string expected)
        {
            Assert.Equal(expected, TimeSpan.FromDays(days).Humanize(maxUnit: Humanizer.Localisation.TimeUnit.Year));
        }

        [Theory]
        [InlineData(7, "1 settimana")]
        [InlineData(14, "2 settimane")]
        public void Weeks(int days, string expected)
        {
            Assert.Equal(expected, TimeSpan.FromDays(days).Humanize());
        }

        [Theory]
        [InlineData(1, "1 giorno")]
        [InlineData(2, "2 giorni")]
        public void Days(int days, string expected)
        {
            Assert.Equal(expected, TimeSpan.FromDays(days).Humanize());
        }

        [Theory]
        [InlineData(1, "1 ora")]
        [InlineData(2, "2 ore")]
        public void Hours(int hours, string expected)
        {
            Assert.Equal(expected, TimeSpan.FromHours(hours).Humanize());
        }

        [Theory]
        [InlineData(1, "1 minuto")]
        [InlineData(2, "2 minuti")]
        public void Minutes(int minutes, string expected)
        {
            Assert.Equal(expected, TimeSpan.FromMinutes(minutes).Humanize());
        }

        [Theory]
        [InlineData(1, "1 secondo")]
        [InlineData(2, "2 secondi")]
        public void Seconds(int seconds, string expected)
        {
            Assert.Equal(expected, TimeSpan.FromSeconds(seconds).Humanize());
        }

        [Theory]
        [InlineData(1, "1 millisecondo")]
        [InlineData(2, "2 millisecondi")]
        public void Milliseconds(int milliseconds, string expected)
        {
            Assert.Equal(expected, TimeSpan.FromMilliseconds(milliseconds).Humanize());
        }

        [Theory]
        [InlineData(4, "4 giorni")]
        [InlineData(23, "3 settimane")]
        [InlineData(64, "2 mesi")]
        [InlineData(367, "1 anno")]
        [InlineData(750, "2 anni")]
        public void Age(int days, string expected)
        {
            var actual = TimeSpan.FromDays(days).ToAge();
            Assert.Equal(expected, actual);
        }

        [Theory]
        [InlineData(4, "")]
        [InlineData(23, "")]
        [InlineData(64, "")]
        [InlineData(367, "")]
        [InlineData(750, "")]
        public void HyphenatedAge(int days, string expected)
        {
            var actual = TimeSpan.FromDays(days).ToHyphenatedAge();
            Assert.Equal(expected, actual);
        }

        [Fact]
        public void NoTime()
        {
            Assert.Equal("0 millisecondi", TimeSpan.Zero.Humanize());
        }

        [Fact]
        public void NoTimeToWords()
        {
            // This does not make much sense in italian, anyway
            Assert.Equal("0 secondi", TimeSpan.Zero.Humanize(toWords: true));
        }
    }
}

using System;

namespace LoremIpsumGenerator.Libs
{
    public class DateTimeWriterService : IDateTimeWriterService
    {
        public DateTime CreateRandomDateTimeBlock(Random randomGenerator)
        {
            //args to Random below are epoch timestamps (first: 12 August 2019)
            return DateTimeOffset.FromUnixTimeSeconds(randomGenerator.Next(1565649526, (int)DateTimeOffset.Now.ToUnixTimeSeconds())).DateTime;
        }
    }
}

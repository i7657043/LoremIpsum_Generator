using System;

namespace LoremIpsumGenerator.Libs
{
    public interface IDateTimeWriterService
    {
        DateTime CreateRandomDateTimeBlock(Random randomGenerator);
    }
}

using System;

namespace LoremIpsumGenerator.Libs
{
    public interface ICharWriterService
    {
        char CreateRandomCharBlock(Random randomGenerator);
    }
}

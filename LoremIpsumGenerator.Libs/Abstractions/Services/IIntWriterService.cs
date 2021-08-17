using System;

namespace LoremIpsumGenerator.Libs
{
    public interface IIntWriterService
    {
        int CreateRandomIntBlock(Random randomGenerator);
    }
}

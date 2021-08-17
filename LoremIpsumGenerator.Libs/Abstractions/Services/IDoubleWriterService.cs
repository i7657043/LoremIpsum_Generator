using System;

namespace LoremIpsumGenerator.Libs
{
    public interface IDoubleWriterService
    {
        double CreateRandomDoubleBlock(Random randomGenerator);
    }
}

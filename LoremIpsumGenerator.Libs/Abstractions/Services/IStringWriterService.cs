using System;

namespace LoremIpsumGenerator.Libs
{
    public interface IStringWriterService
    {
        string CreateRandomStringBlock(int wordsPerBlockLower, int wordsPerBlockHigher, bool uniqueWords, Random randomGenerator, ref ulong uniqueWordCounter);
    }
}

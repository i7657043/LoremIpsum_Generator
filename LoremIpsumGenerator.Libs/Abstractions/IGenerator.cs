using System.Collections.Generic;

namespace LoremIpsumGenerator.Libs
{
    public interface IGenerator
    {
        bool CanRead { get; }

        void SetupGenerator(int wordsPerBlockLower, int wordsPerBlockHigher, int totalBlocks, int pageSize, bool uniqueWords);
        List<T> Generate<T>();
        void Reset();
    }
}

using System.Collections.Generic;

namespace LoremIpsumGenerator.Libs
{
    public interface IGenerator
    {
        bool CanRead { get; }

        List<T> Generate<T>();
        void Reset();
    }
}

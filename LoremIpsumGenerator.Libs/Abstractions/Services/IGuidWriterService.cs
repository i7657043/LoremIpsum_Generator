using System;

namespace LoremIpsumGenerator.Libs
{
    public interface IGuidWriterService
    {
        Guid CreateRandomGuidBlock();
    }
}

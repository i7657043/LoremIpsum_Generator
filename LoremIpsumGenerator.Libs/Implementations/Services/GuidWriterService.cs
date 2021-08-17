using System;
using System.Collections.Generic;
using System.Linq;

namespace LoremIpsumGenerator.Libs
{
    public class GuidWriterService : IGuidWriterService
    {
        public GuidWriterService() { }

        public Guid CreateRandomGuidBlock()
        {
            return Guid.NewGuid();
        }
    }
}

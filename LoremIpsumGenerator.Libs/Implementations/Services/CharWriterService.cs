using System;
using System.Collections.Generic;
using System.Linq;

namespace LoremIpsumGenerator.Libs
{
    public class CharWriterService : ICharWriterService
    {
        private readonly List<char> _charLetters;

        public CharWriterService() => _charLetters = Enumerable.Range('A', 'Z' - 'A' + 1).Select(c => (char)c).ToList();        

        public char CreateRandomCharBlock(Random randomGenerator)
        {
            return _charLetters[randomGenerator.Next(0, _charLetters.Count)];
        }
    }
}

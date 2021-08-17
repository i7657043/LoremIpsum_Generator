using System;

namespace LoremIpsumGenerator.Libs
{
    public class IntWriterService : IIntWriterService
    {
        public int CreateRandomIntBlock(Random randomGenerator)
        {
            return randomGenerator.Next(65043, 12121212);
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;

namespace LoremIpsumGenerator.Libs
{
    public class DoubleWriterService : IDoubleWriterService
    {
        public DoubleWriterService() {} 

        public double CreateRandomDoubleBlock(Random randomGenerator)
        {
            //Sometimes return a whole number as a double, sometimes return a decimal
            return randomGenerator.Next(0,2) == 1 
                ? randomGenerator.Next(65043, 12121212) + randomGenerator.NextDouble() 
                : randomGenerator.Next(65043, 12121212);
        }
    }
}

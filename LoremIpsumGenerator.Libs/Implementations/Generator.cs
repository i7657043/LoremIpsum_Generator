using System;
using System.Collections.Generic;
using System.Reflection;

namespace LoremIpsumGenerator.Libs
{
    public class Generator : IGenerator
    {
        #region vars and cons
        private bool uniqueWords;
        private int wordsPerBlockLower, wordsPerBlockHigher, totalBlocks, pageSize, totalBlocksWrote;
        private ulong uniqueWordCounter = 1212;

        private readonly Random _randomGenerator;      
        private readonly IStringWriterService _stringWriterService;
        private readonly ICharWriterService _charWriterService;
        private readonly IIntWriterService _intWriterService;
        private readonly IDateTimeWriterService _datetimeWriterService;
        private readonly IGuidWriterService _guidWriterService;
        private readonly IDoubleWriterService _doubleWriterService;

        public bool CanRead { get => totalBlocksWrote < totalBlocks; }

        public Generator(int wordsPerBlockLower, int wordsPerBlockHigher, int totalBlocks, int pageSize = 0, bool uniqueWords = false)
        {
            SetGeneratorProperties(wordsPerBlockLower, wordsPerBlockHigher, totalBlocks, pageSize, uniqueWords);

            _randomGenerator = new Random();

            _stringWriterService = new StringWriterService();
            _charWriterService = new CharWriterService();
            _intWriterService = new IntWriterService();
            _datetimeWriterService = new DateTimeWriterService();
            _guidWriterService = new GuidWriterService();
            _doubleWriterService = new DoubleWriterService();
        }

        #endregion

        public List<T> Generate<T>()
        {
            List<T> blocks = new List<T>();

            if (!CanRead)
                return blocks;

            while (CanRead && InsidePageThreshold(blocks.Count))
            {
                blocks.Add(FillBlockProperties(Activator.CreateInstance<T>()));

                totalBlocksWrote++;
            }

            return blocks;
        }

        private T FillBlockProperties<T>(T block)
        {
            foreach (PropertyInfo property in block.GetType().GetProperties())
            {
                if (ValidProperty<string>(property))
                {
                    property.SetValue(block, _stringWriterService.CreateRandomStringBlock(wordsPerBlockLower, wordsPerBlockHigher, uniqueWords, _randomGenerator, ref uniqueWordCounter), null);
                }

                if (ValidProperty<char>(property))
                {
                    property.SetValue(block, _charWriterService.CreateRandomCharBlock(_randomGenerator), null);
                }

                if (ValidProperty<int>(property) || ValidProperty<long>(property))
                {
                    property.SetValue(block, _intWriterService.CreateRandomIntBlock(_randomGenerator), null);
                }

                if (ValidProperty<DateTime>(property))
                {
                    property.SetValue(block, _datetimeWriterService.CreateRandomDateTimeBlock(_randomGenerator), null);
                }

                if (ValidProperty<Guid>(property))
                {
                    property.SetValue(block, _guidWriterService.CreateRandomGuidBlock(), null);
                }

                if (ValidProperty<double>(property))
                {
                    property.SetValue(block, _doubleWriterService.CreateRandomDoubleBlock(_randomGenerator), null);
                }
            }

            return block;
        }

        private static bool ValidProperty<T>(PropertyInfo property)
        {
            return property != null && property.PropertyType == typeof(T);
        }

        private bool InsidePageThreshold(int currentPageCount)
        {
            return currentPageCount < pageSize;
        }

        private void SetGeneratorProperties(int wordsPerBlockLower, int wordsPerBlockHigher, int totalBlocks, int pageSize, bool uniqueWords)
        {
            if (wordsPerBlockLower < 0 || wordsPerBlockHigher < 0)
                throw new ArgumentOutOfRangeException("Words per Block range arguments must be larger than 0, and less than 11473193");

            if (totalBlocks < 0)
                throw new ArgumentOutOfRangeException("You cant give me Blocks. Set the Total Blocks to larger than -1");

            if (pageSize < 0 || pageSize > totalBlocks)
                throw new ArgumentOutOfRangeException("Set the Page Size to larger than -1 and smaller than the Total Blocks");

            this.wordsPerBlockLower = wordsPerBlockLower;
            this.wordsPerBlockHigher = wordsPerBlockHigher;
            this.totalBlocks = totalBlocks;
            this.uniqueWords = uniqueWords;
            this.pageSize = pageSize != 0 ? pageSize : totalBlocks; //If 0 passed in as page size arg then only use 1 page
        }

        public void Reset()
        {
            totalBlocksWrote = 0;
        }
    }
}

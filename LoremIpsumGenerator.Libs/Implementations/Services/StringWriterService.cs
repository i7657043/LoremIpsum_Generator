using System;
using System.Collections.Generic;
using System.Text;

namespace LoremIpsumGenerator.Libs
{
    public class StringWriterService : IStringWriterService
    {
        private readonly List<string> _loremIpsumWords;

        public StringWriterService() => 
            _loremIpsumWords = new List<string>
            {
                "lorem",
                "ipsum",
                "dolor",
                "sit",
                "amet",
                "consectetur",
                "adipiscing",
                "eiusmod",
                "tempor",
                "incididunt",
                "ut",
                "labore"
            };
        

        public string CreateRandomStringBlock(int wordsPerBlockLower, int wordsPerBlockHigher, bool uniqueWords, Random randomGenerator, ref ulong uniqueWordCounter)
        {
            string word = string.Empty;

            word = wordsPerBlockHigher > 1
                ? GetNextRandomWords(wordsPerBlockLower, wordsPerBlockHigher, uniqueWords, randomGenerator, ref uniqueWordCounter)
                : GetNextRandomWord(randomGenerator);

            if (uniqueWords)
            {
                word = $"{word} {uniqueWordCounter}";

                uniqueWordCounter++;
            }

            if (string.IsNullOrEmpty(word))
                throw new Exception("There was an error when creating a Random Text Block. The Random Word string is null or empty");

            return word;
        }

        private string GetNextRandomWord(Random randomGenerator)
        {
            return _loremIpsumWords[randomGenerator.Next(0, _loremIpsumWords.Count)];
        }

        private string GetNextRandomWords(int wordsPerBlockLower, int wordsPerBlockHigher, bool uniqueWords, Random randomGenerator, ref ulong uniqueWordCounter)
        {
            StringBuilder randomWords = new StringBuilder();

            int randomNumber = randomGenerator.Next(wordsPerBlockLower, wordsPerBlockHigher + 1);

            for (int i = 0; i < randomNumber; i++)
            {
                //If we are adding a unique word, add it around the middle of the string of random words we return              
                randomWords.Append(uniqueWords && i == (randomNumber / 2) 
                    ? $"{uniqueWordCounter} {GetNextRandomWord(randomGenerator)} " 
                    : $"{GetNextRandomWord(randomGenerator)} ");
            }

            return randomWords.ToString().Trim();
        }
    }
}

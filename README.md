## Lorem Ipsum Generator
* Library for easily creating large random data sets for Types: string, char, int, long, double, DateTime and Guid

* Generate data sets containing:
  * random number of lorem ipsum words between upper and lower bounds, seperated by whitespace e.g. "lorem ipsum dolor sit"
  * paginate the response for generating large data sets on hardware with smaller amounts of memory available
  * generate a random, incrementing number in the middle of the dataset in order to generate data sets that contain a familiar, incrementing set of string values that are queryable for testing e.g. "lorem ipsum 1212 dolor sit", "ipsum 1213 sit"

* .Net Standard 2.0 library

* Available as .nupkg file at the following URL: https://www.nuget.org/packages/LoremIpsumGenerator/

#### Example Usage
```cs
class SampleStructure
{
    public string TextOne { get; set; }
    public char CharOne { get; set; }
    public int IntOne { get; set; }
    public DateTime DateTimeOne { get; set; }
    public Guid GuidOne { get; set; }
    public double DoubleOne { get; set; }
}

class Program
{
    static void Main(string[] args)
    {
        List<SampleStructure> generatedBlocks = new List<SampleStructure>();

        IGenerator generator = new Generator(wordsPerBlockLower: 2, wordsPerBlockHigher: 3, totalBlocks: 1000000, pageSize: 500000, uniqueWords: true);

        while (generator.CanRead)
        {
            generatedBlocks = generator.Generate<SampleStructure>();

            //Do something with Blocks
        }
    }
}
```
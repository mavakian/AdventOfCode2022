using System.Runtime.CompilerServices;
using System.Xml.Schema;

internal class Program
{
    private static void Main(string[] args)
    { // I am not proud of this.
        Console.WriteLine("Hello, World!");
        const string inputPath = @"C:\Users\mavakian\source\repos\AdventOfCode\DayFour\input.txt";
        int Total = 0;
        int overlappingPairs = 0;
        
        using (StreamReader sr = new StreamReader(inputPath))
        {
            string? line;
            while((line = sr.ReadLine()) != null)
            {
                var ranges = line?.Split(",");
                List<int[]> chores = new List<int[]>();

                foreach (var range in ranges!)
                {
                    var sequence = range.Split('-');
                    var start = int.Parse(sequence[0]);
                    var end = int.Parse(sequence[1]);
                    var count = end - start + 1;
                    chores.Add(Enumerable.Range(start,count).ToArray());
                }

                var choreOneSize = chores[0].Length;
                var choreTwoSize = chores[1].Length;
                var choreCount = chores[0].Intersect(chores[1]).ToArray().Length;
                var choreCount2 = chores[1].Intersect(chores[0]).ToArray().Length;
                if (choreCount > 0)
                    overlappingPairs ++;

                if (choreCount == choreOneSize || choreCount == choreTwoSize)
                {
                    Total++;
                }
            }            
        }
        Console.WriteLine($"Here is your total sir: {Total}.");
        Console.WriteLine($"The number of overlapping pairs is: {overlappingPairs}.");
    }
}


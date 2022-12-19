
// Find the item type that appears in both compartments of each rucksack.
// What is the sum of the priorities of those item types?
var input = @"C:\Users\mavakian\source\repos\AdventOfCode\DayThree\input.txt";
int total = 0;
using (StreamReader stream = new StreamReader(input))
{
    string? line;

    while ((line = stream.ReadLine()) != null)
    {
        
        string firstCompartment = line.Substring(0, line.Length / 2);
        string secondCompartment = line.Substring(line.Length / 2);


        var common = (from firstChar in firstCompartment
                   from secondChar in secondCompartment
                   where firstChar == secondChar
                   select secondChar).First();

        int asciiCode = common;
        var priority = asciiCode - 96;
       
        if(asciiCode <= 90)
            priority = asciiCode - 38;

        total += priority;
        Console.WriteLine($"{firstCompartment}, {secondCompartment}, {common}, {priority}, {total}");
    }
}
Console.WriteLine($"Your sum syre: {total}");
Console.WriteLine($"PART 2 : ");

//Part 2
total = 0;
using (StreamReader stream = new StreamReader(input))
{
    string? line;
    int i = 0;
    while ((line = stream.ReadLine()) != null)
    {
        string? secondString = stream.ReadLine();
        string? thirdString = stream.ReadLine();

        var common = from firstChar in line
                      from secondChar in secondString!
                      where firstChar == secondChar
                      select secondChar;

        var commons = (from chars in common
                      from thirdChar in thirdString!
                      where thirdChar == chars
                      select thirdChar).First();

        int asciiCode = commons;
        var priority = asciiCode - 96;

        if (asciiCode <= 90)
            priority = asciiCode - 38;

        total += priority;
        Console.WriteLine($" {commons}, {priority}, {total}");
    }
}


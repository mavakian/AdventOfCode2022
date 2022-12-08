List<int> caloriePacks = new List<int>();
using (StreamReader reader = new StreamReader("C:\\Users\\mavakian\\source\\repos\\AdventOfCode\\DayOne\\input.txt"))
{
    string? snackCalories = string.Empty;
    int caloriePack = 0;
    while(snackCalories is not null)
    {
        while ((snackCalories = reader.ReadLine()) != string.Empty && snackCalories is not null)
        {
            caloriePack += Int32.Parse(snackCalories);
        }
        caloriePacks.Add(caloriePack);
        caloriePack = 0;
    }
}
foreach (int pack in caloriePacks)
{
    Console.WriteLine($"Index: {caloriePacks.IndexOf(pack)}, Calories: {pack}");
}
Console.WriteLine($"The elf with the most calories is elf number [{caloriePacks.IndexOf(caloriePacks.Max())-1}] with [{caloriePacks.Max()}] calories.");
Console.WriteLine("Did I do good Michael?");
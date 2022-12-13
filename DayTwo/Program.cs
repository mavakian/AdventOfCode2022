static class Program
{
    static void Main()
    {
        var input = @"C:\Users\mavakian\source\repos\AdventOfCode\DayTwo\input.txt";
        Console.WriteLine($"Calculating Score");
        int total_score = 0;
        int re_score = 0;
        using (StreamReader reader = new StreamReader(input))
        {
            string? line;
            while((line = reader?.ReadLine()) != null)
            {
                var turn = new Turn(line.Split(" "));
                var score = turn.Score();
                total_score += score;
                var reScore = turn.ReScore();
                re_score += reScore;
                Console.WriteLine($"Line: {line}, Score: {score}, Rescore: {reScore}");
            }                     
        }

        Console.WriteLine($"The total score is: [{total_score}].");
        Console.WriteLine($"The Correct total score is: [{re_score}].");
        Console.ReadLine();
    }

    public static int Points(string hand)
    {
        switch (hand.ToLower())
        {
            case "a":
                return 1;
            case "b":
                return 2;
            case "c":
                return 3;
            case "x":
                return 1;
            case "y":
                return 2;
            case "z":
                return 3;
            default:
                return 0;
        }        
    }
}


public enum Shape
{
    Rock = 1,
    Paper = 2,
    Scissors = 3
}

public enum Strategy
{
    Lose = 1,
    Draw = 2,
    Win = 3
}

public class Turn
{
    private readonly Shape _defense;
    private readonly Shape _offense;

    public Turn(string[] line)
    {
        _defense = (Shape)Program.Points(line[0]);
        _offense = (Shape)Program.Points(line[1]);
    }

    public int Score()
    {
        int score = 0;
        if(_offense == Shape.Rock)
        { 
            if(_defense == Shape.Paper)
                score = (int)Shape.Rock + 0;

            if (_defense == Shape.Scissors)
                score = (int)Shape.Rock + 6;

            if (_defense == Shape.Rock)
                score = (int)Shape.Rock + 3;
        }

        if (_offense == Shape.Paper)
        {
            if (_defense == Shape.Paper)
                score = (int)Shape.Paper + 3;

            if (_defense == Shape.Scissors)
                score = (int)Shape.Paper + 0;

            if (_defense == Shape.Rock)
                score = (int)Shape.Paper + 6;
        }

        if (_offense == Shape.Scissors)
        {
            if (_defense == Shape.Paper)
                score = (int)Shape.Scissors + 6;

            if (_defense == Shape.Scissors)
                score = (int)Shape.Scissors + 3;

            if (_defense == Shape.Rock)
                score = (int)Shape.Scissors + 0;
        }
        return score;
    }

    public int ReScore()
    {
        var defense = _defense;
        int reScore = 0;
        if (defense == Shape.Rock)
        {
            if ((int)_offense == (int)Strategy.Lose)
                reScore = (int)Shape.Scissors + 0;

            if ((int)_offense == (int)Strategy.Draw)
                reScore = (int)Shape.Rock + 3;

            if ((int)_offense == (int)Strategy.Win)
                reScore = (int)Shape.Paper + 6;
        }

        if (defense == Shape.Paper)
        {
            if ((int)_offense == (int)Strategy.Lose)
                reScore = (int)Shape.Rock + 0;

            if ((int)_offense == (int)Strategy.Draw)
                reScore = (int)Shape.Paper + 3;

            if ((int)_offense == (int)Strategy.Win)
                reScore = (int)Shape.Scissors + 6;
        }

        if (defense == Shape.Scissors)
        {
            if ((int)_offense == (int)Strategy.Lose)
                reScore = (int)Shape.Paper + 0;

            if ((int)_offense == (int)Strategy.Draw)
                reScore = (int)Shape.Scissors + 3;

            if ((int)_offense == (int)Strategy.Win)
                reScore = (int)Shape.Rock + 6;
        }
        return reScore;
    }
}
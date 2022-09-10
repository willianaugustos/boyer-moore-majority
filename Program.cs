using System;

public static class Program
{
    public static void Main(String[] args)
    {
        int[] sequence = { 20, 18, 60, 10, 10, 10, 10, 20, 20, 20, 20, 20, 20, 48 };
        int element = BoyerMoore.FindMajorityElement(sequence);
        Console.WriteLine($"The majority element is: {element}");

        decimal percent = BoyerMoore.CalculateRecurrencyPercentage(element, sequence);
        Console.WriteLine($"The recurrency is {percent * 100}%");
    }
}

public static class BoyerMoore
{
    public static int FindMajorityElement(int[] elementArray)
    {
        int count = 0;
        int elementCandidate = -1;

        foreach (int currentElement in elementArray)
        {
            if (count == 0)
            {
                elementCandidate = currentElement;
                count = 1;
            }
            else
            {
                if (currentElement == elementCandidate)
                {
                    count++;
                }
                else
                {
                    count--;
                }
            }
        }
        return elementCandidate;
    }

    public static decimal CalculateRecurrencyPercentage(int number, int[] sequence)
    {
        int count = 0;
        foreach (int element in sequence)
        {
            if (element == number)
                count++;
        }
        return Math.Round((decimal)count / sequence.Length,2);
    }
}

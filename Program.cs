using System;

public static class Program
{
    public static void Main(String[] args)
    {
        int[] sequence = { 1, 2, 3, 4, 2, 2, 2, 7, 8, 2, 2, 2, 12, 2 };
        var (element, isMajority) = BoyerMooreMajority.FindMostFrequentElement(sequence);
        
        if (isMajority)
         Console.WriteLine($"The most frequent element is: {element} (more than 50%)");
        else
         Console.WriteLine("No majority element found.");
    }
}

public static class BoyerMooreMajority
{
    public static (int, bool) FindMostFrequentElement(int[] elementArray)
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
        return (elementCandidate, 
            CalculateRecurrencyPercentage(elementCandidate, elementArray) > 0.5M);
    }

    private static decimal CalculateRecurrencyPercentage(int number, int[] elementArray)
    {
        decimal recurrency = (decimal)elementArray.Where(e=>e == number).Count() / 
            elementArray.Count();

        return recurrency;
    }
}

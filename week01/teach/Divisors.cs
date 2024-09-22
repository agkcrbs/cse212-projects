public static class Divisors {
    /// <summary>
    /// Entry point for the Divisors class
    /// </summary>
    public static void Run() {
        List<int> list = FindDivisors(80);
        Console.WriteLine("<List>{" + string.Join(", ", list) + "}"); // <List>{1, 2, 4, 5, 8, 10, 16, 20, 40}
        List<int> list1 = FindDivisors(79);
        Console.WriteLine("<List>{" + string.Join(", ", list1) + "}"); // <List>{1}
    }

    /// <summary>
    /// Create a list of all divisors for a number including 1
    /// and excluding the number itself. Modulo will be used
    /// to test divisibility.
    /// </summary>
    /// <param name="number">The number to find the divisor</param>
    /// <returns>List of divisors</returns>
    private static List<int> FindDivisors(int number) {
        List<int> results = new();
        // TODO problem 1

// -get a number
// -check if the number modulo another number (remainder) is zero; that means it's a divisor
// -reduce those checking numbers down to 1
// -use a loop, therefore, starting at the number itself, decrementing by one each time, till the number reaches 1
// -use a list and append the successfully checked numbers to the list
// so...
// int mainNumber = 5;
// List<int> dividendList = new();
// for (int dividend = mainNumber; i > 0; i --)
// {
//     if (mainNumber % dividend == 0)
//     {
//         dividendList.Add(dividend);
//     }
// }
// Actually, instead of decrementing, increment to avoid the need to sort again, as per instructions.

        for (int dividend = 1; dividend < number; dividend++) // The solution says prefix increment ++i; since nothing is assigned, I guess it's irrelevant, as both happen at the end of each loop.
        {
            if (number % dividend == 0)
            {
                results.Add(dividend);
            }
        }

        return results;
    }
}
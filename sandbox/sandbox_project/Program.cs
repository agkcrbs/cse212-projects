using System.Diagnostics;
using Microsoft.VisualBasic;

public class Program
{
    static void Main(string[] args)
    {
        // This project is here for you to use as a "Sandbox" to play around
        // with any code or ideas you have that do not directly apply to
        // one of your projects.

        Console.WriteLine("Hello Sandbox World!");
        Run();
    }

    public static void Run()
    {
        int[] data = [
            50, 9, 24, 100, 7, 75, 93, 24, 17, 16, 97, 6, 18, 81, 48, 37, 49, 33, 60, 3, 99, 32, 88, 29, 65, 20, 35, 33,
            15, 81, 31, 93, 17, 5, 5, 79, 12, 91, 18, 31, 12, 94, 39, 98, 10, 72, 20, 79, 100, 27, 46, 28, 50, 1, 7, 14,
            78, 100, 55, 26, 48, 33, 96, 77, 69, 8, 33, 36, 42, 98, 42, 32, 49, 65, 1, 82, 30, 74, 73, 89, 23, 76, 25,
            4, 76, 7, 72, 86, 71, 29, 18, 98, 84, 20, 24, 18, 11, 33, 39, 96, 1, 97, 65, 41, 62, 48, 59, 51, 17, 89, 6,
            29, 98, 49, 37, 72, 63, 49, 12, 79, 27, 23, 23, 13, 90, 47, 11, 66, 41, 97, 2, 60, 1, 21, 38, 100, 98, 2,
            18, 75, 86, 52, 63, 58, 26, 80, 62, 82, 63, 94, 33, 76, 7, 11, 49, 2, 34, 3, 10, 27, 71, 60, 4, 94, 100, 95,
            46, 15, 21, 40, 35, 98, 89, 25, 46, 54, 24, 75, 92, 69, 37, 63, 71, 70, 90, 91, 82, 81, 4, 10, 82, 1, 32, 8,
            13, 47, 8, 52, 30, 54, 4, 79, 7, 90, 81, 33, 65, 89, 84, 83, 46, 95, 82, 6, 93, 5, 22, 67, 8, 79, 3, 55, 79,
            6, 54, 10, 22, 16, 40, 67, 50, 58, 37, 35, 7, 44, 10, 31, 45, 93, 12, 55, 67, 48, 32, 43, 57, 58, 37, 76,
            85, 47, 80, 18, 32, 59, 98, 92, 53, 98, 29, 61, 82, 42, 78, 97, 23, 94, 38, 20, 73, 11, 99, 94, 92, 82, 82,
            65
        ];

        Console.WriteLine($"Number of items in the collection: {data.Length}");
        Console.WriteLine($"Number of duplicates : {CountDuplicates1(data)}");
        Console.WriteLine($"Number of duplicates : {CountDuplicates2(data)}");

        Console.WriteLine("{0,15}{1,17}{2,17}{3,16}{4,16}", "n", "duplicate1-count", "duplicate2-count", "duplicate1-time",
            "duplicate2-time");
        Console.WriteLine("{0,15}{0,17}{0,17}{0,16}{0,16}", "----------");

        double time1Total = 0;
        double time2Total = 0;

        for (int n = 0; n <= 25; n += 1)
        {
            var testData = Enumerable.Range(0, n).ToArray();
            int count1 = CountDuplicates1(data);
            int count2 = CountDuplicates2(data);
            double time1 = Time(() => CountDuplicates1(data), 100);
            double time2 = Time(() => CountDuplicates2(data), 100);
            Console.WriteLine("{0,15}{1,17}{2,17}{3,16:0.00000}{4,16:0.00000}", n, count1, count2, time1, time2);
            time1Total += time1;
            time2Total += time2;
        }

        Console.WriteLine($"Average Time 1: {time1Total / 25}");
        Console.WriteLine($"Average Time 2: {time2Total / 25}");

        Console.WriteLine();
        Console.WriteLine("Hashing");
        Console.WriteLine("-------");
        Console.WriteLine("positive int 3: " + 3.GetHashCode()); // positive int: 3
        Console.WriteLine("negative int -3: " + -3.GetHashCode()); // negative int: -3
        Console.WriteLine("string cat : " + "cat".GetHashCode()); // string: -1599535192
        Console.WriteLine("other string dog: " + "dog".GetHashCode()); // other string: -73217838
        Console.WriteLine("float/double 3.14: " + 3.14.GetHashCode()); // float/double: 300063655
        Console.WriteLine("bool true: " + true.GetHashCode()); // bool: 1
        Console.WriteLine("List/object: " + new List<string>().GetHashCode()); // List/object: 27252167
    
// Recursion
        // Console.WriteLine(Fibonacci(90));

        // string s = "abc---def";
        // Console.WriteLine("Index: 012345678");
        // Console.WriteLine("1)     {0}", s);
        // Console.WriteLine("2)     {0}", s.Remove(3));
        // Console.WriteLine("3)     {0}", s.Remove(3, 3));
        // Console.WriteLine("orig.) {0}", s);

        Permutations("ABC");

    }



    // Slow Fib
    // public static int Fib(int n)
    // {
    //     if (n <= 2)
    //     {
    //         // Fib(2) = 1 and Fib(1) = 1
    //         return 1;
    //     }
    //     else
    //     {
    //         // Fib(n) = Fib(n - 1) + Fib(n - 2)
    //         return Fib(n - 1) + Fib(n - 2);
    //     }
    // }

    public static long Fibonacci(int n, Dictionary<int, long> remember = null)
{
    // If this is the first time calling the function, then
    // we need to create the dictionary.
    if (remember == null)
        remember = new Dictionary<int, long>();
    // Or, remember ??= new Dictionary<int, long>();

    // Base Case
    if (n <= 2)
        return 1;

    // Check if we have solved this one before
    if (remember.ContainsKey(n))
        return remember[n];
    // Or:
    //     if (remember.TryGetValue(n, out long value))
    //         return value;

    // Otherwise solve with recursion
    var result = Fibonacci(n - 1, remember) + Fibonacci(n - 2, remember);

    // Remember result for potential later use
    remember[n] = result;
    return result;
}



public static void Permutations(string letters, string word = "")
{
    // Try adding each of the available letters
    // to the 'word' and add up all the
    // resulting permutations.
    if (letters.Length == 0)
    {
        Console.WriteLine(word);
    }
    else
    {
        for (var i = 0; i < letters.Length; i++)
        {
            // Make a copy of the letters to pass to the
            // the next call to permutations.  We need
            // to remove the letter we just added before
            // we call permutations again.
            var lettersLeft = letters.Remove(i, 1); // Remove returns, starting from the given index, the given number of items (or the entirety by default)

            // Add the new letter to the word we have so far
            Permutations(lettersLeft, word + letters[i]);  // Remove creates a new string, it doesn't affect the original string; therefor, letters[i] is still the first letter
        }
    }
}




    // Count the number of duplicate items; Method 1:
    private static int CountDuplicates1(int[] data)
    {
        HashSet<int> noDuplicates = new HashSet<int> (); // or just = [];
        foreach (int member in data)
        {
            // if (!noDuplicates.Contains(member)) // this check makes this function a little slower than the other; otherwise, it's very slightly faster
            // {
            //     noDuplicates.Add(member);
            // }
            noDuplicates.Add(member);
        }
        // Or,
        // HashSet<int> noDuplicates = [.. data];
        //     return data.Length - noDuplicates.Count;
        return data.Length - noDuplicates.Count;
    }

    // Method 2:
    private static int CountDuplicates2(int[] data)
    {
        HashSet<int> noDuplicates = new HashSet<int> (data); // or just = new (data);
        return data.Length - noDuplicates.Count;
    }

    private static double Time(Action executeAlgorithm, int times)
    {
        var sw = Stopwatch.StartNew();
        for (var i = 0; i < times; ++i)
        {
            executeAlgorithm();
        }

        sw.Stop();
        return sw.Elapsed.TotalMilliseconds / times;
    }


}
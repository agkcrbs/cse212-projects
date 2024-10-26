using System.Collections;

public static class Recursion
{
    /// <summary>
    /// #############
    /// # Problem 1 #
    /// #############
    /// Using recursion, find the sum of 1^2 + 2^2 + 3^2 + ... + n^2
    /// and return it.  Remember to both express the solution in 
    /// terms of recursive call on a smaller problem and to identify
    /// a base case (terminating case).  If the value of n <= 0,
    /// just return 0.  A loop should not be used.
    /// </summary>
    public static int SumSquaresRecursive(int n)
    {
        // TO DO Start Problem 1
        // Remember: use n * n or (int)Math.Pow(n, 2), but not n ^ 2
        if (n <= 0)
            return 0;
        else
            return n * n + SumSquaresRecursive(n - 1);
    }

    /// <summary>
    /// #############
    /// # Problem 2 #
    /// #############
    /// Using recursion, insert permutations of length 'size' from 
    /// a list of 'letters' into the results list.  This function
    /// should assume that each letter is unique (i.e. the function 
    /// does not need to find unique permutations).
    ///
    /// In mathematics, we can calculate the number of permutations 
    /// using the formula: len(letters)! / (len(letters) - size)!
    ///
    /// For example, if letters was [A,B,C] and size was 2 then the 
    /// following would be the contents of the results array after 
    /// the function ran: AB, AC, BA, BC, CA, CB (might be in a 
    /// different order).
    ///
    /// You can assume that the size specified is always valid 
    /// (between 1 and the length of the letters list).
    /// </summary>
    public static void PermutationsChoose(List<string> results, string letters, int size, string word = "")
    {
        // TO DO Start Problem 2
        if (word.Length == size) // not: letters.Length
        {
            results.Add(word);
            return;
        }
        else
        {
            for (var i = 0; i < letters.Length; i++) // not: i < size
            {
                var lettersLeft = letters.Remove(i, 1);
                PermutationsChoose(results, lettersLeft, size, word + letters[i]);
            }
        }
    }

    /// <summary>
    /// #############
    /// # Problem 3 #
    /// #############
    /// Imagine that there was a staircase with 's' stairs.  
    /// We want to count how many ways there are to climb 
    /// the stairs.  If the person could only climb one 
    /// stair at a time, then the total would be just one.  
    /// However, if the person could choose to climb either 
    /// one, two, or three stairs at a time (in any order), 
    /// then the total possibilities become much more 
    /// complicated.  If there were just three stairs,
    /// the possible ways to climb would be four as follows:
    ///
    ///     1 step, 1 step, 1 step
    ///     1 step, 2 step
    ///     2 step, 1 step
    ///     3 step
    ///
    /// With just one step to go, the ways to get
    /// to the top of 's' stairs is to either:
    ///
    /// - take a single step from the second to last step, 
    /// - take a double step from the third to last step, 
    /// - take a triple step from the fourth to last step
    ///
    /// We don't need to think about scenarios like taking two 
    /// single steps from the third to last step because this
    /// is already part of the first scenario (taking a single
    /// step from the second to last step).
    ///
    /// These final leaps give us a sum:
    ///
    /// CountWaysToClimb(s) = CountWaysToClimb(s-1) + 
    ///                       CountWaysToClimb(s-2) +
    ///                       CountWaysToClimb(s-3)
    ///
    /// To run this function for larger values of 's', you will 
    /// need to update this function to use memoization.  The 
    /// parameter 'remember' has already been added as an input 
    /// parameter to the function for you to complete this task.
    /// </summary>
    public static decimal CountWaysToClimb(int s, Dictionary<int, decimal>? remember = null)
    {
        // TO DO Start Problem 3
        // If this is the first time calling the function, then
        // we need to create the dictionary.
        if (remember == null)
            remember = new Dictionary<int, decimal>();

        // Check if we have solved this one before
        if (remember.ContainsKey(s))
            return remember[s];

        // Base Cases
        if (s == 0)
            return 0;
        if (s == 1)
            return 1;
        if (s == 2)
            return 2;
        if (s == 3)
            return 4;

        // Otherwise solve with recursion
        decimal ways = CountWaysToClimb(s - 1, remember) + CountWaysToClimb(s - 2, remember) + CountWaysToClimb(s - 3, remember); // Make sure to pass in the dictionary.

        // Remember result for potential later use
        remember[s] = ways;
        return ways;
    }

    /// <summary>
    /// #############
    /// # Problem 4 #
    /// #############
    /// A binary string is a string consisting of just 1's and 0's.  For example, 1010111 is 
    /// a binary string.  If we introduce a wildcard symbol * into the string, we can say that 
    /// this is now a pattern for multiple binary strings.  For example, 101*1 could be used 
    /// to represent 10101 and 10111.  A pattern can have more than one * wildcard.  For example, 
    /// 1**1 would result in 4 different binary strings: 1001, 1011, 1101, and 1111.
    ///	
    /// Using recursion, insert all possible binary strings for a given pattern into the results list.  You might find 
    /// some of the string functions like IndexOf and [..X] / [X..] to be useful in solving this problem.
    /// </summary>
    public static void WildcardBinary(string pattern, List<string> results)
    {
        // TO DO Start Problem 4
        // I'm given a pattern and a results list.  Pattern should have
        // at least one asterisk character (*).  Find it with IndexOf().
        // Include a base case where there is no *.
        if (!pattern.Contains('*'))
        {
            results.Add(pattern);
            return;
        }
        // string pattern0 = pattern[pattern.IndexOf('*')].ToString() + "0" + pattern[pattern.IndexOf('*') + 1].ToString(); // This seeks an out-of-range index when * is at the end.
        string pattern0 = pattern.Substring(0, pattern.IndexOf('*')) + "0" + pattern.Substring(pattern.IndexOf('*') + 1); // No second index: Substring() continues to the end.
        WildcardBinary(pattern0, results);
        string pattern1 = pattern.Substring(0, pattern.IndexOf('*')) + '1' + pattern.Substring(pattern.IndexOf('*') + 1);
        WildcardBinary(pattern1, results);
        // Or: StringBuilder sb = new StringBuilder("hello"); sb[1] = 'a'; string result = sb.ToString(); // "hello" -> "hallo" -> convert back to a string.
        // Do not use string.Replace('a', 'b') here, because it replaces all instances of 'a', not just the first.
        // Do not try to concatenate char-types with +; only string + string or char + string (as with Substring()).
    }

    /// <summary>
    /// Use recursion to insert all paths that start at (0,0) and end at the
    /// 'end' square into the results list.
    /// </summary>
    public static void SolveMaze(List<string> results, Maze maze, int x = 0, int y = 0, List<ValueTuple<int, int>>? currPath = null)
    {
        // If this is the first time running the function, then we need
        // to initialize the currPath list.
        if (currPath == null) {
            currPath = new List<ValueTuple<int, int>>();
        }
        
        // currPath.Add((1,2)); // Use this syntax to add to the current path
        // results.Add(currPath.AsString()); // Use this to add your path to the results array keeping track of complete maze solutions when you find the solution.

        // TO DO Start Problem 5
        // ADD CODE HERE
        //
        // This function takes: a results List, a Maze object, ints x and y 
        // (default zero) representing the current location, and currPath: 
        // a nullable list of (int, int) ValueTuple types.  It returns 
        // nothing but potentially updates currPath and results.
        //
        // Maze.IsValidMove() takes currPath and x/y, returning a bool.
        // Maze.IsEnd() takes x/y and returns bool.
        //
        // I need to recursively check the present location and all available 
        // moves, and, if any reach the end, add them to currPath.  So the 
        // only things in currPath should be successful path spaces.  The
        // adding should postcede the recursion containing the IsEnd check.
        //
        // The base cases should be: no valid moves, and IsEnd is true.

        // Add the current position to the path:
        currPath.Add((x, y));

        // Check if it's the end and add currPath to results:
        if (maze.IsEnd(x,y))
            results.Add(currPath.AsString());
        else
        {
            // Check all directions and recursively explore the path.
            if (maze.IsValidMove(currPath, x - 1, y))
                SolveMaze(results, maze, x - 1, y, new List<ValueTuple<int, int>>(currPath));
            if (maze.IsValidMove(currPath, x, y + 1))
                SolveMaze(results, maze, x, y + 1, new List<ValueTuple<int, int>>(currPath));
            if (maze.IsValidMove(currPath, x + 1, y))
                SolveMaze(results, maze, x + 1, y, new List<ValueTuple<int, int>>(currPath));
            if (maze.IsValidMove(currPath, x, y - 1))
                SolveMaze(results, maze, x, y - 1, new List<ValueTuple<int, int>>(currPath));
        }

        // Backtrack and remove the current position from the path.
        currPath.RemoveAt(currPath.Count - 1);

        // if (maze.IsEnd(x, y))
        // {
        //     // currPath.Add((x, y));
        //     results.Add(currPath.AsString());
        //     // results.Add(new List<ValueTuple<int, int>>(currPath));
        //     return;
        // }

        // if (!maze.IsValidMove(currPath, x, y))
        // {
        //     return;
        // }

        // currPath.Add((x, y));

        // // Recursively check all directions:
        // SolveMaze(results, maze, x - 1, y, currPath);
        // SolveMaze(results, maze, x, y + 1, currPath);
        // SolveMaze(results, maze, x + 1, y, currPath);
        // SolveMaze(results, maze, x, y - 1, currPath);

        // // currPath.RemoveAt(currPath.Count - 1);
    }
}
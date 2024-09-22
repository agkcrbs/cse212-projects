public static class Arrays
{
    /// <summary>
    /// This function will produce an array of size 'length' starting with 'number' followed by multiples of 'number'.  For 
    /// example, MultiplesOf(7, 5) will result in: {7, 14, 21, 28, 35}.  Assume that length is a positive
    /// integer greater than 0.
    /// </summary>
    /// <returns>array of doubles that are the multiples of the supplied number</returns>
    public static double[] MultiplesOf(double number, int length) // Making this return List<double> fails tests...
    {
        // TODO Problem 1 Start
        // Remember: Using comments in your program, write down your process for solving this problem
        // step by step before you write the code. The plan should be clear enough that it could
        // be implemented by another person.

        // Task: create and return an array of multiples of a given number
        // Steps:  1) get a number and length
        //         2) make a holding (dynamic) array *** no, must be a fixed array
        //         3) put the number into it first (no, just do this in the loop)
        //         4) loop "length" times
        //         5) each loop, make multiples of "number"
        //         6) put each multiple into the array
        //         7) return the array *** must be a fixed array

        var holdingArray = new double[length];
        // holdingArray.Append(number);
        for (int i = 1; i <= length; i++)
        {
            holdingArray[i - 1] = number * i;
        }

        return holdingArray; // replace this return statement with your own
    }

    /// <summary>
    /// Rotate the 'data' to the right by the 'amount'.  For example, if the data is 
    /// List<int>{1, 2, 3, 4, 5, 6, 7, 8, 9} and an amount is 3 then the list after the function runs should be 
    /// List<int>{7, 8, 9, 1, 2, 3, 4, 5, 6}.  The value of amount will be in the range of 1 to data.Count, inclusive.
    ///
    /// Because a list is dynamic, this function will modify the existing data list rather than returning a new list.
    /// </summary>
    public static void RotateListRight(List<int> data, int amount)
    {
        // TODO Problem 2 Start
        // Remember: Using comments in your program, write down your process for solving this problem
        // step by step before you write the code. The plan should be clear enough that it could
        // be implemented by another person.

        // Task: shift members of an array a given number of spaces to the right, wrapping the end back around to the front
        // I'm given an array and a number by which to shift the elements, from 1 up to and including the whole length.
        // I could try a loop: counting back from the end, grabbing the index, storing it, deleting it, and inserting it at the front: O(n)
        // Or, copy the list from that point, then to that point, into a new array using Array.Copy().  Then copy it back to the original.
        // The instructions say "modify the existing data list".  Apparently List.InsertRange() does multiple values.  There is also RemoveRange().

        // Steps:  1) make a temporary array
        //         2) determine the desired starting index: Count minus amount
        //         3) use Array.CopyTo() to save the values (parameters: source start index, target array, target start index (zero), amount)
        //         4) use Array.InsertRange(index=0, iterable values) on the original array, adding back the temporary array
        //         5) chop off the copied values with Array.RemoveRange(Count, amount)

        var temporaryArray = new int[amount];
        data.CopyTo(data.Count - amount, temporaryArray, 0, amount);
        data.InsertRange(0, temporaryArray);
        data.RemoveRange(data.Count - amount, amount);
    }
}

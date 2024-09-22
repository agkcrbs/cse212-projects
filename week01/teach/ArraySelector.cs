public static class ArraySelector
{
    public static void Run()
    {
        var l1 = new[] { 1, 2, 3, 4, 5 };
        var l2 = new[] { 2, 4, 6, 8, 10};
        var select = new[] { 1, 1, 1, 2, 2, 1, 2, 2, 2, 1};
        var intResult = ListSelector(l1, l2, select);
        Console.WriteLine("<int[]>{" + string.Join(", ", intResult) + "}"); // <int[]>{1, 2, 3, 2, 4, 4, 6, 8, 10, 5}
    }

    private static int[] ListSelector(int[] list1, int[] list2, int[] select)
    {

// I need a loop... I need some if statements...
// I need to run through the selector, check if it's a 1 or 2, and then grab from the correct array.
// I need a counter to keep track of the serialy processed indices.
// Just put the grabbed values into the new return Array.
// No overflow checking required with the given selector array...

        var returnArray = new int[10];
        int counter1 = 0;
        int counter2 = 0;
        for (int index = 0; index < 10; index++) // The solution includes a shorter ternary conditional operator...
        {
            if (select[index] == 1)
            {
                returnArray[index] = list1[counter1++];
            }
            else
            {
                returnArray[index] = list2[counter2++];
            }
        }
        return returnArray;
    }
}
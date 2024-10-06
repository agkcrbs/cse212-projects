using System.Diagnostics;
using Microsoft.VisualStudio.TestTools.UnitTesting;

// TODO Problem 2 - Write and run test cases and fix the code to match requirements.

[TestClass]
public class PriorityQueueTests
{
    [TestMethod]
    // Scenario: Create PriorityItem objects and Enqueue them to a PriorityQueue object.
    // Expected Result: The queue's Length should equal the number of objects enqueued.
    // Defect(s) Found: None.
    public void TestPriorityQueue_Enqueue()
    {
        var value1 = new PriorityItem("President", 100);
        var value2 = new PriorityItem("Vice President", 90);
        var value3 = new PriorityItem("House Speaker", 80);
        var value4 = new PriorityItem("Senate Vice President", 70);
        var value5 = new PriorityItem("State Secretary", 60);
        var value6 = new PriorityItem("Treasury Secretary", 50);
        var value7 = new PriorityItem("Defense Secretary", 40);
        var value8 = new PriorityItem("General Attorney", 30);
        List<PriorityItem> toShuffle = new List<PriorityItem> {value1, value2, value3, value4, value5, value6, value7, value8};

        var priorityQueue = new PriorityQueue();

        // Shuffle the list using Fisher-Yates shuffle algorithm
        Random random = new Random();
        for (int i = toShuffle.Count - 1; i > 0; i--)
        {
            int j = random.Next(i + 1);
            // Swap elements at i and j
            var temp = toShuffle[i];
            toShuffle[i] = toShuffle[j];
            toShuffle[j] = temp;
        }

        for (int i = toShuffle.Count - 1; i >= 0; i--)
        {
                priorityQueue.Enqueue(toShuffle[i].Value, toShuffle[i].Priority);
                toShuffle.RemoveAt(i);
        }

        Assert.AreEqual(priorityQueue.Length, 8);
    }

    [TestMethod]
    // Scenario: Dequeue 3 PriorityItem objects from a populated PriorityQueue object.
    // Expected Result: queue's original Length - 3 == queue's new Length
    // Defect(s) Found: The length didn't decrease, so the items were not dequeued.
    //                  Added a RemoveAt method to the PriorityQueue class's Dequeue function.
    public void TestPriorityQueue_Dequeue()
    {
        var value1 = new PriorityItem("President", 100);
        var value2 = new PriorityItem("Vice President", 90);
        var value3 = new PriorityItem("House Speaker", 80);
        var value4 = new PriorityItem("Senate Vice President", 70);
        var value5 = new PriorityItem("State Secretary", 60);
        var value6 = new PriorityItem("Treasury Secretary", 50);
        var value7 = new PriorityItem("Defense Secretary", 40);
        var value8 = new PriorityItem("General Attorney", 30);
        List<PriorityItem> toShuffle = new() { value1, value2, value3, value4, value5, value6, value7, value8 };

        var priorityQueue = new PriorityQueue();

        // Shuffle the list using Fisher-Yates shuffle algorithm
        Random random = new Random();
        for (int i = toShuffle.Count - 1; i > 0; i--)
        {
            int j = random.Next(i + 1);
            // Swap elements at i and j
            var temp = toShuffle[i];
            toShuffle[i] = toShuffle[j];
            toShuffle[j] = temp;
        }

        for (int i = toShuffle.Count - 1; i >= 0; i--)
        {
            priorityQueue.Enqueue(toShuffle[i].Value, toShuffle[i].Priority);
            toShuffle.RemoveAt(i);
        }

        int originalLength = priorityQueue.Length;
        int numberToDequeue = 3;

        for (int i = numberToDequeue; i > 0; i--)
        {
            priorityQueue.Dequeue();
        }

        Assert.AreEqual(priorityQueue.Length, originalLength - numberToDequeue);
    }

    // Add more test cases as needed below.

    [TestMethod]
    // Scenario: Dequeue 3 PriorityItem objects from a populated PriorityQueue object.
    //           Check whether the object's Value is returned.
    // Expected Result: ["President", "Vice President", "House Speaker"]
    // Defect(s) Found: The Dequeuing function's for loop to find the highest priority was indexed wrongly.
    public void TestPriorityQueue_ReturnDequeued()
    {
        var value1 = new PriorityItem("President", 100);
        var value2 = new PriorityItem("Vice President", 90);
        var value3 = new PriorityItem("House Speaker", 80);
        var value4 = new PriorityItem("Senate Vice President", 70);
        var value5 = new PriorityItem("State Secretary", 60);
        var value6 = new PriorityItem("Treasury Secretary", 50);
        var value7 = new PriorityItem("Defense Secretary", 40);
        var value8 = new PriorityItem("General Attorney", 30);
        List<PriorityItem> toShuffle = [value1, value2, value3, value4, value5, value6, value7, value8];

        var priorityQueue = new PriorityQueue();

        // Shuffle the list using Fisher-Yates shuffle algorithm
        Random random = new Random();
        for (int i = toShuffle.Count - 1; i > 0; i--)
        {
            int j = random.Next(i + 1);
            // Swap elements at i and j
            var temp = toShuffle[i];
            toShuffle[i] = toShuffle[j];
            toShuffle[j] = temp;
        }

        for (int i = toShuffle.Count - 1; i >= 0; i--)
        {
            priorityQueue.Enqueue(toShuffle[i].Value, toShuffle[i].Priority);
            toShuffle.RemoveAt(i);
        }

        int numberToDequeue = 3;
        string[] expectedResultArray = [value1.Value, value2.Value, value3.Value];
        string[] resultArray = new string[numberToDequeue];

        for (int i = 0; i < numberToDequeue; i++) // single-line for loops can omit braces
            resultArray[i] = priorityQueue.Dequeue();

        CollectionAssert.AreEqual(expectedResultArray, resultArray); // regular Assert uses memory references and finds unequal specific objects
    }

    [TestMethod]
    // Scenario: Dequeue 3 PriorityItem objects from a populated PriorityQueue object.
    //           There is a same-priority item.  Check whether the first item was dequeued first.
    // Expected Result: ["President", "Lobbyist", "Vice President"]
    // Defect(s) Found: 
    public void TestPriorityQueue_DequeueEqualPriority()
    {
        var value1 = new PriorityItem("President", 100);
        var value2 = new PriorityItem("Vice President", 90);
        var value3 = new PriorityItem("House Speaker", 80);
        var value4 = new PriorityItem("Senate Vice President", 70);
        var value5 = new PriorityItem("State Secretary", 60);
        var value6 = new PriorityItem("Treasury Secretary", 50);
        var value7 = new PriorityItem("Defense Secretary", 40);
        var value8 = new PriorityItem("General Attorney", 30);
        var value9 = new PriorityItem("Lobbyist", 100);
        List<PriorityItem> toShuffle = [value1, value2, value3, value4, value5, value6, value7, value8];

        var priorityQueue = new PriorityQueue();

        // Shuffle the list using Fisher-Yates shuffle algorithm
        Random random = new Random();
        for (int i = toShuffle.Count - 1; i > 0; i--)
        {
            int j = random.Next(i + 1);
            // Swap elements at i and j
            var temp = toShuffle[i];
            toShuffle[i] = toShuffle[j];
            toShuffle[j] = temp;
        }

        for (int i = toShuffle.Count - 1; i >= 0; i--)
        {
            priorityQueue.Enqueue(toShuffle[i].Value, toShuffle[i].Priority);
            toShuffle.RemoveAt(i);
        }

        priorityQueue.Enqueue(value9.Value, value9.Priority);

        int numberToDequeue = 3;
        string[] expectedResultArray = [value1.Value, value9.Value, value2.Value];
        string[] resultArray = new string[numberToDequeue];

        for (int i = 0; i < numberToDequeue; i++) // single-line for loops can omit braces
            resultArray[i] = priorityQueue.Dequeue();

        CollectionAssert.AreEqual(expectedResultArray, resultArray); // regular Assert uses memory references and finds unequal specific objects
    }

    [TestMethod]
    // Scenario: Try to Dequeue from an empty queue.
    // Expected Result: Exception should be thrown with appropriate error message.
    // Defect(s) Found: None.
    public void TestPriorityQueue_Empty()
    {
        var priorityQueue = new PriorityQueue();

        try
        {
            priorityQueue.Dequeue();
            Assert.Fail("Exception should have been thrown.");
        }
        catch (InvalidOperationException e)
        {
            Assert.AreEqual("The queue is empty.", e.Message);  // must match the Dequeue function error message
        }
        catch (AssertFailedException)
        {
            throw;
        }
        catch (Exception e)
        {
            Assert.Fail(
                 string.Format("Unexpected exception of type {0} caught: {1}",
                                e.GetType(), e.Message)
            );
        }
    }

}
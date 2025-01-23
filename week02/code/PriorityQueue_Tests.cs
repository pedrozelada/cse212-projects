using Microsoft.VisualStudio.TestTools.UnitTesting;

// TODO Problem 2 - Write and run test cases and fix the code to match requirements.

[TestClass]
public class PriorityQueueTests
{
    [TestMethod]
    // Scenario: add 5 people with decreasing priorities and perform  5 dequeue.
    // Expected Result: pedro, ayelen, nicolas, angie, carlos.
    // Defect(s) Found: The dequeue method does not remove the value from the queue and always returns the item with the highest priority.
    public void TestPriorityQueue_DecreasingPriorities()
    {
        var pedro = new PriorityItem("Pedro", 5);
        var ayelen  = new PriorityItem("Ayelen", 4);
        var nicolas = new PriorityItem("Nicolas", 3);  
        var angie = new PriorityItem("Angie", 2); 
        var carlos = new PriorityItem("Carlos", 1); 
    
        PriorityItem[] expectedResult = [pedro, ayelen, nicolas, angie, carlos];
        

        var priorityQueue = new PriorityQueue();
        priorityQueue.Enqueue(pedro.Value, pedro.Priority);
        priorityQueue.Enqueue(ayelen.Value, ayelen.Priority);
        priorityQueue.Enqueue(nicolas.Value, nicolas.Priority);
        priorityQueue.Enqueue(angie.Value, angie.Priority);
        priorityQueue.Enqueue(carlos.Value, carlos.Priority);

        int i = 0;

        while (priorityQueue.Length > 0)
        {
            if (i >= expectedResult.Length)
            {
                Assert.Fail("Queue should have run out of items by now.");
            }

            var PriorityItem = priorityQueue.Dequeue();
            Assert.AreEqual(expectedResult[i].Value, PriorityItem);
            i++;
        }
    }

    [TestMethod]
    // Scenario: 5 people with different priority. They are not added in descending order
    // Expected Result: pedro, ayelen, nicolas, angie, carlos.
    // Defect(s) Found: In the Dequeue() method, the queue does not traverse to the last element, but penultimate item in the list.
    public void TestPriorityQueue_DifferentPriorities()
    {
        var pedro = new PriorityItem("Pedro", 3);
        var ayelen  = new PriorityItem("Ayelen", 8);
        var nicolas = new PriorityItem("Nicolas", 5);  
        var angie = new PriorityItem("Angie", 9); 
        var carlos = new PriorityItem("Carlos", 4); 
    
        PriorityItem[] expectedResult = [angie, ayelen, nicolas, carlos, pedro];
        
        var priorityQueue = new PriorityQueue();
        priorityQueue.Enqueue(pedro.Value, pedro.Priority);
        priorityQueue.Enqueue(ayelen.Value, ayelen.Priority);
        priorityQueue.Enqueue(nicolas.Value, nicolas.Priority);
        priorityQueue.Enqueue(angie.Value, angie.Priority);
        priorityQueue.Enqueue(carlos.Value, carlos.Priority);

        int i = 0;

        while (priorityQueue.Length > 0)
        {
            if (i >= expectedResult.Length)
            {
                Assert.Fail("Queue should have run out of items by now.");
            }

            var PriorityItem = priorityQueue.Dequeue();
            Assert.AreEqual(expectedResult[i].Value, PriorityItem);
            i++;
        }
    }

        
    [TestMethod]
    // Scenario: Add 3 people, do 2 rounds of Dequeue, then add 2 people with higher priority.
    // Expected Result: pedro, ayelen, carlos, angie, nicolas
    // Defect(s) Found: In the Dequeue() method, the queue does not traverse to the last element, but penultimate item in the list.
    public void TestPriorityQueue_AddNewHighPriority()
    {
        var pedro = new PriorityItem("Pedro", 5);
        var ayelen  = new PriorityItem("Ayelen", 4);
        var nicolas = new PriorityItem("Nicolas", 3);  
        var angie = new PriorityItem("Angie", 6); 
        var carlos = new PriorityItem("Carlos", 8); 

        PriorityItem[] expectedResult = [pedro, ayelen, carlos, angie, nicolas];

        var priorityQueue = new PriorityQueue();
        priorityQueue.Enqueue(nicolas.Value, nicolas.Priority);
        priorityQueue.Enqueue(pedro.Value, pedro.Priority);
        priorityQueue.Enqueue(ayelen.Value, ayelen.Priority);

        int i = 0;
        for (; i < 2; i++)
        {
            var PriorityItem = priorityQueue.Dequeue();
            Assert.AreEqual(expectedResult[i].Value, PriorityItem);
        }

        priorityQueue.Enqueue(carlos.Value, carlos.Priority);
        priorityQueue.Enqueue(angie.Value, angie.Priority);

        while (priorityQueue.Length > 0)
        {
            var PriorityItem = priorityQueue.Dequeue();
            Assert.AreEqual(expectedResult[i].Value, PriorityItem);
            i++;
        }
    }

         
    [TestMethod]
    // Scenario: Add 5 people, 3 with the same priority, and perform several rounds of Dequeue.
    // Expected Result: pedro, nicolas, angie, carlos, ayelen
    // Defect(s) Found: The dequeue method always selects the last index of the element with the highest priority because >=
    public void TestPriorityQueue_SamePriority()
    {
        var pedro = new PriorityItem("Pedro", 5);
        var ayelen  = new PriorityItem("Ayelen", 3);
        var nicolas = new PriorityItem("Nicolas", 4);  
        var angie = new PriorityItem("Angie", 4); 
        var carlos = new PriorityItem("Carlos", 4); 

        PriorityItem[] expectedResult = [pedro, nicolas, angie, carlos, ayelen];

        var priorityQueue = new PriorityQueue();
        priorityQueue.Enqueue(nicolas.Value, nicolas.Priority);
        priorityQueue.Enqueue(pedro.Value, pedro.Priority);
        priorityQueue.Enqueue(angie.Value, angie.Priority);
        priorityQueue.Enqueue(ayelen.Value, ayelen.Priority);
        priorityQueue.Enqueue(carlos.Value, carlos.Priority);
        

        int i = 0;
        while (priorityQueue.Length > 0)
        {
            if (i >= expectedResult.Length)
            {
                Assert.Fail("Queue should have run out of items by now.");
            }

            var PriorityItem = priorityQueue.Dequeue();
            Assert.AreEqual(expectedResult[i].Value, PriorityItem);
            i++;
        }
    }

    [TestMethod]
    // Scenario: Attempt to `Dequeue` from an empty queue.
    // Expected Result: An InvalidOperationException should be thrown with the message "The queue is empty."
    // Defect(s) Found: This works fine
    public void TestPriorityQueue_EmptyQueue()
    {
        var priorityQueue = new PriorityQueue();

        try
        {
            priorityQueue.Dequeue();
            Assert.Fail("Exception should have been thrown.");
        }
        catch (InvalidOperationException e)
        {
            Assert.AreEqual("The queue is empty.", e.Message);
        }
    }   

}
using Microsoft.VisualStudio.TestTools.UnitTesting;

// TODO Problem 2 - Write and run test cases and fix the code to match requirements.

[TestClass]
public class PriorityQueueTests
{
    [TestMethod]
    // Scenario: Enqueue three items with different priorities(A:1, B:6, C:3), then Dequeue once.
    // Expected Result: B should be returned, since it's the highest priority.
    // Defect(s) Found: 
    //1. The Dequeue loop ( for index= 1; index < _queue.Count - 1; index++) nver checks the last item
    //in the queue, since it stops one index short. This test happened to pass anyway because B is the 
    //highest priority and wasn't the last item, but the defect is still present and would cause incorrect
    //results if the highest priority item were enqueue last.

    public void TestPriorityQueue_1()
    {
        var priorityQueue = new PriorityQueue();
        priorityQueue.Enqueue("A",1);
        priorityQueue.Enqueue("B",6);
        priorityQueue.Enqueue("C",3);
        var result = priorityQueue.Dequeue();
        Assert.AreEqual("B", result);
    }

    [TestMethod]
    // Scenario: Enqueue three items (A:2 ,B:4, C:8), where the highest priority item 
    // (C:8) is the last one added.
    // Expected Result: C should be returned, since its the highest priority
    // Defect(s) Found: 
    //The Dequeue loops stop one index too early (index < _queue.Count - 1), so it never 
    //checks the last item in the queue. Here C (was the highest priority, enqueued last),
    //is skipped and B priority 4 is incorrectly return instead.
    public void TestPriorityQueue_2()
    {
        var priorityQueue = new PriorityQueue();
        priorityQueue.Enqueue("A",2);
        priorityQueue.Enqueue("B",4);
        priorityQueue.Enqueue("C",8);
        var result = priorityQueue.Dequeue();
        Assert.AreEqual("C",result);
    }

    // Add more test cases as needed below.

    [TestMethod]
    // Scenario: Enqueue three items (A:3 ,B:6, C:6), where we have multiple values 
    // with the  the highest priority item (B:6, C:6) then the item closest to the 
    // front of the queue will be removed.
    // Expected Result: B should be returned, since its the highest priority and was 
    //added first.
    // Defect(s) Found: 
    //The Dequeue loops used >= when comparing priorities, which let a later item C with
    //an equal priority to the current best B overwrite it as the highest priority item.
    //This is against the tie breaking rule, which says the item closest to the front should
    //win . Changed the >= to > so the ties keep the earlier item.
    public void TestPriorityQueue_3()
    {
        var priorityQueue = new PriorityQueue();
        priorityQueue.Enqueue("A",3);
        priorityQueue.Enqueue("B",6);
        priorityQueue.Enqueue("C",6);
        var result = priorityQueue.Dequeue();
        Assert.AreEqual("B",result);
    }

    [TestMethod]
    // Scenario: Try to get the highest priority from an empty queue
    // Expected Result: Exception should be thrown with appropriate error message.
    // Defect(s) Found: 
    //None. The empty check (_queue.Count == 0) correctly throws InvalidOperationException
    //with a message "The queue is empty." before any priority comparison logic runs.
    public void TestPriorityQueue_4()
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
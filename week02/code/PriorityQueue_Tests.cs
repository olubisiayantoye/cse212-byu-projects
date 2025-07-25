using Microsoft.VisualStudio.TestTools.UnitTesting;

// TODO Problem 2 - Write and run test cases and fix the code to match requirements.

[TestClass]
public class PriorityQueueTests
{
    [TestMethod]
    // Scenario: create a queue with the following items and priorities. beans (1), diamonds (8), books (4), clothes(3), family(10). Dequeue all of the items
    // Expected Result: family, diamonds, books, clothes, beans.
    // Defect(s) Found: the index was off by one since it was doing _queue.Count - 1, so I removed the -1 and that fixed that. I think found that it wasn't removing the high priority items from the queue, only finding the highest priority and returning it. I added functionality to remove it from the queue.
    public void TestPriorityQueue_1()
    {
        var beans = new PriorityItem("beans", 1);
        var diamonds = new PriorityItem("diamonds", 8);
        var books = new PriorityItem("books", 4);
        var clothes = new PriorityItem("clothes", 3);
        var family = new PriorityItem("family", 10);

        var priorityQueue = new PriorityQueue();
        priorityQueue.Enqueue(beans.Value, beans.Priority);
        priorityQueue.Enqueue(diamonds.Value, diamonds.Priority);
        priorityQueue.Enqueue(books.Value, books.Priority);
        priorityQueue.Enqueue(clothes.Value, clothes.Priority);
        priorityQueue.Enqueue(family.Value, family.Priority);

        PriorityItem[] expectedResult = [family, diamonds, books, clothes, beans];

        for (int i = 0; i < expectedResult.Length; i++)
        {
            var item = priorityQueue.Dequeue();
            Assert.AreEqual(expectedResult[i].Value, item);
        }
    }

    [TestMethod]
    // Scenario: create a queue with the following items and priorities. shoes (3), socks (2), shirt (4), pants (4), hat (1)
    // Expected Result: shirt, pants, shoes, socks, hat
    // Defect(s) Found: removed the >= when comparing the priorities, and made it so it only changes the high priority index if the priority of the index is greater >
    public void TestPriorityQueue_2()
    {
        var shoes = new PriorityItem("shoes", 3);
        var socks = new PriorityItem("socks", 2);
        var shirt = new PriorityItem("shirt", 4);
        var pants = new PriorityItem("pants", 4);
        var hat = new PriorityItem("hat", 1);

        var priorityQueue = new PriorityQueue();
        priorityQueue.Enqueue(shoes.Value, shoes.Priority);
        priorityQueue.Enqueue(socks.Value, socks.Priority);
        priorityQueue.Enqueue(shirt.Value, shirt.Priority);
        priorityQueue.Enqueue(pants.Value, pants.Priority);
        priorityQueue.Enqueue(hat.Value, hat.Priority);

        PriorityItem[] expectedResult = [shirt, pants, shoes, socks, hat];

        for (int i = 0; i < expectedResult.Length; i++)
        {
            var item = priorityQueue.Dequeue();
            Assert.AreEqual(expectedResult[i].Value, item);
        }
    }

    // Add more test cases as needed below.
}
/// <summary>
/// Maintain a Customer Service Queue.  Allows new customers to be 
/// added and allows customers to be serviced.
/// </summary>
public class CustomerService {
    public static void Run() {
        // Example code to see what's in the customer service queue:
        // var cs = new CustomerService(10);
        // Console.WriteLine(cs);

        // Test Cases

        // Test 1
        // Scenario: Add one customer and then serve that customer.
        // Expected Result: The customer that was added should be displayed when served.
        Console.WriteLine("Test 1");
        var cs1 = new CustomerService(4);
        cs1.AddNewCustomer();
        cs1.ServeCustomer();
        // Defect(s) Found: ServeCustomer removed the customer from the queue BEFORE reading 
        // them, so it displayed the wrong customer (or crashed). Fixed by reading the customer 
        // first, then removing them.

        Console.WriteLine("=================");

        // Test 2
        // Scenario: Add two customers and serve them in order.
        // Expected Result: Customers should be served in the same order they were added (FIFO).
        Console.WriteLine("Test 2");
        var cs2 = new CustomerService(4);
        cs2.AddNewCustomer();
        cs2.AddNewCustomer();
        Console.WriteLine($"Before serving customers: {cs2}");
        cs2.ServeCustomer();
        cs2.ServeCustomer();
        Console.WriteLine($"After serving customers: {cs2}");
        // Defect(s) Found: None.

        Console.WriteLine("=================");

        // Test 3
        // Scenario: Try to serve a customer when the queue is empty.
        // Expected Result: An error message should be displayed instead of crashing.
        Console.WriteLine("Test 3");
        var cs3 = new CustomerService(4);
        cs3.ServeCustomer();
        // Defect(s) Found: ServeCustomer had no check for an empty queue, so it would crash 
        // trying to access an item that didn't exist. Fixed by adding a check for 
        // _queue.Count <= 0 before serving.

        Console.WriteLine("=================");

        // Test 4
        // Scenario: Fill the queue to its max size, then try to add one more customer.
        // Expected Result: An error message should be displayed when trying to add beyond capacity.
        Console.WriteLine("Test 4");
        var cs4 = new CustomerService(4);
        cs4.AddNewCustomer();
        cs4.AddNewCustomer();
        cs4.AddNewCustomer();
        cs4.AddNewCustomer();
        cs4.AddNewCustomer();
        Console.WriteLine($"Service Queue: {cs4}");
        // Defect(s) Found: AddNewCustomer used _queue.Count > _maxSize, which allowed one 
        // extra customer beyond the max size before blocking. Fixed by changing the check to 
        // _queue.Count >= _maxSize.

        Console.WriteLine("=================");

        // Test 5
        // Scenario: Create a CustomerService with an invalid size (0 or less).
        // Expected Result: The max size should default to 10.
        Console.WriteLine("Test 5");
        var cs5 = new CustomerService(0);
        Console.WriteLine($"Size should be 10: {cs5}");
        // Defect(s) Found: None.
    }

    private readonly List<Customer> _queue = new();
    private readonly int _maxSize;

    public CustomerService(int maxSize) {
        if (maxSize <= 0)
            _maxSize = 10;
        else
            _maxSize = maxSize;
    }

    /// <summary>
    /// Defines a Customer record for the service queue.
    /// This is an inner class.  Its real name is CustomerService.Customer
    /// </summary>
    private class Customer {
        public Customer(string name, string accountId, string problem) {
            Name = name;
            AccountId = accountId;
            Problem = problem;
        }

        private string Name { get; }
        private string AccountId { get; }
        private string Problem { get; }

        public override string ToString() {
            return $"{Name} ({AccountId})  : {Problem}";
        }
    }

    /// <summary>
    /// Prompt the user for the customer and problem information.  Put the 
    /// new record into the queue.
    /// </summary>
    private void AddNewCustomer() {
        // Verify there is room in the service queue
        if (_queue.Count >= _maxSize) {
            Console.WriteLine("Maximum Number of Customers in Queue.");
            return;
        }

        Console.Write("Customer Name: ");
        var name = Console.ReadLine()!.Trim();
        Console.Write("Account Id: ");
        var accountId = Console.ReadLine()!.Trim();
        Console.Write("Problem: ");
        var problem = Console.ReadLine()!.Trim();

        // Create the customer object and add it to the queue
        var customer = new Customer(name, accountId, problem);
        _queue.Add(customer);
    }

    /// <summary>
    /// Dequeue the next customer and display the information.
    /// </summary>
    private void ServeCustomer() {
        if (_queue.Count <= 0) {
            Console.WriteLine("No Customers in the queue");
        }
        else {
            var customer = _queue[0];
            _queue.RemoveAt(0);
            Console.WriteLine(customer);
        }
    }

    /// <summary>
    /// Support the WriteLine function to provide a string representation of the
    /// customer service queue object. This is useful for debugging. If you have a 
    /// CustomerService object called cs, then you run Console.WriteLine(cs) to
    /// see the contents.
    /// </summary>
    /// <returns>A string representation of the queue</returns>
    public override string ToString() {
        return $"[size={_queue.Count} max_size={_maxSize} => " + string.Join(", ", _queue) + "]";
    }
}
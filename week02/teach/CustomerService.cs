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
        // Scenario:        Create a new Customer Service queue that takes an integer called maxSize 
        //                  and saves it as _maxSize.  If the integer is <= 0, change the size to 10.
        // Expected Result: After initializing with (0), cs._maxSize should be 10.
        //                  Initializing with 1 should leave the _maxSize as 1.

        Console.WriteLine("Test 1");
        var cs1 = new CustomerService(0);
        if (cs1._maxSize == 10)
        {
            Console.WriteLine("The maximum size was set by default to 10.");
        }
        else
        {
            Console.WriteLine("There was a problem with a zero-sized maximum size.");
        }
        var cs2 = new CustomerService(2);
        if (cs2._maxSize == 2)
        {
            Console.WriteLine("The maximum size initialized to the input size.");
        }
        else
        {
            Console.WriteLine("There was a problem setting the maximum size.");
        }

        // Defect(s) Found: None.

        Console.WriteLine("=================");

        // Test 2
        // Scenario:        AddNewCustomer adds Customer objects to the back of the
        //                  Customer Service queue.
        // Expected Result: After initializing a cs object and running AddNewCustomer,
        //                  cs._queue[cs._queue.Count - 1] should show that customer.
        Console.WriteLine("Test 2");
        cs2.AddNewCustomer();
        Console.WriteLine(cs2._queue[cs2._queue.Count - 1]);

        // Defect(s) Found: None.

        Console.WriteLine("=================");

        // Test 3
        // Scenario:        AddNewCustomer raises an error if the Customer Service queue is full.
        // Expected Result: If AddNewCustomer is run more than the maximum size number of times,
        //                  a "queue full" message will appear.
        Console.WriteLine("Test 3");
        cs2.AddNewCustomer();
        cs2.AddNewCustomer();
        cs2.AddNewCustomer();

        // Defect(s) Found: None.

        Console.WriteLine("=================");

        // Test 4
        // Scenario:        ServeCustomer removes and displays the first item in the queue.
        // Expected Result: After dequeuing, the item should have been retained for display, and
        //                  cs._queue[0] should show the secondly input customer.
        Console.WriteLine("Test 4");
        Console.Write("Customer being served: ");
        cs2.ServeCustomer();
        Console.Write("Next customer in line: ");
        Console.WriteLine(cs2._queue[0]);

        // Defect(s) Found: The function removes the item before saving it for display.  Reverse
        //                  the order: save it for display, then remove it.

        Console.WriteLine("=================");

        // Test 5
        // Scenario:        ServeCustomer raises an error with an empty queue.
        // Expected Result: When cs._queue.Count is zero, ServeCustomer should fail.
        Console.WriteLine("Test 5");
        var cs3 = new CustomerService(1);
        cs3.ServeCustomer();

        // Defect(s) Found: The function didn't check for size at all, 
        //                  so it did not fail when the queue was empty.

        Console.WriteLine("=================");
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
        if (_queue.Count > _maxSize) {
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
        if (_queue.Count > 0)
        {
            var customer = _queue[0];
            _queue.RemoveAt(0);
            Console.WriteLine(customer);
        }
        else
        {
            Console.WriteLine("The queue was empty.");
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
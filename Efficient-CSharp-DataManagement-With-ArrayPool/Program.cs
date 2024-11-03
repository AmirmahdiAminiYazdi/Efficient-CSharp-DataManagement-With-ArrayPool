using System.Buffers;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;

class Program
{
    static void Main()
    {
        int numberOfCustomers = 100000; // Number of customers
        var pool = ArrayPool<int>.Shared; // Get shared ArrayPool

        // ============================
        // 1. Using ArrayPool to manage customer data efficiently
        // ============================

        var watch = Stopwatch.StartNew(); // Start timing
        for (int i = 0; i < 10; i++)
        {
            int[] customerData = pool.Rent(numberOfCustomers); // Rent an array from the pool
            for (int j = 0; j < numberOfCustomers; j++)
            {
                customerData[j] = j; // Populate customer data
            }
            pool.Return(customerData); // Return array to the pool for reuse
        }
        watch.Stop(); // Stop timing
        Console.WriteLine($"Time taken using ArrayPool for managing customer data: {watch.ElapsedMilliseconds} ms");


        // ============================
        // 2. Using a multidimensional array
        // ============================
        int[,] customerMatrix = new int[100, 100]; // Multidimensional array to store customer info
        for (int i = 0; i < 100; i++)
        {
            for (int j = 0; j < 100; j++)
            {
                customerMatrix[i, j] = i + j; // Populate multidimensional array
            }
        }
        watch.Stop(); // Stop timing
        Console.WriteLine($"Time taken to process multidimensional array for customers: {watch.ElapsedMilliseconds} ms");

        // ============================
        // 3. Using a jagged array
        // ============================
        int[][] customerJaggedArray = new int[5][];// Jagged array for storing variable customer data
        for (int i = 0; i < customerJaggedArray.Length; i++)
        {
            customerJaggedArray[i] = new int[i + 1]; // Initialize each jagged array
            for (int j = 0; j <= i; j++)
            {
                customerJaggedArray[i][j] = j; // Populate jagged array
            }
        }
        Console.WriteLine("Contents of the jagged array for customers:");
        foreach (var row in customerJaggedArray)
        {
            Console.WriteLine(string.Join(", ", row)); // Display contents of jagged array
        }

        // ============================
        // 4. Using BitArray to track customer statuses
        // ============================
        BitArray customerStatus = new BitArray(10); // BitArray to store customer status
        for (int i = 0; i < 10; i++)
        {
            customerStatus[i] = (i % 2 == 0); // Set customer status
        }
        Console.WriteLine("Contents of the BitArray showing customer statuses:");
        foreach (bool status in customerStatus)
        {
            Console.WriteLine(status ? "Active" : "Inactive"); // Display customer status
        }
        Console.WriteLine();
        // ============================
        // 5. Using Enumerator to display customer data
        // ============================
        Console.WriteLine("Using Enumerator to display sample customer data:");
        int[] sampleData = { 1, 2, 3, 4, 5 }; // Sample data
        foreach (var item in sampleData)
        {
            Console.WriteLine(item); // Display sample values
        }

        // ============================
        // 6. Conclusion
        // ============================
        Console.WriteLine("Customer data management project completed successfully.");





    }


}
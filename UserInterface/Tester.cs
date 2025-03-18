using Services;
using Exceptions;
using Vehicles;
using IndependentClasses;
using Common;

namespace UserInterface;

public static class Tester
{
    // Constants for test display
    private const int TEST_NAME_WIDTH = 40;
    private const string RUNNING = "RUNNING";
    private const string PASSED = "PASSED";
    private const string FAILED = "FAILED";
    private const int TEST_DELAY_MS = 100; // Delay to simulate test running

    // Keeps track of test results
    private static int passedTests = 0;
    private static int failedTests = 0;
    private static int totalTests = 0;

    public static void RunTests()
    {
        Console.Clear();
        Console.WriteLine("╔══════════════════════════════════════════════════════════╗");
        Console.WriteLine("║                 VEHICLE MANAGEMENT SYSTEM                ║");
        Console.WriteLine("║                      AUTOMATED TESTS                     ║");
        Console.WriteLine("╚══════════════════════════════════════════════════════════╝");
        Console.WriteLine();

        try
        {
            // Prepare test data
            PrepareTestData();
            
            Console.WriteLine("═════════════════════ SORTING TESTS ═════════════════════");
            // Test Section: Sorting
            RunTest("Sort by Price", TestSortByPrice);
            RunTest("Sort by Speed", TestSortBySpeed);
            RunTest("Sort by Vehicle Type", TestSortByType);
            
            Console.WriteLine("\n══════════════════ LINQ QUERY TESTS ══════════════════");
            // Test Section: LINQ Queries
            RunTest("Vehicles faster than 200 km/h", TestVehiclesExceedingSpeed);
            RunTest("Most expensive vehicle", TestMostExpensiveVehicle);
            RunTest("Trucks with load capacity > 2 tons", TestTrucksExceedingLoadCapacity);
            
            Console.WriteLine("\n══════════════ EXCEPTION HANDLING TESTS ══════════════");
            // Test Section: Exception Handling
            RunTest("Invalid Price Exception", TestInvalidPriceException);
            RunTest("Invalid Speed Exception", TestInvalidSpeedException);
            RunTest("Invalid Cargo Capacity Exception", TestInvalidCargoCapacityException);
            
            Console.WriteLine("\n═════════════════ DATA ANALYSIS TESTS ═════════════════");
            // Test Section: Data Analysis
            RunTest("Average price per vehicle type", TestAveragePricePerType);
            RunTest("Count of each vehicle type", TestCountEachType);
            RunTest("Fastest vehicle in each category", TestFastestPerCategory);
            
            // Summary
            Console.WriteLine("\n════════════════════ TEST SUMMARY ════════════════════");
            Console.ForegroundColor = ConsoleColor.White;
            Console.WriteLine($"Total Tests: {totalTests}");
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine($"Passed: {passedTests}");
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine($"Failed: {failedTests}");
            Console.ResetColor();
        }
        catch (Exception ex)
        {
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine($"Fatal error in test suite: {ex.Message}");
            Console.WriteLine(ex.StackTrace);
            Console.ResetColor();
        }
        
        // Restore original vehicles after tests
        RestoreOriginalVehicles();
        
        Console.WriteLine("\nPress any key to continue...");
        Console.ReadKey();
    }

    private static void RunTest(string testName, Func<bool> testMethod)
    {
        totalTests++;
        
        // Show test as running
        Console.Write($"{testName,-TEST_NAME_WIDTH}");
        Console.ForegroundColor = ConsoleColor.Yellow;
        Console.Write($"[{RUNNING}]");
        Console.ResetColor();
        
        // Simulate test running
        Thread.Sleep(TEST_DELAY_MS);
        
        bool result = false;
        try
        {
            // Run the actual test
            result = testMethod();
        }
        catch (Exception ex)
        {
            Console.SetCursorPosition(TEST_NAME_WIDTH, Console.CursorTop);
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine($" [{FAILED}] - {ex.Message}");
            Console.ResetColor();
            failedTests++;
            return;
        }
        
        // Update the test result
        Console.SetCursorPosition(TEST_NAME_WIDTH, Console.CursorTop);
        
        if (result)
        {
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine($" [{PASSED}]");
            passedTests++;
        }
        else
        {
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine($" [{FAILED}]");
            failedTests++;
        }
        Console.ResetColor();
    }

    // Backup of original vehicles to restore after tests
    private static Vehicle[]? originalVehicles;

    private static void PrepareTestData()
    {
        // Backup current vehicles
        originalVehicles = new Vehicle[VehicleManager.Vehicles.Length];
        Array.Copy(VehicleManager.Vehicles, originalVehicles, VehicleManager.Vehicles.Length);
        
        VehicleManager.ClearVehicles();
        VehicleManager.AddVehicle(new Car("Test Car", 25000, 120, "Sedan", 150, "TestModel"));
        VehicleManager.AddVehicle(new Truck("Test Truck", 45000, 90, "Pickup", 2.5));
        VehicleManager.AddVehicle(new Boat("Test Boat", 35000, 50, "Speedboat", 6));
        VehicleManager.AddVehicle(new Airplane("Test Plane", 2000000, 500, "Commercial", 35000));
        VehicleManager.AddVehicle(new Train("Test Train", 1500000, 200, "Passenger", 8));
        VehicleManager.AddVehicle(new CargoAirplane("Cargo Plane", 4000000, 450, "Freight", 30000, 120));
        VehicleManager.AddVehicle(new RaceCar("Race Car", 350000, 220, "Formula", 700, "Speedster", true));
        VehicleManager.AddVehicle(new LuxuryYacht("Yacht", 5000000, 40, "Luxury", 20, true));
    }

    private static void RestoreOriginalVehicles()
    {
        VehicleManager.ClearVehicles();
        foreach (Vehicle vehicle in originalVehicles ?? [])
        {
            VehicleManager.AddVehicle(vehicle);
        }
    }

    // Test implementations
    private static bool TestSortByPrice()
    {
        PrepareTestData();
        var vehiclesCopy = new Vehicle[VehicleManager.Vehicles.Length];
        Array.Copy(VehicleManager.Vehicles, vehiclesCopy, VehicleManager.Vehicles.Length);
        
        // Store the original order to check against
        var originalNames = vehiclesCopy.Select(v => v.Name).ToArray();
        
        // Sort using the method we're testing
        VehicleComparer.SortByPrice(vehiclesCopy);
        
        // Define expected order (sorted by price ascending)
        string[] expectedOrder = { "Test Car", "Test Boat", "Test Truck", "Race Car", "Test Train", 
                                  "Test Plane", "Cargo Plane", "Yacht" };
        
        // Compare actual sorted order with expected order
        for (int i = 0; i < expectedOrder.Length; i++)
        {
            if (vehiclesCopy[i].Name != expectedOrder[i])
            {
                return false;
            }
        }
        
        return true;
    }

    private static bool TestSortBySpeed()
    {
        PrepareTestData();
        var vehiclesCopy = new Vehicle[VehicleManager.Vehicles.Length];
        Array.Copy(VehicleManager.Vehicles, vehiclesCopy, VehicleManager.Vehicles.Length);
        
        // Store the original order to check against
        var originalNames = vehiclesCopy.Select(v => v.Name).ToArray();
        
        // Sort using the method we're testing
        VehicleComparer.SortBySpeed(vehiclesCopy);
        
        // Define expected order (sorted by speed ascending)
        string[] expectedOrder = { "Yacht", "Test Boat", "Test Truck", "Test Car", "Test Train", 
                                  "Race Car", "Cargo Plane", "Test Plane" };
        
        // Compare actual sorted order with expected order
        for (int i = 0; i < expectedOrder.Length; i++)
        {
            if (vehiclesCopy[i].Name != expectedOrder[i])
            {
                return false;
            }
        }
        
        return true;
    }

    private static bool TestSortByType()
    {
        PrepareTestData();
        var vehiclesCopy = new Vehicle[VehicleManager.Vehicles.Length];
        Array.Copy(VehicleManager.Vehicles, vehiclesCopy, VehicleManager.Vehicles.Length);
        
        // Sort using the method we're testing
        VehicleComparer.SortByType(vehiclesCopy);
        
        // Define expected order (sorted by vehicle type alphabetically)
        // This assumes our test data types have the following alphabetical order:
        // Airplane, Boat, Car, CargoAirplane, LuxuryYacht, RaceCar, Train, Truck
        string[] expectedOrder = { "Test Plane", "Test Boat", "Test Car", "Cargo Plane", 
                                  "Yacht", "Race Car", "Test Train", "Test Truck" };
        
        // Compare actual sorted order with expected order
        for (int i = 0; i < expectedOrder.Length; i++)
        {
            if (vehiclesCopy[i].Name != expectedOrder[i])
            {
                return false;
            }
        }
        
        return true;
    }

    private static bool TestVehiclesExceedingSpeed()
    {
        double speedThreshold = 200; // 200 km/h
        
        try
        {
            // Use the VehicleStatistics method
            var exceedingSpeedVehicles = VehicleStatistics.FindVehiclesExceedingSpeed(speedThreshold);
            
            // Verify all returned vehicles are actually above the threshold
            bool allAboveThreshold = exceedingSpeedVehicles.All(v => v.Speed > speedThreshold);
            
            // Verify we found all vehicles above the threshold
            int expectedCount = VehicleManager.Vehicles.Count(v => v.Speed > speedThreshold);
            bool correctCount = exceedingSpeedVehicles.Count() == expectedCount;
            
            return allAboveThreshold && correctCount;
        }
        catch (Exception)
        {
            return false;
        }
    }

    private static bool TestMostExpensiveVehicle()
    {
        if (VehicleManager.Vehicles.Length == 0) 
            return false;
        
        try
        {
            // Use the VehicleStatistics method
            Vehicle? mostExpensive = VehicleStatistics.FindMostEpensiveVehicle();
            if (mostExpensive == null)
                return false;
            
            // Verify it's actually the most expensive
            double highestPrice = VehicleManager.Vehicles.Max(v => v.Price);
            double epsilon = 0.0001;
            return Math.Abs(mostExpensive.Price - highestPrice) < epsilon;
        }
        catch (Exception)
        {
            return false;
        }
    }

    private static bool TestTrucksExceedingLoadCapacity()
    {
        double loadCapacityThreshold = 5000; // 5 thousand kg
        
        try
        {
            // Use the VehicleStatistics method
            var trucksExceedingCapacity = VehicleStatistics.FindTrucksExceedingLoadCapacity(loadCapacityThreshold);
            // Verify all are Trucks and exceed the threshold
            bool allValidTrucks = (from v in trucksExceedingCapacity
                                   where v is Truck truck && truck.LoadCapacity > loadCapacityThreshold
                                   select v).Count() == trucksExceedingCapacity.Count();
                
            // Verify we found all trucks above the threshold
            int expectedCount = (from v in VehicleManager.Vehicles
                                 where v is Truck truck && truck.LoadCapacity > loadCapacityThreshold
                                 select v).Count();
            return allValidTrucks && trucksExceedingCapacity.Count() == expectedCount;
        }
        catch (Exception)
        {
            return false;
        }
    }

    private static bool TestInvalidPriceException()
    {
        try
        {
            // Should throw InvalidPriceException
            var _ = new Car("Invalid Car", -100, 120, "Sedan", 150, "TestModel");
            return false; // If we get here, no exception was thrown
        }
        catch (InvalidPriceException)
        { return true; }
        catch
        { return false; }
    }

    private static bool TestInvalidSpeedException()
    {
        try
        {
            // Should throw InvalidSpeedException
            var _ = new Car("Invalid Car", 25000, -50, "Sedan", 150, "TestModel");
            return false; // If we get here, no exception was thrown
        }
        catch (InvalidSpeedException)
        { return true; }
        catch
        { return false; }
    }

    private static bool TestInvalidCargoCapacityException()
    {
        try
        {
            // Should throw InvalidCargoCapacityException
            var _ = new CargoAirplane("Invalid Plane", 2000000, 500, "Commercial", 35000, -5);
            return false; // If we get here, no exception was thrown
        }
        catch (InvalidCargoCapacityException)
        { return true; }
        catch
        { return false; }
    }
    private static bool TestAveragePricePerType()
    {
        if (VehicleManager.Vehicles.Length == 0)
            return false;
            
        try
        {
            // Clear existing vehicles and add vehicles with known prices
            var backupVehicles = VehicleManager.Vehicles.ToArray();
            
            VehicleManager.ClearVehicles();
            // Add test vehicles with predetermined prices
            VehicleManager.AddVehicle(new Car("Test Car 1", 10000, 120, "Sedan", 150, "Model1"));
            VehicleManager.AddVehicle(new Car("Test Car 2", 20000, 130, "Sedan", 160, "Model2"));
            VehicleManager.AddVehicle(new Truck("Test Truck 1", 50000, 90, "Pickup", 2.5));
            VehicleManager.AddVehicle(new Truck("Test Truck 2", 70000, 85, "Pickup", 3.0));
            
            // Use the VehicleStatistics method
            var averagePrices = VehicleStatistics.FindAveragePricePerType();
            
            // Define expected averages based on our test data
            var expectedAverages = new Dictionary<string, double>
            {
                { "Car", 15000 },     // (10000 + 20000) / 2
                { "Truck", 60000 }    // (50000 + 70000) / 2
            };
            
            // Restore original vehicles
            VehicleManager.ClearVehicles();
            foreach (var vehicle in backupVehicles)
            {
                VehicleManager.AddVehicle(vehicle);
            }
            
            // Check if each type has the correct average
            foreach (var kvp in expectedAverages)
            {
                string type = kvp.Key;
                double expectedAverage = kvp.Value;
                
                if (!averagePrices.TryGetValue(type, out double actualAverage) || 
                    Math.Abs(expectedAverage - actualAverage) > 0.001)
                {
                    return false;
                }
            }
            
            return true;
        }
        catch (Exception)
        {
            return false;
        }
    }

    private static bool TestCountEachType()
    {
        try
        {
            // Backup existing vehicles
            var backupVehicles = VehicleManager.Vehicles.ToArray();
            
            // Clear existing vehicles and add vehicles with predetermined types
            VehicleManager.ClearVehicles();
            VehicleManager.AddVehicle(new Car("Test Car 1", 10000, 120, "Sedan", 150, "Model1"));
            VehicleManager.AddVehicle(new Car("Test Car 2", 20000, 130, "Sedan", 160, "Model2"));
            VehicleManager.AddVehicle(new Truck("Test Truck", 50000, 90, "Pickup", 2.5));
            VehicleManager.AddVehicle(new Boat("Test Boat", 35000, 50, "Speedboat", 6));
            
            // Use the VehicleStatistics method
            var typeCounts = VehicleStatistics.CountEachType();
            
            // Define expected counts based on our test data
            var expectedCounts = new Dictionary<string, int>
            {
                { "Car", 2 },
                { "Truck", 1 },
                { "Boat", 1 }
            };
            
            // Restore original vehicles
            VehicleManager.ClearVehicles();
            foreach (var vehicle in backupVehicles)
            {
                VehicleManager.AddVehicle(vehicle);
            }
            
            // Verify each type has correct count
            foreach (var kvp in expectedCounts)
            {
                if (!typeCounts.TryGetValue(kvp.Key, out int count) || count != kvp.Value)
                {
                    return false;
                }
            }
            
            // Verify no extra types
            return typeCounts.Count == expectedCounts.Count;
        }
        catch (Exception)
        {
            return false;
        }
    }
    private static bool TestFastestPerCategory()
    {
        try
        {
            // Backup existing vehicles
            var backupVehicles = VehicleManager.Vehicles.ToArray();
            
            // Clear existing vehicles and add vehicles with predetermined types and speeds
            VehicleManager.ClearVehicles();
            VehicleManager.AddVehicle(new Car("Fast Car", 30000, 200, "Sedan", 150, "Sedan"));
            VehicleManager.AddVehicle(new Car("Slow Car", 20000, 150, "Sedan", 120, "Sedan"));
            VehicleManager.AddVehicle(new Truck("Fast Truck", 70000, 120, "Pickup", 2.5));
            VehicleManager.AddVehicle(new Truck("Slow Truck", 50000, 90, "Pickup", 3.0));
            VehicleManager.AddVehicle(new Boat("Speed Boat", 45000, 80, "Speedboat", 6));
            VehicleManager.AddVehicle(new Boat("Slow Boat", 35000, 40, "Speedboat", 4));
            VehicleManager.AddVehicle(new Airplane("Fast Plane", 3000000, 900, "Jet", 40000));
            VehicleManager.AddVehicle(new Airplane("Slow Plane", 2000000, 500, "Jet", 25000));
            
            // Use the VehicleStatistics method
            var fastestByCategory = VehicleStatistics.FindFastestPerCategory();
            
            // Define expected fastest vehicles based on our test data
            var expectedFastest = new Dictionary<string, string>
            {
                { "Sedan", "Fast Car" },
                { "Pickup", "Fast Truck" },
                { "Speedboat", "Speed Boat" },
                { "Jet", "Fast Plane" }
            };
            
            // Restore original vehicles
            VehicleManager.ClearVehicles();
            foreach (var vehicle in backupVehicles)
            {
                VehicleManager.AddVehicle(vehicle);
            }
            
            // Verify each category has the correct fastest vehicle
            foreach (var kvp in expectedFastest)
            {
                string category = kvp.Key;
                string expectedName = kvp.Value;
                
                if (!fastestByCategory.TryGetValue(category, out Vehicle? actualFastest) || 
                    actualFastest.Name != expectedName)
                {
                    return false;
                }
            }
            
            // Verify all categories are covered and no extras
            return fastestByCategory.Count == expectedFastest.Count;
        }
        catch (Exception)
        {
            return false;
        }
    }
}

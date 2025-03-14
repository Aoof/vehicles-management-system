# Vehicle Management System

A comprehensive C# application for managing different types of vehicles, including cars, trucks, boats, race cars, and luxury yachts.

## Project Structure

```
.
├── Exceptions            # Custom exceptions for vehicle validation
├── IndependentClasses    # Utility classes for vehicle operations
├── Services              # Service classes for file operations and vehicle management
├── Vehicles              # Vehicle class implementations
├── Program.cs            # Main application entry point
└── README.md             # Project documentation
```

## Components

### Vehicles

The system supports multiple vehicle types:

- **Vehicle**: Abstract base class for all vehicle types
- **Car**: Basic passenger vehicle implementation with horsepower and model
- **Truck**: Vehicle with cargo load capacity
- **Boat**: Water-based vehicle with seating capacity
- **RaceCar**: High-performance vehicle with turbo boost capability
- **LuxuryYacht**: High-end water vehicle with luxury features including helipad
- **Airplane**: Flying vehicle with altitude capabilities
- **CargoAirplane**: Specialized airplane for transporting cargo
- **Train**: Rail-based vehicle with multiple units

### Exceptions

Custom exception classes for data validation:

- **VehicleException**: Base exception class for all vehicle-related exceptions
- **InvalidPriceException**: Thrown when vehicle price is invalid
- **InvalidSpeedException**: Thrown when speed values are invalid
- **InvalidCargoCapacityException**: Thrown when truck cargo capacity is invalid

### Independent Classes

Utility classes for vehicle operations:

- **TaxCalculator**: Calculates applicable taxes for different vehicle types
- **VehicleComparer**: Provides comparison functionality between vehicles
- **VehicleStatistics**: Generates statistical information about vehicle collections

### Services

Service classes for application operations:

- **FileHandler**: Manages reading and writing vehicle data to files
- **VehicleManager**: Core service for managing vehicle objects

## Getting Started

### Prerequisites

- .NET 6.0+ SDK
- Visual Studio 2022 or VS Code with C# extensions

### Running the Application

1. Clone the repository `git clone https://github.com/aoof/vehicle-management-system.git`
2. Open the solution in your preferred IDE
3. Build the solution `dotnet build`
4. Run the Program.cs file `dotnet run`

## Usage


## Features

- Create and manage different types of vehicles
- Calculate taxes and statistics for vehicles
- Compare vehicle properties
- Save and load vehicle data from files

## Future Enhancements


## License

MIT License

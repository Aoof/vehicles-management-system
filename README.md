# Vehicle Management System

A comprehensive C# application for managing different types of vehicles, including cars, trucks, boats, race cars, and luxury yachts.

## Project Structure

```
.
├── Common                # Common utility class for vehicle constants
├── Exceptions            # Custom exceptions for vehicle validation
├── IndependentClasses    # Utility classes for vehicle operations
├── Services              # Service classes for file operations and vehicle management
├── Vehicles              # Vehicle class implementations
├── UserInterface         # Console-based user interface for vehicle management
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

- .NET 9.0+ SDK
- Visual Studio 2022 or VS Code with C# extensions

### Running the Application

1. Clone the repository `git clone https://github.com/aoof/vehicles-management-system.git`
2. Open the solution in your preferred IDE
3. Build the solution `dotnet build`
4. Run the Program.cs file `dotnet run` or to run tests `dotnet run -t`

#### To Run on Linux

1. Install the linux release file from [releases page](https://github.com/aoof/vehicles-management-system/releases/latest)
2. Extract using unzip `unzip vehicles-management-system-linux.zip -d vehicles-management-system`
3. Give execute permissions `chmod +x vehicles-management-system/vehicles-management-system`
4. Run the application `./vehicles-management-system/vehicles-management-system`

#### To Run on MacOS

> Note: MacOS generally has more security restrictions so save yourself the time and clone the repo and build the application yourself

1. Ensure you have the latest version of .NET installed on your machine
2. Install the macos release file from [releases page](https://github.com/aoof/vehicles-management-system/releases/latest)
3. Uncompress or extract using unzip `unzip vehicles-management-system-macos.zip -d vehicles-management-system`
4. Run `dotnet vehicles-management-system/vehicles-management-system.dll` to start the application (Additional security permissions may be required)

## Usage

The Vehicle Management System provides a command-line interface for managing your vehicle collection:

1. **Adding Vehicles**: 
   - Select "Add Vehicle" from the main menu
   - Choose a vehicle type (Car, Truck, Boat, etc.)
   - Enter requested details for the specific vehicle type

2. **Managing Vehicles**:
   - List all vehicles in the system
   - Search for specific vehicles by name or type
   - Update vehicle information
   - Remove vehicles from the system

3. **Data Operations**:
   - Save your vehicle collection to a CSV file
   - Load vehicle data from existing files
   - Export statistics about your vehicle collection

4. **Advanced Features**:
   - Compare different vehicles by various properties
   - Calculate tax liability for each vehicle
   - Generate reports on vehicle value distribution

## Features

- **Comprehensive Vehicle Management**:
  - Create and manage different types of vehicles with specific properties
  - Support for land, water, and air vehicles with specialized attributes
  - Extensible framework for adding new vehicle types

- **Advanced Calculations**:
  - Calculate taxes based on vehicle type, price, and regional settings
  - Generate statistics including average price, speed range, and type distribution
  - Compare vehicles across multiple dimensions (speed, value, capacity)

- **Data Persistence**:
  - Save and load vehicle data from CSV files with comma-separated values
  - Support for custom file locations and multiple save files
  - Error handling for file operations with recovery mechanisms

- **Flexible Architecture**:
  - Object-oriented design with inheritance for vehicle types
  - Service-based architecture for separation of concerns
  - Custom exception handling for robust error management

## Future Enhancements

- **Graphical User Interface**:
  - Desktop application with modern UI
  - Interactive vehicle visualization
  - Drag-and-drop functionality for vehicle management

- **Extended Features**:
  - Vehicle maintenance scheduling and tracking
  - Fuel efficiency calculations and comparisons
  - Integration with external vehicle databases

- **Advanced Analytics**:
  - Predictive maintenance recommendations
  - Value depreciation forecasting
  - Cost of ownership analysis

- **Mobile Support**:
  - Cross-platform mobile application
  - Synchronization between devices
  - Barcode/QR code scanning for quick vehicle lookup

## License

This project is licensed under the MIT License - see the [LICENSE](LICENSE) file for details.


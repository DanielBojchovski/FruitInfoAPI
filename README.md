# Fruit Information Application

## Overview
This application interacts with the Fruityvice API to fetch and manage information about various fruits from name. It also allows adding, removing, and updating metadata for fruits.

## Prerequisites
- .NET SDK 8.0.302
- Visual Studio or any C# IDE
- Internet connection for API access

## How to Run
1. Clone the repository.
2. Navigate to the project directory.
3. Ensure the following NuGet packages are installed:
    - `Newtonsoft.Json` (version 13.0.3): Used for JSON serialization and deserialization.
    - `Swashbuckle.AspNetCore` (version 6.4.0): Used to integrate Swagger for API documentation and testing.
4. Run the project to open the Swagger UI.
5. Test the endpoints.

## Endpoints
- `GET /api/Fruityvice/GetFruitByName`: Get fruit information by name.
    - **Query Parameter**: `name` (string, required) - The name of the fruit to retrieve.
- `POST /api/Fruityvice/AddMetadata`: Add metadata to a fruit.
    - **Body**: `SaveMetadataRequest` (JSON object, required)
        - `name` (string, required) - The name of the fruit.
        - `metadata` (string, required) - The metadata to add.
- `DELETE /api/Fruityvice/RemoveMetadata`: Remove metadata from a fruit.
    - **Query Parameter**: `name` (string, required) - The name of the fruit to remove metadata from.
- `PUT /api/Fruityvice/UpdateMetadata`: Update metadata of a fruit.
    - **Body**: `SaveMetadataRequest` (JSON object, required)
        - `name` (string, required) - The name of the fruit.
        - `metadata` (string, required) - The new metadata.

## Future Enhancements
- Implement database storage for fruit metadata.

## Authors
- Daniel

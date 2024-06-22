# Fruit Information API Documentation

## Overview
This API interacts with the Fruityvice API to fetch and manage information about various fruits by name. It allows adding, removing, and updating metadata for fruits.

## Project Structure

### Controllers
#### FruityviceController
Handles API requests related to fruit information and metadata management.

- **GetFruitByName**: Handles GET requests to fetch fruit information by name.
- **AddMetadata**: Handles POST requests to add metadata to a fruit.
- **RemoveMetadata**: Handles DELETE requests to remove metadata from a fruit.
- **UpdateMetadata**: Handles PUT requests to update metadata of a fruit.

### Services
#### FruityviceService
Implements the business logic for fetching fruit data and managing metadata. Utilizes caching to improve performance.

- **GetFruitByName**: Fetches fruit information by name. Caches the result for performance.
- **AddMetadataAsync**: Adds metadata to a fruit and invalidates the cache.
- **RemoveMetadataAsync**: Removes metadata from a fruit and invalidates the cache.
- **UpdateMetadataAsync**: Updates metadata of a fruit and invalidates the cache.

### Interfaces
#### IFruityviceService
Defines the contract for the FruityviceService.

- **GetFruitByName**: Fetches fruit information by name.
- **AddMetadataAsync**: Adds metadata to a fruit.
- **RemoveMetadataAsync**: Removes metadata from a fruit.
- **UpdateMetadataAsync**: Updates metadata of a fruit.

### Models
Defines the data structures used in the application.

#### Fruit
Represents a fruit and its associated metadata.

- **Id**: The unique identifier of the fruit.
- **Name**: The name of the fruit.
- **Family**: The family of the fruit.
- **Genus**: The genus of the fruit.
- **Order**: The order of the fruit.
- **Nutritions**: The nutritional information of the fruit.
- **Metadata**: The metadata associated with the fruit.

#### Nutrition
Represents nutritional information of a fruit.

- **Carbohydrates**: The amount of carbohydrates.
- **Protein**: The amount of protein.
- **Fat**: The amount of fat.
- **Calories**: The number of calories.
- **Sugar**: The amount of sugar.

### Requests
Defines the request models used for API operations.

#### GetFruitByNameRequest
Represents a request to fetch fruit information by name.

- **Name**: The name of the fruit.

#### SaveMetadataRequest
Represents a request to save metadata for a fruit.

- **Name**: The name of the fruit.
- **Metadata**: The metadata to be saved.

#### DeleteMetadataRequest
Represents a request to delete metadata for a fruit.

- **Name**: The name of the fruit.

### Responses
Defines the response models used for API operations.

#### OperationStatusResponse
Represents the status of an operation.

- **IsSuccessful**: Indicates if the operation was successful.
- **Message**: Provides additional information about the operation.

### Program Setup
#### Program.cs
Configures and runs the application.

- Adds services to the container.
- Configures Swagger for API documentation.
- Sets up the HTTP request pipeline.
- Runs the application.

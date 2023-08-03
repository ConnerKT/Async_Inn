# Async Inn Management System

## Introduction

Welcome to the Async Inn Management System! This web application is designed to manage hotels, rooms, and amenities for a hotel chain called Async Inn. With this system, you can easily create, read, update, and delete data for hotels, rooms, and amenities through an API.

## ERD Diagram

Below is the Entity Relationship Diagram (ERD) for the Async Inn Management System:

![Async Inn ERD](link-to-your-erd-image.png)

## What each table represents

| Column Name | Data Type | Description                       |
|-------------|----------|-----------------------------------|
| id          | integer  | Unique identifier for each hotel location entry. |
| city        | string   | The city where the hotel is located. |
| state       | string   | The state where the hotel is located. |
| address     | string   | The address of the hotel.          |
| phone       | string   | The contact phone number for the hotel. |

## Table Hotel_Rooms

| Column Name | Data Type | Description                       |
|-------------|----------|-----------------------------------|
| hotel_id    | integer  | Foreign key referencing the id column of the Hotel_Location table, indicating which hotel the rooms belong to. |
| rooms_id    | integer  | Foreign key referencing the id column of the Rooms table, indicating which room is available in the hotel. |
| id          | integer  | Unique identifier for each hotel-room relationship entry. |
| price       | decimal  | The price of the room in the hotel. |

## Table Rooms

| Column Name | Data Type | Description                       |
|-------------|----------|-----------------------------------|
| id          | integer  | Unique identifier for each room entry. |
| name        | string   | The name or number assigned to the room (e.g., "Suite 101"). |
| Layout      | string   | The layout or configuration of the room (e.g., "Single", "Double", "Suite", etc.). |

## Table Room_Amen
| Column Name | Data Type | Description                       |
|-------------|----------|-----------------------------------|
| id          | integer  | Unique identifier for each room-amenity relationship entry. |
| Rooms_id    | integer  | Foreign key referencing the id column of the Rooms table, indicating which room has the specified amenity. |
| Amen_id     | integer  | Foreign key referencing the id column of the Amen table, indicating which amenity is available in the room. |

## Table Amen

| Column Name | Data Type | Description                       |
|-------------|----------|-----------------------------------|
| id          | integer  | Unique identifier for each amenity entry. |
| nameofamen  | string   | The name or description of the amenity (e.g., "Wi-Fi", "TV", "Mini-Bar", etc.). |


## Overview of Relationships

- A **Hotel** can have multiple **Rooms**, but a **Room** belongs to only one **Hotel**.
- A **Room** can have multiple **Amenities**, and an **Amenity** can be associated with multiple **Rooms**.

## Getting Started
To run the Async Inn Management System on your local machine, follow these steps:

1. Clone the repository to your local machine.
2. Ensure you have the .NET Core SDK installed.
3. Open the solution in Visual Studio or your preferred code editor.
4. Configure the connection string in the `appsettings.json` file to point to your local database.
5. Run the following commands in the Package Manager Console to apply migrations and seed data:
    ```
    Update-Database
    ```
6. Build and run the application.

## API Endpoints

### Hotels
- `GET /api/hotels` - Get a list of all hotels.
- `GET /api/hotels/{id}` - Get a specific hotel by its ID.
- `POST /api/hotels` - Create a new hotel.
- `PUT /api/hotels/{id}` - Update an existing hotel by its ID.
- `DELETE /api/hotels/{id}` - Delete a hotel by its ID.

### Rooms
- `GET /api/rooms` - Get a list of all rooms.
- `GET /api/rooms/{id}` - Get a specific room by its ID.
- `POST /api/rooms` - Create a new room.
- `PUT /api/rooms/{id}` - Update an existing room by its ID.
- `DELETE /api/rooms/{id}` - Delete a room by its ID.

### Amenities
- `GET /api/amenities` - Get a list of all amenities.
- `GET /api/amenities/{id}` - Get a specific amenity by its ID.
- `POST /api/amenities` - Create a new amenity.
- `PUT /api/amenities/{id}` - Update an existing amenity by its ID.
- `DELETE /api/amenities/{id}` - Delete an amenity by its ID.

## Usage
You can interact with the API using tools like Postman or any HTTP client. The API supports standard CRUD operations for hotels, rooms, and amenities.




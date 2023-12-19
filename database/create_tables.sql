-- Admin Table
CREATE TABLE Admin (
    admin_id INT PRIMARY KEY NOT NULL,
    username VARCHAR(255) NOT NULL,
    password VARCHAR(255) NOT NULL,
    full_name VARCHAR(255) NOT NULL
);

-- Bus Table
CREATE TABLE Bus (
    bus_id INT PRIMARY KEY NOT NULL,
    captain_name VARCHAR(255) NOT NULL,
    number_of_seats INT NOT NULL,
    admin_id INT NOT NULL,
    FOREIGN KEY (admin_id) REFERENCES Admin(admin_id)
);

-- Passenger Table
CREATE TABLE Passenger (
    passenger_id INT PRIMARY KEY NOT NULL,
    name VARCHAR(255) NOT NULL,
    username VARCHAR(255) NOT NULL,
    email VARCHAR(255) NOT NULL,
    phone_number INT NOT NULL,
    gender VARCHAR(255) NOT NULL,
    password VARCHAR(255) NOT NULL
);

-- Trip Table
CREATE TABLE Trip (
    trip_id INT PRIMARY KEY NOT NULL,
    destination VARCHAR(255) NOT NULL,
    start_date DATE NOT NULL,
    end_date DATE NOT NULL,
    passenger_id INT NOT NULL,
    bus_id INT NOT NULL,
    FOREIGN KEY (passenger_id) REFERENCES Passenger(passenger_id),
    FOREIGN KEY (bus_id) REFERENCES Bus(bus_id)
);

-- Booking Table
CREATE TABLE Booking (
    booking_id INT PRIMARY KEY NOT NULL,
    trip_id INT NOT NULL,
    passenger_id INT NOT NULL,
    FOREIGN KEY (trip_id) REFERENCES Trip(trip_id),
    FOREIGN KEY (passenger_id) REFERENCES Passenger(passenger_id)
);

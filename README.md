# Bus Trips Reserving System (BTRS)

![Homepage Preview](/docs/preview.png)

## Overview

BTRS is a university project developed for the ASP\.NET course at Applied Science Private University. It is a web application designed to facilitate seamless booking for passengers and secure administration for ABC Bus Travels.

## Key Features

- **Passenger Booking System:** Allows passengers to create accounts, book bus trips, and view their bookings.
- **Secure Administration:** Provides administrators with the ability to manage bus trip announcements efficiently.
- **Database Integration:** Utilizes Entity Framework Core to connect to the SQL Server database for data storage.
- **Security Measures:** Implements password requirements and prevents duplicate registrations with the same email.

## Technologies Used

- ASP\.NET Core MVC
- Microsoft SQL Server Management Studio
- Microsoft Visual Studio Studio
- Entity Framework Core
- HTML Helpers with Bootstrap for styling

## Project Structure

- [/BTRS](/BTRS): ASP\.NET Core MVC Project
- [/docs](/docs): Project documentation.

## Getting Started

To set up and run this project locally, follow these steps:

1. Clone the repository to your local machine.
2. Open the project Visual Studio.
3. Configure the database connection by editing the `appsettings.json` file and adding your connection string.
4. In SQL Server Management Studio, create a new database named `BTRS`.
5. In your Visual Studio, open the NuGet Package Manager Console and run the following command to apply the database migrations:

```sql
update-database
```

6. Build and run the application to start using it.

- With these steps, you'll have the project set up and running locally on your machine.

## Task Management

Project tasks are tracked and managed using [Trello](https://trello.com/b/My26qPis).

## Contributing

Feel free to contribute to the project by submitting issues or pull requests.

## License

This project is licensed under the [MIT License](LICENSE).

---

**Note:** After cloning the repository, please refer to the detailed project documentation in the [/docs](/docs) folder.

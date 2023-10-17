# Taskify API

Welcome to Taskify API, a .NET 7 based project to manage tasks effectively. This repository is named "Todo-App".

## Features

- **Create Tasks**: Add new tasks to your list.
- **Update Tasks**: Make changes to existing tasks.
- **Retrieve Tasks**: 
  - Get a single task detail.
  - View all tasks in the list.
- **Delete Tasks**: Remove tasks that are no longer needed.

## Project Structure

The project follows a clean architecture, promoting the separation of concerns principle:

- **Controller Folder**: Houses all the controllers responsible for handling the incoming requests and sending responses.
  
- **Service Folder**: Contains services which hold the business logic for our operations.
  
- **Repository Folder**: This is where our data access logic resides.
  
- **Dto's Folder**: Used for data transfer objects, ensuring data integrity when data moves between processes.
  
- **Response Message Dto**: Structured response message to give detailed results to the end-users.

## Getting Started

1. Clone this repository
2. Navigate to the project directory
3. Install the required packages
4. Run the project


For more detailed setup and configuration, please refer to the official [.NET 7 documentation](https://github.com/dotnet/core/blob/main/release-notes/7.0/README.md).

## Contributing

If you'd like to contribute, please fork the repository and make changes as you'd like. Pull requests are warmly welcome.

## License

[MIT](https://choosealicense.com/licenses/mit/)

## Support

If you encounter any issues, please open an issue in this repository.





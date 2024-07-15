This project is a web API developed using .NET Core 8.0, focused on implementing basic API operations and creating an Author controller to manage authors of books.

## Features Implemented:

    Author Controller:
        Add Author
        Update Author Information
        Delete Author
        List All Authors
        Get Specific Author Information

    Author Information:
        Name
        Surname
        Date of Birth

    Entity Relationships:
        Establish relationships between Book, Author, and Genre entities.
        Assume each book has only one author.
        Ensure that authors with published books cannot be deleted directly. First, delete the associated books, then delete the author.

    Model and DTOs:
        Add models and DTOs for Author. Controller methods should not directly use entities as input or output.

    AutoMapper:
        Configure AutoMapper to map between Author entities and DTOs.

    Fluent Validation:
        Implement validation classes using Fluent Validation for Author services.
        Define validation rules as appropriate.

    Error Handling:
        Ensure meaningful error messages are thrown from services when exceptions occur.

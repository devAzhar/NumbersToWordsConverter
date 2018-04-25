# NumbersToWordsConverter
Take-away Tech Test for NumbersToWordsConverter

Solution contains following projects
- NumbersToWordsConverter.Core
- NumbersToWordsConverter.Web
- NumbersToWordsConverter.Tests

# NumbersToWordsConverter.Core
This project contains the core business logic for this application. The main logic to convert a currency into words is in this project.
I have also broken down the functionality and added more services so that the each part of functionality remain separate.

This core project contains following contracts and their default implementation:
 - ISplitNumberParts
 - INumberToWordsConverter
 - ICurrencyToWordsConverter

Following Model entities are used
 - ConvertResponse
 - SplitResponse

## SplitNumberParts
This service class will split a double input and separate the whole and the fraction parts. This will return SplitResponse model.


# NumbersToWordsConverter.Web

# NumbersToWordsConverter.Tests

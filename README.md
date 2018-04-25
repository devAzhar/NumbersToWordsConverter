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

### SplitResponse Split(double number)
Input: double number=20.50
Output: SplitResponse
 NumberPart=20
 FractionPart=50

## NumberToWordsConverter
This service class has two methods to convert an integer into word and also to convert both parts of a double parameter into word.

This service uses the SplitNumberParts service to split parts of double input data.

### string Convert(int number)
This method will convert the integer parameter into word string.

Input: int number=35
Output: string = thirty-five
 
### ConvertResponse Convert(double number)
This method will convert the integer parameter into word string for both parts of double input (including the whole part and the fraction part).

Input: int number=35.50
Output: ConvertResponse
 NumberPartWord = thirty-five
 FractionPartWord = fifty

## CurrencyToWordsConverter


# NumbersToWordsConverter.Web

# NumbersToWordsConverter.Tests

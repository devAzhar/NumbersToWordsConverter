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
This service class has one methods to convert a double input into word. This service uses NumberToWordsConverter service in order to convert the parts of the number into words and then format the output as currency. 

This service uses the NumberToWordsConverter service to convert part of number into words.

### string Convert(double amount, string currencyName = "", string currencyCentsName = "")
This method takes the currency amount as input, you can pass optional parameters for currencyName and currencyCentsName if the currency is not a dollar currency.

_These additional parameters were not part of the requirement but are added for additional flexibility to work with rest of the currencies_

Input: int number=35.50
Output: string THIRTY-FIVE DOLLARS AND FIFTY CENTS

This method will take care of all the combinations of dollars and cents.

# NumbersToWordsConverter.Web
This project contains the Web API to host the currency to words converter. The demo page to test the service is also part of this project.

## Web API
### NumbersToWordsConverter.Web.Controllers.CurrencyToWordsConverterController.Convert

/CurrencyToWordsConverter/Convert

Input:
CurrencyToWordsInputModel:
 - double Amount
 - string CurrencyName
 - string CurrencyCentsName
 
 Output:
 JsonResult for ServiceResponse
  - Result - Words for currency amount
  - ErrorMessage - Error string will be returned if there is any error during conversion.

_More web api actions can be created to expose other services_

## Demo
I have created the demo on root of the URL. 

Demo is created using MVC razor view and KnockoutJS.

Web UI is built using the standard ASP.Net MVC site layout that uses Bootstrap and jQuery by default.

# NumbersToWordsConverter.Tests
This project contains Unit Test for the Core project. Unit test coverage is 100% for the Core project.

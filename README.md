## About NumbersToWordsConverter:

This project is developed against the requirements mentioned in the document "Take-away Tech Test.pdf"

The demo page accessible on the root of the web project will perform the following action:
1. Capture a person's name and a number
2. Convert this number into words
3. Render this name and number (as words) as a web page

## Opening the solution:
Once you download the files, you can open the solution in Visual Studio 2015 and above.

Visual Studio solution file path: **/src/NumbersToWordsConverter.sln**

You can compile the application, it should install the packages from NuGet during compilation. Once compiled, you can either debug (F5) or execute the web project directly (Ctrl+F5).

## Testing the output:
The default view of the demo page will be like following:
![Demo View](https://github.com/devAzhar/NumbersToWordsConverter/blob/master/documentation/web-view.png?raw=true)

If you provide the sample input, you will get the output as following:
![Demo View](https://github.com/devAzhar/NumbersToWordsConverter/blob/master/documentation/web-view-sample-input.png?raw=true)

### Validation and Error Handling:
Fields are validated on the client side for data.

![Error View](https://github.com/devAzhar/NumbersToWordsConverter/blob/master/documentation/web-view-input-validation-1.png?raw=true)
![Error View](https://github.com/devAzhar/NumbersToWordsConverter/blob/master/documentation/web-view-input-validation-2.png?raw=true)

In some cases (e.g. for -ve amount), the error will be returned from the web api call.

![Error View](https://github.com/devAzhar/NumbersToWordsConverter/blob/master/documentation/web-view-input-server-validation.png?raw=true)

## Documentation:
You can review the overall documentation about project details on the following url:

https://github.com/devAzhar/NumbersToWordsConverter/blob/master/documentation/documentation.md

## Code Coverage Results:
### OpenCover Code Coverage:
![Code Coverage Result OpenCover](https://github.com/devAzhar/NumbersToWordsConverter/blob/master/code-analysis/code_coverage_open_cover.png?raw=true)

### MS Test Code Coverage:
![Code Coverage Result MS Test](https://github.com/devAzhar/NumbersToWordsConverter/blob/master/code-analysis/code_coverage_ms_updated.png?raw=true)

## Code Map:
![Code Map Overview](https://github.com/devAzhar/NumbersToWordsConverter/blob/master/code-analysis/code_map.png?raw=true)

## Code Metrics:
![Code Metrics](https://github.com/devAzhar/NumbersToWordsConverter/blob/master/code-analysis/code_metrics.png?raw=true)

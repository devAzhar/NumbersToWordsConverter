(() => {
    //Global function to trim spaces from a string object
    if (!String.prototype.trim) {
        String.prototype.trim = function () {
            return this.replace(/^[\s\uFEFF\xA0]+|[\s\uFEFF\xA0]+$/g, '');
        };
    }

    //Wrapper to call the external service to convert a number into words
    let CurrencyToWordsConverterService = function (url) {
        let self = this;
        self.url = url || "/CurrencyToWordsConverter/Convert";

        self.convert = (number) => {
            return new Promise((resolve, reject) => {
                try {
                    let word = number;
                    let data = { amount: number };

                    $.ajax({
                        url: self.url
                        , data: JSON.stringify(data)
                        , contentType: "application/json; charset=utf-8"
                        , dataType: "json"
                        , method: "POST"
                        , success: (json) => {
                            let error = json.ErrorMessage;
                            let result = json.Result;

                            //Check if there is any error in the response
                            if (error) {
                                reject(error); //Reject the promise
                            }
                            //No error, proceed to resolve the promise
                            else {
                                resolve(result);
                            }
                        }
                        , error: (request, status, error) => {
                            //The call fails itself, reject promise
                            reject(error);
                        }
                    });
                }
                catch (exp) {
                    //un-handled exception, reject promise
                    reject(exp);
                }
            });
        };
    }

    //Main view model for the demo page to show numbers to words conversion. Converter service is passed to reduce dependency
    //It can help when we write unit tests for the java-script
    let CurrencyToWordsConverterViewModel = function(currencyToWordsConverterService) {
        let self = this;

        self.currencyToWordsConverterService = currencyToWordsConverterService;
        self.name = ko.observable("");
        self.number = ko.observable("");
        self.words = ko.observable("");
        self.errorString = ko.observable("")

        self.validate = () => {
            let $error = "";
            let $name = self.name().trim();
            let $number = self.number().trim();

            if (!$name) {
                $error = "Please enter name.";
            }
            else if (!$number || isNaN($number)) {
                $error = "Please enter a valid numerical value (E.g. 12.50).";
            }

            self.errorString($error);

            let $valid = ($error === "");

            if ($valid) {
                self.name($name);
                self.number($number);
            }

            return $valid;
        }

        self.displayString = ko.pureComputed(() => {
            let display = "";

            if (!self.errorString() && self.words()) {
                display = `${self.name()}<br/>"${self.words()}"`;
            }

            return display;
        }, self);

        self.calculate = (event) => {
            if (self.validate()) {
                self.currencyToWordsConverterService.convert(self.number())
                    .then((word) => {
                        self.words(word);
                    })
                    .catch((error) => {
                        self.errorString(error);
                    });
            }
        }
    };

    //Execute this when Dom is ready
    $(() => {
        let $currencyToWordsConverterContainer = $("#currencyToWordsConverterContainer").get(0);

        if ($currencyToWordsConverterContainer) {
            let viewModel = new CurrencyToWordsConverterViewModel(new CurrencyToWordsConverterService());
            ko.applyBindings(viewModel, $currencyToWordsConverterContainer);
        }
    })
})();
MANGOPAY .NET SDK [![Build Status](https://travis-ci.org/Mangopay/mangopay2-net-sdk.svg?branch=master)](https://travis-ci.org/Mangopay/mangopay2-net-sdk)
=================================================
MangopaySDK is a Microsoft .NET client library to work with
[Mangopay REST API](http://docs.mangopay.com/api-references/).


Installation and package dependencies
-------------------------------------------------
This SDK is currently targeting **.NET Standard 2.1** and **.NET 6.0.** It has **4** dependencies on external packages. 
These dependencies are:
- Common.Logging library (version 3.4.1)
- Newtonsoft.Json (version 13.0.1)
- RestSharp (version 107.3.0)
- NETStandard.Library (version 2.0.3)

The installation is as easy as downloading the SDK package and storing it under any location that will be available for referencing by your project (see examples below). You can also install from the .Net Package Manager Console:

	Install-Package mangopay2-sdk

License
-------------------------------------------------
MangopaySDK is distributed under MIT license, see LICENSE file.


Unit Tests
-------------------------------------------------
Tests are placed in MangoPay.SDK.Tests project in solution.


Contact
-------------------------------------------------
Report bugs or suggest features using [issue tracker at GitHub](https://github.com/MangoPay/mangopay2-net-sdk/issues).


Account creation
-------------------------------------------------
You can get yourself a free sandbox account or sign up for a production account by [registering on the Mangopay site](https://www.mangopay.com/start/) (note that validation of your production account involves several steps, so think about doing it in advance of when you actually want to go live).


Configuration
-------------------------------------------------
Using the credential info from the signup process above, you should then set `api.Config.ClientId` to your MANGOPAY Client ID and `api.Config.ClientPassword` to your apiKey.

`api.Config.BaseUrl` is set to sandbox environment by default. To enable production environment, set it to `https://api.mangopay.com`:

    api.Config.BaseUrl = "https://api.mangopay.com";

The `ClientId`, `ClientPassword` and `BaseUrl` properties are mandatory. Optionally, you can set the logger instance, setting `LoggerFactoryAdapter` property to an instance of `ILoggerFactoryAdapter`.
By default, there is `NoOpLoggerFactoryAdapter` used, what means there won't be any logs emitted anywhere. For more details please refer to the [Common.Logging library documentation](http://netcommon.sourceforge.net/docs/2.1.0/reference/html/ch01.html#logging-adapters).

Below is the example showing how to configure SDK:

    MangoPayApi api = new MangoPayApi();

    // configure client credentails..
    api.Config.ClientId = "your-client-id";
    api.Config.ClientPassword = "your-client-api-key";
    api.Config.BaseUrl = "https://api.sandbox.mangopay.com";
	
	// ..and optionally, set the logger you want (here, the console logger is used)
	api.Config.LoggerFactoryAdapter = new Common.Logging.Simple.ConsoleOutLoggerFactoryAdapter();

    // now you're ready to call API methods, i.e.:
    var users = api.Users.GetAll();


Sample usage (get, update and save an entity)
-------------------------------------------------

    MangoPayApi api = new MangoPayApi();

    // configuration
    api.Config.ClientId = "your-client-id";
    api.Config.ClientPassword = "your-client-api-key";

    // get some Natural user
    var user = api.Users.GetNatural(someUserId);

	// create update entity
	var userPut = new UserNaturalPutDTO
    {
        Tag = user.Tag,
        Email = user.Email,
        FirstName = user.FirstName,
        LastName = user.LastName + " - CHANGED",
        Address = user.Address,
        Birthday = user.Birthday,
        Nationality = user.Nationality,
        CountryOfResidence = user.CountryOfResidence,
        Occupation = user.Occupation,
        IncomeRange = user.IncomeRange
    };
	
	// save updated user
	var userSaved = api.Users.UpdateNatural(userPut, user.Id);

	// get his bank accounts
    var accounts = api.Users.GetBankAccounts(user.Id, new Pagination(2, 10));
	
    // get all users (with pagination)
    var users = api.Users.GetAll(new Pagination(1, 8));

	

Mangopay SDK
=================================================
MangopaySDK is a Microsoft .NET client library to work with
[Mangopay REST API](http://docs.mangopay.com/api-references/).


Installation and package dependencies
-------------------------------------------------
SDK has been written in C#, for .NET Framework 4.5 and has 3 dependencies on external packages. These dependencies are:
- Common.Logging library (version 3.1.0)
- Json.NET (version 6.0.3)
- RestSharp (version 104.4.0)

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


Client creation example (you need to use this once only)
-------------------------------------------------

	using MangoPay.SDK;
	using MangoPay.SDK.Entities.GET;
	(...)
	
    MangoPayApi api = new MangoPayApi();
	
    ClientDTO client = api.Clients.Create("your-client-id", "your-client-name", "your-client-email@sample.org");

    // you'll receive your passphrase here, note it down and keep in secret
    string passphrase = client.Passphrase;


Configuration
-------------------------------------------------
See the example above and call `api.Clients.Create(...)` to get your passphrase. 
Then set `api.Config.ClientId` to your Mangopay Client ID and `api.Config.ClientPassword` to your passphrase.

`api.Config.BaseUrl` is set to sandbox environment by default. To enable production environment, set it to `https://api.mangopay.com`:

    api.Config.BaseUrl = "https://api.mangopay.com";

The `ClientId`, `ClientPassword` and `BaseUrl` properties are mandatory. Optionally, you can set the logger instance, setting `LoggerFactoryAdapter` property to an instance of `ILoggerFactoryAdapter`.
By default, there is `NoOpLoggerFactoryAdapter` used, what means there won't be any logs emitted anywhere. For more details please refer to the [Common.Logging library documentation](http://netcommon.sourceforge.net/docs/2.1.0/reference/html/ch01.html#logging-adapters).

Below is the example showing how to configure SDK:

    MangoPayApi api = new MangoPayApi();

    // configure client credentails..
    api.Config.ClientId = "your-client-id";
    api.Config.ClientPassword = "your-client-passphrase";
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
    api.Config.ClientPassword = "your-client-passphrase";

    // get some Natural user
    UserNaturalDTO user = api.Users.GetNatural(someUserId);

	// create update entity
	UserNaturalPutDTO userPut = new UserNaturalPutDTO
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
	UserNaturalDTO userSaved = api.Users.UpdateNatural(userPut, user.Id);

	// get his bank accounts
    Pagination pagination = new Pagination(2, 10); // get 2nd page, 10 items per page
    ListPaginated<BankAccountDTO> accounts = api.Users.GetBankAccounts(user.Id, pagination);
	
    // get all users (with pagination)
    Pagination pagination = new Pagination(1, 8); // get 1st page, 8 items per page
    ListPaginated<UserDTO> users = api.Users.GetAll(pagination);

	

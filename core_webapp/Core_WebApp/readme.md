ASP.NET Core Programming
1. Data Model Creation using EntityFramework Core (EF Core)
	- Understand EF Core
		- The Object Relational Mapping (ORM) for performing
		  Data Access using CLR Object (classes) mapped with
		  Data Tables (Relational Table)
		- Allows to create clr classes and genarete database
		and tables from it. This approach is knows as 'Code-First'
		approach. Use this approach when the app is developed 
		from scracth.
		- Allows to generate classes from the already created 
		Database and its tables. The Database First approach. 
			- If you are replacing already avaiable software by 
			ASP.NET Core app by having same database w/o any changes 
			in database.
		- Classes with relations across them
			- One-to-one
			- One-to-many
			- Many-to-Many

2. Creating the Data Access Layer using EF Core
	- Using EF Core for Data Access 
	- Use the EF Core Packages
		- Microsoft.EntityFrameworkCore
		- Microsoft.EntityFrameworkCore.SqlServer
		- Microsoft.EntityFrameworkCore.Relational
		- Microsoft.EntityFrameworkCore.Tools
		- Microsoft.EntityFrameworkCore.Design
	- EF Core Object Model
		- DbContext
			- Class, used to connect to Database Server using 
				connection string
			- Class used to map with Tables using DbSet<T>
			- Class used to perfrom Db Transactions using
				SaveChanges() and SaveChangesAsync() methods
		- DbSet<T>
			- Class, used to map the CLR Class of Name 'T'
				with Database table of name T
			-  Methods to perform CRUD Operations
				- Add() / AddAsync() / AddRange() / AddRangeAsync()
				- Find() / FindAsync(), Find record based on P.K.
				- Remove() , delete record based on found object
			- DbSet is a cursor aka RecordSet, that contains all
				rows from table
		- Define Database connection string in 'appsettings.json' file
		- Run the Migrations to generate Migration Files to create database and table
- dotnet ef migrations add <NAME-OF-MIGRATION> -c <DbContext Class Path using namespace>
- dotnet ef migrations add FirstMigration -c Core_WebApp.Models.AppJune2020DbContext
	- The above command will generate the Migrations file where the code definitions
		for creating tables with relations is written
- To generate the database and tables run the following command
- dotnet ef database update -c <DbContext Class Path using namespace>
- dotnet ef database update -c Core_WebApp.Models.AppJune2020DbContext

3. Dependency Registration of the Data Access layer
	- Understand ASP.NET Core 
		- Program Class
			- ASP.NET Core uses 'Kestral' as a default hosting 
				engine	
			- IHostBuilder
				- Contract that is used to configure the Hosting
					environment settings (?) for the ASP.NET Core app
					- Application Cofiguration Settings using 'IConfiguration' interface
						- Reads 'appsettings.json'
							- Read ConnectionStrings, Loggining, etc.
					- Manage Sessions
					- Manages Security
					- Manages Dependency Container
					- Manages Request Processing for the Application
		- Startup class
			- Inject the IConfiguration as constructor injectation 
				to read appsettings.json
			- ConfigureServices() method
				- This is used to manage Dependencies in a cotainer with its lifecycle
			- Configure() method
				- Responsible for the request processing
4. Create Repository Business Layer
	- Repository Pattern
	- Dependency Injection
5. Create Controllers
	- Action Methods and the IActionResult Contract
		- ViewResult, PartialViewResult
		- OkResult, OkObjectResult, JsonResult
		- NotFoundResult, BadRequestresult, NoContentResult, ConflictResult
	- Controller Base Type
6. Create View
	- The cshtml razor views
		- Strongly Typed Views
			- View with the Model class
			- Base class for View is RazorPage<TModel>
				- TModel is the Type of model data passed to View
				- The class has 'Model' property that contaisn data to be 
				displayed on view or to be accepted from View using HttpPost request
				- Model property is of the type TModel
			- View Template Types
				- List, accpts TModel as IEnumerable of the model class
				- Create, accepts TModel as empty model class
				- Edit, accepts TModel as the model class containing model to be updated
				- Delete, accepts TModel as the model class containing model to be deleted
		- Empty View
			- No Model class
	- Tag Helpers
		- Each Razor View in ASP.NET Core MVC uses Tag Helpers
		- They are server-side executing custom attributes for HTML Elements
		- asp-action, redirect to action method
		- asp-controller, redirect to the controller
		- asp-validation-summary, show validations
		- asp-for, for binding Model class property to the HTML input test elements
		- asp-items, iterate over the collections from the model class
7. Create Filters
	- Request Procesing
	- filter Creation and Filter Registration
8. Secure the Application
	- User and Role Based Security
	- Policy Based Security
9. Create WEB API
	- Http Method and Contracts
10. Create Middleware
	- CReating Middlewares in Request Processing
11. Secure WEB API
	- JWT Authentication

===================================================================
Microsoft.AspNetCore.App
- ASP.NET Core Runtime, that will manage the ASP.NET Core Application
Histing and execution on the Host Machine 






Assignment 1: Create ProductService, ProductController witrh action methods and 
perform CRUD Operations on Product controller.
Assignment 2: Create a controller that will have an Index method which will show 
Table of Categories and Products. When we select a category from category table
the product table should show only those products from the selected category.




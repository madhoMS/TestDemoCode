# User API Dev Guide

## Building
Here are some required things to build and run the project.
1. Visual studio 2017,2019 or 2022 IDE is required.
2. Open the TestProject.WebAPI.sln file in IDE.
3. After opening the project restore all the nuget packages.
4. Clean and rebuild the entire solution.
5. Connect the SQL database.
6. press f5 key to run the project.
## Testing
We have following ways to test the API first is using postman and second is using the mock test :-
1. Testing using postman :-
   a. CreateUser() API : -
      Request URL = https://localhost:44350/api/v1/user/CreateUser
	  Body data format = 	{
							"name": "dev sach",
							"emailAddress": "sach12@gmail.com",
							  "monthlySalary": 4000,
							  "monthlyExpenses": 3000,
							  "password": "sach@123456"
							}
							
	b. GetUserById() API
	    Request URL = https://localhost:44350/api/v1/user/GetUserById?Id=20
		
	c. GetAllUser()
		Request URL = https://localhost:44350/api/v1/user/GetAllUser
	
	d. CreateAccount() API : -
      Request URL = https://localhost:44350/api/v1/Account/CreateAccount
		  Body data format = 	{
									"AccountName": "test66 account",
									"UserId":4
								}
	e. GetAccounts() API :-
		Request URL = https://localhost:44350/api/v1/Account/GetAccounts

2. Mock test :-
	a. Points to test User Module:-
	   1. Open the UserControllerTests.cs file and there are three API for mock test right click on any API and then you will see a option of Debug Test then it will automatically start the testing and show you the response.
	b. Points to test Account Module:-
	   1. Open the AccountControllerTests.cs file and there are two API for mock test right click on any API and then you will see a option of Debug Test then it will automatically start the testing and show you the response.
 
## Deploying

## Additional Information
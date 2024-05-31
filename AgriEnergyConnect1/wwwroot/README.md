# Agri-Energy Connect Platform


## Setup Instructions

1. Clone the repository.
2. Open the solution in Visual Studio.
3. Restore NuGet packages.
4. Update the connection string in `appsettings.json` with your Azure SQL Database connection string.
5. Run the following commands in the Package Manager Console:
6. Build and run the project.


## User Roles and Functionalities


### Farmer
- Add products with details like name, category, and production date.
- View own product listings.


### Employee
- Add new farmer profiles with essential details.
- View and filter products from any farmer based on criteria like date range and product type.
- 

## UI Design Considerations
- **Intuitive Navigation**: The navigation menu provides easy access to different sections of the application for both farmers and employees.
- **Clear Layout**: The layout of each page is designed to be clean and organized, ensuring that information is presented in a clear and understandable manner.
- **Responsive Design**: The application is responsive and adapts well to various screen sizes, providing a consistent user experience across devices.


## User Experience Testing
- **Usability Testing**: The application has undergone usability testing with sample users to evaluate its ease of use and identify any areas of improvement.
- **Feedback Collection**: Users are encouraged to provide feedback on their experience with the application. A feedback form is available within the application for users to submit their comments, suggestions, or issues encountered.



## Deployment

1. Publish the application to Azure App Service or another hosting environment.
2. Ensure that the necessary configuration settings are updated for the production environment.
3. Test the deployed application to ensure that it runs smoothly in the production environment.


1. ## Additional Information
- The application uses ASP.NET Core MVC, Entity Framework Core, and Identity for authentication and authorization.
- Bootstrap is used for responsive design.
- Error handling is implemented to provide a better user experience.


2. ## Troubleshooting

- **Database Issues:** Ensure the connection string in `appsettings.json` is correct and that your Azure SQL Database is accessible.
- **Authentication Problems:** Ensure roles are correctly set up in the database. If necessary, use the `SeedData` class to initialize roles and a test user.
- **Dependency Issues:** Ensure all NuGet packages are restored and up-to-date.


3. ## Development Notes

- This application follows the MVC design pattern.
- Always run the application in `Development` environment locally to get detailed error messages.
- Before deploying, switch to `Production` environment to ensure sensitive information is not exposed.


4. ## Feedback and Support
If you have any feedback or need support, please don't hesitate to reach out. You can submit feedback directly within the application or contact our support team at support@agrienergyconnect.com.


5. ## Github Repository Link

https://github.com/VCCT-OPSC7311-G2-2024/ST10177615_DylanLeePadayachee_PROG7311POEPart2_AgriEnergyConnect1

6.  ## Website URL
	 
http://localhost:5163/


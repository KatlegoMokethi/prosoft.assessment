# Prosoft IT - Software Developer Assessment

## Tech Stack:
- .NET 7 Web API
- Database: Postgres

## Architecture:
I opted for Clean Architecture for promoting separion of concerns between core business logic (handling customer feedback) and external systems i.e the database and notification service. This has ensured that changes in each layer won't afftec others, making the Web API more maintainable and adaptable to change. I used this with CQRS to handle requests, which keeps the code clean and mainatable as well. I then chose PostgresSQL due to its reliability, conforming to SQL standards and has JSON support (in case we need to store document objects). It's flexible for this backend solution, managing data effectively.

## How to run the API:
- After pulling the repo to your local machine, download and install PgAdmin (https://www.pgadmin.org/download/). This will install a local postgres server to get started with.
- Create a superuser with password and update the connection in appsettings (e.g prosoftAdmin, ***)
- Globally install dotnet ef tool for running migrations via the terminal. Command: dotnet tool install --global dotnet-ef
- Run the following command to run migrations in the persistance layer: dotnet ef database update
- The appsettings file has the API Key and authentication options needed to make api requests via Swagger (or any tool).
- The appsettings file also has MailNotificationOptions, only update AdminEmails collection before running the API (in order to recieve emails for each successful feedback that is submitted).
- Run the API project and authorize with the API Key specified in the appsettings file for basic access.
![image](https://github.com/KatlegoMokethi/prosoft.assessment/assets/45683188/da779fe6-4c9a-436a-897e-559a02d2c147)
![image](https://github.com/KatlegoMokethi/prosoft.assessment/assets/45683188/fa1fe4ce-964d-42c9-b2e7-f1a361e504c0)
- Once authenticated, you can submit feedback as shown below:
![image](https://github.com/KatlegoMokethi/prosoft.assessment/assets/45683188/ae15f7d3-3ae5-4a43-91ee-d0b3c6982350)
This will auto send out notification emails as configired for Admins
![image](https://github.com/KatlegoMokethi/prosoft.assessment/assets/45683188/2b11c436-5f68-422a-a252-6c9945d256e6)
![image](https://github.com/KatlegoMokethi/prosoft.assessment/assets/45683188/58400fba-8467-4357-b870-d9abd44af222)
![image](https://github.com/KatlegoMokethi/prosoft.assessment/assets/45683188/c24b7496-f6a3-4069-893d-90c9161c7990)
![image](https://github.com/KatlegoMokethi/prosoft.assessment/assets/45683188/19ae1bdc-eea0-4955-b156-bece186d3ed9)
- In order to get all feedbacks as Admin, you'll need to provide a bearer token before calling **GET /api/v1/feedback/all** endpoint.
- I've created an endpoint to generate a valid token (although it's out of scope, it's the only way I could get it to work for ensuring admin-specific operations). Endpoint: **/api/v1/authentication/token**
  ![image](https://github.com/KatlegoMokethi/prosoft.assessment/assets/45683188/13ded858-258f-4c58-9c88-a2a7cd561667)
Authorize and call Get All Feedbacks
![image](https://github.com/KatlegoMokethi/prosoft.assessment/assets/45683188/633a605f-0e74-4b07-af3b-c24154fad729)
![image](https://github.com/KatlegoMokethi/prosoft.assessment/assets/45683188/16fa0556-c5c2-45fd-a94e-8f8e5ee63929)
-This is how the DB records look like:
<img width="1500" alt="image" src="https://github.com/KatlegoMokethi/prosoft.assessment/assets/45683188/8476c011-856f-4cc4-92ff-03646295dda7">

## Challenges:
- Initially battled a bit with running EF migrations at first, I was going to opt for using Roundhouse scripts as an alternative but writing manual scripts wasn't ideal and -rh command wasn't working. I got a workaround with running migrations as described above.
- I looked into SendGrid and opended a Twilio account but couldn't open the Web API integration dashboard. So, I ended up writing a custom notification service (which can be reused if packaged and released). I tested out the notification service as shown above.
  

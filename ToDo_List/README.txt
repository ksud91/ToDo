I have used generic repository pattern implementation to provide clean architecture for future expansion and facilitate testing

Unit of work pattern to ensure data integrity when operating on multiple entities

Added custom database initializer, inheriting from CreateDatabaseIfNotExists and overriding seed to populate example data on first run, I did want to have this check for an xml/json file to seed a million items to test performan but not create the file!

I would propose an additional service application that uses the existing backend code to scrape the database and notify users of outstanding issues, and issues due in the next x days.


 





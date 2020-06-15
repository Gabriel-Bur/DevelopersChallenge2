
## Database  
The connection string is setup for localdb and is located at appsettings.json, EF core will always try to create if does not exist.
````
  "ConnectionStrings": {
    "DefaultConnection": "Server=(localdb)\\mssqllocaldb;Database=Xayah-Database;Integrated Security=True"
  },
  ````


## Run

#### Clone
```
C:\>git clone https://github.com/Gabriel-Bur/DevelopersChallenge2.git
```
#### Restore, Build and Run
```
C:\DevelopersChallenge2\src>dotnet restore
C:\DevelopersChallenge2\src>dotnet build
C:\DevelopersChallenge2\src>dotnet run --project Xayah.Web
```

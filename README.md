# Exam Management System (İmtahan Proqramı)

## Layihənin Təsviri
**İmtahan proqramı** orta məktəb şagirdlərinin dərslər üzrə imtahan nəticələrinin qeydiyyatını aparmaq üçün hazırlanmış bir sistemdir.  

Sistem əsasən üç moduldan ibarətdir:  

1. **Dərslər (Lessons)**  
   Dərslər haqqında məlumatlar qeyd olunur:
   - Dərsin kodu: `char(3)`
   - Dərsin adı: `varchar(30)`
   - Sinif: `number(2,0)`
   - Müəllimin adı: `varchar(20)`
   - Müəllimin soyadı: `varchar(20)`

2. **Şagirdlər (Students)**  
   Şagirdlərin qeydiyyatı aparılır:
   - Nömrəsi: `number(5,0)`
   - Adı: `varchar(30)`
   - Soyadı: `varchar(30)`
   - Sinif: `number(2,0)`

3. **İmtahanlar (ExamResults)**  
   İmtahan nəticələrinin qeydiyyatı:
   - Dərsin kodu: `char(3)`
   - Şagirdin nömrəsi: `number(5,0)`
   - İmtahan tarixi: `date`
   - Qiyməti: `number(1,0)`

---

## Texnologiyalar və Kitabxanalar
- **Backend:** .NET 8 Web API  
- **ORM:** Entity Framework Core (EF Core)  
- **Database:**  
  - SQL Server (RDBMS)  
  - MongoDB (NoSQL, Logging və Auditing üçün)  
- **Data Seed və Mock Data:** Bogus  
- **Validation:** FluentValidation  
- **Mapping:** Customized AutoMapper  
- **Design Patterns:** Repository, Unit of Work, Singleton, Dependency Injection  
- **Prinsiplər:** SOLID, DRY, KISS  
- **Filterlar:** API query/filter özəllikləri üçün implementasiya  

---

## User Credentials
- **Admin**  
  - Username: `admin`  
  - Password: `Admin123!`
- **User**  
  - Username: `user`  
  - Password: `User123!`

---

## Docker Setup

### MongoDB
MongoDB konteyneri yaratmaq üçün:

```bash
docker run -d --name mongo -p 27017:27017 -e MONGO_INITDB_ROOT_USERNAME=admin -e MONGO_INITDB_ROOT_PASSWORD=adminpw mongo:latest

"ConnectionStrings": {
  "DefaultSql": "Server=(LocalDB)\\MSSQLLocalDB;Database=ExamDb;Trusted_Connection=True;MultipleActiveResultSets=true",
  "DefaultNoSql": "mongodb://logger:loggerpw@localhost:27017/LoggingDatabase"
}


ExamApp/
│
├─ WebApi/                    # ASP.NET Core Web API
│   ├─ Controllers/           # API Controllers
│   ├─ Entities/              # EF Core Entitylər
│   ├─ Configurations/        # Fluent API Configurations
│   ├─ DTOs/                  # Data Transfer Objects
│   ├─ Validators/            # FluentValidation Validators
│   └─ Mapping/               # AutoMapper Profiles
│
├─ Persistence/               # EF Core DbContext & Repositories
│
├─ MongoDb/                   # NoSQL Logging & Notification Repositories
│   └─ init-mongo.js          # MongoDB initial script (optional)
│
├─ Dockerfile                 # Multi-stage build
└─ README.md

Run Locally

Clone repository:

git clone <repo-url>
cd ExamApp


Run Docker MongoDB container:

docker-compose up -d
# OR manual docker run commands


Update appsettings.json connection strings.

Run the application:

dotnet restore
dotnet build
dotnet run --project WebApi/WebApi.csproj


API default port: 8080
Example endpoint: http://localhost:8080/api/lessons

Seed Data & Mocking

Bogus istifadə olunur mock data yaratmaq üçün:

Şagirdlər, müəllimlər, dərslər, imtahan nəticələri

Seed data EF Core HasData() ilə tətbiq edilir.

MongoDB-də loglar və notificationlar üçün seed data da mümkündür.

Logging & Notifications

MongoDB istifadə olunur:

ErrorLog

WarningLog

NotificationLog

IUnitOfWork pattern ilə implementasiya edilib.

Custom repositories və services ilə bağlanır.

Validation

FluentValidation ilə bütün model və DTO-lar validate edilir:

Məsələn, ExamValue 0–5 aralığında olmalıdır.

Name/Surname varchar limitlərinə uyğun olmalıdır.

Design Principles

SOLID prinsipinə uyğun olaraq servis, repository və controller qatları ayrılıb.

Dependency Injection istifadə olunur.

Unit of Work pattern ilə transaction-lar idarə olunur.

Repository pattern ilə database abstraction təmin edilir.

Notes

SQL Server və MongoDB paralel olaraq işləyir.

Docker ilə MongoDB avtomatik konfiqurasiya edilə bilər (init-mongo.js).

Admin və User fərqli səviyyədə API access-ə sahibdir.
docker exec -it mongo bash
mongosh -u admin -p adminpw --authenticationDatabase admin

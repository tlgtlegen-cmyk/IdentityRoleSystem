# IdentityRoleSystem

**Студент:** Айша Тілеген  
**Оқу орны:** Абай атындағы Қазақ ұлттық педагогикалық университеті  
**Курс:** 3-курс  
**Тапсырма:** 5-апта үй тапсырмасы

## Тапсырманың мақсаты

ASP.NET Core Identity негізінде пайдаланушыларды және рөлдерді басқару жүйесін әзірлеу. Жүйеде тіркелу, кіру, шығу, Dashboard, студенттер тізімі және рөлдік қолжетімділік іске асырылған.

## Қолданылған технологиялар

- .NET 8
- ASP.NET Core MVC
- C#
- ASP.NET Core Identity
- Entity Framework Core
- SQLite
- Razor Views
- HTML, CSS, JavaScript
- Bootstrap 5
- GitHub

## Жоба құрылымы

- `Controllers/AccountController.cs` — тіркелу, кіру және POST шығысы
- `Controllers/StudentsController.cs` — студенттер тізімі және жою
- `Models/ApplicationUser.cs` — аты және тегі бар қолданушы моделі
- `Models/RegisterViewModel.cs` — тіркелу деректері және серверлік валидация
- `Models/LoginViewModel.cs` — кіру деректері
- `Data/AppDbContext.cs` — IdentityDbContext<ApplicationUser>
- `Views/Account/` — тіркелу және кіру беттері
- `Views/Students/` — студенттер тізімі
- `Data/Migrations/` — Entity Framework миграциясы
- `screenshots/` — нақты бағдарламадан алынған скриншоттар

## Орнату нұсқаулығы

```powershell
cd IdentityRoleSystem
dotnet restore
dotnet ef database update
dotnet run
```

SQLite дерекқоры `app.db` файлындa сақталады. Қажет болса `dotnet ef` құралын орнату:

```powershell
dotnet tool install --global dotnet-ef
```

## Миграция командалары

```powershell
dotnet ef migrations add InitialIdentityRoleSystem --context AppDbContext
dotnet ef database update --context AppDbContext
```

## Іске қосу командасы

```powershell
dotnet run
```

Әдепкі жергілікті мекенжай: `http://localhost:5000` немесе `Properties/launchSettings.json` ішінде көрсетілген мекенжай.

## Рөлдер сипаттамасы

### Admin

- Студенттер тізімін көреді.
- Студент қолданушыларын жоя алады.
- Жою әрекеті тек `Admin` рөліне және POST әдісіне рұқсат етіледі.

Бастапқы Admin тіркелгісі:

- Email: `admin@identity.kz`
- Құпиясөз: `Admin123!`

### Student

- Жүйеге тіркелу кезінде автоматты түрде беріледі.
- Dashboard және студенттер тізімін көре алады.
- Тізімнен пайдаланушыны жоюға рұқсаты жоқ.

## Тестілеу нәтижелері

- `dotnet build`: сәтті, ескерту жоқ, қате жоқ.
- `dotnet ef database update`: SQLite миграциясы сәтті қолданылды.
- `/`, `/Account/Register` және `/Account/Login`: HTTP 200.
- Анонимді `/Students` сұранысы кіру бетіне қайта бағытталды.
- Student тіркелгісі жасаылып, автоматты түрде Student рөлі тағайындалды.
- Student Student тізімін көрді, Жою батырмасын көрмеді.
- Admin арқылы кіру жүргізіліп, студентті жою батырмасы табылды.
- Шығу тек POST формасы арқылы орындалды.

## Скриншоттар

Нақты жұмыс істеп тұрған бағдарламадан алынған скриншоттар `screenshots/` папкасында сақталған:

1. `register.png`
2. `login.png`
3. `student-restrictions.png`
4. `admin-capabilities.png`

## Қорытынды

IdentityRoleSystem жобасында қажетті ASP.NET Core Identity компоненттері, SQLite дерекқоры, миграциялар, серверлік валидация және рөлдік қорғау толық іске асырылды. Интерфейс қазақ тілінде жасалды және Admin/Student мүмкіндіктері Dashboard пен студенттер тізімі арқылы нақты ажыратылды.

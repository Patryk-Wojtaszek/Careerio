using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Careerio.Models;
using Careerio.Authentication;

namespace Careerio.Data
{
    public class SeedData
    {
        public static void Init(IServiceProvider serviceProvider)
        {
            using (var context = new CareerioDbContext(
                serviceProvider.GetRequiredService<DbContextOptions<CareerioDbContext>>()))
            {

                var pendingMigrations = context.Database.GetPendingMigrations();
                if (pendingMigrations != null && pendingMigrations.Any())
                {
                    context.Database.Migrate();
                }

                SeedCompanies(context);
                SeedRemote(context);
                SeedExperience(context);
                SeedContracts(context);
                SeedHours(context);
                SeedJobOffers(context);
                SeedRoles(context);
             
            }
        }

 

        private static void SeedRoles(CareerioDbContext context)
        {
            if (context.Roles.Any())
            {
                return;
            }
            context.Roles.AddRange(
                new Role
                {
                    Id =1,
                    Name = "User"
                },
                new Role
                {
                    Id = 73,
                    Name = "Admin"
                });
            context.SaveChanges();
        }
        private static void SeedJobOffers(CareerioDbContext context)
        {
            if(context.JobOffers.Any())
            {
                return;
            }
            var companies = context.Companies
                .ToDictionary(c => c.Name, c => c.Id);
           if(context.JobOffers.Any())
            {
                return;
            }
            context.JobOffers.AddRange(
                new JobOffer
                {
                    JobTitle = "Backend Developer",
                    DateTime = DateTime.Now,
                    WorkingHoursID = 1,
                    ExperienceLevelId = 1,
                    RemoteRecruitmentId = 1,
                    TypeOfContractId = 2,
                    SalaryFrom = 3500,
                    SalaryTo = 6000,
                    CompanyId = companies["Comarch"],
                    Requirement = new Requirement()
                    {
                        Requirements = new string[] { "znajomość frameworków Node.js (Express)", "umiejętność tworzenia Web Services (REST/GraphQL)", "znajomość SQL (PostgreSQL)",
                    "doświadczenie w pracy z systemem kontroli wersji Git", "umiejętność komunikacji w języku polskim i angielskim"}
                    },
                    Responsibility= new Responsibility()
                    {
                       Responsibilities = new string[] { "Planowanie i wycena nowych funkcjonalności (oraz rozwijanie istniejących)","implementacja API (Node.js / GraphQL)",
                    "udział w podejmowaniu decyzji dotyczących architektury stosowanych rozwiązań", "tworzenie testów automatycznych","wsparcie pozostałych członków zespołu podczas prac implementacyjnych" }
                    }
                    
                },
                new JobOffer
                {
                    JobTitle = "Frontend Developer",
                    DateTime = DateTime.Now,
                    WorkingHoursID = 1,
                    ExperienceLevelId = 4,
                    RemoteRecruitmentId = 1,
                    TypeOfContractId = 3,
                    SalaryFrom = 12000,
                    SalaryTo = 16000,
                    CompanyId = companies["Nokia"],
                    Requirement = new Requirement()
                    {
                        Requirements = new string[] { "Zdolności organizacyjne", "Znajomość HTML5, CSS, JavaScript (es6+)", "Znajomość narzędzi do automatyzacji pracy jak Gulp albo Webpack itp.",
                    "Znajomość różnic w interpretacji kodu przez różne przeglądarki","Umiejętność tworzenia stron opartych na rozwiązaniach Responsive Web Design"}
                    },
                    Responsibility = new Responsibility()
                    {
                        Responsibilities = new string[] { "Analizowanie i implementacja wymagań klienta", "Projektowanie i wdrażanie nowych sklepów internetowych z wykorzystaniem autorskiego systemu CMS",
                    "Utrzymywanie sklepów internetowych, wdrażanie/modyfikowanie funkcjonalności na życzenie klienta, reagowanie na awarie","Optymalizowanie istniejącego kodu sklepów internetowych",
                    "Rozwijanie autorskiego systemu CMS"}
                    }
                },
                new JobOffer
                {
                    JobTitle="Tester oprogramowania",
                    DateTime = DateTime.Now,
                    WorkingHoursID = 2,
                    ExperienceLevelId = 4,
                    RemoteRecruitmentId = 1,
                    TypeOfContractId = 1,
                    SalaryFrom = 13000,
                    SalaryTo = 14500,
                    CompanyId = companies["Motorola"],
                    Requirement = new Requirement
                    {
                        Requirements = new string[] { "Min. 4 lata doświadczenia jako tester", "Doświadczenie w testowaniu backendu i frontend", "Biegłość w testach funkcjonalnych, E2E i UAT w ramach SDLC i STLC",
                        "Bardzo dobra znajomość różnych faz i typów testowania: Integracja, UAT, E2E, testy funkcjonalne", "Praktyczne doświadczenie z metodologiami Agile (preferowany Scrum)",
                        "Umiejętność komunikowania się w języku angielskim na co dzień w mowie i piśmie (min. B2)", "Doskonałe umiejętności zarządzania czasem i umiejętność dotrzymywania terminów"}
                    },
                    Responsibility = new Responsibility
                    {
                        Responsibilities = new string[] { "Analiza wymagań biznesowych i współpraca z analitykami biznesowymi/Product Ownerem", "Identyfikowanie przypadków testowych na podstawie wymagań",
                        "Tworzenie i wykonywanie testów manualnych i przypadków testowych w celu zapewnienia zgodności ze specyfikacjami i dokumentacją","Wykonywanie testów funkcjonalnych i E2E",
                        "Identyfikacja, raportowanie, zarządzanie defektami","Testowanie backendu i frontendu, w tym API, bazy danych i Salesforce"}
                    }


                },
                new JobOffer
                {
                    JobTitle="Android Developer",
                    DateTime = DateTime.Now,
                    WorkingHoursID = 1,
                    ExperienceLevelId = 2,
                    RemoteRecruitmentId = 1,
                    TypeOfContractId = 2,
                    SalaryFrom = 6000,
                    SalaryTo = 7500,
                    CompanyId = companies["Samsung"],
                    Requirement = new Requirement
                    {
                        Requirements= new string[] { "2-lata doświadczenia w pisaniu aplikacji na Androida", "Praktyczna znajomość komponentów Android SDK",
                        "Znajomość Kotlina i Spring Boot", "Poparta doświadczeniem umiejętność optymalizowania i profilowania aplikacji w aspektach: CPU, GPU, pamięć, sieć"}

                    },
                    Responsibility = new Responsibility
                    {
                        Responsibilities= new string[] { "Analiza techniczna", "Rozwój aplikacji zarządzanych w Android Enterprice", "Budowanie testów jednostkowych",
                        "Dzielenie się wiedzą we własnym obszarze wiedzy specjalistycznej", "Optymalizowanie i profilowanie aplikacji", "Uczestnictwo w projektach rozbudowy systemów biznesowych"}
                    }

                },
                new JobOffer
                {
                    JobTitle = "PHP Developer",
                    DateTime = DateTime.Now,
                    WorkingHoursID = 1,
                    ExperienceLevelId = 4,
                    RemoteRecruitmentId = 1,
                    TypeOfContractId = 2,
                    SalaryFrom = 12000,
                    SalaryTo = 17500,
                    CompanyId = companies["Samsung"],
                    Requirement = new Requirement
                    {
                        Requirements= new string[] { "bardzo dobra znajomość PHP 7+ oraz frameworka Symfony w wersji 4+","bardzo dobra umiejętność korzystania z Doctrine",
                        "znajomość lub chęć nauczenia się podstaw ElasticSearch", "umiejętność pracy z git","znajomość jQuery, JavaScript, HTML, CSS, SASS, vue.js"}
                    },
                    Responsibility = new Responsibility
                    {
                        Responsibilities=new string[] { "programowanie funkcjonalności (OOP)","refaktoryzacja i optymalizacja kodu","debugowanie i naprawianie błędów",
                        "proponowanie technicznych rozwiązań problemów","dbanie o bezpieczeństwo danych klientów"}
                    }
                },
                new JobOffer
                {
                    JobTitle = "Ruby on Rails Developer",
                    DateTime = DateTime.Now,
                    WorkingHoursID = 1,
                    ExperienceLevelId = 4,
                    RemoteRecruitmentId = 1,
                    TypeOfContractId = 2,
                    SalaryFrom = 12000,
                    SalaryTo = 17500,
                    CompanyId = companies["Samsung"],
                    Requirement = new Requirement
                    {
                        Requirements=new string[] { "min. 2 lata doświadczenia produkcyjnego w Ruby/Ruby on Rails", "JavaScript, HTML, CSS oraz GIT",
                        "Bazy danych: MySQL lub PostgreSQL","Język angielskim w stopniu umożliwiającym czytanie dokumentacji"}
                    },
                    Responsibility=new Responsibility
                    {
                        Responsibilities=new string[] { "dostarczanie nowych funkcjonalności", "proponowanie technicznych rozwiązań problemów" }
                    }
                },
                new JobOffer
                {
                    JobTitle = "Frontend developer",
                    DateTime = DateTime.Now,
                    WorkingHoursID = 2,
                    ExperienceLevelId = 1,
                    RemoteRecruitmentId = 1,
                    TypeOfContractId = 2,
                    SalaryFrom = 3000,
                    SalaryTo = 4000,
                    CompanyId = companies["Motorola"],
                    Requirement = new Requirement
                    {
                        Requirements=new string[] { "Jesteś studentem informatyki, matematyki, fizyki lub ekonometrii", "Posiadasz praktyczną znajomość języka JavaScript",
                        "Wiesz co to react i nie boisz się używać TypeScript'a","Znasz podstawowe komendy gita"}
                    },
                    Responsibility=new Responsibility
                    {
                        Responsibilities=new string[] {"Udział w innowacyjnych projektach", "refaktoryzacja i optymalizacja kodu", "debugowanie i naprawianie błędów"}
                    }

                },
                new JobOffer
                {

                    JobTitle = "Analityk danych marketingu i sprzedaży",
                    DateTime = DateTime.Now,
                    WorkingHoursID = 2,
                    ExperienceLevelId = 3,
                    RemoteRecruitmentId = 1,
                    TypeOfContractId = 1,
                    SalaryFrom = 13000,
                    SalaryTo = 14000,
                    CompanyId = companies["Motorola"],
                    Requirement = new Requirement
                    {
                        Requirements=new string[] { "wykształcenie wyższe preferowane kierunki z obszaru STEM i ekonometria, mile widziana specjalizacja w analizie danych", "biegła znajomość systemów i programów: PowerBI (w tym języka DAX, dobra orientacja w jezyku M), HotJar, Google Ads, Meta Ads, Google Analytics, Google Data Studio, Google Optimize",
                        "znajomość języka R lub Python, w tym szczególnie bibliotek do przetwarzania danych oraz automatyzacji procesów pobierania danych","znajomość SQL (preferowany PostgreSQL, MySQL)"}
                    },
                    Responsibility = new Responsibility
                    {
                        Responsibilities=new string[] { "Bieżące raportowanie i analiza przyjętych mierników", "Analiza sprzedażowa platform i stron sprzedażowych w obsługiwanych regionach",
                        "Optymalizacja - dostosowywanie witryn do oczekiwań użytkowników oraz zwiększenia sprzedaży","Samodzielny dobór narzędzi analitycznych, oraz reagowanie na bieżące wyniki raportów"}
                    }

                },
                new JobOffer
                {
                    JobTitle = "Java Developer",
                    DateTime = DateTime.Now,
                    WorkingHoursID = 2,
                    ExperienceLevelId = 3,
                    RemoteRecruitmentId = 1,
                    TypeOfContractId = 1,
                    SalaryFrom = 13000,
                    SalaryTo = 14000,
                    CompanyId = companies["Nokia"],
                    Requirement=new Requirement
                    {
                        Requirements= new string[] { "Dobra znajomość Javy","Dobra znajomość Springa","Znajomość JavaScriptu","Biegłość w zrozumieniu i swobodnym poruszaniu się w terminologii techniczno-architektonicznej.",
                        "Elastyczne podejście do pracy w różnych projektach i różnych frameworkach (Hybris, rozwoje i utrzymanie systemu itp.)"}
                    },
                    Responsibility=new Responsibility
                    {
                        Responsibilities=new string[] {"Bieżący rozwój systemu w sprintach","Rozwiązywanie problemów produkcyjnych zgłaszanych przez klienta","Współpraca ze specjalistami ds. hostingu aplikacji oraz inżynierami DevOps",
                        "Tworzenie dokumentacji technicznej wdrażanego rozwiązania"}
                    }

                },
                new JobOffer
                {
                    JobTitle = "Architekt systemów",
                    DateTime = DateTime.Now,
                    WorkingHoursID = 2,
                    ExperienceLevelId = 2,
                    RemoteRecruitmentId = 2,
                    TypeOfContractId = 1,
                    SalaryFrom = 6000,
                    SalaryTo = 10000,
                    CompanyId = companies["Nokia"],
                    Requirement=new Requirement
                    {
                        Requirements=new string[] {"wykształcenie techniczne lub ekonomiczne (informatyka, matematyka, ekonomia)","umiejętność przełożenia wymagań biznesowych na wymagania techniczne",
                        "doświadczenie w projektowaniu, analizie oraz implementacji systemów informatycznych","umiejętność projektowania systemów z wykorzystaniem gotowych elementów open-source","umiejętność dokumentowania architektury i funkcjonalności systemów zgodnie z trendami rynkowymi",
                        "umiejętność przygotowywania przypadków użycia i przypadków testowych"}
                    },
                    Responsibility=new Responsibility
                    {
                        Responsibilities=new string[] {"analiza posiadanych przez klienta systemów","projektowanie nowych rozwiązań", "specyfikowanie funkcji systemu i ustalanie zakresu","projektowanie struktur danych",
                        "śledzenie trendów rynkowych"}
                    }
                    
                },
                new JobOffer
                {
                    JobTitle = "Java Developer",
                    DateTime = DateTime.Now,
                    WorkingHoursID = 2,
                    ExperienceLevelId = 2,
                    RemoteRecruitmentId = 2,
                    TypeOfContractId = 3,
                    SalaryFrom = 6000,
                    SalaryTo = 10000,
                    CompanyId = companies["Comarch"],
                    Requirement=new Requirement
                    {
                        Requirements=new string[] {"Min. 2 lata doświadczenia komercyjnego w programowaniu w Java","Dobra znajomość Java 8 i wyższej, Spring, Hibernate","Doświadczenie w implementacji aplikacji z wykorzystaniem technologii JEE (Spring, REST, Web Services)",
                        "Podstawowa znajomość narzędzi: Gradle, Maven, GIT"}
                    },
                    Responsibility=new Responsibility
                    { Responsibilities=new string[] {"Rozwój i utrzymanie obecnego oprogramowania","Udział w projektach typu PoC (weryfikacje użyteczności technologii)",
                    "Tworzenie rozwiązań w oparciu o język Java oraz relacyjną bazę Oracle, w tym udział w projektowaniu i modelowaniu nowych rozwiązań"}
                    }
                },
                new JobOffer
                {
                    JobTitle = "Python Developer",
                    DateTime = DateTime.Now,
                    WorkingHoursID = 2,
                    ExperienceLevelId = 2,
                    RemoteRecruitmentId = 2,
                    TypeOfContractId = 3,
                    SalaryFrom = 6000,
                    SalaryTo = 10000,
                    CompanyId = companies["Comarch"],
                    Requirement=new Requirement
                    {
                        Requirements=new string[] {"Min. 3 letnie komercyjne doświadczenie w tworzeniu projektów z wykorzystaniem Pythona 3.X.","Znajomość JavaScript w wersji co najmniej ES6 wraz z HTML, CSS (SCSS).",
                        "Znajomość jednego z popularnych frameworków webowych (Django, Flask).","Umiejętność biegłego korzystania z baz relacyjnych (PostgreSQL, MySQL) oraz nierelacyjnych (MongoDB, Redis).","Umiejętność posługiwania się Linuxem.",
                        "Umiejętność analitycznego myślenia, kreatywność.","Znajomość zasad projektowania obiektowego i wzorców projektowych."}
                    },
                    Responsibility=new Responsibility
                    {
                        Responsibilities=new string[] {"Tworzenie skalowalnych rozwiązań opartych o RESTowe API, które służą do komunikacji z aplikacjami mobilnymi.","Nowoczesne aplikacje webowe wykorzystujące najnowsze technologie."}
                    }
                }
            
                );
            context.SaveChanges();
        }

        private static void SeedHours(CareerioDbContext context)
        {
            if (context.WorkingHours.Any())
            {
               
                return;

            }
            context.WorkingHours.AddRange(
                new WorkingHours
                {
                    Id = 1,
                    WorkingHoursDescription = "Pełny etat"
                },
                new WorkingHours
                {
                    Id = 2,
                    WorkingHoursDescription = "Praca dorywcza"
                });
            context.SaveChanges();
        }

        private static void SeedContracts(CareerioDbContext context)
        {
            if (context.TypeOfContracts.Any())
            {
                
                return;
            }
            context.TypeOfContracts.AddRange(
                new TypeOfContract
                {
                    Id = 1,
                    TypeOfContractDescription = "B2B",
                    Shortcut = "B2B"


                },
                new TypeOfContract
                {
                    Id = 2,
                    TypeOfContractDescription = "Umowa zlecenie",
                    Shortcut = "UZ"
                },
                new TypeOfContract
                {
                    Id = 3,
                    TypeOfContractDescription = "Umowa o pracę",
                    Shortcut = "UOP"
                });
            context.SaveChanges();
        
    }

        private static void SeedExperience(CareerioDbContext context)
        {
            if (context.ExperienceLevels.Any())
            {
                return;
            }
            context.ExperienceLevels.AddRange(
           new ExperienceLevel
           {
               Id = 1,
               ExperienceLevelDescription = "Staż"
           },
           new ExperienceLevel
           {
               Id = 2,
               ExperienceLevelDescription = "Junior"
           },
            new ExperienceLevel
            {
                Id = 3,
                ExperienceLevelDescription = "Mid"
            },
           new ExperienceLevel
           {
               Id = 4,
               ExperienceLevelDescription = "Senior"
           });
            context.SaveChanges();
        }

        private static void SeedRemote(CareerioDbContext context)
        {
            if (context.RemoteRecruitments.Any())
            {
             
                return;
            }
            context.RemoteRecruitments.AddRange(
                new RemoteRecruitment
                {
                    Id = 1,
                    IsRemoteRecruitment = true
                },
                new RemoteRecruitment
                {
                    Id = 2,
                    IsRemoteRecruitment = false
                }); ;
            context.SaveChanges();
        }

        private static void SeedCompanies(CareerioDbContext context)
        {
            if (context.Companies.Any())
            {
                return;
            }

            context.Companies.AddRange(
               new Company
               {
                   Name = "Motorola",
                   Url = "https://www.motorola.com/pl/",
                   NumberOfEmployees = 53000,
                   ShortDescription = "Amerykańskie przedsiębiorstwo telekomunikacyjne założone w 1928 roku",
                   ImageUrl = "http://logok.org/wp-content/uploads/2014/11/Motorola-logo-880x660.png",
                   LongDescription = "W kwietniu 1998 Motorola otworzyła w Polsce, w Krakowie, Centrum Oprogramowania. Jest ono jednym z dwudziestu takich placówek rozsianych po całym świecie, zatrudniających około pięciu tysięcy inżynierów. Do roku 2008 centra te tworzyły Global Software Group, obecnie są częścią biznesów Motoroli. Centrum krakowskie produkuje i integruje oprogramowania stacji bazowych telefonii komórkowej trzeciej generacji w systemach CDMA, UMTS (biznes Home & Networks Mobility) oraz w standardzie TETRA/APCO dla służb bezpieczeństwa publicznego (biznes Enterprise Mobility Solutions). Krakowskie centrum Motoroli uczestniczy też w tworzeniu oprogramowania elementów platformy wspierającej infrastrukturę trzeciej generacji (High Availability Platform), do systemów charakteryzujących się minimalnym czasem awarii. Polscy inżynierowie koordynują w niektórych dziedzinach, działania badawczo-rozwojowe Motoroli w regionie Europy Środkowo-Wschodniej. Krakowski ośrodek Motoroli posiada unikalne w skali światowej laboratorium infrastruktury komórkowej w systemach CDMA i UMTS, dzięki czemu może tworzyć i integrować oprogramowanie, ale i świadczyć 24-godzinny serwis dla operatorów komórkowych, takich jak Sprint, KDDI, Verizon i Alltell. Obecnie ośrodek zatrudnia blisko 1000 osób. Po podziale Motoroli krakowskie Centrum Oprogramowania weszło w skład Motoroli Solutions.",
                   DateOfStarting = 1928,
                   Industry = "Telekomunikacja",
                   Email = "motorola@motorola.pl",
                   Address = new Address()
                   {
                       City = "Chicago",
                       Province = "Illinois",
                       Country = "Stany Zjednoczone",
                       PostCode = "75009",
                       Street = "500 W Monroe Ste 4400"
                   },
                   Benefit = new Benefit()
                   {
                       Benefits = new string[] { "Prywatna opieka medyczna", "Multisport", "Firmowe wyjazdy zagraniczne", "Dopłaty do nauki" }
                   },
                   Gallery = new Gallery()
                   {
                       Photos = new string[] { "https://inhire.io/images/company_company_common_profile_photo_0_10516_1593592701111.jpg", "https://pliki.propertydesign.pl/i/10/94/66/109466_r0_1140.jpg,", "https://pliki.propertydesign.pl/i/10/94/65/109465_1140.jpg" }
                   },
                
                   Technology = new Technology()
                   {
                       Technologies = new string[] { "Java", "Sql" }
                   }
               },
               new Company
               {
                   Name = "Samsung",
                   Url = "https://www.samsung.com/pl/",
                   ShortDescription = "Południowokoreańska grupa zrzeszająca przedsiębiorstwa produkcyjne i usługowe oraz instytucje finansowe",
                   NumberOfEmployees = 287439,
                   ImageUrl = "https://images.samsung.com/is/image/samsung/assets/global/about-us/brand/logo/pc/720_600_1.png?$720_N_PNG$",
                   DateOfStarting = 1938,
                   Industry = "Telekomunikacja",
                   LongDescription = "W latach 90. XX wieku Samsung stał się korporacją międzynarodową i liderem w produkcji podzespołów elektronicznych. We wrześniu 1993 roku Samsung Construction dostał zlecenie na budowę jednej z dwóch wież Petronas Towers w stolicy Malezji Kuala Lumpur, a w 2004 na budowę największej budowli zbudowanej przez człowieka, wieży Burdż Dubaj w Dubaju (otwartej jako Burdż Chalifa).Samsung Electronics stał się silnym konkurentem dla przedsiębiorstw japońskich, tajwańskich i amerykańskich przedsiębiorstw z Doliny Krzemowej, rozwijając produkcję głównie układów pamięci DRAM, pamięci flash, lodówek i odtwarzaczy DVD, stawiając sobie za cel podwojenie sprzedaży i osiągnięcie pozycji globalnego lidera w produkcji 20 produktów z tej grupy do 2010 roku. Obecnie Samsung Electronics jest wiodącym producentem ekranów LCD i nowoczesnych telefonów komórkowych.",
                   Email = "samsung@samsung.pl",
                   Address = new Address()
                   {
                       City = "Seoul",
                       Province = "Seocho District",
                       Country = "Korea Południowa",
                       PostCode = "06899",
                       Street = "Seocho-daero 74-gil"
                   },
                   Benefit = new Benefit()
                   {
                       Benefits = new string[] { "Prywatna opieka medyczna", "Multisport", "Mały zespół", "Kursy językowe" }
                   },
                   Gallery = new Gallery()
                   {
                       Photos = new string[] { "http://crn.thecamels.pl/wp-content/uploads/media/default/0001/16/059af28de040b036e10f6ac1572792f379c279f4.jpg", "https://i.iplsc.com/-/0002L6W2FMTB5SI8-C122-F4.jpg", "https://pliki.propertydesign.pl/i/06/49/89/064989_r0_1140.jpg" }
                   },
             
                   Technology = new Technology()
                   {
                       Technologies = new string[] { "Figma", "UxPin", "JavaScript" }
                   }
               },
               new Company
               {
                   Name = "Comarch",
                   Url = "https://www.comarch.pl/",
                   ShortDescription = "Jedna z największych polskich spółek informatycznych z siedzibą w Krakowie założona w 1993 przez profesora Akademii Górniczo-Hutniczej Janusza Filipiaka i jego dwunastu studentów",
                   NumberOfEmployees = 7000,
                   ImageUrl = "https://getfound.pl/wp-content/uploads/2014/07/logo-comarch.jpg",
                   DateOfStarting = 1993,
                   Industry = "IT",
                   LongDescription = "Przedsiębiorstwo koncentruje się na działalności w następujących sektorach: oprogramowanie dla administracji publicznej,oprogramowanie dla sektora zdrowia,oprogramowanie klasy ERP dla małych i średnich przedsiębiorstw.",
                   Email = "comarch@comarch.pl",
                   Address = new Address()
                   {
                       City = "Kraków",
                       Province = "Malopolska",
                       Country = "Polska",
                       PostCode = "31-864",
                       Street = "al. Jana Pawła II 39a"
                   },
                   Benefit = new Benefit()
                   {
                       Benefits = new string[] { "Prywatna opieka medyczna", "Multisport", "Dodatkowy program emerytalny", "Dopłaty do wyżywienia" }
                   },
                   Gallery = new Gallery()
                   {
                       Photos = new string[] { "https://www.comarch.pl/files-pl/file_54/lodz-comarch-fot-piotr-krajewski-1-jpg-lq_29_N_5D3_5244.jpg", "https://www.starosadeckie.info/wp-content/uploads/2021/08/Comarch-siedziba.jpg", "https://kariera.comarch.pl/files-pl/file_34/warszawa-comarch.jpg" }
                   },
            
                   Technology = new Technology()
                   {
                       Technologies = new string[] { "Java", "Android" }
                   }

               },
               new Company
               {
                   Name = "Nokia",
                   Url = "https://www.nokia.com/",
                   ShortDescription = "Znane z produkcji telefonów komórkowych przedsiębiorstwo zajmujące się technologiami telekomunikacyjnymi",
                   NumberOfEmployees = 92000,
                   ImageUrl = "https://www.telix.pl/wp-content/uploads/2015/04/nokia-logo.jpg",
                   DateOfStarting = 1865,
                   Industry = "Telekomunikacja",
                   LongDescription = "Przedsiębiorstwo założone zostało w roku 1865 jako fabryka masy papierniczej, następnie zajmowało się produkcją kabli i galanterii gumowej. Przedsiębiorstwo zaczęło używać nazwy Nokia, po przeniesieniu produkcji do miasta Nokia w Finlandii. Po przeprowadzce przedsiębiorstwo weszło w branżę elektroniczną, produkując elektronikę użytkową: telewizory, magnetowidy, zestawy do odbioru telewizji satelitarnej, a także podzespoły elektroniczne. Nokia przez krótki okres produkowała własne roboty przemysłowe",
                   Email = "nokia@nokia.pl",
                   Address = new Address()
                   {
                       City = "Espoo",
                       Province = "Greater Helsinki",
                       Country = "Finlandia",
                       PostCode = "02610",
                       Street = "Karakaari 7"
                   },
                   Benefit = new Benefit()
                   {
                       Benefits = new string[] { "Prywatna opieka medyczna", "Multisport", "Szkolenia Wewnątrzfirmowe", "Telefon służbowy" }
                   },
                   Gallery = new Gallery()
                   {
                       Photos = new string[] { "https://prowly-uploads.s3.eu-west-1.amazonaws.com/uploads/4636/assets/91578/large-e40eceeaf9c283ebe2aa91c1478c1217.jpg", "https://bi.im-g.pl/im/f5/a9/13/z20616949V,Wroclawskie-biura-firmy-Nokia.jpg", "https://www.sztuka-wnetrza.pl/galleries/thumbs/fit_in_900x600/nokia2.jpg" }
                   },
             
                   Technology = new Technology()
                   {
                       Technologies = new string[] { "Adobe Photoshop", "Jira" }
                   }

               });
            context.SaveChanges();
        }
    }
}
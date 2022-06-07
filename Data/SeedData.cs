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
                Console.WriteLine("Roles already seeded");
                return;
            }
            context.Roles.AddRange(
                new Role
                {
                    Name = "User"
                },
                new Role
                {
                    Name = "Employer"
                },
                new Role
                {
                    Name = "Admin"
                });
            context.SaveChanges();
        }
        private static void SeedJobOffers(CareerioDbContext context)
        {
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
                    
                });
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
                   RelatedIndustry = new RelatedIndustry()
                   {
                       RelatedIndustries = new string[] { "Bankowość", "Finanse", "Telekomunikacja" }
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
                   RelatedIndustry = new RelatedIndustry()
                   {
                       RelatedIndustries = new string[] { "Technologiczne innowacje w usługach finansowych", "Bankowość" }
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
                   RelatedIndustry = new RelatedIndustry()
                   {
                       RelatedIndustries = new string[] { "Finanse", "Telekomunikacja" }
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
                   RelatedIndustry = new RelatedIndustry()
                   {
                       RelatedIndustries = new string[] { "Technologiczne innowacje w usługach finansowych", "Telekomunikacja" }
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
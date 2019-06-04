using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices.ComTypes;
using System.Threading.Tasks;
using FileReader;
using MedicalExamination.DAL;
using MedicalExamination.Entities;
using Microsoft.AspNetCore.Identity;

namespace MedicalExaminationWeb
{
    public sealed class DbInitializer
    {
        private readonly MedicalExaminationContext _context;
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly RoleManager<ApplicationRole> _roleManager;


        public DbInitializer(MedicalExaminationContext context, UserManager<ApplicationUser> userManager, 
            RoleManager<ApplicationRole> roleManager)
        {
            _context = context;
            _userManager = userManager;
            _roleManager = roleManager;
        }

        public async Task Initialize()
        {
            //_context.Database.EnsureCreated();
            InitDiseaseOutcomeTypes();
            //InitPassportIssuePlaceType();
            //InitInsuranceCompanyType();
            //await InitRoles();
            //await InitUsers();
            //InitPatients();
            //InitServiceType();
            //InitWorker();
            //InitProvideService();
            //InitPositionType();
            //InitPosition();
        }

        private void InitPosition()
        {
            if(_context.Positions.Any())
                return;

            var worker = _context.Workers.First();

            var positionType = _context.PositionTypes.First();

            var position = new Position
            {
                PositionId = positionType.Id,
                PositionType = positionType,
                Worker = worker,
                WorkerId = worker.PersonId
            };
        }

        private void InitWorker()
        {
            if(_context.Workers.Any())
                return;

            var passportIssuePlaceType = _context.PassportIssuePlaceTypes.ToList()[1];

            var person = new Person
            {
                BirthDate = DateTime.Now.AddYears(-36),
                FirstName = "Петрович",
                LastName = "Иван",
                Gender = MedicalExamination.Entities.Gender.Female,
                INN = "32228",
                MiddleName = "Иванович",
                PassportIssueDate = DateTime.Now,
                PassportIssuePlaceId = passportIssuePlaceType.Id,
                PassportNumber = "436463",
                PassportSeries = "543534",
                SNILS = "54353453453"
            };

            person.Id = _context.Persons.Add(person).Entity.Id;

            _context.SaveChanges();

            var worker = new Worker
            {
                PersonId = person.Id,
                Person = person
            };

            _context.Workers.Add(worker);

            _context.SaveChanges();
        }

        private void InitDiseaseOutcomeTypes()
        {
            if(_context.DiseaseOutcomeTypes.Any())
                return;

            var diseaseOutcome1 = new DiseaseOutcomeType {Name = "Выздоровление полное и неполное"};
            var diseaseOutcomet2 = new DiseaseOutcomeType {Name = "Переход в хроническую форму"};
            var diseaseOutcome3 = new DiseaseOutcomeType {Name = "Смерть"};

            _context.DiseaseOutcomeTypes.AddRange(new DiseaseOutcomeType[]
                {diseaseOutcome1, diseaseOutcomet2, diseaseOutcome3});
            _context.SaveChanges();
        }

        private void InitPositionType()
        {
            if(_context.PositionTypes.Any())
                return;

            var positionType = new PositionType
            {
                Name = "Хирург"
            };

            _context.PositionTypes.Add(positionType);

            _context.SaveChanges();
        }

        private void InitProvideService()
        {
            if(_context.ProvideServices.Any())
                return;

            var positionType = _context.PositionTypes.First();

            var service = _context.ServiceTypes.Last();

            var provideService = new ProvideService
            {
                Position = positionType,
                PositionId = positionType.Id,
                Service = service,
                ServiceId = service.Id
            };
        }

        private async Task InitUsers()
        {
            if (_context.Users.Any())
            {
                return;
            }

            var passportIssuePlaceType = _context.PassportIssuePlaceTypes.ToList()[0];

            var person = new Person
            {
                BirthDate = DateTime.Now,
                FirstName = "Test",
                LastName = "Test",
                Gender = MedicalExamination.Entities.Gender.Female,
                INN = "32228",
                MiddleName = "test",
                PassportIssueDate = DateTime.Now,
                PassportIssuePlaceId = passportIssuePlaceType.Id,
                PassportNumber = "436463",
                PassportSeries = "543534",
                SNILS = "54353453453"
            };

            var createdPerson = _context.Persons.Add(person);
            _context.SaveChanges();

            var worker = new Worker
            {
                PersonId = createdPerson.Entity.Id
            };

            var createdWorker = _context.Workers.Add(worker);
            _context.SaveChanges();

            var position = new Position
                { PositionId = new Guid("361A9CE3-F531-4D9B-9B95-08D6A4A5A29B"), WorkerId = worker.PersonId };

            _context.Positions.Add(position);
            _context.SaveChanges();

            var testUser = new ApplicationUser
            {
                UserName = "Test",
                Password = "TestTest1,",
                WorkerId = worker.PersonId,
                Worker = worker
            };

            var createTestUser = await _userManager.CreateAsync(testUser, testUser.Password);
            if (createTestUser.Succeeded)
            {
                await _userManager.AddToRoleAsync(testUser, "Test");
            }

            _context.SaveChanges();
        }

        private void InitPatients()
        {
            if (_context.Patients.Any())
            {
                return;
            }

            var testPassportIssuePlaceType = _context.PassportIssuePlaceTypes.FirstOrDefault();
            var testInsuranceCompanyType = _context.InsuranceCompanyTypes.FirstOrDefault();

            var testPerson1 = new Person
            {
                FirstName = "TestPerson1",
                LastName = "TestPerson1",
                BirthDate = DateTime.Now.AddYears(-18),
                Gender = MedicalExamination.Entities.Gender.Male,
                SNILS = "684586485648",
                MiddleName = "test",
                PassportIssuePlaceId = testPassportIssuePlaceType.Id,
                PassportIssuePlace = testPassportIssuePlaceType
            };

            var createdTestPerson = _context.Persons.Add(testPerson1);
            _context.SaveChanges();

            var testPatient1 = new Patient
            {
                PersonId = createdTestPerson.Entity.Id,
                Person = createdTestPerson.Entity,
                InsuranceNumber = "846456854",
                InsuranceCompanyId = testInsuranceCompanyType.Id,
                InsuranceCompany = testInsuranceCompanyType
            };

            _context.Patients.Add(testPatient1);
            _context.SaveChanges();

            var testPerson2 = new Person
            {
                FirstName = "TestPerson2",
                LastName = "TestPerson2",
                BirthDate = DateTime.Now.AddYears(-19),
                Gender = MedicalExamination.Entities.Gender.Female,
                SNILS = "228",
                MiddleName = "test2",
                PassportIssuePlaceId = testPassportIssuePlaceType.Id,
                PassportIssuePlace = testPassportIssuePlaceType
            };

            var createdTestPerson2 = _context.Persons.Add(testPerson2);
            _context.SaveChanges();

            var testPatient2 = new Patient
            {
                PersonId = createdTestPerson2.Entity.Id,
                Person = createdTestPerson2.Entity,
                InsuranceNumber = "95394593",
                InsuranceCompanyId = testInsuranceCompanyType.Id,
                InsuranceCompany = testInsuranceCompanyType
            };

            _context.Patients.Add(testPatient2);

            _context.SaveChanges();
        }

        private async Task InitRoles()
        {
            if (_context.Roles.Any())
            {
                return;
            }

            var testRole = new ApplicationRole
            {
                Name = "Test",
                NormalizedName = "TEST",
            };

            var createTestRole =  await _roleManager.CreateAsync(testRole);

            _context.SaveChanges();
        }

        private void InitPassportIssuePlaceType()
        {
            if (_context.PassportIssuePlaceTypes.Any())
            {
                return;
            }

            var passportIssuePlaces = new List<PassportIssuePlaceType>()
            {
                new PassportIssuePlaceType
                {
                    Name = "Отделом УМФС по Республике Татарстан г. Казани Советского района"
                },
                new PassportIssuePlaceType
                {
                    Name = "Отделом УМФС по Республике Татарстан г. Казани Приволжского района"
                },
                new PassportIssuePlaceType
                {
                    Name = "Отделом УМФС по Республике Татарстан г. Казани Авиастроительного района"
                },
                new PassportIssuePlaceType
                {
                    Name = "Отделом УМФС по Республике Татарстан г. Казани Вахитовского района"
                },
                new PassportIssuePlaceType
                {
                    Name = "Отделом УМФС по Республике Татарстан г. Казани Московского района"
                },
                new PassportIssuePlaceType
                {
                    Name = "Отделом УМФС по Республике Татарстан г. Казани Ново-Савиноского района"
                }
            };

            _context.PassportIssuePlaceTypes.AddRange(passportIssuePlaces);

            _context.SaveChanges();
        }

        private void InitInsuranceCompanyType()
        {
            if (_context.InsuranceCompanyTypes.Any())
            {
                return;
            }

            var insuranceCompanies = new List<InsuranceCompanyType>
            {
                new InsuranceCompanyType
                {
                    Name = "Ак Барс"
                },
                new InsuranceCompanyType
                {
                    Name = "Альфа Страхование"
                },
                new InsuranceCompanyType
                {
                    Name = "Спасение"
                }
            };

            _context.InsuranceCompanyTypes.AddRange(insuranceCompanies);
            _context.SaveChanges();
        }

        private void InitServiceType()
        {
            if(_context.ServiceTypes.Any())
                return;

            var textReader = new TextReader();
            string mkbCodes = textReader.Read(@"\Resources\mkb-codes.txt");

            var serviceTypes = mkbCodes.Split('\n').Where(l => !string.IsNullOrEmpty(l.Split(',')[2]))
                .Select(l => new ServiceType
                    {Code = l.Split(',')[2].Replace("\"", ""), Name = l.Split(',')[3].Replace("\"","") });

            _context.ServiceTypes.AddRange(serviceTypes);
            _context.SaveChanges();
        }
    }
}

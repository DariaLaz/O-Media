using OMedia.Core.Models.Competition;
using OMedia.Core.Services;
using OMedia.Infrastructure.Data;
using OMedia.Infrastructure.Data.Common;
using OMedia.UnitTests.Mocks;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OMedia.UnitTests.TestUserArea
{
    public class CompetitionServiceTests
    {
        [Fact]
        public async Task AllSuccessfully()
        {
            //Arrange
            var repo = new Repository(DBMock.Instance);
            var service = new CompetitionService(repo);

            //Act
            var a = await service.Create(new AddCompetitionViewModel()
            {
                AgeGroups = new List<CompetitionAgeGroupModel>(),
                AgeGroupString = new List<string>(),
                Date = "11/11/2022",
                AgeGroupsCheckBoxes = new List<Core.Models.CheckBoxOptions>(),
                Details = "",
                Location = "",
                Name = ""
            }, 1);
            var b = await service.Create(new AddCompetitionViewModel()
            {
                AgeGroups = new List<CompetitionAgeGroupModel>(),
                AgeGroupString = new List<string>(),
                Date = "11/11/2022",
                AgeGroupsCheckBoxes = new List<Core.Models.CheckBoxOptions>(),
                Details = "",
                Location = "",
                Name = ""
            }, 1);
            var result = await service.GetAll();

            //Assert
            Assert.True(result.TotalCompetitionsCount == 2);
            Assert.True(await service.Exists(a));
            Assert.True(await service.Exists(b));
        }
        [Fact]
        public async Task GetAllAgeGroupsSuccessfully()
        {
            //Arrange
            var repo = new Repository(DBMock.Instance);
            var service = new AgeGroupService(repo);

            //Act
            var a = await service.Create(new Core.Models.AgeGroup.AgeGroupViewModel()
            {
                Age = 12,
                Gender = Infrastructure.Enums.Gender.Male,
                Id = 1
            });
            var b = await service.Create(new Core.Models.AgeGroup.AgeGroupViewModel()
            {
                Age = 21,
                Gender = Infrastructure.Enums.Gender.Male,
                Id = 2
            });
            var result = await service.All();

            //Assert
            Assert.True(result.Count() == 2);
        }
        [Fact]
        public async Task GetAllTeamsSuccessfully()
        {
            //Arrange
            var repo = new Repository(DBMock.Instance);
            var service = new TeamService(repo);

            //Act
            await service.Create(new Core.Models.Team.AddTeamModel()
            {
                Details = "",
                Name = ""
            });
            await service.Create(new Core.Models.Team.AddTeamModel()
            {
                Details = "",
                Name = ""
            });
            var result = await service.GetAllTeams();

            //Assert
            Assert.True(result.Count() == 2);
        }
        [Fact]
        public async Task GetCompetitionIdWithValidId()
        {
            //Arrange
            var repo = new Repository(DBMock.Instance);
            var service = new CompetitionService(repo);

            //Act
            await service.Create(new AddCompetitionViewModel()
            {
                AgeGroups = new List<CompetitionAgeGroupModel>(),
                AgeGroupString = new List<string>(),
                Date = "11/11/2022",
                AgeGroupsCheckBoxes = new List<Core.Models.CheckBoxOptions>(),
                Details = "",
                Location = "",
                Name = ""
            }, 1);

            var result = await service.GetCompetitionById(1);

            //Assert
            Assert.True(result != null);
        }
        [Fact]
        public async Task GetCompetitionIdWithInvalidId()
        {
            //Arrange
            var repo = new Repository(DBMock.Instance);
            var service = new CompetitionService(repo);

            //Act
            var result = await service.GetCompetitionById(1);

            //Assert
            Assert.True(result == null);
        }
        [Fact]
        public async Task CreateWithValidArguments()
        {
            //Arrange
            var repo = new Repository(DBMock.Instance);
            var service = new CompetitionService(repo);

            //Act
            await service.Create(new AddCompetitionViewModel()
            {
                AgeGroups = new List<CompetitionAgeGroupModel>(),
                AgeGroupString = new List<string>(),
                Date = "11/11/2022",
                AgeGroupsCheckBoxes = new List<Core.Models.CheckBoxOptions>(),
                Details = "",
                Location = "",
                Name = ""
            }, 1);
            var result = await service.GetAll();

            //Assert
            Assert.True(result.TotalCompetitionsCount == 1);
        }

        [Fact]
        public async Task EditWithValidArguments()
        {
            //Arrange
            var repo = new Repository(DBMock.Instance);
            var service = new CompetitionService(repo);

            //Act
            await service.Create(new AddCompetitionViewModel()
            {
                AgeGroups = new List<CompetitionAgeGroupModel>(),
                AgeGroupString = new List<string>(),
                Date = "11/11/2022",
                AgeGroupsCheckBoxes = new List<Core.Models.CheckBoxOptions>(),
                Details = "",
                Location = "",
                Name = ""
            }, 1);
            var edited = new AddCompetitionViewModel()
            {
                AgeGroups = new List<CompetitionAgeGroupModel>(),
                AgeGroupString = new List<string>(),
                Date = "11/11/2022",
                AgeGroupsCheckBoxes = new List<Core.Models.CheckBoxOptions>(),
                Details = "",
                Location = "",
                Name = "Mew"
            };
             await service.Edit(1, edited);
            var result = await repo.GetByIdAsync<Competition>(1);

            //Assert
            Assert.True(result.Name == "Mew");
        }
       
        [Fact]
        public async Task ExistsShouldReturnTrueWhenCompetitionIdIsValid()
        {
            //Arrange
            var repo = new Repository(DBMock.Instance);
            var service = new CompetitionService(repo);

            //Act
            await service.Create(new AddCompetitionViewModel()
            {
                AgeGroups = new List<CompetitionAgeGroupModel>(),
                AgeGroupString = new List<string>(),
                Date = "11/11/2022",
                AgeGroupsCheckBoxes = new List<Core.Models.CheckBoxOptions>(),
                Details = "",
                Location = "",
                Name = ""
            }, 1);

            await repo.SaveChangesAsync();

            var result = await service.Exists(1);

            //Assert
            Assert.True(result);
        }
        [Fact]
        public async Task ExistsShouldReturnFalseWhenCompetitionIdIsNotValid()
        {
            //Arrange
            var repo = new Repository(DBMock.Instance);
            var service = new CompetitionService(repo);

            //Act
            var result = await service.Exists(1);

            //Assert
            Assert.False(result);
        }
        
        [Fact]
        public async Task DeleteWithValidId()
        {
            //Arrange
            var repo = new Repository(DBMock.Instance);
            var service = new CompetitionService(repo);

            //Act
           var comp =  await service.Create(new AddCompetitionViewModel()
            {
                AgeGroups = new List<CompetitionAgeGroupModel>(),
                AgeGroupString = new List<string>(),
                Date = "11/11/2022",
                AgeGroupsCheckBoxes = new List<Core.Models.CheckBoxOptions>(),
                Details = "",
                Location = "",
                Name = ""
            }, 1);
            await service.Create(new AddCompetitionViewModel()
            {
                AgeGroups = new List<CompetitionAgeGroupModel>(),
                AgeGroupString = new List<string>(),
                Date = "11/11/2022",
                AgeGroupsCheckBoxes = new List<Core.Models.CheckBoxOptions>(),
                Details = "",
                Location = "",
                Name = ""
            }, 1);
            await service.Delete(comp);

            var result = await service.GetAll();

            //Assert
            Assert.True(result.TotalCompetitionsCount == 1);
        }


        [Fact]
        public async Task TakePartSuccessfully()
        {
            //Arrange
            var repo = new Repository(DBMock.Instance);
            var competitionService = new CompetitionService(repo);
            var competitorService = new CompetitorService(repo);

            //Act

            await competitionService.Create(new AddCompetitionViewModel()
            {
                AgeGroups = new List<CompetitionAgeGroupModel>(),
                AgeGroupString = new List<string>(),
                Date = "11/11/2022",
                AgeGroupsCheckBoxes = new List<Core.Models.CheckBoxOptions>(),
                Details = "",
                Location = "",
                Name = ""
            }, 2);

            await competitorService.Create("userId", "name", 1, 1);

            competitionService.TakePart(1, 1);
            var competitor = await repo.GetByIdAsync<Competitor>(1);
            var competition = await repo.GetByIdAsync<Competition>(1);


            //Assert
            Assert.True(competition.Competitors.Select(x => x.CompetitorId).Any(x => x == 1));
            Assert.True(competitor.Competitions.Select(x => x.CompetitionId).Any(x => x == 1));
        }
        [Fact]
        public async Task CancelSuccessfully()
        {
            // Arrange
            var repo = new Repository(DBMock.Instance);
            var competitionService = new CompetitionService(repo);
            var competitorService = new CompetitorService(repo);


            //Act

            await competitionService.Create(new AddCompetitionViewModel()
            {
                AgeGroups = new List<CompetitionAgeGroupModel>(),
                AgeGroupString = new List<string>(),
                Date = "11/11/2022",
                AgeGroupsCheckBoxes = new List<Core.Models.CheckBoxOptions>(),
                Details = "",
                Location = "",
                Name = ""
            }, 2);

            await competitorService.Create("userId", "name", 1, 1);

            competitionService.TakePart(1, 1);
            
            competitionService.Cancel(1, 1);

            var competition = await competitionService.GetCompetitionById(1);


            //Assert
            Assert.False(competition.Competitors.Select(x => x.CompetitorId).Any(x => x == 1));
        }
    }
}

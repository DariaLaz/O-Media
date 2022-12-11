using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using OMedia.Core.Contracts;
using OMedia.Core.Models.Competition;
using OMedia.Core.Models.User;
using OMedia.Infrastructure.Data;
using OMedia.Infrastructure.Data.Common;

namespace OMedia.Core.Services
{
    public class UserService : IUserService
    {
        private readonly IRepository repo;
        private readonly UserManager<IdentityUser> userManager;
        public UserService(IRepository _repo,
            UserManager<IdentityUser> _userManager)
        {
            repo = _repo;
            userManager = _userManager;
        }


        public async Task<bool> isCompetitorById(string userId)
        {
            return await repo.All<Competitor>()
                .AnyAsync(a => a.UserId == userId);
        }

        public async Task<int> GetCompetitorId(string userId)
        {
            return (await repo.AllReadonly<Competitor>()
               .FirstOrDefaultAsync(a => a.UserId == userId))?.Id ?? 0;
        }

        public async Task Create(string userId, string name, int teamId, int ageGroupId)
        {
            var competitor = new Competitor()
            {
                UserId = userId,
                Name = name,
                TeamId = teamId,
                AgeGroupId = ageGroupId
            };
            await repo.AddAsync(competitor);
            await repo.SaveChangesAsync();
        }

        public async Task<ProfileViewModel> GetCompetitor(int id)
        {
            var competitior = (await repo.AllReadonly<Competitor>()
                .Include(x => x.Team)
                .Include(x => x.Competitions)
                .ThenInclude(x => x.Competition)
                .FirstOrDefaultAsync(a => a.Id == id));
            var competitions = competitior.Competitions
                .Where(x => x.Role != "Organizer" && x.Competitor.Id == id)
                .Select(c => new CompetitionViewModel()
                {
                    Id = c.CompetitionId,
                    Name = c.Competition.Name,
                    Location = c.Competition.Location,
                    Date = c.Competition.Date.ToString("dd-MM-yyyy"),
                    AgeGroups = c.Competition.AgeGroups.Select(g => new CompetitionAgeGroupModel
                    {
                        Id = g.AgeGroupId
                    })
                }).ToList();
            var competitionsOrganized = competitior.Competitions
                .Where(x => x.Role == "Organizer" && x.Competitor.Id == id)
                .Select(c => new CompetitionViewModel()
                {
                    Id = c.CompetitionId,
                    Name = c.Competition.Name,
                    Location = c.Competition.Location,
                    Date = c.Competition.Date.ToString("dd-MM-yyyy"),
                    AgeGroups = c.Competition.AgeGroups.Select(g => new CompetitionAgeGroupModel
                    {
                        Id = g.AgeGroupId
                    })
                }).ToList();
            return new ProfileViewModel()
            {
                Name = competitior.Name,
                TeamId = competitior.TeamId,
                TeamName = competitior.Team.Name,
                Competitions = competitions,
                CompetitionsOrganized = competitionsOrganized
            };
        }

        public async Task<IEnumerable<UserViewModel>> All()
        {
            var all = await repo.AllReadonly<Competitor>()
                .Include(c => c.User)
                .Where(c => c.IsActive)
                .Select(c => new UserViewModel()
                {
                    UserId =c.UserId,
                    Email = c.User.Email,
                    Name = c.Name
                })
                .ToListAsync();
            foreach (var user in all)
            {
                var u = await repo.AllReadonly<Competitor>()
                    .Include(x => x.User)
                    .FirstAsync(x => x.UserId == user.UserId);
                user.IsAdministrator = await userManager.IsInRoleAsync(u.User, "Administrator");
            }
            return all;
        }

        

        public Task<bool> Forget(string userId)
        {
            throw new NotImplementedException();
        }

        public async Task<IdentityUser> GetUser(string id)
        {
            var user = await repo.AllReadonly<Competitor>()
                .Include(x => x.User)
                .FirstAsync(x => x.UserId == id);
            return user.User;
        }
        public async Task<bool> AddAdmin(IdentityUser user)
        {
            var roles = new List<string>();
            roles.Add("Administrator");
            await userManager.AddToRolesAsync(user, roles);
            var result = await userManager.UpdateAsync(user);

            return result.Succeeded;
        }
        public async Task<bool> RemoveAdmin(IdentityUser user)
        {
            var userRoles = await userManager.GetRolesAsync(user);

            await userManager.RemoveFromRolesAsync(user, userRoles);
            var result = await userManager.UpdateAsync(user);

            return result.Succeeded;

        }
    }
}

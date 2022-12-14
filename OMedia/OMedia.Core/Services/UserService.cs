using Microsoft.AspNetCore.Hosting;
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
        public IWebHostEnvironment webHostEnviroment;
        public UserService(IRepository _repo,
            UserManager<IdentityUser> _userManager,
            IWebHostEnvironment _webHostEnviroment)
        {
            repo = _repo;
            userManager = _userManager;
            webHostEnviroment = _webHostEnviroment;
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
        public async Task<ProfileViewModel> GetCompetitor(int id)
        {
            var competitior = (await repo.AllReadonly<Competitor>()
                .Include(x => x.User)
                .Include(x => x.Team)
                .Include(x => x.Competitions)
                .ThenInclude(x => x.Competition)
                .FirstOrDefaultAsync(a => a.Id == id && a.IsActive));
            if (competitior == null)
            {
                return new ProfileViewModel()
                {
                    IsActive = false
                };
            }
            var competitions = competitior.Competitions
                .Where(x => x.Role != "Organizer" && x.Competitor.Id == id && x.IsActive && x.Competition.IsActive)
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
                .Where(x => x.Role == "Organizer" && x.Competitor.Id == id && x.IsActive && x.Competition.IsActive)
                .Select(c => new CompetitionViewModel()
                {
                    Id = c.CompetitionId,
                    Name = c.Competition.Name,
                    Location = c.Competition.Location,
                    Date = c.Competition.Date.ToString("dd-MM-yyyy"),
                    AgeGroups = c.Competition.AgeGroups.Select(g => new CompetitionAgeGroupModel
                    {
                        Id = g.AgeGroupId
                    }),
                }).ToList();
            return new ProfileViewModel()
            {
                Id = competitior.Id,
                Name = competitior.Name,
                TeamId = competitior.TeamId,
                TeamName = competitior.Team.Name,
                Competitions = competitions,
                CompetitionsOrganized = competitionsOrganized,
                Email = competitior.User.Email,
                IsActive = true,
            };
        }
        public async Task<IEnumerable<UserViewModel>> All()
        {
            var all = await repo.AllReadonly<Competitor>()
                .Include(c => c.User)
                .Where(c => c.IsActive && c.User.Email != null)
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
        public async Task<bool> Forget(IdentityUser user)
        {
           
            user.NormalizedUserName = null;
            user.Email = null;
            user.NormalizedEmail = null;
            user.PasswordHash = null;
            user.UserName = $"forgottenUser-{DateTime.Now.Ticks}";
            var result = await userManager.UpdateAsync(user);
            if (result.Succeeded)
            {
                var competitor = (await repo.All<Competitor>()
                    .FirstOrDefaultAsync(a => a.UserId == user.Id));
                competitor.IsActive = false;
                competitor.Name = "Deleted_User-{DateTime.Now.Ticks}";
                await repo.SaveChangesAsync();
            }
            return result.Succeeded;
        }
        public async Task<IdentityUser> GetUser(string id)
        {
            var user = await repo.AllReadonly<Competitor>()
                .Include(x => x.User)
                .FirstAsync(x => x.UserId == id);
            return user.User;
        }
        public async Task<bool> AddAdmin(string id)
        {
            var user = await repo.All<Competitor>()
                .Include(x => x.User)
                .Select(x => x.User)
                .FirstAsync(x => x.Id == id);

            var roles = new List<string>();
            roles.Add("Administrator");
            await userManager
                .AddToRolesAsync(user, roles);
            var result = await userManager.UpdateAsync(user);

            return result.Succeeded;
        }
        public async Task<bool> RemoveAdmin(string id)
        {
            var user = await repo.All<Competitor>()
                .Include(x => x.User)
                .Select(x => x.User)
                .FirstAsync(x => x.Id == id);
            var roles = new List<string>();
            roles.Add("Administrator");

            await userManager.RemoveFromRolesAsync(user, roles);
            var result = await userManager.UpdateAsync(user);

            return result.Succeeded;

        }
        public async Task<bool> IsTheLastAdmin()
        {
            var allCompetitiors = await repo.AllReadonly<Competitor>()
                                .Include(x => x.User)
                                .ToListAsync();
            var counter = 0;
            foreach (var c in allCompetitiors)
            {
                if (await userManager.IsInRoleAsync(c.User, "Administrator"))
                {
                    counter++;
                }
            }
            return counter == 1;
        }
        public async Task<UserViewModel> GetInfo(string id)
        {
            var competitor = await repo.AllReadonly<IdentityUser>()
                .FirstAsync(x => x.Id == id);
            var isAdmin = await userManager.IsInRoleAsync(competitor, "Administrator");

            var resulr = new UserViewModel()
            {
                UserId = competitor.Id,
                Email = competitor.Email,
                IsAdministrator = isAdmin,
                Name = competitor.UserName
            };
            if (await isCompetitorById(competitor.Id))
            {
                var comp = await GetCompetitorId(competitor.Id);
                var name = (await GetCompetitor(comp)).Name;

                resulr.Name = name;
            }
            return resulr;
        }
    }
}

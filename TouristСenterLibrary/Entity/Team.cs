using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace TouristСenterLibrary.Entity
{
    public class Team
    {
        private static ApplicationContext db = ContextManager.db;
        public int ID { get; set; }
        [Required] public string Name { get; set; }
        [Required] public User MainUser { get; set; }
        [Required] public List<Teammate> Teammates { get; set; }

        public Team()
        {
            Teammates = new List<Teammate>();
        }

        public Team(string Name, User MainUser)
        {
            this.Name = Name;
            this.MainUser = MainUser;
            Teammates = new List<Teammate>();
        }

        public bool Add()
        {
            try
            {
                db.Team.Add(this);
                db.SaveChanges();
                return true;
            }
            catch (Exception ex)
            {
                return false;
            }

        }

        public bool Update()
        {
            try
            {
                db.SaveChanges();
                return true;
            }
            catch (Exception ex)
            {
                return false;
            }

        }

        public static List<Team> GetTeams()
        {
            try
            {
                return db.Team.Include(t=>t.MainUser).Include(t=>t.Teammates).ThenInclude(t=>t.User).ToList();
            }
            catch (Exception ex)
            {
                return new List<Team>();
            }

        }

        public static Team? GetTeamsByID(int id)
        {
            try
            {
                return db.Team.Include(t => t.MainUser).Include(t => t.Teammates).ThenInclude(t => t.User).FirstOrDefault(t => t.ID == id);
            }
            catch (Exception ex)
            {
                return null;
            }

        }

        public bool AddTeammate(User user)
        {
            try
            {
                this.Teammates.Add(new Teammate(this, user));
                db.SaveChanges();
                return true;
            }
            catch(Exception ex)
            {
                return false;
            }
           
        }

        public static List<Team> GetTeamsByUserLogin(string login)
        {
            try
            {
                return db.Team.Include(t => t.MainUser).Include(t => t.Teammates).ThenInclude(t => t.User).Where(t => t.MainUser.Login == login || t.Teammates.Any(x=>x.User.Login == login && x.IsActive && x.IsTeammate)).ToList();
            }
            catch(Exception ex)
            {
                return new List<Team>();
            }
            
        }

    }
}

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
        
        public List<Team> GetTeamsByUserLogin(string login)
        {
            try
            {
                return db.Team.Where(t => t.MainUser.Login == login).ToList();
            }
            catch(Exception ex)
            {
                return new List<Team>();
            }
            
        }

    }
}

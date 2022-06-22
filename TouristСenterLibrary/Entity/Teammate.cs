using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace TouristСenterLibrary.Entity
{
    public class Teammate
    {
        private static ApplicationContext db = ContextManager.db;
        public int ID { get; set; } 
        [Required] public Team Team { get; set; }
        [Required] public User User { get; set; }
        [Required] public bool IsTeammate { get; set; }
        [Required] public bool IsActive { get; set; }

        public Teammate()
        {
        }
        public Teammate(Team Team, User User)
        {
            this.Team = Team;
            this.User = User;
            this.IsTeammate = false;
            this.IsActive = false;
        }

        public bool Add()
        {
            try
            {
                db.Teammate.Add(this);
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

        public static List<Teammate> GetTeammatesByTeam(Team team)
        {
            try
            {
                return db.Teammate.Include(t=>t.User).Where(t => t.Team == team).ToList();
            }
            catch(Exception ex)
            {
                return new List<Teammate>();
            }
           
        }

    }
}

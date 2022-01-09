using System.ComponentModel.DataAnnotations;

namespace TouristСenterLibrary.Entity
{
    public class Role
    {
        public int ID { get; set; }
        [Required] public string PositionName { get; set; }

        public Role()
        {
        }
        public Role(string PositionName)
        {
            this.PositionName = PositionName;
        }
    }
}

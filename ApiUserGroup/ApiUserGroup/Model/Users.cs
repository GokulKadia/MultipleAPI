using System.ComponentModel.DataAnnotations;

namespace ApiUserGroup.Model
{
    //created data model for Users and we can also paste directly using past special
    public class User
    {
        [Key]
        public int userid { get; set; }

        [StringLength(75)]
        public string FirstName { get; set; } = "";

        [StringLength(75)]
        public string LastName { get; set; } = "";

        [StringLength(75)]
        public string EmailId { get; set; } = "";
        [StringLength(150)]
        public string Address { get; set; } = "";

       
    }
}

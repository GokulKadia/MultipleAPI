using System.ComponentModel.DataAnnotations;

namespace ApiUserGroup.Model
{
    public class Group
    {
        [Key]
        public int groupid { get; set; }

        [StringLength(75)]
        public string GroupName { get; set; } = "";
    }
}

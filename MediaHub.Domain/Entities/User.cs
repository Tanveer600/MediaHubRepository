using MediaHub.Domain.Common;

namespace MediaHub.Domain.Entities
{
    public class User : BaseEntity
    {
        // BaseEntity se Id already mil raha hai

        public string UserName { get; set; } = null!;
        public string Email { get; set; } = null!;
        public string PasswordHash { get; set; } = null!;

        //  Foreign Key
        public long RoleId { get; set; }

        //  Navigation Property
        public Role Role { get; set; } = null!;

        public DateTime CreatedAt { get; set; } = DateTime.UtcNow;

        public ICollection<Media> MediaItems { get; set; } = new List<Media>();
    }
}

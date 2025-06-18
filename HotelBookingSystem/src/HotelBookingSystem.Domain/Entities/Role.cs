namespace HotelBookingSystem.Domain.Entities
{
    public class Role
    {
        public long RoleId { get; set; }
        public string RoleName { get; set; }
        public string Description { get; set; }
        public bool IsActive { get; set; }
        public long HotelId { get; set; }
        public Hotel Hotel { get; set; }
        public List<UserRole> UserRoles { get; set; }
    }
}

namespace Wing_Fleet_Manager.Models
{
    public class UserZone
    {
        public int Id { get; set; }
        public User User { get; set; }
        public int UserId { get; set; }
        public Zone Zone { get; set; }
        public int ZoneId { get; set; }
    }
}

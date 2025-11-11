namespace Wing_Fleet_Manager.Models
{
    public class FaultNotification
    {
        public int Id { get; set; }
        public Fault Fault { get; set; }
        public int FaultId { get; set; }
        public Notification Notification { get; set; }
        public int NotificationId { get; set; }
    }
}

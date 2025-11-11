using Microsoft.EntityFrameworkCore;
using Wing_Fleet_Manager.Models;

namespace Wing_Fleet_Manager.Data
{
    public class WingDbContext : DbContext
    {
        public WingDbContext(DbContextOptions<WingDbContext> options) : base(options) { }
        
        public DbSet<User> Users {  get; set; }
        public DbSet<UserLog> UserLogs {  get; set; }
        public DbSet<UserTask> UserTasks { get; set; }
        public DbSet<TaskLog> TaskLogs { get; set; }
        public DbSet<Zone> Zones { get; set; }
        public DbSet<UserZone> UserZones { get; set; }
        public DbSet<Role> Roles { get; set; }
        public DbSet<Vehicle> Vehicles { get; set; }
        public DbSet<VehicleLog> VehicleLogs {  get; set; }
        public DbSet<VehicleNote> VehicleNotes {  get; set; }
        public DbSet<Fault> Faults {  get; set; }
        public DbSet<FaultImg> FaultImgs {  get; set; }
        public DbSet<SparePart> SpareParts { get; set; }
        public DbSet<SparePartMovement> SparePartMovements { get; set; }
        public DbSet<Notification> Notifications { get; set; }
        public DbSet<FaultNotification> FaultNotifications { get; set; }
        public DbSet<CashRecord> CashRecords { get; set; }
        public DbSet<FileRecord> FileRecords { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<User>()
                .HasIndex(u => u.Email)
                .IsUnique();
            modelBuilder.Entity<User>()
                .HasIndex(u => u.NickName)
                .IsUnique();
            modelBuilder.Entity<User>()
                .HasIndex(u => u.Phone)
                .IsUnique();
            modelBuilder.Entity<Role>()
                .HasIndex(r => r.Name)
                .IsUnique();
            modelBuilder.Entity<Zone>()
                .HasIndex(z => z.Name)
                .IsUnique();
            modelBuilder.Entity<Vehicle>()
                .HasIndex(v => v.Qr)
                .IsUnique();
            modelBuilder.Entity<Vehicle>()
                .HasIndex(v => v.Imei)
                .IsUnique();
            modelBuilder.Entity<Vehicle>()
                .HasIndex(v => v.Mac)
                .IsUnique();
            modelBuilder.Entity<UserTask>()
                .HasIndex(ut => ut.SerialNumber)
                .IsUnique();
            modelBuilder.Entity<SparePartMovement>()
                .HasIndex(spm => spm.SerialNumber)
                .IsUnique();
            modelBuilder.Entity<SparePart>()
                .HasIndex(sp => sp.Name)
                .IsUnique();
            modelBuilder.Entity<Notification>()
                .HasIndex(n => n.SerialNumber)
                .IsUnique();
            modelBuilder.Entity<FileRecord>()
                .HasIndex(fr => fr.SerialNumber)
                .IsUnique();
            modelBuilder.Entity<Fault>()
                .HasIndex(f => f.SerialNumber)
                .IsUnique();
            modelBuilder.Entity<CashRecord>()
                .HasIndex(cr => cr.SerialNumber)
                .IsUnique();

            modelBuilder.Entity<User>()
                .HasOne(u => u.Role)
                .WithMany(r => r.Users)
                .HasForeignKey(u => u.RoleId)
                .OnDelete(DeleteBehavior.Restrict);
            modelBuilder.Entity<UserLog>()
                .HasOne(ul => ul.User)
                .WithMany(u => u.UserLogs)
                .HasForeignKey(ul => ul.UserId)
                .OnDelete(DeleteBehavior.Restrict);
            modelBuilder.Entity<UserZone>()
                .HasOne(uz => uz.User)
                .WithMany(u => u.UserZones)
                .HasForeignKey(uz => uz.UserId)
                .OnDelete(DeleteBehavior.Restrict);
            modelBuilder.Entity<UserZone>()
                .HasOne(uz => uz.Zone)
                .WithMany(z => z.UserZones)
                .HasForeignKey(uz => uz.ZoneId)
                .OnDelete(DeleteBehavior.Restrict);
            modelBuilder.Entity<Vehicle>()
                .HasOne(v => v.Zone)
                .WithMany(z => z.Vehicles)
                .HasForeignKey(v => v.ZoneId)
                .OnDelete(DeleteBehavior.Restrict);
            modelBuilder.Entity<VehicleLog>()
                .HasOne(vl => vl.Vehicle)
                .WithMany(v => v.VehicleLogs)
                .HasForeignKey(vl => vl.VehicleId)
                .OnDelete(DeleteBehavior.Restrict);
            modelBuilder.Entity<VehicleNote>()
                .HasOne(vn => vn.Vehicle)
                .WithMany(v => v.VehicleNotes)
                .HasForeignKey(vn => vn.VehicleId)
                .OnDelete(DeleteBehavior.Restrict);
            modelBuilder.Entity<Fault>()
                .HasOne(f => f.Vehicle)
                .WithMany(v => v.Faults)
                .HasForeignKey(f => f.VehicleId)
                .OnDelete(DeleteBehavior.Restrict);
            modelBuilder.Entity<Fault>()
                .HasOne(f => f.Zone)
                .WithMany(z => z.Faults)
                .HasForeignKey(f => f.ZoneId)
                .OnDelete(DeleteBehavior.Restrict);
            modelBuilder.Entity<Fault>()
                .HasOne(f => f.CreatedBy)
                .WithMany(cr => cr.FaultsCreated)
                .HasForeignKey(f => f.CreatedById)
                .OnDelete(DeleteBehavior.Restrict);
            modelBuilder.Entity<Fault>()
                .HasOne(f => f.ClosedBy)
                .WithMany(cl => cl.FaultsClosed)
                .HasForeignKey(f => f.ClosedById)
                .OnDelete(DeleteBehavior.Restrict);
            modelBuilder.Entity<FaultImg>()
                .HasOne(fi => fi.Fault)
                .WithMany(f => f.FaultImgs)
                .HasForeignKey(fi => fi.FaultId)
                .OnDelete(DeleteBehavior.Restrict);
            modelBuilder.Entity<FaultNotification>()
                .HasOne(fn => fn.Fault)
                .WithMany(f => f.FaultNotifications)
                .HasForeignKey(fn => fn.FaultId)
                .OnDelete(DeleteBehavior.Restrict);
            modelBuilder.Entity<FaultNotification>()
                .HasOne(fn => fn.Notification)
                .WithMany(n => n.FaultNotifications)
                .HasForeignKey(fn => fn.NotificationId)
                .OnDelete(DeleteBehavior.Restrict);
            modelBuilder.Entity<Notification>()
                .HasOne(n => n.CreatedBy)
                .WithMany(cb => cb.SentNotifications)
                .HasForeignKey(n => n.CreatedById)
                .OnDelete(DeleteBehavior.Restrict);
            modelBuilder.Entity<Notification>()
                .HasOne(n => n.CreatedTo)
                .WithMany(ct => ct.ReceivedNotifications)
                .HasForeignKey(n => n.CreatedToId)
                .OnDelete(DeleteBehavior.Restrict);
            modelBuilder.Entity<SparePartMovement>()
                .HasOne(spm => spm.SparePart)
                .WithMany(sp => sp.SparePartMovements)
                .HasForeignKey(spm => spm.SparePartId)
                .OnDelete(DeleteBehavior.Restrict);
            modelBuilder.Entity<SparePartMovement>()
                .HasOne(spm => spm.CreatedBy)
                .WithMany(cbm => cbm.SparePartMovements)
                .HasForeignKey(spm => spm.CreatedById)
                .OnDelete(DeleteBehavior.Restrict);
            modelBuilder.Entity<SparePartMovement>()
                .HasOne(spm => spm.Zone)
                .WithMany(z => z.SparePartMovements)
                .HasForeignKey(spm => spm.ZoneId)
                .OnDelete(DeleteBehavior.Restrict);
            modelBuilder.Entity<CashRecord>()
                .HasOne(cr => cr.User)
                .WithMany(u => u.CashRecords)
                .HasForeignKey(cr => cr.UserId)
                .OnDelete(DeleteBehavior.Restrict);
            modelBuilder.Entity<CashRecord>()
                .HasOne(cr => cr.Zone)
                .WithMany(z => z.CashRecords)
                .HasForeignKey(cr => cr.ZoneId)
                .OnDelete(DeleteBehavior.Restrict);
            modelBuilder.Entity<UserTask>()
                .HasOne(ut => ut.CreatedBy)
                .WithMany(cbt => cbt.CreatedTasks)
                .HasForeignKey(ut => ut.CreatedById)
                .OnDelete(DeleteBehavior.Restrict);
            modelBuilder.Entity<UserTask>()
                .HasOne(ut => ut.AssignedTo)
                .WithMany(att => att.AssignedTasks)
                .HasForeignKey(ut => ut.AssignedToId)
                .OnDelete(DeleteBehavior.Restrict);
            modelBuilder.Entity<UserTask>()
                .HasOne(ut => ut.Vehicle)
                .WithMany(v => v.Tasks)
                .HasForeignKey(ut => ut.VehicleId)
                .OnDelete(DeleteBehavior.Restrict);
            modelBuilder.Entity<TaskLog>()
                .HasOne(tl => tl.UserTask)
                .WithMany(ut => ut.TaskLogs)
                .HasForeignKey(tl => tl.UserTaskId)
                .OnDelete(DeleteBehavior.Restrict);
            modelBuilder.Entity<TaskLog>()
                .HasOne(tl => tl.User)
                .WithMany(u => u.TaskLogs)
                .HasForeignKey(tl => tl.UserId)
                .OnDelete(DeleteBehavior.Restrict);
        }
    }
}

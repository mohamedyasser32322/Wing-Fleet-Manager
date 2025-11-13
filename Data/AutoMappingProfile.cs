using AutoMapper;
using Wing_Fleet_Manager.Models;
using Wing_Fleet_Manager.Dtos;
using Wing_Fleet_Manager.Dtos.User;
using Wing_Fleet_Manager.Helpers;
using Microsoft.Identity.Client.Extensibility;
using Wing_Fleet_Manager.Dtos.Zone;
using Wing_Fleet_Manager.Dtos.Vehicle;
using Wing_Fleet_Manager.Dtos.Fault;
using Wing_Fleet_Manager.Dtos.SparePart;
using Wing_Fleet_Manager.Dtos.SparePartMovement;
using Wing_Fleet_Manager.Dtos.UserTask;
using Wing_Fleet_Manager.Dtos.CashRecord;
using Wing_Fleet_Manager.Dtos.FileRecord;
using Wing_Fleet_Manager.Dtos.Notification;
using Wing_Fleet_Manager.Dtos.VehicleNote;
using Wing_Fleet_Manager.Dtos.FaultImg;
using Wing_Fleet_Manager.Dtos.ReadOnly;

namespace Wing_Fleet_Manager.Data
{
    public class AutoMappingProfile : Profile
    {
        public AutoMappingProfile()
        {
            // User
            CreateMap<User, UserReadDto>()
                .ForMember(dest => dest.RoleName, options => options.MapFrom(src => src.Role.Name));
            CreateMap<UserCreateDto, User>()
                .ForMember(dest => dest.HashPassword, opt => opt.MapFrom(src => PasswordHelper.PasswordHasher(src.Password)));
            CreateMap<UserUpdateDto, User>()
                .ForMember(dest => dest.HashPassword, opt => opt.Ignore())
                .ForMember(dest => dest.FullName, opt => opt.Condition(src => !string.IsNullOrEmpty(src.FullName)))
                .ForMember(dest => dest.NickName, opt => opt.Condition(src => !string.IsNullOrEmpty(src.NickName)))
                .ForMember(dest => dest.Phone, opt => opt.Condition(src => !string.IsNullOrEmpty(src.Phone)))
                .ForMember(dest => dest.ImageUrl, opt => opt.Condition(src => !string.IsNullOrEmpty(src.ImageUrl)));
            
            // Zone
            CreateMap<Zone, ZoneReadDto>();
            CreateMap<ZoneCreateDto, Zone>();
            CreateMap<ZoneUpdateDto, Zone>()
                .ForMember(dest => dest.Name, opt => opt.Condition(src => !string.IsNullOrEmpty(src.Name)))
                .ForMember(dest => dest.City, opt => opt.Condition(src => !string.IsNullOrEmpty(src.City)))
                .ForMember(dest => dest.SpareBatteries, opt => opt.Condition(src => src.SpareBatteries.HasValue));

            // User >> Zone
            CreateMap<UserZone, UserZoneReadDto>();

            // Vehicle
            CreateMap<Vehicle, VehicleReadDto>();
            CreateMap<VehicleCreateDto,Vehicle>();
            CreateMap<VehicleUpdateDto, Vehicle>()
                .ForMember(dest => dest.Qr, opt => opt.Condition(src => !string.IsNullOrEmpty(src.Qr)))
                .ForMember(dest => dest.Type, opt => opt.Condition(src => src.Type.HasValue))
                .ForMember(dest => dest.Company, opt => opt.Condition(src => src.Company.HasValue))
                .ForMember(dest => dest.Imei, opt => opt.Condition(src => !string.IsNullOrEmpty(src.Imei)))
                .ForMember(dest => dest.Mac, opt => opt.Condition(src => !string.IsNullOrEmpty(src.Mac)))
                .ForMember(dest => dest.IsActive, opt => opt.Condition(src => src.IsActive.HasValue))
                .ForMember(dest => dest.Status, opt => opt.Condition(src => src.Status.HasValue));

            // Fault
            CreateMap<Fault, FaultReadDto>();
            CreateMap<FaultCreateDto,Fault>();
            CreateMap<FaultUpdateDto, Fault>()
                .ForMember(dest => dest.Title, opt => opt.Condition(src => !string.IsNullOrEmpty(src.Title)))
                .ForMember(dest => dest.Description, opt => opt.Condition(src => !string.IsNullOrEmpty(src.Description)))
                .ForMember(dest => dest.Type, opt => opt.Condition(src => src.Type.HasValue))
                .ForMember(dest => dest.Priority, opt => opt.Condition(src => src.Priority.HasValue));

            // Fault Img
            CreateMap<FaultImg, FaultImgReadDto>();
            CreateMap<FaultImgCreateDto, FaultImg>();

            // Fault >> Notification
            CreateMap<FaultNotification, FaultNotificationReadDto>();

            // Sparepart
            CreateMap<SparePart, SparePartReadDto>();
            CreateMap<SparePartCreateDto, SparePart>();
            CreateMap<SparePartUpdateDto, SparePart>()
                .ForMember(dest => dest.Name, opt => opt.Condition(src => !string.IsNullOrEmpty(src.Name)))
                .ForMember(dest => dest.Description, opt => opt.Condition(src => !string.IsNullOrEmpty(src.Description)))
                .ForMember(dest => dest.Type, opt => opt.Condition(src => src.Type.HasValue))
                .ForMember(dest => dest.Quantity, opt => opt.Condition(src => src.Quantity.HasValue));

            // Sparepart Movement
            CreateMap<SparePartMovement, SparePartMovementReadDto>();
            CreateMap<SparePartMovementCreateDto, SparePartMovement>();

            // User Task
            CreateMap<UserTask, UserTaskReadDto>();
            CreateMap<UserTaskCreateDto, UserTask>();
            CreateMap<UserTaskUpdateDto, UserTask>()
                .ForMember(dest => dest.SerialNumber, opt => opt.Condition(src => src.SerialNumber.HasValue))
                .ForMember(dest => dest.Title, opt => opt.Condition(src => !string.IsNullOrEmpty(src.Title)))
                .ForMember(dest => dest.Description, opt => opt.Condition(src => !string.IsNullOrEmpty(src.Description)))
                .ForMember(dest => dest.IsCompleted, opt => opt.Condition(src => src.IsCompleted.HasValue));

            // Cash Record
            CreateMap<CashRecord, CashRecordReadDto>();
            CreateMap<CashRecordCreateDto, CashRecord>();
            CreateMap<CashRecordUpdateDto, CashRecord>()
                .ForMember(dest => dest.SerialNumber, opt => opt.Condition(src => src.SerialNumber.HasValue))
                .ForMember(dest => dest.Amount, opt => opt.Condition(src => src.Amount.HasValue))
                .ForMember(dest => dest.OperationType, opt => opt.Condition(src => src.OperationType.HasValue));

            // File Record
            CreateMap<FileRecord, FileRecordReadDto>();
            CreateMap<FileRecordCreateDto, FileRecord>();
            CreateMap<FileRecordUpdateDto, FileRecord>()
                .ForMember(dest => dest.SerialNumber, opt => opt.Condition(src => src.SerialNumber.HasValue))
                .ForMember(dest => dest.Name, opt => opt.Condition(src => !string.IsNullOrEmpty(src.Name)))
                .ForMember(dest => dest.Description, opt => opt.Condition(src => !string.IsNullOrEmpty(src.Description)))
                .ForMember(dest => dest.FilePath, opt => opt.Condition(src => !string.IsNullOrEmpty(src.FilePath)));

            // Notification
            CreateMap<Notification, NotificationReadDto>();
            CreateMap<NotificationCreateDto,Notification>();

            // Vehicle Note
            CreateMap<VehicleNote, VehicleNoteReadDto>();
            CreateMap<VehicleNoteCreateDto, VehicleNote>();
            CreateMap<VehicleNoteUpdateDto, VehicleNote>()
                .ForMember(dest => dest.Title, opt => opt.Condition(src => !string.IsNullOrEmpty(src.Title)))
                .ForMember(dest => dest.Description, opt => opt.Condition(src => !string.IsNullOrEmpty(src.Description)));

            // User Log
            CreateMap<UserLog, UserLogReadDto>();

            // Vehicle Log
            CreateMap<VehicleLog, VehicleLogReadDto>();

            // Task Log
            CreateMap<TaskLog, TaskLogReadDto>();
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace StamingRobot.Repository.Enum
{
    [JsonConverter(typeof(JsonStringEnumConverter))]
    public enum StampingJobStatus
    {
        [EnumMember(Value = "Pending")]
        Pending, // Chờ xử lý

        [EnumMember(Value = "InProgress")]
        InProgress, // Đang chạy

        [EnumMember(Value = "Completed")]
        Completed, // Hoàn thành

        [EnumMember(Value = "Failed")]
        Failed, // Lỗi

        [EnumMember(Value = "Canceled")]
        Canceled // Hủy bỏ
    }

    [JsonConverter(typeof(JsonStringEnumConverter))]
    public enum StampingSessionStatus
    {
        [EnumMember(Value = "NotStarted")]
        NotStarted, // Chưa bắt đầu

        [EnumMember(Value = "Running")]
        Running, // Đang chạy

        [EnumMember(Value = "Paused")]
        Paused, // Tạm dừng

        [EnumMember(Value = "Finished")]
        Finished, // Đã hoàn thành

        [EnumMember(Value = "Failed")]
        Failed, // Hủy giữa chừng

        [EnumMember(Value = "Canceled")]
        Canceled // Hủy bỏs
    }

    [JsonConverter(typeof(JsonStringEnumConverter))]
    public enum TaskAssignmentStatus
    {
        [EnumMember(Value = "InProgress")]
        InProgress, // Đang thực hiện

        [EnumMember(Value = "Completed")]
        Completed, // Hoàn thành

        [EnumMember(Value = "Failed")]
        Failed, // Lỗi khi thực hiện
    }

    [JsonConverter(typeof(JsonStringEnumConverter))]
    public enum RobotStatus
    {
        [EnumMember(Value = "Idle")]
        Idle, // Đang rảnh

        [EnumMember(Value = "Working")]
        Working, // Đang làm việc

        [EnumMember(Value = "Error")]
        Error, // Gặp lỗi

        [EnumMember(Value = "Maintenance")]
        Maintenance // Đang bảo trì
    }
}

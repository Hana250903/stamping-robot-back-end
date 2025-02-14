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
    public enum Role
    {
        [EnumMember(Value = "Admin")]
        Admin,
        [EnumMember(Value = "Employee")]
        Employee
    }
}

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
    public enum ModelRobot
    {
        [EnumMember(Value = "IprHd6m90")]
        IprHd6m90,
        [EnumMember(Value = "IprHd6ms90")]
        IprHd6ms90,
        [EnumMember(Value = "IprHd6m180")]
        IprHd6m180,
        [EnumMember(Value = "IprHd6ms180")]
        IprHd6ms180
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;
using LifeBlue.Dal.DTO;

namespace LifeBlue.Core.Models
{
    public class VisitorResponse
    {
        public VisitorInformation VisitorInformation { get; set; }
        [JsonIgnore]
        public IEnumerable<string>? Errors { get; set; }
    }
}

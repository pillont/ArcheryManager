using Newtonsoft.Json;
using System;
using static ArcheryManager.CustomControls.TargetImage;

namespace ArcheryManager.Upjv
{
    public class JsonShoot
    {
        public int Id { get; set; }

        [JsonIgnore]
        public TargetStyle TargetStyle => (TargetStyle)Enum.Parse(typeof(TargetStyle), TargetStyleString);

        public string TargetStyleString { get; set; }
    }
}

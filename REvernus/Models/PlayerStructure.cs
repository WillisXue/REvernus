using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Controls;
using EVEStandard.Models;
using REvernus.Models.Interfaces;

namespace REvernus.Models
{
    [Serializable]
    public class PlayerStructure : IStation
    {
        public long StationId { get; set; }
        public string StationName { get; set; }
        public int OwnerId { get; set; }
        public int SolarSystemId { get; set; }
        public long StationTypeId { get; set; }
        public long? AddedBy { get; set; }
        public DateTime? AddedAt { get; set; }
        public bool? Enabled { get; set; }
        public bool IsPublic { get; set; }
    }
}

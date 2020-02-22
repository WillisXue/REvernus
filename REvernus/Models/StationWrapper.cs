using System;
using System.Collections.Generic;
using System.Text;
using EVEStandard.Models;
using REvernus.Models.Interfaces;

namespace REvernus.Models
{
    internal class StationWrapper : IStation
    {
        private Structure EveStandardStructure { get; }

        internal StationWrapper(long stationId, Structure structure)
        {
            EveStandardStructure = structure;
            StationId = stationId;
        }

        public long StationId { get; }
        public string StationName => EveStandardStructure.Name;
        public long SolarSystemId => EveStandardStructure.SolarSystemId;
        public long StationTypeId => Convert.ToInt64(EveStandardStructure.TypeId);
        public int OwnerId => EveStandardStructure.OwnerId;
    }
}

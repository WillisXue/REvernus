using System;
using System.Collections.Generic;
using System.Data.SQLite;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using REvernus.Core;
using REvernus.Core.ESI;
using REvernus.Models.EveDbModels;

namespace REvernus.Utilities
{
    public static class EveUniverse
    {
        public static bool TryGetRegionFromSystem(long? systemId, out int regionId)
        {
            regionId = 0;
            using var db = new eveContext();
            try
            {
                var solarSystem = db.MapSolarSystems.FirstOrDefault(o => o.SolarSystemId == systemId);
                if (solarSystem != null)
                {
                    regionId = Convert.ToInt32(solarSystem.RegionId);
                    return true;
                }
                else
                {
                    return false;
                }
            }
            finally
            {
                db.Dispose();
            }
        }

        /// <summary>
        /// This method returns all NPC stations and player structures within range specified. Does not check public structures.
        /// </summary>
        /// <param name="solarSystemId"></param>
        /// <param name="range"></param>
        public static List<long> GetStructuresInRange(int solarSystemId, int range)
        {
            if (range > -1)
            {
                var db = new eveContext();
                var searchSystems = new List<int>();
                searchSystems.Add(solarSystemId);
                var returnList = new List<long>();

                // Each iteration increases the range.
                for (var i = 0; i <= range; i++)
                {
                    var tempList = new List<int>();
                    foreach (var systemId in searchSystems.ToArray())
                    {
                        var npcStations = db.StaStations.Where(s => s.SolarSystemId == systemId).ToList();
                        returnList.AddRange(npcStations.Select(s => s.StationId));

                        var playerStations = StructureManager.Structures.Where(s => s.SolarSystemId == solarSystemId);
                        returnList.AddRange(playerStations.Select(s => s.StationId));

                        tempList.AddRange(db.MapJumps.Where(j => j.StargateId == systemId).Select(j => (int) j.DestinationId).ToList());
                    }
                    searchSystems.Clear();
                    searchSystems.AddRange(tempList);
                }
                return returnList;
            }
            return new List<long>();
        }
    }
}

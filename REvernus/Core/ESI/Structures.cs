using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using EVEStandard.Models;
using EVEStandard.Models.API;
using REvernus.Models;
using REvernus.Models.Interfaces;

namespace REvernus.Core.ESI
{
    public static class Structures
    {
        public static async Task<IStation> GetStructureInfoAsync(AuthDTO auth, long structureId, string searchString = "")
        {
            try
            {
                var structureInfo =
                    await EsiData.EsiClient.Universe.GetStructureInfoV2Async(auth, structureId);

                if (searchString == "") return new StationWrapper(structureId, structureInfo.Model);

                if (structureInfo.Model.Name.Contains(searchString))
                {
                    return new StationWrapper(structureId, structureInfo.Model);
                }
            }
            catch (Exception)
            {
                // Ignored
            }
            return null;
        }
    }
}

﻿using System;
using System.Collections.Generic;

namespace REvernus.Models.EveDbModels
{
    public partial class Skins
    {
        public long SkinId { get; set; }
        public string InternalName { get; set; }
        public long? SkinMaterialId { get; set; }
    }
}

﻿using System;
using System.Collections.Generic;

namespace REvernus.Models.EveDbModels
{
    public partial class CertSkills
    {
        public long? CertId { get; set; }
        public long? SkillId { get; set; }
        public long? CertLevelInt { get; set; }
        public long? SkillLevel { get; set; }
        public string CertLevelText { get; set; }
    }
}

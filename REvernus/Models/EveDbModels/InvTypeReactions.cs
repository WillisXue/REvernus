﻿using System;
using System.Collections.Generic;

namespace REvernus.Models.EveDbModels
{
    public partial class InvTypeReactions
    {
        public long ReactionTypeId { get; set; }
        public byte[] Input { get; set; }
        public long TypeId { get; set; }
        public long? Quantity { get; set; }
    }
}
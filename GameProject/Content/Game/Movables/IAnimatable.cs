﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameProject.Content.Game.Movables {
    internal interface IAnimatable {
        public Frame ActiveFrame
        {
            get; set;
        }
    }
}

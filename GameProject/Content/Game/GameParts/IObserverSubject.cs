﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameProject.Content.Game.GameParts
{
    internal interface IObserverSubject
    {
        void RegisterObserver(ISantaObserver observer);
        void RemoveObserver(ISantaObserver observer);
        void NotifyObservers();
    }
}

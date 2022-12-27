using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameProject.Content.Game {
    internal interface ISantaObserver {
        void update(bool santaMoved);
    }
}

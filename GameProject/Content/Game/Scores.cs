using GameProject.Content.Game.Levels;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace GameProject.Content.Game {
    internal static class Scores {
        public static Dictionary<Type, int> LevelScores;
        static Scores() {
            LevelScores = new Dictionary<Type, int>();

            //get the amount of levels.
            var type = typeof(ILevel);
            var levelClasses = AppDomain.CurrentDomain.GetAssemblies()
                .SelectMany(s => s.GetTypes())
                .Where(p => type.IsAssignableFrom(p) && p != type)
                .ToList();

            foreach (var level in levelClasses)
            {
                LevelScores.Add(level, 0);
            }
            Debug.WriteLine(levelClasses);
        }
    }
}

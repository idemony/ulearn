using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Windows.Forms.Keys;

namespace Digger
{
    public class Terrain : ICreature
    {
        public int GetDrawingPriority()
        {
            return 4;
        }

        public string GetImageFileName()
        {
            string imageFileName = "Terrain.png";
            return imageFileName;
        }

        public bool DeadInConflict(ICreature conflictedObject)
        {
            return true;
        }

        public CreatureCommand Act(int x, int y)
        {
            return new CreatureCommand();
        }
    }

    public class Player : ICreature
    {
        public int GetDrawingPriority()
        {
            int drawingPriority = 1;
            return drawingPriority;
        }

        public string GetImageFileName()
        {
            string imageFileName = "Digger.png";
            return imageFileName;
        }

        public CreatureCommand Act(int x, int y)
        {
            var coord = new CreatureCommand();
            var key = Game.KeyPressed;
            if (key == Down && y < Game.MapHeight - 1)
                coord.DeltaY = 1;
            if (key == Up && y > 0)
                coord.DeltaY = -1;
            if (key == Right && x < Game.MapWidth - 1)
                coord.DeltaX = 1;
            if (key == Left && x > 0)
                coord.DeltaX = -1;
            return coord;
        }

        public bool DeadInConflict(ICreature conflictedObject)
        {
            return false;
        }
    }
}

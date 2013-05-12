using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BullsAndCows
{
    /// <summary>
    /// Interface,that is inherited by Cow.cs and Bull.cs
    /// </summary>
    public interface IDraw
    {
        void DrawToConsole();
    }
}

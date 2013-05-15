//-----------------------------------------------------------------------
// <copyright file="IDraw.cs" company="TelerikAcademy">
//     All rights reserved © Telerik Academy 2012-2013
// </copyright>
//-----------------------------------------------------------------------
namespace BullsAndCows
{
    using System;

    /// <summary>
    /// Interface,that is inherited by Cow.cs and Bull.cs
    /// </summary>
    public interface IDraw
    {
        /// <summary>
        /// Gets the count of the Bulls/Cows
        /// </summary>
        /// <returns>Formatted string</returns>
        string GetPrintableCount();
    }
}

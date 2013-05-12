//-----------------------------------------------------------------------
// <copyright file="PlayerInfo.cs" company="TelerikAcademy">
//     All rights reserved © Telerik Academy 2012-2013
// </copyright>
//-----------------------------------------------------------------------
namespace BullsAndCows
{
    using System;

    /// <summary>
    /// Class holding the info about a player as nickName and amount of guesses
    /// </summary>
    public class PlayerInfo : IComparable<PlayerInfo>
    {
        /// <summary>
        /// The nickname of the player
        /// </summary>
        private string nickName;

        /// <summary>
        /// Initializes a new instance of the <see cref="PlayerInfo" /> class.
        /// </summary>
        /// <param name="nickName">The player's nickname</param>
        /// <param name="guesses">The player's guesses</param>
        public PlayerInfo(string nickName, int guesses)
        {
            this.NickName = nickName;
            this.Guesses = guesses;
        }

        /// <summary>
        /// Gets the nickname of the player
        /// </summary>
        public string NickName
        {
            get
            {
                return this.nickName;
            }

            private set
            {
                if (string.IsNullOrEmpty(value))
                {
                    throw new ArgumentException("NickName should have at least 1 symbol!");
                }
                else
                {
                    this.nickName = value;
                }
            }
        }

        /// <summary>
        /// Gets or sets the player's guesses
        /// </summary>
        public int Guesses { get; set; }

        /// <summary>
        /// Compares the number of guesses made by two users
        /// </summary>
        /// <param name="other">Another player's information</param>
        /// <returns>A signed number indicating the relative values of this instance and
        /// <paramref name="other"/>.Return Value Description Less than zero This instance
        /// is less than <paramref name="other"/>. Zero This instance is equal to <paramref name="other"/>.
        /// Greater than zero This instance is greater than <paramref name="other"/>.-or-
        /// <paramref name="other"/> is null. </returns>
        public int CompareTo(PlayerInfo other)
        {
            if (this.Guesses.CompareTo(other.Guesses) == 0)
            {
                return this.NickName.CompareTo(other.NickName);
            }
            else
            {
                return this.Guesses.CompareTo(other.Guesses);
            }
        }

        /// <summary>
        /// Overrides ToString() method to return information about results for the player
        /// </summary>
        /// <returns>Results information in string </returns>
        public override string ToString()
        {
            string result = string.Format("{0,3}    | {1}", this.Guesses, this.NickName);
            return result;
        }
    }
}
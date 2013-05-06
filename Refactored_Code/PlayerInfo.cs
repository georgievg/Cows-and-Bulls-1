using System;

namespace BullsAndCows
{
   
    /// <summary>
    /// Class holding the info about a player as nickName and amount of guesses
    /// </summary>
    public class PlayerInfo : IComparable<PlayerInfo>
    {
        private string nickName;

        public int Guesses { get; set; }

        public string NickName
        {
            get
            {
                return this.nickName;
            }

            private set
            {
                if (string.IsNullOrEmpty(this.nickName))
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
        /// Create new <see cref="PlayerInfo"/>
        /// </summary>
        /// <param name="nickName">The player's nickname</param>
        /// <param name="guesses">The player's guesses</param>
        public PlayerInfo(string nickName, int guesses)
        {
            this.NickName = nickName;
            this.Guesses = guesses;
        }

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

        public override string ToString()
        {
            string result = string.Format("{0,3}    | {1}", this.Guesses, this.NickName);
            return result;
        }
    }
}
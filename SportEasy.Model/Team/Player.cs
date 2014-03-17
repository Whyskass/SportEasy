using System;

namespace SportEasy.Model.Team
{
    public class Player
    {
        #region Properties

        public string FullName { get; set; }
        public int Age { get; set; }
        public double Size { get; set; }
        public double Weight { get; set; }
        public string Email { get; set; }
        public string PhoneNumber { get; set; }
        public string Position { get; set; }
        public string Role { get; set; }
        public string PhotoUrl { get; set; }

        public char FirstLetter
        {
            get
            {
                return Convert.ToChar(FullName[0].ToString().ToLower());
            }
        }

        #endregion 
    }
}
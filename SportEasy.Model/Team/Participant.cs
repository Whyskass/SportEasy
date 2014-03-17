using System;
using SportEasy.Model.Localization;

namespace SportEasy.Model.Team
{
    public class Participant
    {
        #region Properties

        public Player Player { get; set; }
        public ParticipantStatus Status { get; set; }

        public string StatusString
        {
            get
            {
                switch (Status)
                {
                    case ParticipantStatus.Yes:
                        return AppResources.string_Yes;
                    case ParticipantStatus.No:
                        return AppResources.string_No;
                    case ParticipantStatus.Maybe:
                        return AppResources.string_Maybe;
                    default:
                        throw new ArgumentOutOfRangeException();
                }
            }
        }

        #endregion 
    }

    public enum ParticipantStatus
    {
        Yes = 1,
        No = 2,
        Maybe = 3
    }
}
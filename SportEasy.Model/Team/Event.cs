using System;
using System.Collections;
using System.Collections.Generic;
using SportEasy.Model.Localization;

namespace SportEasy.Model.Team
{
    public class Event
    {
        #region Properties

        public int Id { get; set; }
        public DateTime Date { get; set; }
        public string Match { get; set; }
        public string Type { get; set; }
        public DateTime RdvDate { get; set; }
        public string Location { get; set; }
        public IEnumerable<Participant> Participants { get; set; }

        #region Date

        public string FullRdv
        {
            get
            {
                return string.Format("{0} {1} - {2} {3}", AppResources.string_StartAt, Date.ToString("hh:mm"),
                                                            AppResources.string_RdvAt, RdvDate.ToString("hh:mm"));
            }
        }

        public string DayString
        {
            get
            {
                switch (Date.DayOfWeek)
                {
                    case DayOfWeek.Friday:
                        return AppResources.string_Add_Friday.ToLower();
                    case DayOfWeek.Monday:
                        return AppResources.string_Add_Monday.ToLower();
                    case DayOfWeek.Saturday:
                        return AppResources.string_Add_Saturday.ToLower();
                    case DayOfWeek.Sunday:
                        return AppResources.string_Add_Sunday.ToLower();
                    case DayOfWeek.Thursday:
                        return AppResources.string_Add_Thurdsay.ToLower();
                    case DayOfWeek.Tuesday:
                        return AppResources.string_Add_Tuesday.ToLower();
                    case DayOfWeek.Wednesday:
                        return AppResources.string_Add_Wesneday.ToLower();
                    default:
                        throw new ArgumentOutOfRangeException();
                }
            }
        }

        public string Hour
        {
            get
            {
                return string.Format("{0}:{1}", Date.Hour, Date.ToString("mm"));
            }
        }

        public string Month
        {
            get
            {
                switch (Date.Month)
                {
                    case 1:
                        return AppResources.string_January.ToUpper();
                    case 2:
                        return AppResources.string_February.ToUpper();
                    case 3:
                        return AppResources.string_March.ToUpper();
                    case 4:
                        return AppResources.string_April.ToUpper();
                    case 5:
                        return AppResources.string_May.ToUpper();
                    case 6:
                        return AppResources.string_June.ToUpper();
                    case 7:
                        return AppResources.string_July.ToUpper();
                    case 8:
                        return AppResources.string_August.ToUpper();
                    case 9:
                        return AppResources.string_September.ToUpper();
                    case 10:
                        return AppResources.string_October.ToUpper();
                    case 11:
                        return AppResources.string_November.ToUpper();
                    case 12:
                        return AppResources.string_December.ToUpper();
                    default:
                        return "";
                }
            }
        }

        public string MonthAndYear
        {
            get
            {
                return string.Format("{0} {1}", Month, Date.Year);
            }
        }

        public string FullDate
        {
            get
            {
                return string.Format("{0} {1} {2}", DayString, Date.Day, MonthAndYear);
            }
        }

        public string RdvHour
        {
            get
            {
                return RdvDate.ToString("hh:mm");
            }
        }

        #endregion

        #endregion
    }
}
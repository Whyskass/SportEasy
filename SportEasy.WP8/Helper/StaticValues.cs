using System.Windows.Threading;
using SportEasy.Model.User;

namespace SportEasy.WP8.Helper
{
    public class StaticValues
    {
        #region Properties

        public static Dispatcher Dispatcher { get; set; }
        public static User CurrentUser { get; set; }

        #endregion
    }
}
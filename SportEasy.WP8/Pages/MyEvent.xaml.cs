using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Navigation;
using Microsoft.Phone.Controls;
using Microsoft.Phone.Shell;
using SportEasy.Model.Team;
using Telerik.Windows.Data;

namespace SportEasy.WP8.Pages
{
    public partial class MyEvent : PhoneApplicationPage
    {
        #region Constructor

        public MyEvent()
        {
            InitializeComponent();

            var groupByMonthAndYear = new GenericGroupDescriptor<Participant, string>(pt => ((int)pt.Status).ToString());
            ParticipantJumpList.GroupDescriptors.Add(groupByMonthAndYear);
        } 

        #endregion

    }
}
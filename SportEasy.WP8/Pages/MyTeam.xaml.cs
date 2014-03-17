using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Controls;
using System.Windows.Navigation;
using Microsoft.Phone.Controls;
using SportEasy.Model.Team;
using SportEasy.ViewModel.Pages;
using Telerik.Windows.Controls;
using Telerik.Windows.Data;
using GestureEventArgs = System.Windows.Input.GestureEventArgs;

namespace SportEasy.WP8.Pages
{
    public partial class MyTeam : PhoneApplicationPage
    {
        #region Variable declaration

        private string _alphabet = "#abcdefghijklmnopqrstuvwxyz";
        
        #endregion

        #region Constructor

        public MyTeam()
        {
            InitializeComponent();

            #region Jump list group

            var groupByMonthAndYear = new GenericGroupDescriptor<Event, string>(evt => evt.MonthAndYear);
            EventJumpList.GroupDescriptors.Add(groupByMonthAndYear);

            var groupByFullname = new GenericGroupDescriptor<Player, char>(player => player.FirstLetter);
            PlayerJumpList.GroupDescriptors.Add(groupByFullname);

            // we do not want async balance since item templates are simple
            PlayerJumpList.IsAsyncBalanceEnabled = false;

            // add custom group picker items, including all alphabetic characters
            var groupPickerItems = new List<string>(32);
            groupPickerItems.AddRange(_alphabet.Select(c => new string(c, 1)));
            PlayerJumpList.GroupPickerItemsSource = groupPickerItems;

            #endregion
        }

        #endregion


        #region Page event handler

        private void EventJumpList_OnGroupHeaderItemTap(object sender, GroupHeaderItemTapEventArgs e)
        {
            var navImage = e.OriginalSource as Image;
            if (navImage != null)
            {
                var dataGroup = EventJumpList.GetDataSourceItemForDataItem(e.Item.Content) as IDataSourceGroup;

                if (navImage.Tag != null && navImage.Tag.ToString().Equals("up"))
                {
                    int indexOfGroup = Array.IndexOf(EventJumpList.Groups, dataGroup.Value);
                    if (indexOfGroup > 0)
                    {
                        EventJumpList.BringIntoView(EventJumpList.Groups[indexOfGroup - 1]);
                        e.ShowGroupPicker = false;
                    }
                }
                else if (navImage.Tag != null && navImage.Tag.ToString().Equals("down"))
                {
                    int indexOfGroup = Array.IndexOf(EventJumpList.Groups, dataGroup.Value);
                    if (indexOfGroup < EventJumpList.Groups.Length - 1)
                    {
                        EventJumpList.BringIntoView(EventJumpList.Groups[indexOfGroup + 1]);
                        e.ShowGroupPicker = false;
                    }
                }
            }
        }

        private void PlayerJumpList_OnGroupPickerItemTap(object sender, GroupPickerItemTapEventArgs e)
        {
            foreach (DataGroup group in PlayerJumpList.Groups)
            {
                if (object.Equals(e.DataItem.ToString(), group.Key.ToString()))
                {
                    e.DataItemToNavigate = group;
                    return;
                }
            }
        }

        private void CalendarTap(object sender, GestureEventArgs e)
        {
            TeamPivot.SelectedIndex = 0;
        }

        private void TeamTap(object sender, GestureEventArgs e)
        {
            TeamPivot.SelectedIndex = 1;
        }

        #endregion
    }
}
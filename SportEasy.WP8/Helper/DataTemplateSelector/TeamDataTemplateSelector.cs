using System.Windows;
using SportEasy.Model.Localization;
using SportEasy.Model.Team;

namespace SportEasy.WP8.Helper.DataTemplateSelector
{
    public class TeamDataTemplateSelector : DataTemplateSelector
    {
        public DataTemplate Normal
        {
            get;
            set;
        }

        public DataTemplate Add
        {
            get;
            set;
        }

        public override DataTemplate SelectTemplate(object item, DependencyObject container)
        {
            Team foodItem = item as Team;
            if (foodItem != null)
            {
                if (foodItem.Name == AppResources.string_Add)
                {
                    return Add;
                }
                    return Normal;
                
            }

            return base.SelectTemplate(item, container);
        }
    }
}
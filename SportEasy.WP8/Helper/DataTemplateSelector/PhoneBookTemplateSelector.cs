using System.Windows;
using Telerik.Windows.Controls;
using Telerik.Windows.Controls.JumpList;
using Telerik.Windows.Data;

namespace SportEasy.WP8.Helper.DataTemplateSelector
{
    public class PhoneBookTemplateSelector : Telerik.Windows.Controls.DataTemplateSelector
    {
        private DataTemplate emptyItemTemplate;
        private DataTemplate linkedItemTemplate;
        private RadJumpList list;

        public DataTemplate LinkedItemTemplate
        {
            get { return linkedItemTemplate; }
            set { linkedItemTemplate = value; }
        }

        public DataTemplate EmptyItemTemplate
        {
            get { return emptyItemTemplate; }
            set { emptyItemTemplate = value; }
        }

        public override DataTemplate SelectTemplate(object item, DependencyObject container)
        {
            if (list == null)
            {
                var picker = ElementTreeHelper.FindVisualAncestor<JumpListGroupPicker>(container);
                if (picker != null)
                {
                    list = picker.Owner;
                }
            }

            if (list == null)
            {
                return base.SelectTemplate(item, container);
            }

            return IsLinkedItem(item) ? linkedItemTemplate : emptyItemTemplate;
        }

        private bool IsLinkedItem(object item)
        {
            foreach (DataGroup group in list.Groups)
            {
                if (Equals(group.Key.ToString(), item.ToString()))
                {
                    return true;
                }
            }

            return false;
        }
    }
}
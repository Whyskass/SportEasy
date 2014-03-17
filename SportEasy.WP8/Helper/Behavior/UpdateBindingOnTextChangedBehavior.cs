using System.Windows.Controls;
using System.Windows.Interactivity;
using Microsoft.Phone.Controls;

namespace SportEasy.WP8.Helper.Behavior
{
    public class UpdateBindingOnTextChangedBehavior : Behavior<PhoneTextBox>
    {
        protected override void OnAttached()
        {
            base.OnAttached();
            this.AssociatedObject.TextChanged += new TextChangedEventHandler(AssociatedObject_TextChanged);
        }

        void AssociatedObject_TextChanged(object sender, TextChangedEventArgs e)
        {
            var binding = AssociatedObject.GetBindingExpression(TextBox.TextProperty);
            if (binding != null)
                binding.UpdateSource();
        }

        protected override void OnDetaching()
        {
            base.OnDetaching();
            this.AssociatedObject.TextChanged -= AssociatedObject_TextChanged;
        }
    }
}
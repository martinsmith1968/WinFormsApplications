namespace QuickCalendar.Extensions
{
    internal static class ComboBoxExtensions
    {
        public static T[] GetItems<T>(this ComboBox comboBox)
        {
            return comboBox.Items.Cast<T>().ToArray();
        }
    }
}

using MyApp.Dependencies;
using System;
using System.Windows;

namespace MyApp.WPF.NetFramework.Dependencies
{
    public class MessageDialog : IMessageDialog
    {
        /// <summary>
        /// Show alert message
        /// </summary>
        /// <param name="title">Dialog title</param>
        /// <param name="message">Alert message</param>
        /// <param name="onOkAction">Action when ok button is selected</param>
        void IMessageDialog.ShowAlertMessage(string title, string message, Action onOkAction)
        {
            MessageBox.Show(message, title, MessageBoxButton.OK, MessageBoxImage.Warning);
            onOkAction?.Invoke();
        }
    }
}

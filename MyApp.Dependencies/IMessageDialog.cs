using System;

namespace MyApp.Dependencies
{
    public interface IMessageDialog
    {
        /// <summary>
        /// Show alert message
        /// </summary>
        /// <param name="title">Dialog title</param>
        /// <param name="message">Alert message</param>
        /// <param name="onOkAction">Action when ok button is selected</param>
        void ShowAlertMessage(string title, string message, Action onOkAction);
    }
}

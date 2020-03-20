using MyApp.Dependencies;
using ReactiveUI;
using System;

namespace MyApp.XamForms.Dependencies
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
            MessageBus.Current.SendMessage(new MessageDialogRequest()
            {
                Title = title,
                Message = message
            });
            onOkAction?.Invoke();
        }

        public class MessageDialogRequest
        {
            public string Title { get; set; }
            public string Message { get; set; }
        }
    }
}

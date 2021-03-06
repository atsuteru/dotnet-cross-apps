﻿using MyApp.ViewModel;
using ReactiveUI;
using ReactiveUI.XamForms;
using System;
using System.Reactive.Disposables;
using System.Reactive.Linq;
using System.Threading.Tasks;
using Xamarin.Forms;
using static MyApp.XamForms.Dependencies.MessageDialog;

namespace MyApp.XamForms
{
    public partial class HomeView : ReactiveContentPage<HomeViewModel>
    {
        public HomeView()
        {
            InitializeComponent();
            NavigationPage.SetHasBackButton(this, false);

            this.WhenActivated((d) =>
            {
                HandleViewModelBound(d);
            });
        }

        protected void HandleViewModelBound(CompositeDisposable d)
        {
            this.Bind(ViewModel, vm => vm.Name, v => v.NameTextBox.Text).DisposeWith(d);
            this.Bind(ViewModel, vm => vm.Organization, v => v.OrganizationTextBox.Text).DisposeWith(d);
            this.BindCommand(ViewModel, vm => vm.SubmitCommand, v => v.GenerateButton).DisposeWith(d);

            MessageBus.Current.RegisterScheduler<MessageDialogRequest>(RxApp.MainThreadScheduler);
            MessageBus.Current.Listen<MessageDialogRequest>()
                .Subscribe(x => HandleMessageDialogRequest(x))
                .DisposeWith(d);
        }

        protected Task HandleMessageDialogRequest(MessageDialogRequest request)
        {
            return DisplayAlert(request.Title, request.Message, "OK");
        }
    }
}

﻿using MyApp.ViewModel;
using ReactiveUI;
using ReactiveUI.XamForms;
using System.Reactive.Disposables;
using Xamarin.Forms;

namespace MyApp.XamForms
{
    public partial class ResultView : ReactiveContentPage<ResultViewModel>
    {
        protected bool IsViewModelBound { get; private set; }

        public ResultView()
        {
            InitializeComponent();
            NavigationPage.SetHasBackButton(this, false);

            this.WhenActivated((d) =>
            {
                if (IsViewModelBound)
                {
                    return;
                }
                HandleViewModelBound(d);
                IsViewModelBound = true;
            });
        }

        protected void HandleViewModelBound(CompositeDisposable d)
        {
            this.OneWayBind(ViewModel, vm => vm.Name, v => v.NameTextBox.Text).DisposeWith(d);
            this.OneWayBind(ViewModel, vm => vm.Organization, v => v.OrganizationTextBox.Text).DisposeWith(d);
            this.OneWayBind(ViewModel, vm => vm.Result, v => v.ResultTextBox.Text).DisposeWith(d);
            this.BindCommand(ViewModel, vm => vm.BackCommand, v => v.BackButton).DisposeWith(d);
        }
    }
}

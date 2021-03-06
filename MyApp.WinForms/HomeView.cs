﻿using MyApp.ViewModel;
using ReactiveUI;
using ReactiveUI.Winforms;
using System.Reactive.Disposables;

namespace MyApp.WinForms
{
    public partial class HomeView : ReactiveUserControl<HomeViewModel>
    {
        protected bool IsViewModelBound { get; private set; }

        public HomeView()
        {
            InitializeComponent();

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
            this.Bind(ViewModel, vm => vm.Name, v => v.NameTextBox.Text).DisposeWith(d);
            this.Bind(ViewModel, vm => vm.Organization, v => v.OrganizationTextBox.Text).DisposeWith(d);
            this.BindCommand(ViewModel, vm => vm.SubmitCommand, v => v.GenerateButton).DisposeWith(d);
        }
    }
}

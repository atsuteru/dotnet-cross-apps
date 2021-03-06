﻿using MyApp.ViewModel;
using ReactiveUI;
using System.Reactive.Disposables;

namespace MyApp.WPF
{
    /// <summary>
    /// HomeView.xaml の相互作用ロジック
    /// </summary>
    public partial class ResultView : ReactiveUserControl<ResultViewModel>
    {
        public ResultView()
        {
            InitializeComponent();

            this.WhenActivated((d) =>
            {
                HandleViewModelBound(d);
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

using wooooooood.Common.ViewModels;
using System;
using Xamarin.Forms;

//[XamlCompilation(XamlCompilationOptions.Compile)]
namespace wooooooood.Common.Pages
{
    public partial class SpinnerPage : ContentPage
    {
        SpinnerViewModel ViewModel;

        public HistoricalViewDetailPage(SpinnerViewModel viewModel)
        {
            InitializeComponent();
            BindingContext = ViewModel = viewModel;
        }
    }
}
using NetflixRoullette.Models;
using NetflixRoullette.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace NetflixRoullette.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class MovieDetailPageView : ContentPage
    {
        MovieDetailPageViewModel viewModel;
        public MovieDetailPageView(Movie movie)
        {
            InitializeComponent();
            viewModel = Resources["viewModel"] as MovieDetailPageViewModel;
            viewModel.Movie = movie;
        }
    }
}
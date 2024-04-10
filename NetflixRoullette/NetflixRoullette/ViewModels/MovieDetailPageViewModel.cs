using NetflixRoullette.Models;
using System;
using System.Collections.Generic;
using System.Text;
using Xamarin.Forms;

namespace NetflixRoullette.ViewModels
{
    public class MovieDetailPageViewModel : BaseViewModel
    {
        private Movie movie;

        public Movie Movie
        {
            get => movie;
            set => SetValue(ref movie, value);
        }
    }
}

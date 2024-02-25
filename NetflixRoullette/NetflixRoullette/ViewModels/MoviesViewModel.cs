using System;
using System.Collections.Generic;
using System.Text;

namespace NetflixRoullette.ViewModels
{
    public class MoviesViewModel : BaseViewModel
    {
        private string _temp;
        public string Temp
        {
            get => _temp;
            set => SetValue(ref _temp, value); 
        }

        public MoviesViewModel()
        {
            _temp = "This is comming from the MoviesViewModel";
        }
    }
}

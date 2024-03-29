﻿using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace NetflixRoullette.Services.Interfaces
{
    public interface INavigationService
    {
        Task<bool> DisplayAlert(string title, string message, string ok, string cancel);
        Task DisplayAlert(string title, string message, string ok);
        Task PushAsync(Page page);
        Task<Page> PopAsync();
    }
}

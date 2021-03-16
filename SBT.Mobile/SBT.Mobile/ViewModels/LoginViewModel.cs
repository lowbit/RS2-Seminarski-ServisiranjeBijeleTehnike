﻿using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Input;
using Xamarin.Forms;

namespace SBT.Mobile.ViewModels
{
    class LoginViewModel:BaseViewModel
    {
        public LoginViewModel()
        {
            LoginCommand = new Command(()=>
            {
                Username = "aa";
            });
        }
        string _username = string.Empty;
        public string Username
        {
            get { return _username; }
            set { SetProperty(ref _username, value); }
        }
        string _password = string.Empty;
        public string Password
        {
            get { return _password; }
            set { SetProperty(ref _password, value); }
        }
        public ICommand LoginCommand{ get; set; }
    }
}
﻿using Imaging;
using PRPR.BooruViewer.Models;
using PRPR.BooruViewer.ViewModels;
using PRPR.Common;
using PRPR.Common.Models.Global;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using Windows.ApplicationModel;
using Windows.ApplicationModel.Resources;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.Graphics.Imaging;
using Windows.Storage.Streams;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Media.Imaging;
using Windows.UI.Xaml.Navigation;

// The Blank Page item template is documented at http://go.microsoft.com/fwlink/?LinkId=234238

namespace PRPR.BooruViewer.Views
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class AboutPage : Page
    {
        public AboutPage()
        {
            this.InitializeComponent();
            this.navigationHelper = new NavigationHelper(this);
            this.navigationHelper.LoadState += this.NavigationHelper_LoadState;
            this.navigationHelper.SaveState += this.NavigationHelper_SaveState;
        }

        #region NavigationHelper

        private NavigationHelper navigationHelper;
        public NavigationHelper NavigationHelper
        {
            get { return this.navigationHelper; }
        }

        protected override void OnNavigatedTo(NavigationEventArgs e)
        {
            this.navigationHelper.OnNavigatedTo(e);
        }

        protected override void OnNavigatedFrom(NavigationEventArgs e)
        {
            this.navigationHelper.OnNavigatedFrom(e);
        }

        #endregion
        


        public string AppVersion
        {
            get
            {
                return AppSettings.Current.CurrentAppVersion;
            }
        }
        
        public ObservableCollection<string> UpdateNotes
        {
            get
            {
                var loader = ResourceLoader.GetForCurrentView();
                var notes = loader.GetString("/PatchNotes/Notes").Split('@').Where(o => !String.IsNullOrEmpty(o));

                return new ObservableCollection<string>(notes);
            }
        }


        private void NavigationHelper_LoadState(object sender, LoadStateEventArgs e)
        {
            AppSettings.Current.UpdateNoticed();
        }
        
        private void NavigationHelper_SaveState(object sender, SaveStateEventArgs e)
        {

        }
    }
}


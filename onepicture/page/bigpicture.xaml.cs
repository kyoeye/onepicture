﻿using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Media.Imaging;
using Windows.UI.Xaml.Navigation;

// “空白页”项模板在 http://go.microsoft.com/fwlink/?LinkId=234238 上有介绍

namespace onepicture.page
{
    /// <summary>
    /// 可用于自身或导航至 Frame 内部的空白页。
    /// </summary>
    public sealed partial class bigpicture : Page
    {
        public bigpicture()
        {
            this.InitializeComponent();
        }
        public object kk { get; set; }
        protected override async void OnNavigatedTo(NavigationEventArgs e)
        {
            var gg = (string ) e.Parameter;
          //   BitmapSource bl = new Uri(gg);
          
            if (gg != null)
            {
                BitmapImage lv = new BitmapImage(new Uri(gg));
                bigpicturename.Source = lv;
            }
            else
            {
                var msgDialog = new Windows.UI.Popups.MessageDialog("gg == null") { Title = "错误" };
                msgDialog.Commands.Add(new Windows.UI.Popups.UICommand("改改改"));
                await msgDialog.ShowAsync();
            }
            /*    if (gg != null)
               {
                   BitmapSource bl = new Uri(gg);
                  BitmapImage lv = new BitmapImage(new Uri(bl));
                  Uri ll = kk;
                   BitmapImage jj = new BitmapImage(ll);
                   bigpicturename.Source = jj;  
               } 
          */
        }
    }
}

﻿using onepicture.cs;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Navigation;


// “空白页”项模板在 http://go.microsoft.com/fwlink/?LinkId=234238 上有介绍

namespace onepicture.page
{
    /// <summary>
    /// 可用于自身或导航至 Frame 内部的空白页。
    /// </summary>
    public sealed partial class seting : Page
    {
        public seting()
        {
            this.InitializeComponent();
           NavigationCacheMode = NavigationCacheMode.Required;
        }

     

        public void shengliu_kaiguan_Toggled(object sender, Windows.UI.Xaml.RoutedEventArgs e)
        {
            var toggle = sender as ToggleSwitch;
          //  shengliukaiguan diaoyong = new shengliukaiguan();
            if (toggle.IsOn)
            {
                shengliukaiguan diaoyong = new shengliukaiguan();
                //  diaoyong.fangfa(1);
                int a = 1;
                diaoyong.on = a;
                fresh_Click kk = new fresh_Click();
            }
            else
            {
                shengliukaiguan diaoyong = new shengliukaiguan();
                //   diaoyong.fangfa(2);
                int b = 2;
                diaoyong.On = b;
             
            }
          
        }
    }
}

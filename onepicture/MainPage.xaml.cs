using System;
using onepicture.page;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Navigation;

//“空白页”项模板在 http://go.microsoft.com/fwlink/?LinkId=402352&clcid=0x409 上有介绍

namespace onepicture
{
    /// <summary>
    /// 可用于自身或导航至 Frame 内部的空白页。
    /// </summary>
    public sealed partial class MainPage : Page
    {
        public MainPage()
        {
            this.InitializeComponent();
           
        }

       

        protected override void OnNavigatedTo(  NavigationEventArgs e)
        {
            base.OnNavigatedTo(e);
            myframe.Navigate(typeof(oneimage));
        }

        private void Listboxmenu_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (onepicture.IsSelected)
            {
                 
                myframe.Navigate(typeof(oneimage));
                mynemu.IsPaneOpen = !mynemu.IsPaneOpen;
            }
            else if (setting.IsSelected )
            {
                myframe.Navigate(typeof(seting));
                mynemu.IsPaneOpen = !mynemu.IsPaneOpen;
            }
        }

        private void hanbao_Click(object sender, RoutedEventArgs e)
        {
            mynemu.IsPaneOpen = !mynemu.IsPaneOpen;
        }

    }
}

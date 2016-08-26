using System;
using onepicture.page;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Navigation;
using System.Net.NetworkInformation;

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



        protected override async void OnNavigatedTo(NavigationEventArgs e)
        {
            base.OnNavigatedTo(e);
            if (NetworkInterface.GetIsNetworkAvailable())
            {
                Frame.Navigate(typeof(oneimage));
            }
            else
            {
                var msgDialog = new Windows.UI.Popups.MessageDialog("请检查交易资格并尝试继续") { Title = "网络结合失败(/≧▽≦)/" };
                msgDialog.Commands.Add(new Windows.UI.Popups.UICommand("取消"));
                await msgDialog.ShowAsync();
            }
        }

        public async void Listboxmenu_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
          
            if (onepicture.IsSelected)
            {
                onepicture.IsSelected = !onepicture.IsSelected;
                if (NetworkInterface.GetIsNetworkAvailable())
                {
                    base.Frame.Navigate(typeof(oneimage));
                }
                else
                {
                    var msgDialog = new Windows.UI.Popups.MessageDialog("请检查交易资格并尝试继续") { Title = "网络结合失败(/≧▽≦)/" };
                    msgDialog.Commands.Add(new Windows.UI.Popups.UICommand("取消"));
                    await msgDialog.ShowAsync();
                }
                mynemu.IsPaneOpen = !mynemu.IsPaneOpen;

            }
            else if (setting.IsSelected)
            {
                setting.IsSelected = !setting.IsSelected;
                base.Frame.Navigate(typeof(seting));
                mynemu.IsPaneOpen = !mynemu.IsPaneOpen;
            }
        }
     
        public void hanbao_Click(object sender, RoutedEventArgs e)
        {
            mynemu.IsPaneOpen = !mynemu.IsPaneOpen;
        }

    }
}

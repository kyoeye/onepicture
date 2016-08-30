using onepicture.cs;
using onepicture.page;
using System;
using System.Net.NetworkInformation;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Media.Imaging;
using Windows.UI.Xaml.Navigation;

// “空白页”项模板在 http://go.microsoft.com/fwlink/?LinkId=234238 上有介绍

namespace onepicture.page
{
    /// <summary>
    /// 可用于自身或导航至 Frame 内部的空白页。
    /// </summary>
    public sealed partial class homepage : Page
    {
        public homepage()
        {
            this.InitializeComponent();
            
        }



        protected override async void OnNavigatedTo(NavigationEventArgs e)
        {
          
            // base.OnNavigatedTo(e);

            if (NetworkInterface.GetIsNetworkAvailable())
            {
                RootObject myimage = await imageproxy.goimage();
                
                BitmapImage homepage_image = new BitmapImage(new Uri(myimage.p_ori));
                storyboardRectangle.Begin();
                homethephoto.Source = homepage_image;
            }

        }

    }
}

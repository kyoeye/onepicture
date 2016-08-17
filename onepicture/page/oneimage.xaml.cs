using System;
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
    public sealed partial class oneimage : Page
    {
        public oneimage()
        {
            this.InitializeComponent();
           
        }

        protected override async void OnNavigatedTo(NavigationEventArgs e)
        {
            base.OnNavigatedTo(e);
            RootObject myimage = await imageproxy.goimage();
            twotext.Text = "高度" + myimage.p_ori_hight + "-" + "宽度" + myimage.p_ori_width;
            // BitmapImage貌似是用来接收uri来转成图片的，死国一得死
            BitmapImage bitmapImage = new BitmapImage(new Uri(myimage.p_ori));
            thephoto.Source = bitmapImage;
        }

        private async void fresh_Click(object sender, RoutedEventArgs e)
        {

            RootObject myimage = await imageproxy.goimage();
            twotext.Text = "高度" + myimage.p_ori_hight + "-" + "宽度" + myimage.p_ori_width;
            // BitmapImage貌似是用来接收uri来转成图片的，死国一得死
            BitmapImage bitmapImage = new BitmapImage(new Uri(myimage.p_ori));
            thephoto.Source = bitmapImage;
            //实现GRID的背景图加载
            //   ImageBrush imageBrush = new ImageBrush();
            //   imageBrush.ImageSource = bitmapImage;           
            //   backimage = imageBrush;

        }
    }
}

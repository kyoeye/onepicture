using onepicture.cs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.NetworkInformation;
using System.Runtime.InteropServices.WindowsRuntime;
using System.Threading.Tasks;
using Windows.Graphics.Display;
using Windows.Graphics.Imaging;
using Windows.Storage;
using Windows.Storage.Pickers;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Media.Imaging;
using Windows.UI.Xaml.Navigation;
using Microsoft.Toolkit.Uwp.UI.Animations;
using Windows.System.UserProfile;
using Windows.UI.Popups;


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
            NavigationCacheMode = NavigationCacheMode.Required;

        }

        BitmapImage bitmapImage;
        Uri imguri;
        //方法
        public async void getfc()
        {
            RootObject myimage = await imageproxy.goimage();
            twotext.Text = "小高度" + myimage.p_ori_hight + "-" + "宽度" + myimage.p_ori_width;
            bitmapImage = new BitmapImage(new Uri(myimage.p_ori));
            imguri = new Uri(myimage.p_ori);
        }

        protected override async void OnNavigatedTo(NavigationEventArgs e)
        {           
            base.OnNavigatedTo(e);
            thephoto.Stretch = Stretch.Uniform;
            shengliukaiguan diaoyong = new shengliukaiguan();
            if (diaoyong.On == 1)
            {
                if (NetworkInterface.GetIsNetworkAvailable())
                {
                                   
                    getfc();
                    thephoto.Source = bitmapImage ;
                    await backimage.Blur(duration: 10, delay: 0, value: 10).StartAsync();
                }
                else 
                {
                    var msgDialog = new Windows.UI.Popups.MessageDialog("你的网络断了（或许吧）") { Title = "网络结合失败(/≧▽≦)/" };
                    msgDialog.Commands.Add(new Windows.UI.Popups.UICommand("取消"));
                    await msgDialog.ShowAsync();
                }
            }
            else
            {
                if (NetworkInterface.GetIsNetworkAvailable())
                {
                    RootObject myimage = await imageproxy.goimage();
                    twotext.Text = "高度" + myimage.p_ori_hight + "-" + "宽度" + myimage.p_ori_width;
                    // BitmapImage貌似是用来接收uri来转成图片的，死国一得死
                    BitmapImage bitmapImage = new BitmapImage(new Uri(myimage.p_ori));
                    thephoto.Source = bitmapImage;
                }
                else
                {
                    var msgDialog = new Windows.UI.Popups.MessageDialog("你的网络断了（或许吧）") { Title = "网络结合失败(/≧▽≦)/" };
                    msgDialog.Commands.Add(new Windows.UI.Popups.UICommand("取消"));
                    await msgDialog.ShowAsync();
                }
            }
        }

   
        public async void fresh_Click( object sender, RoutedEventArgs e)
        {
            
             //  using page.seting. ;
             shengliukaiguan diaoyong = new shengliukaiguan();
            //   shengliukaiguan dd = await shengliukaiguan.on();

            if  (diaoyong.On == 1)
            {
                if (NetworkInterface.GetIsNetworkAvailable())
                {
                    RootObject myimage = await imageproxy.goimage();
                    twotext.Text = "小高度" + myimage.p_ori_hight + "-" + "宽度" + myimage.p_ori_width;

                    BitmapImage bitmapImage = new BitmapImage(new Uri(myimage.p_mid));
                    thephoto.Source = bitmapImage;

                   //大图传递
                    BitmapImage bb = new BitmapImage(new Uri(myimage.p_ori));
                    Uri kk = bb.UriSource;
                }
                else
                {
                    var msgDialog = new Windows.UI.Popups.MessageDialog("你的网络断了（或许吧）") { Title = "网络结合失败(/≧▽≦)/" };
                    msgDialog.Commands.Add(new Windows.UI.Popups.UICommand("取消"));
                    await msgDialog.ShowAsync();
                }
            }
            else
            {
                if (NetworkInterface.GetIsNetworkAvailable())
                {
                    RootObject myimage = await imageproxy.goimage();
                    twotext.Text = "高度" + myimage.p_ori_hight + "-" + "宽度" + myimage.p_ori_width;

                    BitmapImage bitmapImage = new BitmapImage(new Uri(myimage.p_ori));
                    thephoto.Source = bitmapImage;

                    //大图传递
                    BitmapImage bb = new BitmapImage(new Uri(myimage.p_ori));
                    Uri kk = bb.UriSource;
                }
                else
                {
                    var msgDialog = new Windows.UI.Popups.MessageDialog("你的网络断了（或许吧）") { Title = "网络结合失败(/≧▽≦)/" };
                    msgDialog.Commands.Add(new Windows.UI.Popups.UICommand("取消"));
                    await msgDialog.ShowAsync();
                }
            }
          
       }
        
   


        private async void gotoimage_Click(object sender, RoutedEventArgs e)
        {
            RootObject myimage = await imageproxy.goimage();
            
            
        }
       
        public void bigpictureclick_Click(object sender, RoutedEventArgs e)
        {

            Frame.Navigate(typeof(bigpicture));
        }

        private  void bata_1_Click(object sender, RoutedEventArgs e)
        {
           

            
            thephoto.Stretch = Stretch.UniformToFill;
        }



        //public async void sfilefc()
        //{
        //    //image控件转换图像
        //    RenderTargetBitmap renderTargerBitemap = new RenderTargetBitmap();
        //    //传入image控件
        //    await renderTargerBitemap.RenderAsync(thephoto);
        //    var progressTask = ModalProgressDig.ShowAsync();
            
        //}

        private async void download_Click(object sender, RoutedEventArgs e)
        {
            RootObject myimage = await imageproxy.goimage();
            var saveFile = new FileSavePicker();
            saveFile.SuggestedStartLocation = PickerLocationId.PicturesLibrary; //下拉列表的文件类型
            string filename = "文件类型";
            saveFile.FileTypeChoices.Add(filename, new List<string>() { ".png", ".jpg", ".jpeg", ".bmp" }); //文件命名

            string filenam = myimage.p_mid;
          
            saveFile.SuggestedFileName = filenam;
            StorageFile sFile = await saveFile.PickSaveFileAsync();

            if (sFile != null)
            {
                // 在用户完成更改并调用CompleteUpdatesAsync之前，阻止对文件的更新
                CachedFileManager.DeferUpdates(sFile);
                //image控件转换图像
                RenderTargetBitmap renderTargerBitemap = new RenderTargetBitmap();
                //传入image控件
                await renderTargerBitemap.RenderAsync(thephoto);
                var progressTask = ModalProgressDig.ShowAsync();
                randomclass dd = new randomclass();
                dd.randome();
                dd.stringzifu();
                contenttext2.Text = dd.zif;
                var pixelBuffer = await renderTargerBitemap.GetPixelsAsync();
                //下面这段不明所以的说
                using (var fileStream = await sFile.OpenAsync(FileAccessMode.ReadWrite))
                {
                    var encoder = await BitmapEncoder.CreateAsync(BitmapEncoder.PngEncoderId, fileStream);
                    encoder.SetPixelData(
                        BitmapPixelFormat.Bgra8,
                        BitmapAlphaMode.Ignore,
                         (uint)renderTargerBitemap.PixelWidth,
                         (uint)renderTargerBitemap.PixelHeight,
                         DisplayInformation.GetForCurrentView().LogicalDpi,
                         DisplayInformation.GetForCurrentView().LogicalDpi,
                         pixelBuffer.ToArray()
                        );
                    //刷新
                    await encoder.FlushAsync();
                }
                await Task.Delay(4000);

                progressTask.Cancel();
                ModalProgressDig.Hide();
            }
            else
            {

            }
        }

        private void homebackground_Click(object sender, RoutedEventArgs e)
        {
            homebackground.Flyout = myFlyout;
            
        }

        private async void StarBackground_Click(object sender, RoutedEventArgs e)
        {
            var msg = new MessageDialog("");
            if (!UserProfilePersonalizationSettings.IsSupported())
            {
                var mess = new MessageDialog("人品太差，不支持哦！");
                await mess.ShowAsync();
            }

            StorageFile file = await StorageFile.GetFileFromApplicationUriAsync(imguri);

            UserProfilePersonalizationSettings setting  = UserProfilePersonalizationSettings.Current; //实例化
            await setting.TrySetLockScreenImageAsync(file);
        }
    }
}

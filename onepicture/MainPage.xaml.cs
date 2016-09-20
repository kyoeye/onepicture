using System;
using onepicture.page;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Navigation;
using System.Net.NetworkInformation;
using Windows.UI.Xaml.Media;
using Windows.UI;
using Windows.UI.Text;
using static onepicture.homeimageclass;
using Windows.UI.Xaml.Media.Imaging;
using System.Threading.Tasks;
using Windows.Storage.Pickers;
using Windows.Graphics.Imaging;
using System.Collections.Generic;
using Windows.Storage;
using System.Runtime.InteropServices.WindowsRuntime;
using Windows.Graphics.Display;
using Windows.UI.Xaml.Media.Animation;
using onepicture.cs;

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
            NavigationCacheMode = NavigationCacheMode.Required;
            oneborder.Visibility = Visibility.Collapsed;

        }

    
            public int setting3 { get; set; }
            public void setting2(int set)
            {
              setting3 = set;
                
            }

        public static BitmapSource  dy { get; set; }
       
        protected override async void OnNavigatedTo(NavigationEventArgs e)
        { 
            

            base.OnNavigatedTo(e);
         //   await backimage.Blur(duration: 10, delay: 0, value: 10).StartAsync();
            //var propertyDesc = e.Parameter as PropertyDescriptor;



            //if (propertyDesc != null)

            //{

            //    DataContext = propertyDesc.Expando;

            //}
            home_image_pixiv.Stretch = Stretch.Uniform ; 
            if (NetworkInterface.GetIsNetworkAvailable())
            {                                      
                 RootObject1 homeimagepixiv = await goimage1();
               if (home_image_pixiv ==null)
                {
                   // ProgressBar.Visibility = Visibility.Visible;

                  //  Progressrun.Visibility = Visibility.Visible ;
                }
               else 
                {
                    Progressrun.IsActive = false;
                }
                if (homeimagepixiv != null )
                {

                  BitmapImage homepixiv = new BitmapImage(new Uri(homeimagepixiv.p_ori));
                cc_text.FontSize = 14;
                cc_text.Text = "宽:"+ homeimagepixiv.p_ori_width + "--高："+ homeimagepixiv.p_ori_hight;
                
                home_image_pixiv.Source = homepixiv;
                   
                    BitmapSource soure_1 = homepixiv ;
                dy = soure_1;
                     if (homepixiv != null)
                {                
                    storyboardRectangle.Begin();
                }
               
              }

  /*             
                if (home_image_pixiv.Source != null)
                {
                    await Task.Delay(1500);
                    border1.Visibility = Visibility.Visible;
                }
                else
                {
                   border1.Visibility = Visibility.Collapsed ;
                }*/
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
                    oneborder.Visibility = Visibility.Collapsed;
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
                oneborder.Visibility = Visibility.Collapsed;
                base.Frame.Navigate(typeof(seting), null , new SuppressNavigationTransitionInfo());
                mynemu.IsPaneOpen = !mynemu.IsPaneOpen;
               
            }
        }
     
        public void hanbao_Click(object sender, RoutedEventArgs e)
        {
            mynemu.IsPaneOpen = !mynemu.IsPaneOpen;
        }

        private void Pivot_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            home_page.Content = "首页";
            home_page.FontSize = 18;
   
            home_page.Foreground = new SolidColorBrush(Color.FromArgb(225, 213, 213, 216));
            fenlei_page.Content = "分类";
            fenlei_page.FontSize = 18;
            fenlei_page.Foreground = new SolidColorBrush(Color.FromArgb(225, 213, 213, 216));

            switch (pivot.SelectedIndex)
            {
                case 0:
                    home_page.FontSize = 18;
                    fenlei_page.FontWeight = FontWeights.ExtraLight;
                    home_page.FontWeight = FontWeights.Bold;
                    home_page.Foreground = new SolidColorBrush(Color.FromArgb(255, 255, 255, 255));
                    break;
                case 1:
                    fenlei_page.FontSize = 18;
                    home_page.FontWeight = FontWeights.ExtraLight;
                    fenlei_page.FontWeight = FontWeights.Bold;
                    fenlei_page.Foreground = new SolidColorBrush(Color.FromArgb(255, 255, 255, 255));
                    break;
            }
        }

        private void home_page_Click(object sender, RoutedEventArgs e)
        {
            pivot.SelectedIndex = 0;
            pivot.SelectedItem = pivot.Items[0];
        }

        private void fenlei_page_Click(object sender, RoutedEventArgs e)
        {
            pivot.SelectedIndex = 1;
            pivot.SelectedItem = pivot.Items[1];
        }

        private void twoborder_Tapped(object sender, TappedRoutedEventArgs e)
        {
            oneborder.Visibility = Visibility.Visible;
        }

        public void random()
        {
            Random ran = new Random();
   //         intRandKey = ran.Next(1,10);
        }

     
        //下载图片
        private async void AppBarButton_Click(object sender, RoutedEventArgs e)
        {
            RootObject1 myimage = await homeimageclass.goimage1();
            var saveFile = new FileSavePicker();
            saveFile.SuggestedStartLocation = PickerLocationId.PicturesLibrary; //下拉列表的文件类型
            string filename = "文件类型" ;
            saveFile.FileTypeChoices.Add(filename, new List<string>() { ".png", ".jpg", ".jpeg", ".bmp" }); //文件命名，图片+数字自加。。。有机会换成获取api返回的id试试

            string filenam = myimage.p_mid;
           
            saveFile.SuggestedFileName = filenam;
            StorageFile sFile = await saveFile.PickSaveFileAsync();

            if (sFile != null)
            {
                // 在用户完成更改并调用CompleteUpdatesAsync之前，阻止对文件的更新，此方法参考了http://blog.csdn.net/csdn_ergo/article/details/51281093的博客
                CachedFileManager.DeferUpdates(sFile);
                //image控件转换图像
                RenderTargetBitmap renderTargerBitemap = new RenderTargetBitmap();
                //传入image控件
                await renderTargerBitemap.RenderAsync(home_image_pixiv);

                //调用模态框
              //  await ModalProgressDig.ShowAsync();
                var progressTask = ModalProgressDig.ShowAsync();
                randomclass dd = new randomclass();
                dd.randome();
                dd.stringzifu();
                contenttext.Text = dd.zif;         
               // dialogimage.Source = ne (dd.imageuri);
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
                await Task.Delay(4500);
               
                progressTask.Cancel();
                ModalProgressDig.Hide();
            }
            else
            {
                
            }

        }

      
    }
}

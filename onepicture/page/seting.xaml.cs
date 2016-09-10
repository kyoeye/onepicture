using onepicture.cs;
using Windows.ApplicationModel.DataTransfer;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Media.Animation;
using Windows.UI.Xaml.Navigation;
using static onepicture.MainPage;


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
            var frame = new Frame();
            frame.ContentTransitions = new TransitionCollection();
            frame.ContentTransitions.Add(new NavigationThemeTransition());

        }


        /*
                public static  void shengliukaiguan_Toggled(object sender, Windows.UI.Xaml.RoutedEventArgs e)
                {
                    var toggle = sender as ToggleSwitch;
                    //  shengliukaiguan diaoyong = new shengliukaiguan();
                    if (toggle.IsOn)
                    {
                        MainPage setingclass = new MainPage();
                        setingclass.setting2(1);
                       // shengliukaiguan diaoyong = new shengliukaiguan();
                        //  diaoyong.fangfa(1);
                     //  int a = 1;
                      //  diaoyong.On = a;
                        //      fresh_Click kk = new fresh_Click();
                    }
                    else
                    {
                       // shengliukaiguan diaoyong = new shengliukaiguan();
                        //   diaoyong.fangfa(2);
                      //  int b = 2;
                    //    diaoyong.On = b;
                    //
                    }

                }
                */
        private void shengliu_kaiguan_Toggled(object sender, Windows.UI.Xaml.RoutedEventArgs e)
        {
            var toggle = sender as ToggleSwitch;
          
            if (toggle.IsOn)
            {
                
            }
        }

        private void qqclick_Click(object sender, Windows.UI.Xaml.RoutedEventArgs e)
        {
            string text = (string)qqclick.Content;
            /*用了数据绑定的呀  先找控件  找到控件就找到内容了*/
            DataPackage dp = new DataPackage();
            dp.SetText(text);
            Clipboard.SetContent(dp);
            qqclick.Content = "已复制到剪贴板，请转至qq粘贴搜索";
        }
    }
}

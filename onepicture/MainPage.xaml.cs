using onepicture.page;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Input;

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
            myframe.Navigate(typeof(oneimage));
            ManipulationCompleted += The_ManipulationCompleted;//订阅手势滑动结束后的事件
            ManipulationDelta += The_ManipulationDelta;//订阅手势滑动事件
        }

        double x = 0;//用来接收手势水平滑动的长度

       
          
    

        private void The_ManipulationDelta(object sender, ManipulationDeltaRoutedEventArgs e)//手势滑动中
        {
            x += e.Delta.Translation.X;//将滑动的值赋给x
        }

        private void The_ManipulationCompleted(object sender, ManipulationCompletedRoutedEventArgs e)//手势滑动结束
        {
            if (x > 200)//判断滑动的距离是否符合条件
            {
                mynemu.IsPaneOpen = true;//打开汉堡菜单
            }
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

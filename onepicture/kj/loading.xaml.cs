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
using Windows.UI.Xaml.Navigation;

// The User Control item template is documented at http://go.microsoft.com/fwlink/?LinkId=234236

namespace onepicture.kj
{
    public sealed partial class loading : UserControl
    {
        public loading()
        {
            this.InitializeComponent();
            randome();
            stringzifu();
            textloading.Text = zif;
        }

        public int int1;
        public string zif;
        //   public ImageSource  imageuri;
        public void randome()
        {
            Random rand = new Random();
            int1 = rand.Next(1, 10);
        }

        public void stringzifu()
        {

            if (int1 == 1)
            {
                zif = "正在加载";
                //   imageuri = new ImageSource ("ms-appx-file://image/70742a5645f23e213bc03be44dca3501.jpg");
            }

            else if (int1 == 2)
            {
                //    imageuri = ("ms-appx-file://image/70742a5645f23e213bc03be44dca3501.jpg";
                zif = "坐和放宽";
            }

            else if (int1 == 3)
            {
                zif = "远程呼叫交易对象";
                //   imageuri = "ms-appx-file://image/70742a5645f23e213bc03be44dca3501.jpg";
            }
            else if (int1 == 3)
            {
                zif = "正在和萌豚娘看电视";

            }
            else if (int1 == 4)
                zif = "你确定你的网没问题？";
            else if (int1 == 5)
                zif = "正在加载";
            else if (int1 == 6)
                zif = "正在加载";
            else if (int1 == 7)
                zif = "正在加载";
            else if (int1 == 8)
                zif = "正在加载";
            else if (int1 == 9)
                zif = "兄弟，雪碧";
            else if (int1 == 10)
                zif = "正在加载";
        }

       
     
    }
}

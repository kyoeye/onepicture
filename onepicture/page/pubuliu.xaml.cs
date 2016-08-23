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

// “空白页”项模板在 http://go.microsoft.com/fwlink/?LinkId=234238 上有介绍

namespace onepicture.page
{
    /// <summary>
    /// 可用于自身或导航至 Frame 内部的空白页。
    /// </summary>
    public sealed partial class pubuliu : Page
    {
        public pubuliu()
        {
            this.InitializeComponent();
        }

        //设定 <see cref="HLib.Controls.VirtualizingPanel"/> 的栈布局个数,最小值为1. 瀑布流实现来自http://blog.higan.me/uwp-control-development-02/
        public int StatckCount
        {
            get { return (int)GetValue(StatckCountProperty); }
            set { SetValue(StatckCountProperty, value); }
        }
        public static readonly DependencyProperty StatckCountProperty =
            DependencyProperty.Register("StatckCount", typeof(int),
              typeof (VirtualizingPanel),new PropertyMetadata (1 ,RequestArrange));
        /// <summary>
        /// 设定 <see cref="HLib.Controls.VirtualizingPanel"/> 的栈布局的间距.tatckSpacing 属性控制了每个 Stack 之间的距离
        /// </summary>
        public Double StatckSpacing
        {
            get { return (Double)GetValue(StatckSpacingProperty); }
            set { SetValue(StatckSpacingProperty, value); }
        }

        public static readonly DependencyProperty StatckSpacingProperty =
                DependencyProperty.Register("StatckSpacing", typeof(Double), 
                    typeof(VirtualizingPanel), new PropertyMetadata(10, RequestArrange));
        /// <summary>
        /// 设定 <see cref="HLib.Controls.VirtualizingPanel"/> 的子元素的间距.
        /// </summary>
        public Double ItemsSpacing
        {
            get { return (Double)GetValue(ItemsSpacingProperty); }
            set { SetValue(ItemsSpacingProperty, value); }
        }

        public static readonly DependencyProperty ItemsSpacingProperty =
                DependencyProperty.Register("ItemsSpacing", typeof(Double),
                    typeof(VirtualizingPanel), new PropertyMetadata(10, RequestArrange));
       
        /// <summary>
        /// 设定 <see cref="HLib.Controls.VirtualizingPanel"/> 的布局方向.
        /// </summary>
        public Orientation Orientation
        {
            get { return (Orientation)GetValue(OrientationProperty); }
            set { SetValue(OrientationProperty, value); }
        }

        public static readonly DependencyProperty OrientationProperty =
                DependencyProperty.Register("Orientation", typeof(Orientation),
                    typeof(VirtualizingPanel),
                    new PropertyMetadata(Windows.UI.Xaml.Controls.Orientation.Vertical, RequestArrange));
        ///  Orientation 属性可以设定我们面板的布局方向, 这样我们就得到了一个支持设定多列/行,支持设定元素间距,支持横向与纵向排版的瀑布流面板了.

        /// <summary>
        /// 请求重新测量与布局面板,InvalidateMeasure 方法和 InvalidateArrange 方法的调用会导致该对象的布局测量失效,请求重新测量.
        /// </summary>
        private static void RequestArrange(DependencyObject d, DependencyPropertyChangedEventArgs e)
        {
            (d as VirtualizingPanel).InvalidateMeasure();
            (d as VirtualizingPanel).InvalidateArrange();
        }
        //go,go,go
        /// <summary>
        /// 测量面板需要的空间
        /// </summary>
        protected override Size MeasureOverride(Size availableSize)
        {
            var measure = base.MeasureOverride(availableSize);

            double itemFixed = 0;
            Size requestSize = Size.Empty;
            //对网络返回的图片重写测量
            if (Double.IsInfinity(availableSize.Width))
            {
                if (Double.IsInfinity(availableSize.Height))
                {
                    return new Size((this.DataContext as PostViewModel).Post.PreviewImageWidth, (this.DataContext as PostViewModel).Post.PreviewImageHeight);
                }
                else
                {
                    return MathHelper.ResizeWithHeight((this.DataContext as PostViewModel).Post.PreviewImageWidth, (this.DataContext as PostViewModel).Post.PreviewImageHeight, availableSize.Height);
                }
            }
            else
            {
                if (Double.IsInfinity(availableSize.Height))
                {
                    return MathHelper.ResizeWithWidth((this.DataContext as PostViewModel).Post.PreviewImageWidth, (this.DataContext as PostViewModel).Post.PreviewImageHeight, availableSize.Width);
                }
                else
                {
                    double scale = availableSize.Width / availableSize.Height;
                    if ((DataContext as PostViewModel).Post.PreviewImageHeight * scale > (DataContext as PostViewModel).Post.PreviewImageWidth)
                    {
                        return MathHelper.ResizeWithHeight((this.DataContext as PostViewModel).Post.PreviewImageWidth, (this.DataContext as PostViewModel).Post.PreviewImageHeight, availableSize.Height);
                    }
                    else
                    {
                        return MathHelper.ResizeWithWidth((this.DataContext as PostViewModel).Post.PreviewImageWidth, (this.DataContext as PostViewModel).Post.PreviewImageHeight, availableSize.Width);
                    }
                }
            }
            //判断面板的布局类型,是横向布局还是纵向布局
            if (Orientation == Orientation.Vertical)
            {
                //纵向布局

                //创建一个列表记录所有 Stack 的长度
                List<Double> offsetY = new Double[StatckCount].ToList();

                //计算一个 Item 的固定边长度,纵向布局的话是宽固定
                itemFixed = (availableSize.Width - StatckSpacing * (StatckCount - 1)) / StatckCount;

                requestSize = new Size()
                {
                    //设定需要的空间的宽,一般是提供多少要多少
                    Width = availableSize.Width
                };

                //遍历 Children 来测量长度
                foreach (var item in this.Children)
                {
                    //寻找最短的 Stack ,将新的 Item 分配到这个 Stack
                    int minIndex = offsetY.IndexOf(offsetY.Min());
                    //向 Item 发送测量请求,让 Item 测量自己需要的空间
                    item.Measure(new Size(itemFixed, double.PositiveInfinity));
                    //测量结果保存在 DesiredSize 属性里面
                    var itemRequestSize = item.DesiredSize;
                    //将这个 Stack 的长度加上新的 Item 的长度和 Item 的间隙
                    offsetY[minIndex] += itemRequestSize.Height + ItemsSpacing;
                }
                //寻找最长的 Stack,这个 Stack 就是面板需要的高度
                requestSize.Height = offsetY.Max();
            }
            else
            {
                //横向布局,内容大同小异,区别就是把长变成了宽

                List<Double> offsetX = new Double[StatckCount].ToList();

                //Item 的固定边为长
                itemFixed = (availableSize.Height - StatckSpacing * (StatckCount - 1)) / StatckCount;

                requestSize = new Size()
                {
                    Height = availableSize.Height
                };

                foreach (var item in this.Children)
                {
                    int minIndex = offsetX.IndexOf(offsetX.Min());
                    item.Measure(new Size(double.PositiveInfinity, itemFixed));
                    var itemRequestSize = item.DesiredSize;
                    offsetX[minIndex] += itemRequestSize.Width;
                }
                requestSize.Width = offsetX.Max();
            }


            //返回我们面板需要的大小
            return requestSize;

        }
    }
}

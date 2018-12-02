using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.UI.ViewManagement;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Media.Imaging;
using Windows.UI.Xaml.Navigation;

// The Blank Page item template is documented at https://go.microsoft.com/fwlink/?LinkId=234238

namespace SilverFrame
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class ImageView : Page
    {
        public ImageView()
        {
            this.InitializeComponent();
            ApplicationView.GetForCurrentView().TryEnterFullScreenMode();
            RotatingImage.Source = new BitmapImage(new Uri("ms-appx:///Assets/images/test.JPG"));
            handleShow();
            //RotatingImage.
        }

        public void handleShow()
        {
            //using (var client = new System.Net.WebClient())
            //{
            //    client.DownloadFile("http://example.com/file/song/a.mpeg", "a.jpg");
            //}


            RotatingImage.Source = new BitmapImage(new Uri("ms-appx:///Assets/images/test2.jpg"));
            //BitmapImage bi = new BitmapImage();
            //bi.UriSource = new Uri(@"ms-appx:/Assets/images/test2.jpg", UriKind.RelativeOrAbsolute);

            //Image temp = new Image();
            //temp.Source = bi;
            //RotatingImage = temp;
            //bool pause = true;

        }
    }
}

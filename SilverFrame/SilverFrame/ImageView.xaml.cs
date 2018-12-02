using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.Storage;
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
            //handleShow();
            //RotatingImage.
        }

        public void handleShow()
        {
            using (var client = new System.Net.WebClient())
            //{
            //    client.DownloadFile("https://lh3.googleusercontent.com/lr/AJ-EwvnYqclSka1f8J-8b1Pooj-8B3JciYhkvI8bjdIakItBv0oMoVu5T7lBXksXdgwmHaMNZED5thJH56UAIGszJRESSkHeltiRgaQ3jf9017W6-ViiYK6dHTeHDZUakfGjiN3ji0RKGdNEZ1xFWk4bVhmWyFAFfN7R0ADq-ig0qL7Lm5oVadKGd4ujYN1rUo22tOsIV4B7BmhlSHuXiFgTvldV2gaxcIpJVY5LVIZkxv1abEuheizW_HNlDjqavdcG3bbzi3xLakcTmqn8frBsOiRD1Q6irIPqzy1t44xMWvCmGec3_IN2jRXd7uABzcdSJPZgdR8SnE5EdlOgDBbznNwl8gqoSfcMOiXz4-NHkK0cYv2_YjyqrzRH7jzxkMuV_9U9r3rpNWb23FZzoEd6eAGZpPi0nlIqAPaPQGW23YA21jMVwbOlj97-tLVerUgcZezCzOGjKzWEdWBrDoTD2gMvAMcAekqNQXHFPBOmUFOS0FYpnAMxh7mOBEUQfobcNXktTtC2KNhZwnJeXm1y03u3KkIpf3C_QBSTUNcFQ5Wld7RC9nR4JXDYkf-2fBvwI9OloZTQgnYhmsC5qMIJIE48XbPYkS_IpXXuFlU-oVOt79aVhxnLC7pRMVy5Jd5us56pO_ytk_wwKb_tANBm1BKC2A7wuY8qcHuxT5MkcW-7yBKHxW6cWuQuqSpmpQwUWfQJXC1gXIC7v5n4P4HFQmgrz7daYbTlc-fNPf-6UiqmBKa8Qa8-itQT7rGaXPbHz57J5eviPqkMubmGZzqYfoaJgaroftGanJAsOYmN-KJkNBuPkaE", @"C://SilverFrame/a.jpg");
            //}


            RotatingImage.Source = new BitmapImage(new Uri("ms-appx:///Assets/images/test2.jpg"));
            //BitmapImage bi = new BitmapImage();
            //bi.UriSource = new Uri(@"ms-appx:/Assets/images/test2.jpg", UriKind.RelativeOrAbsolute);

            //Image temp = new Image();
            //temp.Source = bi;
            //RotatingImage = temp;
            //bool pause = true;

        }

        protected async override void OnNavigatedTo(NavigationEventArgs e)
        {
            // Get the Pictures library
            Windows.Storage.StorageFolder picturesFolder =
                Windows.Storage.KnownFolders.PicturesLibrary;
            IReadOnlyList<StorageFolder> folders =
                await picturesFolder.GetFoldersAsync();

            // Process file folders
            foreach (StorageFolder folder in folders)
            {
                // Get and process files in folder
                IReadOnlyList<StorageFile> fileList = await folder.GetFilesAsync();
                foreach (StorageFile file in fileList)
                {
                    Windows.UI.Xaml.Media.Imaging.BitmapImage bitmapImage =
                        new Windows.UI.Xaml.Media.Imaging.BitmapImage();

                    // Open a stream for the selected file.
                    // The 'using' block ensures the stream is disposed
                    // after the image is loaded.
                    using (Windows.Storage.Streams.IRandomAccessStream fileStream =
                        await file.OpenAsync(Windows.Storage.FileAccessMode.Read))
                    {
                        // Set the image source to the selected bitmap.
                        Windows.UI.Xaml.Media.Imaging.BitmapImage bmi =
                            new Windows.UI.Xaml.Media.Imaging.BitmapImage();
                        bmi.SetSource(fileStream);

                        // Create an Image control.  
                        //Image img = new Image();
                        //img.Height = 50;
                        RotatingImage.Source = bmi;

                        // Add the Image control to the UI. 'imageGrid' is a
                        // VariableSizedWrapGrid declared in the XAML page.
                        //imageGrid.Children.Add(img);
                    }
                }
            }
        }
    }
}

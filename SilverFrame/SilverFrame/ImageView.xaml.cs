using Microsoft.Data.Sqlite;
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
            handleShowAsync();
            //RotatingImage.
        }

        public async System.Threading.Tasks.Task handleShowAsync()
        {
            Uri temp = new Uri("https://m.media-amazon.com/images/M/MV5BMTQ1OTM0NDM1NV5BMl5BanBnXkFtZTgwOTUxOTU2NzE@._V1_SY1000_CR0,0,707,1000_AL_.jpg");
            await ImageLoader.LoadImage(temp, "bob.jpg");

            //RotatingImage.Source = new BitmapImage(new Uri("ms-appx:///Assets/images/test2.jpg"));
            //BitmapImage bi = new BitmapImage();
            //bi.UriSource = new Uri(@"ms-appx:/Assets/images/test2.jpg", UriKind.RelativeOrAbsolute);

            //Image temp = new Image();
            //temp.Source = bi;
            //RotatingImage = temp;
            //bool pause = true;

        }

        //protected async override void OnNavigatedTo(NavigationEventArgs e)
        //{
        //    // Get the Pictures library
        //    Windows.Storage.StorageFolder picturesFolder =
        //        Windows.Storage.KnownFolders.PicturesLibrary;
        //    IReadOnlyList<StorageFolder> folders =
        //        await picturesFolder.GetFoldersAsync();


        //    using (SqliteConnection db =
        //                    new SqliteConnection("Filename=pictures.db"))
        //    {
        //        db.Open();

        //        SqliteCommand selectCommand = new SqliteCommand("SELECT* FROM table ORDER BY RANDOM() LIMIT 1;", db);
        //        .Parameters.AddWithValue("filePath", filePath);

        //        SqliteDataReader query = selectCommand.ExecuteReader();

        //        while (query.Read())
        //        {
        //            entries.Add(query.GetString(0));
        //        }

        //        db.Close();
        //    }

        //    // Process file folders
        //    foreach (StorageFolder folder in folders)
        //    {
        //        // Get and process files in folder
        //        IReadOnlyList<StorageFile> fileList = await folder.GetFilesAsync();
        //        foreach (StorageFile file in fileList)
        //        {
        //            Windows.UI.Xaml.Media.Imaging.BitmapImage bitmapImage =
        //                new Windows.UI.Xaml.Media.Imaging.BitmapImage();

        //            // Open a stream for the selected file.
        //            // The 'using' block ensures the stream is disposed
        //            // after the image is loaded.
        //            using (Windows.Storage.Streams.IRandomAccessStream fileStream =
        //                await file.OpenAsync(Windows.Storage.FileAccessMode.Read))
        //            {
        //                // Set the image source to the selected bitmap.
        //                Windows.UI.Xaml.Media.Imaging.BitmapImage bmi =
        //                    new Windows.UI.Xaml.Media.Imaging.BitmapImage();
        //                bmi.SetSource(fileStream);

        //                // Create an Image control.  
        //                //Image img = new Image();
        //                //img.Height = 50;
        //                RotatingImage.Source = bmi;

        //                // Add the Image control to the UI. 'imageGrid' is a
        //                // VariableSizedWrapGrid declared in the XAML page.
        //                //imageGrid.Children.Add(img);
        //            }
        //        }
        //    }
        //}
    }
}

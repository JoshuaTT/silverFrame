using Microsoft.Data.Sqlite;
using SilverFrame.Model;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using System.Threading.Tasks;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.Storage;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Navigation;


// The Blank Page item template is documented at https://go.microsoft.com/fwlink/?LinkId=402352&clcid=0x409

namespace SilverFrame
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class MainPage : Page
    {
        public MainPage()
        {
            this.InitializeComponent();
            updateDatabase();
        }

        private void Info_Click(object sender, RoutedEventArgs e)
        {
            Frame.Navigate(typeof(AboutPage));
        }

        private void Page_Loaded(object sender, RoutedEventArgs e)
        {
           
        }

        //private void Add_Click(object sender, RoutedEventArgs e)
        //{
        //    using (var db = new SilverFrameContext())
        //    {
        //        var picture = new Picture { PicturePath = NewBlogUrl.Text };
        //        db.Pictures.Add(picture);
        //        db.SaveChanges();

        //        Pictures.ItemsSource = db.Pictures.ToList();
        //    }
        //}

        private async Task updateDatabase()
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

                    string fileType = file.FileType;

                    if (fileType == ".JPG" || fileType == ".PNG" || fileType == ".GIF")
                    {
                        string filePath = file.Path;
                        //Check if in database
                        List<String> entries = new List<string>();

                        using (SqliteConnection db =
                            new SqliteConnection("Filename=pictures.db"))
                        {
                            db.Open();

                            SqliteCommand selectCommand = new SqliteCommand("SELECT PicturePath FROM Pictures WHERE PicturePath = @filePath", db);
                            selectCommand.Parameters.AddWithValue("filePath", filePath);

                            

                            SqliteDataReader query = selectCommand.ExecuteReader();

                            while (query.Read())
                            {
                                entries.Add(query.GetString(0));
                            }

                            db.Close();
                        }

                        if (entries.Count() == 0)
                        {
                            using (SqliteConnection db = new SqliteConnection("Filename=pictures.db"))
                            {
                                db.Open();

                                SqliteCommand insertCommand = new SqliteCommand();
                                insertCommand.Connection = db;

                                bool include = true;
                                // Use parameterized query to prevent SQL injection attacks
                                insertCommand.CommandText = "INSERT INTO Pictures VALUES (NULL, @Path, NULL, @Include);";
                                insertCommand.Parameters.AddWithValue("@Path", filePath);
                                insertCommand.Parameters.AddWithValue("@Include", include);


                                insertCommand.ExecuteReader();

                                db.Close();
                            }
                        }

                       
                    }


                    // Open a stream for the selected file.
                    // The 'using' block ensures the stream is disposed
                    // after the image is loaded.
                    //using (Windows.Storage.Streams.IRandomAccessStream fileStream =
                    //    await file.OpenAsync(Windows.Storage.FileAccessMode.Read))
                    //{
                    //    // Set the image source to the selected bitmap.
                    //    //Windows.UI.Xaml.Media.Imaging.BitmapImage bmi =
                    //    //    new Windows.UI.Xaml.Media.Imaging.BitmapImage();
                    //    //bmi.SetSource(fileStream);

                    //    fileStream.

                    //    // Create an Image control.  
                    //    //Image img = new Image();
                    //    //img.Height = 50;
                    //    //this.RotatingImage.Source = bmi;

                    //    // Add the Image control to the UI. 'imageGrid' is a
                    //    // VariableSizedWrapGrid declared in the XAML page.
                    //    //imageGrid.Children.Add(img);
                    //}
                }
            }
        }

        private void Show_Click(object sender, RoutedEventArgs e)
        {
            Frame.Navigate(typeof(ImageView));
        }
    }
}

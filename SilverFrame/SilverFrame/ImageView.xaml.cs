using Microsoft.Data.Sqlite;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading;
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
using System.Threading.Tasks;


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

        private int currentPhotoID;
        private string currentPhotoPath = "";
        private string currentPhotoCaption = "";
        private bool currentPhotoInclude = true;
        private bool hasFocus;

        public async System.Threading.Tasks.Task handleShow()
        {
            //while (true)
            //{
                

                // Get the Pictures library
                Windows.Storage.StorageFolder picturesFolder =
                    Windows.Storage.KnownFolders.PicturesLibrary;
                IReadOnlyList<StorageFolder> folders =
                    await picturesFolder.GetFoldersAsync();


                using (SqliteConnection db =
                                new SqliteConnection("Filename=pictures.db"))
                {
                    db.Open();
                    do
                    {

                        SqliteCommand selectCommand = new SqliteCommand("SELECT * FROM Pictures ORDER BY RANDOM() LIMIT 1;", db);
                        SqliteDataReader query = selectCommand.ExecuteReader();

                        while (query.Read())
                        {
                            currentPhotoID = query.GetInt32(0);
                            currentPhotoPath = query.GetString(1);

                            if (!query.IsDBNull(2))
                                currentPhotoCaption = query.GetString(2);
                            else
                                currentPhotoCaption = "";
                            

                            currentPhotoInclude = query.GetBoolean(3);

                        }
                    }
                    while (currentPhotoInclude == false);
                    db.Close();
                }

                StorageFile currentFile = await picturesFolder.GetFileAsync(currentPhotoPath);
                Windows.Storage.Streams.IRandomAccessStream fileStream = await currentFile.OpenAsync(Windows.Storage.FileAccessMode.Read);
                Windows.UI.Xaml.Media.Imaging.BitmapImage bmi = new Windows.UI.Xaml.Media.Imaging.BitmapImage();
                bmi.SetSource(fileStream);
            captionBox.Text = currentPhotoCaption;
                RotatingImage.Source = bmi;
            CaptionSave.Focus(FocusState.Programmatic);
            successLabel.Visibility = Visibility.Collapsed;
            //Thread.Sleep(1500);

            //}

        }

       
        private void CaptionSave_PointerPressed(object sender, PointerRoutedEventArgs e)
        {


        }

        protected override void OnNavigatedTo(NavigationEventArgs e)
        {
            App.Current.IsIdleChanged += onIsIdleChanged;
        }

        protected override void OnNavigatedFrom(NavigationEventArgs e)
        {
            App.Current.IsIdleChanged -= onIsIdleChanged;
        }

        private void onIsIdleChanged(object sender, EventArgs e)
        {
            if (!hasFocus)
            {
                captionBox.Visibility = Visibility.Collapsed;
                CaptionSave.Visibility = Visibility.Collapsed;
            }

            System.Diagnostics.Debug.WriteLine($"IsIdle: {App.Current.IsIdle}");
        }

        private void Grid_PointerMoved(object sender, PointerRoutedEventArgs e)
        {
            captionBox.Visibility = Visibility.Visible;
            CaptionSave.Visibility = Visibility.Visible;
        }

        private void captionBox_GotFocus(object sender, RoutedEventArgs e)
        {
            hasFocus = true;
            successLabel.Visibility = Visibility.Collapsed;
        }

        private void captionBox_LostFocus(object sender, RoutedEventArgs e)
        {
            hasFocus = false;
        }

        private void CaptionSave_Click(object sender, RoutedEventArgs e)
        {

            string captionText = captionBox.Text;

            using (SqliteConnection db = new SqliteConnection("Data Source=pictures.db"))
            {
                db.Open();

                SqliteCommand insertCommand = new SqliteCommand();
                insertCommand.Connection = db;

                bool include = true;
                // Use parameterized query to prevent SQL injection attacks
                insertCommand.CommandText = "UPDATE Pictures Set Caption = @Caption Where PictureId = @id";
                insertCommand.Parameters.AddWithValue("@Caption", captionText);
                insertCommand.Parameters.AddWithValue("@id", currentPhotoID);


                insertCommand.ExecuteReader();

                db.Close();
            }

            successLabel.Visibility = Visibility.Visible;
        }

        private void RemoveButton_Click(object sender, RoutedEventArgs e)
        {
            using (SqliteConnection db = new SqliteConnection("Data Source=pictures.db"))
            {
                db.Open();

                SqliteCommand insertCommand = new SqliteCommand();
                insertCommand.Connection = db;

                bool include = true;
                // Use parameterized query to prevent SQL injection attacks
                insertCommand.CommandText = "UPDATE Pictures Set Include = @Include Where PictureId = @id";
                insertCommand.Parameters.AddWithValue("@Include", false);
                insertCommand.Parameters.AddWithValue("@id", currentPhotoID);


                insertCommand.ExecuteReader();

                db.Close();
            }
        }
    }
}

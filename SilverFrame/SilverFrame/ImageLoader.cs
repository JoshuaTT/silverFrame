using System;
using System.Diagnostics;
using System.IO;
using System.Net;
using System.Threading.Tasks;
using Windows.Storage;
using Windows.Storage.Streams;
using Windows.UI.Xaml.Media.Imaging;
using Windows.Web.Http;
using System.Runtime.InteropServices.WindowsRuntime;

public class ImageLoader
{
    public async static Task LoadImage(Uri uri, string filename)
    {
        Windows.Storage.StorageFolder picturesFolder =
                Windows.Storage.KnownFolders.PicturesLibrary;

        StorageFolder silverFramePictures = await picturesFolder.GetFolderAsync("SilverFrame");

        var coverpic_file = await silverFramePictures.CreateFileAsync(filename, CreationCollisionOption.GenerateUniqueName);

        try
        {
            HttpClient client = new HttpClient(); // Create HttpClient
            IBuffer bufferAbstract = await client.GetBufferAsync(uri); //client.GetByteArrayAsync(coverUrl); // Download file
            byte[] buffer = bufferAbstract.ToArray();
            using (Stream stream = await coverpic_file.OpenStreamForWriteAsync())
                stream.Write(buffer, 0, buffer.Length); // Save
        }
        catch(Exception e)
        {
            Console.WriteLine(e);
        }
    }
}
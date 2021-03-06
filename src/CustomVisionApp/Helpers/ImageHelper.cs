﻿using System.IO;
using System.Windows.Media.Imaging;

namespace CustomVisionApp.Helpers
{
    public static class ImageHelper
    {
        public static BitmapImage ToImage(byte[] imageInBytes)
        {
            using (var memoryStream = new MemoryStream(imageInBytes))
            {
                return ToImage(memoryStream);
            }
        }

        public static BitmapImage ToImage(Stream stream)
        {
            var image = new BitmapImage();

            image.BeginInit();
            image.CacheOption = BitmapCacheOption.OnLoad;
            image.StreamSource = stream;
            image.EndInit();

            return image;
        }

        public static byte[] ToImage(BitmapImage bitmapImage)
        {
            var encoder = new JpegBitmapEncoder();
            encoder.Frames.Add(BitmapFrame.Create(bitmapImage));
            using (MemoryStream ms = new MemoryStream())
            {
                encoder.Save(ms);
                return ms.ToArray();
            }
        }
    }
}

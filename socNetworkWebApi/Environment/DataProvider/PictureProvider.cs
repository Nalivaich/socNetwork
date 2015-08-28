using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Web;

namespace socNetworkWebApi.Environment.DataProvider
{
    public static class PictureProvider
    {

        public static void SaveMiniatureImage(string baseImagePath, string newImagePath, int maxPixels)
        {

            Image image = Image.FromFile(baseImagePath);
            Size thumbnailSize = GetThumbnailSize(image, maxPixels);

            Image thumbnail = image.GetThumbnailImage(thumbnailSize.Width,
                        thumbnailSize.Height, null, IntPtr.Zero);
            thumbnail.Save(newImagePath);
            image.Dispose();
        }

        public static Size GetThumbnailSize(Image original, int maxPixels)
        {
            
            // Width and height.
            int originalWidth = original.Width;
            int originalHeight = original.Height;

            // Compute best factor to scale entire image based on larger dimension.
            double factor;
            if (originalWidth > originalHeight)
            {
                factor = (double)maxPixels / originalWidth;
            }
            else
            {
                factor = (double)maxPixels / originalHeight;
            }

            // Return thumbnail size.
            return new Size((int)(originalWidth * factor), (int)(originalHeight * factor));
        }

    }
}
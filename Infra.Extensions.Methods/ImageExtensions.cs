using System;
using System.Drawing;
using System.Drawing.Imaging;
using System.IO;

namespace Infra.Extensions.Methods
{
    public static class ImageExtensions
    {
        public static byte[] ToByteArray(this Image image, ImageFormat format = null)
        {
            format = format is null ? ImageFormat.Bmp : format;

            var stream = new MemoryStream();
            new Bitmap(image).Save(stream, format);
            stream.Position = 0;
            return stream.ToArray();
        }
        public static Image ToImage(this byte[] imageBytes)
        {
            using var ms = new MemoryStream(imageBytes);
            return Image.FromStream(ms);
        }
        public static Image Base64ToImage(this string base64String)
        {
            byte[] imageBytes = Convert.FromBase64String(base64String);

            using var ms = new MemoryStream(imageBytes, 0, imageBytes.Length);
            return Image.FromStream(ms, true);
        }
    }
}

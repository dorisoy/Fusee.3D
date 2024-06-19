using System;

namespace Fusee.Base.Common
{
    // This class is a bit awkward. It tries to solve the following things:
    // - IImageData instances must expose line-wise contiguous portions of internal memory where
    //   requesting objects can copy pixel data from.
    // - C# does not allow to simply wrap a byte[] object around existing memory without first
    //   creating such an object and copy the memory. (In C# 7.3 there is a feature called AsSpan, for now we must use ScanLine.)
    // - We could consider returning a pointer (byte*) but this would involve other headache, including
    //   unsafe code and extra-coding for JSIL.
    /// <summary>
    /// Provides view into a portion (= one horizontal line) of a byte[] dataSource of an <see cref="IImageData"/> instance.
    /// </summary>
    public class ScanLine
    {
        /// <summary>
        /// Constructor to initialize one horizontal ScanLine inside a byte[] dataSource, beginning at offset in bytes.
        /// </summary>
        /// <param name="dataSource">The dataSource array, usually the byte array of an IImageData.</param>
        /// <param name="offset">Offset in bytes (= the ScanLine begins at offset bytes inside dataSource).</param>
        /// <param name="width">Width of the ScanLine in pixels.</param>
        /// <param name="pixelFormat">ImagePixelFormat of the dataSource.</param>
        public ScanLine(byte[] dataSource, int offset, int width, ImagePixelFormat pixelFormat)
        {
            DataSource = dataSource;
            Offset = offset;
            Width = width;
            PixelFormat = pixelFormat;
        }

        /// <summary>
        /// The Data source byte array of this ScanLine.
        /// </summary>
        public byte[] DataSource { get; }  // The start of some internal array where the data comes from

        /// <summary>
        /// An Offset (in bytes) to add to the index to the first pixel of the requested line
        /// </summary>
        public int Offset { get; }


        /// <summary>
        /// Width of the ScanLine in pixels.
        /// </summary>
        public int Width { get; }

        /// <summary>
        /// Returns the byes per pixel with respect to the <see cref="PixelFormat"/>.
        /// </summary>
        /// <value>
        /// The number of bytes each pixel consists of.
        /// </value>
        /// <exception cref="System.ArgumentOutOfRangeException">For unknown pixel formats.</exception>
        public int BytesPerPixel
        {
            get
            {
                return PixelFormat.ColorFormat switch
                {
                    ColorFormat.Intensity => 1,
                    ColorFormat.Depth16 => 2,
                    ColorFormat.RGB => 3,
                    ColorFormat.Depth24 => 3,
                    ColorFormat.uiRgb8 => 3,
                    ColorFormat.RGBA => 4,
                    // SLIRP
                    // ColorFormat.BGRA => 4,
                    // ColorFormat.YUV420 => 4,
                    // SLIRP close
                    ColorFormat.fRGB16 => 6,
                    ColorFormat.fRGBA16 => 8,
                    ColorFormat.fRGB32 => 12,
                    ColorFormat.iRGBA32 => 16,
                    ColorFormat.fRGBA32 => 16,
                    _ => throw new ArgumentOutOfRangeException(),
                };
            }
        }


        /// <summary>
        /// Describes the PixelFormat of the ScanLine's data source.
        /// </summary>
        public ImagePixelFormat PixelFormat { get; }


        /// <summary>
        /// Copies the bytes that make up this ScanLine from the dataSource.
        /// </summary>
        /// <returns>Returns a byte array that makes up this ScanLine.</returns>
        public byte[] GetScanLineBytes()
        {
            int bytesPerLine = Width * BytesPerPixel;
            byte[] lineByteBuffer = new byte[bytesPerLine];
            Buffer.BlockCopy(DataSource, Offset, lineByteBuffer, 0, bytesPerLine);

            return lineByteBuffer;
        }
    }
}
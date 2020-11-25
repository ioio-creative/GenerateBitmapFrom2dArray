using System;
using System.Drawing;
using System.Drawing.Imaging;

using System.IO;

namespace GenerateBitmapFrom2dArray
{
    public class Program
    {
        private const string outputImageFileName = "marker_5.jpg";
        private const string outputTextFileName = "marker_5.txt";
        private const int cellSize = 50;

        private static double[,] array2D_1 = new double[,]
        {
            { 1, 1, 1, 1, 1, 1, 1, 1, 1 },
            { 1, 0, 0, 0, 0, 0, 0, 0, 1 },
            { 1, 0, 1, 0, 0, 0, 0, 0, 1 },
            { 1, 0, 0, 1, 1, 1, 0, 0, 1 },
            { 1, 0, 1, 0, 1, 1, 1, 0, 1 },
            { 1, 0, 1, 0, 1, 1, 1, 0, 1 },
            { 1, 0, 1, 0, 1, 1, 1, 0, 1 },
            { 1, 0, 0, 0, 0, 0, 0, 0, 1 },
            { 1, 1, 1, 1, 1, 1, 1, 1, 1 }
        };

        private static double[,] array2D_2 = new double[,]
        {
            { 1, 1, 1, 1, 1, 1, 1, 1, 1 },
            { 1, 0, 0, 0, 0, 0, 0, 0, 1 },
            { 1, 0, 1, 0, 1, 1, 0, 0, 1 },
            { 1, 0, 0, 1, 0, 0, 1, 0, 1 },
            { 1, 0, 1, 1, 1, 0, 1, 0, 1 },
            { 1, 0, 0, 1, 0, 0, 0, 0, 1 },
            { 1, 0, 1, 1, 1, 1, 1, 0, 1 },
            { 1, 0, 0, 0, 0, 0, 0, 0, 1 },
            { 1, 1, 1, 1, 1, 1, 1, 1, 1 }
        };

        private static double[,] array2D_3 = new double[,]
        {
            { 1, 1, 1, 1, 1, 1, 1, 1, 1 },
            { 1, 0, 0, 0, 0, 0, 0, 0, 1 },
            { 1, 0, 0, 1, 1, 0, 1, 0, 1 },
            { 1, 0, 1, 0, 0, 1, 0, 0, 1 },
            { 1, 0, 1, 0, 1, 0, 1, 0, 1 },
            { 1, 0, 0, 1, 0, 0, 1, 0, 1 },
            { 1, 0, 1, 0, 1, 1, 0, 0, 1 },
            { 1, 0, 0, 0, 0, 0, 0, 0, 1 },
            { 1, 1, 1, 1, 1, 1, 1, 1, 1 }
        };

        private static double[,] array2D_4 = new double[,]
        {
            { 1, 1, 1, 1, 1, 1, 1, 1, 1 },
            { 1, 0, 0, 0, 0, 0, 0, 0, 1 },
            { 1, 0, 1, 0, 1, 1, 0, 0, 1 },
            { 1, 0, 0, 0, 0, 0, 1, 0, 1 },
            { 1, 0, 1, 0, 1, 0, 0, 0, 1 },
            { 1, 0, 0, 0, 0, 0, 1, 0, 1 },
            { 1, 0, 0, 1, 1, 1, 0, 0, 1 },
            { 1, 0, 0, 0, 0, 0, 0, 0, 1 },
            { 1, 1, 1, 1, 1, 1, 1, 1, 1 }
        };

        private static double[,] array2D_5 = new double[,]
        {
            { 1, 1, 1, 1, 1, 1, 1, 1, 1 },
            { 1, 0, 0, 0, 0, 0, 0, 0, 1 },
            { 1, 0, 0, 0, 0, 1, 1, 0, 1 },
            { 1, 0, 1, 1, 0, 1, 0, 0, 1 },
            { 1, 0, 0, 1, 1, 1, 1, 0, 1 },
            { 1, 0, 1, 1, 0, 0, 0, 0, 1 },
            { 1, 0, 0, 0, 0, 1, 0, 0, 1 },
            { 1, 0, 0, 0, 0, 0, 0, 0, 1 },
            { 1, 1, 1, 1, 1, 1, 1, 1, 1 }
        };

        private static void Main(string[] args)
        {
            double[,] enlargedArray2D = GetEnlargedArray2D(array2D_5);
            PrintArray2DToFile(enlargedArray2D, outputTextFileName);
            Bitmap bitmap_1 = ToBitmap(enlargedArray2D);
            bitmap_1.Save(outputImageFileName, ImageFormat.Jpeg);
        }

        private static double[,] GetEnlargedArray2D(double[,] input)
        {
            int inputSize = Convert.ToInt32(Math.Sqrt(input.Length));

            int resultSize = cellSize * inputSize;
            double[,] output = new double[resultSize, resultSize];

            for (int row = 0; row < inputSize; row++)
            {
                for (int col = 0; col < inputSize; col++)
                {
                    double cellValue = input[row, col];

                    for (int r = row * cellSize; r < (row + 1) * cellSize; r++)
                    {
                        for (int c = col * cellSize; c < (col + 1) * cellSize; c++)
                        {
                            output[r, c] = cellValue;
                        }
                    }
                }
            }           

            return output;
        }

        private static void PrintArray2DToFile(double[,] input, string fileName)
        {
            int inputSize = Convert.ToInt32(Math.Sqrt(input.Length));

            using (StreamWriter file = new StreamWriter(fileName))
            {
                for (int r = 0; r < inputSize; r++)
                {
                    for (int c = 0; c < inputSize; c++)
                    {
                        file.Write(input[r, c] + ", ");
                    }

                    file.Write(Environment.NewLine);
                }
            }
        }


        // https://stackoverflow.com/questions/13511661/create-bitmap-from-double-two-dimentional-array
        private unsafe static Bitmap ToBitmap(double[,] rawImage)
        {
            int width = rawImage.GetLength(1);
            int height = rawImage.GetLength(0);

            Bitmap Image = new Bitmap(width, height);
            BitmapData bitmapData = Image.LockBits(
                new Rectangle(0, 0, width, height),
                ImageLockMode.ReadWrite,
                PixelFormat.Format32bppArgb
            );
            ColorARGB* startingPosition = (ColorARGB*)bitmapData.Scan0;


            for (int i = 0; i < height; i++)
                for (int j = 0; j < width; j++)
                {
                    double color = rawImage[i, j];
                    byte rgb = (byte)(color * 255);

                    ColorARGB* position = startingPosition + j + i * width;
                    position->A = 255;
                    position->R = rgb;
                    position->G = rgb;
                    position->B = rgb;
                }

            Image.UnlockBits(bitmapData);
            return Image;
        }

        public struct ColorARGB
        {
            public byte B;
            public byte G;
            public byte R;
            public byte A;

            public ColorARGB(Color color)
            {
                A = color.A;
                R = color.R;
                G = color.G;
                B = color.B;
            }

            public ColorARGB(byte a, byte r, byte g, byte b)
            {
                A = a;
                R = r;
                G = g;
                B = b;
            }

            public Color ToColor()
            {
                return Color.FromArgb(A, R, G, B);
            }
        }
    }
}
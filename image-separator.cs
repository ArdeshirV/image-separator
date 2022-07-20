// image-separator: Separate specified large-image into several readable image.
// Copyright (c) 2022 ArdeshirV@protonmail.com, Licensed under GPLv3+
using System;
using System.IO;
using System.Drawing;
using System.Windows.Forms;
using System.Drawing.Imaging;
//----------------------------------------------------------------------------------------
namespace ArdeshirV.Applications.ImageSeparator {
  public class Program {
    public static void Main (string[] args) {
      const string stringTitle = "image-separator: Separate specified large-image into several readable image.";
      const string stringCopyright = "Copyright (c) 2022 ArdeshirV@protonmail.com, Licensed under GPLv3+";
      System.Console.ForegroundColor = ConsoleColor.Yellow;
      System.Console.Write(string.Format("{0}\n{1}\n", stringTitle, stringCopyright));
      System.Console.ResetColor();
      if(args.Length < 2) {
        System.Console.ForegroundColor = ConsoleColor.Red;
        System.Console.WriteLine("Error: Source file and separation number is not specified!");
        System.Console.WriteLine("Usage: image-separator <source-image> <separation-number>");
        System.Console.ResetColor();
        return;
      }
      if(!File.Exists(args[0])) {
        System.Console.ForegroundColor = ConsoleColor.Red;
        System.Console.WriteLine("Error: Source file doesn't exists!");
        System.Console.ResetColor();
        return;
      }
      string stringSourceFile = args[0];
      int intSeperationNumber = int.Parse(args[1]);
      Bitmap imageSource = new Bitmap(stringSourceFile);
      int width = imageSource.Width;
      int height = imageSource.Height / intSeperationNumber;
      int intExtHeight = height / 20;
      for(int indexer = 0; indexer < intSeperationNumber; indexer++) {
        RectangleF cloneRect = new RectangleF(
          0, height * indexer, width, (height + intExtHeight) * (indexer + 1));
        string fileName = string.Format("farabank-{0}.jpg", indexer + 1);
        string stringMessage = string.Format("{0} - {1}", cloneRect, fileName);
        System.Console.ForegroundColor = ConsoleColor.Magenta;
        System.Console.WriteLine(stringMessage);
        System.Console.ResetColor();
        Bitmap imageDest = new Bitmap(width, height + intExtHeight);
        Graphics g = Graphics.FromImage(imageDest);
        g.DrawImage(imageSource, 0, 0, cloneRect, GraphicsUnit.Pixel);
        imageDest.Save(fileName, ImageFormat.Jpeg);
        imageDest.Dispose();
      }
      imageSource.Dispose();
    }
  }
}
//----------------------------------------------------------------------------------------

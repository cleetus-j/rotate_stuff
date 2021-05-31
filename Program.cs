using System;
using System.IO;
using System.Drawing;


namespace rotate_stuff
{
    class Program
    {
        static void Main(string[] args)
        {
            
            string PicToWorkOn = args[0];
            string[] broken_string = PicToWorkOn.Split('.');
            string[] angles;
            angles=new string[]{"90", "180", "270","360","XFlip","YFlip"};
            var RotateType=Convert.ToUInt16(args[1]);            
            string output;
            
            
            Bitmap bitmap1;
            bitmap1 = (Bitmap)Bitmap.FromFile(PicToWorkOn);
            
            if (RotateType==0)//90 fokos elforgatás.
            {
                bitmap1.RotateFlip(RotateFlipType.Rotate90FlipNone);
                output = "C:\\temp\\" + broken_string[0] + angles[RotateType] + "." + broken_string[1];
                bitmap1.Save(output);
            }
            else if (RotateType==1)//180 fokos elforgatás.
            {
                bitmap1.RotateFlip(RotateFlipType.Rotate180FlipNone);
                output = "C:\\temp\\" + broken_string[0] + angles[RotateType] + "." + broken_string[1];
                bitmap1.Save(output);
            }
            else if (RotateType==2)//270 fokos elforgatás.
            {
                bitmap1.RotateFlip(RotateFlipType.Rotate270FlipNone);
                output = "C:\\temp\\" + broken_string[0] + angles[RotateType] + "." + broken_string[1];
                bitmap1.Save(output);
            }
            else if (RotateType==3)//Kell az összes elforgatás.
            {
                RotateType = 1;
                for (int i = 0; i < 3; i++)
                {
                    
                    bitmap1.RotateFlip(RotateFlipType.Rotate90FlipNone);
                    output = "C:\\temp\\" + broken_string[0] + angles[RotateType] + "." + broken_string[1];
                    bitmap1.Save(output);
                    RotateType++;

                }
            }
            else if (RotateType==4)//Függőleges tükrözés.
            {
                bitmap1.RotateFlip(RotateFlipType.RotateNoneFlipX);
                output = "C:\\temp\\" + broken_string[0] + angles[RotateType] + "." + broken_string[1];
                bitmap1.Save(output);
            }
            else if (RotateType==5)//Vízszintes tükrözés.
            {
                bitmap1.RotateFlip(RotateFlipType.RotateNoneFlipY);
                output = "C:\\temp\\" + broken_string[0] + angles[RotateType] + "." + broken_string[1];
                bitmap1.Save(output);
            }
            else if (RotateType==6)
            {
                int HowManyRotations = Convert.ToUInt16(args[2]);
                float HowManyDegrees = float.Parse(args[3]);
                int CurrentDegree=Convert.ToInt32(HowManyDegrees)*HowManyRotations;
                string FileNameWithDegree = "C:\\temp\\" + broken_string[0] + CurrentDegree + "." + broken_string[1];

                for (int i = 0; i < HowManyRotations; i++)
                {
                    CurrentDegree = Convert.ToInt32(HowManyDegrees) * i;

                    Image ImageGoesIn = bitmap1;
                    
                        
                    Image ImageGoesOut;
                    ImageGoesOut = RotateImage(ImageGoesIn, CurrentDegree);
                    FileNameWithDegree = "C:\\temp\\" + broken_string[0] + CurrentDegree + "." + broken_string[1];
                    ImageGoesOut.Save(FileNameWithDegree);

                }
            }
            else
            {
                Console.WriteLine("Invalid job type, exiting.");
                System.Environment.Exit(-1);
            }
            
           // Console.WriteLine(broken_string[0]);
            //Console.WriteLine(broken_string[1]);
            //bitmap1.Save(output);
            Console.WriteLine("All work was done. Exiting.");
            System.Environment.Exit(0);
        }
        public static Image RotateImage(Image img, float rotationAngle)
        {
            //create an empty Bitmap image
            Bitmap bmp = new Bitmap(img.Width, img.Height);

            //turn the Bitmap into a Graphics object
            Graphics gfx = Graphics.FromImage(bmp);

            //now we set the rotation point to the center of our image
            gfx.TranslateTransform((float)bmp.Width / 2, (float)bmp.Height / 2);

            //now rotate the image
            gfx.RotateTransform(rotationAngle);

            gfx.TranslateTransform(-(float)bmp.Width / 2, -(float)bmp.Height / 2);

            //set the InterpolationMode to HighQualityBicubic so to ensure a high
            //quality image once it is transformed to the specified size
            gfx.InterpolationMode = System.Drawing.Drawing2D.InterpolationMode.HighQualityBicubic;

            //now draw our new image onto the graphics object
            gfx.DrawImage(img, new Point(0, 0));

            //dispose of our Graphics object
            gfx.Dispose();

            //return the image
            return bmp;
        }
    }
}

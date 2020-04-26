using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using OpenCvSharp;

namespace ShapeDetection
{
    class ShapeDetectAssist
    {
        IplImage source, grayScaleImage, outlineImage;

        public void OpenInitialImage()
        {
            source = Cv.LoadImage("6a.png",LoadMode.Color);
            Cv.SaveImage("bilBall.jpg",source);
        }

        public void OpenGrayImage()
        {
            grayScaleImage = Cv.CreateImage(source.Size, BitDepth.U8, 1);
            Cv.CvtColor(source,grayScaleImage,ColorConversion.RgbToGray);
            Cv.SaveImage("GrayBill.jpg",grayScaleImage);
        }

        public void captureShape()
        {
            OpenInitialImage();
            Cv.Smooth(grayScaleImage, grayScaleImage, SmoothType.Gaussian, 10);
            Cv.Canny(grayScaleImage,grayScaleImage,15,45,ApertureSize.Size3);
            Cv.SaveImage("grayBillMod.jpg", grayScaleImage);
            outlineImage = source.Clone();
            var storage = new CvMemStorage();

            CvSeq<CvCircleSegment> sequence = grayScaleImage.HoughCircles(storage,HoughCirclesMethod.Gradient,1,50,10,25,0,40);
            foreach(CvCircleSegment item in sequence)
            {
                outlineImage.Circle(item.Center, (int)item.Radius, CvColor.Magenta,2,LineType.Link4); 

            }

            Cv.SaveImage("grayBillmod2.jpg",outlineImage);
        }
    }
}

using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using Xamarin.Forms;

namespace C4S.MobileApp.Views.CustomLayouts
{
    public class SquareLayout : Layout<View>
    {
        //Dictionary<Size, LayoutData> layoutDataCache = new Dictionary<Size, LayoutData>();

        protected override SizeRequest OnMeasure(double widthConstraint, double heightConstraint)
        {
            //Keine Views -> kein Platz benötigt
            if (Children.Count == 0)
            {
                return new SizeRequest();
            }

            Size size;

            if (Double.IsPositiveInfinity(heightConstraint)
            ) //Display des Geräts in Portrait -> verfügabare Breite ist relevant
            {
                size = new Size(widthConstraint, widthConstraint);
            }
            else //Display des Geräts in Landscape -> verfügabare Höhe ist relevant
            {
                size = new Size(heightConstraint, heightConstraint);
            }

            Debug.WriteLine($"OnMeasure: widthConstraint {widthConstraint}, heightConstraint {heightConstraint}, size " + size);

            return new SizeRequest(size);
        }

        protected override void LayoutChildren(double x, double y, double width, double height)
        {
            //1.Child positionieren
            LayoutChildIntoBoundingRegion(Children.FirstOrDefault(),
                new Rectangle(new Point(x, y), new Size(width, width)));

            Debug.WriteLine($"LayoutChildren: x {x}, y {y}, width {width}, height {height}");
        }
    }
}
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TerminalSite.Shared
{
    public class BoundingClientRect
    {
        public double X { get; set; }
        public double Y { get; set; }
        public double Width { get; set; }
        public double Height { get; set; }
        public double Top { get; set; }
        public double Right { get; set; }
        public double Bottom { get; set; }
        public double Left { get; set; }


        public Coordinate2D GetLocationCoordinate(Location l) => l switch
        {
            Location.TopLeft => new Coordinate2D() { X = Left, Y = Top },
            Location.TopCenter => new Coordinate2D() { X = Left + Width * 0.5, Y = Top },
            Location.TopRight => new Coordinate2D() {X = Right, Y = Top },
            Location.RightCenter=> new Coordinate2D() { X = Right, Y = Top + Height * 0.5 },
            Location.BottomRight => new Coordinate2D() { X = Right, Y = Bottom },
            Location.BottomCenter => new Coordinate2D() { X = Left + Width * 0.5, Y = Bottom },
            Location.BottomLeft => new Coordinate2D() { X = Left, Y = Bottom },
            Location.LeftCenter => new Coordinate2D() { X = Left, Y = Top + Height * 0.5 },
            Location.Center => new Coordinate2D() { X = Left + Width * 0.5, Y = Top + Height * 0.5 },
            _ => throw new ArgumentOutOfRangeException(nameof(l), $"{l} is not a valid location ")
        };
        
    }

    public enum Location
    {
        TopLeft,
        TopCenter,
        TopRight,
        RightCenter,
        BottomRight,
        BottomCenter,
        BottomLeft,
        LeftCenter,
        Center
    }

    public class Coordinate2D
    {
        public double X { get; set; }
        public double Y { get; set; }
    }
}

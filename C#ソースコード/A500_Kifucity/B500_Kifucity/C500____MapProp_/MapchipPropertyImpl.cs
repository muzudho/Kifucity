using Grayscale.A500_Kifucity.B500_Kifucity.C___400_Image___;
using Grayscale.A500_Kifucity.B500_Kifucity.C___500_MapProp_;
using System.Drawing;

namespace Grayscale.A500_Kifucity.B500_Kifucity.C500____MapProp_
{
    /// <summary>
    /// </summary>
    public class MapchipPropertyImpl : MapchipProperty
    {
        public MapchipPropertyImpl(ImageSourcefile mapchipImageType, int x, int y, int width, int height)
        {
            this.MapchipImageType = mapchipImageType;
            this.SourceBounds = new Rectangle(x,y,width,height);
        }
        public MapchipPropertyImpl(ImageSourcefile mapchipImageType, Rectangle bounds)
        {
            this.MapchipImageType = mapchipImageType;
            this.SourceBounds = bounds;
        }

        /// <summary>
        /// 画像。
        /// </summary>
        public ImageSourcefile MapchipImageType { get; set; }

        /// <summary>
        /// マップチップ画像上の位置とサイズ。
        /// </summary>
        public Rectangle SourceBounds { get; set; }

    }
}

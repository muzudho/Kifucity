using Grayscale.A500_Kifucity.B500_Kifucity.C___500_MapProp_;
using System.Drawing;

namespace Grayscale.A500_Kifucity.B500_Kifucity.C500____MapProp_
{
    public class MapchipPropertyImpl : MapchipProperty
    {
        public MapchipPropertyImpl(ImageType mapchipImageType, int x, int y, int width, int height)
        {
            this.MapchipImageType = mapchipImageType;
            this.SourceBounds = new Rectangle(x,y,width,height);
        }

        /// <summary>
        /// 画像。
        /// </summary>
        public ImageType MapchipImageType { get; set; }

        /// <summary>
        /// マップチップ画像上の位置とサイズ。
        /// </summary>
        public Rectangle SourceBounds { get; set; }

    }
}

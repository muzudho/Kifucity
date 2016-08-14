using System.Drawing;

namespace Grayscale.A500_Kifucity.B500_Kifucity.C___500_MapProp_
{
    public interface MapchipProperty
    {
        /// <summary>
        /// 画像。
        /// </summary>
        ImageType MapchipImageType { get; set; }

        /// <summary>
        /// マップチップ画像上の位置とサイズ。
        /// </summary>
        Rectangle SourceBounds { get; set; }

    }
}

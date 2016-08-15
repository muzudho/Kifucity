using Grayscale.A500_Kifucity.B500_Kifucity.C___400_Image___;
using Grayscale.A500_Kifucity.B500_Kifucity.C___450_Position;

namespace Grayscale.A500_Kifucity.B500_Kifucity.C___500_MapProp_
{
    /// <summary>
    /// 太ペン☆ //囲まれている内側を塗りつぶすバケツ☆
    /// </summary>
    public interface MapchipBoldBrush : MapchipBrush
    {
        /// <summary>
        /// 
        /// </summary>
        MapchipCrop Patch { get; set; }

        /// <summary>
        /// レイヤー番号☆
        /// </summary>
        int Layer { get; set; }
        ImageType ImageType { get; set; }
    }
}

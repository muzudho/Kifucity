using System.Drawing;
using Grayscale.A500_Kifucity.B500_Kifucity.C___450_Position;
using Grayscale.A500_Kifucity.B500_Kifucity.C___400_Image___;

namespace Grayscale.A500_Kifucity.B500_Kifucity.C___500_MapProp_
{
    /// <summary>
    /// 境界線で囲まれる形状のマップチップを置くブラシ☆
    /// </summary>
    public interface MapchipBulldozerBrush : MapchipBrush
    {
        /// <summary>
        /// [0]なし
        /// [1]～[9]
        /// </summary>
        MapchipCrop[] PatchesA { get; set; }
        /// <summary>
        /// [0]なし
        /// [1]～[4]
        /// </summary>
        MapchipCrop[] PatchesB { get; set; }
        /// <summary>
        /// [0]なし
        /// [1]～[4]
        /// </summary>
        MapchipCrop[] PatchesC { get; set; }
        MapchipCrop PatchesD { get; set; }
        /// <summary>
        /// [0]なし
        /// [1]～[15]のうち幾つか
        /// </summary>
        MapchipCrop[] PatchesE { get; set; }
        /// <summary>
        /// [0]なし
        /// [1]～[12]
        /// </summary>
        MapchipCrop[] PatchesFx { get; set; }
        /// <summary>
        /// [0]なし
        /// [1]～[6]
        /// </summary>
        MapchipCrop[] PatchesGx { get; set; }

        /// <summary>
        /// レイヤー番号☆
        /// </summary>
        int Layer { get; set; }
        ImageType ImageType { get; set; }
    }
}

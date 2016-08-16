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
        ImageCropBorder[] PatchesA { get; set; }
        /// <summary>
        /// [0]なし
        /// [1]～[4]
        /// </summary>
        ImageCropBorder[] PatchesB { get; set; }
        /// <summary>
        /// [0]なし
        /// [1]～[4]
        /// </summary>
        ImageCropBorder[] PatchesC { get; set; }
        ImageCropBorder PatchesD { get; set; }
        /// <summary>
        /// [0]なし
        /// [1]～[15]のうち幾つか
        /// </summary>
        ImageCropBorder[] PatchesE { get; set; }
        /// <summary>
        /// [0]なし
        /// [1]～[12]
        /// </summary>
        ImageCropBorder[] PatchesFx { get; set; }
        /// <summary>
        /// [0]なし
        /// [1]～[6]
        /// </summary>
        ImageCropBorder[] PatchesGx { get; set; }

        /// <summary>
        /// レイヤー番号☆
        /// </summary>
        int Layer { get; set; }
        ImageSourcefile ImageSourcefile { get; set; }
        ImageType ImageType { get; set; }
    }
}

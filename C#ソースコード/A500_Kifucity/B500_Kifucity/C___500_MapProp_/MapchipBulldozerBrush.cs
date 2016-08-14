using System.Drawing;

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
        /// [1]～[8]
        /// </summary>
        MapchipCrop[] PatchesF { get; set; }
        /// <summary>
        /// [0]なし
        /// [1]～[6]
        /// </summary>
        MapchipCrop[] PatchesG { get; set; }
    }
}

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
        /// [1]┌
        /// [2]┬
        /// [3]┐
        /// [4]├
        /// [5]┼
        /// [6]┤
        /// [7]└
        /// [8]┴
        /// [9]┘
        /// [10]逆┌
        /// [11]逆┐
        /// [12]逆└
        /// [13]逆┘
        /// [14]角無／
        /// [15]角無＼
        /// [16]角無┌
        /// [17]角無┐
        /// [18]角無└
        /// [19]角無┘
        /// </summary>
        MapchipCrop[] Patches { get; set; }
    }
}

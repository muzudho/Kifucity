using Grayscale.A500_Kifucity.B500_Kifucity.C___400_Image___;
using Grayscale.A500_Kifucity.B500_Kifucity.C___450_Position;
using System.Drawing;

namespace Grayscale.A500_Kifucity.B500_Kifucity.C___500_MapProp_
{
    /// <summary>
    /// 線路状のマップチップを置くブラシ☆
    /// </summary>
    public interface MapchipRailwayBrush : MapchipBrush
    {
        /// <summary>
        /// レイヤー番号☆
        /// </summary>
        int Layer { get; set; }
        /// <summary>
        /// 元画像は、１種類の道路／線路タイプ、２種類の送電線／高架送電線タイプがあるぜ☆（＾～＾）
        /// </summary>
        ImageSourcefile[] ImageSourcefiles { get; set; }

        /// <summary>
        /// [ 0]なし
        /// [ 1]・ [ 2]│  [ 3]─
        /// [ 4]┌  [ 5]┬  [ 6]┐
        /// [ 7]├  [ 8]┼  [ 9]┤
        /// [10]└  [11]┴  [12]┘
        /// </summary>
        ImageCropWay[] ImageCrop { get; set; }
    }
}

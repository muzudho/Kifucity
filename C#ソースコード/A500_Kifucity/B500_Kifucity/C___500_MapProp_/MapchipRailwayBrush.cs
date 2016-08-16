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
        ImageSourcefile ImageSourcefile { get; set; }

        /// <summary>
        /// [0]なし [1]・ [2]│
        /// [3]┌    [4]┬  [5]┐
        /// [6]├    [7]┼  [8]┤
        /// [9]└    [10]┴ [11]┘
        /// </summary>
        ImageCropWay Point { get; set; }
        ImageCropWay Vertical { get; set; }
        ImageCropWay Horizontal { get; set; }
        ImageCropWay[] Patches { get; set; }

        /*
        /// <summary>
        /// 線路状にマップチップを連続配置するぜ☆（＾▽＾）
        /// </summary>
        void PutMapchipAsLine(
            out bool out_isUpdate, Point mouseLocation, UcMain ucMain
            );
            */
    }
}

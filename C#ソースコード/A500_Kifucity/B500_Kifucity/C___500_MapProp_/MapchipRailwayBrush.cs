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
        ImageType ImageType { get; set; }

        /// <summary>
        /// ・
        /// </summary>
        MapchipCrop Point { get; set; }
        /// <summary>
        /// │
        /// </summary>
        MapchipCrop Vertical { get; set; }
        /// <summary>
        /// ─
        /// </summary>
        MapchipCrop Horizontal { get; set; }

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
        /// </summary>
        MapchipCrop[] Patches { get; set; }

        /// <summary>
        /// 線路状にマップチップを連続配置するぜ☆（＾▽＾）
        /// </summary>
        void PutMapchipAsLine(
            out bool out_isUpdate, Point mouseLocation, UcMain ucMain
            );
    }
}

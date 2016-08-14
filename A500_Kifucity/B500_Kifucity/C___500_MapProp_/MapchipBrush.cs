using System.Drawing;

namespace Grayscale.A500_Kifucity.B500_Kifucity.C___500_MapProp_
{
    /// <summary>
    /// 線路や、ブルドーザーのブラシを１つの配列にまとめるためのインターフェースだぜ☆（＾～＾）
    /// </summary>
    public interface MapchipBrush
    {
        /// <summary>
        /// 近傍を巻き込んだマップチップの置き換え
        /// </summary>
        void UpdateNeighborhood(UcMain ucMain //MapchipCrop[,,] map
            , int row, int col);

        /// <summary>
        /// 直線状にマップチップを連続配置するぜ☆（＾▽＾）
        /// </summary>
        void PutMapchipAsLine(
            out bool out_isUpdate, Point mouseLocation, UcMain ucMain
            );
    }
}

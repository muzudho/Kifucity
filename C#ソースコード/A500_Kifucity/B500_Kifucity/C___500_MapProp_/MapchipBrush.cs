using System.Drawing;
using Grayscale.A500_Kifucity.B500_Kifucity.C___450_Position;

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
        void UpdateNeighborhood(Position city, int row, int col);

        /// <summary>
        /// どの元画像を使うかを、ブラシ毎にセルを見て変えるためのものだぜ☆（＾▽＾）
        /// </summary>
        /// <param name="city"></param>
        /// <param name="row"></param>
        /// <param name="col"></param>
        /// <returns></returns>
        int GetSourcefileIndex(Position city, int row, int col);

        /// <summary>
        /// 直線状にマップチップを連続配置するぜ☆（＾▽＾）
        /// </summary>
        void PutMapchipAsLine(
            out bool out_isUpdate, Point mouseLocation, UcMain ucMain
            );
    }
}

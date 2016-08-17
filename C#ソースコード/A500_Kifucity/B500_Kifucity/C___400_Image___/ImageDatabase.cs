using System.Drawing;

namespace Grayscale.A500_Kifucity.B500_Kifucity.C___400_Image___
{
    /// <summary>
    /// セーブデータのセルと対応したいぜ☆（＾▽＾）
    /// 
    /// 配列Image[元画像ファイル識別子]
    /// 配列Crop[マップチップの配置形式][配置番号]
    /// 
    /// ・マップチップの配置形式……自由配置、砂浜、線路。
    /// </summary>
    public interface ImageDatabase
    {
        /// <summary>
        /// 画像の読込みをするぜ☆（＾▽＾）
        /// </summary>
        void Load();

        /// <summary>
        /// [ImageSourcefile]
        /// [0]なし [1]マップ画像☆ [2]砂地画像☆ [3]ボタン画像☆ [4]道路☆ [5]線路☆ [6]送電線☆
        /// </summary>
        Image[] ImageSourcefiles { get; set; }

        /// <summary>
        /// 切り抜く領域☆
        /// </summary>
        Rectangle[][] Crop { get; set; }
    }
}

namespace Grayscale.A500_Kifucity.B500_Kifucity.C___400_Image___
{
    /// <summary>
    /// マップチップ画像の切り抜く範囲ひとつひとつの区別☆
    /// 
    /// ボタン系
    /// </summary>
    public enum ImageCropButton
    {
        None,

        /// <summary>
        /// 線路ボタン senro button [1]押す前 [2]マウスカーソルを重ねたとき [3]押した後
        /// </summary>
        sebt線路1,
        sebt線路2,
        sebt線路3,
        sebt線路4,
        /// <summary>
        /// ブルドーザー seichi button
        /// </summary>
        sebt整地1,
        sebt整地2,
        sebt整地3,
        sebt整地4,
        /// <summary>
        /// 
        /// </summary>
        dobt道路1,
        dobt道路2,
        dobt道路3,
        dobt道路4,
        /// <summary>
        /// 
        /// </summary>
        bobt太ペン1,
        bobt太ペン2,
        bobt太ペン3,
        bobt太ペン4,
        /// <summary>
        /// 送電線 power line
        /// </summary>
        pobt送電線1,
        pobt送電線2,
        pobt送電線3,
        pobt送電線4,
        /*
        /// <summary>
        /// 砂地で囲まれた空間を、砂地で埋めるバケツ。
        /// </summary>
        babtバケツ1,
        babtバケツ2,
        babtバケツ3,
        babtバケツ4,
        */

        /// <summary>
        /// （列挙型サイズ）
        /// </summary>
        Num
    }
}

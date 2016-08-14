namespace Grayscale.A500_Kifucity.B500_Kifucity.C___500_MapProp_
{
    /// <summary>
    /// マップチップ画像の切り抜く範囲ひとつひとつの区別☆
    /// </summary>
    public enum MapchipCrop
    {
        None = 0,

        u海,
        /// <summary>
        /// 住宅地
        /// </summary>
        R,
        /// <summary>
        /// 商業地
        /// </summary>
        C,
        /// <summary>
        /// 工業地
        /// </summary>
        I,

        /// <summary>
        /// ・ point
        /// </summary>
        do道路P,
        /// <summary>
        /// │ vertical
        /// </summary>
        do道路V,
        /// <summary>
        /// ─ horizontal
        /// </summary>
        do道路H,
        /// <summary>
        /// 
        /// </summary>
        do道路_田1,
        /// <summary>
        /// 
        /// </summary>
        do道路_田2,
        /// <summary>
        /// 
        /// </summary>
        do道路_田3,
        /// <summary>
        /// 
        /// </summary>
        do道路_田4,
        /// <summary>
        /// 
        /// </summary>
        do道路_田5,
        /// <summary>
        /// 
        /// </summary>
        do道路_田6,
        /// <summary>
        /// 
        /// </summary>
        do道路_田7,
        /// <summary>
        /// 
        /// </summary>
        do道路_田8,
        /// <summary>
        /// 
        /// </summary>
        do道路_田9,

        /// <summary>
        /// ・
        /// </summary>
        se線路P,
        /// <summary>
        /// 
        /// </summary>
        se線路V,
        /// <summary>
        /// 
        /// </summary>
        se線路H,
        /// <summary>
        /// 
        /// </summary>
        se線路_田1,
        /// <summary>
        /// 
        /// </summary>
        se線路_田2,
        /// <summary>
        /// 
        /// </summary>
        se線路_田3,
        /// <summary>
        /// 
        /// </summary>
        se線路_田4,
        /// <summary>
        /// 
        /// </summary>
        se線路_田5,
        /// <summary>
        /// 
        /// </summary>
        se線路_田6,
        /// <summary>
        /// 
        /// </summary>
        se線路_田7,
        /// <summary>
        /// 
        /// </summary>
        se線路_田8,
        /// <summary>
        /// 
        /// </summary>
        se線路_田9,

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
        /// 境界線チップ
        /// </summary>
        kyo境界線_A1,
        /// <summary>
        /// ┬
        /// </summary>
        kyo境界線_A2,
        /// <summary>
        /// ┐
        /// </summary>
        kyo境界線_A3,
        /// <summary>
        /// ├
        /// </summary>
        kyo境界線_A4,
        /// <summary>
        /// ┼
        /// </summary>
        kyo境界線_A5,
        /// <summary>
        /// ┤
        /// </summary>
        kyo境界線_A6,
        /// <summary>
        /// └
        /// </summary>
        kyo境界線_A7,
        /// <summary>
        /// ┴
        /// </summary>
        kyo境界線_A8,
        /// <summary>
        /// ┘
        /// </summary>
        kyo境界線_A9,
        /// <summary>
        /// 逆┌
        /// </summary>
        kyo境界線_B1,
        /// <summary>
        /// 逆┐
        /// </summary>
        kyo境界線_B2,
        /// <summary>
        /// 逆└
        /// </summary>
        kyo境界線_B3,
        /// <summary>
        /// 逆┘
        /// </summary>
        kyo境界線_B4,
        /// <summary>
        /// 逆┌
        /// </summary>
        kyo境界線_C1,
        /// <summary>
        /// 逆┐
        /// </summary>
        kyo境界線_C2,
        /// <summary>
        /// 逆└
        /// </summary>
        kyo境界線_C3,
        /// <summary>
        /// 逆┘
        /// </summary>
        kyo境界線_C4,
        /// <summary>
        /// 
        /// </summary>
        kyo境界線_D,

        /// <summary>
        ///
        /// </summary>
        kyo境界線_E6,
        /// <summary>
        ///
        /// </summary>
        kyo境界線_E13,
        /// <summary>
        ///
        /// </summary>
        kyo境界線_E10,
        /// <summary>
        ///
        /// </summary>
        kyo境界線_E12,
        /// <summary>
        ///
        /// </summary>
        kyo境界線_E14,
        /// <summary>
        ///
        /// </summary>
        kyo境界線_E15,
        /// <summary>
        ///
        /// </summary>
        kyo境界線_E9,
        /// <summary>
        ///
        /// </summary>
        kyo境界線_E3,
        /// <summary>
        ///
        /// </summary>
        kyo境界線_E7,
        /// <summary>
        ///
        /// </summary>
        kyo境界線_E11,
        /// <summary>
        ///
        /// </summary>
        kyo境界線_E5,

        /// <summary>
        ///
        /// </summary>
        kyo境界線_F1x,
        /// <summary>
        ///
        /// </summary>
        kyo境界線_F2x,
        /// <summary>
        ///
        /// </summary>
        kyo境界線_F3x,
        /// <summary>
        ///
        /// </summary>
        kyo境界線_F4x,
        /// <summary>
        ///
        /// </summary>
        kyo境界線_F5x,
        /// <summary>
        ///
        /// </summary>
        kyo境界線_F6x,
        /// <summary>
        ///
        /// </summary>
        kyo境界線_F7x,
        /// <summary>
        ///
        /// </summary>
        kyo境界線_F8x,
        /// <summary>
        ///
        /// </summary>
        kyo境界線_F9x,
        /// <summary>
        ///
        /// </summary>
        kyo境界線_F10x,
        /// <summary>
        ///
        /// </summary>
        kyo境界線_F11x,
        /// <summary>
        ///
        /// </summary>
        kyo境界線_F12x,
        /// <summary>
        ///
        /// </summary>
        kyo境界線_G1x,
        /// <summary>
        ///
        /// </summary>
        kyo境界線_G2x,
        /// <summary>
        ///
        /// </summary>
        kyo境界線_G3x,
        /// <summary>
        ///
        /// </summary>
        kyo境界線_G4x,
        /// <summary>
        ///
        /// </summary>
        kyo境界線_G5x,
        /// <summary>
        ///
        /// </summary>
        kyo境界線_G6x,

        /// <summary>
        /// 列挙型サイズ
        /// </summary>
        Num
    }
}

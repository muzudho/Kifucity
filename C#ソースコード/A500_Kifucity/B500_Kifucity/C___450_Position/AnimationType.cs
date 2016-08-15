namespace Grayscale.A500_Kifucity.B500_Kifucity.C___450_Position
{
    /// <summary>
    /// マップチップ画像で、アニメーションのコマがどのようにならんでいるか☆
    /// </summary>
    public enum AnimationType
    {
        /// <summary>
        /// アニメーションしない☆
        /// </summary>
        None,

        /// <summary>
        /// ８コマが横に隣接して並んでいる☆
        /// </summary>
        Horizontal8,

        /// <summary>
        /// 境界線チップ用の128px飛びに横に並んでいる☆
        /// </summary>
        Horizontal8_span128
    }
}

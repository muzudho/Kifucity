namespace Grayscale.A500_Kifucity.B500_Kifucity.C___500_MapProp_
{
    public interface Cell
    {
        /// <summary>
        /// １コマ目の切り抜き範囲☆
        /// アニメする場合、画像は横に並んでいるものとするぜ☆
        /// </summary>
        MapchipCrop MapchipCrop { get; set; }

        /// <summary>
        /// 8コマ・アニメーションするなら真☆
        /// </summary>
        bool IsAnimation { get; set; }

        /// <summary>
        /// 元画像ファイル☆
        /// </summary>
        ImageType ImageType { get; set; }

        void Clear();
    }
}

using Grayscale.A500_Kifucity.B500_Kifucity.C___400_Image___;

namespace Grayscale.A500_Kifucity.B500_Kifucity.C___450_Position
{
    public interface Cell
    {
        /// <summary>
        /// １コマ目の切り抜き範囲☆
        /// アニメする場合、画像は横に並んでいるものとするぜ☆
        /// </summary>
        MapchipCrop MapchipCrop { get; set; }

        /// <summary>
        /// マップチップ画像で、アニメーションのコマがどのようにならんでいるか☆
        /// </summary>
        AnimationType AnimationType { get; set; }

        /// <summary>
        /// 元画像ファイル☆
        /// </summary>
        ImageType ImageType { get; set; }

        void Clear();
    }
}

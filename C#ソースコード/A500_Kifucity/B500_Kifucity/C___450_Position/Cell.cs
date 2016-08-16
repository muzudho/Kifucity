using Grayscale.A500_Kifucity.B500_Kifucity.C___400_Image___;

namespace Grayscale.A500_Kifucity.B500_Kifucity.C___450_Position
{
    public interface Cell
    {
        void SetValue(ImageType imageType, ImageCrop imageCrop, ImageSourcefile imageSourcefile);

        /// <summary>
        /// 画像タイプ☆
        /// </summary>
        ImageType ImageType { get; set; }
        /// <summary>
        /// １コマ目の切り抜き範囲☆
        /// アニメする場合、画像は横に並んでいるものとするぜ☆
        /// </summary>
        ImageCrop ImageCrop { get; set; }

        /// <summary>
        /// 元画像ファイル☆
        /// </summary>
        ImageSourcefile ImageSourcefile { get; set; }

        void Clear();
    }
}

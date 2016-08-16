using Grayscale.A500_Kifucity.B500_Kifucity.C___400_Image___;
using Grayscale.A500_Kifucity.B500_Kifucity.C___450_Position;

namespace Grayscale.A500_Kifucity.B500_Kifucity.C450____Position
{
    public class CellImpl : Cell
    {
        public void SetValue(ImageType imageType, ImageCrop imageCrop, ImageSourcefile imageSourcefile)
        {
            this.ImageType = imageType;
            this.ImageCrop = imageCrop;
            this.ImageSourcefile = imageSourcefile;
        }

        /// <summary>
        /// 画像タイプ☆
        /// </summary>
        public ImageType ImageType { get; set; }
        /// <summary>
        /// １コマ目の切り抜き範囲☆
        /// アニメする場合、画像は横に並んでいるものとするぜ☆
        /// </summary>
        public ImageCrop ImageCrop { get; set; }

        /// <summary>
        /// 元画像ファイル☆
        /// </summary>
        public ImageSourcefile ImageSourcefile { get; set; }

        public void Clear()
        {
            this.ImageType = ImageType.None;
            this.ImageCrop = 0;
            this.ImageSourcefile = ImageSourcefile.None;
        }
    }
}

using Grayscale.A500_Kifucity.B500_Kifucity.C___400_Image___;
using Grayscale.A500_Kifucity.B500_Kifucity.C___450_Position;

namespace Grayscale.A500_Kifucity.B500_Kifucity.C450____Position
{
    public class CellImpl : Cell
    {
        /// <summary>
        /// １コマ目の切り抜き範囲☆
        /// アニメする場合、画像は横に並んでいるものとするぜ☆
        /// </summary>
        public MapchipCrop MapchipCrop { get; set; }

        /// <summary>
        /// 8コマ・アニメーションするなら真☆
        /// </summary>
        public AnimationType AnimationType { get; set; }

        /// <summary>
        /// 元画像ファイル☆
        /// </summary>
        public ImageType ImageType { get; set; }

        public void Clear()
        {
            this.MapchipCrop = MapchipCrop.None;
            this.AnimationType = AnimationType.None;
            this.ImageType = ImageType.None;
        }
    }
}

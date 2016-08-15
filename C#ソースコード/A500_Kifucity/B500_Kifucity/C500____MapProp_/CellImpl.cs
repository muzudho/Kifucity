using Grayscale.A500_Kifucity.B500_Kifucity.C___500_MapProp_;

namespace Grayscale.A500_Kifucity.B500_Kifucity.C500____MapProp_
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
        public bool IsAnimation { get; set; }

        /// <summary>
        /// 元画像ファイル☆
        /// </summary>
        public ImageType ImageType { get; set; }

        public void Clear()
        {
            this.MapchipCrop = MapchipCrop.None;
            this.IsAnimation = false;
            this.ImageType = ImageType.None;
        }
    }
}

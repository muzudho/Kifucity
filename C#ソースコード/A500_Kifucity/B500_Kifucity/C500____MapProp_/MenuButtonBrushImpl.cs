using Grayscale.A500_Kifucity.B500_Kifucity.C___400_Image___;
using Grayscale.A500_Kifucity.B500_Kifucity.C___450_Position;
using Grayscale.A500_Kifucity.B500_Kifucity.C___500_MapProp_;
using System.Drawing;

namespace Grayscale.A500_Kifucity.B500_Kifucity.C500____MapProp_
{
    public class MenuButtonBrushImpl : MenuButtonBrush
    {
        public MenuButtonBrushImpl(
            ImageSourcefile imageType,
            int x,
            int y,
            int width,
            int height,
            ImageCropButton patch1,
            ImageCropButton patch2,
            ImageCropButton patch3,
            ImageCropButton patch4
            )
        {
            this.ImageType = imageType;
            this.DestinationBounds = new Rectangle(x,y,width,height);

            this.ButtonState = ButtonState2.Pushable;

            this.Patches = new ImageCropButton[]
            {
                ImageCropButton.None,
                patch1,
                patch2,
                patch3,
                patch4
            };
        }

        public ButtonState2 ButtonState { get; set; }

        public ImageSourcefile ImageType { get; set; }
        /// <summary>
        /// [0]なし
        /// [1]押す前
        /// [2]マウスカーソルを合わせたとき
        /// [3]押されているとき
        /// </summary>
        public ImageCropButton[] Patches { get; set; }

        /// <summary>
        /// ボタンの表示位置とサイズ☆
        /// </summary>
        public Rectangle DestinationBounds { get; set; }

        /// <summary>
        /// 描画
        /// </summary>
        public void Paint(Graphics g, UcMain ucMain)
        {
            if (null != ucMain.ImageDatabase.Images)//ビジュアル・エディター対策
            {
                g.DrawImage(ucMain.ImageDatabase.Images[(int)this.ImageType], this.DestinationBounds, ucMain.ImageDatabase.Crop[(int)this.ImageType][(int)this.Patches[(int)this.ButtonState]], GraphicsUnit.Pixel);
            }
        }

    }
}

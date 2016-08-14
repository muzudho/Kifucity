using Grayscale.A500_Kifucity.B500_Kifucity.C___500_MapProp_;
using System.Drawing;

namespace Grayscale.A500_Kifucity.B500_Kifucity.C500____MapProp_
{
    public class MapchipButtonBrushImpl : MapchipButtonBrush
    {
        public MapchipButtonBrushImpl(
            int x,
            int y,
            int width,
            int height,
            MapchipCrop patch1,
            MapchipCrop patch2,
            MapchipCrop patch3,
            MapchipCrop patch4
            )
        {
            this.DestinationBounds = new Rectangle(x,y,width,height);

            this.ButtonState = ButtonState2.Pushable;
            //this.ButtonState = ButtonState2.Pushed;

            this.Patches = new MapchipCrop[]
            {
                MapchipCrop.None,
                patch1,
                patch2,
                patch3,
                patch4
            };
        }

        public ButtonState2 ButtonState { get; set; }

        /// <summary>
        /// [0]なし
        /// [1]押す前
        /// [2]マウスカーソルを合わせたとき
        /// [3]押されているとき
        /// </summary>
        public MapchipCrop[] Patches { get; set; }

        /// <summary>
        /// ボタンの表示位置とサイズ☆
        /// </summary>
        public Rectangle DestinationBounds { get; set; }

        /// <summary>
        /// 描画
        /// </summary>
        public void Paint(Graphics g, UcMain ucMain)
        {
            g.DrawImage(ucMain.ImgMap, this.DestinationBounds, ucMain.MapchipProperties[(int)this.Patches[(int)this.ButtonState]].SourceBounds, GraphicsUnit.Pixel);
        }

    }
}

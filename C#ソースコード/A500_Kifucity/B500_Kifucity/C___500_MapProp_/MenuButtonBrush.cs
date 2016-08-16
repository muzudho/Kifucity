using Grayscale.A500_Kifucity.B500_Kifucity.C___400_Image___;
using Grayscale.A500_Kifucity.B500_Kifucity.C___450_Position;
using System.Drawing;

namespace Grayscale.A500_Kifucity.B500_Kifucity.C___500_MapProp_
{
    /// <summary>
    /// ボタン状のマップチップを置くブラシ☆
    /// </summary>
    public interface MenuButtonBrush
    {
        ButtonState2 ButtonState { get; set; }

        ImageSourcefile ImageType { get; set; }
        /// <summary>
        /// [0]なし
        /// [1]押す前
        /// [2]マウスカーソルを合わせたとき
        /// [3]押されているとき
        /// </summary>
        ImageCropButton[] Patches { get; set; }

        /// <summary>
        /// ボタンの表示位置とサイズ☆
        /// </summary>
        Rectangle DestinationBounds { get; set; }

        /// <summary>
        /// 描画
        /// </summary>
        void Paint(Graphics g, UcMain ucMain);

        /*
        /// <summary>
        /// マウスカーソルが重なったかを確認するぜ☆（＾▽＾）
        /// </summary>
        /// <param name="mouseLocation"></param>
        /// <returns></returns>
        bool Contains(Point mouseLocation);
        */
    }
}

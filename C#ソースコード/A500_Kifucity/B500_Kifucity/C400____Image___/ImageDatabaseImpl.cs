using Grayscale.A500_Kifucity.B500_Kifucity.C___400_Image___;
using System.Drawing;
using Grayscale.A500_Kifucity.B500_Kifucity.C450____Position;//FIXME:

namespace Grayscale.A500_Kifucity.B500_Kifucity.C400____Image___
{
    /// <summary>
    /// セーブデータのセルと対応したいぜ☆（＾▽＾）
    /// 
    /// 配列Image[元画像ファイル識別子]
    /// 配列Crop[マップチップの配置形式][配置番号]
    /// 
    /// ・マップチップの配置形式……自由配置、砂浜、線路。
    /// </summary>
    public class ImageDatabaseImpl : ImageDatabase
    {
        /// <summary>
        /// ボタンの大きさ☆（＾～＾）
        /// </summary>
        public const int BUTTON_W = 32;
        public const int BUTTON_H = 32;

        public ImageDatabaseImpl()
        {
            // マップチップ画像読み込み
            this.Images = new Image[]{
                    null,
                    Image.FromFile("./img/map.png"),
                    Image.FromFile("./img/borderAnime_sunachi.png"),//Image.FromFile("./img/border_sunachi.png"),
                    Image.FromFile("./img/buttons.png"),
                    Image.FromFile("./img/anime_16x16x8.png"),
                    Image.FromFile("./img/wayChip_1.png"),
                    Image.FromFile("./img/wayChip_2.png"),
                    Image.FromFile("./img/wayChip_3.png"),
                };
            // 全ての画像の(0,128,128)を透明色に指定。
            Color transparentColor = Color.FromArgb(0, 128, 128);
            for (int iImg = 1; iImg < (int)ImageSourcefile.Num; iImg++)
            {
                ((Bitmap)this.Images[iImg]).MakeTransparent(transparentColor);
            }

            // マップチップ画像に関するデータ。
            this.Crop = new Rectangle[(int)ImageType.Num][];
            this.Crop[(int)ImageType.Normal] = new Rectangle[(int)ImageCropNormal.Num];
            this.Crop[(int)ImageType.NormalAnime] = new Rectangle[(int)ImageCropNormalAnime.Num];
            this.Crop[(int)ImageType.Button] = new Rectangle[(int)ImageCropButton.Num];
            this.Crop[(int)ImageType.Border] = new Rectangle[(int)ImageCropBorder.Num];
            this.Crop[(int)ImageType.BorderAnime] = new Rectangle[(int)ImageCropBorder.Num];
            this.Crop[(int)ImageType.Way] = new Rectangle[(int)ImageCropWay.Num];

            // 海アニメ・チップ
            // 1コマ目
            this.Crop[(int)ImageType.NormalAnime][(int)ImageCropNormalAnime.Frame1] = new Rectangle(0 * PositionImpl.CELL_W, 0 * PositionImpl.CELL_H, PositionImpl.CELL_W, PositionImpl.CELL_H);

            // 境界線チップ [0]非アニメ [1]アニメの１コマ目
            for (int i=0; i<2; i++)
            {
                int imageTypeN = (i == 0 ? (int)ImageType.Border : (int)ImageType.BorderAnime);

                this.Crop[imageTypeN][(int)ImageCropBorder.kyo境界線_A1] = new Rectangle(1 * PositionImpl.CELL_W, 0 * PositionImpl.CELL_H, PositionImpl.CELL_W, PositionImpl.CELL_H);
                this.Crop[imageTypeN][(int)ImageCropBorder.kyo境界線_A2] = new Rectangle(2 * PositionImpl.CELL_W, 0 * PositionImpl.CELL_H, PositionImpl.CELL_W, PositionImpl.CELL_H);
                this.Crop[imageTypeN][(int)ImageCropBorder.kyo境界線_A3] = new Rectangle(3 * PositionImpl.CELL_W, 0 * PositionImpl.CELL_H, PositionImpl.CELL_W, PositionImpl.CELL_H);
                this.Crop[imageTypeN][(int)ImageCropBorder.kyo境界線_A4] = new Rectangle(1 * PositionImpl.CELL_W, 1 * PositionImpl.CELL_H, PositionImpl.CELL_W, PositionImpl.CELL_H);
                this.Crop[imageTypeN][(int)ImageCropBorder.kyo境界線_A5] = new Rectangle(2 * PositionImpl.CELL_W, 1 * PositionImpl.CELL_H, PositionImpl.CELL_W, PositionImpl.CELL_H);
                this.Crop[imageTypeN][(int)ImageCropBorder.kyo境界線_A6] = new Rectangle(3 * PositionImpl.CELL_W, 1 * PositionImpl.CELL_H, PositionImpl.CELL_W, PositionImpl.CELL_H);
                this.Crop[imageTypeN][(int)ImageCropBorder.kyo境界線_A7] = new Rectangle(1 * PositionImpl.CELL_W, 2 * PositionImpl.CELL_H, PositionImpl.CELL_W, PositionImpl.CELL_H);
                this.Crop[imageTypeN][(int)ImageCropBorder.kyo境界線_A8] = new Rectangle(2 * PositionImpl.CELL_W, 2 * PositionImpl.CELL_H, PositionImpl.CELL_W, PositionImpl.CELL_H);
                this.Crop[imageTypeN][(int)ImageCropBorder.kyo境界線_A9] = new Rectangle(3 * PositionImpl.CELL_W, 2 * PositionImpl.CELL_H, PositionImpl.CELL_W, PositionImpl.CELL_H);
                this.Crop[imageTypeN][(int)ImageCropBorder.kyo境界線_B1] = new Rectangle(0 * PositionImpl.CELL_W, 3 * PositionImpl.CELL_H, PositionImpl.CELL_W, PositionImpl.CELL_H);
                this.Crop[imageTypeN][(int)ImageCropBorder.kyo境界線_B2] = new Rectangle(1 * PositionImpl.CELL_W, 3 * PositionImpl.CELL_H, PositionImpl.CELL_W, PositionImpl.CELL_H);
                this.Crop[imageTypeN][(int)ImageCropBorder.kyo境界線_B3] = new Rectangle(0 * PositionImpl.CELL_W, 4 * PositionImpl.CELL_H, PositionImpl.CELL_W, PositionImpl.CELL_H);
                this.Crop[imageTypeN][(int)ImageCropBorder.kyo境界線_B4] = new Rectangle(1 * PositionImpl.CELL_W, 4 * PositionImpl.CELL_H, PositionImpl.CELL_W, PositionImpl.CELL_H);
                this.Crop[imageTypeN][(int)ImageCropBorder.kyo境界線_C1] = new Rectangle(2 * PositionImpl.CELL_W, 3 * PositionImpl.CELL_H, PositionImpl.CELL_W, PositionImpl.CELL_H);
                this.Crop[imageTypeN][(int)ImageCropBorder.kyo境界線_C2] = new Rectangle(3 * PositionImpl.CELL_W, 3 * PositionImpl.CELL_H, PositionImpl.CELL_W, PositionImpl.CELL_H);
                this.Crop[imageTypeN][(int)ImageCropBorder.kyo境界線_C3] = new Rectangle(2 * PositionImpl.CELL_W, 4 * PositionImpl.CELL_H, PositionImpl.CELL_W, PositionImpl.CELL_H);
                this.Crop[imageTypeN][(int)ImageCropBorder.kyo境界線_C4] = new Rectangle(3 * PositionImpl.CELL_W, 4 * PositionImpl.CELL_H, PositionImpl.CELL_W, PositionImpl.CELL_H);
                this.Crop[imageTypeN][(int)ImageCropBorder.kyo境界線_D] = new Rectangle(0 * PositionImpl.CELL_W, 5 * PositionImpl.CELL_H, PositionImpl.CELL_W, PositionImpl.CELL_H);
                this.Crop[imageTypeN][(int)ImageCropBorder.kyo境界線_E6] = new Rectangle(1 * PositionImpl.CELL_W, 5 * PositionImpl.CELL_H, PositionImpl.CELL_W, PositionImpl.CELL_H);
                this.Crop[imageTypeN][(int)ImageCropBorder.kyo境界線_E13] = new Rectangle(2 * PositionImpl.CELL_W, 5 * PositionImpl.CELL_H, PositionImpl.CELL_W, PositionImpl.CELL_H);
                this.Crop[imageTypeN][(int)ImageCropBorder.kyo境界線_E10] = new Rectangle(3 * PositionImpl.CELL_W, 5 * PositionImpl.CELL_H, PositionImpl.CELL_W, PositionImpl.CELL_H);
                this.Crop[imageTypeN][(int)ImageCropBorder.kyo境界線_E12] = new Rectangle(0 * PositionImpl.CELL_W, 6 * PositionImpl.CELL_H, PositionImpl.CELL_W, PositionImpl.CELL_H);
                this.Crop[imageTypeN][(int)ImageCropBorder.kyo境界線_E14] = new Rectangle(1 * PositionImpl.CELL_W, 6 * PositionImpl.CELL_H, PositionImpl.CELL_W, PositionImpl.CELL_H);
                this.Crop[imageTypeN][(int)ImageCropBorder.kyo境界線_E15] = new Rectangle(2 * PositionImpl.CELL_W, 6 * PositionImpl.CELL_H, PositionImpl.CELL_W, PositionImpl.CELL_H);
                this.Crop[imageTypeN][(int)ImageCropBorder.kyo境界線_E9] = new Rectangle(3 * PositionImpl.CELL_W, 6 * PositionImpl.CELL_H, PositionImpl.CELL_W, PositionImpl.CELL_H);
                this.Crop[imageTypeN][(int)ImageCropBorder.kyo境界線_E3] = new Rectangle(0 * PositionImpl.CELL_W, 7 * PositionImpl.CELL_H, PositionImpl.CELL_W, PositionImpl.CELL_H);
                this.Crop[imageTypeN][(int)ImageCropBorder.kyo境界線_E7] = new Rectangle(1 * PositionImpl.CELL_W, 7 * PositionImpl.CELL_H, PositionImpl.CELL_W, PositionImpl.CELL_H);
                this.Crop[imageTypeN][(int)ImageCropBorder.kyo境界線_E11] = new Rectangle(2 * PositionImpl.CELL_W, 7 * PositionImpl.CELL_H, PositionImpl.CELL_W, PositionImpl.CELL_H);
                this.Crop[imageTypeN][(int)ImageCropBorder.kyo境界線_E5] = new Rectangle(3 * PositionImpl.CELL_W, 7 * PositionImpl.CELL_H, PositionImpl.CELL_W, PositionImpl.CELL_H);
                this.Crop[imageTypeN][(int)ImageCropBorder.kyo境界線_F1] = new Rectangle(4 * PositionImpl.CELL_W, 1 * PositionImpl.CELL_H, PositionImpl.CELL_W, PositionImpl.CELL_H);
                this.Crop[imageTypeN][(int)ImageCropBorder.kyo境界線_F2] = new Rectangle(5 * PositionImpl.CELL_W, 1 * PositionImpl.CELL_H, PositionImpl.CELL_W, PositionImpl.CELL_H);
                this.Crop[imageTypeN][(int)ImageCropBorder.kyo境界線_F3] = new Rectangle(6 * PositionImpl.CELL_W, 1 * PositionImpl.CELL_H, PositionImpl.CELL_W, PositionImpl.CELL_H);
                this.Crop[imageTypeN][(int)ImageCropBorder.kyo境界線_F4] = new Rectangle(4 * PositionImpl.CELL_W, 2 * PositionImpl.CELL_H, PositionImpl.CELL_W, PositionImpl.CELL_H);
                this.Crop[imageTypeN][(int)ImageCropBorder.kyo境界線_F5] = new Rectangle(5 * PositionImpl.CELL_W, 2 * PositionImpl.CELL_H, PositionImpl.CELL_W, PositionImpl.CELL_H);
                this.Crop[imageTypeN][(int)ImageCropBorder.kyo境界線_F6] = new Rectangle(6 * PositionImpl.CELL_W, 2 * PositionImpl.CELL_H, PositionImpl.CELL_W, PositionImpl.CELL_H);
                this.Crop[imageTypeN][(int)ImageCropBorder.kyo境界線_F7] = new Rectangle(4 * PositionImpl.CELL_W, 3 * PositionImpl.CELL_H, PositionImpl.CELL_W, PositionImpl.CELL_H);
                this.Crop[imageTypeN][(int)ImageCropBorder.kyo境界線_F8] = new Rectangle(4 * PositionImpl.CELL_W, 4 * PositionImpl.CELL_H, PositionImpl.CELL_W, PositionImpl.CELL_H);
                this.Crop[imageTypeN][(int)ImageCropBorder.kyo境界線_F9] = new Rectangle(4 * PositionImpl.CELL_W, 5 * PositionImpl.CELL_H, PositionImpl.CELL_W, PositionImpl.CELL_H);
                this.Crop[imageTypeN][(int)ImageCropBorder.kyo境界線_F10] = new Rectangle(5 * PositionImpl.CELL_W, 3 * PositionImpl.CELL_H, PositionImpl.CELL_W, PositionImpl.CELL_H);
                this.Crop[imageTypeN][(int)ImageCropBorder.kyo境界線_F11] = new Rectangle(5 * PositionImpl.CELL_W, 4 * PositionImpl.CELL_H, PositionImpl.CELL_W, PositionImpl.CELL_H);
                this.Crop[imageTypeN][(int)ImageCropBorder.kyo境界線_F12] = new Rectangle(5 * PositionImpl.CELL_W, 5 * PositionImpl.CELL_H, PositionImpl.CELL_W, PositionImpl.CELL_H);
                this.Crop[imageTypeN][(int)ImageCropBorder.kyo境界線_G1] = new Rectangle(4 * PositionImpl.CELL_W, 0 * PositionImpl.CELL_H, PositionImpl.CELL_W, PositionImpl.CELL_H);
                this.Crop[imageTypeN][(int)ImageCropBorder.kyo境界線_G2] = new Rectangle(5 * PositionImpl.CELL_W, 0 * PositionImpl.CELL_H, PositionImpl.CELL_W, PositionImpl.CELL_H);
                this.Crop[imageTypeN][(int)ImageCropBorder.kyo境界線_G3] = new Rectangle(6 * PositionImpl.CELL_W, 0 * PositionImpl.CELL_H, PositionImpl.CELL_W, PositionImpl.CELL_H);
                this.Crop[imageTypeN][(int)ImageCropBorder.kyo境界線_G4] = new Rectangle(7 * PositionImpl.CELL_W, 0 * PositionImpl.CELL_H, PositionImpl.CELL_W, PositionImpl.CELL_H);
                this.Crop[imageTypeN][(int)ImageCropBorder.kyo境界線_G5] = new Rectangle(7 * PositionImpl.CELL_W, 1 * PositionImpl.CELL_H, PositionImpl.CELL_W, PositionImpl.CELL_H);
                this.Crop[imageTypeN][(int)ImageCropBorder.kyo境界線_G6] = new Rectangle(7 * PositionImpl.CELL_W, 2 * PositionImpl.CELL_H, PositionImpl.CELL_W, PositionImpl.CELL_H);
            }

            this.Crop[(int)ImageType.Way][(int)ImageCropWay.P] = new Rectangle(0 * PositionImpl.CELL_W, 0 * PositionImpl.CELL_H, PositionImpl.CELL_W, PositionImpl.CELL_H);
            this.Crop[(int)ImageType.Way][(int)ImageCropWay.V] = new Rectangle(1 * PositionImpl.CELL_W, 0 * PositionImpl.CELL_H, PositionImpl.CELL_W, PositionImpl.CELL_H);
            this.Crop[(int)ImageType.Way][(int)ImageCropWay.H] = new Rectangle(2 * PositionImpl.CELL_W, 0 * PositionImpl.CELL_H, PositionImpl.CELL_W, PositionImpl.CELL_H);
            this.Crop[(int)ImageType.Way][(int)ImageCropWay.Patch1] = new Rectangle(0 * PositionImpl.CELL_W, 1 * PositionImpl.CELL_H, PositionImpl.CELL_W, PositionImpl.CELL_H);
            this.Crop[(int)ImageType.Way][(int)ImageCropWay.Patch2] = new Rectangle(1 * PositionImpl.CELL_W, 1 * PositionImpl.CELL_H, PositionImpl.CELL_W, PositionImpl.CELL_H);
            this.Crop[(int)ImageType.Way][(int)ImageCropWay.Patch3] = new Rectangle(2 * PositionImpl.CELL_W, 1 * PositionImpl.CELL_H, PositionImpl.CELL_W, PositionImpl.CELL_H);
            this.Crop[(int)ImageType.Way][(int)ImageCropWay.Patch4] = new Rectangle(0 * PositionImpl.CELL_W, 2 * PositionImpl.CELL_H, PositionImpl.CELL_W, PositionImpl.CELL_H);
            this.Crop[(int)ImageType.Way][(int)ImageCropWay.Patch5] = new Rectangle(1 * PositionImpl.CELL_W, 2 * PositionImpl.CELL_H, PositionImpl.CELL_W, PositionImpl.CELL_H);
            this.Crop[(int)ImageType.Way][(int)ImageCropWay.Patch6] = new Rectangle(2 * PositionImpl.CELL_W, 2 * PositionImpl.CELL_H, PositionImpl.CELL_W, PositionImpl.CELL_H);
            this.Crop[(int)ImageType.Way][(int)ImageCropWay.Patch7] = new Rectangle(0 * PositionImpl.CELL_W, 3 * PositionImpl.CELL_H, PositionImpl.CELL_W, PositionImpl.CELL_H);
            this.Crop[(int)ImageType.Way][(int)ImageCropWay.Patch8] = new Rectangle(1 * PositionImpl.CELL_W, 3 * PositionImpl.CELL_H, PositionImpl.CELL_W, PositionImpl.CELL_H);
            this.Crop[(int)ImageType.Way][(int)ImageCropWay.Patch9] = new Rectangle(2 * PositionImpl.CELL_W, 3 * PositionImpl.CELL_H, PositionImpl.CELL_W, PositionImpl.CELL_H);

            // 個別指定
            this.Crop[(int)ImageType.Normal][(int)ImageCropNormal.R] = new Rectangle(48, 0, 48, 48);//住宅地
            this.Crop[(int)ImageType.Normal][(int)ImageCropNormal.C] = new Rectangle(96, 0, 48, 48);//商業地
            this.Crop[(int)ImageType.Normal][(int)ImageCropNormal.I] = new Rectangle(144, 0, 48, 48);//工業地

            // ボタン
            this.Crop[(int)ImageType.Button][(int)ImageCropButton.sebt線路1] = new Rectangle( 0 * BUTTON_W, 0 * BUTTON_H, BUTTON_W, BUTTON_H);
            this.Crop[(int)ImageType.Button][(int)ImageCropButton.sebt線路2] = new Rectangle( 0 * BUTTON_W, 1 * BUTTON_H, BUTTON_W, BUTTON_H);
            this.Crop[(int)ImageType.Button][(int)ImageCropButton.sebt線路3] = new Rectangle( 0 * BUTTON_W, 2 * BUTTON_H, BUTTON_W, BUTTON_H);
            this.Crop[(int)ImageType.Button][(int)ImageCropButton.sebt線路4] = new Rectangle( 0 * BUTTON_W, 3 * BUTTON_H, BUTTON_W, BUTTON_H);
            this.Crop[(int)ImageType.Button][(int)ImageCropButton.sebt整地1] = new Rectangle( 1 * BUTTON_W, 0 * BUTTON_H, BUTTON_W, BUTTON_H);
            this.Crop[(int)ImageType.Button][(int)ImageCropButton.sebt整地2] = new Rectangle( 1 * BUTTON_W, 1 * BUTTON_H, BUTTON_W, BUTTON_H);
            this.Crop[(int)ImageType.Button][(int)ImageCropButton.sebt整地3] = new Rectangle( 1 * BUTTON_W, 2 * BUTTON_H, BUTTON_W, BUTTON_H);
            this.Crop[(int)ImageType.Button][(int)ImageCropButton.sebt整地4] = new Rectangle( 1 * BUTTON_W, 3 * BUTTON_H, BUTTON_W, BUTTON_H);
            this.Crop[(int)ImageType.Button][(int)ImageCropButton.dobt道路1] = new Rectangle( 2 * BUTTON_W, 0 * BUTTON_H, BUTTON_W, BUTTON_H);
            this.Crop[(int)ImageType.Button][(int)ImageCropButton.dobt道路2] = new Rectangle( 2 * BUTTON_W, 1 * BUTTON_H, BUTTON_W, BUTTON_H);
            this.Crop[(int)ImageType.Button][(int)ImageCropButton.dobt道路3] = new Rectangle( 2 * BUTTON_W, 2 * BUTTON_H, BUTTON_W, BUTTON_H);
            this.Crop[(int)ImageType.Button][(int)ImageCropButton.dobt道路4] = new Rectangle( 2 * BUTTON_W, 3 * BUTTON_H, BUTTON_W, BUTTON_H);
            this.Crop[(int)ImageType.Button][(int)ImageCropButton.bobt太ペン1] = new Rectangle( 3 * BUTTON_W, 0 * BUTTON_H, BUTTON_W, BUTTON_H);
            this.Crop[(int)ImageType.Button][(int)ImageCropButton.bobt太ペン2] = new Rectangle( 3 * BUTTON_W, 1 * BUTTON_H, BUTTON_W, BUTTON_H);
            this.Crop[(int)ImageType.Button][(int)ImageCropButton.bobt太ペン3] = new Rectangle( 3 * BUTTON_W, 2 * BUTTON_H, BUTTON_W, BUTTON_H);
            this.Crop[(int)ImageType.Button][(int)ImageCropButton.bobt太ペン4] = new Rectangle( 3 * BUTTON_W, 3 * BUTTON_H, BUTTON_W, BUTTON_H);
            this.Crop[(int)ImageType.Button][(int)ImageCropButton.pobt送電線1] = new Rectangle(4 * BUTTON_W, 0 * BUTTON_H, BUTTON_W, BUTTON_H);
            this.Crop[(int)ImageType.Button][(int)ImageCropButton.pobt送電線2] = new Rectangle(4 * BUTTON_W, 1 * BUTTON_H, BUTTON_W, BUTTON_H);
            this.Crop[(int)ImageType.Button][(int)ImageCropButton.pobt送電線3] = new Rectangle(4 * BUTTON_W, 2 * BUTTON_H, BUTTON_W, BUTTON_H);
            this.Crop[(int)ImageType.Button][(int)ImageCropButton.pobt送電線4] = new Rectangle(4 * BUTTON_W, 3 * BUTTON_H, BUTTON_W, BUTTON_H);
        }

        /// <summary>
        /// [ImageSourcefile]
        /// [0]なし [1]マップ画像☆ [2]砂地画像☆ [3]ボタン画像☆ [4]道路☆ [5]線路☆ [6]送電線☆
        /// </summary>
        public Image[] Images { get; set; }

        /// <summary>
        /// 切り抜く領域☆
        /// </summary>
        public Rectangle[][] Crop { get; set; }

    }
}

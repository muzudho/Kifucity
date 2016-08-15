using Grayscale.A500_Kifucity.B500_Kifucity.C___300_AnimeGif;
using Grayscale.A500_Kifucity.B500_Kifucity.C___400_Image___;
using Grayscale.A500_Kifucity.B500_Kifucity.C___450_Position;
using Grayscale.A500_Kifucity.B500_Kifucity.C___500_MapProp_;
using Grayscale.A500_Kifucity.B500_Kifucity.C450____Position;
using Grayscale.A500_Kifucity.B500_Kifucity.C500____MapProp_;
using System;
using System.Drawing;
using System.IO;
using System.Text;
using System.Windows.Forms;

namespace Grayscale.A500_Kifucity
{
    public partial class UcMain : UserControl
    {
        /// <summary>
        /// ボタンの大きさ☆（＾～＾）
        /// </summary>
        public const int BUTTON_W = 32;
        public const int BUTTON_H = 32;

        /// <summary>
        /// テーブルの左辺座標。
        /// </summary>
        public int TableLeft { get; set; }

        /// <summary>
        /// テーブルの上辺座標。
        /// </summary>
        public int TableTop { get; set; }

        /// <summary>
        /// マウスダウンしたときのパネル上の座標。
        /// </summary>
        public Point MouseDownLocation { get; set; }

        /// <summary>
        /// [MapchipImageType]
        /// [0]なし [1]マップ画像☆ [2]砂地画像☆ [3]ボタン画像☆
        /// </summary>
        public Image[] Images { get; set; }

        /// <summary>
        /// マップチップ画像に関するデータ。
        /// </summary>
        public MapchipProperty[] MapchipProperties { get; set; }

        /// <summary>
        /// 都市データ☆（＾▽＾）
        /// </summary>
        public Position City { get; set; }

        /// <summary>
        /// 施設を置くブラシ。[0]なし [1]線路 [2]砂地 [3]道路 [4]太ペン
        /// </summary>
        public MapchipBrush[] BrushesFacility { get; set; }

        /// <summary>
        /// ボタンを描くブラシ。
        /// [0]なし [1]線路 [2]整地 [3]道路 ...
        /// </summary>
        public MenuButtonBrush[] BrushesButton { get; set; }

        /// <summary>
        /// マウスボタン押下、開放に反応するオブジェクトが重なっている場合、一番上のオブジェクトをマウス押下し終わったらチェックを立てて、下のボタンを押さないようにするんだぜ☆（＾～＾）
        /// マウスボタンを開放したら 偽 に戻すぜ☆（＾▽＾）
        /// </summary>
        public bool IsButtonEffected { get; set; }

        /// <summary>
        /// セーブファイルのバージョン番号☆
        /// 1:Version行追加
        /// 2:改行修正
        /// 3:Size行,MapData行追加
        /// </summary>
        public int SaveFileVersion { get; set; }

        /// <summary>
        /// TODO: あとでタイマーにする予定☆
        /// とりあえず ペイント１回に付き１増やす☆
        /// </summary>
        public int AnimationCount { get; set; }
        /// <summary>
        /// このゲームのアニメは 8コマ とするぜ☆（＾▽＾）
        /// </summary>
        public const int AnimationCountNum = 8;

        public UcMain()
        {
            InitializeComponent();
        }

        /// <summary>
        /// Paint や、画像出力で使うぜ☆（＾～＾）
        /// </summary>
        private void DrawCanvas(
            Graphics g, int animationCount, bool isVisibleButtuns, bool isVisibleGrid,
            int tableLeft, int tableTop
            )
        {
            g.DrawRectangle(Pens.Black, tableLeft, tableTop,
    this.City.TableCols * PositionImpl.CELL_W, this.City.TableRows * PositionImpl.CELL_H);

            //────────────────────────────────────────
            // 各セルを描画しようぜ☆（＾▽＾）
            //────────────────────────────────────────
            if (null != this.Images)//ビジュアル・エディターでは画像を読込んでない☆（＾～＾）
            {
                // 画像の一部を切り抜いて貼り付け☆（＾▽＾）
                for (int layer = 0; layer < PositionImpl.TABLE_LAYERS; layer++)
                {
                    for (int row = 0; row < this.City.TableRows; row++)
                    {
                        for (int col = 0; col < this.City.TableCols; col++)
                        {
                            if (MapchipCrop.None != this.City.Cells[layer, row, col].MapchipCrop)
                            {
                                // セルには MapchipImageType が入っているので、どの画像ファイルから
                                // 画像を切り抜くのかが分かるぜ☆（＾▽＾）
                                Image img = this.Images[(int)this.City.Cells[layer, row, col].ImageType];

                                if (null != img)
                                {
                                    if (AnimationType.Horizontal8==this.City.Cells[layer, row, col].AnimationType)
                                    {
                                        // アニメーションするセルの場合☆ 8コマと想定☆（＾～＾）
                                        const int span = PositionImpl.CELL_W;
                                        g.DrawImage(img,
                                            new Rectangle(col * PositionImpl.CELL_W + tableLeft, row * PositionImpl.CELL_H + tableTop, PositionImpl.CELL_W, PositionImpl.CELL_H),//ディスプレイ
                                                                                                                                       // 元画像
                                            this.MapchipProperties[(int)this.City.Cells[layer, row, col].MapchipCrop].SourceBounds.X + animationCount % UcMain.AnimationCountNum * span,
                                            this.MapchipProperties[(int)this.City.Cells[layer, row, col].MapchipCrop].SourceBounds.Y,
                                            this.MapchipProperties[(int)this.City.Cells[layer, row, col].MapchipCrop].SourceBounds.Width,
                                            this.MapchipProperties[(int)this.City.Cells[layer, row, col].MapchipCrop].SourceBounds.Height,
                                            GraphicsUnit.Pixel);
                                    }
                                    else if (AnimationType.Horizontal8_span128== this.City.Cells[layer, row, col].AnimationType)
                                    {
                                        // 境界線チップ用の アニメーションだぜ☆（＾～＾）
                                        const int span = 128;
                                        g.DrawImage(img,
                                            new Rectangle(col * PositionImpl.CELL_W + tableLeft, row * PositionImpl.CELL_H + tableTop, PositionImpl.CELL_W, PositionImpl.CELL_H),//ディスプレイ
                                                                                                                                                                                 // 元画像
                                            this.MapchipProperties[(int)this.City.Cells[layer, row, col].MapchipCrop].SourceBounds.X + animationCount % UcMain.AnimationCountNum * span,
                                            this.MapchipProperties[(int)this.City.Cells[layer, row, col].MapchipCrop].SourceBounds.Y,
                                            this.MapchipProperties[(int)this.City.Cells[layer, row, col].MapchipCrop].SourceBounds.Width,
                                            this.MapchipProperties[(int)this.City.Cells[layer, row, col].MapchipCrop].SourceBounds.Height,
                                            GraphicsUnit.Pixel);
                                    }
                                    else
                                    {
                                        // 静止画セルの場合☆
                                        g.DrawImage(img,
                                            new Rectangle(col * PositionImpl.CELL_W + tableLeft, row * PositionImpl.CELL_H + tableTop, PositionImpl.CELL_W, PositionImpl.CELL_H),//ディスプレイ
                                            this.MapchipProperties[(int)this.City.Cells[layer, row, col].MapchipCrop].SourceBounds,// 元画像
                                            GraphicsUnit.Pixel);
                                    }
                                }
                            }
                        }
                    }
                }
            }

            if (isVisibleGrid)
            {
                // グリッドを引こうぜ☆
                // ヨコ線
                for (int col = 1; col < this.City.TableCols; col++)
                {
                    g.DrawLine(Pens.Black,
                        col * PositionImpl.CELL_W + tableLeft,
                        tableTop,
                        col * PositionImpl.CELL_W + tableLeft,
                        this.City.TableRows * PositionImpl.CELL_H + tableTop
                        );
                }

                // タテ線
                for (int row = 1; row < this.City.TableRows; row++)
                {
                    g.DrawLine(Pens.Black,
                        tableLeft,
                        row * PositionImpl.CELL_H + tableTop,
                        this.City.TableCols * PositionImpl.CELL_W + tableLeft,
                        row * PositionImpl.CELL_H + tableTop
                        );
                }
            }

            if (isVisibleButtuns)
            {
                //────────────────────────────────────────
                // ボタンを置こうぜ☆（＾▽＾）
                //────────────────────────────────────────
                this.BrushesButton[(int)ButtonType.se整地].Paint(g, this);
                this.BrushesButton[(int)ButtonType.do道路].Paint(g, this);
                this.BrushesButton[(int)ButtonType.se線路].Paint(g, this);
                this.BrushesButton[(int)ButtonType.bo太ペン].Paint(g, this);
            }

            /*
#if DEBUG
            if(null!= this.ImgMap)
            {
                // 画像の貼り付け☆
                g.DrawImage(this.ImgMap, new Rectangle(0, 0, 600, 400), new Rectangle(0, 0, 600, 400), GraphicsUnit.Pixel);
            }
#endif
            //*/
        }

        private void UcMain_Paint(object sender, PaintEventArgs e)
        {
            // 外枠を描こうぜ☆
            Graphics g = e.Graphics;
            int animationCount = this.AnimationCount;
            this.DrawCanvas(g, animationCount,
                true,//ボタンは表示するぜ☆（＾▽＾）
                true,//グリッドは表示するぜ☆（＾▽＾）
                this.TableLeft,
                this.TableTop
                );
        }

        private void RefreshTitlebar()
        {
            this.ParentForm.Text = "きふシティ  (savefile ver." + this.SaveFileVersion + ")";
        }

        private void UcMain_Load(object sender, System.EventArgs e)
        {
            // セーブファイルのバージョン番号。
            this.SaveFileVersion = 3;
            this.RefreshTitlebar();

            // マップ
            this.City = new PositionImpl();

            // アプリケーション起動時の最初の位置。
            this.TableLeft = 16;
            this.TableTop = 16;

            this.MouseDownLocation = Point.Empty;

            try
            {
                // マップチップ画像読み込み
                this.Images = new Image[]{
                    null,
                    Image.FromFile("./img/map.png"),
                    Image.FromFile("./img/borderAnime_sunachi.png"),//Image.FromFile("./img/border_sunachi.png"),
                    Image.FromFile("./img/buttons.png"),
                    Image.FromFile("./img/anime_16x16x8.png")
                };
                // 全ての画像の(0,128,128)を透明色に指定。
                Color transparentColor = Color.FromArgb(0, 128, 128);
                for (int iImg=1; iImg<(int)ImageType.Num; iImg++)
                {
                    ((Bitmap)this.Images[iImg]).MakeTransparent(transparentColor);
                }


                // マップチップ画像に関するデータ。
                this.MapchipProperties = new MapchipProperty[(int)MapchipCrop.Num];
                this.MapchipProperties[(int)MapchipCrop.None] = new MapchipPropertyImpl(ImageType.Mapchip, 0, 0, 16, 16);

                // アニメ
                this.MapchipProperties[(int)MapchipCrop.anime16x16_1] = new MapchipPropertyImpl(ImageType.Anime_16x16x8, 0 * PositionImpl.CELL_W, 0 * PositionImpl.CELL_H, PositionImpl.CELL_W, PositionImpl.CELL_H);
                /*
                this.MapchipProperties[(int)MapchipCrop.anime16x16_2] = new MapchipPropertyImpl(ImageType.Anime_16x16x8, 1 * PositionImpl.CELL_W, 0 * PositionImpl.CELL_H, PositionImpl.CELL_W, PositionImpl.CELL_H);
                this.MapchipProperties[(int)MapchipCrop.anime16x16_3] = new MapchipPropertyImpl(ImageType.Anime_16x16x8, 2 * PositionImpl.CELL_W, 0 * PositionImpl.CELL_H, PositionImpl.CELL_W, PositionImpl.CELL_H);
                this.MapchipProperties[(int)MapchipCrop.anime16x16_4] = new MapchipPropertyImpl(ImageType.Anime_16x16x8, 3 * PositionImpl.CELL_W, 0 * PositionImpl.CELL_H, PositionImpl.CELL_W, PositionImpl.CELL_H);
                this.MapchipProperties[(int)MapchipCrop.anime16x16_5] = new MapchipPropertyImpl(ImageType.Anime_16x16x8, 4 * PositionImpl.CELL_W, 0 * PositionImpl.CELL_H, PositionImpl.CELL_W, PositionImpl.CELL_H);
                this.MapchipProperties[(int)MapchipCrop.anime16x16_6] = new MapchipPropertyImpl(ImageType.Anime_16x16x8, 5 * PositionImpl.CELL_W, 0 * PositionImpl.CELL_H, PositionImpl.CELL_W, PositionImpl.CELL_H);
                this.MapchipProperties[(int)MapchipCrop.anime16x16_7] = new MapchipPropertyImpl(ImageType.Anime_16x16x8, 6 * PositionImpl.CELL_W, 0 * PositionImpl.CELL_H, PositionImpl.CELL_W, PositionImpl.CELL_H);
                this.MapchipProperties[(int)MapchipCrop.anime16x16_8] = new MapchipPropertyImpl(ImageType.Anime_16x16x8, 7 * PositionImpl.CELL_W, 0 * PositionImpl.CELL_H, PositionImpl.CELL_W, PositionImpl.CELL_H);
                */

                this.MapchipProperties[(int)MapchipCrop.R] = new MapchipPropertyImpl(ImageType.Mapchip, 48, 0, 48, 48);//住宅地
                this.MapchipProperties[(int)MapchipCrop.C] = new MapchipPropertyImpl(ImageType.Mapchip, 96, 0, 48, 48);//商業地
                this.MapchipProperties[(int)MapchipCrop.I] = new MapchipPropertyImpl(ImageType.Mapchip, 144, 0, 48, 48);//工業地
                this.MapchipProperties[(int)MapchipCrop.kyo境界線_A1] = new MapchipPropertyImpl(ImageType.Border_Sunachi, 1 * PositionImpl.CELL_W, 0 * PositionImpl.CELL_H, PositionImpl.CELL_W, PositionImpl.CELL_H);
                this.MapchipProperties[(int)MapchipCrop.kyo境界線_A2] = new MapchipPropertyImpl(ImageType.Border_Sunachi, 2 * PositionImpl.CELL_W, 0 * PositionImpl.CELL_H, PositionImpl.CELL_W, PositionImpl.CELL_H);
                this.MapchipProperties[(int)MapchipCrop.kyo境界線_A3] = new MapchipPropertyImpl(ImageType.Border_Sunachi, 3 * PositionImpl.CELL_W, 0 * PositionImpl.CELL_H, PositionImpl.CELL_W, PositionImpl.CELL_H);
                this.MapchipProperties[(int)MapchipCrop.kyo境界線_A4] = new MapchipPropertyImpl(ImageType.Border_Sunachi, 1 * PositionImpl.CELL_W, 1 * PositionImpl.CELL_H, PositionImpl.CELL_W, PositionImpl.CELL_H);
                this.MapchipProperties[(int)MapchipCrop.kyo境界線_A5] = new MapchipPropertyImpl(ImageType.Border_Sunachi, 2 * PositionImpl.CELL_W, 1 * PositionImpl.CELL_H, PositionImpl.CELL_W, PositionImpl.CELL_H);
                this.MapchipProperties[(int)MapchipCrop.kyo境界線_A6] = new MapchipPropertyImpl(ImageType.Border_Sunachi, 3 * PositionImpl.CELL_W, 1 * PositionImpl.CELL_H, PositionImpl.CELL_W, PositionImpl.CELL_H);
                this.MapchipProperties[(int)MapchipCrop.kyo境界線_A7] = new MapchipPropertyImpl(ImageType.Border_Sunachi, 1 * PositionImpl.CELL_W, 2 * PositionImpl.CELL_H, PositionImpl.CELL_W, PositionImpl.CELL_H);
                this.MapchipProperties[(int)MapchipCrop.kyo境界線_A8] = new MapchipPropertyImpl(ImageType.Border_Sunachi, 2 * PositionImpl.CELL_W, 2 * PositionImpl.CELL_H, PositionImpl.CELL_W, PositionImpl.CELL_H);
                this.MapchipProperties[(int)MapchipCrop.kyo境界線_A9] = new MapchipPropertyImpl(ImageType.Border_Sunachi, 3 * PositionImpl.CELL_W, 2 * PositionImpl.CELL_H, PositionImpl.CELL_W, PositionImpl.CELL_H);
                this.MapchipProperties[(int)MapchipCrop.kyo境界線_B1] = new MapchipPropertyImpl(ImageType.Border_Sunachi, 0 * PositionImpl.CELL_W, 3 * PositionImpl.CELL_H, PositionImpl.CELL_W, PositionImpl.CELL_H);
                this.MapchipProperties[(int)MapchipCrop.kyo境界線_B2] = new MapchipPropertyImpl(ImageType.Border_Sunachi, 1 * PositionImpl.CELL_W, 3 * PositionImpl.CELL_H, PositionImpl.CELL_W, PositionImpl.CELL_H);
                this.MapchipProperties[(int)MapchipCrop.kyo境界線_B3] = new MapchipPropertyImpl(ImageType.Border_Sunachi, 0 * PositionImpl.CELL_W, 4 * PositionImpl.CELL_H, PositionImpl.CELL_W, PositionImpl.CELL_H);
                this.MapchipProperties[(int)MapchipCrop.kyo境界線_B4] = new MapchipPropertyImpl(ImageType.Border_Sunachi, 1 * PositionImpl.CELL_W, 4 * PositionImpl.CELL_H, PositionImpl.CELL_W, PositionImpl.CELL_H);
                this.MapchipProperties[(int)MapchipCrop.kyo境界線_C1] = new MapchipPropertyImpl(ImageType.Border_Sunachi, 2 * PositionImpl.CELL_W, 3 * PositionImpl.CELL_H, PositionImpl.CELL_W, PositionImpl.CELL_H);
                this.MapchipProperties[(int)MapchipCrop.kyo境界線_C2] = new MapchipPropertyImpl(ImageType.Border_Sunachi, 3 * PositionImpl.CELL_W, 3 * PositionImpl.CELL_H, PositionImpl.CELL_W, PositionImpl.CELL_H);
                this.MapchipProperties[(int)MapchipCrop.kyo境界線_C3] = new MapchipPropertyImpl(ImageType.Border_Sunachi, 2 * PositionImpl.CELL_W, 4 * PositionImpl.CELL_H, PositionImpl.CELL_W, PositionImpl.CELL_H);
                this.MapchipProperties[(int)MapchipCrop.kyo境界線_C4] = new MapchipPropertyImpl(ImageType.Border_Sunachi, 3 * PositionImpl.CELL_W, 4 * PositionImpl.CELL_H, PositionImpl.CELL_W, PositionImpl.CELL_H);
                this.MapchipProperties[(int)MapchipCrop.kyo境界線_D] = new MapchipPropertyImpl(ImageType.Border_Sunachi, 0 * PositionImpl.CELL_W, 5 * PositionImpl.CELL_H, PositionImpl.CELL_W, PositionImpl.CELL_H);
                this.MapchipProperties[(int)MapchipCrop.kyo境界線_E6] = new MapchipPropertyImpl(ImageType.Border_Sunachi, 1 * PositionImpl.CELL_W, 5 * PositionImpl.CELL_H, PositionImpl.CELL_W, PositionImpl.CELL_H);
                this.MapchipProperties[(int)MapchipCrop.kyo境界線_E13] = new MapchipPropertyImpl(ImageType.Border_Sunachi, 2 * PositionImpl.CELL_W, 5 * PositionImpl.CELL_H, PositionImpl.CELL_W, PositionImpl.CELL_H);
                this.MapchipProperties[(int)MapchipCrop.kyo境界線_E10] = new MapchipPropertyImpl(ImageType.Border_Sunachi, 3 * PositionImpl.CELL_W, 5 * PositionImpl.CELL_H, PositionImpl.CELL_W, PositionImpl.CELL_H);
                this.MapchipProperties[(int)MapchipCrop.kyo境界線_E12] = new MapchipPropertyImpl(ImageType.Border_Sunachi, 0 * PositionImpl.CELL_W, 6 * PositionImpl.CELL_H, PositionImpl.CELL_W, PositionImpl.CELL_H);
                this.MapchipProperties[(int)MapchipCrop.kyo境界線_E14] = new MapchipPropertyImpl(ImageType.Border_Sunachi, 1 * PositionImpl.CELL_W, 6 * PositionImpl.CELL_H, PositionImpl.CELL_W, PositionImpl.CELL_H);
                this.MapchipProperties[(int)MapchipCrop.kyo境界線_E15] = new MapchipPropertyImpl(ImageType.Border_Sunachi, 2 * PositionImpl.CELL_W, 6 * PositionImpl.CELL_H, PositionImpl.CELL_W, PositionImpl.CELL_H);
                this.MapchipProperties[(int)MapchipCrop.kyo境界線_E9] = new MapchipPropertyImpl(ImageType.Border_Sunachi, 3 * PositionImpl.CELL_W, 6 * PositionImpl.CELL_H, PositionImpl.CELL_W, PositionImpl.CELL_H);
                this.MapchipProperties[(int)MapchipCrop.kyo境界線_E3] = new MapchipPropertyImpl(ImageType.Border_Sunachi, 0 * PositionImpl.CELL_W, 7 * PositionImpl.CELL_H, PositionImpl.CELL_W, PositionImpl.CELL_H);
                this.MapchipProperties[(int)MapchipCrop.kyo境界線_E7] = new MapchipPropertyImpl(ImageType.Border_Sunachi, 1 * PositionImpl.CELL_W, 7 * PositionImpl.CELL_H, PositionImpl.CELL_W, PositionImpl.CELL_H);
                this.MapchipProperties[(int)MapchipCrop.kyo境界線_E11] = new MapchipPropertyImpl(ImageType.Border_Sunachi, 2 * PositionImpl.CELL_W, 7 * PositionImpl.CELL_H, PositionImpl.CELL_W, PositionImpl.CELL_H);
                this.MapchipProperties[(int)MapchipCrop.kyo境界線_E5] = new MapchipPropertyImpl(ImageType.Border_Sunachi, 3 * PositionImpl.CELL_W, 7 * PositionImpl.CELL_H, PositionImpl.CELL_W, PositionImpl.CELL_H);
                this.MapchipProperties[(int)MapchipCrop.kyo境界線_F1] = new MapchipPropertyImpl(ImageType.Border_Sunachi, 4 * PositionImpl.CELL_W, 1 * PositionImpl.CELL_H, PositionImpl.CELL_W, PositionImpl.CELL_H);
                this.MapchipProperties[(int)MapchipCrop.kyo境界線_F2] = new MapchipPropertyImpl(ImageType.Border_Sunachi, 5 * PositionImpl.CELL_W, 1 * PositionImpl.CELL_H, PositionImpl.CELL_W, PositionImpl.CELL_H);
                this.MapchipProperties[(int)MapchipCrop.kyo境界線_F3] = new MapchipPropertyImpl(ImageType.Border_Sunachi, 6 * PositionImpl.CELL_W, 1 * PositionImpl.CELL_H, PositionImpl.CELL_W, PositionImpl.CELL_H);
                this.MapchipProperties[(int)MapchipCrop.kyo境界線_F4] = new MapchipPropertyImpl(ImageType.Border_Sunachi, 4 * PositionImpl.CELL_W, 2 * PositionImpl.CELL_H, PositionImpl.CELL_W, PositionImpl.CELL_H);
                this.MapchipProperties[(int)MapchipCrop.kyo境界線_F5] = new MapchipPropertyImpl(ImageType.Border_Sunachi, 5 * PositionImpl.CELL_W, 2 * PositionImpl.CELL_H, PositionImpl.CELL_W, PositionImpl.CELL_H);
                this.MapchipProperties[(int)MapchipCrop.kyo境界線_F6] = new MapchipPropertyImpl(ImageType.Border_Sunachi, 6 * PositionImpl.CELL_W, 2 * PositionImpl.CELL_H, PositionImpl.CELL_W, PositionImpl.CELL_H);
                this.MapchipProperties[(int)MapchipCrop.kyo境界線_F7] = new MapchipPropertyImpl(ImageType.Border_Sunachi, 4 * PositionImpl.CELL_W, 3 * PositionImpl.CELL_H, PositionImpl.CELL_W, PositionImpl.CELL_H);
                this.MapchipProperties[(int)MapchipCrop.kyo境界線_F8] = new MapchipPropertyImpl(ImageType.Border_Sunachi, 4 * PositionImpl.CELL_W, 4 * PositionImpl.CELL_H, PositionImpl.CELL_W, PositionImpl.CELL_H);
                this.MapchipProperties[(int)MapchipCrop.kyo境界線_F9] = new MapchipPropertyImpl(ImageType.Border_Sunachi, 4 * PositionImpl.CELL_W, 5 * PositionImpl.CELL_H, PositionImpl.CELL_W, PositionImpl.CELL_H);
                this.MapchipProperties[(int)MapchipCrop.kyo境界線_F10] = new MapchipPropertyImpl(ImageType.Border_Sunachi, 5 * PositionImpl.CELL_W, 3 * PositionImpl.CELL_H, PositionImpl.CELL_W, PositionImpl.CELL_H);
                this.MapchipProperties[(int)MapchipCrop.kyo境界線_F11] = new MapchipPropertyImpl(ImageType.Border_Sunachi, 5 * PositionImpl.CELL_W, 4 * PositionImpl.CELL_H, PositionImpl.CELL_W, PositionImpl.CELL_H);
                this.MapchipProperties[(int)MapchipCrop.kyo境界線_F12] = new MapchipPropertyImpl(ImageType.Border_Sunachi, 5 * PositionImpl.CELL_W, 5 * PositionImpl.CELL_H, PositionImpl.CELL_W, PositionImpl.CELL_H);
                this.MapchipProperties[(int)MapchipCrop.kyo境界線_G1] = new MapchipPropertyImpl(ImageType.Border_Sunachi, 4 * PositionImpl.CELL_W, 0 * PositionImpl.CELL_H, PositionImpl.CELL_W, PositionImpl.CELL_H);
                this.MapchipProperties[(int)MapchipCrop.kyo境界線_G2] = new MapchipPropertyImpl(ImageType.Border_Sunachi, 5 * PositionImpl.CELL_W, 0 * PositionImpl.CELL_H, PositionImpl.CELL_W, PositionImpl.CELL_H);
                this.MapchipProperties[(int)MapchipCrop.kyo境界線_G3] = new MapchipPropertyImpl(ImageType.Border_Sunachi, 6 * PositionImpl.CELL_W, 0 * PositionImpl.CELL_H, PositionImpl.CELL_W, PositionImpl.CELL_H);
                this.MapchipProperties[(int)MapchipCrop.kyo境界線_G4] = new MapchipPropertyImpl(ImageType.Border_Sunachi, 7 * PositionImpl.CELL_W, 0 * PositionImpl.CELL_H, PositionImpl.CELL_W, PositionImpl.CELL_H);
                this.MapchipProperties[(int)MapchipCrop.kyo境界線_G5] = new MapchipPropertyImpl(ImageType.Border_Sunachi, 7 * PositionImpl.CELL_W, 1 * PositionImpl.CELL_H, PositionImpl.CELL_W, PositionImpl.CELL_H);
                this.MapchipProperties[(int)MapchipCrop.kyo境界線_G6] = new MapchipPropertyImpl(ImageType.Border_Sunachi, 7 * PositionImpl.CELL_W, 2 * PositionImpl.CELL_H, PositionImpl.CELL_W, PositionImpl.CELL_H);

                this.MapchipProperties[(int)MapchipCrop.do道路P] = new MapchipPropertyImpl(ImageType.Mapchip, 48, 48, 16, 16);
                this.MapchipProperties[(int)MapchipCrop.do道路V] = new MapchipPropertyImpl(ImageType.Mapchip, 64, 48, 16, 16);
                this.MapchipProperties[(int)MapchipCrop.do道路H] = new MapchipPropertyImpl(ImageType.Mapchip, 80, 48, 16, 16);
                this.MapchipProperties[(int)MapchipCrop.do道路_田1] = new MapchipPropertyImpl(ImageType.Mapchip, 48, 64, 16, 16);
                this.MapchipProperties[(int)MapchipCrop.do道路_田2] = new MapchipPropertyImpl(ImageType.Mapchip, 64, 64, 16, 16);
                this.MapchipProperties[(int)MapchipCrop.do道路_田3] = new MapchipPropertyImpl(ImageType.Mapchip, 80, 64, 16, 16);
                this.MapchipProperties[(int)MapchipCrop.do道路_田4] = new MapchipPropertyImpl(ImageType.Mapchip, 48, 80, 16, 16);
                this.MapchipProperties[(int)MapchipCrop.do道路_田5] = new MapchipPropertyImpl(ImageType.Mapchip, 64, 80, 16, 16);
                this.MapchipProperties[(int)MapchipCrop.do道路_田6] = new MapchipPropertyImpl(ImageType.Mapchip, 80, 80, 16, 16);
                this.MapchipProperties[(int)MapchipCrop.do道路_田7] = new MapchipPropertyImpl(ImageType.Mapchip, 48, 96, 16, 16);
                this.MapchipProperties[(int)MapchipCrop.do道路_田8] = new MapchipPropertyImpl(ImageType.Mapchip, 64, 96, 16, 16);
                this.MapchipProperties[(int)MapchipCrop.do道路_田9] = new MapchipPropertyImpl(ImageType.Mapchip, 80, 96, 16, 16);

                this.MapchipProperties[(int)MapchipCrop.se線路P] = new MapchipPropertyImpl(ImageType.Mapchip, 48, 112, 16, 16);
                this.MapchipProperties[(int)MapchipCrop.se線路V] = new MapchipPropertyImpl(ImageType.Mapchip, 64, 112, 16, 16);
                this.MapchipProperties[(int)MapchipCrop.se線路H] = new MapchipPropertyImpl(ImageType.Mapchip, 80, 112, 16, 16);
                this.MapchipProperties[(int)MapchipCrop.se線路_田1] = new MapchipPropertyImpl(ImageType.Mapchip, 48, 128, 16, 16);
                this.MapchipProperties[(int)MapchipCrop.se線路_田2] = new MapchipPropertyImpl(ImageType.Mapchip, 64, 128, 16, 16);
                this.MapchipProperties[(int)MapchipCrop.se線路_田3] = new MapchipPropertyImpl(ImageType.Mapchip, 80, 128, 16, 16);
                this.MapchipProperties[(int)MapchipCrop.se線路_田4] = new MapchipPropertyImpl(ImageType.Mapchip, 48, 144, 16, 16);
                this.MapchipProperties[(int)MapchipCrop.se線路_田5] = new MapchipPropertyImpl(ImageType.Mapchip, 64, 144, 16, 16);
                this.MapchipProperties[(int)MapchipCrop.se線路_田6] = new MapchipPropertyImpl(ImageType.Mapchip, 80, 144, 16, 16);
                this.MapchipProperties[(int)MapchipCrop.se線路_田7] = new MapchipPropertyImpl(ImageType.Mapchip, 48, 160, 16, 16);
                this.MapchipProperties[(int)MapchipCrop.se線路_田8] = new MapchipPropertyImpl(ImageType.Mapchip, 64, 160, 16, 16);
                this.MapchipProperties[(int)MapchipCrop.se線路_田9] = new MapchipPropertyImpl(ImageType.Mapchip, 80, 160, 16, 16);

                // ボタン
                this.MapchipProperties[(int)MapchipCrop.sebt線路1] = new MapchipPropertyImpl(ImageType.Buttons, 0 * BUTTON_W, 0 * BUTTON_H, BUTTON_W, BUTTON_H);
                this.MapchipProperties[(int)MapchipCrop.sebt線路2] = new MapchipPropertyImpl(ImageType.Buttons, 0 * BUTTON_W, 1 * BUTTON_H, BUTTON_W, BUTTON_H);
                this.MapchipProperties[(int)MapchipCrop.sebt線路3] = new MapchipPropertyImpl(ImageType.Buttons, 0 * BUTTON_W, 2 * BUTTON_H, BUTTON_W, BUTTON_H);
                this.MapchipProperties[(int)MapchipCrop.sebt線路4] = new MapchipPropertyImpl(ImageType.Buttons, 0 * BUTTON_W, 3 * BUTTON_H, BUTTON_W, BUTTON_H);
                this.MapchipProperties[(int)MapchipCrop.sebt整地1] = new MapchipPropertyImpl(ImageType.Buttons, 1 * BUTTON_W, 0 * BUTTON_H, BUTTON_W, BUTTON_H);
                this.MapchipProperties[(int)MapchipCrop.sebt整地2] = new MapchipPropertyImpl(ImageType.Buttons, 1 * BUTTON_W, 1 * BUTTON_H, BUTTON_W, BUTTON_H);
                this.MapchipProperties[(int)MapchipCrop.sebt整地3] = new MapchipPropertyImpl(ImageType.Buttons, 1 * BUTTON_W, 2 * BUTTON_H, BUTTON_W, BUTTON_H);
                this.MapchipProperties[(int)MapchipCrop.sebt整地4] = new MapchipPropertyImpl(ImageType.Buttons, 1 * BUTTON_W, 3 * BUTTON_H, BUTTON_W, BUTTON_H);
                this.MapchipProperties[(int)MapchipCrop.dobt道路1] = new MapchipPropertyImpl(ImageType.Buttons, 2 * BUTTON_W, 0 * BUTTON_H, BUTTON_W, BUTTON_H);
                this.MapchipProperties[(int)MapchipCrop.dobt道路2] = new MapchipPropertyImpl(ImageType.Buttons, 2 * BUTTON_W, 1 * BUTTON_H, BUTTON_W, BUTTON_H);
                this.MapchipProperties[(int)MapchipCrop.dobt道路3] = new MapchipPropertyImpl(ImageType.Buttons, 2 * BUTTON_W, 2 * BUTTON_H, BUTTON_W, BUTTON_H);
                this.MapchipProperties[(int)MapchipCrop.dobt道路4] = new MapchipPropertyImpl(ImageType.Buttons, 2 * BUTTON_W, 3 * BUTTON_H, BUTTON_W, BUTTON_H);
                this.MapchipProperties[(int)MapchipCrop.bobt太ペン1] = new MapchipPropertyImpl(ImageType.Buttons, 3 * BUTTON_W, 0 * BUTTON_H, BUTTON_W, BUTTON_H);
                this.MapchipProperties[(int)MapchipCrop.bobt太ペン2] = new MapchipPropertyImpl(ImageType.Buttons, 3 * BUTTON_W, 1 * BUTTON_H, BUTTON_W, BUTTON_H);
                this.MapchipProperties[(int)MapchipCrop.bobt太ペン3] = new MapchipPropertyImpl(ImageType.Buttons, 3 * BUTTON_W, 2 * BUTTON_H, BUTTON_W, BUTTON_H);
                this.MapchipProperties[(int)MapchipCrop.bobt太ペン4] = new MapchipPropertyImpl(ImageType.Buttons, 3 * BUTTON_W, 3 * BUTTON_H, BUTTON_W, BUTTON_H);
            }
            catch (Exception)
            {
                // ビジュアル・エディター等のFormではファイルの読み込みに失敗することがある。
            }

            //────────────────────────────────────────
            // ブラシ
            //────────────────────────────────────────
            this.BrushesButton = new MenuButtonBrush[]
            {
                null,
                new MenuButtonBrushImpl(ImageType.Buttons, 0*BUTTON_W+32,0*BUTTON_H+32,BUTTON_W,BUTTON_H,MapchipCrop.sebt線路1,MapchipCrop.sebt線路2,MapchipCrop.sebt線路3,MapchipCrop.sebt線路4),
                new MenuButtonBrushImpl(ImageType.Buttons, 1*BUTTON_W+32,0*BUTTON_H+32,BUTTON_W,BUTTON_H,MapchipCrop.sebt整地1,MapchipCrop.sebt整地2,MapchipCrop.sebt整地3,MapchipCrop.sebt整地4),
                new MenuButtonBrushImpl(ImageType.Buttons, 0*BUTTON_W+32,1*BUTTON_H+32,BUTTON_W,BUTTON_H,MapchipCrop.dobt道路1,MapchipCrop.dobt道路2,MapchipCrop.dobt道路3,MapchipCrop.dobt道路4),
                new MenuButtonBrushImpl(ImageType.Buttons, 1*BUTTON_W+32,1*BUTTON_H+32,BUTTON_W,BUTTON_H,MapchipCrop.bobt太ペン1,MapchipCrop.bobt太ペン2,MapchipCrop.bobt太ペン3,MapchipCrop.bobt太ペン4),
            };
            this.BrushesFacility = new MapchipBrush[]
            {
                null,
                // 線路
                new MapchipRailwayBrushImpl(
                    PositionImpl.LAYER_RAILWAY,
                    ImageType.Mapchip,
                    MapchipCrop.se線路P,
                    MapchipCrop.se線路V,
                    MapchipCrop.se線路H,
                    MapchipCrop.se線路_田1,
                    MapchipCrop.se線路_田2,
                    MapchipCrop.se線路_田3,
                    MapchipCrop.se線路_田4,
                    MapchipCrop.se線路_田5,
                    MapchipCrop.se線路_田6,
                    MapchipCrop.se線路_田7,
                    MapchipCrop.se線路_田8,
                    MapchipCrop.se線路_田9
                ),
                // 砂地
                new MapchipBulldozerBrushImpl(
                    PositionImpl.LAYER_LAND,
                    ImageType.Border_Sunachi,
                    AnimationType.Horizontal8_span128,
                    MapchipCrop.kyo境界線_A1,
                    MapchipCrop.kyo境界線_A2,
                    MapchipCrop.kyo境界線_A3,
                    MapchipCrop.kyo境界線_A4,
                    MapchipCrop.kyo境界線_A5,
                    MapchipCrop.kyo境界線_A6,
                    MapchipCrop.kyo境界線_A7,
                    MapchipCrop.kyo境界線_A8,
                    MapchipCrop.kyo境界線_A9,
                    MapchipCrop.kyo境界線_B1,
                    MapchipCrop.kyo境界線_B2,
                    MapchipCrop.kyo境界線_B3,
                    MapchipCrop.kyo境界線_B4,
                    MapchipCrop.kyo境界線_C1,
                    MapchipCrop.kyo境界線_C2,
                    MapchipCrop.kyo境界線_C3,
                    MapchipCrop.kyo境界線_C4,
                    MapchipCrop.kyo境界線_D,
                    MapchipCrop.kyo境界線_E6,
                    MapchipCrop.kyo境界線_E13,
                    MapchipCrop.kyo境界線_E10,
                    MapchipCrop.kyo境界線_E12,
                    MapchipCrop.kyo境界線_E14,
                    MapchipCrop.kyo境界線_E15,
                    MapchipCrop.kyo境界線_E9,
                    MapchipCrop.kyo境界線_E3,
                    MapchipCrop.kyo境界線_E7,
                    MapchipCrop.kyo境界線_E11,
                    MapchipCrop.kyo境界線_E5,
                    MapchipCrop.kyo境界線_F1,
                    MapchipCrop.kyo境界線_F2,
                    MapchipCrop.kyo境界線_F3,
                    MapchipCrop.kyo境界線_F4,
                    MapchipCrop.kyo境界線_F5,
                    MapchipCrop.kyo境界線_F6,
                    MapchipCrop.kyo境界線_F7,
                    MapchipCrop.kyo境界線_F8,
                    MapchipCrop.kyo境界線_F9,
                    MapchipCrop.kyo境界線_F10,
                    MapchipCrop.kyo境界線_F11,
                    MapchipCrop.kyo境界線_F12,
                    MapchipCrop.kyo境界線_G1,
                    MapchipCrop.kyo境界線_G2,
                    MapchipCrop.kyo境界線_G3,
                    MapchipCrop.kyo境界線_G4,
                    MapchipCrop.kyo境界線_G5,
                    MapchipCrop.kyo境界線_G6
                ),
                // 道路
                new MapchipRailwayBrushImpl(
                    PositionImpl.LAYER_ROAD,
                    ImageType.Mapchip,
                    MapchipCrop.do道路P,
                    MapchipCrop.do道路V,
                    MapchipCrop.do道路H,
                    MapchipCrop.do道路_田1,
                    MapchipCrop.do道路_田2,
                    MapchipCrop.do道路_田3,
                    MapchipCrop.do道路_田4,
                    MapchipCrop.do道路_田5,
                    MapchipCrop.do道路_田6,
                    MapchipCrop.do道路_田7,
                    MapchipCrop.do道路_田8,
                    MapchipCrop.do道路_田9
                ),
                //砂地（太ペン）
                new MapchipBoldBrushImpl(
                    PositionImpl.LAYER_LAND,
                    ImageType.Border_Sunachi,
                    AnimationType.Horizontal8_span128,
                    MapchipCrop.kyo境界線_A5
                )
            };

            // 海で初期化☆（＾▽＾）
            this.City.Init();

            //────────────────────────────────────────
            // タイマー・スタート☆
            //────────────────────────────────────────
            this.timer1.Start();
        }

        private void UcMain_MouseDown(object sender, MouseEventArgs e)
        {
            bool isRefresh = false;
            this.MouseDownLocation = e.Location;

            if (MouseButtons.Left == e.Button)
            {
                // 左ボタンなら

                //────────────────────────────────────────
                // ボタン押下
                //────────────────────────────────────────
                ButtonType pushedButton = ButtonType.None;
                for (int iBtn = 1; iBtn < (int)ButtonType.Num; iBtn++)
                {
                    if (this.BrushesButton[iBtn].DestinationBounds.Contains(e.Location))
                    {
                        pushedButton = (ButtonType)iBtn;

                        switch (this.BrushesButton[iBtn].ButtonState)
                        {
                            case ButtonState2.Pushable_MouseOver:
                                this.BrushesButton[iBtn].ButtonState = ButtonState2.Pushed_MouseOver;
                                isRefresh = true;
                                break;
                            case ButtonState2.Pushed_MouseOver:
                                this.BrushesButton[iBtn].ButtonState = ButtonState2.Pushable_MouseOver;
                                isRefresh = true;
                                break;
                        }
                    }
                }
                // ボタン押下の解除
                if (ButtonType.None!=pushedButton)
                {
                    for (int iBtn = 1; iBtn < (int)ButtonType.Num; iBtn++)
                    {
                        if (pushedButton != (ButtonType)iBtn)
                        {
                            this.BrushesButton[iBtn].ButtonState = ButtonState2.Pushable;
                        }
                    }

                    this.IsButtonEffected = true;
                }

                // 施設を置く☆
                if(!this.IsButtonEffected)
                {
                    int col = (e.Location.X - this.TableLeft) / PositionImpl.CELL_W;
                    int row = (e.Location.Y - this.TableTop) / PositionImpl.CELL_H;
                    if (col < this.City.TableCols && row < this.City.TableRows)
                    {
                        for(int iBtn=1; iBtn<(int)ButtonType.Num; iBtn++)
                        {
                            if (this.BrushesButton[iBtn].ButtonState==ButtonState2.Pushed ||
                                this.BrushesButton[iBtn].ButtonState == ButtonState2.Pushed_MouseOver)
                            {
                                this.BrushesFacility[iBtn].UpdateNeighborhood(this //this.MapImg
                                    , row, col);
                            }
                        }

                        isRefresh = true;
                    }
                }
            }

            if (isRefresh)
            {
                this.Refresh();
            }
        }

        private void UcMain_MouseUp(object sender, MouseEventArgs e)
        {
            if (MouseButtons.Right == e.Button)
            {
                if (!this.IsButtonEffected)
                {
                    // マウスの右ボタンで、マップ引きずる
                    int deltaX = e.Location.X - this.MouseDownLocation.X;
                    int deltaY = e.Location.Y - this.MouseDownLocation.Y;

                    this.TableLeft += deltaX;
                    this.TableTop += deltaY;
                    this.Refresh();
                }
            }
            else if (MouseButtons.Left == e.Button)
            {
                // 左ボタンなら
                // 砂地を置く☆
                if (!this.IsButtonEffected)
                {
                    int col = (e.Location.X - this.TableLeft) / PositionImpl.CELL_W;
                    int row = (e.Location.Y - this.TableTop) / PositionImpl.CELL_H;
                    if (col < this.City.TableCols && row < this.City.TableRows)
                    {
                        //this.BrushRailway.UpdateNeighborhood(this //this.MapImg
                        //    , row, col);
                        for (int iBtn = 1; iBtn < (int)ButtonType.Num; iBtn++)
                        {
                            if (this.BrushesButton[iBtn].ButtonState == ButtonState2.Pushed ||
                                this.BrushesButton[iBtn].ButtonState == ButtonState2.Pushed_MouseOver)
                            {
                                this.BrushesFacility[iBtn].UpdateNeighborhood(this //this.MapImg
                                    , row, col);
                            }
                        }

                        this.Refresh();
                    }
                }
            }

            // マウスのドラッグは終わった☆
            this.MouseDownLocation = Point.Empty;

            this.IsButtonEffected = false;
        }

        private void UcMain_MouseMove(object sender, MouseEventArgs e)
        {
            bool isRefresh = false;

            //────────────────────────────────────────
            // ボタン
            //────────────────────────────────────────
            for (int iBtn = 1; iBtn < (int)ButtonType.Num; iBtn++)
            {
                if (this.BrushesButton[iBtn].DestinationBounds.Contains(e.Location))
                {
                    switch (this.BrushesButton[iBtn].ButtonState)
                    {
                        case ButtonState2.Pushable:
                            this.BrushesButton[iBtn].ButtonState = ButtonState2.Pushable_MouseOver;
                            isRefresh = true;
                            break;
                        case ButtonState2.Pushed:
                            this.BrushesButton[iBtn].ButtonState = ButtonState2.Pushed_MouseOver;
                            isRefresh = true;
                            break;
                    }
                }
                else
                {
                    switch (this.BrushesButton[iBtn].ButtonState)
                    {
                        case ButtonState2.Pushable_MouseOver:
                            this.BrushesButton[iBtn].ButtonState = ButtonState2.Pushable;
                            isRefresh = true;
                            break;
                        case ButtonState2.Pushed_MouseOver:
                            this.BrushesButton[iBtn].ButtonState = ButtonState2.Pushed;
                            isRefresh = true;
                            break;
                    }
                }
            }

            if (MouseButtons.Right == e.Button)
            {
                // マウスの右ボタンで、マップ引きずる
                if (this.MouseDownLocation != Point.Empty)
                {
                    // マウスでマップを引きずっているようなら

                    if (!this.IsButtonEffected)
                    {
                        int deltaX = e.Location.X - this.MouseDownLocation.X;
                        int deltaY = e.Location.Y - this.MouseDownLocation.Y;

                        this.TableLeft += deltaX;
                        this.TableTop += deltaY;

                        // すぐ更新☆ すぐ描画☆
                        this.MouseDownLocation = e.Location;
                        isRefresh = true;
                    }
                }
            }
            else if (MouseButtons.Left == e.Button)
            {
                // 左ボタンなら

                if (this.MouseDownLocation != Point.Empty)
                {
                    // 施設を置く☆

                    if (!this.IsButtonEffected)
                    {
                        for (int iBtn = 1; iBtn < (int)ButtonType.Num; iBtn++)
                        {
                            if (
                                this.BrushesButton[(int)iBtn].ButtonState == ButtonState2.Pushed ||
                                this.BrushesButton[(int)iBtn].ButtonState == ButtonState2.Pushed_MouseOver)
                            {
                                bool isUpdate;
                                this.BrushesFacility[(int)iBtn].PutMapchipAsLine(out isUpdate, e.Location, this);
                                if (isUpdate)
                                {
                                    this.MouseDownLocation = e.Location;
                                    isRefresh = true;
                                }
                            }
                        }
                    }
                }
            }

            if (isRefresh)
            {
                this.Refresh();
            }
        }

        /// <summary>
        /// TODO: Gifアニメの出力を試す☆
        /// </summary>
        private void ExportGifAnimation()
        {
            // 8コマのアニメにするぜ☆（＾▽＾）
            Bitmap[] bitmapImages = new Bitmap[UcMain.AnimationCountNum];

            for (int iAnimationCount=0; iAnimationCount<UcMain.AnimationCountNum; iAnimationCount++)
            {
                Bitmap img = new Bitmap(
                    this.City.TableCols * PositionImpl.CELL_W,
                    this.City.TableRows * PositionImpl.CELL_H
                    );

                // ImageオブジェクトのGraphicsオブジェクトを作成する
                Graphics g = Graphics.FromImage(img);

                // 都市を描画するぜ☆（＾▽＾）
                this.DrawCanvas(g, iAnimationCount,
                    false,//メニューは表示しないぜ☆（＾▽＾）
                    false,//グリッドは表示しないぜ☆（＾▽＾）
                    0,0//マージンは無しだぜ☆（＾▽＾）
                    );

                //リソースを解放する
                g.Dispose();

                bitmapImages[iAnimationCount] = img;
            }

            Util_AnimationGif.SaveAnimatedGif("./your_city.gif",
                bitmapImages,
                12,// ほんとは 12.5 にしたかった☆（／＿＼）
                0
                );
        }

        public const int MapchipImageSaveNumber = 512;
        /// <summary>
        /// 一時保存
        /// </summary>
        private void SaveGame()
        {
            StringBuilder sb = new StringBuilder();

            // [0]行目は「Version,セーブファイルのバージョン番号,」で固定☆
            sb.Append("Version,");
            sb.Append(this.SaveFileVersion);
            sb.AppendLine(",");//ここで改行☆（＾～＾）

            // [1]行目は「MapSize,列数,行数」で固定☆
            sb.Append("MapSize,");
            sb.Append(this.City.TableCols);
            sb.Append(",");
            sb.Append(this.City.TableRows);
            sb.AppendLine(",");//ここで改行☆（＾～＾）

            // マップデータが始まる前に「MapData」を入れる☆
            sb.AppendLine("MapData,");//ここで改行☆（＾～＾）
            for (int layer = 0; layer < PositionImpl.TABLE_LAYERS; layer++)
            {
                for (int row = 0; row < this.City.TableRows; row++)
                {
                    for (int col = 0; col < this.City.TableCols; col++)
                    {
                        sb.Append(
                            MapchipImageSaveNumber * (int)this.City.Cells[layer, row, col].ImageType +
                            (int)this.City.Cells[layer, row, col].MapchipCrop
                        );
                        sb.Append(",");
                    }
                    sb.AppendLine();
                }
                sb.AppendLine();
                sb.AppendLine();
            }

            File.WriteAllText("./save.txt", sb.ToString());

            // おまけ☆
            this.ExportGifAnimation();
        }

        /// <summary>
        /// 再開
        /// </summary>
        private void LoadGame()
        {
            string[] lines = File.ReadAllLines("./save.txt");

            int headerRow = 0;
            int line = 0;

            for (int layer = 0; layer < PositionImpl.TABLE_LAYERS; layer++)
            {
                for (int row = 0; row < this.City.TableRows && line< lines.Length; line++)
                {
                    if (""==lines[line].Trim())
                    {
                        // 空行は無視☆
                        continue;
                    }

                    string[] tokens = lines[line].Split(',');

                    if (0== headerRow && 1<tokens.Length && "Version"==tokens[0])
                    {
                        // [0]行目の[0]列目が「Version」なら、[1]列目はセーブファイル仕様のバージョン番号。
                        int version;
                        if (int.TryParse(tokens[1], out version))
                        {
                            this.SaveFileVersion = version;
                        }

                        headerRow++;
                        continue;
                    }
                    else if (1 == headerRow && 2 < tokens.Length && "MapSize" == tokens[0])
                    {
                        // [1]行目は「MapSize,列数,行数」で固定☆
                        // [1]列目は列数☆
                        int cols;
                        if (int.TryParse(tokens[1], out cols))
                        {
                            this.City.TableCols = cols;
                        }

                        // [2]列目は行数☆
                        int rows;
                        if (int.TryParse(tokens[2], out rows))
                        {
                            this.City.TableRows = rows;
                        }

                        headerRow++;
                        continue;
                    }
                    else if (1 < tokens.Length && "MapData" == tokens[0])
                    {
                        // 「MapData」値で始まる行は無視☆
                        continue;
                    }

                    for (int col = 0; col < this.City.TableCols && col < tokens.Length; col++)
                    {
                        int number;
                        if (int.TryParse(tokens[col],out number))
                        {
                            this.City.Cells[layer, row, col].MapchipCrop = (MapchipCrop)(number % MapchipImageSaveNumber);
                            this.City.Cells[layer, row, col].ImageType = (ImageType)(number / MapchipImageSaveNumber);
                        }
                    }
                    row++;
                }
            }

            this.RefreshTitlebar();
            this.Refresh();
        }

        private void UcMain_PreviewKeyDown(object sender, PreviewKeyDownEventArgs e)
        {
            if (e.Control)
            {
                switch (e.KeyCode)
                {
                    case Keys.D1:
                        {
                            // マップを破棄し、マップのサイズを小さくするぜ☆（＾▽＾）
                            // ツイッターで見るぐらい小さなサイズだぜ☆（＾▽＾）
                            this.City.ChangeSizeMap(16, 16);
                            this.Refresh();
                        }
                        break;
                    case Keys.L:
                        {
                            // ロード
                            this.LoadGame();
                        }
                        break;
                    case Keys.S:
                        {
                            // セーブ
                            this.SaveGame();
                        }
                        break;
                }
            }
        }

        /// <summary>
        /// タイマー☆
        /// インターバル 125 にしておけば、秒間8コマになるな☆（＾▽＾）
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void timer1_Tick(object sender, EventArgs e)
        {
            this.AnimationCount++;
            this.Refresh();
        }
    }
}

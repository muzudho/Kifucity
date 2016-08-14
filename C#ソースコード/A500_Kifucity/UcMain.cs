using Grayscale.A500_Kifucity.B500_Kifucity.C___500_MapProp_;
using Grayscale.A500_Kifucity.B500_Kifucity.C500____MapProp_;
using System;
using System.Drawing;
using System.Windows.Forms;
using System.Text;
using System.IO;

namespace Grayscale.A500_Kifucity
{
    public partial class UcMain : UserControl
    {
        // マップの広さ（固定長）
        public const int TABLE_COLS = 120;
        public const int TABLE_ROWS = 100;
        public const int TABLE_LAYERS = 2;
        // マスの大きさ
        public const int CELL_W = 16;
        public const int CELL_H = 16;

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
        /// マップ画像☆
        /// </summary>
        public Image ImgMap { get; set; }
        /// <summary>
        /// 砂地画像☆
        /// </summary>
        public Image ImgSunachi { get; set; }

        /// <summary>
        /// マップチップ画像に関するデータ。
        /// </summary>
        public MapchipProperty[] MapchipProperties { get; set; }

        /// <summary>
        /// マップ・データ。[layer,row,col]
        /// </summary>
        public MapchipCrop[,,] MapData1 { get; set; }
        public MapchipImageType[,,] MapData2 { get; set; }

        /// <summary>
        /// 施設を置くブラシ。[0]なし [1]線路 [2]砂地 [3]道路
        /// </summary>
        public MapchipBrush[] BrushesFacility { get; set; }

        /// <summary>
        /// ボタンを描くブラシ。
        /// [0]なし [1]線路 [2]整地 [3]道路 ...
        /// </summary>
        public MapchipButtonBrush[] BrushesButton { get; set; }

        /// <summary>
        /// マウスボタン押下、開放に反応するオブジェクトが重なっている場合、一番上のオブジェクトをマウス押下し終わったらチェックを立てて、下のボタンを押さないようにするんだぜ☆（＾～＾）
        /// マウスボタンを開放したら 偽 に戻すぜ☆（＾▽＾）
        /// </summary>
        public bool IsButtonEffected { get; set; }

        public UcMain()
        {
            InitializeComponent();
        }

        private void UcMain_Paint(object sender, PaintEventArgs e)
        {
            // 外枠を描こうぜ☆
            Graphics g = e.Graphics;

            g.DrawRectangle(Pens.Black, this.TableLeft, this.TableTop,
                TABLE_COLS*CELL_W, TABLE_ROWS*CELL_H);

            if (null != this.ImgMap)
            {
                // 画像の一部を切り抜いて貼り付け☆（＾▽＾）
                for (int layer = 0; layer < TABLE_LAYERS; layer++)
                {
                    for (int row = 0; row < TABLE_ROWS; row++)
                    {
                        for (int col = 0; col < TABLE_COLS; col++)
                        {
                            if(MapchipCrop.None != this.MapData1[layer, row, col])
                            {
                                Image img;
                                switch (this.MapData2[layer, row, col])
                                {
                                    case MapchipImageType.Border_Sunachi:
                                        // 境界線チップ_砂地 にあるもの。
                                        img = this.ImgSunachi;
                                        break;
                                    default:// 旧仕様に対応
                                    case MapchipImageType.Mapchip:
                                        // マップチップにあるもの。
                                        img = this.ImgMap;
                                        break;
                                }

                                g.DrawImage(img,
                                    new Rectangle(col * CELL_W + this.TableLeft, row * CELL_H + this.TableTop, CELL_W, CELL_H),//ディスプレイ
                                    this.MapchipProperties[(int)this.MapData1[layer, row, col]].SourceBounds,// new Rectangle(1 * cellW, 0 * cellH, cellW, cellH),//元画像
                                    GraphicsUnit.Pixel);
                            }
                        }
                    }
                }
            }

            // グリッドを引こうぜ☆
            // ヨコ線
            for (int col = 1; col < TABLE_COLS; col++)
            {
                g.DrawLine(Pens.Black,
                    col * CELL_W + this.TableLeft,
                    this.TableTop,
                    col * CELL_W + this.TableLeft,
                    TABLE_ROWS * CELL_H + this.TableTop
                    );
            }

            // タテ線
            for (int row = 1; row < TABLE_ROWS; row++)
            {
                g.DrawLine(Pens.Black,
                    this.TableLeft,
                    row * CELL_H + this.TableTop,
                    TABLE_COLS * CELL_W + this.TableLeft,
                    row * CELL_H + this.TableTop
                    );
            }

            //────────────────────────────────────────
            // ボタンを置こうぜ☆（＾▽＾）
            //────────────────────────────────────────
            // 整地
            this.BrushesButton[(int)ButtonType.se整地].Paint(g, this);
            // 道路
            this.BrushesButton[(int)ButtonType.do道路].Paint(g, this);
            // 線路
            this.BrushesButton[(int)ButtonType.se線路].Paint(g, this);

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

        private void UcMain_Load(object sender, System.EventArgs e)
        {
            // アプリケーション起動時の最初の位置。
            this.TableLeft = 16;
            this.TableTop = 16;

            this.MouseDownLocation = Point.Empty;

            try
            {
                // マップチップ画像読み込み
                this.ImgMap = Image.FromFile("./img/map.png");
                this.ImgSunachi = Image.FromFile("./img/border_sunachi.png");

                // マップチップ画像に関するデータ。
                this.MapchipProperties = new MapchipProperty[(int)MapchipCrop.Num];
                this.MapchipProperties[(int)MapchipCrop.None] = new MapchipPropertyImpl(0, 0, 16, 16);
                this.MapchipProperties[(int)MapchipCrop.u海] = new MapchipPropertyImpl(16, 0, 16, 16);
                this.MapchipProperties[(int)MapchipCrop.R] = new MapchipPropertyImpl(48, 0, 48, 48);//住宅地
                this.MapchipProperties[(int)MapchipCrop.C] = new MapchipPropertyImpl(96, 0, 48, 48);//商業地
                this.MapchipProperties[(int)MapchipCrop.I] = new MapchipPropertyImpl(144, 0, 48, 48);//工業地
                this.MapchipProperties[(int)MapchipCrop.kyo境界線_A1] = new MapchipPropertyImpl(1 * CELL_W, 0 * CELL_H, CELL_W, CELL_H);
                this.MapchipProperties[(int)MapchipCrop.kyo境界線_A2] = new MapchipPropertyImpl(2 * CELL_W, 0 * CELL_H, CELL_W, CELL_H);
                this.MapchipProperties[(int)MapchipCrop.kyo境界線_A3] = new MapchipPropertyImpl(3 * CELL_W, 0 * CELL_H, CELL_W, CELL_H);
                this.MapchipProperties[(int)MapchipCrop.kyo境界線_A4] = new MapchipPropertyImpl(1 * CELL_W, 1 * CELL_H, CELL_W, CELL_H);
                this.MapchipProperties[(int)MapchipCrop.kyo境界線_A5] = new MapchipPropertyImpl(2 * CELL_W, 1 * CELL_H, CELL_W, CELL_H);
                this.MapchipProperties[(int)MapchipCrop.kyo境界線_A6] = new MapchipPropertyImpl(3 * CELL_W, 1 * CELL_H, CELL_W, CELL_H);
                this.MapchipProperties[(int)MapchipCrop.kyo境界線_A7] = new MapchipPropertyImpl(1 * CELL_W, 2 * CELL_H, CELL_W, CELL_H);
                this.MapchipProperties[(int)MapchipCrop.kyo境界線_A8] = new MapchipPropertyImpl(2 * CELL_W, 2 * CELL_H, CELL_W, CELL_H);
                this.MapchipProperties[(int)MapchipCrop.kyo境界線_A9] = new MapchipPropertyImpl(3 * CELL_W, 2 * CELL_H, CELL_W, CELL_H);
                this.MapchipProperties[(int)MapchipCrop.kyo境界線_B1] = new MapchipPropertyImpl(0 * CELL_W, 3 * CELL_H, CELL_W, CELL_H);
                this.MapchipProperties[(int)MapchipCrop.kyo境界線_B2] = new MapchipPropertyImpl(1 * CELL_W, 3 * CELL_H, CELL_W, CELL_H);
                this.MapchipProperties[(int)MapchipCrop.kyo境界線_B3] = new MapchipPropertyImpl(0 * CELL_W, 4 * CELL_H, CELL_W, CELL_H);
                this.MapchipProperties[(int)MapchipCrop.kyo境界線_B4] = new MapchipPropertyImpl(1 * CELL_W, 4 * CELL_H, CELL_W, CELL_H);
                this.MapchipProperties[(int)MapchipCrop.kyo境界線_C1] = new MapchipPropertyImpl(0 * CELL_W, 3 * CELL_H, CELL_W, CELL_H);
                this.MapchipProperties[(int)MapchipCrop.kyo境界線_C2] = new MapchipPropertyImpl(1 * CELL_W, 3 * CELL_H, CELL_W, CELL_H);
                this.MapchipProperties[(int)MapchipCrop.kyo境界線_C3] = new MapchipPropertyImpl(0 * CELL_W, 4 * CELL_H, CELL_W, CELL_H);
                this.MapchipProperties[(int)MapchipCrop.kyo境界線_C4] = new MapchipPropertyImpl(1 * CELL_W, 4 * CELL_H, CELL_W, CELL_H);
                this.MapchipProperties[(int)MapchipCrop.kyo境界線_D] = new MapchipPropertyImpl(0 * CELL_W, 5 * CELL_H, CELL_W, CELL_H);
                this.MapchipProperties[(int)MapchipCrop.kyo境界線_E6] = new MapchipPropertyImpl(1 * CELL_W, 5 * CELL_H, CELL_W, CELL_H);
                this.MapchipProperties[(int)MapchipCrop.kyo境界線_E13] = new MapchipPropertyImpl(2 * CELL_W, 5 * CELL_H, CELL_W, CELL_H);
                this.MapchipProperties[(int)MapchipCrop.kyo境界線_E10] = new MapchipPropertyImpl(3 * CELL_W, 5 * CELL_H, CELL_W, CELL_H);
                this.MapchipProperties[(int)MapchipCrop.kyo境界線_E12] = new MapchipPropertyImpl(0 * CELL_W, 6 * CELL_H, CELL_W, CELL_H);
                this.MapchipProperties[(int)MapchipCrop.kyo境界線_E14] = new MapchipPropertyImpl(1 * CELL_W, 6 * CELL_H, CELL_W, CELL_H);
                this.MapchipProperties[(int)MapchipCrop.kyo境界線_E15] = new MapchipPropertyImpl(2 * CELL_W, 6 * CELL_H, CELL_W, CELL_H);
                this.MapchipProperties[(int)MapchipCrop.kyo境界線_E9] = new MapchipPropertyImpl(3 * CELL_W, 6 * CELL_H, CELL_W, CELL_H);
                this.MapchipProperties[(int)MapchipCrop.kyo境界線_E3] = new MapchipPropertyImpl(0 * CELL_W, 7 * CELL_H, CELL_W, CELL_H);
                this.MapchipProperties[(int)MapchipCrop.kyo境界線_E7] = new MapchipPropertyImpl(1 * CELL_W, 7 * CELL_H, CELL_W, CELL_H);
                this.MapchipProperties[(int)MapchipCrop.kyo境界線_E11] = new MapchipPropertyImpl(2 * CELL_W, 7 * CELL_H, CELL_W, CELL_H);
                this.MapchipProperties[(int)MapchipCrop.kyo境界線_E5] = new MapchipPropertyImpl(3 * CELL_W, 7 * CELL_H, CELL_W, CELL_H);
                this.MapchipProperties[(int)MapchipCrop.kyo境界線_F1x] = new MapchipPropertyImpl(4 * CELL_W, 1 * CELL_H, CELL_W, CELL_H);
                this.MapchipProperties[(int)MapchipCrop.kyo境界線_F2x] = new MapchipPropertyImpl(5 * CELL_W, 1 * CELL_H, CELL_W, CELL_H);
                this.MapchipProperties[(int)MapchipCrop.kyo境界線_F3x] = new MapchipPropertyImpl(6 * CELL_W, 1 * CELL_H, CELL_W, CELL_H);
                this.MapchipProperties[(int)MapchipCrop.kyo境界線_F4x] = new MapchipPropertyImpl(4 * CELL_W, 2 * CELL_H, CELL_W, CELL_H);
                this.MapchipProperties[(int)MapchipCrop.kyo境界線_F5x] = new MapchipPropertyImpl(5 * CELL_W, 2 * CELL_H, CELL_W, CELL_H);
                this.MapchipProperties[(int)MapchipCrop.kyo境界線_F6x] = new MapchipPropertyImpl(6 * CELL_W, 2 * CELL_H, CELL_W, CELL_H);
                this.MapchipProperties[(int)MapchipCrop.kyo境界線_F7x] = new MapchipPropertyImpl(4 * CELL_W, 3 * CELL_H, CELL_W, CELL_H);
                this.MapchipProperties[(int)MapchipCrop.kyo境界線_F8x] = new MapchipPropertyImpl(4 * CELL_W, 4 * CELL_H, CELL_W, CELL_H);
                this.MapchipProperties[(int)MapchipCrop.kyo境界線_F9x] = new MapchipPropertyImpl(4 * CELL_W, 5 * CELL_H, CELL_W, CELL_H);
                this.MapchipProperties[(int)MapchipCrop.kyo境界線_F10x] = new MapchipPropertyImpl(5 * CELL_W, 3 * CELL_H, CELL_W, CELL_H);
                this.MapchipProperties[(int)MapchipCrop.kyo境界線_F11x] = new MapchipPropertyImpl(5 * CELL_W, 4 * CELL_H, CELL_W, CELL_H);
                this.MapchipProperties[(int)MapchipCrop.kyo境界線_F12x] = new MapchipPropertyImpl(5 * CELL_W, 5 * CELL_H, CELL_W, CELL_H);
                this.MapchipProperties[(int)MapchipCrop.kyo境界線_G1x] = new MapchipPropertyImpl(4 * CELL_W, 0 * CELL_H, CELL_W, CELL_H);
                this.MapchipProperties[(int)MapchipCrop.kyo境界線_G2x] = new MapchipPropertyImpl(5 * CELL_W, 0 * CELL_H, CELL_W, CELL_H);
                this.MapchipProperties[(int)MapchipCrop.kyo境界線_G3x] = new MapchipPropertyImpl(6 * CELL_W, 0 * CELL_H, CELL_W, CELL_H);
                this.MapchipProperties[(int)MapchipCrop.kyo境界線_G4x] = new MapchipPropertyImpl(7 * CELL_W, 0 * CELL_H, CELL_W, CELL_H);
                this.MapchipProperties[(int)MapchipCrop.kyo境界線_G5x] = new MapchipPropertyImpl(7 * CELL_W, 1 * CELL_H, CELL_W, CELL_H);
                this.MapchipProperties[(int)MapchipCrop.kyo境界線_G6x] = new MapchipPropertyImpl(7 * CELL_W, 2 * CELL_H, CELL_W, CELL_H);

                this.MapchipProperties[(int)MapchipCrop.do道路P] = new MapchipPropertyImpl(48, 48, 16, 16);
                this.MapchipProperties[(int)MapchipCrop.do道路V] = new MapchipPropertyImpl(64, 48, 16, 16);
                this.MapchipProperties[(int)MapchipCrop.do道路H] = new MapchipPropertyImpl(80, 48, 16, 16);
                this.MapchipProperties[(int)MapchipCrop.do道路_田1] = new MapchipPropertyImpl(48, 64, 16, 16);
                this.MapchipProperties[(int)MapchipCrop.do道路_田2] = new MapchipPropertyImpl(64, 64, 16, 16);
                this.MapchipProperties[(int)MapchipCrop.do道路_田3] = new MapchipPropertyImpl(80, 64, 16, 16);
                this.MapchipProperties[(int)MapchipCrop.do道路_田4] = new MapchipPropertyImpl(48, 80, 16, 16);
                this.MapchipProperties[(int)MapchipCrop.do道路_田5] = new MapchipPropertyImpl(64, 80, 16, 16);
                this.MapchipProperties[(int)MapchipCrop.do道路_田6] = new MapchipPropertyImpl(80, 80, 16, 16);
                this.MapchipProperties[(int)MapchipCrop.do道路_田7] = new MapchipPropertyImpl(48, 96, 16, 16);
                this.MapchipProperties[(int)MapchipCrop.do道路_田8] = new MapchipPropertyImpl(64, 96, 16, 16);
                this.MapchipProperties[(int)MapchipCrop.do道路_田9] = new MapchipPropertyImpl(80, 96, 16, 16);

                this.MapchipProperties[(int)MapchipCrop.se線路P] = new MapchipPropertyImpl(48, 112, 16, 16);
                this.MapchipProperties[(int)MapchipCrop.se線路V] = new MapchipPropertyImpl(64, 112, 16, 16);
                this.MapchipProperties[(int)MapchipCrop.se線路H] = new MapchipPropertyImpl(80, 112, 16, 16);
                this.MapchipProperties[(int)MapchipCrop.se線路_田1] = new MapchipPropertyImpl(48, 128, 16, 16);
                this.MapchipProperties[(int)MapchipCrop.se線路_田2] = new MapchipPropertyImpl(64, 128, 16, 16);
                this.MapchipProperties[(int)MapchipCrop.se線路_田3] = new MapchipPropertyImpl(80, 128, 16, 16);
                this.MapchipProperties[(int)MapchipCrop.se線路_田4] = new MapchipPropertyImpl(48, 144, 16, 16);
                this.MapchipProperties[(int)MapchipCrop.se線路_田5] = new MapchipPropertyImpl(64, 144, 16, 16);
                this.MapchipProperties[(int)MapchipCrop.se線路_田6] = new MapchipPropertyImpl(80, 144, 16, 16);
                this.MapchipProperties[(int)MapchipCrop.se線路_田7] = new MapchipPropertyImpl(48, 160, 16, 16);
                this.MapchipProperties[(int)MapchipCrop.se線路_田8] = new MapchipPropertyImpl(64, 160, 16, 16);
                this.MapchipProperties[(int)MapchipCrop.se線路_田9] = new MapchipPropertyImpl(80, 160, 16, 16);

                this.MapchipProperties[(int)MapchipCrop.sebt線路1] = new MapchipPropertyImpl(192, 0, 32, 32);
                this.MapchipProperties[(int)MapchipCrop.sebt線路2] = new MapchipPropertyImpl(192, 32, 32, 32);
                this.MapchipProperties[(int)MapchipCrop.sebt線路3] = new MapchipPropertyImpl(192, 64, 32, 32);
                this.MapchipProperties[(int)MapchipCrop.sebt線路4] = new MapchipPropertyImpl(192, 96, 32, 32);
                this.MapchipProperties[(int)MapchipCrop.sebt整地1] = new MapchipPropertyImpl(224, 0, 32, 32);
                this.MapchipProperties[(int)MapchipCrop.sebt整地2] = new MapchipPropertyImpl(224, 32, 32, 32);
                this.MapchipProperties[(int)MapchipCrop.sebt整地3] = new MapchipPropertyImpl(224, 64, 32, 32);
                this.MapchipProperties[(int)MapchipCrop.sebt整地4] = new MapchipPropertyImpl(224, 96, 32, 32);
                this.MapchipProperties[(int)MapchipCrop.dobt道路1] = new MapchipPropertyImpl(256, 0, 32, 32);
                this.MapchipProperties[(int)MapchipCrop.dobt道路2] = new MapchipPropertyImpl(256, 32, 32, 32);
                this.MapchipProperties[(int)MapchipCrop.dobt道路3] = new MapchipPropertyImpl(256, 64, 32, 32);
                this.MapchipProperties[(int)MapchipCrop.dobt道路4] = new MapchipPropertyImpl(256, 96, 32, 32);
            }
            catch (Exception)
            {
                // ビジュアル・エディター等のFormではファイルの読み込みに失敗することがある。
            }

            //────────────────────────────────────────
            // ブラシ
            //────────────────────────────────────────
            this.BrushesButton = new MapchipButtonBrush[]
            {
                null,
                new MapchipButtonBrushImpl(32,32,32,32,MapchipCrop.sebt線路1,MapchipCrop.sebt線路2,MapchipCrop.sebt線路3,MapchipCrop.sebt線路4),
                new MapchipButtonBrushImpl(64,32,32,32,MapchipCrop.sebt整地1,MapchipCrop.sebt整地2,MapchipCrop.sebt整地3,MapchipCrop.sebt整地4),
                new MapchipButtonBrushImpl(32,64,32,32,MapchipCrop.dobt道路1,MapchipCrop.dobt道路2,MapchipCrop.dobt道路3,MapchipCrop.dobt道路4),
            };
            this.BrushesFacility = new MapchipBrush[]
            {
                null,
                new MapchipRailwayBrushImpl(
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
                new MapchipBulldozerBrushImpl(
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
                MapchipCrop.kyo境界線_F1x,
                MapchipCrop.kyo境界線_F2x,
                MapchipCrop.kyo境界線_F3x,
                MapchipCrop.kyo境界線_F4x,
                MapchipCrop.kyo境界線_F5x,
                MapchipCrop.kyo境界線_F6x,
                MapchipCrop.kyo境界線_F7x,
                MapchipCrop.kyo境界線_F8x,
                MapchipCrop.kyo境界線_F9x,
                MapchipCrop.kyo境界線_F10x,
                MapchipCrop.kyo境界線_F11x,
                MapchipCrop.kyo境界線_F12x,
                MapchipCrop.kyo境界線_G1x,
                MapchipCrop.kyo境界線_G2x,
                MapchipCrop.kyo境界線_G3x,
                MapchipCrop.kyo境界線_G4x,
                MapchipCrop.kyo境界線_G5x,
                MapchipCrop.kyo境界線_G6x
                ),
                new MapchipRailwayBrushImpl(
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
                )
            };

            this.MapData1 = new MapchipCrop[2, UcMain.TABLE_ROWS, UcMain.TABLE_COLS];
            this.MapData2 = new MapchipImageType[2, UcMain.TABLE_ROWS, UcMain.TABLE_COLS];
            // レイヤー[1] を海で埋め尽くすぜ☆（＾▽＾）
            int layer = 1;
            for (int row = 0; row < TABLE_ROWS; row++)
            {
                for (int col = 0; col < TABLE_COLS; col++)
                {
                    this.MapData1[layer, row, col] = MapchipCrop.u海;
                    this.MapData2[layer, row, col] = MapchipImageType.Mapchip;
                }
            }
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
                    int col = (e.Location.X - this.TableLeft) / CELL_W;
                    int row = (e.Location.Y - this.TableTop) / CELL_H;
                    if (col < TABLE_COLS && row < TABLE_ROWS)
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
                    int col = (e.Location.X - this.TableLeft) / CELL_W;
                    int row = (e.Location.Y - this.TableTop) / CELL_H;
                    if (col < TABLE_COLS && row < TABLE_ROWS)
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


        public const int MapchipImageSaveNumber = 512;
        /// <summary>
        /// 一時保存
        /// </summary>
        private void SaveGame()
        {
            StringBuilder sb = new StringBuilder();
            for (int layer = 0; layer < TABLE_LAYERS; layer++)
            {
                for (int row = 0; row < TABLE_ROWS; row++)
                {
                    for (int col = 0; col < TABLE_COLS; col++)
                    {
                        sb.Append(
                            MapchipImageSaveNumber * (int)this.MapData2[layer, row, col] +
                            (int)this.MapData1[layer, row, col]
                        );
                        sb.Append(",");
                    }
                    sb.AppendLine();
                }
                sb.AppendLine();
                sb.AppendLine();
            }

            File.WriteAllText("./save.txt", sb.ToString());
        }

        /// <summary>
        /// 再開
        /// </summary>
        private void LoadGame()
        {
            string[] lines = File.ReadAllLines("./save.txt");

            int line = 0;
            for (int layer = 0; layer < TABLE_LAYERS; layer++)
            {
                for (int row = 0; row < TABLE_ROWS; row++, line++)
                {
                    if (""==lines[line].Trim())
                    {
                        // 空行は無視☆
                        continue;
                    }

                    string[] tokens = lines[line].Split(',');

                    for (int col = 0; col < TABLE_COLS; col++)
                    {
                        int number;
                        if (int.TryParse(tokens[col],out number))
                        {
                            this.MapData1[layer, row, col] = (MapchipCrop)(number % MapchipImageSaveNumber);
                            this.MapData2[layer, row, col] = (MapchipImageType)(number / MapchipImageSaveNumber);
                        }
                    }
                }
            }

            this.Refresh();
        }

        private void UcMain_PreviewKeyDown(object sender, PreviewKeyDownEventArgs e)
        {
            if (e.Control)
            {
                switch (e.KeyCode)
                {
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
    }
}

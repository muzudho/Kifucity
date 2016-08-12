using System.Drawing;
using System.Windows.Forms;
using System;
using System.Collections.Generic;
using Grayscale.A500_Kifucity.B500_Kifucity.C___500_MapProp_;
using Grayscale.A500_Kifucity.B500_Kifucity.C500____MapProp_;

namespace Grayscale.A500_Kifucity
{
    public partial class UcMain : UserControl
    {
        // マップの広さ（固定長）
        public const int TABLE_COLS = 120;
        public const int TABLE_ROWS = 100;
        public const int TABLE_LAYERS = 2;

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
        /// マップチップ画像に関するデータ。
        /// </summary>
        public MapchipProperty[] MapchipProperties { get; set; }

        /// <summary>
        /// マップ・データ。[layer,row,col]
        /// </summary>
        public MapchipType[,,] MapImg { get; set; }

        public UcMain()
        {
            InitializeComponent();
        }

        private void UcMain_Paint(object sender, PaintEventArgs e)
        {
            // マスの大きさ
            int cellW = 16;
            int cellH = 16;

            // 外枠を描こうぜ☆
            Graphics g = e.Graphics;

            g.DrawRectangle(Pens.Black, this.TableLeft, this.TableTop,
                TABLE_COLS*cellW, TABLE_ROWS*cellH);

            if (null != this.ImgMap)
            {
                // 画像の一部を切り抜いて貼り付け☆（＾▽＾）
                for (int layer = 0; layer < TABLE_LAYERS; layer++)
                {
                    for (int row = 0; row < TABLE_ROWS; row++)
                    {
                        for (int col = 0; col < TABLE_COLS; col++)
                        {
                            if(MapchipType.None != this.MapImg[layer, row, col])
                            {
                                g.DrawImage(this.ImgMap,
                                    new Rectangle(col * cellW + this.TableLeft, row * cellH + this.TableTop, cellW, cellH),//ディスプレイ
                                    this.MapchipProperties[(int)this.MapImg[layer, row, col]].SourceBounds,// new Rectangle(1 * cellW, 0 * cellH, cellW, cellH),//元画像
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
                    col * cellW + this.TableLeft,
                    this.TableTop,
                    col * cellW + this.TableLeft,
                    TABLE_ROWS * cellH + this.TableTop
                    );
            }

            // タテ線
            for (int row = 1; row < TABLE_ROWS; row++)
            {
                g.DrawLine(Pens.Black,
                    this.TableLeft,
                    row * cellH + this.TableTop,
                    TABLE_COLS * cellW + this.TableLeft,
                    row * cellH + this.TableTop
                    );
            }

#if DEBUG
            if(null!= this.ImgMap)
            {
                // 画像の貼り付け☆
                g.DrawImage(this.ImgMap, new Rectangle(0, 0, 600, 400), new Rectangle(0, 0, 600, 400), GraphicsUnit.Pixel);
            }
#endif
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

                // マップチップ画像に関するデータ。
                this.MapchipProperties = new MapchipProperty[(int)MapchipType.Num];
                this.MapchipProperties[(int)MapchipType.None] = new MapchipPropertyImpl(0, 0, 16, 16);
                this.MapchipProperties[(int)MapchipType.u海] = new MapchipPropertyImpl(16, 0, 16, 16);
                this.MapchipProperties[(int)MapchipType.R] = new MapchipPropertyImpl(48, 0, 48, 48);//住宅地
                this.MapchipProperties[(int)MapchipType.C] = new MapchipPropertyImpl(96, 0, 48, 48);//商業地
                this.MapchipProperties[(int)MapchipType.I] = new MapchipPropertyImpl(144, 0, 48, 48);//工業地
                this.MapchipProperties[(int)MapchipType.su砂_田1] = new MapchipPropertyImpl(0, 16, 16, 16);
                this.MapchipProperties[(int)MapchipType.su砂_田2] = new MapchipPropertyImpl(16, 16, 16, 16);
                this.MapchipProperties[(int)MapchipType.su砂_田3] = new MapchipPropertyImpl(32, 16, 16, 16);
                this.MapchipProperties[(int)MapchipType.su砂_田4] = new MapchipPropertyImpl(0, 32, 16, 16);
                this.MapchipProperties[(int)MapchipType.su砂_田5] = new MapchipPropertyImpl(16, 32, 16, 16);
                this.MapchipProperties[(int)MapchipType.su砂_田6] = new MapchipPropertyImpl(32, 32, 16, 16);
                this.MapchipProperties[(int)MapchipType.su砂_田7] = new MapchipPropertyImpl(0, 48, 16, 16);
                this.MapchipProperties[(int)MapchipType.su砂_田8] = new MapchipPropertyImpl(16, 48, 16, 16);
                this.MapchipProperties[(int)MapchipType.su砂_田9] = new MapchipPropertyImpl(32, 48, 16, 16);
                this.MapchipProperties[(int)MapchipType.su砂_逆田1] = new MapchipPropertyImpl(0, 64, 16, 16);
                this.MapchipProperties[(int)MapchipType.su砂_逆田3] = new MapchipPropertyImpl(16, 64, 16, 16);
                this.MapchipProperties[(int)MapchipType.su砂_逆田7] = new MapchipPropertyImpl(0, 80, 16, 16);
                this.MapchipProperties[(int)MapchipType.su砂_逆田9] = new MapchipPropertyImpl(16, 80, 16, 16);
                this.MapchipProperties[(int)MapchipType.si芝_田1] = new MapchipPropertyImpl(0, 96, 16, 16);
                this.MapchipProperties[(int)MapchipType.si芝_田2] = new MapchipPropertyImpl(16, 96, 16, 16);
                this.MapchipProperties[(int)MapchipType.si芝_田3] = new MapchipPropertyImpl(32, 96, 16, 16);
                this.MapchipProperties[(int)MapchipType.si芝_田4] = new MapchipPropertyImpl(0, 112, 16, 16);
                this.MapchipProperties[(int)MapchipType.si芝_田5] = new MapchipPropertyImpl(16, 112, 16, 16);
                this.MapchipProperties[(int)MapchipType.si芝_田6] = new MapchipPropertyImpl(32, 112, 16, 16);
                this.MapchipProperties[(int)MapchipType.si芝_田7] = new MapchipPropertyImpl(0, 128, 16, 16);
                this.MapchipProperties[(int)MapchipType.si芝_田8] = new MapchipPropertyImpl(16, 128, 16, 16);
                this.MapchipProperties[(int)MapchipType.si芝_田9] = new MapchipPropertyImpl(32, 128, 16, 16);
                this.MapchipProperties[(int)MapchipType.si芝_逆田1] = new MapchipPropertyImpl(0, 144, 16, 16);
                this.MapchipProperties[(int)MapchipType.si芝_逆田3] = new MapchipPropertyImpl(16, 144, 16, 16);
                this.MapchipProperties[(int)MapchipType.si芝_逆田7] = new MapchipPropertyImpl(0, 160, 16, 16);
                this.MapchipProperties[(int)MapchipType.si芝_逆田9] = new MapchipPropertyImpl(16, 160, 16, 16);

                this.MapchipProperties[(int)MapchipType.do道路V] = new MapchipPropertyImpl(64, 48, 16, 16);
                this.MapchipProperties[(int)MapchipType.do道路H] = new MapchipPropertyImpl(80, 48, 16, 16);
                this.MapchipProperties[(int)MapchipType.do道路_田1] = new MapchipPropertyImpl(48, 64, 16, 16);
                this.MapchipProperties[(int)MapchipType.do道路_田2] = new MapchipPropertyImpl(64, 64, 16, 16);
                this.MapchipProperties[(int)MapchipType.do道路_田3] = new MapchipPropertyImpl(80, 64, 16, 16);
                this.MapchipProperties[(int)MapchipType.do道路_田4] = new MapchipPropertyImpl(48, 80, 16, 16);
                this.MapchipProperties[(int)MapchipType.do道路_田5] = new MapchipPropertyImpl(64, 80, 16, 16);
                this.MapchipProperties[(int)MapchipType.do道路_田6] = new MapchipPropertyImpl(80, 80, 16, 16);
                this.MapchipProperties[(int)MapchipType.do道路_田7] = new MapchipPropertyImpl(48, 96, 16, 16);
                this.MapchipProperties[(int)MapchipType.do道路_田8] = new MapchipPropertyImpl(64, 96, 16, 16);
                this.MapchipProperties[(int)MapchipType.do道路_田9] = new MapchipPropertyImpl(80, 96, 16, 16);

                this.MapchipProperties[(int)MapchipType.se線路V] = new MapchipPropertyImpl(64, 112, 16, 16);
                this.MapchipProperties[(int)MapchipType.se線路H] = new MapchipPropertyImpl(80, 112, 16, 16);
                this.MapchipProperties[(int)MapchipType.se線路_田1] = new MapchipPropertyImpl(48, 128, 16, 16);
                this.MapchipProperties[(int)MapchipType.se線路_田2] = new MapchipPropertyImpl(64, 128, 16, 16);
                this.MapchipProperties[(int)MapchipType.se線路_田3] = new MapchipPropertyImpl(80, 128, 16, 16);
                this.MapchipProperties[(int)MapchipType.se線路_田4] = new MapchipPropertyImpl(48, 144, 16, 16);
                this.MapchipProperties[(int)MapchipType.se線路_田5] = new MapchipPropertyImpl(64, 144, 16, 16);
                this.MapchipProperties[(int)MapchipType.se線路_田6] = new MapchipPropertyImpl(80, 144, 16, 16);
                this.MapchipProperties[(int)MapchipType.se線路_田7] = new MapchipPropertyImpl(48, 160, 16, 16);
                this.MapchipProperties[(int)MapchipType.se線路_田8] = new MapchipPropertyImpl(64, 160, 16, 16);
                this.MapchipProperties[(int)MapchipType.se線路_田9] = new MapchipPropertyImpl(80, 160, 16, 16);
            }
            catch (Exception)
            {
                // ビジュアル・エディター等のFormではファイルの読み込みに失敗することがある。
            }

            this.MapImg = new MapchipType[2, UcMain.TABLE_ROWS, UcMain.TABLE_COLS];
            // レイヤー[1] を海で埋め尽くすぜ☆（＾▽＾）
            int layer = 1;
            for (int row = 0; row < TABLE_ROWS; row++)
            {
                for (int col = 0; col < TABLE_COLS; col++)
                {
                    this.MapImg[layer, row, col] = MapchipType.u海;
                }
            }
        }

        private void UcMain_MouseDown(object sender, MouseEventArgs e)
        {
            this.MouseDownLocation = e.Location;
        }

        private void UcMain_MouseUp(object sender, MouseEventArgs e)
        {
            int deltaX = e.Location.X - this.MouseDownLocation.X;
            int deltaY = e.Location.Y - this.MouseDownLocation.Y;

            this.TableLeft += deltaX;
            this.TableTop += deltaY;
            this.Refresh();

            // マウスでマップを引きずるのは終わった☆
            this.MouseDownLocation = Point.Empty;
        }

        private void UcMain_MouseMove(object sender, MouseEventArgs e)
        {
            if (this.MouseDownLocation != Point.Empty)
            {
                // マウスでマップを引きずっているようなら

                int deltaX = e.Location.X - this.MouseDownLocation.X;
                int deltaY = e.Location.Y - this.MouseDownLocation.Y;

                this.TableLeft += deltaX;
                this.TableTop += deltaY;

                // すぐ更新☆
                this.MouseDownLocation = e.Location;

                this.Refresh();
            }
        }
    }
}

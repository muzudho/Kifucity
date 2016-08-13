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
        public const int cellW = 16;
        public const int cellH = 16;

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
        public MapchipCrop[,,] MapImg { get; set; }

        /// <summary>
        /// 線路を置くブラシ。
        /// </summary>
        public MapchipRailwayBrush BrushRailway { get; set; }

        public UcMain()
        {
            InitializeComponent();
        }

        private void UcMain_Paint(object sender, PaintEventArgs e)
        {
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
                            if(MapchipCrop.None != this.MapImg[layer, row, col])
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
                this.MapchipProperties = new MapchipProperty[(int)MapchipCrop.Num];
                this.MapchipProperties[(int)MapchipCrop.None] = new MapchipPropertyImpl(0, 0, 16, 16);
                this.MapchipProperties[(int)MapchipCrop.u海] = new MapchipPropertyImpl(16, 0, 16, 16);
                this.MapchipProperties[(int)MapchipCrop.R] = new MapchipPropertyImpl(48, 0, 48, 48);//住宅地
                this.MapchipProperties[(int)MapchipCrop.C] = new MapchipPropertyImpl(96, 0, 48, 48);//商業地
                this.MapchipProperties[(int)MapchipCrop.I] = new MapchipPropertyImpl(144, 0, 48, 48);//工業地
                this.MapchipProperties[(int)MapchipCrop.su砂_田1] = new MapchipPropertyImpl(0, 16, 16, 16);
                this.MapchipProperties[(int)MapchipCrop.su砂_田2] = new MapchipPropertyImpl(16, 16, 16, 16);
                this.MapchipProperties[(int)MapchipCrop.su砂_田3] = new MapchipPropertyImpl(32, 16, 16, 16);
                this.MapchipProperties[(int)MapchipCrop.su砂_田4] = new MapchipPropertyImpl(0, 32, 16, 16);
                this.MapchipProperties[(int)MapchipCrop.su砂_田5] = new MapchipPropertyImpl(16, 32, 16, 16);
                this.MapchipProperties[(int)MapchipCrop.su砂_田6] = new MapchipPropertyImpl(32, 32, 16, 16);
                this.MapchipProperties[(int)MapchipCrop.su砂_田7] = new MapchipPropertyImpl(0, 48, 16, 16);
                this.MapchipProperties[(int)MapchipCrop.su砂_田8] = new MapchipPropertyImpl(16, 48, 16, 16);
                this.MapchipProperties[(int)MapchipCrop.su砂_田9] = new MapchipPropertyImpl(32, 48, 16, 16);
                this.MapchipProperties[(int)MapchipCrop.su砂_逆田1] = new MapchipPropertyImpl(0, 64, 16, 16);
                this.MapchipProperties[(int)MapchipCrop.su砂_逆田3] = new MapchipPropertyImpl(16, 64, 16, 16);
                this.MapchipProperties[(int)MapchipCrop.su砂_逆田7] = new MapchipPropertyImpl(0, 80, 16, 16);
                this.MapchipProperties[(int)MapchipCrop.su砂_逆田9] = new MapchipPropertyImpl(16, 80, 16, 16);
                this.MapchipProperties[(int)MapchipCrop.si芝_田1] = new MapchipPropertyImpl(0, 96, 16, 16);
                this.MapchipProperties[(int)MapchipCrop.si芝_田2] = new MapchipPropertyImpl(16, 96, 16, 16);
                this.MapchipProperties[(int)MapchipCrop.si芝_田3] = new MapchipPropertyImpl(32, 96, 16, 16);
                this.MapchipProperties[(int)MapchipCrop.si芝_田4] = new MapchipPropertyImpl(0, 112, 16, 16);
                this.MapchipProperties[(int)MapchipCrop.si芝_田5] = new MapchipPropertyImpl(16, 112, 16, 16);
                this.MapchipProperties[(int)MapchipCrop.si芝_田6] = new MapchipPropertyImpl(32, 112, 16, 16);
                this.MapchipProperties[(int)MapchipCrop.si芝_田7] = new MapchipPropertyImpl(0, 128, 16, 16);
                this.MapchipProperties[(int)MapchipCrop.si芝_田8] = new MapchipPropertyImpl(16, 128, 16, 16);
                this.MapchipProperties[(int)MapchipCrop.si芝_田9] = new MapchipPropertyImpl(32, 128, 16, 16);
                this.MapchipProperties[(int)MapchipCrop.si芝_逆田1] = new MapchipPropertyImpl(0, 144, 16, 16);
                this.MapchipProperties[(int)MapchipCrop.si芝_逆田3] = new MapchipPropertyImpl(16, 144, 16, 16);
                this.MapchipProperties[(int)MapchipCrop.si芝_逆田7] = new MapchipPropertyImpl(0, 160, 16, 16);
                this.MapchipProperties[(int)MapchipCrop.si芝_逆田9] = new MapchipPropertyImpl(16, 160, 16, 16);

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
            }
            catch (Exception)
            {
                // ビジュアル・エディター等のFormではファイルの読み込みに失敗することがある。
            }

            //────────────────────────────────────────
            // ブラシ
            //────────────────────────────────────────
            this.BrushRailway = new MapchipRailwayBrushImpl(
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
                );

            this.MapImg = new MapchipCrop[2, UcMain.TABLE_ROWS, UcMain.TABLE_COLS];
            // レイヤー[1] を海で埋め尽くすぜ☆（＾▽＾）
            int layer = 1;
            for (int row = 0; row < TABLE_ROWS; row++)
            {
                for (int col = 0; col < TABLE_COLS; col++)
                {
                    this.MapImg[layer, row, col] = MapchipCrop.u海;
                }
            }
        }

        private void UcMain_MouseDown(object sender, MouseEventArgs e)
        {
            this.MouseDownLocation = e.Location;

            if (MouseButtons.Left == e.Button)
            {
                // 左ボタンなら
                // 砂地を置く☆
                {
                    int col = (e.Location.X - this.TableLeft) / cellW;
                    int row = (e.Location.Y - this.TableTop) / cellH;
                    if (col < TABLE_COLS && row < TABLE_ROWS)
                    {
                        this.BrushRailway.Update5Neighborhood(this //this.MapImg
                            , row, col);
                        //this.MapImg[1, row, col] = MapchipCrop.su砂_田5;

                        this.Refresh();
                    }
                }
            }
        }

        private void UcMain_MouseUp(object sender, MouseEventArgs e)
        {
            if (MouseButtons.Right == e.Button)
            {
                // マウスの右ボタンで、マップ引きずる
                int deltaX = e.Location.X - this.MouseDownLocation.X;
                int deltaY = e.Location.Y - this.MouseDownLocation.Y;

                this.TableLeft += deltaX;
                this.TableTop += deltaY;
                this.Refresh();
            }
            else if (MouseButtons.Left == e.Button)
            {
                // 左ボタンなら
                // 砂地を置く☆
                {
                    int col = (e.Location.X - this.TableLeft) / cellW;
                    int row = (e.Location.Y - this.TableTop) / cellH;
                    if (col < TABLE_COLS && row < TABLE_ROWS)
                    {
                        this.BrushRailway.Update5Neighborhood(this //this.MapImg
                            , row, col);

                        //this.MapImg[1, row, col] = MapchipCrop.su砂_田5;
                        this.Refresh();
                    }
                }
            }

            // マウスのドラッグは終わった☆
            this.MouseDownLocation = Point.Empty;
        }

        /// <summary>
        /// 線路状にマップチップを連続配置するぜ☆（＾▽＾）
        /// </summary>
        private void PutMapchipAsLine(
            out bool out_isUpdate, Point mouseLocation, MapchipRailwayBrush brushRailway
            )
        {
            // ２点間を補完して埋めたい。
            // http://kifucity.warabenture.com/archives/47

            out_isUpdate = false;

            // 始点
            int beginCol = (this.MouseDownLocation.X - this.TableLeft) / cellW;
            int beginRow = (this.MouseDownLocation.Y - this.TableTop) / cellH;
            // 終点
            int endCol = (mouseLocation.X - this.TableLeft) / cellW;
            int endRow = (mouseLocation.Y - this.TableTop) / cellH;
            // 距離
            int distanceCol = endCol - beginCol;
            int distanceRow = endRow - beginRow;

            if (Math.Abs(distanceRow) <= Math.Abs(distanceCol))
            {
                // ２点間が、ヨコ、タテが同じか、ヨコの方が長い場合☆
                if (0 <= distanceCol)
                {
                    //
                    // 東の方に向かう直線。図でいうと「＜」扇状の範囲。
                    //
                    //*
                    int pCol;
                    int pRow = beginRow;
                    int pRowPrev;
                    for (int iCol = 0; iCol < distanceCol + 1; iCol++)
                    {
                        int iRow;
                        if (0 == distanceCol)
                        {
                            iRow = 0;
                        }
                        else
                        {
                            // 計算途中は実数にしないと、隙間ができてしまうぜ☆（＾～＾）
                            iRow = (int)((float)distanceRow * ((float)iCol / (float)distanceCol));
                        }

                        pCol = beginCol + iCol;
                        pRowPrev = pRow;
                        pRow = beginRow + iRow;
                        if (pCol < TABLE_COLS && pRow < TABLE_ROWS)
                        {
                            brushRailway.Update5Neighborhood(this //this.MapImg
                                , pRow, pCol);
                            //this.MapImg[1, pRow, pCol] = brushRailway.Patches[5];// MapchipCrop.su砂_田5;

                            if (pRowPrev != pRow && pRowPrev < TABLE_ROWS)
                            {
                                // シムシティの線路みたいな直線のつなげ方をするぜ☆（＾～＾）
                                brushRailway.Update5Neighborhood(this //this.MapImg
                                    , pRowPrev, pCol);
                                //this.MapImg[1, pRowPrev, pCol] = brushRailway.Patches[5];// MapchipCrop.su砂_田5;
                            }
                        }
                    }
                    //*/
                }
                else
                {
                    //
                    // 西の方に向かう直線。図でいうと「＞」扇状の範囲。
                    //
                    //*
                    int pCol;
                    int pRow = beginRow;
                    int pRowPrev;
                    for (int iCol = 0; distanceCol - 1 < iCol; iCol--)
                    {
                        int iRow;
                        if (0 == distanceCol)
                        {
                            iRow = 0;
                        }
                        else
                        {
                            // 計算途中は実数にしないと、隙間ができてしまうぜ☆（＾～＾）
                            iRow = (int)((float)distanceRow * ((float)iCol / (float)distanceCol));
                        }

                        pCol = beginCol + iCol;
                        pRowPrev = pRow;
                        pRow = beginRow + iRow;
                        if (pCol < TABLE_COLS && pRow < TABLE_ROWS)
                        {
                            brushRailway.Update5Neighborhood(this //this.MapImg
                                , pRow, pCol);
                            //this.MapImg[1, pRow, pCol] = brushRailway.Patches[5]; //MapchipCrop.su砂_田5;

                            if (pRowPrev != pRow && pRowPrev < TABLE_ROWS)
                            {
                                // シムシティの線路みたいな直線のつなげ方をするぜ☆（＾～＾）
                                brushRailway.Update5Neighborhood(this //this.MapImg
                                    , pRowPrev, pCol);
                                //this.MapImg[1, pRowPrev, pCol] = brushRailway.Patches[5]; //MapchipCrop.su砂_田5;
                            }
                        }
                    }
                    //*/
                }

                // すぐ更新☆ すぐ描画☆
                out_isUpdate = true;
            }
            else
            {
                // ２点間が、タテの方が長い場合☆
                if (0 <= distanceRow)
                {
                    //
                    // 南の方に向かう直線。図でいうと「∧」扇状の範囲。
                    //
                    //*
                    int pCol = beginCol;
                    int pColPrev;
                    int pRow;
                    for (int iRow = 0; iRow < distanceRow + 1; iRow++)
                    {
                        int iCol;
                        if (0 == distanceRow)
                        {
                            iCol = 0;
                        }
                        else
                        {
                            // 計算途中は実数にしないと、隙間ができてしまうぜ☆（＾～＾）
                            iCol = (int)((float)distanceCol * ((float)iRow / (float)distanceRow));
                        }

                        pColPrev = pCol;
                        pCol = beginCol + iCol;
                        pRow = beginRow + iRow;
                        if (pCol < TABLE_COLS && pRow < TABLE_ROWS)
                        {
                            brushRailway.Update5Neighborhood(this //this.MapImg
                                , pRow, pCol);
                            //this.MapImg[1, pRow, pCol] = brushRailway.Patches[5]; //MapchipCrop.su砂_田5;

                            if (pColPrev != pCol && pColPrev < TABLE_COLS)
                            {
                                // シムシティの線路みたいな直線のつなげ方をするぜ☆（＾～＾）
                                brushRailway.Update5Neighborhood(this //this.MapImg
                                    , pRow, pColPrev);
                                //this.MapImg[1, pRow, pColPrev] = brushRailway.Patches[5]; //MapchipCrop.su砂_田5;
                            }
                        }
                    }
                    //*/
                }
                else
                {
                    //
                    // 北の方に向かう直線。図でいうと「∨」扇状の範囲。
                    //
                    //*
                    int pCol = beginCol;
                    int pColPrev;
                    int pRow;
                    for (int iRow = 0; distanceRow - 1 < iRow; iRow--)
                    {
                        int iCol;
                        if (0 == distanceRow)
                        {
                            iCol = 0;
                        }
                        else
                        {
                            // 計算途中は実数にしないと、隙間ができてしまうぜ☆（＾～＾）
                            iCol = (int)((float)distanceCol * ((float)iRow / (float)distanceRow));
                        }

                        pColPrev = pCol;
                        pCol = beginCol + iCol;
                        pRow = beginRow + iRow;
                        if (pCol < TABLE_COLS && pRow < TABLE_ROWS)
                        {
                            brushRailway.Update5Neighborhood(this //this.MapImg
                                , pRow, pCol);
                            //this.MapImg[1, pRow, pCol] = brushRailway.Patches[5]; //MapchipCrop.su砂_田5;

                            if (pColPrev != pCol && pColPrev < TABLE_COLS)
                            {
                                // シムシティの線路みたいな直線のつなげ方をするぜ☆（＾～＾）
                                brushRailway.Update5Neighborhood(this //this.MapImg
                                    , pRow, pColPrev);
                                //this.MapImg[1, pRow, pColPrev] = brushRailway.Patches[5]; //MapchipCrop.su砂_田5;
                            }
                        }
                    }
                    //*/
                }

                // すぐ更新☆ すぐ描画☆
                out_isUpdate = true;
            }
        }

        private void UcMain_MouseMove(object sender, MouseEventArgs e)
        {
            if (MouseButtons.Right == e.Button)
            {
                // マウスの右ボタンで、マップ引きずる
                if (this.MouseDownLocation != Point.Empty)
                {
                    // マウスでマップを引きずっているようなら

                    int deltaX = e.Location.X - this.MouseDownLocation.X;
                    int deltaY = e.Location.Y - this.MouseDownLocation.Y;

                    this.TableLeft += deltaX;
                    this.TableTop += deltaY;

                    // すぐ更新☆ すぐ描画☆
                    this.MouseDownLocation = e.Location;
                    this.Refresh();
                }
            }
            else if (MouseButtons.Left == e.Button)
            {
                // 左ボタンなら
                // 砂地を置く☆
                if (this.MouseDownLocation != Point.Empty)
                {
                    bool isUpdate;
                    this.PutMapchipAsLine(out isUpdate, e.Location, this.BrushRailway);
                    if (isUpdate)
                    {
                        this.MouseDownLocation = e.Location;
                        this.Refresh();
                    }
                }
            }
        }

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
                        sb.Append((int)this.MapImg[layer, row, col]);
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
                            this.MapImg[layer, row, col] = (MapchipCrop)number;
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

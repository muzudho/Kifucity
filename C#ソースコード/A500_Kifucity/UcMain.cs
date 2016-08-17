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
using Grayscale.A500_Kifucity.B500_Kifucity.C400____Image___;

namespace Grayscale.A500_Kifucity
{
    public partial class UcMain : UserControl
    {
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
        /// 画像データベース☆
        /// </summary>
        public ImageDatabase ImageDatabase { get; set; }

        /// <summary>
        /// 都市データ☆（＾▽＾）
        /// </summary>
        public Position City { get; set; }

        /// <summary>
        /// 施設を置くブラシ。[0]なし [1]線路 [2]砂地 [3]道路 [4]太ペン [5]送電線
        /// </summary>
        public MapchipBrush[] BrushesFacility { get; set; }

        /// <summary>
        /// ボタンを描くブラシ。
        /// [0]なし [1]線路 [2]整地 [3]道路 [4]送電線／高架送電線 ...
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
        /// 4:(ImageType,ImageCrop,ImageSourcefile)の3要素を1セルに詰め込んだ。
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

            //
            // ビジュアル・エディターでは、
            // Load よりも Paint の方が呼び出される方が早いので、ここで初期化するぜ☆（＾～＾）
            //

            this.ImageDatabase = new ImageDatabaseImpl();
            //────────────────────────────────────────
            // ブラシ
            //────────────────────────────────────────
            this.BrushesButton = new MenuButtonBrush[]
            {
                null,
                new MenuButtonBrushImpl(ImageSourcefile.Buttons, 0*ImageDatabaseImpl.BUTTON_W+32,0*ImageDatabaseImpl.BUTTON_H+32,ImageDatabaseImpl.BUTTON_W,ImageDatabaseImpl.BUTTON_H,ImageCropButton.sebt線路1,ImageCropButton.sebt線路2,ImageCropButton.sebt線路3,ImageCropButton.sebt線路4),
                new MenuButtonBrushImpl(ImageSourcefile.Buttons, 1*ImageDatabaseImpl.BUTTON_W+32,0*ImageDatabaseImpl.BUTTON_H+32,ImageDatabaseImpl.BUTTON_W,ImageDatabaseImpl.BUTTON_H,ImageCropButton.sebt整地1,ImageCropButton.sebt整地2,ImageCropButton.sebt整地3,ImageCropButton.sebt整地4),
                new MenuButtonBrushImpl(ImageSourcefile.Buttons, 0*ImageDatabaseImpl.BUTTON_W+32,1*ImageDatabaseImpl.BUTTON_H+32,ImageDatabaseImpl.BUTTON_W,ImageDatabaseImpl.BUTTON_H,ImageCropButton.dobt道路1,ImageCropButton.dobt道路2,ImageCropButton.dobt道路3,ImageCropButton.dobt道路4),
                new MenuButtonBrushImpl(ImageSourcefile.Buttons, 1*ImageDatabaseImpl.BUTTON_W+32,1*ImageDatabaseImpl.BUTTON_H+32,ImageDatabaseImpl.BUTTON_W,ImageDatabaseImpl.BUTTON_H,ImageCropButton.bobt太ペン1,ImageCropButton.bobt太ペン2,ImageCropButton.bobt太ペン3,ImageCropButton.bobt太ペン4),
                new MenuButtonBrushImpl(ImageSourcefile.Buttons, 0*ImageDatabaseImpl.BUTTON_W+32,2*ImageDatabaseImpl.BUTTON_H+32,ImageDatabaseImpl.BUTTON_W,ImageDatabaseImpl.BUTTON_H,ImageCropButton.pobt送電線1,ImageCropButton.pobt送電線2,ImageCropButton.pobt送電線3,ImageCropButton.pobt送電線4),
            };
            this.BrushesFacility = new MapchipBrush[]
            {
                null,
                // 線路
                new MapchipRailwayBrushImpl(
                    PositionImpl.LAYER_RAILWAY,
                    ImageSourcefile.Way_Railway
                ),
                // 砂地
                new MapchipBulldozerBrushImpl(
                    PositionImpl.LAYER_LAND,
                    ImageSourcefile.Border_Sunachi,
                    ImageType.BorderAnime
                ),
                // 道路
                new MapchipRailwayBrushImpl(
                    PositionImpl.LAYER_ROAD,
                    ImageSourcefile.Way_Roadway
                ),
                //砂地（太ペン）
                new MapchipBoldBrushImpl(
                    PositionImpl.LAYER_LAND,
                    ImageSourcefile.Border_Sunachi,
                    ImageType.BorderAnime,//FIXME:
                    ImageCropBorder.kyo境界線_A5
                ),
                // 送電線 power line
                new MapchipRailwayBrushImpl(
                    PositionImpl.LAYER_ROAD,
                    ImageSourcefile.Way_PowerLine
                ),
            };
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
            // 画像の一部を切り抜いて貼り付け☆（＾▽＾）
            for (int layer = 0; layer < PositionImpl.TABLE_LAYERS; layer++)
            {
                for (int row = 0; row < this.City.TableRows; row++)
                {
                    for (int col = 0; col < this.City.TableCols; col++)
                    {
                        if (ImageCrop.None != this.City.Cells[layer, row, col].ImageCrop)
                        {
                            // セルには MapchipImageType が入っているので、どの画像ファイルから
                            // 画像を切り抜くのかが分かるぜ☆（＾▽＾）
                            Image img = this.ImageDatabase.ImageSourcefiles[(int)this.City.Cells[layer, row, col].ImageSourcefile];

                            if (null != img
                                //&&
                                //ImageType.None != this.City.Cells[layer, row, col].ImageType
                                )
                            {
                                int imageCropN = (int)this.City.Cells[layer, row, col].ImageCrop;

                                if (ImageType.NormalAnime==this.City.Cells[layer, row, col].ImageType)
                                {
                                    // アニメーションするセルの場合☆ 8コマと想定☆（＾～＾）

                                    const int span = PositionImpl.CELL_W;
                                    g.DrawImage(img,
                                        new Rectangle(col * PositionImpl.CELL_W + tableLeft, row * PositionImpl.CELL_H + tableTop, PositionImpl.CELL_W, PositionImpl.CELL_H),//ディスプレイ
                                                                                                                                    // 元画像
                                        
                                        this.ImageDatabase.Crop[(int)ImageType.NormalAnime][imageCropN].X + animationCount % UcMain.AnimationCountNum * span,
                                        this.ImageDatabase.Crop[(int)ImageType.NormalAnime][imageCropN].Y,
                                        this.ImageDatabase.Crop[(int)ImageType.NormalAnime][imageCropN].Width,
                                        this.ImageDatabase.Crop[(int)ImageType.NormalAnime][imageCropN].Height,
                                        GraphicsUnit.Pixel);
                                }
                                else if (ImageType.BorderAnime == this.City.Cells[layer, row, col].ImageType)
                                {
                                    // 境界線チップ用の アニメーションだぜ☆（＾～＾）
                                    const int span = 128;
                                    g.DrawImage(img,
                                        new Rectangle(col * PositionImpl.CELL_W + tableLeft, row * PositionImpl.CELL_H + tableTop, PositionImpl.CELL_W, PositionImpl.CELL_H),//ディスプレイ
                                                                                                                                                                                // 元画像
                                        this.ImageDatabase.Crop[(int)ImageType.BorderAnime][imageCropN].X + animationCount % UcMain.AnimationCountNum * span,
                                        this.ImageDatabase.Crop[(int)ImageType.BorderAnime][imageCropN].Y,
                                        this.ImageDatabase.Crop[(int)ImageType.BorderAnime][imageCropN].Width,
                                        this.ImageDatabase.Crop[(int)ImageType.BorderAnime][imageCropN].Height,
                                        GraphicsUnit.Pixel);
                                }
                                else
                                {
                                    // 静止画セルの場合☆
                                    g.DrawImage(img,
                                        new Rectangle(col * PositionImpl.CELL_W + tableLeft, row * PositionImpl.CELL_H + tableTop, PositionImpl.CELL_W, PositionImpl.CELL_H),//ディスプレイ
                                        this.ImageDatabase.Crop[(int)this.City.Cells[layer, row, col].ImageType][imageCropN],// 元画像
                                        GraphicsUnit.Pixel);
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
                for (int iButtonType=1; iButtonType<this.BrushesButton.Length; iButtonType++)
                {
                    this.BrushesButton[iButtonType].Paint(g, this);
                }
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
            this.SaveFileVersion = 4;
            this.RefreshTitlebar();

            // マップ
            this.City = new PositionImpl();

            // アプリケーション起動時の最初の位置。
            this.TableLeft = 16;
            this.TableTop = 16;

            this.MouseDownLocation = Point.Empty;

            try
            {
                this.ImageDatabase.Load();
            }
            catch (Exception)
            {
                // ビジュアル・エディター等のFormではファイルの読み込みに失敗することがある。
            }

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

        /// <summary>
        /// int型は32bit
        /// 
        /// 0000 0000 0000 0000 0000 0000 0000 0000
        ///                               |---A---|
        ///                     |---B---|
        ///           |---C---|
        ///
        /// A: 画像タイプ (0～256)
        /// B: クロップ番号 (0～256)
        /// C: 画像ファイル識別子 (0～256)
        /// </summary>
        public const int BitshiftB = 8;
        public const int BitshiftC = 16;
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
                            ((int)this.City.Cells[layer, row, col].ImageType & 0xff)
                            +
                            (((int)this.City.Cells[layer, row, col].ImageCrop & 0xff)<<BitshiftB)
                            +
                            (((int)this.City.Cells[layer, row, col].ImageSourcefile & 0xff)<<BitshiftC)
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
                            this.City.Cells[layer, row, col].SetValue(
                                (ImageType)(number & 0xff),
                                (ImageCrop)((number >> BitshiftB) & 0xff),
                                (ImageSourcefile)((number>> BitshiftC) & 0xff)
                                );
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
                            //
                            // 512x384以上の画像にしておかないと、拡大されて荒くなるぜ☆（＾～＾）

                            int cols = 512 / PositionImpl.CELL_W;
                            int rows = 384 / PositionImpl.CELL_H;

                            this.City.ChangeSizeMap(rows, cols);
                            //this.City.ChangeSizeMap(16, 16);
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

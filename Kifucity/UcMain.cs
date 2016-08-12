using System.Drawing;
using System.Windows.Forms;
using System;

namespace Kifucity
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
        /// マップ画像☆
        /// </summary>
        public Image ImgMap { get; set; }

        public UcMain()
        {
            InitializeComponent();
        }

        private void UcMain_Paint(object sender, PaintEventArgs e)
        {
            // マスの大きさ
            int cellW = 16;
            int cellH = 16;

            // マップの広さ
            int tableCols = 120;
            int tableRows = 100;

            // 外枠を描こうぜ☆
            Graphics g = e.Graphics;

            g.DrawRectangle(Pens.Black, this.TableLeft, this.TableTop,
                tableCols*cellW, tableRows*cellH);

            if (null != this.ImgMap)
            {
                // 画像の一部を切り抜いて貼り付け☆（＾▽＾）
                for (int row = 0; row < tableRows; row++)
                {
                    for (int col = 0; col < tableCols; col++)
                    {
                        g.DrawImage(this.ImgMap,
                            new Rectangle(col * cellW + this.TableLeft, row * cellH + this.TableTop, cellW, cellH),//ディスプレイ
                            new Rectangle(1 * cellW, 0 * cellH, cellW, cellH),//元画像
                            GraphicsUnit.Pixel);
                    }
                }
            }

            // グリッドを引こうぜ☆
            // ヨコ線
            for (int col = 1; col < tableCols; col++)
            {
                g.DrawLine(Pens.Black,
                    col * cellW + this.TableLeft,
                    this.TableTop,
                    col * cellW + this.TableLeft,
                    tableRows * cellH + this.TableTop
                    );
            }

            // タテ線
            for (int row = 1; row < tableRows; row++)
            {
                g.DrawLine(Pens.Black,
                    this.TableLeft,
                    row * cellH + this.TableTop,
                    tableCols * cellW + this.TableLeft,
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
                // 画像読み込み
                this.ImgMap = Image.FromFile("./img/map.png");
            }
            catch (Exception)
            {
                // ビジュアル・エディター等のFormではファイルの読み込みに失敗することがある。
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

using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Drawing.Imaging;


namespace BorderCopy
{
    public partial class UcMain : UserControl
    {
        /// <summary>
        /// ドラッグ＆ドロップしてきた元画像☆（＾▽＾）
        /// </summary>
        private Image SourceImage { get; set; }

        /// <summary>
        /// ドラッグ＆ドロップしてきた元画像☆（＾▽＾）
        /// の、90度時計回りしたものだぜ☆（＾▽＾）
        /// </summary>
        private Image SourceImage90 { get; set; }

        /// <summary>
        /// 加工後の画像☆（＾▽＾）
        /// </summary>
        private Image DestinationImage { get; set; }

        public UcMain()
        {
            InitializeComponent();
        }

        private void UcMain_DragEnter(object sender, DragEventArgs e)
        {
            //ドラッグされているデータが ファイル か調べ、
            //そうであればドロップ効果をMoveにする
            if (e.Data.GetDataPresent(DataFormats.FileDrop))
            {
                e.Effect = DragDropEffects.Move;
            }
            else
            {
                //そうでなければ受け入れない
                e.Effect = DragDropEffects.None;
            }
        }

        private void UcMain_DragDrop(object sender, DragEventArgs e)
        {
            //ドロップされたデータが ファイル 型か調べる
            if (e.Data.GetDataPresent(DataFormats.FileDrop))
            {
                UcMain target = (UcMain)sender;
                //ドロップされたデータ(ファイル型)を取得
                string[] filepaths = (string[])e.Data.GetData(DataFormats.FileDrop);

                //ドロップされたデータを使う☆
                foreach (string filepath in filepaths)
                {
                    if (!System.IO.File.Exists(filepath))
                    {
                        // ファイル以外であればイベント・ハンドラを抜ける
                        return;
                    }

                    this.SourceImage = Image.FromFile(filepath);
                    if(this.SourceImage.Width==128 && this.SourceImage.Height == 128)
                    {
                        // 境界線チップ（非アニメ）
                        this.CopyImage_NonAnime(this.SourceImage);
                        this.ExportImage();
                        this.Refresh();
                    }
                    else if (this.SourceImage.Width == 128 && this.SourceImage.Height == 80)
                    {
                        // 境界線アニメチップ
                        this.CopyImage_Anime(this.SourceImage);
                        this.ExportImage();
                        this.Refresh();
                    }


                    // １件処理して終わり☆（＾▽＾）
                    break;
                }
                e.Effect = DragDropEffects.Copy;
            }
        }

        public void ExportImage()
        {
            if (null!=this.DestinationImage)
            {
                this.DestinationImage.Save("./_出力_境界線チップ.png",ImageFormat.Png);
            }
        }

        /// <summary>
        /// 変形なし☆（＾▽＾）
        /// </summary>
        /// <param name="x"></param>
        /// <param name="y"></param>
        /// <returns></returns>
        private Rectangle Norma(int col, int row, int dX, int dY)
        {
            int width = 8;
            int height = 8;
            return new Rectangle(col*width+dX, row*height+dY, width, height);
        }
        private Rectangle Norma2(int col, int row, int dX, int dY)
        {
            int width = 16;
            int height = 16;
            return new Rectangle(col * width + dX, row * height + dY, width, height);
        }

        /// <summary>
        /// 左右反転☆（＾▽＾）
        /// </summary>
        /// <param name="x"></param>
        /// <param name="y"></param>
        /// <returns></returns>
        private Rectangle FlipH(int col, int row, int dX, int dY)
        {
            int width = 8;
            int height = 8;
            return new Rectangle(col * width + width + dX, row * height + dY, -width, height);
        }
        private Rectangle FlipH2(int col, int row, int dX, int dY)
        {
            int width = 16;
            int height = 16;
            return new Rectangle(col * width + width + dX, row * height + dY, -width, height);
        }

        /// <summary>
        /// 上下反転☆（＾▽＾）
        /// </summary>
        /// <param name="x"></param>
        /// <param name="y"></param>
        /// <returns></returns>
        private Rectangle FlipV(int col, int row, int dX, int dY)
        {
            int width = 8;
            int height = 8;
            return new Rectangle(col * width + dX, row * height + height + dY, width, -height);
        }
        private Rectangle FlipV2(int col, int row, int dX, int dY)
        {
            int width = 16;
            int height = 16;
            return new Rectangle(col * width + dX, row * height + height + dY, width, -height);
        }

        /// <summary>
        /// 180度回転☆（＾▽＾）
        /// </summary>
        /// <param name="x"></param>
        /// <param name="y"></param>
        /// <returns></returns>
        private Rectangle Rotat(int col, int row, int dX, int dY)
        {
            int width = 8;
            int height = 8;
            return new Rectangle(col * width + width + dX, row * height + height, -width, -height);
        }
        private Rectangle Rotat2(int col, int row, int dX, int dY)
        {
            int width = 16;
            int height = 16;
            return new Rectangle(col * width + width + dX, row * height + height, -width, -height);
        }

        private void DrawImage(
            Graphics g, int dX, int dY,
            Image src, Image srcR, Rectangle parts1,
            Rectangle parts2, Rectangle parts2R, Rectangle parts3, Rectangle parts3R,
            Rectangle parts4, Rectangle parts4R,
            Rectangle parts5,
            Rectangle parts6,
            Rectangle parts7
        )
        {
            //────────────────────────────────────────
            // パーツ１
            //────────────────────────────────────────
            g.DrawImage(src, Norma(3, 1, dX,dY), parts1, GraphicsUnit.Pixel);
            g.DrawImage(src, FlipH(6, 1, dX, dY), parts1, GraphicsUnit.Pixel);
            g.DrawImage(src, FlipV(3, 4, dX, dY), parts1, GraphicsUnit.Pixel);
            g.DrawImage(src, Rotat(6, 4, dX, dY), parts1, GraphicsUnit.Pixel);

            g.DrawImage(src, Norma(9, 3, dX, dY), parts1, GraphicsUnit.Pixel);
            g.DrawImage(src, FlipH(10, 3, dX, dY), parts1, GraphicsUnit.Pixel);
            g.DrawImage(src, Norma(11, 3, dX, dY), parts1, GraphicsUnit.Pixel);
            g.DrawImage(src, FlipH(12, 3, dX, dY), parts1, GraphicsUnit.Pixel);
            g.DrawImage(src, FlipV(9, 4, dX, dY), parts1, GraphicsUnit.Pixel);
            g.DrawImage(src, Rotat(10, 4, dX, dY), parts1, GraphicsUnit.Pixel);
            g.DrawImage(src, FlipV(11, 4, dX, dY), parts1, GraphicsUnit.Pixel);
            g.DrawImage(src, Rotat(12, 4, dX, dY), parts1, GraphicsUnit.Pixel);

            g.DrawImage(src, Norma(5, 7, dX, dY), parts1, GraphicsUnit.Pixel);
            g.DrawImage(src, FlipH(6, 7, dX, dY), parts1, GraphicsUnit.Pixel);
            g.DrawImage(src, FlipV(5, 8, dX, dY), parts1, GraphicsUnit.Pixel);
            g.DrawImage(src, Rotat(6, 8, dX, dY), parts1, GraphicsUnit.Pixel);

            g.DrawImage(src, Norma(9, 7, dX, dY), parts1, GraphicsUnit.Pixel);
            g.DrawImage(src, FlipH(10, 7, dX, dY), parts1, GraphicsUnit.Pixel);
            g.DrawImage(src, FlipV(9, 8, dX, dY), parts1, GraphicsUnit.Pixel);
            g.DrawImage(src, Rotat(10, 8, dX, dY), parts1, GraphicsUnit.Pixel);
            g.DrawImage(src, Norma(9, 9, dX, dY), parts1, GraphicsUnit.Pixel);
            g.DrawImage(src, FlipH(10, 9, dX, dY), parts1, GraphicsUnit.Pixel);
            g.DrawImage(src, FlipV(9, 10, dX, dY), parts1, GraphicsUnit.Pixel);
            g.DrawImage(src, Rotat(10, 10, dX, dY), parts1, GraphicsUnit.Pixel);

            g.DrawImage(src, FlipV(3, 10, dX, dY), parts1, GraphicsUnit.Pixel);
            g.DrawImage(src, Rotat(4, 10, dX, dY), parts1, GraphicsUnit.Pixel);
            g.DrawImage(src, FlipV(7, 10, dX, dY), parts1, GraphicsUnit.Pixel);

            g.DrawImage(src, Norma(3, 11, dX, dY), parts1, GraphicsUnit.Pixel);
            g.DrawImage(src, FlipH(4, 11, dX, dY), parts1, GraphicsUnit.Pixel);
            g.DrawImage(src, Norma(5, 11, dX, dY), parts1, GraphicsUnit.Pixel);
            g.DrawImage(src, FlipH(6, 11, dX, dY), parts1, GraphicsUnit.Pixel);
            g.DrawImage(src, FlipV(3, 12, dX, dY), parts1, GraphicsUnit.Pixel);
            g.DrawImage(src, Rotat(4, 12, dX, dY), parts1, GraphicsUnit.Pixel);
            g.DrawImage(src, FlipV(5, 12, dX, dY), parts1, GraphicsUnit.Pixel);
            g.DrawImage(src, Rotat(6, 12, dX, dY), parts1, GraphicsUnit.Pixel);

            g.DrawImage(src, FlipH(0, 13, dX, dY), parts1, GraphicsUnit.Pixel);
            g.DrawImage(src, Norma(1, 13, dX, dY), parts1, GraphicsUnit.Pixel);
            g.DrawImage(src, FlipH(2, 13, dX, dY), parts1, GraphicsUnit.Pixel);
            g.DrawImage(src, Norma(3, 13, dX, dY), parts1, GraphicsUnit.Pixel);
            g.DrawImage(src, FlipH(4, 13, dX, dY), parts1, GraphicsUnit.Pixel);
            g.DrawImage(src, Norma(5, 13, dX, dY), parts1, GraphicsUnit.Pixel);
            g.DrawImage(src, FlipH(6, 13, dX, dY), parts1, GraphicsUnit.Pixel);
            g.DrawImage(src, Rotat(0, 14, dX, dY), parts1, GraphicsUnit.Pixel);
            g.DrawImage(src, FlipV(1, 14, dX, dY), parts1, GraphicsUnit.Pixel);
            g.DrawImage(src, Rotat(2, 14, dX, dY), parts1, GraphicsUnit.Pixel);
            g.DrawImage(src, FlipV(3, 14, dX, dY), parts1, GraphicsUnit.Pixel);
            g.DrawImage(src, Rotat(4, 14, dX, dY), parts1, GraphicsUnit.Pixel);
            g.DrawImage(src, FlipV(5, 14, dX, dY), parts1, GraphicsUnit.Pixel);
            g.DrawImage(src, Rotat(6, 14, dX, dY), parts1, GraphicsUnit.Pixel);

            g.DrawImage(src, Norma(3, 15, dX, dY), parts1, GraphicsUnit.Pixel);
            g.DrawImage(src, FlipH(4, 15, dX, dY), parts1, GraphicsUnit.Pixel);
            g.DrawImage(src, Norma(7, 15, dX, dY), parts1, GraphicsUnit.Pixel);

            //────────────────────────────────────────
            // パーツ２
            //────────────────────────────────────────
            g.DrawImage(src, Norma(4, 1, dX, dY), parts2, GraphicsUnit.Pixel);
            g.DrawImage(src, FlipH(5, 1, dX, dY), parts2, GraphicsUnit.Pixel);

            g.DrawImage(srcR, FlipH(3, 2, dX, dY), parts2R, GraphicsUnit.Pixel);
            g.DrawImage(srcR, Rotat(3, 3, dX, dY), parts2R, GraphicsUnit.Pixel);

            g.DrawImage(srcR, Norma(6, 2, dX, dY), parts2R, GraphicsUnit.Pixel);
            g.DrawImage(srcR, FlipV(6, 3, dX, dY), parts2R, GraphicsUnit.Pixel);

            g.DrawImage(src, FlipV(4, 4, dX, dY), parts2, GraphicsUnit.Pixel);
            g.DrawImage(src, Rotat(5, 4, dX, dY), parts2, GraphicsUnit.Pixel);

            g.DrawImage(src, FlipV(8, 2, dX, dY), parts2, GraphicsUnit.Pixel);
            g.DrawImage(src, Rotat(9, 2, dX, dY), parts2, GraphicsUnit.Pixel);
            g.DrawImage(src, FlipV(10, 2, dX, dY), parts2, GraphicsUnit.Pixel);
            g.DrawImage(src, Rotat(11, 2, dX, dY), parts2, GraphicsUnit.Pixel);
            g.DrawImage(src, FlipV(12, 2, dX, dY), parts2, GraphicsUnit.Pixel);
            g.DrawImage(src, Rotat(13, 2, dX, dY), parts2, GraphicsUnit.Pixel);

            g.DrawImage(src, Norma(8, 5, dX, dY), parts2, GraphicsUnit.Pixel);
            g.DrawImage(src, FlipH(9, 5, dX, dY), parts2, GraphicsUnit.Pixel);
            g.DrawImage(src, Norma(10, 5, dX, dY), parts2, GraphicsUnit.Pixel);
            g.DrawImage(src, FlipH(11, 5, dX, dY), parts2, GraphicsUnit.Pixel);
            g.DrawImage(src, Norma(12, 5, dX, dY), parts2, GraphicsUnit.Pixel);
            g.DrawImage(src, FlipH(13, 5, dX, dY), parts2, GraphicsUnit.Pixel);

            g.DrawImage(srcR, Norma(8, 6, dX, dY), parts2R, GraphicsUnit.Pixel);
            g.DrawImage(srcR, FlipV(8, 7, dX, dY), parts2R, GraphicsUnit.Pixel);
            g.DrawImage(srcR, Norma(8, 8, dX, dY), parts2R, GraphicsUnit.Pixel);
            g.DrawImage(srcR, FlipV(8, 9, dX, dY), parts2R, GraphicsUnit.Pixel);
            g.DrawImage(srcR, Norma(8, 10, dX, dY), parts2R, GraphicsUnit.Pixel);
            g.DrawImage(srcR, FlipV(8, 11, dX, dY), parts2R, GraphicsUnit.Pixel);

            g.DrawImage(srcR, Norma(11, 6, dX, dY), parts2R, GraphicsUnit.Pixel);
            g.DrawImage(srcR, FlipV(11, 7, dX, dY), parts2R, GraphicsUnit.Pixel);
            g.DrawImage(srcR, Norma(11, 8, dX, dY), parts2R, GraphicsUnit.Pixel);
            g.DrawImage(srcR, FlipV(11, 9, dX, dY), parts2R, GraphicsUnit.Pixel);
            g.DrawImage(srcR, Norma(11, 10, dX, dY), parts2R, GraphicsUnit.Pixel);
            g.DrawImage(srcR, FlipV(11, 11, dX, dY), parts2R, GraphicsUnit.Pixel);

            //────────────────────────────────────────
            // パーツ３
            //────────────────────────────────────────
            g.DrawImage(src, Norma(8, 1, dX, dY), parts3, GraphicsUnit.Pixel);
            g.DrawImage(src, FlipV(8, 0, dX, dY), parts3, GraphicsUnit.Pixel);

            g.DrawImage(src, Rotat(13, 0, dX, dY), parts3, GraphicsUnit.Pixel);
            g.DrawImage(src, FlipH(13, 1, dX, dY), parts3, GraphicsUnit.Pixel);

            g.DrawImage(srcR, Norma(14, 0, dX, dY), parts3R, GraphicsUnit.Pixel);
            g.DrawImage(srcR, FlipH(15, 0, dX, dY), parts3R, GraphicsUnit.Pixel);

            g.DrawImage(srcR, FlipV(14, 5, dX, dY), parts3R, GraphicsUnit.Pixel);
            g.DrawImage(srcR, Rotat(15, 5, dX, dY), parts3R, GraphicsUnit.Pixel);

            //────────────────────────────────────────
            // パーツ４
            //────────────────────────────────────────
            g.DrawImage(src, Norma(9, 1, dX, dY), parts4, GraphicsUnit.Pixel);
            g.DrawImage(src, Norma(10, 1, dX, dY), parts4, GraphicsUnit.Pixel);
            g.DrawImage(src, Norma(11, 1, dX, dY), parts4, GraphicsUnit.Pixel);
            g.DrawImage(src, Norma(12, 1, dX, dY), parts4, GraphicsUnit.Pixel);
            g.DrawImage(src, FlipV(9, 0, dX, dY), parts4, GraphicsUnit.Pixel);
            g.DrawImage(src, FlipV(10, 0, dX, dY), parts4, GraphicsUnit.Pixel);
            g.DrawImage(src, FlipV(11, 0, dX, dY), parts4, GraphicsUnit.Pixel);
            g.DrawImage(src, FlipV(12, 0, dX, dY), parts4, GraphicsUnit.Pixel);

            g.DrawImage(srcR, Norma(14, 1, dX, dY), parts4R, GraphicsUnit.Pixel);
            g.DrawImage(srcR, Norma(14, 2, dX, dY), parts4R, GraphicsUnit.Pixel);
            g.DrawImage(srcR, Norma(14, 3, dX, dY), parts4R, GraphicsUnit.Pixel);
            g.DrawImage(srcR, Norma(14, 4, dX, dY), parts4R, GraphicsUnit.Pixel);
            g.DrawImage(srcR, FlipH(15, 1, dX, dY), parts4R, GraphicsUnit.Pixel);
            g.DrawImage(srcR, FlipH(15, 2, dX, dY), parts4R, GraphicsUnit.Pixel);
            g.DrawImage(srcR, FlipH(15, 3, dX, dY), parts4R, GraphicsUnit.Pixel);
            g.DrawImage(srcR, FlipH(15, 4, dX, dY), parts4R, GraphicsUnit.Pixel);

            //────────────────────────────────────────
            // パーツ５
            //────────────────────────────────────────
            g.DrawImage(src, Norma(0, 10, dX, dY), parts5, GraphicsUnit.Pixel);
            g.DrawImage(src, FlipH(1, 10, dX, dY), parts5, GraphicsUnit.Pixel);
            g.DrawImage(src, FlipV(0, 11, dX, dY), parts5, GraphicsUnit.Pixel);
            g.DrawImage(src, Rotat(1, 11, dX, dY), parts5, GraphicsUnit.Pixel);

            //────────────────────────────────────────
            // パーツ６（倍角）
            //────────────────────────────────────────
            g.DrawImage(src, Norma2(2, 1, dX, dY), parts6, GraphicsUnit.Pixel);

            //────────────────────────────────────────
            // パーツ７（倍角）
            //────────────────────────────────────────
            g.DrawImage(src, Norma2(0, 3, dX, dY), parts7, GraphicsUnit.Pixel);
            g.DrawImage(src, FlipH2(1, 3, dX, dY), parts7, GraphicsUnit.Pixel);
            g.DrawImage(src, Norma2(2, 3, dX, dY), parts7, GraphicsUnit.Pixel);
            g.DrawImage(src, FlipH2(3, 3, dX, dY), parts7, GraphicsUnit.Pixel);

            g.DrawImage(src, FlipV2(0, 4, dX, dY), parts7, GraphicsUnit.Pixel);
            g.DrawImage(src, Rotat2(1, 4, dX, dY), parts7, GraphicsUnit.Pixel);
            g.DrawImage(src, FlipV2(2, 4, dX, dY), parts7, GraphicsUnit.Pixel);
            g.DrawImage(src, Rotat2(3, 4, dX, dY), parts7, GraphicsUnit.Pixel);
        }

        /// <summary>
        /// 境界線チップ（非アニメ）を組み立て☆
        /// </summary>
        /// <param name="src"></param>
        public void CopyImage_NonAnime(Image src)
        {
            // 90度右（時計回り）回転した元画像も用意しておく☆
            {
                this.SourceImage90 = new Bitmap(
                    src.Width,
                    src.Height
                );
                Graphics g2 = Graphics.FromImage(this.SourceImage90);
                g2.DrawImage(src, 0, 0);
                // 時計回りに90度回転して、反転は無し☆（＾～＾）
                this.SourceImage90.RotateFlip(RotateFlipType.Rotate90FlipNone);
                g2.Dispose();
            }
            Image srcR = this.SourceImage90;

            Bitmap destinationImage = new Bitmap(
                src.Width,
                src.Height
            );

            // ImageオブジェクトのGraphicsオブジェクトを作成する
            Graphics g = Graphics.FromImage(destinationImage);

            // コピーを開始するぜ☆（＾▽＾）
            int deltaX1 = 0;
            int deltaY1 = 0;

            //────────────────────────────────────────
            // パーツ１
            //────────────────────────────────────────
            Rectangle parts1 = Norma(3, 1, deltaX1, deltaY1);

            //────────────────────────────────────────
            // パーツ２
            //────────────────────────────────────────
            Rectangle parts2 = Norma(4, 1, deltaX1, deltaY1);
            Rectangle parts2R = Norma(14, 4, deltaX1, deltaY1);

            //────────────────────────────────────────
            // パーツ３
            //────────────────────────────────────────
            Rectangle parts3 = Norma(8, 1, deltaX1, deltaY1);
            Rectangle parts3R = Norma(14, 8, deltaX1, deltaY1);

            //────────────────────────────────────────
            // パーツ４
            //────────────────────────────────────────
            Rectangle parts4 = Norma(10, 1, deltaX1, deltaY1);
            Rectangle parts4R = Norma(14, 10, deltaX1, deltaY1);

            //────────────────────────────────────────
            // パーツ５
            //────────────────────────────────────────
            Rectangle parts5 = Norma(0, 10, deltaX1, deltaY1);

            //────────────────────────────────────────
            // パーツ６（倍角）
            //────────────────────────────────────────
            Rectangle parts6 = Norma2(2, 1, deltaX1, deltaY1);

            //────────────────────────────────────────
            // パーツ７（倍角）
            //────────────────────────────────────────
            Rectangle parts7 = Norma2(0, 3, deltaX1, deltaY1);

            int deltaX2 = 0;
            int deltaY2 = 0;
            this.DrawImage(g, deltaX2, deltaY2, src, srcR, parts1, parts2, parts2R,
                parts3, parts3R, parts4, parts4R, parts5, parts6, parts7
            );

            //リソースを解放する
            g.Dispose();

            this.DestinationImage = destinationImage;
        }

        public const int BORDER_ANIME_WIDTH_UNIT = 256;
        public const int BORDER_ANIME_WIDTH = 8 * BORDER_ANIME_WIDTH_UNIT;
        public const int BORDER_ANIME_HEIGHT = 256;
        public const int ANIMATION_COUNT_NUM = 8;
        public const int HALF = 8;
        public const int FULL = 16;

        /// <summary>
        /// 境界線アニメチップを組み立て☆
        /// </summary>
        /// <param name="src"></param>
        public void CopyImage_Anime(Image src)
        {
            // 90度右（時計回り）回転した元画像も用意しておく☆
            {
                // 正方形にする☆（＾▽＾）
                int length = Math.Max(src.Width, src.Height);
                this.SourceImage90 = new Bitmap(length, length);
                Graphics g2 = Graphics.FromImage(this.SourceImage90);
                g2.DrawImage(src, 0, 0);
                // 時計回りに90度回転して、反転は無し☆（＾～＾）
                this.SourceImage90.RotateFlip(RotateFlipType.Rotate90FlipNone);
                g2.Dispose();
            }
            Image srcR = this.SourceImage90;

            // サイズが決まっているぜ☆（＾▽＾）
            Bitmap destinationImage = new Bitmap(
                BORDER_ANIME_WIDTH,
                BORDER_ANIME_HEIGHT);

            // ImageオブジェクトのGraphicsオブジェクトを作成する
            Graphics g = Graphics.FromImage(destinationImage);

            // コピーを開始するぜ☆（＾▽＾）
            for (int iAnime = 0; iAnime < ANIMATION_COUNT_NUM; iAnime++)
            {
                //────────────────────────────────────────
                // パーツ１
                //────────────────────────────────────────
                Rectangle parts1 = Norma(0, 0, iAnime*HALF,0);

                //────────────────────────────────────────
                // パーツ２
                //────────────────────────────────────────
                Rectangle parts2 = Norma(0, 1, iAnime * HALF, 0);
                Rectangle parts2R = Norma(14, 0, 0, iAnime * HALF);

                //────────────────────────────────────────
                // パーツ３
                //────────────────────────────────────────
                Rectangle parts3 = Norma(0, 2, iAnime * HALF, 0);
                Rectangle parts3R = Norma(13, 0, 0, iAnime * HALF);

                //────────────────────────────────────────
                // パーツ４
                //────────────────────────────────────────
                Rectangle parts4 = Norma(0, 3, iAnime * HALF, 0);
                Rectangle parts4R = Norma(12, 0, 0, iAnime * HALF);

                //────────────────────────────────────────
                // パーツ５
                //────────────────────────────────────────
                Rectangle parts5 = Norma(0, 4, iAnime * HALF, 0);

                //────────────────────────────────────────
                // パーツ６（倍角）
                //────────────────────────────────────────
                Rectangle parts6 = Norma2(0, 3, iAnime * FULL, 0);

                //────────────────────────────────────────
                // パーツ７（倍角）
                //────────────────────────────────────────
                Rectangle parts7 = Norma2(0, 4, iAnime * FULL, 0);

                int deltaX2 = iAnime * BORDER_ANIME_WIDTH_UNIT;
                int deltaY2 = 0;
                this.DrawImage(g, deltaX2, deltaY2, src, srcR, parts1, parts2, parts2R,
                    parts3, parts3R, parts4, parts4R, parts5, parts6, parts7
                );
            }

            //リソースを解放する
            g.Dispose();

            this.DestinationImage = destinationImage;
        }

        private void UcMain_Paint(object sender, PaintEventArgs e)
        {
            Graphics g = e.Graphics;
            int padding = 10;

            if (null != this.SourceImage)
            {
                g.DrawImage(this.SourceImage, 0, 0);
            }

            if (null != this.SourceImage90)
            {
                g.DrawImage(this.SourceImage90, 0, 0+this.SourceImage.Height+padding);
            }

            if (null != this.DestinationImage)
            {
                g.DrawImage(this.DestinationImage, this.SourceImage.Width+ padding, 0);
            }
        }
    }
}

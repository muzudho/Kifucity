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

                    this.ReadImage(filepath);
                    this.CopyImage(this.SourceImage);
                    this.ExportImage();
                    this.Refresh();

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

        public void ReadImage(string filepath)
        {
            this.SourceImage = Image.FromFile(filepath);
        }

        /// <summary>
        /// 変形なし☆（＾▽＾）
        /// </summary>
        /// <param name="x"></param>
        /// <param name="y"></param>
        /// <returns></returns>
        private Rectangle Norma(int col, int row)
        {
            int width = 8;
            int height = 8;
            return new Rectangle(col*width, row*height, width, height);
        }
        private Rectangle Norma2(int col, int row)
        {
            int width = 16;
            int height = 16;
            return new Rectangle(col * width, row * height, width, height);
        }

        /// <summary>
        /// 左右反転☆（＾▽＾）
        /// </summary>
        /// <param name="x"></param>
        /// <param name="y"></param>
        /// <returns></returns>
        private Rectangle FlipH(int col, int row)
        {
            int width = 8;
            int height = 8;
            return new Rectangle(col * width + width, row * height, -width, height);
        }
        private Rectangle FlipH2(int col, int row)
        {
            int width = 16;
            int height = 16;
            return new Rectangle(col * width + width, row * height, -width, height);
        }

        /// <summary>
        /// 上下反転☆（＾▽＾）
        /// </summary>
        /// <param name="x"></param>
        /// <param name="y"></param>
        /// <returns></returns>
        private Rectangle FlipV(int col, int row)
        {
            int width = 8;
            int height = 8;
            return new Rectangle(col * width, row * height + height, width, -height);
        }
        private Rectangle FlipV2(int col, int row)
        {
            int width = 16;
            int height = 16;
            return new Rectangle(col * width, row * height + height, width, -height);
        }

        /// <summary>
        /// 180度回転☆（＾▽＾）
        /// </summary>
        /// <param name="x"></param>
        /// <param name="y"></param>
        /// <returns></returns>
        private Rectangle Rotat(int col, int row)
        {
            int width = 8;
            int height = 8;
            return new Rectangle(col * width + width, row * height + height, -width, -height);
        }
        private Rectangle Rotat2(int col, int row)
        {
            int width = 16;
            int height = 16;
            return new Rectangle(col * width + width, row * height + height, -width, -height);
        }

        public void CopyImage(Image src)
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

            //────────────────────────────────────────
            // パーツ１
            //────────────────────────────────────────
            Rectangle parts1 = Norma(3, 1);
            g.DrawImage(src, Norma(3, 1),parts1,GraphicsUnit.Pixel);
            g.DrawImage(src, FlipH(6, 1), parts1, GraphicsUnit.Pixel);
            g.DrawImage(src, FlipV(3, 4), parts1, GraphicsUnit.Pixel);
            g.DrawImage(src, Rotat(6, 4), parts1, GraphicsUnit.Pixel);

            g.DrawImage(src, Norma(9, 3), parts1, GraphicsUnit.Pixel);
            g.DrawImage(src, FlipH(10, 3), parts1, GraphicsUnit.Pixel);
            g.DrawImage(src, Norma(11, 3), parts1, GraphicsUnit.Pixel);
            g.DrawImage(src, FlipH(12, 3), parts1, GraphicsUnit.Pixel);
            g.DrawImage(src, FlipV(9, 4), parts1, GraphicsUnit.Pixel);
            g.DrawImage(src, Rotat(10, 4), parts1, GraphicsUnit.Pixel);
            g.DrawImage(src, FlipV(11, 4), parts1, GraphicsUnit.Pixel);
            g.DrawImage(src, Rotat(12, 4), parts1, GraphicsUnit.Pixel);

            g.DrawImage(src, Norma(5, 7), parts1, GraphicsUnit.Pixel);
            g.DrawImage(src, FlipH(6, 7), parts1, GraphicsUnit.Pixel);
            g.DrawImage(src, FlipV(5, 8), parts1, GraphicsUnit.Pixel);
            g.DrawImage(src, Rotat(6, 8), parts1, GraphicsUnit.Pixel);

            g.DrawImage(src, Norma(9, 7), parts1, GraphicsUnit.Pixel);
            g.DrawImage(src, FlipH(10, 7), parts1, GraphicsUnit.Pixel);
            g.DrawImage(src, FlipV(9, 8), parts1, GraphicsUnit.Pixel);
            g.DrawImage(src, Rotat(10, 8), parts1, GraphicsUnit.Pixel);
            g.DrawImage(src, Norma(9, 9), parts1, GraphicsUnit.Pixel);
            g.DrawImage(src, FlipH(10, 9), parts1, GraphicsUnit.Pixel);
            g.DrawImage(src, FlipV(9, 10), parts1, GraphicsUnit.Pixel);
            g.DrawImage(src, Rotat(10, 10), parts1, GraphicsUnit.Pixel);

            g.DrawImage(src, FlipV(3, 10), parts1, GraphicsUnit.Pixel);
            g.DrawImage(src, Rotat(4, 10), parts1, GraphicsUnit.Pixel);
            g.DrawImage(src, FlipV(7, 10), parts1, GraphicsUnit.Pixel);

            g.DrawImage(src, Norma(3, 11), parts1, GraphicsUnit.Pixel);
            g.DrawImage(src, FlipH(4, 11), parts1, GraphicsUnit.Pixel);
            g.DrawImage(src, Norma(5, 11), parts1, GraphicsUnit.Pixel);
            g.DrawImage(src, FlipH(6, 11), parts1, GraphicsUnit.Pixel);
            g.DrawImage(src, FlipV(3, 12), parts1, GraphicsUnit.Pixel);
            g.DrawImage(src, Rotat(4, 12), parts1, GraphicsUnit.Pixel);
            g.DrawImage(src, FlipV(5, 12), parts1, GraphicsUnit.Pixel);
            g.DrawImage(src, Rotat(6, 12), parts1, GraphicsUnit.Pixel);

            g.DrawImage(src, FlipH(0, 13), parts1, GraphicsUnit.Pixel);
            g.DrawImage(src, Norma(1, 13), parts1, GraphicsUnit.Pixel);
            g.DrawImage(src, FlipH(2, 13), parts1, GraphicsUnit.Pixel);
            g.DrawImage(src, Norma(3, 13), parts1, GraphicsUnit.Pixel);
            g.DrawImage(src, FlipH(4, 13), parts1, GraphicsUnit.Pixel);
            g.DrawImage(src, Norma(5, 13), parts1, GraphicsUnit.Pixel);
            g.DrawImage(src, FlipH(6, 13), parts1, GraphicsUnit.Pixel);
            g.DrawImage(src, Rotat(0, 14), parts1, GraphicsUnit.Pixel);
            g.DrawImage(src, FlipV(1, 14), parts1, GraphicsUnit.Pixel);
            g.DrawImage(src, Rotat(2, 14), parts1, GraphicsUnit.Pixel);
            g.DrawImage(src, FlipV(3, 14), parts1, GraphicsUnit.Pixel);
            g.DrawImage(src, Rotat(4, 14), parts1, GraphicsUnit.Pixel);
            g.DrawImage(src, FlipV(5, 14), parts1, GraphicsUnit.Pixel);
            g.DrawImage(src, Rotat(6, 14), parts1, GraphicsUnit.Pixel);

            g.DrawImage(src, Norma(3, 15), parts1, GraphicsUnit.Pixel);
            g.DrawImage(src, FlipH(4, 15), parts1, GraphicsUnit.Pixel);
            g.DrawImage(src, Norma(7, 15), parts1, GraphicsUnit.Pixel);
            

            //*
            //────────────────────────────────────────
            // パーツ２
            //────────────────────────────────────────
            Rectangle parts2 = Norma(4, 1);
            Rectangle parts2R = Norma(14, 4);
            g.DrawImage(src, Norma(4, 1), parts2, GraphicsUnit.Pixel);
            g.DrawImage(src, FlipH(5, 1), parts2, GraphicsUnit.Pixel);

            g.DrawImage(srcR, FlipH(3, 2), parts2R, GraphicsUnit.Pixel);
            g.DrawImage(srcR, Rotat(3, 3), parts2R, GraphicsUnit.Pixel);

            g.DrawImage(srcR, Norma(6, 2), parts2R, GraphicsUnit.Pixel);
            g.DrawImage(srcR, FlipV(6, 3), parts2R, GraphicsUnit.Pixel);

            g.DrawImage(src, FlipV(4, 4), parts2, GraphicsUnit.Pixel);
            g.DrawImage(src, Rotat(5, 4), parts2, GraphicsUnit.Pixel);

            g.DrawImage(src, FlipV(8, 2), parts2, GraphicsUnit.Pixel);
            g.DrawImage(src, Rotat(9, 2), parts2, GraphicsUnit.Pixel);
            g.DrawImage(src, FlipV(10, 2), parts2, GraphicsUnit.Pixel);
            g.DrawImage(src, Rotat(11, 2), parts2, GraphicsUnit.Pixel);
            g.DrawImage(src, FlipV(12, 2), parts2, GraphicsUnit.Pixel);
            g.DrawImage(src, Rotat(13, 2), parts2, GraphicsUnit.Pixel);

            g.DrawImage(src, Norma(8, 5), parts2, GraphicsUnit.Pixel);
            g.DrawImage(src, FlipH(9, 5), parts2, GraphicsUnit.Pixel);
            g.DrawImage(src, Norma(10, 5), parts2, GraphicsUnit.Pixel);
            g.DrawImage(src, FlipH(11, 5), parts2, GraphicsUnit.Pixel);
            g.DrawImage(src, Norma(12, 5), parts2, GraphicsUnit.Pixel);
            g.DrawImage(src, FlipH(13, 5), parts2, GraphicsUnit.Pixel);

            g.DrawImage(srcR, Norma(8, 6), parts2R, GraphicsUnit.Pixel);
            g.DrawImage(srcR, FlipV(8, 7), parts2R, GraphicsUnit.Pixel);
            g.DrawImage(srcR, Norma(8, 8), parts2R, GraphicsUnit.Pixel);
            g.DrawImage(srcR, FlipV(8, 9), parts2R, GraphicsUnit.Pixel);
            g.DrawImage(srcR, Norma(8, 10), parts2R, GraphicsUnit.Pixel);
            g.DrawImage(srcR, FlipV(8, 11), parts2R, GraphicsUnit.Pixel);

            g.DrawImage(srcR, Norma(11, 6), parts2R, GraphicsUnit.Pixel);
            g.DrawImage(srcR, FlipV(11, 7), parts2R, GraphicsUnit.Pixel);
            g.DrawImage(srcR, Norma(11, 8), parts2R, GraphicsUnit.Pixel);
            g.DrawImage(srcR, FlipV(11, 9), parts2R, GraphicsUnit.Pixel);
            g.DrawImage(srcR, Norma(11, 10), parts2R, GraphicsUnit.Pixel);
            g.DrawImage(srcR, FlipV(11, 11), parts2R, GraphicsUnit.Pixel);
            //*/

            //*
            //────────────────────────────────────────
            // パーツ３
            //────────────────────────────────────────
            Rectangle parts3 = Norma(8, 1);
            Rectangle parts3R = Norma(14, 8);
            g.DrawImage(src, Norma(8, 1), parts3, GraphicsUnit.Pixel);
            g.DrawImage(src, FlipV(8, 0), parts3, GraphicsUnit.Pixel);

            g.DrawImage(src, Rotat(13, 0), parts3, GraphicsUnit.Pixel);
            g.DrawImage(src, FlipH(13, 1), parts3, GraphicsUnit.Pixel);

            g.DrawImage(srcR, Norma(14, 0), parts3R, GraphicsUnit.Pixel);
            g.DrawImage(srcR, FlipH(15, 0), parts3R, GraphicsUnit.Pixel);

            g.DrawImage(srcR, FlipV(14, 5), parts3R, GraphicsUnit.Pixel);
            g.DrawImage(srcR, Rotat(15, 5), parts3R, GraphicsUnit.Pixel);
            //*/

            //*
            //────────────────────────────────────────
            // パーツ４
            //────────────────────────────────────────
            Rectangle parts4 = Norma(10, 1);
            Rectangle parts4R = Norma(14, 10);
            g.DrawImage(src, Norma( 9, 1), parts4, GraphicsUnit.Pixel);
            g.DrawImage(src, Norma(10, 1), parts4, GraphicsUnit.Pixel);
            g.DrawImage(src, Norma(11, 1), parts4, GraphicsUnit.Pixel);
            g.DrawImage(src, Norma(12, 1), parts4, GraphicsUnit.Pixel);
            g.DrawImage(src, FlipV( 9, 0), parts4, GraphicsUnit.Pixel);
            g.DrawImage(src, FlipV(10, 0), parts4, GraphicsUnit.Pixel);
            g.DrawImage(src, FlipV(11, 0), parts4, GraphicsUnit.Pixel);
            g.DrawImage(src, FlipV(12, 0), parts4, GraphicsUnit.Pixel);

            g.DrawImage(srcR, Norma(14, 1), parts4R, GraphicsUnit.Pixel);
            g.DrawImage(srcR, Norma(14, 2), parts4R, GraphicsUnit.Pixel);
            g.DrawImage(srcR, Norma(14, 3), parts4R, GraphicsUnit.Pixel);
            g.DrawImage(srcR, Norma(14, 4), parts4R, GraphicsUnit.Pixel);
            g.DrawImage(srcR, FlipH(15, 1), parts4R, GraphicsUnit.Pixel);
            g.DrawImage(srcR, FlipH(15, 2), parts4R, GraphicsUnit.Pixel);
            g.DrawImage(srcR, FlipH(15, 3), parts4R, GraphicsUnit.Pixel);
            g.DrawImage(srcR, FlipH(15, 4), parts4R, GraphicsUnit.Pixel);
            //*/

            //*
            //────────────────────────────────────────
            // パーツ５
            //────────────────────────────────────────
            Rectangle parts5 = Norma(0, 10);
            g.DrawImage(src, Norma(0, 10), parts5, GraphicsUnit.Pixel);
            g.DrawImage(src, FlipH(1, 10), parts5, GraphicsUnit.Pixel);
            g.DrawImage(src, FlipV(0, 11), parts5, GraphicsUnit.Pixel);
            g.DrawImage(src, Rotat(1, 11), parts5, GraphicsUnit.Pixel);
            //*/

            //*
            //────────────────────────────────────────
            // パーツ６（倍角）
            //────────────────────────────────────────
            Rectangle parts6 = Norma2(2, 1);
            g.DrawImage(src, Norma2(2, 1), parts6, GraphicsUnit.Pixel);
            //*/

            //*
            //────────────────────────────────────────
            // パーツ７（倍角）
            //────────────────────────────────────────
            Rectangle parts7 = Norma2(0, 3);
            g.DrawImage(src, Norma2(0, 3), parts7, GraphicsUnit.Pixel);
            g.DrawImage(src, FlipH2(1, 3), parts7, GraphicsUnit.Pixel);
            g.DrawImage(src, Norma2(2, 3), parts7, GraphicsUnit.Pixel);
            g.DrawImage(src, FlipH2(3, 3), parts7, GraphicsUnit.Pixel);

            g.DrawImage(src, FlipV2(0, 4), parts7, GraphicsUnit.Pixel);
            g.DrawImage(src, Rotat2(1, 4), parts7, GraphicsUnit.Pixel);
            g.DrawImage(src, FlipV2(2, 4), parts7, GraphicsUnit.Pixel);
            g.DrawImage(src, Rotat2(3, 4), parts7, GraphicsUnit.Pixel);
            //*/

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

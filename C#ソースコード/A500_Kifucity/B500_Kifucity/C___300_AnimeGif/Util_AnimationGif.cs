using System;
using System.Drawing;
using System.Drawing.Imaging;
using System.IO;

namespace Grayscale.A500_Kifucity.B500_Kifucity.C___300_AnimeGif
{
    /// <summary>
    /// 出典
    /// http://dobon.net/vb/dotnet/graphics/createanimatedgif.html
    /// </summary>
    public abstract class Util_AnimationGif
    {
        /// <summary>
        /// 複数の画像をGIFアニメーションとして保存する
        /// </summary>
        /// <param name="fileName">保存先のファイルのパス。</param>
        /// <param name="baseImages">GIFアニメにする画像。</param>
        /// <param name="delayTime">遅延時間（100分の1秒単位）。</param>
        /// <param name="loopCount">繰り返す回数。0で無限。</param>
        public static void SaveAnimatedGif(
            string fileName,
            Bitmap[] baseImages,
            UInt16 delayTime,
            UInt16 loopCount)
        {
            //書き込み先のファイルを開く
            FileStream writerFs = new FileStream(fileName,
                FileMode.Create, FileAccess.Write, FileShare.None);
            //BinaryWriterで書き込む
            BinaryWriter writer = new BinaryWriter(writerFs);

            MemoryStream ms = new MemoryStream();
            bool hasGlobalColorTable = false;
            int colorTableSize = 0;

            int imagesCount = baseImages.Length;
            for (int i = 0; i < imagesCount; i++)
            {
                //画像をGIFに変換して、MemoryStreamに入れる
                Bitmap bmp = baseImages[i];
                bmp.Save(ms, ImageFormat.Gif);
                ms.Position = 0;

                if (i == 0)
                {
                    //ヘッダを書き込む
                    //Header
                    writer.Write(ReadBytes(ms, 6));

                    //Logical Screen Descriptor
                    byte[] screenDescriptor = ReadBytes(ms, 7);
                    //Global Color Tableがあるか確認
                    if ((screenDescriptor[4] & 0x80) != 0)
                    {
                        //Color Tableのサイズを取得
                        colorTableSize = screenDescriptor[4] & 0x07;
                        hasGlobalColorTable = true;
                    }
                    else
                    {
                        hasGlobalColorTable = false;
                    }
                    //Global Color Tableを使わない
                    //広域配色表フラグと広域配色表の寸法を消す
                    screenDescriptor[4] = (byte)(screenDescriptor[4] & 0x78);
                    writer.Write(screenDescriptor);

                    //Application Extension
                    writer.Write(GetApplicationExtension(loopCount));
                }
                else
                {
                    //HeaderとLogical Screen Descriptorをスキップ
                    ms.Position += 6 + 7;
                }

                byte[] colorTable = null;
                if (hasGlobalColorTable)
                {
                    //Color Tableを取得
                    colorTable = ReadBytes(ms, (int)Math.Pow(2, colorTableSize + 1) * 3);
                }

                //Graphics Control Extension
                writer.Write(GetGraphicControlExtension(delayTime));
                //基のGraphics Control Extensionをスキップ
                if (ms.GetBuffer()[ms.Position] == 0x21)
                {
                    ms.Position += 8;
                }

                //Image Descriptor
                byte[] imageDescriptor = ReadBytes(ms, 10);
                if (!hasGlobalColorTable)
                {
                    //Local Color Tableを持っているか確認
                    if ((imageDescriptor[9] & 0x80) == 0)
                        throw new Exception("Not found color table.");
                    //Color Tableのサイズを取得
                    colorTableSize = imageDescriptor[9] & 7;
                    //Color Tableを取得
                    colorTable = ReadBytes(ms, (int)Math.Pow(2, colorTableSize + 1) * 3);
                }
                //狭域配色表フラグ (Local Color Table Flag) と狭域配色表の寸法を追加
                imageDescriptor[9] = (byte)(imageDescriptor[9] | 0x80 | colorTableSize);
                writer.Write(imageDescriptor);

                //Local Color Tableを書き込む
                writer.Write(colorTable);

                //Image Dataを書き込む (終了部は書き込まない)
                writer.Write(ReadBytes(ms, (int)(ms.Length - ms.Position - 1)));

                if (i == imagesCount - 1)
                {
                    //終了部 (Trailer)
                    writer.Write((byte)0x3B);
                }

                //MemoryStreamをリセット
                ms.SetLength(0);
            }

            //後始末
            ms.Close();
            writer.Close();
            writerFs.Close();
        }

        /// <summary>
        /// MemoryStreamの現在の位置から指定されたサイズのバイト配列を読み取る
        /// </summary>
        /// <param name="ms">読み取るMemoryStream</param>
        /// <param name="count">読み取るバイトのサイズ</param>
        /// <returns>読み取れたバイト配列</returns>
        private static byte[] ReadBytes(MemoryStream ms, int count)
        {
            byte[] bs = new byte[count];
            ms.Read(bs, 0, count);
            return bs;
        }

        /// <summary>
        /// Netscape Application Extensionブロックを返す。
        /// </summary>
        /// <param name="loopCount">繰り返す回数。0で無限。</param>
        /// <returns>Netscape Application Extensionブロックのbyte配列。</returns>
        private static byte[] GetApplicationExtension(UInt16 loopCount)
        {
            byte[] bs = new byte[19];

            //拡張導入符 (Extension Introducer)
            bs[0] = 0x21;
            //アプリケーション拡張ラベル (Application Extension Label)
            bs[1] = 0xFF;
            //ブロック寸法 (Block Size)
            bs[2] = 0x0B;
            //アプリケーション識別名 (Application Identifier)
            bs[3] = (byte)'N';
            bs[4] = (byte)'E';
            bs[5] = (byte)'T';
            bs[6] = (byte)'S';
            bs[7] = (byte)'C';
            bs[8] = (byte)'A';
            bs[9] = (byte)'P';
            bs[10] = (byte)'E';
            //アプリケーション確証符号 (Application Authentication Code)
            bs[11] = (byte)'2';
            bs[12] = (byte)'.';
            bs[13] = (byte)'0';
            //データ副ブロック寸法 (Data Sub-block Size)
            bs[14] = 0x03;
            //詰め込み欄 [ネットスケープ拡張コード (Netscape Extension Code)]
            bs[15] = 0x01;
            //繰り返し回数 (Loop Count)
            byte[] loopCountBytes = BitConverter.GetBytes(loopCount);
            bs[16] = loopCountBytes[0];
            bs[17] = loopCountBytes[1];
            //ブロック終了符 (Block Terminator)
            bs[18] = 0x00;

            return bs;
        }

        /// <summary>
        /// Graphic Control Extensionブロックを返す。
        /// </summary>
        /// <param name="delayTime">遅延時間（100分の1秒単位）。</param>
        /// <returns>Graphic Control Extensionブロックのbyte配列。</returns>
        private static byte[] GetGraphicControlExtension(UInt16 delayTime)
        {
            byte[] bs = new byte[8];

            //拡張導入符 (Extension Introducer)
            bs[0] = 0x21;
            //グラフィック制御ラベル (Graphic Control Label)
            bs[1] = 0xF9;
            //ブロック寸法 (Block Size)
            bs[2] = 0x04;
            //詰め込み欄 透過色指標を使う時は1
            bs[3] = 0x00;
            //遅延時間 (Delay Time)
            byte[] delayTimeBytes = BitConverter.GetBytes(delayTime);
            bs[4] = delayTimeBytes[0];
            bs[5] = delayTimeBytes[1];
            //透過色指標 (Transparency Index, Transparent Color Index)
            bs[6] = 0x00;
            //ブロック終了符 (Block Terminator)
            bs[7] = 0x00;

            return bs;
        }
    }
}

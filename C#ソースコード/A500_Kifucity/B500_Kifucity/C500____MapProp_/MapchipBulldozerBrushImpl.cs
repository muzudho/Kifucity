using Grayscale.A500_Kifucity.B500_Kifucity.C___400_Image___;
using Grayscale.A500_Kifucity.B500_Kifucity.C___450_Position;
using Grayscale.A500_Kifucity.B500_Kifucity.C___500_MapProp_;
using Grayscale.A500_Kifucity.B500_Kifucity.C450____Position;
using System;
using System.Drawing;

namespace Grayscale.A500_Kifucity.B500_Kifucity.C500____MapProp_
{
    /// <summary>
    /// 境界線で囲まれる形状のマップチップを置くブラシ☆
    /// </summary>
    public class MapchipBulldozerBrushImpl : MapchipBulldozerBrush
    {
        public MapchipBulldozerBrushImpl(
            int layer,
            ImageSourcefile imageSourcefile,
            ImageType imageType
            )
        {
            this.Layer = layer;
            this.ImageSourcefile = imageSourcefile;
            this.ImageType = imageType;
            this.PatchesA = new ImageCropBorder[] {
                    ImageCropBorder.None,
                    ImageCropBorder.kyo境界線_A1,
                    ImageCropBorder.kyo境界線_A2,
                    ImageCropBorder.kyo境界線_A3,
                    ImageCropBorder.kyo境界線_A4,
                    ImageCropBorder.kyo境界線_A5,
                    ImageCropBorder.kyo境界線_A6,
                    ImageCropBorder.kyo境界線_A7,
                    ImageCropBorder.kyo境界線_A8,
                    ImageCropBorder.kyo境界線_A9
            };
            this.PatchesB = new ImageCropBorder[] { ImageCropBorder.None,
                    ImageCropBorder.kyo境界線_B1,
                    ImageCropBorder.kyo境界線_B2,
                    ImageCropBorder.kyo境界線_B3,
                    ImageCropBorder.kyo境界線_B4,
            };
            this.PatchesC = new ImageCropBorder[] { ImageCropBorder.None,
                    ImageCropBorder.kyo境界線_C1,
                    ImageCropBorder.kyo境界線_C2,
                    ImageCropBorder.kyo境界線_C3,
                    ImageCropBorder.kyo境界線_C4,
            };
            this.PatchesD = ImageCropBorder.kyo境界線_D;
            this.PatchesE = new ImageCropBorder[] {
                ImageCropBorder.None,
                ImageCropBorder.None,
                ImageCropBorder.None,
                ImageCropBorder.kyo境界線_E3,
                ImageCropBorder.None,
                     ImageCropBorder.kyo境界線_E5,
                   ImageCropBorder.kyo境界線_E6,
                    ImageCropBorder.kyo境界線_E7,
                ImageCropBorder.None,
                    ImageCropBorder.kyo境界線_E9,
                    ImageCropBorder.kyo境界線_E10,
                    ImageCropBorder.kyo境界線_E11,
                    ImageCropBorder.kyo境界線_E12,
                    ImageCropBorder.kyo境界線_E13,
                    ImageCropBorder.kyo境界線_E14,
                    ImageCropBorder.kyo境界線_E15,
            };
            this.PatchesFx = new ImageCropBorder[] { ImageCropBorder.None,
                    ImageCropBorder.kyo境界線_F1,
                    ImageCropBorder.kyo境界線_F2,
                    ImageCropBorder.kyo境界線_F3,
                    ImageCropBorder.kyo境界線_F4,
                    ImageCropBorder.kyo境界線_F5,
                    ImageCropBorder.kyo境界線_F6,
                    ImageCropBorder.kyo境界線_F7,
                    ImageCropBorder.kyo境界線_F8,
                    ImageCropBorder.kyo境界線_F9,
                    ImageCropBorder.kyo境界線_F10,
                    ImageCropBorder.kyo境界線_F11,
                    ImageCropBorder.kyo境界線_F12,
            };
            this.PatchesGx = new ImageCropBorder[] { ImageCropBorder.None,
                    ImageCropBorder.kyo境界線_G1,
                    ImageCropBorder.kyo境界線_G2,
                    ImageCropBorder.kyo境界線_G3,
                    ImageCropBorder.kyo境界線_G4,
                    ImageCropBorder.kyo境界線_G5,
                    ImageCropBorder.kyo境界線_G6
            };
        }

        /// <summary>
        /// レイヤー番号☆
        /// </summary>
        public int Layer { get; set; }
        public ImageSourcefile ImageSourcefile { get; set; }
        public ImageType ImageType { get; set; }

        /// <summary>
        /// [0]なし
        /// [1]～[9]
        /// </summary>
        public ImageCropBorder[] PatchesA { get; set; }
        /// <summary>
        /// [0]なし
        /// [1]～[4]
        /// </summary>
        public ImageCropBorder[] PatchesB { get; set; }
        /// <summary>
        /// [0]なし
        /// [1]～[4]
        /// </summary>
        public ImageCropBorder[] PatchesC { get; set; }
        public ImageCropBorder PatchesD { get; set; }
        /// <summary>
        /// [0]なし
        /// [1]～[15]のうち幾つか
        /// </summary>
        public ImageCropBorder[] PatchesE { get; set; }
        /// <summary>
        /// [0]なし
        /// [1]～[12]
        /// </summary>
        public ImageCropBorder[] PatchesFx { get; set; }
        /// <summary>
        /// [0]なし
        /// [1]～[6]
        /// </summary>
        public ImageCropBorder[] PatchesGx { get; set; }

        /// <summary>
        /// 周囲８方向に何があるかで、チップの形が決まるぜ☆（＾▽＾）
        /// </summary>
        /// <param name="ucMain"></param>
        /// <param name="pRow"></param>
        /// <param name="pCol"></param>
        private void UpdateBoarder_Sub(UcMain ucMain
            , int pRow, int pCol)
        {
            if ((int)ucMain.City.Cells[this.Layer,pRow,pCol].ImageCrop == (int)ImageCropBorder.kyo境界線_A5)
            {
                // A5は、境界線ではないので、変形しないぜ☆（＾▽＾）
                return;
            }

            int col;
            int row;

            // 東西南北を、数字で表すぜ☆（＾▽＾）
            //
            // 123
            // 456 ※5は空きだぜ☆（＾▽＾）
            // 789

            // 北
            bool exists2 = false;
            col = pCol;
            row = pRow - 1;
            if (-1 < row)
            {
                if ((int)ucMain.City.Cells[this.Layer, row, col].ImageCrop == (int)this.PatchesA[5])
                {
                    exists2 = true;
                }
            }

            // 北東
            bool exists3 = false;
            col = pCol + 1;
            row = pRow - 1;
            if (col < ucMain.City.TableCols && -1 < row)
            {
                if ((int)ucMain.City.Cells[this.Layer, row, col].ImageCrop == (int)this.PatchesA[5])
                {
                    exists3 = true;
                }
            }

            // 東
            bool exists6 = false;
            col = pCol + 1;
            row = pRow;
            if (col < ucMain.City.TableCols)
            {
                if ((int)ucMain.City.Cells[this.Layer, row, col].ImageCrop == (int)this.PatchesA[5])
                {
                    exists6 = true;
                }
            }

            // 南東
            bool exists9 = false;
            col = pCol + 1;
            row = pRow + 1;
            if (col < ucMain.City.TableCols && row < ucMain.City.TableRows)
            {
                if ((int)ucMain.City.Cells[this.Layer, row, col].ImageCrop == (int)this.PatchesA[5])
                {
                    exists9 = true;
                }
            }

            // 南
            bool exists8 = false;
            col = pCol;
            row = pRow + 1;
            if (row < ucMain.City.TableRows)
            {
                if ((int)ucMain.City.Cells[this.Layer, row, col].ImageCrop == (int)this.PatchesA[5])
                {
                    exists8 = true;
                }
            }

            // 南西
            bool exists7 = false;
            col = pCol - 1;
            row = pRow + 1;
            if (-1 < col && row < ucMain.City.TableRows)
            {
                if ((int)ucMain.City.Cells[this.Layer, row, col].ImageCrop == (int)this.PatchesA[5])
                {
                    exists7 = true;
                }
            }

            // 西
            bool exists4 = false;
            col = pCol - 1;
            row = pRow;
            if (-1 < col)
            {
                if ((int)ucMain.City.Cells[this.Layer, row, col].ImageCrop == (int)this.PatchesA[5])
                {
                    exists4 = true;
                }
            }

            // 北西
            bool exists1 = false;
            col = pCol - 1;
            row = pRow - 1;
            if (-1 < col && -1 < row)
            {
                if ((int)ucMain.City.Cells[this.Layer, row, col].ImageCrop == (int)this.PatchesA[5])
                {
                    exists1 = true;
                }
            }


            ImageCropBorder crop = (ImageCropBorder)ImageCrop.None;
            //
            // 変形する条件
            //
            if (!exists8 && !exists7 && !exists4 && !exists1 && !exists2 && !exists3 && !exists6 &&
                  exists9)
            {
                // xxx
                // xxx A1
                // xxo
                crop = this.PatchesA[1];
            }
            else if (
                !exists4 && !exists1 && !exists2 && !exists3 && !exists6 &&
                exists8)
            {
                // xxx
                // xxx A2
                // -o-
                crop = this.PatchesA[2];
            }
            else if (!exists4 && !exists1 && !exists2 && !exists3 && !exists6 && !exists9 && !exists8 &&
                exists7)
            {
                // xxx
                // xxx A3
                // oxx
                crop = this.PatchesA[3];
            }
            else if (
                !exists8 && !exists7 && !exists4 && !exists1 && !exists2 &&
                exists6)
            {
                // xx-
                // xxo A4
                // xx-
                crop = this.PatchesA[4];
            }
            // A5 は境界線ではないので、無視するぜ☆（＾▽＾）
            else if (
                !exists2 && !exists3 && !exists6 && !exists9 && !exists8 &&
                exists4)
            {
                // -xx
                // oxx A6
                // -xx
                crop = this.PatchesA[6];
            }
            else if (!exists6 && !exists9 && !exists8 && !exists7 && !exists4 && !exists1 && !exists2 &&
                exists3)
            {
                // xxo
                // xxx A7
                // xxx
                crop = this.PatchesA[7];
            }
            else if (
                !exists6 && !exists9 && !exists8 && !exists7 && !exists4 &&
                exists2)
            {
                // -o-
                // xxx A8
                // xxx
                crop = this.PatchesA[8];
            }
            else if (!exists2 && !exists3 && !exists6 && !exists9 && !exists8 && !exists7 && !exists4 &&
                exists1)
            {
                // oxx
                // xxx A9
                // xxx
                crop = this.PatchesA[9];
            }

            else if (!exists6 && !exists9 && !exists8 &&
                exists2 && exists4)
            {
                // -o-
                // oxx B1
                // -xx
                crop = this.PatchesB[1];
            }
            else if (!exists8 && !exists7 && !exists4 &&
                exists2 && exists6)
            {
                // -o-
                // xxo B2
                // xx-
                crop = this.PatchesB[2];
            }
            else if (!exists2 && !exists3 && !exists6 &&
                exists8 && exists4)
            {
                // -xx
                // oxx B3
                // -o-
                crop = this.PatchesB[3];
            }
            else if (!exists2 && !exists4 && !exists1 &&
                exists6 && exists8)
            {
                // xx-
                // xxo B4
                // -o-
                crop = this.PatchesB[4];
            }

            else if (!exists6 && !exists8 &&
                exists2 && exists9 && exists4)
            {
                // -o-
                // oxx C1
                // -xo
                crop = this.PatchesC[1];
            }
            else if (!exists8 && !exists4 &&
                exists2 && exists6 && exists7)
            {
                // -o-
                // xxo C2
                // ox-
                crop = this.PatchesC[2];
            }
            else if (!exists2 && !exists6 &&
                exists3 && exists8 && exists4)
            {
                // -xo
                // oxx C3
                // -o-
                crop = this.PatchesC[3];
            }
            else if (!exists2 && !exists4 &&
                exists6 && exists8 && exists1)
            {
                // ox-
                // xxo C4
                // -o-
                crop = this.PatchesC[4];
            }

            else if (exists2 && exists6 && exists8 && exists4)
            {
                // -o-
                // oxo D
                // -o-
                crop = this.PatchesD;
            }

            else if (!exists2 && !exists6 && !exists8 && !exists7 && !exists4 && !exists1 &&
                exists3 && exists9)
            {
                // xxo
                // xxx E6
                // xxo
                crop = this.PatchesE[6];
            }
            else if (!exists2 && !exists3 && !exists6 && !exists8 && !exists4 &&
                exists9 && exists7 && exists1)
            {
                // oxx
                // xxx E13
                // oxo
                crop = this.PatchesE[13];
            }
            else if (!exists2 && !exists6 && !exists9 && !exists8 && !exists4 && !exists1 &&
                exists3 && exists7)
            {
                // xxo
                // xxx E10
                // oxx
                crop = this.PatchesE[10];
            }
            else if (!exists2 && !exists3 && !exists6 && !exists8 && !exists4 && !exists1 &&
                exists9 && exists7)
            {
                // xxx
                // xxx E12
                // oxo
                crop = this.PatchesE[12];
            }
            else if (!exists2 && !exists6 && !exists8 && !exists4 && !exists1 &&
                exists3 && exists9 && exists7)
            {
                // xxo
                // xxx E14
                // oxo
                crop = this.PatchesE[14];
            }
            else if (!exists2 && !exists6 && !exists8 && !exists4 &&
                exists3 && exists9 && exists7 && exists1)
            {
                // oxo
                // xxx E15
                // oxo
                crop = this.PatchesE[15];
            }
            else if (!exists2 && !exists3 && !exists6 && !exists9 && !exists8 && !exists4 &&
                exists1 && exists7)
            {
                // oxx
                // xxx E9
                // oxx
                crop = this.PatchesE[9];
            }
            else if (!exists2 && !exists6 && !exists9 && !exists8 && !exists7 && !exists4 &&
                exists1 && exists3)
            {
                // oxo
                // xxx E3
                // xxx
                crop = this.PatchesE[3];
            }
            else if (!exists2 && !exists6 && !exists8 && !exists7 && !exists4 &&
                exists3 && exists9 && exists1)
            {
                // oxo
                // xxx E7
                // xxo
                crop = this.PatchesE[7];
            }
            else if (!exists2 && !exists6 && !exists9 && !exists8 && !exists4 &&
                exists3 && exists7 && exists1)
            {
                // oxo
                // xxx E11
                // oxx
                crop = this.PatchesE[11];
            }
            else if (!exists2 && !exists3 && !exists6 && !exists8 && !exists7 && !exists4 &&
                exists1 && exists9)
            {
                // oxx
                // xxx E5
                // xxo
                crop = this.PatchesE[5];
            }

            else if (!exists6 && !exists8 && !exists7 && !exists4 &&
                exists2 && exists9)
            {
                // -o-
                // xxx F1
                // xxo
                crop = this.PatchesFx[1];
            }
            else if (!exists6 && !exists8 && !exists4 &&
                exists2 && exists9 && exists7)
            {
                // -o-
                // xxx F2
                // oxo
                crop = this.PatchesFx[2];
            }
            else if (!exists6 && !exists9 && !exists8 && !exists4 &&
                exists2 && exists7)
            {
                // -o-
                // xxx F3
                // oxx
                crop = this.PatchesFx[3];
            }
            else if (!exists2 && !exists6 && !exists4 && !exists1 &&
                exists3 && exists8)
            {
                // xxo
                // xxx F4
                // -o-
                crop = this.PatchesFx[4];
            }
            else if (!exists2 && !exists6 && !exists4 &&
                exists1 && exists3 && exists8)
            {
                // oxo
                // xxx F5
                // -o-
                crop = this.PatchesFx[5];
            }
            else if (!exists2 && !exists3 && !exists6 && !exists4 &&
                exists1 && exists8)
            {
                // oxx
                // xxx F6
                // -o-
                crop = this.PatchesFx[6];
            }
            else if (!exists2 && !exists3 && !exists6 && !exists8 &&
                exists4 && exists9)
            {
                // -xx
                // oxx F7
                // -xo
                crop = this.PatchesFx[7];
            }
            else if (!exists2 && !exists6 && !exists8 &&
                exists3 && exists4 && exists9)
            {
                // -xo
                // oxx F8
                // -xo
                crop = this.PatchesFx[8];
            }
            else if (!exists2 && !exists6 && !exists9 && !exists8 &&
                exists3 && exists4)
            {
                // -xo
                // oxx F9
                // -xx
                crop = this.PatchesFx[9];
            }
            else if (!exists2 && !exists8 && !exists4 && !exists1 &&
                exists6 && exists7)
            {
                // xx-
                // xxo F10
                // ox-
                crop = this.PatchesFx[10];
            }
            else if (!exists2 && !exists8 && !exists4 &&
                exists1 && exists6 && exists7)
            {
                // ox-
                // xxo F11
                // ox-
                crop = this.PatchesFx[11];
            }
            else if (!exists2 && !exists8 && !exists7 && !exists4 &&
                exists1 && exists6)
            {
                // ox-
                // xxo F12
                // xx-
                crop = this.PatchesFx[12];
            }

            else if (!exists6 &&
                exists8 && exists4 && exists2)
            {
                // -o-
                // oxx G1
                // -o-
                crop = this.PatchesGx[1];
            }
            else if (!exists6 && !exists4 &&
                exists2 && exists8)
            {
                // -o-
                // xxx G2
                // -o-
                crop = this.PatchesGx[2];
            }
            else if (!exists4 &&
                exists2 && exists6 && exists8)
            {
                // -o-
                // xxo G3
                // -o-
                crop = this.PatchesGx[3];
            }
            else if ( !exists8 &&
                exists4 && exists2 && exists6)
            {
                // -o-
                // oxo G4
                // -x-
                crop = this.PatchesGx[4];
            }
            else if ( !exists2 && !exists8 &&
                exists4 && exists6)
            {
                // -x-
                // oxo G5
                // -x-
                crop = this.PatchesGx[5];
            }
            else if (!exists2 &&
                exists8 && exists6 && exists4)
            {
                // -x-
                // oxo G6
                // -o-
                crop = this.PatchesGx[6];
            }

            // 更新☆
            if (crop!=ImageCropBorder.None)
            {
                ucMain.City.Cells[this.Layer, pRow, pCol].SetValue(
                    this.ImageType, (ImageCrop)crop, this.ImageSourcefile
                    );
            }
        }

        /// <summary>
        /// 近傍を巻き込んだマップチップの置き換え
        /// </summary>
        public void UpdateNeighborhood(UcMain ucMain //ImageCrop[,,] map
            , int centerRow, int centerCol)
        {
            if (-1 < centerCol && centerCol < ucMain.City.TableCols &&
                -1 < centerRow && centerRow < ucMain.City.TableRows)
            {
                int col;
                int row;

                //────────────────────────────────────────
                // 近傍の同種のマップチップの有無をまず確認だぜ☆（＾▽＾）
                //────────────────────────────────────────

                // 境界線自体は、陸地ではないと判定すること☆（＾▽＾）
                // つまり patches[5] だけが陸地だぜ☆（＾▽＾）

                //────────────────────────────────────────
                // クリックしたところに施設を置くのは確定だぜ☆（＾▽＾）
                //────────────────────────────────────────

                // （更新）中央
                ucMain.City.Cells[this.Layer, centerRow, centerCol].SetValue(
                    this.ImageType, (ImageCrop)this.PatchesA[5], ImageSourcefile.Border_Sunachi
                    );

                //────────────────────────────────────────
                // 8近傍は、更新の候補だぜ☆（＾▽＾）
                //────────────────────────────────────────

                // 次は8近傍を、12時の方角から時計回りで見ていくぜ☆（＾▽＾）
                //
                // ooo
                // oxo
                // ooo
                //

                // （更新）北
                col = centerCol;
                row = centerRow - 1;
                if (-1 < row)
                {
                    this.UpdateBoarder_Sub(ucMain, row, col);
                }

                // （更新）北東
                col = centerCol + 1;
                row = centerRow - 1;
                if (col < ucMain.City.TableCols && -1 < row)
                {
                    this.UpdateBoarder_Sub(ucMain, row, col);
                }

                // （更新）東
                col = centerCol + 1;
                row = centerRow;
                if (col < ucMain.City.TableCols)
                {
                    this.UpdateBoarder_Sub(ucMain, row, col);
                }

                // （更新）南東
                col = centerCol + 1;
                row = centerRow + 1;
                if (col < ucMain.City.TableCols && row < ucMain.City.TableRows)
                {
                    this.UpdateBoarder_Sub(ucMain, row, col);
                }

                // （更新）南
                col = centerCol;
                row = centerRow + 1;
                if (row < ucMain.City.TableRows)
                {
                    this.UpdateBoarder_Sub(ucMain, row, col);
                }

                // （更新）南西
                col = centerCol - 1;
                row = centerRow + 1;
                if (-1 < col && row < ucMain.City.TableRows)
                {
                    this.UpdateBoarder_Sub(ucMain, row, col);
                }

                // （更新）西
                col = centerCol - 1;
                row = centerRow;
                if (-1 < col)
                {
                    this.UpdateBoarder_Sub(ucMain, row, col);
                }

                // （更新）北西
                col = centerCol - 1;
                row = centerRow - 1;
                if (-1 < col && -1 < row)
                {
                    this.UpdateBoarder_Sub(ucMain, row, col);
                }
            }
        }

        /// <summary>
        /// 境界線のある直線状にマップチップを連続配置するぜ☆（＾▽＾）
        /// </summary>
        public void PutMapchipAsLine(
            out bool out_isUpdate, Point mouseLocation, UcMain ucMain
            )
        {
            // ２点間を補完して埋めたい。
            // http://kifucity.warabenture.com/archives/47

            out_isUpdate = false;

            // 始点
            int beginCol = (ucMain.MouseDownLocation.X - ucMain.TableLeft) / PositionImpl.CELL_W;
            int beginRow = (ucMain.MouseDownLocation.Y - ucMain.TableTop) / PositionImpl.CELL_H;
            // 終点
            int endCol = (mouseLocation.X - ucMain.TableLeft) / PositionImpl.CELL_W;
            int endRow = (mouseLocation.Y - ucMain.TableTop) / PositionImpl.CELL_H;
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
                    int pRow;
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
                        pRow = beginRow + iRow;
                        if (pCol < ucMain.City.TableCols && pRow < ucMain.City.TableRows)
                        {
                            this.UpdateNeighborhood(ucMain //this.MapImg
                                , pRow, pCol);
                            //this.MapImg[1, pRow, pCol] = brushRailway.Patches[5];// ImageCrop.su砂_田5;
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
                    int pRow;
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
                        pRow = beginRow + iRow;
                        if (pCol < ucMain.City.TableCols && pRow < ucMain.City.TableRows)
                        {
                            this.UpdateNeighborhood(ucMain //this.MapImg
                                , pRow, pCol);
                            //this.MapImg[1, pRow, pCol] = brushRailway.Patches[5]; //ImageCrop.su砂_田5;
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
                    int pCol;
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

                        pCol = beginCol + iCol;
                        pRow = beginRow + iRow;
                        if (pCol < ucMain.City.TableCols && pRow < ucMain.City.TableRows)
                        {
                            this.UpdateNeighborhood(ucMain //this.MapImg
                                , pRow, pCol);
                            //this.MapImg[1, pRow, pCol] = brushRailway.Patches[5]; //ImageCrop.su砂_田5;
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
                    int pCol;
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

                        pCol = beginCol + iCol;
                        pRow = beginRow + iRow;
                        if (pCol < ucMain.City.TableCols && pRow < ucMain.City.TableRows)
                        {
                            this.UpdateNeighborhood(ucMain //this.MapImg
                                , pRow, pCol);
                            //this.MapImg[1, pRow, pCol] = brushRailway.Patches[5]; //ImageCrop.su砂_田5;
                        }
                    }
                    //*/
                }

                // すぐ更新☆ すぐ描画☆
                out_isUpdate = true;
            }
        }
    }
}

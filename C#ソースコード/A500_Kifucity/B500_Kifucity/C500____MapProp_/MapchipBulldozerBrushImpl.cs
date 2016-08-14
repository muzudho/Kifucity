using Grayscale.A500_Kifucity.B500_Kifucity.C___500_MapProp_;
using System.Drawing;
using System;

namespace Grayscale.A500_Kifucity.B500_Kifucity.C500____MapProp_
{
    /// <summary>
    /// 境界線で囲まれる形状のマップチップを置くブラシ☆
    /// </summary>
    public class MapchipBulldozerBrushImpl : MapchipBulldozerBrush
    {
        public MapchipBulldozerBrushImpl(
            MapchipCrop a1,
            MapchipCrop a2,
            MapchipCrop a3,
            MapchipCrop a4,
            MapchipCrop a5,
            MapchipCrop a6,
            MapchipCrop a7,
            MapchipCrop a8,
            MapchipCrop a9,
            MapchipCrop b1,
            MapchipCrop b2,
            MapchipCrop b3,
            MapchipCrop b4,
            MapchipCrop c1,
            MapchipCrop c2,
            MapchipCrop c3,
            MapchipCrop c4,
            MapchipCrop d,
            MapchipCrop e6,
            MapchipCrop e13,
            MapchipCrop e10,
            MapchipCrop e12,
            MapchipCrop e14,
            MapchipCrop e15,
            MapchipCrop e9,
            MapchipCrop e3,
            MapchipCrop e7,
            MapchipCrop e11,
            MapchipCrop e5,
            MapchipCrop f1,
            MapchipCrop f2,
            MapchipCrop f3,
            MapchipCrop f4,
            MapchipCrop f5,
            MapchipCrop f6,
            MapchipCrop f7,
            MapchipCrop f8,
            MapchipCrop g1,
            MapchipCrop g2,
            MapchipCrop g3,
            MapchipCrop g4,
            MapchipCrop g5,
            MapchipCrop g6
            )
        {
            this.PatchesA = new MapchipCrop[] { MapchipCrop.None, a1, a2, a3, a4, a5, a6, a7, a8, a9 };
            this.PatchesB = new MapchipCrop[] { MapchipCrop.None, b1, b2, b3, b4 };
            this.PatchesC = new MapchipCrop[] { MapchipCrop.None, c1, c2, c3, c4 };
            this.PatchesD = d;
            this.PatchesE = new MapchipCrop[] { MapchipCrop.None, MapchipCrop.None, MapchipCrop.None, e3, MapchipCrop.None, e5, e6, e7, MapchipCrop.None, e9, e10, e11, e12, e13, e14, e15 };
            this.PatchesF = new MapchipCrop[] { MapchipCrop.None, f1, f2, f3, f4, f5, f6, f7, f8 };
            this.PatchesG = new MapchipCrop[] { MapchipCrop.None, g1, g2, g3, g4, g5, g6 };
        }

        /// <summary>
        /// [0]なし
        /// [1]～[9]
        /// </summary>
        public MapchipCrop[] PatchesA { get; set; }
        /// <summary>
        /// [0]なし
        /// [1]～[4]
        /// </summary>
        public MapchipCrop[] PatchesB { get; set; }
        /// <summary>
        /// [0]なし
        /// [1]～[4]
        /// </summary>
        public MapchipCrop[] PatchesC { get; set; }
        public MapchipCrop PatchesD { get; set; }
        /// <summary>
        /// [0]なし
        /// [1]～[15]のうち幾つか
        /// </summary>
        public MapchipCrop[] PatchesE { get; set; }
        /// <summary>
        /// [0]なし
        /// [1]～[8]
        /// </summary>
        public MapchipCrop[] PatchesF { get; set; }
        /// <summary>
        /// [0]なし
        /// [1]～[6]
        /// </summary>
        public MapchipCrop[] PatchesG { get; set; }

        /// <summary>
        /// 周囲８方向に何があるかで、チップの形が決まるぜ☆（＾▽＾）
        /// </summary>
        /// <param name="ucMain"></param>
        /// <param name="pRow"></param>
        /// <param name="pCol"></param>
        private void UpdateBoarder_Sub(UcMain ucMain
            , int pRow, int pCol)
        {
            if (ucMain.MapData1[1,pRow,pCol]==MapchipCrop.kyo境界線_A5)
            {
                // A5は、境界線ではないので、変形しないぜ☆（＾▽＾）
                return;
            }

            int col;
            int row;

            // 東西南北を、数字で表すぜ☆（＾▽＾）
            //
            // 123
            // 456
            // 789

            // 中央
            bool exists5 = false;
            col = pCol;
            row = pRow;
            {
                if (ucMain.MapData1[1, row, col] == this.PatchesA[5])
                {
                    exists5 = true;
                }
            }

            // 北
            bool exists2 = false;
            col = pCol;
            row = pRow - 1;
            if (-1 < row)
            {
                if (ucMain.MapData1[1, row, col] == this.PatchesA[5])
                {
                    exists2 = true;
                }
            }

            // 北東
            bool exists3 = false;
            col = pCol + 1;
            row = pRow - 1;
            if (col < UcMain.TABLE_COLS && -1 < row)
            {
                if (ucMain.MapData1[1, row, col] == this.PatchesA[5])
                {
                    exists3 = true;
                }
            }

            // 東
            bool exists6 = false;
            col = pCol + 1;
            row = pRow;
            if (col < UcMain.TABLE_COLS)
            {
                if (ucMain.MapData1[1, row, col] == this.PatchesA[5])
                {
                    exists6 = true;
                }
            }

            // 南東
            bool exists9 = false;
            col = pCol + 1;
            row = pRow + 1;
            if (col < UcMain.TABLE_COLS && row < UcMain.TABLE_ROWS)
            {
                if (ucMain.MapData1[1, row, col] == this.PatchesA[5])
                {
                    exists9 = true;
                }
            }

            // 南
            bool exists8 = false;
            col = pCol;
            row = pRow + 1;
            if (row < UcMain.TABLE_ROWS)
            {
                if (ucMain.MapData1[1, row, col] == this.PatchesA[5])
                {
                    exists8 = true;
                }
            }

            // 南西
            bool exists7 = false;
            col = pCol - 1;
            row = pRow + 1;
            if (-1 < col && row < UcMain.TABLE_ROWS)
            {
                if (ucMain.MapData1[1, row, col] == this.PatchesA[5])
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
                if (ucMain.MapData1[1, row, col] == this.PatchesA[5])
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
                if (ucMain.MapData1[1, row, col] == this.PatchesA[5])
                {
                    exists1 = true;
                }
            }


            MapchipCrop crop = MapchipCrop.None;
            MapchipImageType image = MapchipImageType.None;
            //
            // 変形する条件
            //
            if (false)
            {

            }
            else if (!exists8 && !exists7 && !exists4 && !exists1 && !exists2 && !exists3 && !exists6 &&
                  exists9 &&
                  !exists5)
            {
                // xxx
                // xxx A1
                // xxo
                crop = this.PatchesA[1];
                image = MapchipImageType.Border_Sunachi;
            }
            else if (
                !exists4 && !exists1 && !exists2 && !exists3 && !exists6 &&
                exists8 &&
                !exists5)
            {
                // xxx
                // xxx A2
                // -o-
                crop = this.PatchesA[2];
                image = MapchipImageType.Border_Sunachi;
            }
            else if (!exists4 && !exists1 && !exists2 && !exists3 && !exists6 && !exists9 && !exists8 &&
                exists7 &&
                  !exists5)
            {
                // xxx
                // xxx A3
                // oxx
                crop = this.PatchesA[3];
                image = MapchipImageType.Border_Sunachi;
            }
            else if (
                !exists8 && !exists7 && !exists4 && !exists1 && !exists2 &&
                exists6 &&
                  !exists5)
            {
                // xx-
                // xxo A4
                // xx-
                crop = this.PatchesA[4];
                image = MapchipImageType.Border_Sunachi;
            }
            // A5 は境界線ではないので、無視するぜ☆（＾▽＾）
            else if (
                !exists2 && !exists3 && !exists6 && !exists9 && !exists8 &&
                exists4 &&
                  !exists5)
            {
                // -xx
                // oxx A6
                // -xx
                crop = this.PatchesA[6];
                image = MapchipImageType.Border_Sunachi;
            }
            else if (!exists6 && !exists9 && !exists8 && !exists7 && !exists4 && !exists1 && !exists2 &&
                exists3 &&
                  !exists5)
            {
                // xxo
                // xxx A7
                // xxx
                crop = this.PatchesA[7];
                image = MapchipImageType.Border_Sunachi;
            }
            else if (
                !exists6 && !exists9 && !exists8 && !exists7 && !exists4 &&
                exists2 &&
                  !exists5)
            {
                // -o-
                // xxx A8
                // xxx
                crop = this.PatchesA[8];
                image = MapchipImageType.Border_Sunachi;
            }
            else if (!exists2 && !exists3 && !exists6 && !exists9 && !exists8 && !exists7 && !exists4 &&
                exists1 &&
                  !exists5)
            {
                // oxx
                // xxx A9
                // xxx
                crop = this.PatchesA[9];
                image = MapchipImageType.Border_Sunachi;
            }

            else if (!exists6 && !exists9 && !exists8 &&
                exists2 && exists4 &&
                  !exists5)
            {
                // -o-
                // oxx B1
                // -xx
                crop = this.PatchesB[1];
                image = MapchipImageType.Border_Sunachi;
            }
            else if (!exists8 && !exists7 && !exists4 &&
                exists2 && exists6 &&
                  !exists5)
            {
                // -o-
                // xxo B2
                // xx-
                crop = this.PatchesB[2];
                image = MapchipImageType.Border_Sunachi;
            }
            else if (!exists2 && !exists3 && !exists6 &&
                exists8 && exists4 &&
                  !exists5)
            {
                // -xx
                // oxx B3
                // -o-
                crop = this.PatchesB[3];
                image = MapchipImageType.Border_Sunachi;
            }
            else if (!exists2 && !exists4 && !exists1 &&
                exists6 && exists8 &&
                  !exists5)
            {
                // xx-
                // xxo B4
                // -o-
                crop = this.PatchesB[4];
                image = MapchipImageType.Border_Sunachi;
            }

            else if (!exists6 && !exists8 &&
                exists2 && exists9 && exists4 &&
                  !exists5)
            {
                // -o-
                // oxx C1
                // -xo
                crop = this.PatchesC[1];
                image = MapchipImageType.Border_Sunachi;
            }
            else if (!exists8 && !exists4 &&
                exists2 && exists6 && exists7 &&
                  !exists5)
            {
                // -o-
                // xxo C2
                // ox-
                crop = this.PatchesC[2];
                image = MapchipImageType.Border_Sunachi;
            }
            else if (!exists2 && !exists6 &&
                exists3 && exists8 && exists4 &&
                  !exists5)
            {
                // -xo
                // oxx C3
                // -o-
                crop = this.PatchesC[3];
                image = MapchipImageType.Border_Sunachi;
            }
            else if (!exists2 && !exists4 &&
                exists6 && exists8 && exists1 &&
                  !exists5)
            {
                // ox-
                // xxo C4
                // -o-
                crop = this.PatchesC[4];
                image = MapchipImageType.Border_Sunachi;
            }

            else if (exists2 && exists6 && exists8 && exists4 &&
                !exists5)
            {
                // -o-
                // oxo D
                // -o-
                crop = this.PatchesD;
                image = MapchipImageType.Border_Sunachi;
            }

            else if (!exists2 && !exists6 && !exists8 && !exists7 && !exists4 && !exists1 &&
                exists3 && exists9 &&
                !exists5)
            {
                // xxo
                // xxx E6
                // xxo
                crop = this.PatchesE[6];
                image = MapchipImageType.Border_Sunachi;
            }
            else if (!exists2 && !exists3 && !exists6 && !exists8 && !exists4 &&
                exists9 && exists7 && exists1 &&
                !exists5)
            {
                // oxx
                // xxx E13
                // oxo
                crop = this.PatchesE[13];
                image = MapchipImageType.Border_Sunachi;
            }
            else if (!exists2 && !exists6 && !exists9 && !exists8 && !exists4 && !exists1 &&
                exists3 && exists7 &&
                !exists5)
            {
                // xxo
                // xxx E10
                // oxx
                crop = this.PatchesE[10];
                image = MapchipImageType.Border_Sunachi;
            }
            else if (!exists2 && !exists3 && !exists6 && !exists8 && !exists4 && !exists1 &&
                exists9 && exists7 &&
                !exists5)
            {
                // xxx
                // xxx E12
                // oxo
                crop = this.PatchesE[12];
                image = MapchipImageType.Border_Sunachi;
            }
            else if (!exists2 && !exists6 && !exists8 && !exists4 && !exists1 &&
                exists3 && exists9 && exists7 &&
                !exists5)
            {
                // xxo
                // xxx E14
                // oxo
                crop = this.PatchesE[14];
                image = MapchipImageType.Border_Sunachi;
            }
            else if (!exists2 && !exists6 && !exists8 && !exists4 &&
                exists3 && exists9 && exists7 && exists1 &&
                !exists5)
            {
                // oxo
                // xxx E15
                // oxo
                crop = this.PatchesE[15];
                image = MapchipImageType.Border_Sunachi;
            }
            else if (!exists2 && !exists3 && !exists6 && !exists9 && !exists8 && !exists4 &&
                exists1 && exists7 &&
                !exists5)
            {
                // oxx
                // xxx E9
                // oxx
                crop = this.PatchesE[9];
                image = MapchipImageType.Border_Sunachi;
            }
            else if (!exists2 && !exists6 && !exists9 && !exists8 && !exists7 && !exists4 &&
                exists1 && exists3 &&
                !exists5)
            {
                // oxo
                // xxx E3
                // xxx
                crop = this.PatchesE[3];
                image = MapchipImageType.Border_Sunachi;
            }
            else if (!exists2 && !exists6 && !exists8 && !exists7 && !exists4 &&
                exists3 && exists9 && exists1 &&
                !exists5)
            {
                // oxo
                // xxx E7
                // xxo
                crop = this.PatchesE[7];
                image = MapchipImageType.Border_Sunachi;
            }
            else if (!exists2 && !exists6 && !exists9 && !exists8 && !exists4 &&
                exists3 && exists7 && exists1 &&
                !exists5)
            {
                // oxo
                // xxx E11
                // oxx
                crop = this.PatchesE[11];
                image = MapchipImageType.Border_Sunachi;
            }
            else if (!exists2 && !exists3 && !exists6 && !exists8 && !exists7 && !exists4 &&
                exists1 && exists9 &&
                !exists5)
            {
                // oxx
                // xxx E5
                // xxo
                crop = this.PatchesE[5];
                image = MapchipImageType.Border_Sunachi;
            }

            else if (!exists6 && !exists8 && !exists7 && !exists4 &&
                exists2 && exists9 &&
                !exists5)
            {
                // -o-
                // xxx F1
                // xxo
                crop = this.PatchesF[1];
                image = MapchipImageType.Border_Sunachi;
            }
            else if (!exists6 && !exists9 && !exists8 && !exists4 &&
                exists2 && exists7 &&
                !exists5)
            {
                // -o-
                // xxx F2
                // oxx
                crop = this.PatchesF[2];
                image = MapchipImageType.Border_Sunachi;
            }
            else if (!exists2 && !exists6 && !exists4 && !exists1 &&
                exists3 && exists8 &&
                !exists5)
            {
                // xxo
                // xxx F3
                // -o-
                crop = this.PatchesF[3];
                image = MapchipImageType.Border_Sunachi;
            }
            else if (!exists2 && !exists3 && !exists6 && !exists4 &&
                exists1 && exists8 &&
                !exists5)
            {
                // oxx
                // xxx F4
                // -o-
                crop = this.PatchesF[4];
                image = MapchipImageType.Border_Sunachi;
            }
            else if (!exists2 && !exists3 && !exists6 && !exists8 &&
                exists4 && exists9 &&
                !exists5)
            {
                // -xx
                // oxx F5
                // -xo
                crop = this.PatchesF[5];
                image = MapchipImageType.Border_Sunachi;
            }
            else if (!exists2 && !exists8 && !exists4 && !exists1 &&
                exists6 && exists7 &&
                !exists5)
            {
                // xx-
                // xxo F6
                // ox-
                crop = this.PatchesF[6];
                image = MapchipImageType.Border_Sunachi;
            }
            else if (!exists2 && !exists6 && !exists9 && !exists8 &&
                exists3 && exists4 &&
                !exists5)
            {
                // -xo
                // oxx F7
                // -xx
                crop = this.PatchesF[7];
                image = MapchipImageType.Border_Sunachi;
            }
            else if (!exists2 && !exists8 && !exists7 && !exists4 &&
                exists1 && exists6 &&
                !exists5)
            {
                // ox-
                // xxo F8
                // xx-
                crop = this.PatchesF[8];
                image = MapchipImageType.Border_Sunachi;
            }

            else if ( !exists2 &&
                exists8 && exists6 && exists4 &&
                !exists5)
            {
                // -x-
                // oxo G1
                // -o-
                crop = this.PatchesG[1];
                image = MapchipImageType.Border_Sunachi;
            }
            else if ( !exists6 &&
                exists8 && exists4 && exists2 &&
                !exists5)
            {
                // -o-
                // oxx G2
                // -o-
                crop = this.PatchesG[2];
                image = MapchipImageType.Border_Sunachi;
            }
            else if ( !exists8 &&
                exists4 && exists2 && exists6 &&
                !exists5)
            {
                // -o-
                // oxo G3
                // -x-
                crop = this.PatchesG[3];
                image = MapchipImageType.Border_Sunachi;
            }
            else if ( !exists4 &&
                exists2 && exists6 && exists8 &&
                !exists5)
            {
                // -o-
                // xxo G4
                // -o-
                crop = this.PatchesG[4];
                image = MapchipImageType.Border_Sunachi;
            }
            else if ( !exists2 && !exists8 &&
                exists4 && exists6 &&
                !exists5)
            {
                // -x-
                // oxo G5
                // -x-
                crop = this.PatchesG[5];
                image = MapchipImageType.Border_Sunachi;
            }
            else if ( !exists6 && !exists4 &&
                exists2 && exists8 &&
                !exists5)
            {
                // -o-
                // xxx G6
                // -o-
                crop = this.PatchesG[6];
                image = MapchipImageType.Border_Sunachi;
            }

            // 更新☆
            if (crop!=MapchipCrop.None && image != MapchipImageType.None)
            {
                ucMain.MapData1[1, pRow, pCol] = crop;
                ucMain.MapData2[1, pRow, pCol] = image;
            }
        }

        /// <summary>
        /// 近傍を巻き込んだマップチップの置き換え
        /// </summary>
        public void UpdateNeighborhood(UcMain ucMain //MapchipCrop[,,] map
            , int centerRow, int centerCol)
        {
            if (-1 < centerCol && centerCol < UcMain.TABLE_COLS &&
                -1 < centerRow && centerRow < UcMain.TABLE_ROWS)
            {
                int col;
                int row;

                //────────────────────────────────────────
                // 近傍の同種のマップチップの有無をまず確認だぜ☆（＾▽＾）
                //────────────────────────────────────────

                // 境界線自体は、陸地ではないと判定すること☆（＾▽＾）
                // つまり patches[5] だけが陸地だぜ☆（＾▽＾）

                // 次は8近傍を、12時の方角から時計回りで見ていくぜ☆（＾▽＾）
                //
                // ooo
                // oxo
                // ooo
                //

                // 北
                bool existsNorth = false;
                col = centerCol;
                row = centerRow - 1;
                if (-1 < row)
                {
                    if (ucMain.MapData1[1, row, col] == this.PatchesA[5])
                    {
                        existsNorth = true;
                    }
                }

                // 北東
                bool existsNorthEast = false;
                col = centerCol + 1;
                row = centerRow - 1;
                if (col < UcMain.TABLE_COLS && -1 < row)
                {
                    if (ucMain.MapData1[1, row, col] == this.PatchesA[5])
                    {
                        existsNorthEast = true;
                    }
                }

                // 東
                bool existsEast = false;
                col = centerCol + 1;
                row = centerRow;
                if (col < UcMain.TABLE_COLS)
                {
                    if (ucMain.MapData1[1, row, col] == this.PatchesA[5])
                    {
                        existsEast = true;
                    }
                }

                // 南東
                bool existsSouthEast = false;
                col = centerCol + 1;
                row = centerRow + 1;
                if (col < UcMain.TABLE_COLS && row < UcMain.TABLE_ROWS)
                {
                    if (ucMain.MapData1[1, row, col] == this.PatchesA[5])
                    {
                        existsSouthEast = true;
                    }
                }

                // 南
                bool existsSouth = false;
                col = centerCol;
                row = centerRow + 1;
                if (row < UcMain.TABLE_ROWS)
                {
                    if (ucMain.MapData1[1, row, col] == this.PatchesA[5])
                    {
                        existsSouth = true;
                    }
                }

                // 南西
                bool existsSouthWest = false;
                col = centerCol - 1;
                row = centerRow + 1;
                if (-1 < col && row < UcMain.TABLE_ROWS)
                {
                    if (ucMain.MapData1[1, row, col] == this.PatchesA[5])
                    {
                        existsSouthWest = true;
                    }
                }

                // 西
                bool existsWest = false;
                col = centerCol - 1;
                row = centerRow;
                if (-1 < col)
                {
                    if (ucMain.MapData1[1, row, col] == this.PatchesA[5])
                    {
                        existsWest = true;
                    }
                }

                // 北西
                bool existsNorthWest = false;
                col = centerCol - 1;
                row = centerRow - 1;
                if (-1 < col && -1 < row)
                {
                    if (ucMain.MapData1[1, row, col] == this.PatchesA[5])
                    {
                        existsNorthWest = true;
                    }
                }


                //────────────────────────────────────────
                // クリックしたところに施設を置くのは確定だぜ☆（＾▽＾）
                //────────────────────────────────────────

                // （更新）中央
                ucMain.MapData1[1, centerRow, centerCol] = this.PatchesA[5];
                ucMain.MapData2[1, centerRow, centerCol] = MapchipImageType.Border_Sunachi;

                //────────────────────────────────────────
                // 8近傍は、更新の候補だぜ☆（＾▽＾）
                //────────────────────────────────────────

                // ooo
                // oxo
                // ooo

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
                if (col < UcMain.TABLE_COLS && -1 < row)
                {
                    this.UpdateBoarder_Sub(ucMain, row, col);
                }

                // （更新）東
                col = centerCol + 1;
                row = centerRow;
                if (col < UcMain.TABLE_COLS)
                {
                    this.UpdateBoarder_Sub(ucMain, row, col);
                }

                // （更新）南東
                col = centerCol + 1;
                row = centerRow + 1;
                if (col < UcMain.TABLE_COLS && row < UcMain.TABLE_ROWS)
                {
                    this.UpdateBoarder_Sub(ucMain, row, col);
                }

                // （更新）南
                col = centerCol;
                row = centerRow + 1;
                if (row < UcMain.TABLE_ROWS)
                {
                    this.UpdateBoarder_Sub(ucMain, row, col);
                }

                // （更新）南西
                col = centerCol - 1;
                row = centerRow + 1;
                if (-1 < col && row < UcMain.TABLE_ROWS)
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
            int beginCol = (ucMain.MouseDownLocation.X - ucMain.TableLeft) / UcMain.CELL_W;
            int beginRow = (ucMain.MouseDownLocation.Y - ucMain.TableTop) / UcMain.CELL_H;
            // 終点
            int endCol = (mouseLocation.X - ucMain.TableLeft) / UcMain.CELL_W;
            int endRow = (mouseLocation.Y - ucMain.TableTop) / UcMain.CELL_H;
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
                        if (pCol < UcMain.TABLE_COLS && pRow < UcMain.TABLE_ROWS)
                        {
                            this.UpdateNeighborhood(ucMain //this.MapImg
                                , pRow, pCol);
                            //this.MapImg[1, pRow, pCol] = brushRailway.Patches[5];// MapchipCrop.su砂_田5;
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
                        if (pCol < UcMain.TABLE_COLS && pRow < UcMain.TABLE_ROWS)
                        {
                            this.UpdateNeighborhood(ucMain //this.MapImg
                                , pRow, pCol);
                            //this.MapImg[1, pRow, pCol] = brushRailway.Patches[5]; //MapchipCrop.su砂_田5;
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
                        if (pCol < UcMain.TABLE_COLS && pRow < UcMain.TABLE_ROWS)
                        {
                            this.UpdateNeighborhood(ucMain //this.MapImg
                                , pRow, pCol);
                            //this.MapImg[1, pRow, pCol] = brushRailway.Patches[5]; //MapchipCrop.su砂_田5;
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
                        if (pCol < UcMain.TABLE_COLS && pRow < UcMain.TABLE_ROWS)
                        {
                            this.UpdateNeighborhood(ucMain //this.MapImg
                                , pRow, pCol);
                            //this.MapImg[1, pRow, pCol] = brushRailway.Patches[5]; //MapchipCrop.su砂_田5;
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

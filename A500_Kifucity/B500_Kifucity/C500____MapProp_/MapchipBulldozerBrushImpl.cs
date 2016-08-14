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
            MapchipCrop patch1,
            MapchipCrop patch2,
            MapchipCrop patch3,
            MapchipCrop patch4,
            MapchipCrop patch5,
            MapchipCrop patch6,
            MapchipCrop patch7,
            MapchipCrop patch8,
            MapchipCrop patch9,
            MapchipCrop patch10,
            MapchipCrop patch11,
            MapchipCrop patch12,
            MapchipCrop patch13,
            MapchipCrop patch14,
            MapchipCrop patch15,
            MapchipCrop patch16,
            MapchipCrop patch17,
            MapchipCrop patch18,
            MapchipCrop patch19
            )
        {
            this.Patches = new MapchipCrop[]
            {
                MapchipCrop.None,
                patch1,
                patch2,
                patch3,
                patch4,
                patch5,
                patch6,
                patch7,
                patch8,
                patch9,
                patch10,
                patch11,
                patch12,
                patch13,
                patch14,
                patch15,
                patch16,
                patch17,
                patch18,
                patch19
            };
        }

        /// <summary>
        /// [0]なし
        /// [1]┌
        /// [2]┬
        /// [3]┐
        /// [4]├
        /// [5]┼
        /// [6]┤
        /// [7]└
        /// [8]┴
        /// [9]┘
        /// [10]逆┌
        /// [11]逆┐
        /// [12]逆└
        /// [13]逆┘
        /// [14]角無／
        /// [15]角無＼
        /// [16]角無┌
        /// [17]角無┐
        /// [18]角無└
        /// [19]角無┘
        /// </summary>
        public MapchipCrop[] Patches { get; set; }


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

                // 1個所更新すると、まずは17近傍を、12時の方角から時計回りで見ていくぜ☆（＾▽＾）
                //
                // ooo
                // ooo
                // ooo
                // +xxx
                // +xxx
                // +xxx
                //

                // まずは17近傍を、12時の方角から時計回りで見ていくぜ☆（＾▽＾）
                //
                // ooooo
                // oxxxo
                // oxxxo
                // oxxxo
                // ooooo
                //

                // 北北
                bool existsNorthNorth = false;
                col = centerCol;
                row = centerRow - 2;
                if (-1 < row)
                {
                    if (ucMain.MapData1[1, row, col] == this.Patches[5])
                    {
                        existsNorthNorth = true;
                    }
                }

                // 北北東
                bool existsNorthNorthEast = false;
                col = centerCol + 1;
                row = centerRow - 2;
                if (col < UcMain.TABLE_COLS && -1 < row)
                {
                    if (ucMain.MapData1[1, row, col] == this.Patches[5])
                    {
                        existsNorthNorthEast = true;
                    }
                }

                // 北東北東
                bool existsNorthEastNorthEast = false;
                col = centerCol + 2;
                row = centerRow - 2;
                if (col < UcMain.TABLE_COLS && - 1 < row)
                {
                    if (ucMain.MapData1[1, row, col] == this.Patches[5])
                    {
                        existsNorthEastNorthEast = true;
                    }
                }

                // 東東北
                bool existsEastEastNorth = false;
                col = centerCol + 2;
                row = centerRow - 1;
                if (col < UcMain.TABLE_COLS && -1 < row)
                {
                    if (ucMain.MapData1[1, row, col] == this.Patches[5])
                    {
                        existsEastEastNorth = true;
                    }
                }

                // 東東
                bool existsEastEast = false;
                col = centerCol + 2;
                row = centerRow;
                if ( col<UcMain.TABLE_COLS)
                {
                    if (ucMain.MapData1[1, row, col] == this.Patches[5])
                    {
                        existsEastEast = true;
                    }
                }

                // 東東南
                bool existsEastEastSouth = false;
                col = centerCol + 2;
                row = centerRow + 1;
                if (col < UcMain.TABLE_COLS && row < UcMain.TABLE_ROWS)
                {
                    if (ucMain.MapData1[1, row, col] == this.Patches[5])
                    {
                        existsEastEastSouth = true;
                    }
                }

                // 南東南東
                bool existsSouthEastSouthEast = false;
                col = centerCol + 2;
                row = centerRow + 2;
                if (col < UcMain.TABLE_COLS && row < UcMain.TABLE_ROWS)
                {
                    if (ucMain.MapData1[1, row, col] == this.Patches[5])
                    {
                        existsSouthEastSouthEast = true;
                    }
                }

                // 南南東
                bool existsSouthSouthEast = false;
                col = centerCol + 1;
                row = centerRow + 2;
                if (col < UcMain.TABLE_COLS && row < UcMain.TABLE_ROWS)
                {
                    if (ucMain.MapData1[1, row, col] == this.Patches[5])
                    {
                        existsSouthSouthEast = true;
                    }
                }

                // 南南
                bool existsSouthSouth = false;
                col = centerCol;
                row = centerRow + 2;
                if (row < UcMain.TABLE_ROWS)
                {
                    if (ucMain.MapData1[1, row, col] == this.Patches[5])
                    {
                        existsSouthSouth = true;
                    }
                }

                // 南南西
                bool existsSouthSouthWest = false;
                col = centerCol - 1;
                row = centerRow + 2;
                if (-1 < col && row < UcMain.TABLE_ROWS)
                {
                    if (ucMain.MapData1[1, row, col] == this.Patches[5])
                    {
                        existsSouthSouthWest = true;
                    }
                }

                // 南西南西
                bool existsSouthWestSouthWest = false;
                col = centerCol - 2;
                row = centerRow + 2;
                if (-1 < col && row < UcMain.TABLE_ROWS)
                {
                    if (ucMain.MapData1[1, row, col] == this.Patches[5])
                    {
                        existsSouthWestSouthWest = true;
                    }
                }

                // 西西南
                bool existsWestWestSouth = false;
                col = centerCol - 2;
                row = centerRow + 1;
                if (-1 < col && row < UcMain.TABLE_ROWS)
                {
                    if (ucMain.MapData1[1, row, col] == this.Patches[5])
                    {
                        existsWestWestSouth = true;
                    }
                }

                // 西西
                bool existsWestWest = false;
                col = centerCol - 2;
                row = centerRow;
                if (-1 < col)
                {
                    if (ucMain.MapData1[1, row, col] == this.Patches[5])
                    {
                        existsWestWest = true;
                    }
                }

                // 西西北
                bool existsWestWestNorth = false;
                col = centerCol - 2;
                row = centerRow - 1;
                if (-1 < col && -1 < row)
                {
                    if (ucMain.MapData1[1, row, col] == this.Patches[5])
                    {
                        existsWestWestNorth = true;
                    }
                }

                // 北西北西
                bool existsNorthWestNorthWest = false;
                col = centerCol - 2;
                row = centerRow - 2;
                if (-1 < col && -1 < row)
                {
                    if (ucMain.MapData1[1, row, col] == this.Patches[5])
                    {
                        existsNorthWestNorthWest = true;
                    }
                }

                // 北北西
                bool existsNorthNorthWest = false;
                col = centerCol - 1;
                row = centerRow - 2;
                if (-1 < col && -1 < row)
                {
                    if (ucMain.MapData1[1, row, col] == this.Patches[5])
                    {
                        existsNorthNorthWest = true;
                    }
                }

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
                    if (ucMain.MapData1[1, row, col] == this.Patches[5])
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
                    if (ucMain.MapData1[1, row, col] == this.Patches[5])
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
                    if (ucMain.MapData1[1, row, col] == this.Patches[5])
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
                    if (ucMain.MapData1[1, row, col] == this.Patches[5])
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
                    if (ucMain.MapData1[1, row, col] == this.Patches[5])
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
                    if (ucMain.MapData1[1, row, col] == this.Patches[5])
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
                    if (ucMain.MapData1[1, row, col] == this.Patches[5])
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
                    if (ucMain.MapData1[1, row, col] == this.Patches[5])
                    {
                        existsNorthWest = true;
                    }
                }



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
                    if (existsNorthNorthWest)
                    {
                        // x → 逆└
                        ucMain.MapData1[1, row, col] = this.Patches[12];
                        ucMain.MapData2[1, row, col] = MapchipImageType.Border_Sunachi;
                    }
                    else if (existsNorthNorth)
                    {
                        // x → ┼
                        ucMain.MapData1[1, row, col] = this.Patches[5];
                        ucMain.MapData2[1, row, col] = MapchipImageType.Border_Sunachi;
                    }
                    else if (existsNorthNorthEast)
                    {
                        // x → 逆┘
                        ucMain.MapData1[1, row, col] = this.Patches[13];
                        ucMain.MapData2[1, row, col] = MapchipImageType.Border_Sunachi;
                    }
                    else
                    {
                        // x → ┬
                        ucMain.MapData1[1, row, col] = this.Patches[2];
                        ucMain.MapData2[1, row, col] = MapchipImageType.Border_Sunachi;
                    }
                }

                // （更新）北東
                col = centerCol + 1;
                row = centerRow - 1;
                if (col < UcMain.TABLE_COLS && -1 < row)
                {
                    if (existsNorthNorth)
                    {
                        // x → ┤
                        ucMain.MapData1[1, row, col] = this.Patches[6];
                        ucMain.MapData2[1, row, col] = MapchipImageType.Border_Sunachi;
                    }
                    else if (existsNorthNorthEast)
                    {
                        // x → 逆┌
                        ucMain.MapData1[1, row, col] = this.Patches[10];
                        ucMain.MapData2[1, row, col] = MapchipImageType.Border_Sunachi;
                    }
                    else if (existsEastEastNorth)
                    {
                        // x → 逆┘
                        ucMain.MapData1[1, row, col] = this.Patches[13];
                        ucMain.MapData2[1, row, col] = MapchipImageType.Border_Sunachi;
                    }
                    else if (existsEastEast)
                    {
                        // x → ┬
                        ucMain.MapData1[1, row, col] = this.Patches[2];
                        ucMain.MapData2[1, row, col] = MapchipImageType.Border_Sunachi;
                    }
                    else if (existsNorthEastNorthEast)
                    {
                        // x → 角無＼
                        ucMain.MapData1[1, row, col] = this.Patches[15];
                        ucMain.MapData2[1, row, col] = MapchipImageType.Border_Sunachi;
                    }
                    else if (existsNorthNorth && existsNorthEastNorthEast)
                    {
                        // x → 角無┘
                        ucMain.MapData1[1, row, col] = this.Patches[19];
                        ucMain.MapData2[1, row, col] = MapchipImageType.Border_Sunachi;
                    }
                    else if (existsNorthEastNorthEast & existsEastEast)
                    {
                        // x → 角無┌
                        ucMain.MapData1[1, row, col] = this.Patches[16];
                        ucMain.MapData2[1, row, col] = MapchipImageType.Border_Sunachi;
                    }
                    else
                    {
                        // x → ┐
                        ucMain.MapData1[1, row, col] = this.Patches[3];
                        ucMain.MapData2[1, row, col] = MapchipImageType.Border_Sunachi;
                    }
                }

                // （更新）東
                col = centerCol + 1;
                row = centerRow;
                if (col < UcMain.TABLE_COLS)
                {
                    if (existsEastEastNorth)
                    {
                        // x → 逆┌
                        ucMain.MapData1[1, row, col] = this.Patches[10];
                        ucMain.MapData2[1, row, col] = MapchipImageType.Border_Sunachi;
                    }
                    else if (existsEastEast)
                    {
                        // x → ┼
                        ucMain.MapData1[1, row, col] = this.Patches[5];
                        ucMain.MapData2[1, row, col] = MapchipImageType.Border_Sunachi;
                    }
                    else if (existsEastEastSouth)
                    {
                        // x → 逆└
                        ucMain.MapData1[1, row, col] = this.Patches[12];
                        ucMain.MapData2[1, row, col] = MapchipImageType.Border_Sunachi;
                    }
                    else
                    {
                        // x → ┤
                        ucMain.MapData1[1, row, col] = this.Patches[6];
                        ucMain.MapData2[1, row, col] = MapchipImageType.Border_Sunachi;
                    }
                }

                // （更新）南東
                col = centerCol + 1;
                row = centerRow + 1;
                if (col < UcMain.TABLE_COLS && row < UcMain.TABLE_ROWS)
                {
                    if (existsSouthSouth)
                    {
                        // x → ┤
                        ucMain.MapData1[1, row, col] = this.Patches[6];
                        ucMain.MapData2[1, row, col] = MapchipImageType.Border_Sunachi;
                    }
                    else if (existsSouthSouthEast)
                    {
                        // x → 逆└
                        ucMain.MapData1[1, row, col] = this.Patches[12];
                        ucMain.MapData2[1, row, col] = MapchipImageType.Border_Sunachi;
                    }
                    else if (existsEastEastSouth)
                    {
                        // x → 逆┐
                        ucMain.MapData1[1, row, col] = this.Patches[11];
                        ucMain.MapData2[1, row, col] = MapchipImageType.Border_Sunachi;
                    }
                    else if (existsEastEast)
                    {
                        // x → ┴
                        ucMain.MapData1[1, row, col] = this.Patches[8];
                        ucMain.MapData2[1, row, col] = MapchipImageType.Border_Sunachi;
                    }
                    else
                    {
                        // x → ┘
                        ucMain.MapData1[1, row, col] = this.Patches[9];
                        ucMain.MapData2[1, row, col] = MapchipImageType.Border_Sunachi;
                    }
                }

                // （更新）南
                col = centerCol;
                row = centerRow + 1;
                if (row < UcMain.TABLE_ROWS)
                {
                    if (existsSouthSouthEast)
                    {
                        // x → 逆┐
                        ucMain.MapData1[1, row, col] = this.Patches[11];
                        ucMain.MapData2[1, row, col] = MapchipImageType.Border_Sunachi;
                    }
                    else if (existsSouthSouth)
                    {
                        // x → ┼
                        ucMain.MapData1[1, row, col] = this.Patches[5];
                        ucMain.MapData2[1, row, col] = MapchipImageType.Border_Sunachi;
                    }
                    else if (existsSouthSouthWest)
                    {
                        // x → 逆┌
                        ucMain.MapData1[1, row, col] = this.Patches[10];
                        ucMain.MapData2[1, row, col] = MapchipImageType.Border_Sunachi;
                    }
                    else
                    {
                        // x → ┴
                        ucMain.MapData1[1, row, col] = this.Patches[8];
                        ucMain.MapData2[1, row, col] = MapchipImageType.Border_Sunachi;
                    }
                }

                // （更新）南西
                col = centerCol - 1;
                row = centerRow + 1;
                if (-1 < col && row < UcMain.TABLE_ROWS)
                {
                    if (existsSouthSouth)
                    {
                        // x → ├
                        ucMain.MapData1[1, row, col] = this.Patches[4];
                        ucMain.MapData2[1, row, col] = MapchipImageType.Border_Sunachi;
                    }
                    else if (existsSouthSouthWest)
                    {
                        // x → 逆┘
                        ucMain.MapData1[1, row, col] = this.Patches[13];
                        ucMain.MapData2[1, row, col] = MapchipImageType.Border_Sunachi;
                    }
                    else if (existsWestWestSouth)
                    {
                        // x → 逆┌
                        ucMain.MapData1[1, row, col] = this.Patches[10];
                        ucMain.MapData2[1, row, col] = MapchipImageType.Border_Sunachi;
                    }
                    else if (existsWestWest)
                    {
                        // x → ┴
                        ucMain.MapData1[1, row, col] = this.Patches[8];
                        ucMain.MapData2[1, row, col] = MapchipImageType.Border_Sunachi;
                    }
                    else
                    {
                        // x → └
                        ucMain.MapData1[1, row, col] = this.Patches[7];
                        ucMain.MapData2[1, row, col] = MapchipImageType.Border_Sunachi;
                    }
                }

                // （更新）西
                col = centerCol - 1;
                row = centerRow;
                if (-1 < col)
                {
                    if (existsWestWestNorth)
                    {
                        // x → 逆┐
                        ucMain.MapData1[1, row, col] = this.Patches[11];
                        ucMain.MapData2[1, row, col] = MapchipImageType.Border_Sunachi;
                    }
                    else if (existsWestWest)
                    {
                        // x → ┼
                        ucMain.MapData1[1, row, col] = this.Patches[5];
                        ucMain.MapData2[1, row, col] = MapchipImageType.Border_Sunachi;
                    }
                    else if (existsWestWestSouth)
                    {
                        // x → 逆┘
                        ucMain.MapData1[1, row, col] = this.Patches[13];
                        ucMain.MapData2[1, row, col] = MapchipImageType.Border_Sunachi;
                    }
                    else
                    {
                        // x → ├
                        ucMain.MapData1[1, row, col] = this.Patches[4];
                        ucMain.MapData2[1, row, col] = MapchipImageType.Border_Sunachi;
                    }
                }

                // （更新）北西
                col = centerCol - 1;
                row = centerRow - 1;
                if (-1 < col && -1 < row)
                {
                    if (existsNorthNorth)
                    {
                        // x → ├
                        ucMain.MapData1[1, row, col] = this.Patches[4];
                        ucMain.MapData2[1, row, col] = MapchipImageType.Border_Sunachi;
                    }
                    else if (existsNorthNorthWest)
                    {
                        // x → 逆┐
                        ucMain.MapData1[1, row, col] = this.Patches[11];
                        ucMain.MapData2[1, row, col] = MapchipImageType.Border_Sunachi;
                    }
                    else if (existsWestWestNorth)
                    {
                        // x → 逆└
                        ucMain.MapData1[1, row, col] = this.Patches[12];
                        ucMain.MapData2[1, row, col] = MapchipImageType.Border_Sunachi;
                    }
                    else if (existsWestWest)
                    {
                        // x → ┬
                        ucMain.MapData1[1, row, col] = this.Patches[2];
                        ucMain.MapData2[1, row, col] = MapchipImageType.Border_Sunachi;
                    }
                    else
                    {
                        // x → ┌
                        ucMain.MapData1[1, row, col] = this.Patches[1];
                        ucMain.MapData2[1, row, col] = MapchipImageType.Border_Sunachi;
                    }
                }

                // （更新）中央
                ucMain.MapData1[1, centerRow, centerCol] = this.Patches[5];
                ucMain.MapData2[1, centerRow, centerCol] = MapchipImageType.Border_Sunachi;
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

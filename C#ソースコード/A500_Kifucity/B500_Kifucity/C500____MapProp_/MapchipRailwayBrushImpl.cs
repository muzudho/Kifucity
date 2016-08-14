using Grayscale.A500_Kifucity.B500_Kifucity.C___500_MapProp_;
using System.Drawing;
using System;

namespace Grayscale.A500_Kifucity.B500_Kifucity.C500____MapProp_
{
    /// <summary>
    /// 線路状のマップチップを置くブラシ☆
    /// </summary>
    public class MapchipRailwayBrushImpl : MapchipRailwayBrush
    {
        public MapchipRailwayBrushImpl(
            int layer,
            MapchipCrop point,
            MapchipCrop vertical,
            MapchipCrop horizontal,
            MapchipCrop patch1,
            MapchipCrop patch2,
            MapchipCrop patch3,
            MapchipCrop patch4,
            MapchipCrop patch5,
            MapchipCrop patch6,
            MapchipCrop patch7,
            MapchipCrop patch8,
            MapchipCrop patch9
            )
        {
            this.Layer = layer;
            this.Point = point;
            this.Vertical = vertical;
            this.Horizontal = horizontal;
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
                patch9
            };
        }

        /// <summary>
        /// レイヤー番号☆
        /// </summary>
        public int Layer { get; set; }

        /// <summary>
        /// ・
        /// </summary>
        public MapchipCrop Point { get; set; }
        /// <summary>
        /// │
        /// </summary>
        public MapchipCrop Vertical { get; set; }
        /// <summary>
        /// ─
        /// </summary>
        public MapchipCrop Horizontal { get; set; }

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

                // 北東
                bool isNorthEast = false;
                col = centerCol + 1;
                row = centerRow - 1;
                if (col < UcMain.TABLE_COLS && -1 < row)
                {
                    if (
                        ucMain.MapData1[this.Layer, row, col] == this.Patches[1] ||
                        ucMain.MapData1[this.Layer, row, col] == this.Patches[2] ||
                        ucMain.MapData1[this.Layer, row, col] == this.Patches[3] ||
                        ucMain.MapData1[this.Layer, row, col] == this.Patches[4] ||
                        ucMain.MapData1[this.Layer, row, col] == this.Patches[5] ||
                        ucMain.MapData1[this.Layer, row, col] == this.Patches[6] ||
                        ucMain.MapData1[this.Layer, row, col] == this.Patches[7] ||
                        ucMain.MapData1[this.Layer, row, col] == this.Patches[8] ||
                        ucMain.MapData1[this.Layer, row, col] == this.Patches[9] ||
                        ucMain.MapData1[this.Layer, row, col] == this.Point ||
                        ucMain.MapData1[this.Layer, row, col] == this.Vertical ||
                        ucMain.MapData1[this.Layer, row, col] == this.Horizontal
                        )
                    {
                        isNorthEast = true;
                    }
                }

                // 南東
                bool isSouthEast = false;
                col = centerCol + 1;
                row = centerRow + 1;
                if (col < UcMain.TABLE_COLS && row < UcMain.TABLE_ROWS)
                {
                    if (
                        ucMain.MapData1[this.Layer, row, col] == this.Patches[1] ||
                        ucMain.MapData1[this.Layer, row, col] == this.Patches[2] ||
                        ucMain.MapData1[this.Layer, row, col] == this.Patches[3] ||
                        ucMain.MapData1[this.Layer, row, col] == this.Patches[4] ||
                        ucMain.MapData1[this.Layer, row, col] == this.Patches[5] ||
                        ucMain.MapData1[this.Layer, row, col] == this.Patches[6] ||
                        ucMain.MapData1[this.Layer, row, col] == this.Patches[7] ||
                        ucMain.MapData1[this.Layer, row, col] == this.Patches[8] ||
                        ucMain.MapData1[this.Layer, row, col] == this.Patches[9] ||
                        ucMain.MapData1[this.Layer, row, col] == this.Point ||
                        ucMain.MapData1[this.Layer, row, col] == this.Vertical ||
                        ucMain.MapData1[this.Layer, row, col] == this.Horizontal
                        )
                    {
                        isSouthEast = true;
                    }
                }

                // 南西
                bool isSouthWest = false;
                col = centerCol - 1;
                row = centerRow + 1;
                if (-1 < col && row < UcMain.TABLE_ROWS)
                {
                    if (
                        ucMain.MapData1[this.Layer, row, col] == this.Patches[1] ||
                        ucMain.MapData1[this.Layer, row, col] == this.Patches[2] ||
                        ucMain.MapData1[this.Layer, row, col] == this.Patches[3] ||
                        ucMain.MapData1[this.Layer, row, col] == this.Patches[4] ||
                        ucMain.MapData1[this.Layer, row, col] == this.Patches[5] ||
                        ucMain.MapData1[this.Layer, row, col] == this.Patches[6] ||
                        ucMain.MapData1[this.Layer, row, col] == this.Patches[7] ||
                        ucMain.MapData1[this.Layer, row, col] == this.Patches[8] ||
                        ucMain.MapData1[this.Layer, row, col] == this.Patches[9] ||
                        ucMain.MapData1[this.Layer, row, col] == this.Point ||
                        ucMain.MapData1[this.Layer, row, col] == this.Vertical ||
                        ucMain.MapData1[this.Layer, row, col] == this.Horizontal
                        )
                    {
                        isSouthWest = true;
                    }
                }

                // 北西
                bool isNorthWest = false;
                col = centerCol - 1;
                row = centerRow - 1;
                if (-1 < col && -1 < row)
                {
                    if (
                        ucMain.MapData1[this.Layer, row, col] == this.Patches[1] ||
                        ucMain.MapData1[this.Layer, row, col] == this.Patches[2] ||
                        ucMain.MapData1[this.Layer, row, col] == this.Patches[3] ||
                        ucMain.MapData1[this.Layer, row, col] == this.Patches[4] ||
                        ucMain.MapData1[this.Layer, row, col] == this.Patches[5] ||
                        ucMain.MapData1[this.Layer, row, col] == this.Patches[6] ||
                        ucMain.MapData1[this.Layer, row, col] == this.Patches[7] ||
                        ucMain.MapData1[this.Layer, row, col] == this.Patches[8] ||
                        ucMain.MapData1[this.Layer, row, col] == this.Patches[9] ||
                        ucMain.MapData1[this.Layer, row, col] == this.Point ||
                        ucMain.MapData1[this.Layer, row, col] == this.Vertical ||
                        ucMain.MapData1[this.Layer, row, col] == this.Horizontal
                        )
                    {
                        isNorthWest = true;
                    }
                }

                // 北
                bool isNorth = false;
                col = centerCol;
                row = centerRow - 1;
                if (-1 < row)
                {
                    if (ucMain.MapData1[this.Layer, row, col] == this.Point)
                    {
                        // ・ → │
                        ucMain.MapData1[this.Layer, row, col] = this.Vertical;
                        ucMain.MapData2[this.Layer, row, col] = MapchipImageType.Mapchip;
                        isNorth = true;
                    }
                    else if (ucMain.MapData1[this.Layer, row, col] == this.Horizontal)
                    {
                        // ─ → 
                        if (!isNorthEast)
                        {
                            // → ┐
                            ucMain.MapData1[this.Layer, row, col] = this.Patches[3];
                            ucMain.MapData2[this.Layer, row, col] = MapchipImageType.Mapchip;
                        }
                        else if (!isNorthWest)
                        {
                            // → ┌
                            ucMain.MapData1[this.Layer, row, col] = this.Patches[1];
                            ucMain.MapData2[this.Layer, row, col] = MapchipImageType.Mapchip;
                        }
                        else
                        {
                            // → ┬
                            ucMain.MapData1[this.Layer, row, col] = this.Patches[2];
                            ucMain.MapData2[this.Layer, row, col] = MapchipImageType.Mapchip;
                        }
                        isNorth = true;
                    }
                    else if (ucMain.MapData1[this.Layer, row, col] == this.Patches[7])
                    {
                        // └ → ├
                        ucMain.MapData1[this.Layer, row, col] = this.Patches[4];
                        ucMain.MapData2[this.Layer, row, col] = MapchipImageType.Mapchip;
                        isNorth = true;
                    }
                    else if (ucMain.MapData1[this.Layer, row, col] == this.Patches[8])
                    {
                        // ┴ → ┼
                        ucMain.MapData1[this.Layer, row, col] = this.Patches[5];
                        ucMain.MapData2[this.Layer, row, col] = MapchipImageType.Mapchip;
                        isNorth = true;
                    }
                    else if (ucMain.MapData1[this.Layer, row, col] == this.Patches[9])
                    {
                        // ┘ → ┤
                        ucMain.MapData1[this.Layer, row, col] = this.Patches[6];
                        ucMain.MapData2[this.Layer, row, col] = MapchipImageType.Mapchip;
                        isNorth = true;
                    }
                    else if (
                        ucMain.MapData1[this.Layer, row, col] == this.Patches[1] ||
                        ucMain.MapData1[this.Layer, row, col] == this.Patches[2] ||
                        ucMain.MapData1[this.Layer, row, col] == this.Patches[3] ||
                        ucMain.MapData1[this.Layer, row, col] == this.Patches[4] ||
                        ucMain.MapData1[this.Layer, row, col] == this.Patches[5] ||
                        ucMain.MapData1[this.Layer, row, col] == this.Patches[6] ||
                        ucMain.MapData1[this.Layer, row, col] == this.Vertical
                        )
                    {
                        isNorth = true;
                    }
                }

                // 東
                bool isEast = false;
                col = centerCol + 1;
                row = centerRow;
                if (col < UcMain.TABLE_COLS)
                {
                    if (ucMain.MapData1[this.Layer, row, col] == this.Point)
                    {
                        // ・ → ─
                        ucMain.MapData1[this.Layer, row, col] = this.Horizontal;
                        ucMain.MapData2[this.Layer, row, col] = MapchipImageType.Mapchip;
                        isEast = true;
                    }
                    else if (ucMain.MapData1[this.Layer, row, col] == this.Vertical)
                    {
                        // │ → 
                        if (!isNorthEast)
                        {
                            // → ┐
                            ucMain.MapData1[this.Layer, row, col] = this.Patches[3];
                            ucMain.MapData2[this.Layer, row, col] = MapchipImageType.Mapchip;
                        }
                        else if (!isSouthEast)
                        {
                            // → ┘
                            ucMain.MapData1[this.Layer, row, col] = this.Patches[9];
                            ucMain.MapData2[this.Layer, row, col] = MapchipImageType.Mapchip;
                        }
                        else
                        {
                            // → ┤
                            ucMain.MapData1[this.Layer, row, col] = this.Patches[6];
                            ucMain.MapData2[this.Layer, row, col] = MapchipImageType.Mapchip;
                        }
                        isEast = true;
                    }
                    else if (ucMain.MapData1[this.Layer, row, col] == this.Patches[1])
                    {
                        // ┌ → ┬
                        ucMain.MapData1[this.Layer, row, col] = this.Patches[2];
                        ucMain.MapData2[this.Layer, row, col] = MapchipImageType.Mapchip;
                        isEast = true;
                    }
                    else if (ucMain.MapData1[this.Layer, row, col] == this.Patches[4])
                    {
                        // ├ → ┼
                        ucMain.MapData1[this.Layer, row, col] = this.Patches[5];
                        ucMain.MapData2[this.Layer, row, col] = MapchipImageType.Mapchip;
                        isEast = true;
                    }
                    else if (ucMain.MapData1[this.Layer, row, col] == this.Patches[7])
                    {
                        // └ → ┴
                        ucMain.MapData1[this.Layer, row, col] = this.Patches[8];
                        ucMain.MapData2[this.Layer, row, col] = MapchipImageType.Mapchip;
                        isEast = true;
                    }
                    else if (
                        ucMain.MapData1[this.Layer, row, col] == this.Patches[2] ||
                        ucMain.MapData1[this.Layer, row, col] == this.Patches[3] ||
                        ucMain.MapData1[this.Layer, row, col] == this.Patches[5] ||
                        ucMain.MapData1[this.Layer, row, col] == this.Patches[6] ||
                        ucMain.MapData1[this.Layer, row, col] == this.Patches[8] ||
                        ucMain.MapData1[this.Layer, row, col] == this.Patches[9] ||
                        ucMain.MapData1[this.Layer, row, col] == this.Horizontal
                        )
                    {
                        isEast = true;
                    }
                }

                // 南
                bool isSouth = false;
                col = centerCol;
                row = centerRow + 1;
                if (row < UcMain.TABLE_ROWS)
                {
                    if (ucMain.MapData1[this.Layer, row, col] == this.Point)
                    {
                        // ・ → │
                        ucMain.MapData1[this.Layer, row, col] = this.Vertical;
                        ucMain.MapData2[this.Layer, row, col] = MapchipImageType.Mapchip;
                        isSouth = true;
                    }
                    else if (ucMain.MapData1[this.Layer, row, col] == this.Horizontal)
                    {
                        // ─ → 
                        if (!isSouthEast)
                        {
                            // → ┘
                            ucMain.MapData1[this.Layer, row, col] = this.Patches[9];
                            ucMain.MapData2[this.Layer, row, col] = MapchipImageType.Mapchip;
                        }
                        else if (!isSouthWest)
                        {
                            // → └
                            ucMain.MapData1[this.Layer, row, col] = this.Patches[7];
                            ucMain.MapData2[this.Layer, row, col] = MapchipImageType.Mapchip;
                        }
                        else
                        {
                            // → ┴
                            ucMain.MapData1[this.Layer, row, col] = this.Patches[8];
                            ucMain.MapData2[this.Layer, row, col] = MapchipImageType.Mapchip;
                        }
                        isSouth = true;
                    }
                    else if (ucMain.MapData1[this.Layer, row, col] == this.Patches[1])
                    {
                        // ┌ → ├
                        ucMain.MapData1[this.Layer, row, col] = this.Patches[4];
                        ucMain.MapData2[this.Layer, row, col] = MapchipImageType.Mapchip;
                        isSouth = true;
                    }
                    else if (ucMain.MapData1[this.Layer, row, col] == this.Patches[2])
                    {
                        // ┬ → ┼
                        ucMain.MapData1[this.Layer, row, col] = this.Patches[5];
                        ucMain.MapData2[this.Layer, row, col] = MapchipImageType.Mapchip;
                        isSouth = true;
                    }
                    else if (ucMain.MapData1[this.Layer, row, col] == this.Patches[3])
                    {
                        // ┐ → ┤
                        ucMain.MapData1[this.Layer, row, col] = this.Patches[6];
                        ucMain.MapData2[this.Layer, row, col] = MapchipImageType.Mapchip;
                        isSouth = true;
                    }
                    else if (
                        ucMain.MapData1[this.Layer, row, col] == this.Patches[4] ||
                        ucMain.MapData1[this.Layer, row, col] == this.Patches[5] ||
                        ucMain.MapData1[this.Layer, row, col] == this.Patches[6] ||
                        ucMain.MapData1[this.Layer, row, col] == this.Patches[7] ||
                        ucMain.MapData1[this.Layer, row, col] == this.Patches[8] ||
                        ucMain.MapData1[this.Layer, row, col] == this.Patches[9] ||
                        ucMain.MapData1[this.Layer, row, col] == this.Vertical
                        )
                    {
                        isSouth = true;
                    }
                }

                // 西
                bool isWest = false;
                col = centerCol - 1;
                row = centerRow;
                if (-1 < col)
                {
                    if (ucMain.MapData1[this.Layer, row, col] == this.Point)
                    {
                        // ・ → ─
                        ucMain.MapData1[this.Layer, row, col] = this.Horizontal;
                        ucMain.MapData2[this.Layer, row, col] = MapchipImageType.Mapchip;
                        isWest = true;
                    }
                    else if (ucMain.MapData1[this.Layer, row, col] == this.Vertical)
                    {
                        // │→
                        if (!isNorthWest)
                        {
                            // → ┌
                            ucMain.MapData1[this.Layer, row, col] = this.Patches[1];
                            ucMain.MapData2[this.Layer, row, col] = MapchipImageType.Mapchip;
                        }
                        else if (!isSouthWest)
                        {
                            // → └
                            ucMain.MapData1[this.Layer, row, col] = this.Patches[7];
                            ucMain.MapData2[this.Layer, row, col] = MapchipImageType.Mapchip;
                        }
                        else
                        {
                            // → ├
                            ucMain.MapData1[this.Layer, row, col] = this.Patches[4];
                            ucMain.MapData2[this.Layer, row, col] = MapchipImageType.Mapchip;
                        }
                        isWest = true;
                    }
                    else if (ucMain.MapData1[this.Layer, row, col] == this.Patches[3])
                    {
                        // ┐ → ┬
                        ucMain.MapData1[this.Layer, row, col] = this.Patches[2];
                        ucMain.MapData2[this.Layer, row, col] = MapchipImageType.Mapchip;
                        isWest = true;
                    }
                    else if (ucMain.MapData1[this.Layer, row, col] == this.Patches[6])
                    {
                        // ┤ → ┼
                        ucMain.MapData1[this.Layer, row, col] = this.Patches[5];
                        ucMain.MapData2[this.Layer, row, col] = MapchipImageType.Mapchip;
                        isWest = true;
                    }
                    else if (ucMain.MapData1[this.Layer, row, col] == this.Patches[9])
                    {
                        // ┘ → ┴
                        ucMain.MapData1[this.Layer, row, col] = this.Patches[8];
                        ucMain.MapData2[this.Layer, row, col] = MapchipImageType.Mapchip;
                        isWest = true;
                    }
                    else if (
                        ucMain.MapData1[this.Layer, row, col] == this.Patches[1] ||
                        ucMain.MapData1[this.Layer, row, col] == this.Patches[2] ||
                        ucMain.MapData1[this.Layer, row, col] == this.Patches[4] ||
                        ucMain.MapData1[this.Layer, row, col] == this.Patches[5] ||
                        ucMain.MapData1[this.Layer, row, col] == this.Patches[7] ||
                        ucMain.MapData1[this.Layer, row, col] == this.Patches[8] ||
                        ucMain.MapData1[this.Layer, row, col] == this.Horizontal
                        )
                    {
                        isWest = true;
                    }
                }

                // 中央
                if (isNorth && isEast && isSouth && isWest)
                {
                    // ┼
                    ucMain.MapData1[this.Layer, centerRow, centerCol] = this.Patches[5];
                    ucMain.MapData2[this.Layer, row, col] = MapchipImageType.Mapchip;
                }
                else if (isWest && isNorth && isEast)
                {
                    // ┴
                    ucMain.MapData1[this.Layer, centerRow, centerCol] = this.Patches[8];
                    ucMain.MapData2[this.Layer, row, col] = MapchipImageType.Mapchip;
                }
                else if (isNorth && isEast && isSouth)
                {
                    // ├
                    ucMain.MapData1[this.Layer, centerRow, centerCol] = this.Patches[4];
                    ucMain.MapData2[this.Layer, row, col] = MapchipImageType.Mapchip;
                }
                else if ( isEast && isSouth && isWest)
                {
                    // ┬
                    ucMain.MapData1[this.Layer, centerRow, centerCol] = this.Patches[2];
                    ucMain.MapData2[this.Layer, row, col] = MapchipImageType.Mapchip;
                }
                else if ( isSouth && isWest && isNorth)
                {
                    // ┤
                    ucMain.MapData1[this.Layer, centerRow, centerCol] = this.Patches[6];
                    ucMain.MapData2[this.Layer, row, col] = MapchipImageType.Mapchip;
                }
                else if (isNorth && isEast)
                {
                    // └
                    ucMain.MapData1[this.Layer, centerRow, centerCol] = this.Patches[7];
                    ucMain.MapData2[this.Layer, row, col] = MapchipImageType.Mapchip;
                }
                else if (isEast && isSouth)
                {
                    // ┌
                    ucMain.MapData1[this.Layer, centerRow, centerCol] = this.Patches[1];
                    ucMain.MapData2[this.Layer, row, col] = MapchipImageType.Mapchip;
                }
                else if (isSouth && isWest)
                {
                    // ┐
                    ucMain.MapData1[this.Layer, centerRow, centerCol] = this.Patches[3];
                    ucMain.MapData2[this.Layer, row, col] = MapchipImageType.Mapchip;
                }
                else if (isWest && isNorth)
                {
                    // ┘
                    ucMain.MapData1[this.Layer, centerRow, centerCol] = this.Patches[9];
                    ucMain.MapData2[this.Layer, row, col] = MapchipImageType.Mapchip;
                }
                else if (isNorth || isSouth)
                {
                    // │
                    ucMain.MapData1[this.Layer, centerRow, centerCol] = this.Vertical;
                    ucMain.MapData2[this.Layer, row, col] = MapchipImageType.Mapchip;
                }
                else if (isEast || isWest)
                {
                    // ─
                    ucMain.MapData1[this.Layer, centerRow, centerCol] = this.Horizontal;
                    ucMain.MapData2[this.Layer, row, col] = MapchipImageType.Mapchip;
                }
                else
                {
                    // ・
                    ucMain.MapData1[this.Layer, centerRow, centerCol] = this.Point;
                    ucMain.MapData2[this.Layer, row, col] = MapchipImageType.Mapchip;
                }
            }
        }

        /// <summary>
        /// 直線状にマップチップを連続配置するぜ☆（＾▽＾）
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
                        if (pCol < UcMain.TABLE_COLS && pRow < UcMain.TABLE_ROWS)
                        {
                            this.UpdateNeighborhood(ucMain //this.MapImg
                                , pRow, pCol);
                            //this.MapImg[1, pRow, pCol] = brushRailway.Patches[5];// MapchipCrop.su砂_田5;

                            if (pRowPrev != pRow && pRowPrev < UcMain.TABLE_ROWS)
                            {
                                // シムシティの線路みたいな直線のつなげ方をするぜ☆（＾～＾）
                                this.UpdateNeighborhood(ucMain //this.MapImg
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
                        if (pCol < UcMain.TABLE_COLS && pRow < UcMain.TABLE_ROWS)
                        {
                            this.UpdateNeighborhood(ucMain //this.MapImg
                                , pRow, pCol);
                            //this.MapImg[1, pRow, pCol] = brushRailway.Patches[5]; //MapchipCrop.su砂_田5;

                            if (pRowPrev != pRow && pRowPrev < UcMain.TABLE_ROWS)
                            {
                                // シムシティの線路みたいな直線のつなげ方をするぜ☆（＾～＾）
                                this.UpdateNeighborhood(ucMain //this.MapImg
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
                        if (pCol < UcMain.TABLE_COLS && pRow < UcMain.TABLE_ROWS)
                        {
                            this.UpdateNeighborhood(ucMain //this.MapImg
                                , pRow, pCol);
                            //this.MapImg[1, pRow, pCol] = brushRailway.Patches[5]; //MapchipCrop.su砂_田5;

                            if (pColPrev != pCol && pColPrev < UcMain.TABLE_COLS)
                            {
                                // シムシティの線路みたいな直線のつなげ方をするぜ☆（＾～＾）
                                this.UpdateNeighborhood(ucMain //this.MapImg
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
                        if (pCol < UcMain.TABLE_COLS && pRow < UcMain.TABLE_ROWS)
                        {
                            this.UpdateNeighborhood(ucMain //this.MapImg
                                , pRow, pCol);
                            //this.MapImg[1, pRow, pCol] = brushRailway.Patches[5]; //MapchipCrop.su砂_田5;

                            if (pColPrev != pCol && pColPrev < UcMain.TABLE_COLS)
                            {
                                // シムシティの線路みたいな直線のつなげ方をするぜ☆（＾～＾）
                                this.UpdateNeighborhood(ucMain //this.MapImg
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
    }
}

using Grayscale.A500_Kifucity.B500_Kifucity.C___500_MapProp_;

namespace Grayscale.A500_Kifucity.B500_Kifucity.C500____MapProp_
{
    /// <summary>
    /// 線路状のマップチップを置くブラシ☆
    /// </summary>
    public class MapchipRailwayBrushImpl : MapchipRailwayBrush
    {
        public MapchipRailwayBrushImpl(
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
        /// 5近傍のマップチップの置き換え
        /// </summary>
        public void Update5Neighborhood(UcMain ucMain //MapchipCrop[,,] map
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
                        ucMain.MapImg[1, row, col] == this.Patches[1] ||
                        ucMain.MapImg[1, row, col] == this.Patches[2] ||
                        ucMain.MapImg[1, row, col] == this.Patches[3] ||
                        ucMain.MapImg[1, row, col] == this.Patches[4] ||
                        ucMain.MapImg[1, row, col] == this.Patches[5] ||
                        ucMain.MapImg[1, row, col] == this.Patches[6] ||
                        ucMain.MapImg[1, row, col] == this.Patches[7] ||
                        ucMain.MapImg[1, row, col] == this.Patches[8] ||
                        ucMain.MapImg[1, row, col] == this.Patches[9] ||
                        ucMain.MapImg[1, row, col] == this.Point ||
                        ucMain.MapImg[1, row, col] == this.Vertical ||
                        ucMain.MapImg[1, row, col] == this.Horizontal
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
                        ucMain.MapImg[1, row, col] == this.Patches[1] ||
                        ucMain.MapImg[1, row, col] == this.Patches[2] ||
                        ucMain.MapImg[1, row, col] == this.Patches[3] ||
                        ucMain.MapImg[1, row, col] == this.Patches[4] ||
                        ucMain.MapImg[1, row, col] == this.Patches[5] ||
                        ucMain.MapImg[1, row, col] == this.Patches[6] ||
                        ucMain.MapImg[1, row, col] == this.Patches[7] ||
                        ucMain.MapImg[1, row, col] == this.Patches[8] ||
                        ucMain.MapImg[1, row, col] == this.Patches[9] ||
                        ucMain.MapImg[1, row, col] == this.Point ||
                        ucMain.MapImg[1, row, col] == this.Vertical ||
                        ucMain.MapImg[1, row, col] == this.Horizontal
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
                        ucMain.MapImg[1, row, col] == this.Patches[1] ||
                        ucMain.MapImg[1, row, col] == this.Patches[2] ||
                        ucMain.MapImg[1, row, col] == this.Patches[3] ||
                        ucMain.MapImg[1, row, col] == this.Patches[4] ||
                        ucMain.MapImg[1, row, col] == this.Patches[5] ||
                        ucMain.MapImg[1, row, col] == this.Patches[6] ||
                        ucMain.MapImg[1, row, col] == this.Patches[7] ||
                        ucMain.MapImg[1, row, col] == this.Patches[8] ||
                        ucMain.MapImg[1, row, col] == this.Patches[9] ||
                        ucMain.MapImg[1, row, col] == this.Point ||
                        ucMain.MapImg[1, row, col] == this.Vertical ||
                        ucMain.MapImg[1, row, col] == this.Horizontal
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
                        ucMain.MapImg[1, row, col] == this.Patches[1] ||
                        ucMain.MapImg[1, row, col] == this.Patches[2] ||
                        ucMain.MapImg[1, row, col] == this.Patches[3] ||
                        ucMain.MapImg[1, row, col] == this.Patches[4] ||
                        ucMain.MapImg[1, row, col] == this.Patches[5] ||
                        ucMain.MapImg[1, row, col] == this.Patches[6] ||
                        ucMain.MapImg[1, row, col] == this.Patches[7] ||
                        ucMain.MapImg[1, row, col] == this.Patches[8] ||
                        ucMain.MapImg[1, row, col] == this.Patches[9] ||
                        ucMain.MapImg[1, row, col] == this.Point ||
                        ucMain.MapImg[1, row, col] == this.Vertical ||
                        ucMain.MapImg[1, row, col] == this.Horizontal
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
                    if (ucMain.MapImg[1, row, col] == this.Point)
                    {
                        // ・ → │
                        ucMain.MapImg[1, row, col] = this.Vertical;
                        isNorth = true;
                    }
                    else if (ucMain.MapImg[1, row, col] == this.Horizontal)
                    {
                        // ─ → 
                        if (!isNorthEast)
                        {
                            // → ┐
                            ucMain.MapImg[1, row, col] = this.Patches[3];
                        }
                        else if (!isNorthWest)
                        {
                            // → ┌
                            ucMain.MapImg[1, row, col] = this.Patches[1];
                        }
                        else
                        {
                            // → ┬
                            ucMain.MapImg[1, row, col] = this.Patches[2];
                        }
                        isNorth = true;
                    }
                    else if (ucMain.MapImg[1, row, col] == this.Patches[7])
                    {
                        // └ → ├
                        ucMain.MapImg[1, row, col] = this.Patches[4];
                        isNorth = true;
                    }
                    else if (ucMain.MapImg[1, row, col] == this.Patches[8])
                    {
                        // ┴ → ┼
                        ucMain.MapImg[1, row, col] = this.Patches[5];
                        isNorth = true;
                    }
                    else if (ucMain.MapImg[1, row, col] == this.Patches[9])
                    {
                        // ┘ → ┤
                        ucMain.MapImg[1, row, col] = this.Patches[6];
                        isNorth = true;
                    }
                    else if (
                        ucMain.MapImg[1, row, col] == this.Patches[1] ||
                        ucMain.MapImg[1, row, col] == this.Patches[2] ||
                        ucMain.MapImg[1, row, col] == this.Patches[3] ||
                        ucMain.MapImg[1, row, col] == this.Patches[4] ||
                        ucMain.MapImg[1, row, col] == this.Patches[5] ||
                        ucMain.MapImg[1, row, col] == this.Patches[6] ||
                        ucMain.MapImg[1, row, col] == this.Vertical
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
                    if (ucMain.MapImg[1, row, col] == this.Point)
                    {
                        // ・ → ─
                        ucMain.MapImg[1, row, col] = this.Horizontal;
                        isEast = true;
                    }
                    else if (ucMain.MapImg[1, row, col] == this.Vertical)
                    {
                        // │ → 
                        if (!isNorthEast)
                        {
                            // → ┐
                            ucMain.MapImg[1, row, col] = this.Patches[3];
                        }
                        else if (!isSouthEast)
                        {
                            // → ┘
                            ucMain.MapImg[1, row, col] = this.Patches[9];
                        }
                        else
                        {
                            // → ┤
                            ucMain.MapImg[1, row, col] = this.Patches[6];
                        }
                        isEast = true;
                    }
                    else if (ucMain.MapImg[1, row, col] == this.Patches[1])
                    {
                        // ┌ → ┬
                        ucMain.MapImg[1, row, col] = this.Patches[2];
                        isEast = true;
                    }
                    else if (ucMain.MapImg[1, row, col] == this.Patches[4])
                    {
                        // ├ → ┼
                        ucMain.MapImg[1, row, col] = this.Patches[5];
                        isEast = true;
                    }
                    else if (ucMain.MapImg[1, row, col] == this.Patches[7])
                    {
                        // └ → ┴
                        ucMain.MapImg[1, row, col] = this.Patches[8];
                        isEast = true;
                    }
                    else if (
                        ucMain.MapImg[1, row, col] == this.Patches[2] ||
                        ucMain.MapImg[1, row, col] == this.Patches[3] ||
                        ucMain.MapImg[1, row, col] == this.Patches[5] ||
                        ucMain.MapImg[1, row, col] == this.Patches[6] ||
                        ucMain.MapImg[1, row, col] == this.Patches[8] ||
                        ucMain.MapImg[1, row, col] == this.Patches[9] ||
                        ucMain.MapImg[1, row, col] == this.Horizontal
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
                    if (ucMain.MapImg[1, row, col] == this.Point)
                    {
                        // ・ → │
                        ucMain.MapImg[1, row, col] = this.Vertical;
                        isSouth = true;
                    }
                    else if (ucMain.MapImg[1, row, col] == this.Horizontal)
                    {
                        // ─ → 
                        if (!isSouthEast)
                        {
                            // → ┘
                            ucMain.MapImg[1, row, col] = this.Patches[9];
                        }
                        else if (!isSouthWest)
                        {
                            // → └
                            ucMain.MapImg[1, row, col] = this.Patches[7];
                        }
                        else
                        {
                            // → ┴
                            ucMain.MapImg[1, row, col] = this.Patches[8];
                        }
                        isSouth = true;
                    }
                    else if (ucMain.MapImg[1, row, col] == this.Patches[1])
                    {
                        // ┌ → ├
                        ucMain.MapImg[1, row, col] = this.Patches[4];
                        isSouth = true;
                    }
                    else if (ucMain.MapImg[1, row, col] == this.Patches[2])
                    {
                        // ┬ → ┼
                        ucMain.MapImg[1, row, col] = this.Patches[5];
                        isSouth = true;
                    }
                    else if (ucMain.MapImg[1, row, col] == this.Patches[3])
                    {
                        // ┐ → ┤
                        ucMain.MapImg[1, row, col] = this.Patches[6];
                        isSouth = true;
                    }
                    else if (
                        ucMain.MapImg[1, row, col] == this.Patches[4] ||
                        ucMain.MapImg[1, row, col] == this.Patches[5] ||
                        ucMain.MapImg[1, row, col] == this.Patches[6] ||
                        ucMain.MapImg[1, row, col] == this.Patches[7] ||
                        ucMain.MapImg[1, row, col] == this.Patches[8] ||
                        ucMain.MapImg[1, row, col] == this.Patches[9] ||
                        ucMain.MapImg[1, row, col] == this.Vertical
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
                    if (ucMain.MapImg[1, row, col] == this.Point)
                    {
                        // ・ → ─
                        ucMain.MapImg[1, row, col] = this.Horizontal;
                        isWest = true;
                    }
                    else if (ucMain.MapImg[1, row, col] == this.Vertical)
                    {
                        // │→
                        if (!isNorthWest)
                        {
                            // → ┌
                            ucMain.MapImg[1, row, col] = this.Patches[1];
                        }
                        else if (!isSouthWest)
                        {
                            // → └
                            ucMain.MapImg[1, row, col] = this.Patches[7];
                        }
                        else
                        {
                            // → ├
                            ucMain.MapImg[1, row, col] = this.Patches[4];
                        }
                        isWest = true;
                    }
                    else if (ucMain.MapImg[1, row, col] == this.Patches[3])
                    {
                        // ┐ → ┬
                        ucMain.MapImg[1, row, col] = this.Patches[2];
                        isWest = true;
                    }
                    else if (ucMain.MapImg[1, row, col] == this.Patches[6])
                    {
                        // ┤ → ┼
                        ucMain.MapImg[1, row, col] = this.Patches[5];
                        isWest = true;
                    }
                    else if (ucMain.MapImg[1, row, col] == this.Patches[9])
                    {
                        // ┘ → ┴
                        ucMain.MapImg[1, row, col] = this.Patches[8];
                        isWest = true;
                    }
                    else if (
                        ucMain.MapImg[1, row, col] == this.Patches[1] ||
                        ucMain.MapImg[1, row, col] == this.Patches[2] ||
                        ucMain.MapImg[1, row, col] == this.Patches[4] ||
                        ucMain.MapImg[1, row, col] == this.Patches[5] ||
                        ucMain.MapImg[1, row, col] == this.Patches[7] ||
                        ucMain.MapImg[1, row, col] == this.Patches[8] ||
                        ucMain.MapImg[1, row, col] == this.Horizontal
                        )
                    {
                        isWest = true;
                    }
                }

                // 中央
                if (isNorth && isEast && isSouth && isWest)
                {
                    // ┼
                    ucMain.MapImg[1, centerRow, centerCol] = this.Patches[5];
                }
                else if (isWest && isNorth && isEast)
                {
                    // ┴
                    ucMain.MapImg[1, centerRow, centerCol] = this.Patches[8];
                }
                else if (isNorth && isEast && isSouth)
                {
                    // ├
                    ucMain.MapImg[1, centerRow, centerCol] = this.Patches[4];
                }
                else if ( isEast && isSouth && isWest)
                {
                    // ┬
                    ucMain.MapImg[1, centerRow, centerCol] = this.Patches[2];
                }
                else if ( isSouth && isWest && isNorth)
                {
                    // ┤
                    ucMain.MapImg[1, centerRow, centerCol] = this.Patches[6];
                }
                else if (isNorth && isEast)
                {
                    // └
                    ucMain.MapImg[1, centerRow, centerCol] = this.Patches[7];
                }
                else if (isEast && isSouth)
                {
                    // ┌
                    ucMain.MapImg[1, centerRow, centerCol] = this.Patches[1];
                }
                else if (isSouth && isWest)
                {
                    // ┐
                    ucMain.MapImg[1, centerRow, centerCol] = this.Patches[3];
                }
                else if (isWest && isNorth)
                {
                    // ┘
                    ucMain.MapImg[1, centerRow, centerCol] = this.Patches[9];
                }
                else if (isNorth || isSouth)
                {
                    // │
                    ucMain.MapImg[1, centerRow, centerCol] = this.Vertical;
                }
                else if (isEast || isWest)
                {
                    // ─
                    ucMain.MapImg[1, centerRow, centerCol] = this.Horizontal;
                }
                else
                {
                    // ・
                    ucMain.MapImg[1, centerRow, centerCol] = this.Point;
                }
            }
        }
    }
}

using Grayscale.A500_Kifucity.B500_Kifucity.C___400_Image___;
using Grayscale.A500_Kifucity.B500_Kifucity.C___450_Position;
using Grayscale.A500_Kifucity.B500_Kifucity.C___500_MapProp_;
using Grayscale.A500_Kifucity.B500_Kifucity.C450____Position;
using System;
using System.Drawing;

namespace Grayscale.A500_Kifucity.B500_Kifucity.C500____MapProp_
{
    /// <summary>
    /// 線路状のマップチップを置くブラシ☆
    /// </summary>
    public class MapchipRailwayBrushImpl : MapchipRailwayBrush
    {
        public MapchipRailwayBrushImpl(
            int layer,
            ImageType imageType,
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
            this.ImageType = imageType;
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
        public ImageType ImageType { get; set; }

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
            if (-1 < centerCol && centerCol < ucMain.City.TableCols &&
                -1 < centerRow && centerRow < ucMain.City.TableRows)
            {
                int col;
                int row;

                // 北東
                bool isNorthEast = false;
                col = centerCol + 1;
                row = centerRow - 1;
                if (col < ucMain.City.TableCols && -1 < row)
                {
                    if (
                        ucMain.City.Cells[this.Layer, row, col].MapchipCrop == this.Patches[1] ||
                        ucMain.City.Cells[this.Layer, row, col].MapchipCrop == this.Patches[2] ||
                        ucMain.City.Cells[this.Layer, row, col].MapchipCrop == this.Patches[3] ||
                        ucMain.City.Cells[this.Layer, row, col].MapchipCrop == this.Patches[4] ||
                        ucMain.City.Cells[this.Layer, row, col].MapchipCrop == this.Patches[5] ||
                        ucMain.City.Cells[this.Layer, row, col].MapchipCrop == this.Patches[6] ||
                        ucMain.City.Cells[this.Layer, row, col].MapchipCrop == this.Patches[7] ||
                        ucMain.City.Cells[this.Layer, row, col].MapchipCrop == this.Patches[8] ||
                        ucMain.City.Cells[this.Layer, row, col].MapchipCrop == this.Patches[9] ||
                        ucMain.City.Cells[this.Layer, row, col].MapchipCrop == this.Point ||
                        ucMain.City.Cells[this.Layer, row, col].MapchipCrop == this.Vertical ||
                        ucMain.City.Cells[this.Layer, row, col].MapchipCrop == this.Horizontal
                        )
                    {
                        isNorthEast = true;
                    }
                }

                // 南東
                bool isSouthEast = false;
                col = centerCol + 1;
                row = centerRow + 1;
                if (col < ucMain.City.TableCols && row < ucMain.City.TableRows)
                {
                    if (
                        ucMain.City.Cells[this.Layer, row, col].MapchipCrop == this.Patches[1] ||
                        ucMain.City.Cells[this.Layer, row, col].MapchipCrop == this.Patches[2] ||
                        ucMain.City.Cells[this.Layer, row, col].MapchipCrop == this.Patches[3] ||
                        ucMain.City.Cells[this.Layer, row, col].MapchipCrop == this.Patches[4] ||
                        ucMain.City.Cells[this.Layer, row, col].MapchipCrop == this.Patches[5] ||
                        ucMain.City.Cells[this.Layer, row, col].MapchipCrop == this.Patches[6] ||
                        ucMain.City.Cells[this.Layer, row, col].MapchipCrop == this.Patches[7] ||
                        ucMain.City.Cells[this.Layer, row, col].MapchipCrop == this.Patches[8] ||
                        ucMain.City.Cells[this.Layer, row, col].MapchipCrop == this.Patches[9] ||
                        ucMain.City.Cells[this.Layer, row, col].MapchipCrop == this.Point ||
                        ucMain.City.Cells[this.Layer, row, col].MapchipCrop == this.Vertical ||
                        ucMain.City.Cells[this.Layer, row, col].MapchipCrop == this.Horizontal
                        )
                    {
                        isSouthEast = true;
                    }
                }

                // 南西
                bool isSouthWest = false;
                col = centerCol - 1;
                row = centerRow + 1;
                if (-1 < col && row < ucMain.City.TableRows)
                {
                    if (
                        ucMain.City.Cells[this.Layer, row, col].MapchipCrop == this.Patches[1] ||
                        ucMain.City.Cells[this.Layer, row, col].MapchipCrop == this.Patches[2] ||
                        ucMain.City.Cells[this.Layer, row, col].MapchipCrop == this.Patches[3] ||
                        ucMain.City.Cells[this.Layer, row, col].MapchipCrop == this.Patches[4] ||
                        ucMain.City.Cells[this.Layer, row, col].MapchipCrop == this.Patches[5] ||
                        ucMain.City.Cells[this.Layer, row, col].MapchipCrop == this.Patches[6] ||
                        ucMain.City.Cells[this.Layer, row, col].MapchipCrop == this.Patches[7] ||
                        ucMain.City.Cells[this.Layer, row, col].MapchipCrop == this.Patches[8] ||
                        ucMain.City.Cells[this.Layer, row, col].MapchipCrop == this.Patches[9] ||
                        ucMain.City.Cells[this.Layer, row, col].MapchipCrop == this.Point ||
                        ucMain.City.Cells[this.Layer, row, col].MapchipCrop == this.Vertical ||
                        ucMain.City.Cells[this.Layer, row, col].MapchipCrop == this.Horizontal
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
                        ucMain.City.Cells[this.Layer, row, col].MapchipCrop == this.Patches[1] ||
                        ucMain.City.Cells[this.Layer, row, col].MapchipCrop == this.Patches[2] ||
                        ucMain.City.Cells[this.Layer, row, col].MapchipCrop == this.Patches[3] ||
                        ucMain.City.Cells[this.Layer, row, col].MapchipCrop == this.Patches[4] ||
                        ucMain.City.Cells[this.Layer, row, col].MapchipCrop == this.Patches[5] ||
                        ucMain.City.Cells[this.Layer, row, col].MapchipCrop == this.Patches[6] ||
                        ucMain.City.Cells[this.Layer, row, col].MapchipCrop == this.Patches[7] ||
                        ucMain.City.Cells[this.Layer, row, col].MapchipCrop == this.Patches[8] ||
                        ucMain.City.Cells[this.Layer, row, col].MapchipCrop == this.Patches[9] ||
                        ucMain.City.Cells[this.Layer, row, col].MapchipCrop == this.Point ||
                        ucMain.City.Cells[this.Layer, row, col].MapchipCrop == this.Vertical ||
                        ucMain.City.Cells[this.Layer, row, col].MapchipCrop == this.Horizontal
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
                    if (ucMain.City.Cells[this.Layer, row, col].MapchipCrop == this.Point)
                    {
                        // ・ → │
                        ucMain.City.Cells[this.Layer, row, col].MapchipCrop = this.Vertical;
                        ucMain.City.Cells[this.Layer, row, col].ImageType = this.ImageType;
                        isNorth = true;
                    }
                    else if (ucMain.City.Cells[this.Layer, row, col].MapchipCrop == this.Horizontal)
                    {
                        // ─ → 
                        if (!isNorthEast)
                        {
                            // → ┐
                            ucMain.City.Cells[this.Layer, row, col].MapchipCrop = this.Patches[3];
                            ucMain.City.Cells[this.Layer, row, col].ImageType = this.ImageType;
                        }
                        else if (!isNorthWest)
                        {
                            // → ┌
                            ucMain.City.Cells[this.Layer, row, col].MapchipCrop = this.Patches[1];
                            ucMain.City.Cells[this.Layer, row, col].ImageType = this.ImageType;
                        }
                        else
                        {
                            // → ┬
                            ucMain.City.Cells[this.Layer, row, col].MapchipCrop = this.Patches[2];
                            ucMain.City.Cells[this.Layer, row, col].ImageType = this.ImageType;
                        }
                        isNorth = true;
                    }
                    else if (ucMain.City.Cells[this.Layer, row, col].MapchipCrop == this.Patches[7])
                    {
                        // └ → ├
                        ucMain.City.Cells[this.Layer, row, col].MapchipCrop = this.Patches[4];
                        ucMain.City.Cells[this.Layer, row, col].ImageType = this.ImageType;
                        isNorth = true;
                    }
                    else if (ucMain.City.Cells[this.Layer, row, col].MapchipCrop == this.Patches[8])
                    {
                        // ┴ → ┼
                        ucMain.City.Cells[this.Layer, row, col].MapchipCrop = this.Patches[5];
                        ucMain.City.Cells[this.Layer, row, col].ImageType = this.ImageType;
                        isNorth = true;
                    }
                    else if (ucMain.City.Cells[this.Layer, row, col].MapchipCrop == this.Patches[9])
                    {
                        // ┘ → ┤
                        ucMain.City.Cells[this.Layer, row, col].MapchipCrop = this.Patches[6];
                        ucMain.City.Cells[this.Layer, row, col].ImageType = this.ImageType;
                        isNorth = true;
                    }
                    else if (
                        ucMain.City.Cells[this.Layer, row, col].MapchipCrop == this.Patches[1] ||
                        ucMain.City.Cells[this.Layer, row, col].MapchipCrop == this.Patches[2] ||
                        ucMain.City.Cells[this.Layer, row, col].MapchipCrop == this.Patches[3] ||
                        ucMain.City.Cells[this.Layer, row, col].MapchipCrop == this.Patches[4] ||
                        ucMain.City.Cells[this.Layer, row, col].MapchipCrop == this.Patches[5] ||
                        ucMain.City.Cells[this.Layer, row, col].MapchipCrop == this.Patches[6] ||
                        ucMain.City.Cells[this.Layer, row, col].MapchipCrop == this.Vertical
                        )
                    {
                        isNorth = true;
                    }
                }

                // 東
                bool isEast = false;
                col = centerCol + 1;
                row = centerRow;
                if (col < ucMain.City.TableCols)
                {
                    if (ucMain.City.Cells[this.Layer, row, col].MapchipCrop == this.Point)
                    {
                        // ・ → ─
                        ucMain.City.Cells[this.Layer, row, col].MapchipCrop = this.Horizontal;
                        ucMain.City.Cells[this.Layer, row, col].ImageType = this.ImageType;
                        isEast = true;
                    }
                    else if (ucMain.City.Cells[this.Layer, row, col].MapchipCrop == this.Vertical)
                    {
                        // │ → 
                        if (!isNorthEast)
                        {
                            // → ┐
                            ucMain.City.Cells[this.Layer, row, col].MapchipCrop = this.Patches[3];
                            ucMain.City.Cells[this.Layer, row, col].ImageType = this.ImageType;
                        }
                        else if (!isSouthEast)
                        {
                            // → ┘
                            ucMain.City.Cells[this.Layer, row, col].MapchipCrop = this.Patches[9];
                            ucMain.City.Cells[this.Layer, row, col].ImageType = this.ImageType;
                        }
                        else
                        {
                            // → ┤
                            ucMain.City.Cells[this.Layer, row, col].MapchipCrop = this.Patches[6];
                            ucMain.City.Cells[this.Layer, row, col].ImageType = this.ImageType;
                        }
                        isEast = true;
                    }
                    else if (ucMain.City.Cells[this.Layer, row, col].MapchipCrop == this.Patches[1])
                    {
                        // ┌ → ┬
                        ucMain.City.Cells[this.Layer, row, col].MapchipCrop = this.Patches[2];
                        ucMain.City.Cells[this.Layer, row, col].ImageType = this.ImageType;
                        isEast = true;
                    }
                    else if (ucMain.City.Cells[this.Layer, row, col].MapchipCrop == this.Patches[4])
                    {
                        // ├ → ┼
                        ucMain.City.Cells[this.Layer, row, col].MapchipCrop = this.Patches[5];
                        ucMain.City.Cells[this.Layer, row, col].ImageType = this.ImageType;
                        isEast = true;
                    }
                    else if (ucMain.City.Cells[this.Layer, row, col].MapchipCrop == this.Patches[7])
                    {
                        // └ → ┴
                        ucMain.City.Cells[this.Layer, row, col].MapchipCrop = this.Patches[8];
                        ucMain.City.Cells[this.Layer, row, col].ImageType = this.ImageType;
                        isEast = true;
                    }
                    else if (
                        ucMain.City.Cells[this.Layer, row, col].MapchipCrop == this.Patches[2] ||
                        ucMain.City.Cells[this.Layer, row, col].MapchipCrop == this.Patches[3] ||
                        ucMain.City.Cells[this.Layer, row, col].MapchipCrop == this.Patches[5] ||
                        ucMain.City.Cells[this.Layer, row, col].MapchipCrop == this.Patches[6] ||
                        ucMain.City.Cells[this.Layer, row, col].MapchipCrop == this.Patches[8] ||
                        ucMain.City.Cells[this.Layer, row, col].MapchipCrop == this.Patches[9] ||
                        ucMain.City.Cells[this.Layer, row, col].MapchipCrop == this.Horizontal
                        )
                    {
                        isEast = true;
                    }
                }

                // 南
                bool isSouth = false;
                col = centerCol;
                row = centerRow + 1;
                if (row < ucMain.City.TableRows)
                {
                    if (ucMain.City.Cells[this.Layer, row, col].MapchipCrop == this.Point)
                    {
                        // ・ → │
                        ucMain.City.Cells[this.Layer, row, col].MapchipCrop = this.Vertical;
                        ucMain.City.Cells[this.Layer, row, col].ImageType = this.ImageType;
                        isSouth = true;
                    }
                    else if (ucMain.City.Cells[this.Layer, row, col].MapchipCrop == this.Horizontal)
                    {
                        // ─ → 
                        if (!isSouthEast)
                        {
                            // → ┘
                            ucMain.City.Cells[this.Layer, row, col].MapchipCrop = this.Patches[9];
                            ucMain.City.Cells[this.Layer, row, col].ImageType = this.ImageType;
                        }
                        else if (!isSouthWest)
                        {
                            // → └
                            ucMain.City.Cells[this.Layer, row, col].MapchipCrop = this.Patches[7];
                            ucMain.City.Cells[this.Layer, row, col].ImageType = this.ImageType;
                        }
                        else
                        {
                            // → ┴
                            ucMain.City.Cells[this.Layer, row, col].MapchipCrop = this.Patches[8];
                            ucMain.City.Cells[this.Layer, row, col].ImageType = this.ImageType;
                        }
                        isSouth = true;
                    }
                    else if (ucMain.City.Cells[this.Layer, row, col].MapchipCrop == this.Patches[1])
                    {
                        // ┌ → ├
                        ucMain.City.Cells[this.Layer, row, col].MapchipCrop = this.Patches[4];
                        ucMain.City.Cells[this.Layer, row, col].ImageType = this.ImageType;
                        isSouth = true;
                    }
                    else if (ucMain.City.Cells[this.Layer, row, col].MapchipCrop == this.Patches[2])
                    {
                        // ┬ → ┼
                        ucMain.City.Cells[this.Layer, row, col].MapchipCrop = this.Patches[5];
                        ucMain.City.Cells[this.Layer, row, col].ImageType = this.ImageType;
                        isSouth = true;
                    }
                    else if (ucMain.City.Cells[this.Layer, row, col].MapchipCrop == this.Patches[3])
                    {
                        // ┐ → ┤
                        ucMain.City.Cells[this.Layer, row, col].MapchipCrop = this.Patches[6];
                        ucMain.City.Cells[this.Layer, row, col].ImageType = this.ImageType;
                        isSouth = true;
                    }
                    else if (
                        ucMain.City.Cells[this.Layer, row, col].MapchipCrop == this.Patches[4] ||
                        ucMain.City.Cells[this.Layer, row, col].MapchipCrop == this.Patches[5] ||
                        ucMain.City.Cells[this.Layer, row, col].MapchipCrop == this.Patches[6] ||
                        ucMain.City.Cells[this.Layer, row, col].MapchipCrop == this.Patches[7] ||
                        ucMain.City.Cells[this.Layer, row, col].MapchipCrop == this.Patches[8] ||
                        ucMain.City.Cells[this.Layer, row, col].MapchipCrop == this.Patches[9] ||
                        ucMain.City.Cells[this.Layer, row, col].MapchipCrop == this.Vertical
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
                    if (ucMain.City.Cells[this.Layer, row, col].MapchipCrop == this.Point)
                    {
                        // ・ → ─
                        ucMain.City.Cells[this.Layer, row, col].MapchipCrop = this.Horizontal;
                        ucMain.City.Cells[this.Layer, row, col].ImageType = this.ImageType;
                        isWest = true;
                    }
                    else if (ucMain.City.Cells[this.Layer, row, col].MapchipCrop == this.Vertical)
                    {
                        // │→
                        if (!isNorthWest)
                        {
                            // → ┌
                            ucMain.City.Cells[this.Layer, row, col].MapchipCrop = this.Patches[1];
                            ucMain.City.Cells[this.Layer, row, col].ImageType = this.ImageType;
                        }
                        else if (!isSouthWest)
                        {
                            // → └
                            ucMain.City.Cells[this.Layer, row, col].MapchipCrop = this.Patches[7];
                            ucMain.City.Cells[this.Layer, row, col].ImageType = this.ImageType;
                        }
                        else
                        {
                            // → ├
                            ucMain.City.Cells[this.Layer, row, col].MapchipCrop = this.Patches[4];
                            ucMain.City.Cells[this.Layer, row, col].ImageType = this.ImageType;
                        }
                        isWest = true;
                    }
                    else if (ucMain.City.Cells[this.Layer, row, col].MapchipCrop == this.Patches[3])
                    {
                        // ┐ → ┬
                        ucMain.City.Cells[this.Layer, row, col].MapchipCrop = this.Patches[2];
                        ucMain.City.Cells[this.Layer, row, col].ImageType = this.ImageType;
                        isWest = true;
                    }
                    else if (ucMain.City.Cells[this.Layer, row, col].MapchipCrop == this.Patches[6])
                    {
                        // ┤ → ┼
                        ucMain.City.Cells[this.Layer, row, col].MapchipCrop = this.Patches[5];
                        ucMain.City.Cells[this.Layer, row, col].ImageType = this.ImageType;
                        isWest = true;
                    }
                    else if (ucMain.City.Cells[this.Layer, row, col].MapchipCrop == this.Patches[9])
                    {
                        // ┘ → ┴
                        ucMain.City.Cells[this.Layer, row, col].MapchipCrop = this.Patches[8];
                        ucMain.City.Cells[this.Layer, row, col].ImageType = this.ImageType;
                        isWest = true;
                    }
                    else if (
                        ucMain.City.Cells[this.Layer, row, col].MapchipCrop == this.Patches[1] ||
                        ucMain.City.Cells[this.Layer, row, col].MapchipCrop == this.Patches[2] ||
                        ucMain.City.Cells[this.Layer, row, col].MapchipCrop == this.Patches[4] ||
                        ucMain.City.Cells[this.Layer, row, col].MapchipCrop == this.Patches[5] ||
                        ucMain.City.Cells[this.Layer, row, col].MapchipCrop == this.Patches[7] ||
                        ucMain.City.Cells[this.Layer, row, col].MapchipCrop == this.Patches[8] ||
                        ucMain.City.Cells[this.Layer, row, col].MapchipCrop == this.Horizontal
                        )
                    {
                        isWest = true;
                    }
                }

                // 中央
                if (isNorth && isEast && isSouth && isWest)
                {
                    // ┼
                    ucMain.City.Cells[this.Layer, centerRow, centerCol].MapchipCrop = this.Patches[5];
                    ucMain.City.Cells[this.Layer, centerRow, centerCol].ImageType = this.ImageType;
                }
                else if (isWest && isNorth && isEast)
                {
                    // ┴
                    ucMain.City.Cells[this.Layer, centerRow, centerCol].MapchipCrop = this.Patches[8];
                    ucMain.City.Cells[this.Layer, centerRow, centerCol].ImageType = this.ImageType;
                }
                else if (isNorth && isEast && isSouth)
                {
                    // ├
                    ucMain.City.Cells[this.Layer, centerRow, centerCol].MapchipCrop = this.Patches[4];
                    ucMain.City.Cells[this.Layer, centerRow, centerCol].ImageType = this.ImageType;
                }
                else if ( isEast && isSouth && isWest)
                {
                    // ┬
                    ucMain.City.Cells[this.Layer, centerRow, centerCol].MapchipCrop = this.Patches[2];
                    ucMain.City.Cells[this.Layer, centerRow, centerCol].ImageType = this.ImageType;
                }
                else if ( isSouth && isWest && isNorth)
                {
                    // ┤
                    ucMain.City.Cells[this.Layer, centerRow, centerCol].MapchipCrop = this.Patches[6];
                    ucMain.City.Cells[this.Layer, centerRow, centerCol].ImageType = this.ImageType;
                }
                else if (isNorth && isEast)
                {
                    // └
                    ucMain.City.Cells[this.Layer, centerRow, centerCol].MapchipCrop = this.Patches[7];
                    ucMain.City.Cells[this.Layer, centerRow, centerCol].ImageType = this.ImageType;
                }
                else if (isEast && isSouth)
                {
                    // ┌
                    ucMain.City.Cells[this.Layer, centerRow, centerCol].MapchipCrop = this.Patches[1];
                    ucMain.City.Cells[this.Layer, centerRow, centerCol].ImageType = this.ImageType;
                }
                else if (isSouth && isWest)
                {
                    // ┐
                    ucMain.City.Cells[this.Layer, centerRow, centerCol].MapchipCrop = this.Patches[3];
                    ucMain.City.Cells[this.Layer, centerRow, centerCol].ImageType = this.ImageType;
                }
                else if (isWest && isNorth)
                {
                    // ┘
                    ucMain.City.Cells[this.Layer, centerRow, centerCol].MapchipCrop = this.Patches[9];
                    ucMain.City.Cells[this.Layer, centerRow, centerCol].ImageType = this.ImageType;
                }
                else if (isNorth || isSouth)
                {
                    // │
                    ucMain.City.Cells[this.Layer, centerRow, centerCol].MapchipCrop = this.Vertical;
                    ucMain.City.Cells[this.Layer, centerRow, centerCol].ImageType = this.ImageType;
                }
                else if (isEast || isWest)
                {
                    // ─
                    ucMain.City.Cells[this.Layer, centerRow, centerCol].MapchipCrop = this.Horizontal;
                    ucMain.City.Cells[this.Layer, centerRow, centerCol].ImageType = this.ImageType;
                }
                else
                {
                    // ・
                    ucMain.City.Cells[this.Layer, centerRow, centerCol].MapchipCrop = this.Point;
                    ucMain.City.Cells[this.Layer, centerRow, centerCol].ImageType = this.ImageType;
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
                        if (pCol < ucMain.City.TableCols && pRow < ucMain.City.TableRows)
                        {
                            this.UpdateNeighborhood(ucMain //this.MapImg
                                , pRow, pCol);
                            //this.MapImg[1, pRow, pCol] = brushRailway.Patches[5];// MapchipCrop.su砂_田5;

                            if (pRowPrev != pRow && pRowPrev < ucMain.City.TableRows)
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
                        if (pCol < ucMain.City.TableCols && pRow < ucMain.City.TableRows)
                        {
                            this.UpdateNeighborhood(ucMain //this.MapImg
                                , pRow, pCol);
                            //this.MapImg[1, pRow, pCol] = brushRailway.Patches[5]; //MapchipCrop.su砂_田5;

                            if (pRowPrev != pRow && pRowPrev < ucMain.City.TableRows)
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
                        if (pCol < ucMain.City.TableCols && pRow < ucMain.City.TableRows)
                        {
                            this.UpdateNeighborhood(ucMain //this.MapImg
                                , pRow, pCol);
                            //this.MapImg[1, pRow, pCol] = brushRailway.Patches[5]; //MapchipCrop.su砂_田5;

                            if (pColPrev != pCol && pColPrev < ucMain.City.TableCols)
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
                        if (pCol < ucMain.City.TableCols && pRow < ucMain.City.TableRows)
                        {
                            this.UpdateNeighborhood(ucMain //this.MapImg
                                , pRow, pCol);
                            //this.MapImg[1, pRow, pCol] = brushRailway.Patches[5]; //MapchipCrop.su砂_田5;

                            if (pColPrev != pCol && pColPrev < ucMain.City.TableCols)
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

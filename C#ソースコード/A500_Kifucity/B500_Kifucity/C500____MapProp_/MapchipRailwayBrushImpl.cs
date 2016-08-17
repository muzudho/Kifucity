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
            ImageSourcefile imageSourcefile1
            )
        {
            this.Layer = layer;
            this.ImageSourcefile1 = imageSourcefile1;

            this.Patches_New = new ImageCropWay[]
            {
                ImageCropWay.None,
                ImageCropWay.P,
                ImageCropWay.V,
                ImageCropWay.H,
                ImageCropWay.Patch1,
                ImageCropWay.Patch2,
                ImageCropWay.Patch3,
                ImageCropWay.Patch4,
                ImageCropWay.Patch5,
                ImageCropWay.Patch6,
                ImageCropWay.Patch7,
                ImageCropWay.Patch8,
                ImageCropWay.Patch9
            };
        }

        public ImageType ImageType { get { return ImageType.Way; } }
        /// <summary>
        /// レイヤー番号☆
        /// </summary>
        public int Layer { get; set; }
        /// <summary>
        /// 元画像は、１種類の道路／線路タイプ、２種類の送電線／高架送電線タイプがあるぜ☆（＾～＾）
        /// </summary>
        public ImageSourcefile ImageSourcefile1 { get; set; }

        /// <summary>
        /// </summary>
        public ImageCropWay[] Patches_New { get; set; }


        public static void UpdateNeighborhood_Inner(UcMain ucMain //ImageCrop[,,] map
            , int centerRow, int centerCol, int layer
            ,ImageType imgType
            ,MapchipRailwayBrushImpl brush//ImageCrop imgCrop
            , ImageSourcefile imgSrc)
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
                        (int)ucMain.City.Cells[layer, row, col].ImageCrop == (int)brush.Patches_New[1] ||
                        (int)ucMain.City.Cells[layer, row, col].ImageCrop == (int)brush.Patches_New[2] ||
                        (int)ucMain.City.Cells[layer, row, col].ImageCrop == (int)brush.Patches_New[3] ||
                        (int)ucMain.City.Cells[layer, row, col].ImageCrop == (int)brush.Patches_New[4] ||
                        (int)ucMain.City.Cells[layer, row, col].ImageCrop == (int)brush.Patches_New[5] ||
                        (int)ucMain.City.Cells[layer, row, col].ImageCrop == (int)brush.Patches_New[6] ||
                        (int)ucMain.City.Cells[layer, row, col].ImageCrop == (int)brush.Patches_New[7] ||
                        (int)ucMain.City.Cells[layer, row, col].ImageCrop == (int)brush.Patches_New[8] ||
                        (int)ucMain.City.Cells[layer, row, col].ImageCrop == (int)brush.Patches_New[9] ||
                        (int)ucMain.City.Cells[layer, row, col].ImageCrop == (int)brush.Patches_New[10] ||
                        (int)ucMain.City.Cells[layer, row, col].ImageCrop == (int)brush.Patches_New[11] ||
                        (int)ucMain.City.Cells[layer, row, col].ImageCrop == (int)brush.Patches_New[12]
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
                        (int)ucMain.City.Cells[layer, row, col].ImageCrop == (int)brush.Patches_New[1] ||
                        (int)ucMain.City.Cells[layer, row, col].ImageCrop == (int)brush.Patches_New[2] ||
                        (int)ucMain.City.Cells[layer, row, col].ImageCrop == (int)brush.Patches_New[3] ||
                        (int)ucMain.City.Cells[layer, row, col].ImageCrop == (int)brush.Patches_New[4] ||
                        (int)ucMain.City.Cells[layer, row, col].ImageCrop == (int)brush.Patches_New[5] ||
                        (int)ucMain.City.Cells[layer, row, col].ImageCrop == (int)brush.Patches_New[6] ||
                        (int)ucMain.City.Cells[layer, row, col].ImageCrop == (int)brush.Patches_New[7] ||
                        (int)ucMain.City.Cells[layer, row, col].ImageCrop == (int)brush.Patches_New[8] ||
                        (int)ucMain.City.Cells[layer, row, col].ImageCrop == (int)brush.Patches_New[9] ||
                        (int)ucMain.City.Cells[layer, row, col].ImageCrop == (int)brush.Patches_New[10] ||
                        (int)ucMain.City.Cells[layer, row, col].ImageCrop == (int)brush.Patches_New[11] ||
                        (int)ucMain.City.Cells[layer, row, col].ImageCrop == (int)brush.Patches_New[12]
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
                        (int)ucMain.City.Cells[layer, row, col].ImageCrop == (int)brush.Patches_New[1] ||
                        (int)ucMain.City.Cells[layer, row, col].ImageCrop == (int)brush.Patches_New[2] ||
                        (int)ucMain.City.Cells[layer, row, col].ImageCrop == (int)brush.Patches_New[3] ||
                        (int)ucMain.City.Cells[layer, row, col].ImageCrop == (int)brush.Patches_New[4] ||
                        (int)ucMain.City.Cells[layer, row, col].ImageCrop == (int)brush.Patches_New[5] ||
                        (int)ucMain.City.Cells[layer, row, col].ImageCrop == (int)brush.Patches_New[6] ||
                        (int)ucMain.City.Cells[layer, row, col].ImageCrop == (int)brush.Patches_New[7] ||
                        (int)ucMain.City.Cells[layer, row, col].ImageCrop == (int)brush.Patches_New[8] ||
                        (int)ucMain.City.Cells[layer, row, col].ImageCrop == (int)brush.Patches_New[9] ||
                        (int)ucMain.City.Cells[layer, row, col].ImageCrop == (int)brush.Patches_New[10] ||
                        (int)ucMain.City.Cells[layer, row, col].ImageCrop == (int)brush.Patches_New[11] ||
                        (int)ucMain.City.Cells[layer, row, col].ImageCrop == (int)brush.Patches_New[12]
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
                        (int)ucMain.City.Cells[layer, row, col].ImageCrop == (int)brush.Patches_New[1] ||
                        (int)ucMain.City.Cells[layer, row, col].ImageCrop == (int)brush.Patches_New[2] ||
                        (int)ucMain.City.Cells[layer, row, col].ImageCrop == (int)brush.Patches_New[3] ||
                        (int)ucMain.City.Cells[layer, row, col].ImageCrop == (int)brush.Patches_New[4] ||
                        (int)ucMain.City.Cells[layer, row, col].ImageCrop == (int)brush.Patches_New[5] ||
                        (int)ucMain.City.Cells[layer, row, col].ImageCrop == (int)brush.Patches_New[6] ||
                        (int)ucMain.City.Cells[layer, row, col].ImageCrop == (int)brush.Patches_New[7] ||
                        (int)ucMain.City.Cells[layer, row, col].ImageCrop == (int)brush.Patches_New[8] ||
                        (int)ucMain.City.Cells[layer, row, col].ImageCrop == (int)brush.Patches_New[9] ||
                        (int)ucMain.City.Cells[layer, row, col].ImageCrop == (int)brush.Patches_New[10] ||
                        (int)ucMain.City.Cells[layer, row, col].ImageCrop == (int)brush.Patches_New[11] ||
                        (int)ucMain.City.Cells[layer, row, col].ImageCrop == (int)brush.Patches_New[12]
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
                    if ((int)ucMain.City.Cells[layer, row, col].ImageCrop == (int)brush.Patches_New[1])
                    {
                        // ・ → │
                        ucMain.City.Cells[layer, row, col].SetValue(
                            imgType, (ImageCrop)brush.Patches_New[2], imgSrc
                            );
                        isNorth = true;
                    }
                    else if ((int)ucMain.City.Cells[layer, row, col].ImageCrop == (int)brush.Patches_New[3])
                    {
                        // ─ → 
                        if (!isNorthEast)
                        {
                            // → ┐
                            ucMain.City.Cells[layer, row, col].SetValue(
                                imgType, (ImageCrop)brush.Patches_New[6], imgSrc
                                );
                        }
                        else if (!isNorthWest)
                        {
                            // → ┌
                            ucMain.City.Cells[layer, row, col].SetValue(
                                imgType, (ImageCrop)brush.Patches_New[4], imgSrc
                                );
                        }
                        else
                        {
                            // → ┬
                            ucMain.City.Cells[layer, row, col].SetValue(
                                imgType, (ImageCrop)brush.Patches_New[5], imgSrc
                                );
                        }
                        isNorth = true;
                    }
                    else if ((int)ucMain.City.Cells[layer, row, col].ImageCrop == (int)brush.Patches_New[10])
                    {
                        // └ → ├
                        ucMain.City.Cells[layer, row, col].SetValue(
                            imgType, (ImageCrop)brush.Patches_New[7], imgSrc
                            );
                        isNorth = true;
                    }
                    else if ((int)ucMain.City.Cells[layer, row, col].ImageCrop == (int)brush.Patches_New[11])
                    {
                        // ┴ → ┼
                        ucMain.City.Cells[layer, row, col].SetValue(
                            imgType, (ImageCrop)brush.Patches_New[8], imgSrc
                            );
                        isNorth = true;
                    }
                    else if ((int)ucMain.City.Cells[layer, row, col].ImageCrop == (int)brush.Patches_New[12])
                    {
                        // ┘ → ┤
                        ucMain.City.Cells[layer, row, col].SetValue(
                            imgType, (ImageCrop)brush.Patches_New[9], imgSrc
                            ); ;
                        isNorth = true;
                    }
                    else if (
                        (int)ucMain.City.Cells[layer, row, col].ImageCrop == (int)brush.Patches_New[4] ||
                        (int)ucMain.City.Cells[layer, row, col].ImageCrop == (int)brush.Patches_New[5] ||
                        (int)ucMain.City.Cells[layer, row, col].ImageCrop == (int)brush.Patches_New[6] ||
                        (int)ucMain.City.Cells[layer, row, col].ImageCrop == (int)brush.Patches_New[7] ||
                        (int)ucMain.City.Cells[layer, row, col].ImageCrop == (int)brush.Patches_New[8] ||
                        (int)ucMain.City.Cells[layer, row, col].ImageCrop == (int)brush.Patches_New[9] ||
                        (int)ucMain.City.Cells[layer, row, col].ImageCrop == (int)brush.Patches_New[2]
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
                    if ((int)ucMain.City.Cells[layer, row, col].ImageCrop == (int)brush.Patches_New[1])
                    {
                        // ・ → ─
                        ucMain.City.Cells[layer, row, col].SetValue(
                            imgType, (ImageCrop)brush.Patches_New[3], imgSrc
                            );
                        isEast = true;
                    }
                    else if ((int)ucMain.City.Cells[layer, row, col].ImageCrop == (int)brush.Patches_New[2])
                    {
                        // │ → 
                        if (!isNorthEast)
                        {
                            // → ┐
                            ucMain.City.Cells[layer, row, col].SetValue(
                                imgType, (ImageCrop)brush.Patches_New[6], imgSrc
                                );
                        }
                        else if (!isSouthEast)
                        {
                            // → ┘
                            ucMain.City.Cells[layer, row, col].SetValue(
                                imgType, (ImageCrop)brush.Patches_New[12], imgSrc
                                );
                        }
                        else
                        {
                            // → ┤
                            ucMain.City.Cells[layer, row, col].SetValue(
                                imgType, (ImageCrop)brush.Patches_New[9], imgSrc
                                );
                        }
                        isEast = true;
                    }
                    else if ((int)ucMain.City.Cells[layer, row, col].ImageCrop == (int)brush.Patches_New[4])
                    {
                        // ┌ → ┬
                        ucMain.City.Cells[layer, row, col].SetValue(
                            imgType, (ImageCrop)brush.Patches_New[5], imgSrc
                            );
                        isEast = true;
                    }
                    else if ((int)ucMain.City.Cells[layer, row, col].ImageCrop == (int)brush.Patches_New[7])
                    {
                        // ├ → ┼
                        ucMain.City.Cells[layer, row, col].SetValue(
                            imgType, (ImageCrop)brush.Patches_New[8], imgSrc
                            );
                        isEast = true;
                    }
                    else if ((int)ucMain.City.Cells[layer, row, col].ImageCrop == (int)brush.Patches_New[10])
                    {
                        // └ → ┴
                        ucMain.City.Cells[layer, row, col].SetValue(
                            imgType, (ImageCrop)brush.Patches_New[11], imgSrc
                            );
                        isEast = true;
                    }
                    else if (
                        (int)ucMain.City.Cells[layer, row, col].ImageCrop == (int)brush.Patches_New[5] ||
                        (int)ucMain.City.Cells[layer, row, col].ImageCrop == (int)brush.Patches_New[6] ||
                        (int)ucMain.City.Cells[layer, row, col].ImageCrop == (int)brush.Patches_New[8] ||
                        (int)ucMain.City.Cells[layer, row, col].ImageCrop == (int)brush.Patches_New[9] ||
                        (int)ucMain.City.Cells[layer, row, col].ImageCrop == (int)brush.Patches_New[11] ||
                        (int)ucMain.City.Cells[layer, row, col].ImageCrop == (int)brush.Patches_New[12] ||
                        (int)ucMain.City.Cells[layer, row, col].ImageCrop == (int)brush.Patches_New[3]
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
                    if ((int)ucMain.City.Cells[layer, row, col].ImageCrop == (int)brush.Patches_New[1])
                    {
                        // ・ → │
                        ucMain.City.Cells[layer, row, col].SetValue(
                            imgType, (ImageCrop)brush.Patches_New[2], imgSrc
                            );
                        isSouth = true;
                    }
                    else if ((int)ucMain.City.Cells[layer, row, col].ImageCrop == (int)brush.Patches_New[3])
                    {
                        // ─ → 
                        if (!isSouthEast)
                        {
                            // → ┘
                            ucMain.City.Cells[layer, row, col].SetValue(
                                imgType, (ImageCrop)brush.Patches_New[12], imgSrc
                                );
                        }
                        else if (!isSouthWest)
                        {
                            // → └
                            ucMain.City.Cells[layer, row, col].SetValue(
                                imgType, (ImageCrop)brush.Patches_New[10], imgSrc
                                );
                        }
                        else
                        {
                            // → ┴
                            ucMain.City.Cells[layer, row, col].SetValue(
                                imgType, (ImageCrop)brush.Patches_New[11], imgSrc
                                );
                        }
                        isSouth = true;
                    }
                    else if ((int)ucMain.City.Cells[layer, row, col].ImageCrop == (int)brush.Patches_New[4])
                    {
                        // ┌ → ├
                        ucMain.City.Cells[layer, row, col].SetValue(
                            imgType,
                            (ImageCrop)brush.Patches_New[7],
                            imgSrc
                            );
                        isSouth = true;
                    }
                    else if ((int)ucMain.City.Cells[layer, row, col].ImageCrop == (int)brush.Patches_New[5])
                    {
                        // ┬ → ┼
                        ucMain.City.Cells[layer, row, col].SetValue(
                            imgType,
                            (ImageCrop)brush.Patches_New[5],
                            imgSrc
                            );
                        isSouth = true;
                    }
                    else if ((int)ucMain.City.Cells[layer, row, col].ImageCrop == (int)brush.Patches_New[6])
                    {
                        // ┐ → ┤
                        ucMain.City.Cells[layer, row, col].SetValue(
                            imgType,
                            (ImageCrop)brush.Patches_New[9],
                            imgSrc
                            );
                        isSouth = true;
                    }
                    else if (
                        (int)ucMain.City.Cells[layer, row, col].ImageCrop == (int)brush.Patches_New[7] ||
                        (int)ucMain.City.Cells[layer, row, col].ImageCrop == (int)brush.Patches_New[8] ||
                        (int)ucMain.City.Cells[layer, row, col].ImageCrop == (int)brush.Patches_New[9] ||
                        (int)ucMain.City.Cells[layer, row, col].ImageCrop == (int)brush.Patches_New[10] ||
                        (int)ucMain.City.Cells[layer, row, col].ImageCrop == (int)brush.Patches_New[11] ||
                        (int)ucMain.City.Cells[layer, row, col].ImageCrop == (int)brush.Patches_New[12] ||
                        (int)ucMain.City.Cells[layer, row, col].ImageCrop == (int)brush.Patches_New[2]
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
                    if ((int)ucMain.City.Cells[layer, row, col].ImageCrop == (int)brush.Patches_New[1])
                    {
                        // ・ → ─
                        ucMain.City.Cells[layer, row, col].SetValue(
                            imgType, (ImageCrop)brush.Patches_New[3], imgSrc
                            );
                        isWest = true;
                    }
                    else if ((int)ucMain.City.Cells[layer, row, col].ImageCrop == (int)brush.Patches_New[2])
                    {
                        // │→
                        if (!isNorthWest)
                        {
                            // → ┌
                            ucMain.City.Cells[layer, row, col].SetValue(
                                imgType, (ImageCrop)brush.Patches_New[4], imgSrc
                                );
                        }
                        else if (!isSouthWest)
                        {
                            // → └
                            ucMain.City.Cells[layer, row, col].SetValue(
                                imgType, (ImageCrop)brush.Patches_New[10], imgSrc
                                );
                        }
                        else
                        {
                            // → ├
                            ucMain.City.Cells[layer, row, col].SetValue(
                                imgType, (ImageCrop)brush.Patches_New[7], imgSrc
                                );
                        }
                        isWest = true;
                    }
                    else if ((int)ucMain.City.Cells[layer, row, col].ImageCrop == (int)brush.Patches_New[6])
                    {
                        // ┐ → ┬
                        ucMain.City.Cells[layer, row, col].SetValue(
                            imgType, (ImageCrop)brush.Patches_New[5], imgSrc
                            );
                        isWest = true;
                    }
                    else if ((int)ucMain.City.Cells[layer, row, col].ImageCrop == (int)brush.Patches_New[9])
                    {
                        // ┤ → ┼
                        ucMain.City.Cells[layer, row, col].SetValue(
                            imgType, (ImageCrop)brush.Patches_New[8], imgSrc
                            );
                        isWest = true;
                    }
                    else if ((int)ucMain.City.Cells[layer, row, col].ImageCrop == (int)brush.Patches_New[12])
                    {
                        // ┘ → ┴
                        ucMain.City.Cells[layer, row, col].SetValue(
                            imgType, (ImageCrop)brush.Patches_New[11], imgSrc
                            );
                        isWest = true;
                    }
                    else if (
                        (int)ucMain.City.Cells[layer, row, col].ImageCrop == (int)brush.Patches_New[4] ||
                        (int)ucMain.City.Cells[layer, row, col].ImageCrop == (int)brush.Patches_New[5] ||
                        (int)ucMain.City.Cells[layer, row, col].ImageCrop == (int)brush.Patches_New[7] ||
                        (int)ucMain.City.Cells[layer, row, col].ImageCrop == (int)brush.Patches_New[8] ||
                        (int)ucMain.City.Cells[layer, row, col].ImageCrop == (int)brush.Patches_New[10] ||
                        (int)ucMain.City.Cells[layer, row, col].ImageCrop == (int)brush.Patches_New[11] ||
                        (int)ucMain.City.Cells[layer, row, col].ImageCrop == (int)brush.Patches_New[3]
                        )
                    {
                        isWest = true;
                    }
                }

                // 中央
                if (isNorth && isEast && isSouth && isWest)
                {
                    // ┼
                    ucMain.City.Cells[layer, centerRow, centerCol].SetValue(
                        imgType, (ImageCrop)brush.Patches_New[8], imgSrc
                        );
                }
                else if (isWest && isNorth && isEast)
                {
                    // ┴
                    ucMain.City.Cells[layer, centerRow, centerCol].SetValue(
                        imgType, (ImageCrop)brush.Patches_New[11], imgSrc
                        );
                }
                else if (isNorth && isEast && isSouth)
                {
                    // ├
                    ucMain.City.Cells[layer, centerRow, centerCol].SetValue(
                        imgType, (ImageCrop)brush.Patches_New[7], imgSrc
                        );
                }
                else if (isEast && isSouth && isWest)
                {
                    // ┬
                    ucMain.City.Cells[layer, centerRow, centerCol].SetValue(
                        imgType, (ImageCrop)brush.Patches_New[5], imgSrc
                        );
                }
                else if (isSouth && isWest && isNorth)
                {
                    // ┤
                    ucMain.City.Cells[layer, centerRow, centerCol].SetValue(
                        imgType, (ImageCrop)brush.Patches_New[9], imgSrc
                        );
                }
                else if (isNorth && isEast)
                {
                    // └
                    ucMain.City.Cells[layer, centerRow, centerCol].SetValue(
                        imgType, (ImageCrop)brush.Patches_New[10], imgSrc
                        );
                }
                else if (isEast && isSouth)
                {
                    // ┌
                    ucMain.City.Cells[layer, centerRow, centerCol].SetValue(
                        imgType, (ImageCrop)brush.Patches_New[4], imgSrc
                        );
                }
                else if (isSouth && isWest)
                {
                    // ┐
                    ucMain.City.Cells[layer, centerRow, centerCol].SetValue(
                        imgType, (ImageCrop)brush.Patches_New[6], imgSrc
                        );
                }
                else if (isWest && isNorth)
                {
                    // ┘
                    ucMain.City.Cells[layer, centerRow, centerCol].SetValue(
                        imgType, (ImageCrop)brush.Patches_New[12], imgSrc
                        );
                }
                else if (isNorth || isSouth)
                {
                    // │
                    ucMain.City.Cells[layer, centerRow, centerCol].SetValue(
                        imgType, (ImageCrop)brush.Patches_New[2], imgSrc
                        );
                }
                else if (isEast || isWest)
                {
                    // ─
                    ucMain.City.Cells[layer, centerRow, centerCol].SetValue(
                        imgType, (ImageCrop)brush.Patches_New[3], imgSrc
                        );
                }
                else
                {
                    // ・
                    ucMain.City.Cells[layer, centerRow, centerCol].SetValue(
                        imgType, (ImageCrop)brush.Patches_New[1], imgSrc
                        );
                }
            }
        }

        /// <summary>
        /// 近傍を巻き込んだマップチップの置き換え
        /// </summary>
        public void UpdateNeighborhood(UcMain ucMain //ImageCrop[,,] map
            , int centerRow, int centerCol)
        {
            MapchipRailwayBrushImpl.UpdateNeighborhood_Inner( ucMain
            , centerRow, centerCol, this.Layer,
            this.ImageType,
            this,//this.ImageCrop,
            this.ImageSourcefile1);
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
                            //this.MapImg[1, pRow, pCol] = brushRailway.Patches[5];// ImageCrop.su砂_田5;

                            if (pRowPrev != pRow && pRowPrev < ucMain.City.TableRows)
                            {
                                // シムシティの線路みたいな直線のつなげ方をするぜ☆（＾～＾）
                                this.UpdateNeighborhood(ucMain //this.MapImg
                                    , pRowPrev, pCol);
                                //this.MapImg[1, pRowPrev, pCol] = brushRailway.Patches[5];// ImageCrop.su砂_田5;
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
                            //this.MapImg[1, pRow, pCol] = brushRailway.Patches[5]; //ImageCrop.su砂_田5;

                            if (pRowPrev != pRow && pRowPrev < ucMain.City.TableRows)
                            {
                                // シムシティの線路みたいな直線のつなげ方をするぜ☆（＾～＾）
                                this.UpdateNeighborhood(ucMain //this.MapImg
                                    , pRowPrev, pCol);
                                //this.MapImg[1, pRowPrev, pCol] = brushRailway.Patches[5]; //ImageCrop.su砂_田5;
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
                            //this.MapImg[1, pRow, pCol] = brushRailway.Patches[5]; //ImageCrop.su砂_田5;

                            if (pColPrev != pCol && pColPrev < ucMain.City.TableCols)
                            {
                                // シムシティの線路みたいな直線のつなげ方をするぜ☆（＾～＾）
                                this.UpdateNeighborhood(ucMain //this.MapImg
                                    , pRow, pColPrev);
                                //this.MapImg[1, pRow, pColPrev] = brushRailway.Patches[5]; //ImageCrop.su砂_田5;
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
                            //this.MapImg[1, pRow, pCol] = brushRailway.Patches[5]; //ImageCrop.su砂_田5;

                            if (pColPrev != pCol && pColPrev < ucMain.City.TableCols)
                            {
                                // シムシティの線路みたいな直線のつなげ方をするぜ☆（＾～＾）
                                this.UpdateNeighborhood(ucMain //this.MapImg
                                    , pRow, pColPrev);
                                //this.MapImg[1, pRow, pColPrev] = brushRailway.Patches[5]; //ImageCrop.su砂_田5;
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

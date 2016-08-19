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
            ImageSourcefile[] imageSourcefiles
            )
        {
            this.Layer = layer;
            this.ImageSourcefiles = imageSourcefiles;

            this.ImageCrop = new ImageCropWay[]
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
        /// 元画像は、道路／線路タイプだぜ☆（＾～＾）
        /// </summary>
        public ImageSourcefile[] ImageSourcefiles { get; set; }

        public int GetSourcefileIndex(Position city, int row, int col)
        {
            return 0;
        }

        /// <summary>
        /// 画像の切り抜き領域☆
        /// </summary>
        public ImageCropWay[] ImageCrop { get; set; }


        /// <summary>
        /// 近傍を巻き込んだマップチップの置き換え
        /// </summary>
        public void UpdateNeighborhood(Position city, int centerRow, int centerCol)
        {
            MapchipRailwayBrushImpl.UpdateNeighborhood_Inner(city
            , centerRow, centerCol, this.Layer,
            this.ImageType,
            this.ImageCrop,
            this.ImageSourcefiles,
            this
            );
        }

        /// <summary>
        /// 直線状にマップチップを連続配置するぜ☆（＾▽＾）
        /// </summary>
        public void PutMapchipAsLine(
            out bool out_isUpdate, Point mouseLocation, UcMain ucMain
            )
        {
            MapchipRailwayBrushImpl.PutMapchipAsLine_Inner(out out_isUpdate, ucMain.City, this,
                mouseLocation,
                ucMain.MouseDownLocation,
                ucMain.TableLeft, ucMain.TableTop
                );
        }


        public static void UpdateNeighborhood_Inner(Position city
            , int centerRow, int centerCol, int layer
            ,ImageType imgType
            ,ImageCropWay[] crops
            , ImageSourcefile[] imageSourcefiles,
            MapchipBrush brush
            )
        {
            if (-1 < centerCol && centerCol < city.TableCols &&
    -1 < centerRow && centerRow < city.TableRows)
            {
                int col;
                int row;

                // 北東
                bool isNorthEast = false;
                col = centerCol + 1;
                row = centerRow - 1;
                if (col < city.TableCols && -1 < row)
                {
                    if (
                        (int)city.Cells[layer, row, col].ImageCrop == (int)crops[1] ||
                        (int)city.Cells[layer, row, col].ImageCrop == (int)crops[2] ||
                        (int)city.Cells[layer, row, col].ImageCrop == (int)crops[3] ||
                        (int)city.Cells[layer, row, col].ImageCrop == (int)crops[4] ||
                        (int)city.Cells[layer, row, col].ImageCrop == (int)crops[5] ||
                        (int)city.Cells[layer, row, col].ImageCrop == (int)crops[6] ||
                        (int)city.Cells[layer, row, col].ImageCrop == (int)crops[7] ||
                        (int)city.Cells[layer, row, col].ImageCrop == (int)crops[8] ||
                        (int)city.Cells[layer, row, col].ImageCrop == (int)crops[9] ||
                        (int)city.Cells[layer, row, col].ImageCrop == (int)crops[10] ||
                        (int)city.Cells[layer, row, col].ImageCrop == (int)crops[11] ||
                        (int)city.Cells[layer, row, col].ImageCrop == (int)crops[12]
                        )
                    {
                        isNorthEast = true;
                    }
                }

                // 南東
                bool isSouthEast = false;
                col = centerCol + 1;
                row = centerRow + 1;
                if (col < city.TableCols && row < city.TableRows)
                {
                    if (
                        (int)city.Cells[layer, row, col].ImageCrop == (int)crops[1] ||
                        (int)city.Cells[layer, row, col].ImageCrop == (int)crops[2] ||
                        (int)city.Cells[layer, row, col].ImageCrop == (int)crops[3] ||
                        (int)city.Cells[layer, row, col].ImageCrop == (int)crops[4] ||
                        (int)city.Cells[layer, row, col].ImageCrop == (int)crops[5] ||
                        (int)city.Cells[layer, row, col].ImageCrop == (int)crops[6] ||
                        (int)city.Cells[layer, row, col].ImageCrop == (int)crops[7] ||
                        (int)city.Cells[layer, row, col].ImageCrop == (int)crops[8] ||
                        (int)city.Cells[layer, row, col].ImageCrop == (int)crops[9] ||
                        (int)city.Cells[layer, row, col].ImageCrop == (int)crops[10] ||
                        (int)city.Cells[layer, row, col].ImageCrop == (int)crops[11] ||
                        (int)city.Cells[layer, row, col].ImageCrop == (int)crops[12]
                        )
                    {
                        isSouthEast = true;
                    }
                }

                // 南西
                bool isSouthWest = false;
                col = centerCol - 1;
                row = centerRow + 1;
                if (-1 < col && row < city.TableRows)
                {
                    if (
                        (int)city.Cells[layer, row, col].ImageCrop == (int)crops[1] ||
                        (int)city.Cells[layer, row, col].ImageCrop == (int)crops[2] ||
                        (int)city.Cells[layer, row, col].ImageCrop == (int)crops[3] ||
                        (int)city.Cells[layer, row, col].ImageCrop == (int)crops[4] ||
                        (int)city.Cells[layer, row, col].ImageCrop == (int)crops[5] ||
                        (int)city.Cells[layer, row, col].ImageCrop == (int)crops[6] ||
                        (int)city.Cells[layer, row, col].ImageCrop == (int)crops[7] ||
                        (int)city.Cells[layer, row, col].ImageCrop == (int)crops[8] ||
                        (int)city.Cells[layer, row, col].ImageCrop == (int)crops[9] ||
                        (int)city.Cells[layer, row, col].ImageCrop == (int)crops[10] ||
                        (int)city.Cells[layer, row, col].ImageCrop == (int)crops[11] ||
                        (int)city.Cells[layer, row, col].ImageCrop == (int)crops[12]
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
                        (int)city.Cells[layer, row, col].ImageCrop == (int)crops[1] ||
                        (int)city.Cells[layer, row, col].ImageCrop == (int)crops[2] ||
                        (int)city.Cells[layer, row, col].ImageCrop == (int)crops[3] ||
                        (int)city.Cells[layer, row, col].ImageCrop == (int)crops[4] ||
                        (int)city.Cells[layer, row, col].ImageCrop == (int)crops[5] ||
                        (int)city.Cells[layer, row, col].ImageCrop == (int)crops[6] ||
                        (int)city.Cells[layer, row, col].ImageCrop == (int)crops[7] ||
                        (int)city.Cells[layer, row, col].ImageCrop == (int)crops[8] ||
                        (int)city.Cells[layer, row, col].ImageCrop == (int)crops[9] ||
                        (int)city.Cells[layer, row, col].ImageCrop == (int)crops[10] ||
                        (int)city.Cells[layer, row, col].ImageCrop == (int)crops[11] ||
                        (int)city.Cells[layer, row, col].ImageCrop == (int)crops[12]
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
                    if ((int)city.Cells[layer, row, col].ImageCrop == (int)crops[1])
                    {
                        // ・ → │
                        city.Cells[layer, row, col].SetValue(
                            imgType, (ImageCrop)crops[2], imageSourcefiles[brush.GetSourcefileIndex(city,row, col)]
                            );
                        isNorth = true;
                    }
                    else if ((int)city.Cells[layer, row, col].ImageCrop == (int)crops[3])
                    {
                        // ─ → 
                        if (!isNorthEast)
                        {
                            // → ┐
                            city.Cells[layer, row, col].SetValue(
                                imgType, (ImageCrop)crops[6], imageSourcefiles[brush.GetSourcefileIndex(city, row, col)]
                                );
                        }
                        else if (!isNorthWest)
                        {
                            // → ┌
                            city.Cells[layer, row, col].SetValue(
                                imgType, (ImageCrop)crops[4], imageSourcefiles[brush.GetSourcefileIndex(city, row, col)]
                                );
                        }
                        else
                        {
                            // → ┬
                            city.Cells[layer, row, col].SetValue(
                                imgType, (ImageCrop)crops[5], imageSourcefiles[brush.GetSourcefileIndex(city, row, col)]
                                );
                        }
                        isNorth = true;
                    }
                    else if ((int)city.Cells[layer, row, col].ImageCrop == (int)crops[10])
                    {
                        // └ → ├
                        city.Cells[layer, row, col].SetValue(
                            imgType, (ImageCrop)crops[7], imageSourcefiles[brush.GetSourcefileIndex(city, row, col)]
                            );
                        isNorth = true;
                    }
                    else if ((int)city.Cells[layer, row, col].ImageCrop == (int)crops[11])
                    {
                        // ┴ → ┼
                        city.Cells[layer, row, col].SetValue(
                            imgType, (ImageCrop)crops[8], imageSourcefiles[brush.GetSourcefileIndex(city, row, col)]
                            );
                        isNorth = true;
                    }
                    else if ((int)city.Cells[layer, row, col].ImageCrop == (int)crops[12])
                    {
                        // ┘ → ┤
                        city.Cells[layer, row, col].SetValue(
                            imgType, (ImageCrop)crops[9], imageSourcefiles[brush.GetSourcefileIndex(city, row, col)]
                            ); ;
                        isNorth = true;
                    }
                    else if (
                        (int)city.Cells[layer, row, col].ImageCrop == (int)crops[4] ||
                        (int)city.Cells[layer, row, col].ImageCrop == (int)crops[5] ||
                        (int)city.Cells[layer, row, col].ImageCrop == (int)crops[6] ||
                        (int)city.Cells[layer, row, col].ImageCrop == (int)crops[7] ||
                        (int)city.Cells[layer, row, col].ImageCrop == (int)crops[8] ||
                        (int)city.Cells[layer, row, col].ImageCrop == (int)crops[9] ||
                        (int)city.Cells[layer, row, col].ImageCrop == (int)crops[2]
                        )
                    {
                        isNorth = true;
                    }
                }

                // 東
                bool isEast = false;
                col = centerCol + 1;
                row = centerRow;
                if (col < city.TableCols)
                {
                    if ((int)city.Cells[layer, row, col].ImageCrop == (int)crops[1])
                    {
                        // ・ → ─
                        city.Cells[layer, row, col].SetValue(
                            imgType, (ImageCrop)crops[3], imageSourcefiles[brush.GetSourcefileIndex(city, row, col)]
                            );
                        isEast = true;
                    }
                    else if ((int)city.Cells[layer, row, col].ImageCrop == (int)crops[2])
                    {
                        // │ → 
                        if (!isNorthEast)
                        {
                            // → ┐
                            city.Cells[layer, row, col].SetValue(
                                imgType, (ImageCrop)crops[6], imageSourcefiles[brush.GetSourcefileIndex(city, row, col)]
                                );
                        }
                        else if (!isSouthEast)
                        {
                            // → ┘
                            city.Cells[layer, row, col].SetValue(
                                imgType, (ImageCrop)crops[12], imageSourcefiles[brush.GetSourcefileIndex(city, row, col)]
                                );
                        }
                        else
                        {
                            // → ┤
                            city.Cells[layer, row, col].SetValue(
                                imgType, (ImageCrop)crops[9], imageSourcefiles[brush.GetSourcefileIndex(city, row, col)]
                                );
                        }
                        isEast = true;
                    }
                    else if ((int)city.Cells[layer, row, col].ImageCrop == (int)crops[4])
                    {
                        // ┌ → ┬
                        city.Cells[layer, row, col].SetValue(
                            imgType, (ImageCrop)crops[5], imageSourcefiles[brush.GetSourcefileIndex(city, row, col)]
                            );
                        isEast = true;
                    }
                    else if ((int)city.Cells[layer, row, col].ImageCrop == (int)crops[7])
                    {
                        // ├ → ┼
                        city.Cells[layer, row, col].SetValue(
                            imgType, (ImageCrop)crops[8], imageSourcefiles[brush.GetSourcefileIndex(city, row, col)]
                            );
                        isEast = true;
                    }
                    else if ((int)city.Cells[layer, row, col].ImageCrop == (int)crops[10])
                    {
                        // └ → ┴
                        city.Cells[layer, row, col].SetValue(
                            imgType, (ImageCrop)crops[11], imageSourcefiles[brush.GetSourcefileIndex(city, row, col)]
                            );
                        isEast = true;
                    }
                    else if (
                        (int)city.Cells[layer, row, col].ImageCrop == (int)crops[5] ||
                        (int)city.Cells[layer, row, col].ImageCrop == (int)crops[6] ||
                        (int)city.Cells[layer, row, col].ImageCrop == (int)crops[8] ||
                        (int)city.Cells[layer, row, col].ImageCrop == (int)crops[9] ||
                        (int)city.Cells[layer, row, col].ImageCrop == (int)crops[11] ||
                        (int)city.Cells[layer, row, col].ImageCrop == (int)crops[12] ||
                        (int)city.Cells[layer, row, col].ImageCrop == (int)crops[3]
                        )
                    {
                        isEast = true;
                    }
                }

                // 南
                bool isSouth = false;
                col = centerCol;
                row = centerRow + 1;
                if (row < city.TableRows)
                {
                    if ((int)city.Cells[layer, row, col].ImageCrop == (int)crops[1])
                    {
                        // ・ → │
                        city.Cells[layer, row, col].SetValue(
                            imgType, (ImageCrop)crops[2], imageSourcefiles[brush.GetSourcefileIndex(city, row, col)]
                            );
                        isSouth = true;
                    }
                    else if ((int)city.Cells[layer, row, col].ImageCrop == (int)crops[3])
                    {
                        // ─ → 
                        if (!isSouthEast)
                        {
                            // → ┘
                            city.Cells[layer, row, col].SetValue(
                                imgType, (ImageCrop)crops[12], imageSourcefiles[brush.GetSourcefileIndex(city, row, col)]
                                );
                        }
                        else if (!isSouthWest)
                        {
                            // → └
                            city.Cells[layer, row, col].SetValue(
                                imgType, (ImageCrop)crops[10], imageSourcefiles[brush.GetSourcefileIndex(city, row, col)]
                                );
                        }
                        else
                        {
                            // → ┴
                            city.Cells[layer, row, col].SetValue(
                                imgType, (ImageCrop)crops[11], imageSourcefiles[brush.GetSourcefileIndex(city, row, col)]
                                );
                        }
                        isSouth = true;
                    }
                    else if ((int)city.Cells[layer, row, col].ImageCrop == (int)crops[4])
                    {
                        // ┌ → ├
                        city.Cells[layer, row, col].SetValue(
                            imgType,
                            (ImageCrop)crops[7],
                            imageSourcefiles[brush.GetSourcefileIndex(city, row, col)]
                            );
                        isSouth = true;
                    }
                    else if ((int)city.Cells[layer, row, col].ImageCrop == (int)crops[5])
                    {
                        // ┬ → ┼
                        city.Cells[layer, row, col].SetValue(
                            imgType,
                            (ImageCrop)crops[5],
                            imageSourcefiles[brush.GetSourcefileIndex(city, row, col)]
                            );
                        isSouth = true;
                    }
                    else if ((int)city.Cells[layer, row, col].ImageCrop == (int)crops[6])
                    {
                        // ┐ → ┤
                        city.Cells[layer, row, col].SetValue(
                            imgType,
                            (ImageCrop)crops[9],
                            imageSourcefiles[brush.GetSourcefileIndex(city, row, col)]
                            );
                        isSouth = true;
                    }
                    else if (
                        (int)city.Cells[layer, row, col].ImageCrop == (int)crops[7] ||
                        (int)city.Cells[layer, row, col].ImageCrop == (int)crops[8] ||
                        (int)city.Cells[layer, row, col].ImageCrop == (int)crops[9] ||
                        (int)city.Cells[layer, row, col].ImageCrop == (int)crops[10] ||
                        (int)city.Cells[layer, row, col].ImageCrop == (int)crops[11] ||
                        (int)city.Cells[layer, row, col].ImageCrop == (int)crops[12] ||
                        (int)city.Cells[layer, row, col].ImageCrop == (int)crops[2]
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
                    if ((int)city.Cells[layer, row, col].ImageCrop == (int)crops[1])
                    {
                        // ・ → ─
                        city.Cells[layer, row, col].SetValue(
                            imgType, (ImageCrop)crops[3], imageSourcefiles[brush.GetSourcefileIndex(city, row, col)]
                            );
                        isWest = true;
                    }
                    else if ((int)city.Cells[layer, row, col].ImageCrop == (int)crops[2])
                    {
                        // │→
                        if (!isNorthWest)
                        {
                            // → ┌
                            city.Cells[layer, row, col].SetValue(
                                imgType, (ImageCrop)crops[4], imageSourcefiles[brush.GetSourcefileIndex(city, row, col)]
                                );
                        }
                        else if (!isSouthWest)
                        {
                            // → └
                            city.Cells[layer, row, col].SetValue(
                                imgType, (ImageCrop)crops[10], imageSourcefiles[brush.GetSourcefileIndex(city, row, col)]
                                );
                        }
                        else
                        {
                            // → ├
                            city.Cells[layer, row, col].SetValue(
                                imgType, (ImageCrop)crops[7], imageSourcefiles[brush.GetSourcefileIndex(city, row, col)]
                                );
                        }
                        isWest = true;
                    }
                    else if ((int)city.Cells[layer, row, col].ImageCrop == (int)crops[6])
                    {
                        // ┐ → ┬
                        city.Cells[layer, row, col].SetValue(
                            imgType, (ImageCrop)crops[5], imageSourcefiles[brush.GetSourcefileIndex(city, row, col)]
                            );
                        isWest = true;
                    }
                    else if ((int)city.Cells[layer, row, col].ImageCrop == (int)crops[9])
                    {
                        // ┤ → ┼
                        city.Cells[layer, row, col].SetValue(
                            imgType, (ImageCrop)crops[8], imageSourcefiles[brush.GetSourcefileIndex(city, row, col)]
                            );
                        isWest = true;
                    }
                    else if ((int)city.Cells[layer, row, col].ImageCrop == (int)crops[12])
                    {
                        // ┘ → ┴
                        city.Cells[layer, row, col].SetValue(
                            imgType, (ImageCrop)crops[11], imageSourcefiles[brush.GetSourcefileIndex(city, row, col)]
                            );
                        isWest = true;
                    }
                    else if (
                        (int)city.Cells[layer, row, col].ImageCrop == (int)crops[4] ||
                        (int)city.Cells[layer, row, col].ImageCrop == (int)crops[5] ||
                        (int)city.Cells[layer, row, col].ImageCrop == (int)crops[7] ||
                        (int)city.Cells[layer, row, col].ImageCrop == (int)crops[8] ||
                        (int)city.Cells[layer, row, col].ImageCrop == (int)crops[10] ||
                        (int)city.Cells[layer, row, col].ImageCrop == (int)crops[11] ||
                        (int)city.Cells[layer, row, col].ImageCrop == (int)crops[3]
                        )
                    {
                        isWest = true;
                    }
                }

#if DEBUG
                row = -1; // もう使わないはず☆
                col = -1;
#endif

                // 中央
                if (isNorth && isEast && isSouth && isWest)
                {
                    // ┼
                    city.Cells[layer, centerRow, centerCol].SetValue(
                        imgType, (ImageCrop)crops[8], imageSourcefiles[brush.GetSourcefileIndex(city, centerRow, centerCol)]
                        );
                }
                else if (isWest && isNorth && isEast)
                {
                    // ┴
                    city.Cells[layer, centerRow, centerCol].SetValue(
                        imgType, (ImageCrop)crops[11], imageSourcefiles[brush.GetSourcefileIndex(city, centerRow, centerCol)]
                        );
                }
                else if (isNorth && isEast && isSouth)
                {
                    // ├
                    city.Cells[layer, centerRow, centerCol].SetValue(
                        imgType, (ImageCrop)crops[7], imageSourcefiles[brush.GetSourcefileIndex(city, centerRow, centerCol)]
                        );
                }
                else if (isEast && isSouth && isWest)
                {
                    // ┬
                    city.Cells[layer, centerRow, centerCol].SetValue(
                        imgType, (ImageCrop)crops[5], imageSourcefiles[brush.GetSourcefileIndex(city, centerRow, centerCol)]
                        );
                }
                else if (isSouth && isWest && isNorth)
                {
                    // ┤
                    city.Cells[layer, centerRow, centerCol].SetValue(
                        imgType, (ImageCrop)crops[9], imageSourcefiles[brush.GetSourcefileIndex(city, centerRow, centerCol)]
                        );
                }
                else if (isNorth && isEast)
                {
                    // └
                    city.Cells[layer, centerRow, centerCol].SetValue(
                        imgType, (ImageCrop)crops[10], imageSourcefiles[brush.GetSourcefileIndex(city, centerRow, centerCol)]
                        );
                }
                else if (isEast && isSouth)
                {
                    // ┌
                    city.Cells[layer, centerRow, centerCol].SetValue(
                        imgType, (ImageCrop)crops[4], imageSourcefiles[brush.GetSourcefileIndex(city, centerRow, centerCol)]
                        );
                }
                else if (isSouth && isWest)
                {
                    // ┐
                    city.Cells[layer, centerRow, centerCol].SetValue(
                        imgType, (ImageCrop)crops[6], imageSourcefiles[brush.GetSourcefileIndex(city, centerRow, centerCol)]
                        );
                }
                else if (isWest && isNorth)
                {
                    // ┘
                    city.Cells[layer, centerRow, centerCol].SetValue(
                        imgType, (ImageCrop)crops[12], imageSourcefiles[brush.GetSourcefileIndex(city, centerRow, centerCol)]
                        );
                }
                else if (isNorth || isSouth)
                {
                    // │
                    city.Cells[layer, centerRow, centerCol].SetValue(
                        imgType, (ImageCrop)crops[2], imageSourcefiles[brush.GetSourcefileIndex(city, centerRow, centerCol)]
                        );
                }
                else if (isEast || isWest)
                {
                    // ─
                    city.Cells[layer, centerRow, centerCol].SetValue(
                        imgType, (ImageCrop)crops[3], imageSourcefiles[brush.GetSourcefileIndex(city, centerRow, centerCol)]
                        );
                }
                else
                {
                    // ・
                    city.Cells[layer, centerRow, centerCol].SetValue(
                        imgType, (ImageCrop)crops[1], imageSourcefiles[brush.GetSourcefileIndex(city, centerRow, centerCol)]
                        );
                }
            }
        }

        /// <summary>
        /// 直線状にマップチップを連続配置するぜ☆（＾▽＾）
        /// </summary>
        public static void PutMapchipAsLine_Inner(
            out bool out_isUpdate, Position city, MapchipBrush brush, Point mouseLocation,
            Point mouseDownLocation,
            int tableLeft, int tableTop
            )
        {
            // ２点間を補完して埋めたい。
            // http://kifucity.warabenture.com/archives/47

            out_isUpdate = false;

            // 始点
            int beginCol = (mouseDownLocation.X - tableLeft) / PositionImpl.CELL_W;
            int beginRow = (mouseDownLocation.Y - tableTop) / PositionImpl.CELL_H;
            // 終点
            int endCol = (mouseLocation.X - tableLeft) / PositionImpl.CELL_W;
            int endRow = (mouseLocation.Y - tableTop) / PositionImpl.CELL_H;
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
                        if (pCol < city.TableCols && pRow < city.TableRows)
                        {
                            brush.UpdateNeighborhood(city, pRow, pCol);

                            if (pRowPrev != pRow && pRowPrev < city.TableRows)
                            {
                                // シムシティの線路みたいな直線のつなげ方をするぜ☆（＾～＾）
                                brush.UpdateNeighborhood(city, pRowPrev, pCol);
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
                        if (pCol < city.TableCols && pRow < city.TableRows)
                        {
                            brush.UpdateNeighborhood(city, pRow, pCol);

                            if (pRowPrev != pRow && pRowPrev < city.TableRows)
                            {
                                // シムシティの線路みたいな直線のつなげ方をするぜ☆（＾～＾）
                                brush.UpdateNeighborhood(city, pRowPrev, pCol);
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
                        if (pCol < city.TableCols && pRow < city.TableRows)
                        {
                            brush.UpdateNeighborhood(city, pRow, pCol);

                            if (pColPrev != pCol && pColPrev < city.TableCols)
                            {
                                // シムシティの線路みたいな直線のつなげ方をするぜ☆（＾～＾）
                                brush.UpdateNeighborhood(city, pRow, pColPrev);
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
                        if (pCol < city.TableCols && pRow < city.TableRows)
                        {
                            brush.UpdateNeighborhood(city, pRow, pCol);

                            if (pColPrev != pCol && pColPrev < city.TableCols)
                            {
                                // シムシティの線路みたいな直線のつなげ方をするぜ☆（＾～＾）
                                brush.UpdateNeighborhood(city, pRow, pColPrev);
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

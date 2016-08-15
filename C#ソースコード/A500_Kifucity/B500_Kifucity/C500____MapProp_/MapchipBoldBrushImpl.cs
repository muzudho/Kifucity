using Grayscale.A500_Kifucity.B500_Kifucity.C___500_MapProp_;
using System.Drawing;
using System;

namespace Grayscale.A500_Kifucity.B500_Kifucity.C500____MapProp_
{
    /// <summary>
    /// 太ペン☆ //囲まれている内側を塗りつぶすバケツ☆
    /// </summary>
    public class MapchipBoldBrushImpl : MapchipBoldBrush
    {
        public MapchipBoldBrushImpl(
            int layer,
            ImageType imageType,
            MapchipCrop patch
            )
        {
            this.Layer = layer;
            this.ImageType = imageType;
            this.Patch = patch;
        }

        /// <summary>
        /// レイヤー番号☆
        /// </summary>
        public int Layer { get; set; }
        public ImageType ImageType { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public MapchipCrop Patch { get; set; }

        /// <summary>
        /// 周囲８方向に何があるかで、チップの形が決まるぜ☆（＾▽＾）
        /// </summary>
        /// <param name="ucMain"></param>
        /// <param name="pRow"></param>
        /// <param name="pCol"></param>
        private void UpdateBoarder_Sub(UcMain ucMain
            , int pRow, int pCol)
        {
            if (ucMain.Cells[1,pRow,pCol].MapchipCrop==MapchipCrop.kyo境界線_A5)
            {
                // A5は、境界線ではないので、変形しないぜ☆（＾▽＾）
                return;
            }

            //────────────────────────────────────────
            // まず、ここに施設を置くぜ☆（＾▽＾）
            //────────────────────────────────────────

            // （更新）中央
            ucMain.Cells[this.Layer, pRow, pCol].MapchipCrop = this.Patch;
            ucMain.Cells[this.Layer, pRow, pCol].ImageType = this.ImageType;


            int col;
            int row;

            MapchipCrop crop = MapchipCrop.None;

            // 北
            col = pCol;
            row = pRow - 1;
            if (-1 < row)
            {
                if (
                    ucMain.Cells[this.Layer, row, col].MapchipCrop != this.Patch &&
                    ucMain.Cells[this.Layer, row, col].ImageType != ImageType.Border_Sunachi
                    )
                {
                    // 塗りつぶすぜ☆（＾▽＾）
                    crop = this.Patch;
                }
            }

            // 東
            col = pCol + 1;
            row = pRow;
            if (col < UcMain.TABLE_COLS)
            {
                if (
                    ucMain.Cells[this.Layer, row, col].MapchipCrop != this.Patch &&
                    ucMain.Cells[this.Layer, row, col].ImageType != ImageType.Border_Sunachi
                    )
                {
                    // 塗りつぶすぜ☆（＾▽＾）
                    crop = this.Patch;
                }
            }

            // 南
            col = pCol;
            row = pRow + 1;
            if (row < UcMain.TABLE_ROWS)
            {
                if (
                    ucMain.Cells[this.Layer, row, col].MapchipCrop != this.Patch &&
                    ucMain.Cells[this.Layer, row, col].ImageType != ImageType.Border_Sunachi
                    )
                {
                    // 塗りつぶすぜ☆（＾▽＾）
                    crop = this.Patch;
                }
            }

            // 西
            col = pCol - 1;
            row = pRow;
            if (-1 < col)
            {
                if (
                    ucMain.Cells[this.Layer, row, col].MapchipCrop != this.Patch &&
                    ucMain.Cells[this.Layer, row, col].ImageType != ImageType.Border_Sunachi
                    )
                {
                    // 塗りつぶすぜ☆（＾▽＾）
                    crop = this.Patch;
                }
            }


            // 更新☆
            if (crop!=MapchipCrop.None)
            {
                ucMain.Cells[this.Layer, pRow, pCol].MapchipCrop = crop;
                ucMain.Cells[this.Layer, pRow, pCol].ImageType = this.ImageType;
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

                //────────────────────────────────────────
                // まず、ここに施設を置くぜ☆（＾▽＾）
                //────────────────────────────────────────

                // （更新）中央
                ucMain.Cells[this.Layer, centerRow, centerCol].MapchipCrop = this.Patch;
                ucMain.Cells[this.Layer, centerRow, centerCol].ImageType = ImageType.Border_Sunachi;

                //────────────────────────────────────────
                // 4近傍は、更新の候補だぜ☆（＾▽＾）
                //────────────────────────────────────────

                // 次は4近傍を、12時の方角から時計回りで見ていくぜ☆（＾▽＾）
                //
                // xox
                // oxo
                // xox
                //

                // （更新）北
                col = centerCol;
                row = centerRow - 1;
                if (-1 < row &&
                        ucMain.Cells[this.Layer, row, col].MapchipCrop != this.Patch &&
                        ucMain.Cells[this.Layer, row, col].ImageType != ImageType.Border_Sunachi
                    )
                {
                    this.UpdateBoarder_Sub(ucMain, row, col);
                }

                // （更新）東
                col = centerCol + 1;
                row = centerRow;
                if (col < UcMain.TABLE_COLS &&
                        ucMain.Cells[this.Layer, row, col].MapchipCrop != this.Patch &&
                        ucMain.Cells[this.Layer, row, col].ImageType != ImageType.Border_Sunachi
                    )
                {
                    this.UpdateBoarder_Sub(ucMain, row, col);
                }

                // （更新）南
                col = centerCol;
                row = centerRow + 1;
                if (row < UcMain.TABLE_ROWS &&
                        ucMain.Cells[this.Layer, row, col].MapchipCrop != this.Patch &&
                        ucMain.Cells[this.Layer, row, col].ImageType != ImageType.Border_Sunachi
                    )
                {
                    this.UpdateBoarder_Sub(ucMain, row, col);
                }

                // （更新）西
                col = centerCol - 1;
                row = centerRow;
                if (-1 < col &&
                        ucMain.Cells[this.Layer, row, col].MapchipCrop != this.Patch &&
                        ucMain.Cells[this.Layer, row, col].ImageType != ImageType.Border_Sunachi
                    )
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

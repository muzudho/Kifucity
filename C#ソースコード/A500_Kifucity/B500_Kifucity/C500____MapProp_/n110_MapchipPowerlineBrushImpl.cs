using Grayscale.A500_Kifucity.B500_Kifucity.C___400_Image___;
using Grayscale.A500_Kifucity.B500_Kifucity.C___450_Position;
using Grayscale.A500_Kifucity.B500_Kifucity.C___500_MapProp_;
using Grayscale.A500_Kifucity.B500_Kifucity.C450____Position;
using System;
using System.Drawing;

namespace Grayscale.A500_Kifucity.B500_Kifucity.C500____MapProp_
{
    /// <summary>
    /// 送電線／高架送電線を描くブラシだぜ☆（＾～＾）
    /// </summary>
    public class MapchipPowerlineBrushImpl : MapchipRailwayBrush
    {
        public MapchipPowerlineBrushImpl(
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
        /// 元画像は、１種類の道路／線路タイプ、２種類の送電線／高架送電線タイプがあるぜ☆（＾～＾）
        /// </summary>
        public ImageSourcefile[] ImageSourcefiles { get; set; }

        public int GetSourcefileIndex(Position city, int row, int col)
        {
            if (
                city.Cells[PositionImpl.LAYER_ROAD, row, col].ImageType != ImageType.None
                ||
                city.Cells[PositionImpl.LAYER_RAILWAY, row, col].ImageType != ImageType.None
            )
            {
                // 高架送電線にするぜ☆（＾▽＾）
                return 1;
            }
            else
            {
                // 電柱に架けた送電線にするぜ☆（＾▽＾）
                return 0;
            }
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
            MapchipRailwayBrushImpl.UpdateNeighborhood_Inner(
                city, centerRow, centerCol, this.Layer,
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
    }
}

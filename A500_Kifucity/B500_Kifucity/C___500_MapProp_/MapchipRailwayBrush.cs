namespace Grayscale.A500_Kifucity.B500_Kifucity.C___500_MapProp_
{
    /// <summary>
    /// 線路状のマップチップを置くブラシ☆
    /// </summary>
    public interface MapchipRailwayBrush
    {
        /// <summary>
        /// ・
        /// </summary>
        MapchipCrop Point { get; set; }
        /// <summary>
        /// │
        /// </summary>
        MapchipCrop Vertical { get; set; }
        /// <summary>
        /// ─
        /// </summary>
        MapchipCrop Horizontal { get; set; }

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
        MapchipCrop[] Patches { get; set; }

        /// <summary>
        /// 5近傍のマップチップの置き換え
        /// </summary>
        void Update5Neighborhood(UcMain ucMain //MapchipCrop[,,] map
            , int row, int col);

    }
}

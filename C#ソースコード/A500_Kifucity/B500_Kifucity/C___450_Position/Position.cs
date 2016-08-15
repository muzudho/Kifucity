namespace Grayscale.A500_Kifucity.B500_Kifucity.C___450_Position
{
    /// <summary>
    /// ここに都市が入っているぜ☆（＾▽＾）
    /// </summary>
    public interface Position
    {
        /// <summary>
        /// マップの広さ
        /// </summary>
        int TableCols { get; set; }
        int TableRows { get; set; }

        /// <summary>
        /// マップ・データ。[layer,row,col]
        /// </summary>
        Cell[,,] Cells { get; set; }

        void Clear();

        /// <summary>
        /// 初期状態に設定するぜ☆（＾▽＾）
        /// </summary>
        void Init();

        /// <summary>
        /// マップを破棄し、マップのサイズを変えるぜ☆（＾▽＾）
        /// </summary>
        /// <param name="rows"></param>
        /// <param name="cols"></param>
        void ChangeSizeMap(int rows, int cols);
    }
}

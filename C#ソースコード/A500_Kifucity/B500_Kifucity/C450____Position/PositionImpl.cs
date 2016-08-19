using Grayscale.A500_Kifucity.B500_Kifucity.C___450_Position;
using Grayscale.A500_Kifucity.B500_Kifucity.C___400_Image___;

namespace Grayscale.A500_Kifucity.B500_Kifucity.C450____Position
{
    /// <summary>
    /// ここに都市が入っているぜ☆（＾▽＾）
    /// </summary>
    public class PositionImpl : Position
    {
        public PositionImpl()
        {
            // マップのサイズ（デフォルト値）
            this.TableCols = 120;
            this.TableRows = 100;

            // メモリ確保☆
            this.Cells = new Cell[PositionImpl.TABLE_LAYERS, this.TableRows, this.TableCols];
            for (int layer = 0; layer < PositionImpl.TABLE_LAYERS; layer++)
            {
                for (int row = 0; row < this.TableRows; row++)
                {
                    for (int col = 0; col < this.TableCols; col++)
                    {
                        this.Cells[layer, row, col] = new CellImpl();
                    }
                }
            }
        }


        /// <summary>
        /// レイヤー。[0]海 [1]陸地相当 [2]道路 [3]鉄道 [4]送電線／高架送電線
        /// </summary>
        public const int LAYER_MARINE = 0;
        public const int LAYER_LAND = 1;
        public const int LAYER_ROAD = 2;
        public const int LAYER_RAILWAY = 3;
        public const int LAYER_POWERLINE = 4;
        public const int TABLE_LAYERS = 5;
        // マスの大きさ
        public const int CELL_W = 16;
        public const int CELL_H = 16;

        /// <summary>
        /// マップの広さ
        /// </summary>
        public int TableCols { get; set; }
        public int TableRows { get; set; }

        /// <summary>
        /// マップ・データ。[layer,row,col]
        /// </summary>
        public Cell[,,] Cells { get; set; }

        public void Clear()
        {
            for (int layer = 0; layer < PositionImpl.TABLE_LAYERS; layer++)
            {
                for (int row = 0; row < this.TableRows; row++)
                {
                    for (int col = 0; col < this.TableCols; col++)
                    {
                        this.Cells[layer, row, col].Clear();
                    }
                }
            }
        }

        /// <summary>
        /// 初期状態に設定するぜ☆（＾▽＾）
        /// </summary>
        public void Init()
        {
            // 海で初期化☆（＾▽＾）
            int layer = PositionImpl.LAYER_MARINE;
            for (int row = 0; row < this.TableRows; row++)
            {
                for (int col = 0; col < this.TableCols; col++)
                {
                    // レイヤー[0] を海で埋め尽くすぜ☆（＾▽＾）
                    this.Cells[layer, row, col].SetValue(
                        ImageType.NormalAnime,
                        (ImageCrop)ImageCropNormalAnime.Frame1,
                        ImageSourcefile.Anime_16x16x8
                        );
                }
            }
        }

        /// <summary>
        /// マップを破棄し、マップのサイズを変えるぜ☆（＾▽＾）
        /// </summary>
        /// <param name="rows"></param>
        /// <param name="cols"></param>
        public void ChangeSizeMap(int rows, int cols)
        {
            // サイズを変える前にクリアー☆
            this.Clear();

            // 海とかを置くぜ☆（＾▽＾）
            this.Init();

            // サイズを変えるぜ☆（＾▽＾）
            this.TableRows = rows;
            this.TableCols = cols;
        }

    }
}

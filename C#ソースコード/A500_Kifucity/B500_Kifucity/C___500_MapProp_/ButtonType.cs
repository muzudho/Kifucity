using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Grayscale.A500_Kifucity.B500_Kifucity.C___500_MapProp_
{
    /// <summary>
    /// ボタンの種類☆　配列の添え字に利用☆
    /// </summary>
    public enum ButtonType
    {
        None,

        se線路,
        se整地,
        do道路,
        bo太ペン,//baバケツ,
        /// <summary>
        /// 送電線／高架送電線 power line
        /// </summary>
        po送電線,
        /*
        /// <summary>
        /// 高架送電線
        /// </summary>
        po送電線2,
        */

        /// <summary>
        /// 列挙型サイズ
        /// </summary>
        Num
    }
}

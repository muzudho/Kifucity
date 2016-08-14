namespace Grayscale.A500_Kifucity.B500_Kifucity.C___500_MapProp_
{
    /// <summary>
    /// ボタンの状態。
    /// Windows.Form.ButtonState との名前被りを回避するために 2 を付けてあるんだぜ☆（＾▽＾）
    /// </summary>
    public enum ButtonState2
    {
        None,

        /// <summary>
        /// 押す前
        /// </summary>
        Pushable,

        /// <summary>
        /// 押す前（マウスを重ねたとき）
        /// </summary>
        Pushable_MouseOver,

        /// <summary>
        /// 押しているとき
        /// </summary>
        Pushed,

        /// <summary>
        /// 押しているとき（マウスを重ねたとき）
        /// </summary>
        Pushed_MouseOver
    }
}

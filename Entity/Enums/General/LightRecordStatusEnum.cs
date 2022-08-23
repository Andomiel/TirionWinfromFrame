using System.ComponentModel;

namespace Entity.Enums
{
    //状态,0 已灭灯，1 已亮灯
    public enum LightRecordStatusEnum
    {
        /// <summary>
        /// 灭灯
        /// </summary>
        [Description("灭灯")]
        LightOff = 0,

        /// <summary>
        /// 亮灯
        /// </summary>
        [Description("亮灯")]
        LightOn = 1,
    }
}

using System.ComponentModel;

namespace Entity.Enums.General
{
    /// <summary>
    /// 执行结果，主要是亮灯设备的结果，0 未执行，1 执行失败， 2执行成功
    /// </summary>
    public enum ExecuteResultEnum
    {
        /// <summary>
        /// 未执行
        /// </summary>
        [Description("未执行")]
        Unexecuted = 0,

        /// <summary>
        /// 执行失败
        /// </summary>
        [Description("执行失败")]
        Failed = 1,

        /// <summary>
        /// 执行成功
        /// </summary>
        [Description("执行成功")]
        Succeed = 2,
    }
}

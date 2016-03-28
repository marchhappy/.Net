using System;

namespace CMS.Services
{
    /// <summary>
    ///   时间委托
    /// </summary>
    /// <description>
    ///   此处为何要用委托时间? 为了特殊需要。如调试，为了将系统的时间重置为某一个特定的时间，总不能一直调你的Windows时间吧？!
    /// </description>
    public static class SystemTime
    {
        /// <summary>
        /// 委托：返回最后一个挂接的方法返回的时间[通过委托挂接到别的函数上，返回的值是最后一个函数的值]。
        /// <para>Gets the system's current data and time. Only change for testing scenarios. Use <see cref="Restore"/> to  reset the function to its default implementation.</para>
        /// </summary>
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2211:NonConstantFieldsShouldNotBeVisible")]
        public static Func<DateTime> Now;   //返回时间的一个委托

        /// <summary>
        /// 初始化。
        /// <para>Inits the <see cref="Now"/> delegate.</para>
        /// </summary>
        static SystemTime()
        {
            Restore();
        }

        /// <summary>
        /// 恢复<see cref="Now"/>函数的默认实现<see cref="DateTimeOffset.Now"/>。
        /// <para>Reverts the <see cref="Now"/> function to its default implementation which just returns <see cref="DateTimeOffset.Now"/>.</para>
        /// </summary>
        public static void Restore()
        {
            Now = () => DateTime.Now;  //使用匿名的委托将当前时间挂接到Now方法
        }
    }
}
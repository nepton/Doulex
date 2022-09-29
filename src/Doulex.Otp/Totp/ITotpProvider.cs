namespace Doulex.Otp.Totp
{
    /// <summary>
    /// 验证码服务
    /// </summary>
    public interface ITotpProvider
    {
        /// <summary>
        /// Generate a one time password for the given time and modifier
        /// </summary>
        /// <param name="modifier">Can be null or mobile number, Email etc</param>
        /// <param name="time">生成指定时间的CODE</param>
        /// <returns></returns>
        string Generate(string? modifier, DateTime time);

        /// <summary>
        /// Generate a one time password for the given modifier
        /// </summary>
        /// <param name="modifier">Can be null or mobile number, Email etc</param>
        /// <returns></returns>
        string Generate(string? modifier);

        /// <summary>
        /// Generate a one time password for the given time
        /// </summary>
        /// <param name="time">生成指定时间的CODE</param>
        /// <returns></returns>
        string Generate(DateTime time);

        /// <summary>
        /// Generate a one time password
        /// </summary>
        /// <returns></returns>
        string Generate();
    }
}

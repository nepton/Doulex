namespace Doulex.Otp.Totp
{
    /// <summary>
    /// 验证码
    /// </summary>
    public class TotpProviderOptions
    {
        public TotpProviderOptions()
        {
            SecurityToken      = "去登顶哈巴雪山:)";
            EffectiveInSeconds = 180;
            LengthOfCode       = 6;
        }

        /// <summary>
        /// 签名的安全密钥, 这个密钥是一个字符串
        /// </summary>
        public string SecurityToken { get; set; }

        /// <summary>
        /// 验证码有效时间范围
        /// </summary>
        public int EffectiveInSeconds
        {
            get;
            set;
        }

        /// <summary>
        /// 验证码的长度, 不可超过8位
        /// </summary>
        public int LengthOfCode
        {
            get;
            set;
        }
    }
}

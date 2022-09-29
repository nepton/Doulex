using System.Diagnostics;
using System.Net;
using System.Security.Cryptography;
using System.Text;

namespace Doulex.Otp.Totp
{
    /// <summary>
    /// 提供安全码的生成程序, 安全码生成后, 在指定时间内有效
    /// </summary>
    public class TotpProvider : ITotpProvider
    {
        /// <summary>
        /// 验证码的长度
        /// </summary>
        private readonly int _lengthOfCode;

        /// <summary>
        /// token 密钥
        /// </summary>
        private readonly byte[] _securityTokenBytes;

        public TotpProvider(TotpProviderOptions config) : this(config.SecurityToken, config.EffectiveInSeconds, config.LengthOfCode)
        {
        }

        public TotpProvider(string securityToken, int effectiveTimeInSeconds, int lengthOfCode)
        {
            if (string.IsNullOrEmpty(securityToken))
                throw new ArgumentException("Missing verification code security token");

            if (lengthOfCode < 1 || lengthOfCode > 8)
                throw new ArgumentOutOfRangeException("");

            _lengthOfCode       = lengthOfCode;
            _timeStep           = TimeSpan.FromSeconds(effectiveTimeInSeconds);
            _securityTokenBytes = MD5.Create().ComputeHash(Encoding.Default.GetBytes(securityToken));
        }

        #region Implementation of IVerificationCodeProvider

        /// <summary>
        /// Generate a one time password for the given modifier
        /// </summary>
        /// <param name="modifier">Can be null or mobile number, Email etc</param>
        /// <returns></returns>
        public string Generate(string? modifier)
        {
            return Generate(modifier, DateTime.UtcNow);
        }

        /// <summary>
        /// Generate a one time password for the given time
        /// </summary>
        /// <param name="time">生成指定时间的CODE</param>
        /// <returns></returns>
        public string Generate(DateTime time)
        {
            return Generate(null, time);
        }

        /// <summary>
        /// Generate a one time password
        /// </summary>
        /// <returns></returns>
        public string Generate()
        {
            return Generate(null, DateTime.UtcNow);
        }

        /// <summary>
        /// Generate a one time password for the given time and modifier
        /// </summary>
        /// <param name="modifier">Can be null or mobile number, Email etc</param>
        /// <param name="time">生成指定时间的CODE</param>
        /// <returns></returns>
        public string Generate(string? modifier, DateTime time)
        {
            var code = GenerateCore(_securityTokenBytes, modifier, time).ToString($"D{_lengthOfCode}");
            return code;
        }

        #endregion

        #region RFC2638

        private readonly DateTime _unixEpoch = new DateTime(1970, 1, 1, 0, 0, 0, DateTimeKind.Utc);
        private readonly TimeSpan _timeStep;
        private readonly Encoding _encoding = new UTF8Encoding(false, true);

        private int GenerateCore(byte[] securityToken, string? modifier, DateTime dateTime)
        {
            if (securityToken == null)
            {
                throw new ArgumentNullException(nameof(securityToken));
            }

            var       currentTimeStep = GetTimeStepNumber(dateTime);
            using var hashAlgorithm   = new HMACSHA1(securityToken);
            return ComputeTotp(hashAlgorithm, currentTimeStep, modifier);
        }

        private int ComputeTotp(HashAlgorithm hashAlgorithm, ulong timeStepNumber, string? modifier)
        {
            // # of 0's = length of pin
            int mod = (int) Math.Pow(10, _lengthOfCode);

            // See https://tools.ietf.org/html/rfc4226
            // We can add an optional modifier
            var timeStepAsBytes = BitConverter.GetBytes(IPAddress.HostToNetworkOrder((long) timeStepNumber));
            var hash            = hashAlgorithm.ComputeHash(ApplyModifier(timeStepAsBytes, modifier));

            // Generate DT string
            var offset = hash[^1] & 0xf;
            Debug.Assert(offset + 4 < hash.Length);
            var binaryCode = (hash[offset] & 0x7f) << 24
                             | (hash[offset + 1] & 0xff) << 16
                             | (hash[offset + 2] & 0xff) << 8
                             | (hash[offset + 3] & 0xff);

            return binaryCode % mod;
        }

        private byte[] ApplyModifier(byte[] input, string? modifier)
        {
            if (String.IsNullOrEmpty(modifier))
            {
                return input;
            }

            var modifierBytes = _encoding.GetBytes(modifier);
            var combined      = new byte[checked(input.Length + modifierBytes.Length)];
            Buffer.BlockCopy(input,         0, combined, 0,            input.Length);
            Buffer.BlockCopy(modifierBytes, 0, combined, input.Length, modifierBytes.Length);
            return combined;
        }

        // More info: https://tools.ietf.org/html/rfc6238#section-4

        private ulong GetTimeStepNumber(DateTime time)
        {
            var delta = time.ToUniversalTime() - _unixEpoch;
            return (ulong) (delta.Ticks / _timeStep.Ticks);
        }

        #endregion
    };
}

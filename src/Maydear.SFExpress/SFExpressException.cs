using System;
using System.Collections.Generic;
using System.Text;
using Maydear.SFExpress.Internal.Responses;

namespace Maydear.SFExpress
{
    /// <summary>
    /// 顺丰快递异常
    /// </summary>
    public class SFExpressException : Exception
    {
        /// <summary>
        /// 错误码
        /// </summary>
        public int Code { get; private set; }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="code"></param>
        /// <param name="message"></param>
        public SFExpressException(int code, string message) : base(message)
        {
            Code = code;
        }


        /// <summary>
        /// 
        /// </summary>
        /// <param name="errorBody"></param>
        /// <returns></returns>
        internal static SFExpressException ThrowException(ErrorBody errorBody)
        {
            return new SFExpressException(errorBody.Code, errorBody.Message);
        }
    }
}

// 全局的统一服务器响应对象，通过泛型达到超级高复用
using System;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace B_MALL.Common
{
    [Serializable]
    public class ServerResponse<T>
    {
        private int status;
        private String msg;
        private T data;
        private ServerResponse(int status)
        {
            this.status = status;
        }
        private ServerResponse(int status, T data)
        {
            this.status = status;
            this.data = data;
        }
        private ServerResponse(int status, String msg, T data)
        {
            this.status = status;
            this.msg = msg;
            this.data = data;
        }

        private ServerResponse(int status, String msg)
        {
            this.status = status;
            this.msg = msg;
        }
        public bool isSuccess()
        {
            return this.status == (int)ResponseCode.SUCCESS;
        }

        public int getStatus()
        {
            return status;
        }
        public T getData()
        {
            return data;
        }
        public String getMsg()
        {
            return msg;
        }
    }
}
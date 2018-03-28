
// 全局的统一服务器响应对象

using System;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using B_MALL.Common;
using Newtonsoft.Json;

namespace B_MALL.Common
{
    public class ServerResponse<T>
    {
        public int status;
        public String msg;

        [JsonProperty(NullValueHandling=NullValueHandling.Ignore)]
        public T data;
        
        public ServerResponse(int status)
        {
            this.status = status;
        }
        public ServerResponse(int status, T data)
        {
            this.status = status;
            this.data = data;
        }
        public ServerResponse(int status, String msg, T data)
        {
            this.status = status;
            this.msg = msg;
            this.data = data;
        }

        public ServerResponse(int status, String msg)
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
        public static ServerResponse<T> createBySuccess()
        {
            return new ServerResponse<T>((int)ResponseCode.SUCCESS);
        }

        public static  ServerResponse<T> createBySuccessMessage(String msg)
        {
            return new ServerResponse<T>((int)ResponseCode.SUCCESS, msg);
        }

        public static ServerResponse<T> createBySuccess(T data)
        {
            return new ServerResponse<T>((int)ResponseCode.SUCCESS, data);
        }

        public static  ServerResponse<T> createBySuccess(String msg, T data)
        {
            return new ServerResponse<T>((int)ResponseCode.SUCCESS, msg, data);
        }
        public static ServerResponse<T> createByErrorMessage(String errorMessage)
        {
            return new ServerResponse<T>((int)ResponseCode.ERROR, errorMessage);
        }


        public static ServerResponse<T> createByError()
        {
            return new ServerResponse<T>((int)ResponseCode.ERROR);
        }


        

        public static  ServerResponse<T> createByErrorCodeMessage(int errorCode, String errorMessage)
        {
            return new ServerResponse<T>(errorCode, errorMessage);
        }
    }
}
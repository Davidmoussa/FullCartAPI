﻿
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FullCartApp.Application.Contracts.Helper
{
    public class Response<T> 
    {
        public ResponseStatus Status { get; set; }

        public string Message { get; set; }

        public string InternalMessage { get; set; }

        public T Data { get; set; }

        public int SubStatus { get; set; }

        public Response(ResponseStatus success)
        {
        }

        public Response(ResponseStatus status, T data)
        {
            Status = status;
            Data = data;
        }

        public Response(ResponseStatus status, string message, T data)
        {
            Status = status;
            Message = message;
            Data = data;
        }
    }

    public enum ResponseStatus
    {
        Success,
        Error,
        AuthFailure,
        Conflict
    }
}

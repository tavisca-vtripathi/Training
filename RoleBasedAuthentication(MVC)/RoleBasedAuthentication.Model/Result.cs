﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;

namespace RollBasedAuthentication.Model
{
    [DataContract]
    public class Result
    {
        [DataMember]
        public Status Status;
        public Result()
        {
            Status = new Status();
            Status.StatusCode = "200";
            Status.Message = "OK";
        }

    }
}

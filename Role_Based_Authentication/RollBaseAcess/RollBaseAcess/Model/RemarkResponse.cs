﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;


namespace RollBaseAcess.Model
{
    [DataContract]
    public class RemarkResponse : Result
    {
        [DataMember]
        public Remark Remark
        {
            get;
            set;
        }
    }
}

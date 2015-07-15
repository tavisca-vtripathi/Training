﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WebServer.Model
{
    public class RequestParser
    {
        
        public string HttpMethod;
        public string HttpUrl;
        public string HttpProtocolVersion;


        public void Parser(string requestString)
        {
            try
            {
                string[] tokens = requestString.Split(' ');

                tokens[1] = tokens[1].Replace("/", "\\");
                HttpMethod = tokens[0].ToUpper();
                HttpUrl = tokens[1];
                HttpProtocolVersion = tokens[2];
            }
            catch (Exception)
            {
                throw new System.Exception(Resource.BadRequest);
            }
        }
    }
}

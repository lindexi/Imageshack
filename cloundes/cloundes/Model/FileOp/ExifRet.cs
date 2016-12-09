﻿// lindexi
// 16:34

using System;
using System.Collections.Generic;
using System.Diagnostics;
using lindexi.uwp.ImageShack.Model.RPC;
using Newtonsoft.Json;

namespace lindexi.uwp.ImageShack.Model.FileOp
{
    public class ExifValType
    {
        public string val
        {
            get;
            set;
        }

        public int type
        {
            get;
            set;
        }
    }

    public class ExifRet : CallRet
    {
        public ExifRet(CallRet ret)
            : base(ret)
        {
            if (!string.IsNullOrEmpty(Response))
            {
                try
                {
                    Unmarshal(Response);
                }
                catch (Exception e)
                {
                    Debug.WriteLine(e.ToString());
                    this.Exception = e;
                }
            }
        }

        public ExifValType this[string key]
        {
            get
            {
                return dict[key];
            }
        }

        public override string ToString()
        {
            try
            {
                return JsonConvert.SerializeObject(dict).ToString();
            }
            catch
            {
                return string.Empty;
            }
        }

        private Dictionary<string, ExifValType> dict;

        private void Unmarshal(string json)
        {
            dict = JsonConvert.DeserializeObject<Dictionary<string, ExifValType>>(json);
        }
    }
}
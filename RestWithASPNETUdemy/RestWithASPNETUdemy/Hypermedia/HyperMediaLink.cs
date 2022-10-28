﻿using System.Text;

namespace RestWithASPNETUdemy.Hypermedia
{
    public class HyperMediaLink
    {
        public string Rel { get; set; }
        private string href { get; set; }
        public string HRef {
            get
            {
                object _lock = new object();
                lock (_lock)
                {
                    StringBuilder sb = new StringBuilder(href);
                    return sb.Replace("%2F", "/").ToString();
                }
            }
            set {
                href = value;
            }
        }
        public string Type { get; set; }
        public string Action { get; set; }
    }
}

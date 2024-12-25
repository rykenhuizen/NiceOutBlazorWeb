using System;
using System.Collections.Generic;
using System.Diagnostics;

namespace NiceOut.Models
{
    [DebuggerDisplay("DateTime:{dateTime}/{nice_factor}%")]
    public class DevationReport
    {
        public DateTime dateTime;
        public bool historical = false;
        public List<IDevationItem> devationItems;

    }

    [DebuggerDisplay("Value:{value} | Devation:{Devation} | Impact:{Impact} | Message:{Message}")]
    public class DevationItem<T> : IDevationItem
    {
        public T value { get; set; }
        public double Devation { get; set; }
        public int Impact { get; set; }
        public string Message { get; set; }
    }

    public interface IDevationItem
    {
        int Impact { get => Impact; }
        string Message { get => Message; }
    }
}

using System;
using System.Collections.Generic;
using System.Text;

namespace WA.Test.Core.Models
{
    public class TestModel
    {
        public string Id { get; set; }
        public DateTime CreatedTime { get; set; }
        public string Value { get; set; }
        public bool IsTrusted { get; set; }
    }
}

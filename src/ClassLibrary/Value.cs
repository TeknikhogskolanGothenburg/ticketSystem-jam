using Microsoft.Data.OData.Query.SemanticAst;
using System;
using System.Collections.Generic;
using System.Text;

namespace ClassLibrary
{
    public class Value
    {
        public List<Venue> Venues { get; set; } = new List<Venue>();
        public List<SelectItem> Items { get; set; } = new List<SelectItem>();
    }
}

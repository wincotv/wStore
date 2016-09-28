using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace wStoreData.Model
{
    public partial class TFileStructure
    {
        public System.Collections.Generic.List<wStoreData.Model.TFileStructure> Childs { get; set; }
    }
}
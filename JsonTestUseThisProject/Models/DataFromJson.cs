using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Threading.Tasks;

namespace JsonTestUseThisProject.Models
{
    public class DataFromJson
    {
        public ObservableCollection<JsonData> DataList { get; set; }

        public DataFromJson()
        {
            DataList = new ObservableCollection<JsonData>();
        }
    }
}

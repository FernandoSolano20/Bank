using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Web;
using EntitiesPOJO;
using Newtonsoft.Json;

namespace WebApp.Models.Controls
{
    public class CtrlDropDownModel : CtrlBaseModel
    {
        public string Label { get; set; }

        public string ColumnDataName { get; set; }

        public CtrlDropDownModel()
        {
            ViewName = "";
        }
    }
}
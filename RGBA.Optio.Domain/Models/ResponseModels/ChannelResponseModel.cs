using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RGBA.Optio.Domain.Models.ResponseModels
{
    public class ChannelResponseModel
    {
        public string ChannelType { get; set; }
        public long Quantity {  get; set; }
        public long Volume {  get; set; }
        public long Average {  get; set; }

    }
}

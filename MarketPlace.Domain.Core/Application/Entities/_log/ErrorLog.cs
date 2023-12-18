using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MarketPlace.Domain.Core.Application.Entities._log
{
    public class ErrorLog
    {
        public ErrorLog(int errorCode, Dictionary<string,string?> properties)
        {
            ErrorCode = errorCode;
            Properties = "";
            foreach (var property in properties)
            {
                Properties += ($"{property.Key} : {property.Value}\n");
            }
        }
        public ErrorLog()
        {
            
        }
        public int ErrorCode { get; set; }
        public string Properties { get;set; }
        public DateTime LogTime { get; set;} = DateTime.Now; 
    }
}

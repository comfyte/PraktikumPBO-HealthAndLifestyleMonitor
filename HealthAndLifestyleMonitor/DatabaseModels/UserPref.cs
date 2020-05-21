using System;
using System.Collections.Generic;
using System.Text;

namespace HealthAndLifestyleMonitor.DatabaseModels
{
    public class UserPref : IHLDataModel
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public bool BoolValue { get; set; }
        public int IntValue { get; set; }
        public string StringValue { get; set; }
    }
}

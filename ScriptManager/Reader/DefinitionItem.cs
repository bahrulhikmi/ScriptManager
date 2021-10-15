using Common.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace Reader
{
    public class DefinitionItem : IDefinitionItem
    {
        public string Name { get; set; }
        public string IconPath { get; set; }
        public string Label { get; set; }
        public string Category { get; set; }
        public string Path { get; set; }
        public string ScriptFileName { get; set; }

        public object this[string propertyName]
        {
            get
            {
                Type myType = typeof(DefinitionItem);
                PropertyInfo myPropInfo = myType.GetProperty(propertyName);
                return (myPropInfo == null) ? null : myPropInfo.GetValue(this, null);
            }
            set
            {
                Type myType = typeof(DefinitionItem);
                PropertyInfo myPropInfo = myType.GetProperty(propertyName);
                if(myPropInfo != null)
                {
                    myPropInfo.SetValue(this, value, null);
                }
            }
        }
    }
}

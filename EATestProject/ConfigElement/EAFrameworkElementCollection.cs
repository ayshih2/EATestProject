using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EAAutoFramework.ConfigElement
{
    [ConfigurationCollection(typeof(EAFrameworkElement), AddItemName="testSetting", CollectionType =ConfigurationElementCollectionType.BasicMap)]
    class EAFrameworkElementCollection : ConfigurationElementCollection
    {
        protected override ConfigurationElement CreateNewElement()
        {
            return new EAFrameworkElement();
        }

        protected override object GetElementKey(ConfigurationElement element)
        {
            return (element as EAFrameworkElement).Name;
        }

        public new EAFrameworkElement this[string type]
        {
            get
            {
                return (EAFrameworkElement)base.BaseGet(type);
            }
        }
    }
}

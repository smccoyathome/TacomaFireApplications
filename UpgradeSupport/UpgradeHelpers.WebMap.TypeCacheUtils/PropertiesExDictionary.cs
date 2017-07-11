using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
namespace UpgradeHelpers.WebMap.Server
{
	public class PropertiesExDictionary : System.Collections.Generic.Dictionary<string, int>
	{
		public PropertiesExDictionary()
			: base(StringComparer.Ordinal)
		{
            PropertiesList = new List<PropertyInfoEx>();
		}

        public PropertiesExDictionary(PropertiesExDictionary parentDict)
            : base(parentDict, StringComparer.Ordinal)
		{
            PropertiesList = new List<PropertyInfoEx>(parentDict.PropertiesList);
		}

        public PropertyInfoEx GetProperty(string name)
        {
            var index = this[name];
            return PropertiesList[index];
        }

        public void AddProperty(string key,PropertyInfoEx newProp)
        {
            var newIndex = PropertiesList.Count;
            newProp.propertyPositionIndex = (short)newIndex;
            PropertiesList.Add(newProp);
            this.Add(key, newIndex);
        }

		public IList<PropertyInfoEx> PropertiesList { get; set; }

        internal void RemoveProperty(string propertyName)
        {
            int currentPos;
            if (TryGetValue(propertyName,out currentPos))
            {
                this.Remove(propertyName);
                /*for(int i=currentPos+1;i<PropertiesList.Count;i++)
                {
                    var prop = PropertiesList[i];
                    this[prop.prop.Name] = prop.propertyPositionIndex = (short)(i - 1);
                }*/
                PropertiesList[currentPos] = null;
            }
        }
    }

}
using System;
using System.Collections.Generic;
using System.Text;
using System.Drawing;
using System.Resources;

namespace Common
{
    [AttributeUsage(AttributeTargets.Class, Inherited = false, AllowMultiple = true)]
    public class AboutAttribute : Attribute
    {
        readonly string name;
        string organization = "Київський національний університет імені Тараса Шевченка";
        string group;

        string photoResName;

        Type resourceClassType;

        public AboutAttribute(string Name)
        {
            this.name = Name;
        }

        public Type ResourceClassType
        {
            get { return resourceClassType; }
            set { resourceClassType = value; }
        }

        public string PhotoResName
        {
            get { return photoResName; }
            set { photoResName = value; }
        }

        public string Name
        {
            get {return this.name;}
        }

        public string Organization
        {
            get { return organization; }
            set { organization = value; }
        }

        public string Group
        {
            get { return group; }
            set { group = value; }
        }

        public Image Photo
        {
            get
            {
                if (ResourceClassType == null || photoResName == null)
                    return null;
                ResourceManager man = new ResourceManager(ResourceClassType.FullName, ResourceClassType.Assembly);

                return man.GetObject(PhotoResName) as Image;
            }
        }
    }
    
}

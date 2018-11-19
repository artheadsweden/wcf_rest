using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;
using System.Xml;

namespace MyRest
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the class name "RestService" in both code and config file together.
    public class RestService : IRestService
    {
        private List<string> items;

        public RestService()
        {
            items = new List<string>
            {
                "Apa",
                "Banan"
            };
        }

        public string AddItem(string newItem)
        {
            items.Add(newItem);
            return "I got " + newItem;
        }

        public List<string> GetAllItems()
        {
            return items;
        }

        public string PostSeveralItems()
        {
            string JSONstring = OperationContext.Current.RequestContext.RequestMessage.ToString();
            XmlDocument doc = new XmlDocument();
            doc.LoadXml(JSONstring);
            string s = "";
            foreach(XmlNode node in doc.DocumentElement.ChildNodes)
            {
                if(node.Name == "otherItem")
                {
                    s += node.Name + " = " + node.InnerText + " - ";
                }
                else
                {
                    s += "Ignoring key " + node.Name + " - ";
                }
            }
            return s;
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;
using System.Xml;
using System.Xml.Serialization;

namespace OOP_Lab_02
{
    internal class LINQSerializer : ISerializable
    {
        public override void Serialize(object obj)
        {
            base.Serialize(obj);
        }
        public override void Deserialize(string xmlUrl, out List<Employee>? EmployeesList)
        {
            XmlSerializer deserializer = new XmlSerializer(typeof(Employee[]));
            Employee[] EmployeeArray;
            using (FileStream stream = new FileStream(xmlUrl, FileMode.Open))
            {
                EmployeeArray = (Employee[])deserializer.Deserialize(stream);
            }
            EmployeesList = new List<Employee>();
            foreach(Employee Employee in EmployeeArray)
            {
                EmployeesList.Add(Employee);
            }
        }
    }
}

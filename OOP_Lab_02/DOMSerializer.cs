using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;

namespace OOP_Lab_02
{
    internal class DOMSerializer : ISerializable
    {
        public override void Serialize(object obj)
        {

        }
        public override void Deserialize(string xmlUrl, out List<Employee>? EmployeesList)
        {
            EmployeesList = new List<Employee>();
            XmlDocument doc = new XmlDocument();
            string[] st =
            {
                "Id",
                "Name",
                "Departerment",
                "Part",
                "Laboratory",
                "Start",
                "End"
            };

            doc.Load(xmlUrl);
            List<List<string>> ListList = new List<List<string>>();
            List<string> List = new List<string>();

            for (int k = 0; k < 7; k++)
            {
                Funk(st[k], doc, out List);
                ListList.Add(List);
            }

            for (int i = 0; i < ListList[0].Count; i++)
            {
                Facultee facultee = new Facultee(ListList[2][i], ListList[3][i]);
                Title title = new Title(ListList[5][i], ListList[6][i]);
                Employee employee = new Employee(ListList[0][i], ListList[1][i], facultee, ListList[4][i], title);
                EmployeesList.Add(employee);
            }
        }
        private void Funk(string ss, XmlDocument doc, out List<string> List)
        {
            int i = 0;
            List = new List<string>();
            while (i < doc.GetElementsByTagName(ss).Count && doc.GetElementsByTagName(ss)[i].ChildNodes[0].Value != null)
            {
                string temp = doc.GetElementsByTagName(ss)[i].ChildNodes[0].Value;
                List.Add(temp);
                i++;
            }
        }
    }
}

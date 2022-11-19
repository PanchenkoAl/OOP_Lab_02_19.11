using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OOP_Lab_02
{
    public abstract class ISerializable
    {
        public virtual void Serialize(object obj)
        {

        }
        public virtual void Deserialize(string xmlUrl, out List<Employee>? EmployeesList)
        {
            EmployeesList = new List<Employee>();
        }
    }
}

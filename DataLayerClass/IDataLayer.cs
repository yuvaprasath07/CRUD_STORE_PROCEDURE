using EntityDb;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataLayerClass
{
    public interface IDataLayer
    {

        public List<EmployeeModel> getAll();

        public object getEmploye();
        public object addEmployee(PostEmployee postDatas);
        public object UpdateEmployee(EmployeeModel updateemployee);
        public object DeleteEmploye(int id);
    }

}

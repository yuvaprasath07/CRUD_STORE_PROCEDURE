using EntityDb;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer
{
    public interface IBusinessLayre
    {
        public List<EmployeeModel> GetAll();
        public object getEmploye();
        public object addEmployee(PostEmployee postDatas);

        public object UpdateEmployee(EmployeeModel updateemployee);
        public object deleteEmployee(int id);
    }
}

using DataLayerClass;
using EntityDb;

namespace BusinessLayer
{
    public class BusinessLayerClass : IBusinessLayre
    {
        private readonly IDataLayer _dataLayer;
        public BusinessLayerClass(IDataLayer dataLayer)
        {
            _dataLayer = dataLayer;
        }

        public List<EmployeeModel> GetAll()
        {
          return _dataLayer.getAll();
        }

        public object getEmploye()
        {
            return _dataLayer.getEmploye();
        }

        public object addEmployee(PostEmployee postDatas)
        {
           return _dataLayer.addEmployee(postDatas);
        }
        public object UpdateEmployee(EmployeeModel updateemployee)
        {
            return _dataLayer.UpdateEmployee(updateemployee);
        }

        public object deleteEmployee(int id)
        {
            return _dataLayer.DeleteEmploye(id);
        }
    }
}
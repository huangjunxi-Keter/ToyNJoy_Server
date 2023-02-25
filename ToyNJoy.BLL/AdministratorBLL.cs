using ToyNJoy.DAL;
using ToyNJoy.Entity;
using ToyNJoy.Entity.Model;


namespace ToyNJoy.BLL
{
    public class AdministratorBLL
    {
        private AdministratorDAL administratorDAL;
        private ToyNjoyContext context;

        public AdministratorBLL(ToyNjoyContext context)
        {
            this.context = context;
            administratorDAL = new AdministratorDAL(context);
        }

        public Administrator Login(Administrator loginData)
        {
            Administrator loginAdmin = administratorDAL.find(loginData.SaName).FirstOrDefault();
            Administrator result = null;
            if (loginAdmin != null && loginData.SaName == loginAdmin.SaName)
                result = loginAdmin;
            return result;
        }

        public Administrator get(int id) 
        {
            return administratorDAL.get(id);
        }
    }
}

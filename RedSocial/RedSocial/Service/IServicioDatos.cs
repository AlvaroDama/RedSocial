using System.Threading.Tasks;
using RedSocial.Model;

namespace RedSocial.Service
{
    //lo usaremos para el acceso a los datos mobileService.
    public interface IServicioDatos
    {
        #region Usuario

        Task<User> ValidarUsuario(User us);
        Task<User> AddUsuario(User us);
        Task<User> UpdateUsuario(User us);
        Task DeleteUsuario(string id);

        #endregion


    }
}

using System;
using System.Threading.Tasks;
using Microsoft.WindowsAzure.MobileServices;
using RedSocial.Model;
using RedSocial.Util;

namespace RedSocial.Service
{
    public class ServicioDatosImpl:IServicioDatos
    {
        private MobileServiceClient _client;

        public ServicioDatosImpl()
        {
            _client = new MobileServiceClient(Cadenas.UrlServicio, Cadenas.TokenServicio);
        }

        public async Task<User> ValidarUsuario(User us)
        {
            var tabla = _client.GetTable<User>();
            var data = await tabla.CreateQuery().
                Where(o => o.Login == us.Login && o.Password == us.Password).
                ToListAsync();

            if (data.Count.Equals(0))
                return null;

            return data[0];
        }

        public async Task<User> AddUsuario(User us)
        {
            var tabla = _client.GetTable<User>();
            var data = await tabla.CreateQuery().
                Where(o => o.Login == us.Login).
                ToListAsync();

            if (data.Count>0)
                throw new Exception("Usuario ya registrado");

            try
            {
                await tabla.InsertAsync(us);
            }
            catch (Exception)
            {
                throw new Exception("Error al dar de alta.");
            }

            return us;
        }

        public Task<User> UpdateUsuario(User us)
        {
            throw new NotImplementedException();
        }

        public Task DeleteUsuario(string id)
        {
            throw new NotImplementedException();
        }
    }
}

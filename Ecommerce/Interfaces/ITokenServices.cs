using Ecommerce.Models;

namespace Ecommerce.Interfaces
{
    public interface ITokenServices
    {
        public Task<string> createToken(User user);

    }
}

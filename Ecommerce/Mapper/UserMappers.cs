using Ecommerce.Dtos.User;
using Ecommerce.Models;

namespace Ecommerce.Mapper
{
    public static class UserMappers
    {
        public static UserDto ToUserDto(this User user)
        {
            return new UserDto
            {
                Id = user.Id,
                Email = user.Email!,
                UserName = user.UserName!,
            };
        }
    }

}

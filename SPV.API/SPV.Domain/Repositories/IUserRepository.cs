using SPV.Domain.Entities;

namespace SPV.Core.Repositories
{
	public interface IUserRepository
	{
		void CreateUser(User user);
	}
}

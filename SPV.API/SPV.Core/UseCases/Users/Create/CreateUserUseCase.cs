using SPV.Core.Repositories;
using SPV.Domain.Entities;

namespace SPV.Core.UseCases.Users.Create
{
	public class CreateUserUseCase : ICreateUserUseCase
	{
		private readonly IUserRepository userRepository;

		public CreateUserUseCase(IUserRepository userRepository)
		{
			this.userRepository = userRepository;
		}

		public void Execute(CreateUserInput input, IPresenter<ErrorOutput> presenter)
		{
			//todo validate input and respond with errors
			var user = MapUser(input);
			userRepository.CreateUser(user);
			presenter.RespondWithSuccess();
		}

		private User MapUser(CreateUserInput input)
		{
			return new User
			{
				Name = input.Name,
				UserType = input.UserType
			};
		}
	}
}

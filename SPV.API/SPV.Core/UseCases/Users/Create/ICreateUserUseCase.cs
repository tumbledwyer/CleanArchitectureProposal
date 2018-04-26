namespace SPV.Core.UseCases.Users.Create
{
	public interface ICreateUserUseCase
	{
		void Execute(CreateUserInput input, IPresenter<ErrorOutput> presenter);
	}
}
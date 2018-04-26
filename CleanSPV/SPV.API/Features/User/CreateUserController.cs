using System.Web.Http;
using SPV.API.Presenters;
using SPV.Core;
using SPV.Core.UseCases.Users.Create;

namespace SPV.API.Features.User
{
	[RoutePrefix("api/user")]
	public class CreateUserController : ApiController
	{
		private readonly ICreateUserUseCase useCase;

		public CreateUserController(ICreateUserUseCase useCase)
		{
			this.useCase = useCase;
		}

		[Route("create")]
		public IHttpActionResult Create(CreateUserInput input)
		{
			var presenter = new RestfulPresenter<ErrorOutput>(this);
			useCase.Execute(input, presenter);
			return presenter.Render();
		}
	}
}
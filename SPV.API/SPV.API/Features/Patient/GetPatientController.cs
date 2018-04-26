using System.Web.Http;
using SPV.API.Presenters;
using SPV.Core;
using SPV.Core.UseCases.Patients.Get;

namespace SPV.API.Features.Patient
{
	[RoutePrefix("api/patient")]
	public class GetPatientController : ApiController
	{
		private readonly IGetPatientUseCase getPatientUseCase;

		public GetPatientController(IGetPatientUseCase getPatientUseCase)
		{
			this.getPatientUseCase = getPatientUseCase;
		}

		public IHttpActionResult Get(GetPatientInput input)
		{
			var presenter = new RestfulOutputPresenter<GetPatientOutput, ErrorOutput>(this);
			getPatientUseCase.Execute(input, presenter);
			return presenter.Render();
		}
	}
}
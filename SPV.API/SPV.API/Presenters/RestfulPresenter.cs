using System.Net;
using System.Web.Http;
using System.Web.Http.Results;
using SPV.Core;

namespace SPV.API.Presenters
{
	public class RestfulPresenter<TError> : IPresenter<TError>
	{
		private readonly ApiController controller;
		private TError error;
		private bool defaultOutput;

		public RestfulPresenter(ApiController controller)
		{
			this.controller = controller;
		}

		public void RespondWithSuccess()
		{
			this.defaultOutput = true;
		}

		public void RespondWithError(TError errorOutput)
		{
			this.error = errorOutput;
		}

		public IHttpActionResult Render()
		{
			//todo check for multiple responses and make a little more sophisticated
			if (defaultOutput)
			{
				return new OkResult(controller);
			}
			
			return new NegotiatedContentResult<TError>(HttpStatusCode.BadRequest, error, controller);
		}
	}
}
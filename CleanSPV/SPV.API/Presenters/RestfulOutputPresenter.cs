using System.Net;
using System.Web.Http;
using System.Web.Http.Results;
using SPV.Core;

namespace SPV.API.Presenters
{
	public class RestfulOutputPresenter<TSuccess, TError> : IPresenter<TSuccess, TError>
	{
		private readonly ApiController controller;
		private TSuccess success;
		private TError error;

		public RestfulOutputPresenter(ApiController controller)
		{
			this.controller = controller;
		}

		public void RespondWithSuccess(TSuccess successOutput)
		{
			this.success = successOutput;
		}

		public void RespondWithError(TError errorOutput)
		{
			this.error = errorOutput;
		}

		public IHttpActionResult Render()
		{
			//todo check for multiple responses and make a little more sophisticated
			if (success != null)
			{
				return new OkNegotiatedContentResult<TSuccess>(success, controller);
			}
			
			return new NegotiatedContentResult<TError>(HttpStatusCode.BadRequest, error, controller);
		}
	}
}
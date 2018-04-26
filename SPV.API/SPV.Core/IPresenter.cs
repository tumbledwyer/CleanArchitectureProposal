namespace SPV.Core
{
	public interface IPresenter<in TSuccess, in TError>
	{
		void RespondWithSuccess(TSuccess successOutput);
		void RespondWithError(TError errorOutput);
	}

	public interface IPresenter<in TError>
	{
		void RespondWithSuccess();
		void RespondWithError(TError errorOutput);
	}
}
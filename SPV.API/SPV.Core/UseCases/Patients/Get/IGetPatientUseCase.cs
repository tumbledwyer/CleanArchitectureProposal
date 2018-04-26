namespace SPV.Core.UseCases.Patients.Get
{
	public interface IGetPatientUseCase
	{
		void Execute(GetPatientInput input, IPresenter<GetPatientOutput, ErrorOutput> presenter);
	}
}
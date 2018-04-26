using System.Collections.Generic;
using SPV.Domain.Entities;
using SPV.Domain.Repositories;

namespace SPV.Core.UseCases.Patients.Get
{
	public class GetPatientUseCase : IGetPatientUseCase
	{
		private readonly IPatientRepository patientRepository;

		public GetPatientUseCase(IPatientRepository patientRepository)
		{
			this.patientRepository = patientRepository;
		}
		public void Execute(GetPatientInput input, IPresenter<GetPatientOutput, ErrorOutput> presenter)
		{
			//todo validate input
			var patient = patientRepository.GetPatient(input.ClinicomNumber);
			if (patient == null)
			{
				//todo extract error builder
				var errorOutput = new ErrorOutput { Errors = new List<string> { "Can't find patient" } };
				presenter.RespondWithError(errorOutput);
				return;
			}
			var output = Map(patient);
			presenter.RespondWithSuccess(output);
		}

		private GetPatientOutput Map(Patient patient)
		{
			return new GetPatientOutput
			{
				ClinicomNumber = patient.ClinicomNumber,
				Name = patient.Name
			};
		}
	}
}

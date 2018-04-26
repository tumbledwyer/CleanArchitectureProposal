using SPV.Domain.Entities;
using SPV.Domain.Repositories;

namespace SPV.DataAccess.Repositories
{
	public class PatientRepository : IPatientRepository
	{
		public Patient GetPatient(long id)
		{
			return new Patient();
		}
	}
}

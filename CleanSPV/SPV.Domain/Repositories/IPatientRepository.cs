using SPV.Domain.Entities;

namespace SPV.Domain.Repositories
{
	public interface IPatientRepository
	{
		Patient GetPatient(long id);
	}
}

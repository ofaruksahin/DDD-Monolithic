using System;
namespace EShop.Domain.Core
{
	public interface IRepository<TAggregateRoot>
		where TAggregateRoot : IAggregateRoot
	{
		IUnitOfWork UnitOfWork
        {
			get;
        }
	}
}


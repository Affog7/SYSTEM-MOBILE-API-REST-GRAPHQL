using System;
namespace Services.UnitOfWork
{
	public interface IUnitOfWork
	{
        void SaveChanges();
    }
}


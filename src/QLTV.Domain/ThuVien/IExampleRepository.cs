using System;
using Volo.Abp.Domain.Repositories;

namespace QLTV.ThuVien
{
    public interface IExampleRepository : IRepository<Example, Guid>
    {
    }
}
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MyInventories.Utils;
using MyInventories.Repository;

namespace MyInventories.Contract
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Web;
    using System.Web.Mvc;
    public interface IBaseRepository<T>
    {
        List<T> GetAll();
        ErrorCode Create(T t, out String errorMsg);
        ErrorCode Update(object id, T t, out String errorMsg);
        ErrorCode Delete(object id, out String errorMsg);
    }
}

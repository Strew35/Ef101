using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Utilities.Results.Abstract
{
    /// <summary>
    /// Geriye veri göndürecek metotlar için kullanılır
    /// </summary>
    /// <typeparam name="T">Dönecek verinin tipi</typeparam>
    public interface IDataResult<T>:IResult
    {
        T? Data { get; }
    }
}

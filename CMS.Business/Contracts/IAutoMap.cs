using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CMS.Business.Contracts
{
    public interface IAutoMap
    {
        TDestination MapTo<TSource, TDestination>(TSource source);
        TDestination MapTo<TSource, TDestination>(TSource source, TDestination destination);
        TDestination MapTo<TDestination>(object source);
    }
}

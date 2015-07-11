using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OperatorOverloading.Parse
{
    public interface ICurencyConverter
    {   //Interface for the conversion function;
        double GetConversionRate(string from, string to);
    }
}
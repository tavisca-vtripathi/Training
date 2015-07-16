
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CustomAttribute;
using TestMethod.Model.CustomAttribute;

namespace TestMethod.Model
{
    [TestClass]
    class Perimeter
    {
      [TestMethod.Model.CustomAttribute.TestMethod]
        [TestCategory("Smoke Test")]
        public void Pericircle()
        { 
        
        }
        [TestMethod.Model.CustomAttribute.TestMethod]
        public void Perisquare()
        { 
        
        }
        [TestMethod.Model.CustomAttribute.Ignore]
        public void PeriRectangle()
        {
        
        
        }
    }
}

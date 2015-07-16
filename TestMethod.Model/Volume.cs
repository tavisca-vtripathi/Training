using CustomAttribute;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TestMethod.Model.CustomAttribute;

namespace TestMethod.Model
{
    [TestClass]
    class Volume
    {
        [TestMethod.Model.CustomAttribute.TestMethod]
        [TestCategory("Smoke Test")]
        public void VolCylinder()
        { 
        
        }
        [TestMethod.Model.CustomAttribute.TestMethod]
        [Ignore]
        public void VolCube()
        { 
        
        }
        public void VolCuboid()
        { 
        
        
        }
    }
}

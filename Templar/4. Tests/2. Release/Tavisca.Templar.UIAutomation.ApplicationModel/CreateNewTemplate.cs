﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Tavisca.TravelNxt.UIAutomation.Framework.Core;
using Tavisca.TravelNxt.UIAutomation.Framework.Controls;

namespace Tavisca.Templar.UIAutomation.ApplicationModel
{
    public class CreateNewTemplate
    {
        public void SelectCreateNewTemplate() 
        {
            TestManager.ControlMap["Templates.LinkCreateTemplate"].Reset().Click();
        }
    }
}

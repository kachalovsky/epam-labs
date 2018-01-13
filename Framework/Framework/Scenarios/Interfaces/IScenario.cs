using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Framework.Scenarios.Interfaces
{
    interface IScenario<ResultPageType>
    {
        ResultPageType ResultPage { get; }
        void Prepaire();
        void ImplementScenario();
        void FinishScenario();
    }
}

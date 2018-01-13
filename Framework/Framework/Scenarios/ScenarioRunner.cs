using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Framework.Scenarios.Interfaces;

namespace Framework.Scenarios
{
    class ScenarioRunner<ResultPageType>
    {
        Action<ResultPageType> verifyer;
        IScenario<ResultPageType> scenario;
        public ScenarioRunner (IScenario<ResultPageType> scenario, Action<ResultPageType> verifyer)
        {
            this.verifyer = verifyer;
            this.scenario = scenario;
        }

        public void Start()
        {
            scenario.Prepaire();
            scenario.ImplementScenario();
            verifyer(scenario.ResultPage);
            scenario.FinishScenario();
        }
    }
}
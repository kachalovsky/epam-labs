using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hospital
{
    class Departament : IStatistic
    {
        private string name;
        private List<Pacient> pacients = new List<Pacient>();

        public Departament(string name)
        {
            this.name = name;
        }
        public void AddPacient(params Diagnosis[] pasients)
        {
            this.pacients.AddRange(pacients);
        }

        public int CalculateCountOfDiagnosis(Diagnosis diagnosis)
        {
            return pacients.Where(pacient => pacient.IsDiagnosisExists(diagnosis)).Count();
        }
    }
}

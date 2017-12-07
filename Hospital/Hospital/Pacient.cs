using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hospital
{
    class Pacient
    {
        private string name;
        private List<Diagnosis> diagnoses = new List<Diagnosis>();

        public Pacient(string name)
        {
            this.name = name;
        }       
        public void AddDiagnoses(params Diagnosis[] diagnoses)
        {
            this.diagnoses.AddRange(diagnoses);
        }
        public bool IsDiagnosisExists(Diagnosis diagnosis)
        {
            return diagnoses.Contains(diagnosis);
        }
    }
}

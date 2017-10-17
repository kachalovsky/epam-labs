using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hospital
{
    class Hospital
    {

        private string name;
        private List<Departament> departaments = new List<Departament>();

        public Hospital(string name)
        {
            this.name = name;
        }

        public void AddPacient(params Departament[] departaments)
        {
            this.departaments.AddRange(departaments);
        }

        public int CalculateCountOfDiagnosis(Diagnosis diagnosis)
        {
            return departaments.Sum(departament => departament.CalculateCountOfDiagnosis(diagnosis));
        }
    }
}


using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProvaAgenti
{
    public interface IManager<Agente>
    {


        public List<Agente> GetAll();

        public Agente GetByGeographicArea(string areaGeografica);

        public bool GetByCF(string cf);


        public void AddAgente(string nome, string cognome, string cf, string areaGeografica, int annoInizio);

        public void GetByYearOFService(int anniDiServizio);

    }
}


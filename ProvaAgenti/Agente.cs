using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProvaAgenti
{
    class Agente:Persona
    {

        public string AreaGeografica { get; set; }
        public int AnnoInizioAttività { get; set; }



        public Agente()
        {

        }


        public Agente(string nome, string cognome, string codiceFiscale, string areaGeografica, int annoInizioAttività): base(nome, cognome, codiceFiscale)
        {
            AreaGeografica = areaGeografica;
            AnnoInizioAttività = annoInizioAttività;
        }
        public override string ToString()
        {
            return $"CF{CodiceFiscale} - Nome: {Nome}\t Cognome: {Cognome} \t  Area_Geografica:{AreaGeografica} \t AnnoInizioAttività:{AnnoInizioAttività}" ;
        }


    }
}

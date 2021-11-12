using System;
using System.Collections.Generic;

namespace ProvaAgenti
{
    class Program
    {
        private static DBManagerAgenti dbAgenti = new DBManagerAgenti();

        static void Main(string[] args)
        {

            Console.WriteLine("Benvenuto nel Database Agenti di Polizia!");

            bool continua = true;
            while (continua)
            {
                Console.WriteLine("--------------------------------Menu----------------------------");
                Console.WriteLine("Premi 1 per vedere tutti gli agenti di polizia");
                Console.WriteLine("Premi 2 per vedere  gli agenti di polizia per area geografica");
                Console.WriteLine("Premi 3 per vedere per vedere  gli agenti di polizia per anni di servizio");
                Console.WriteLine("Premi 4 per inserire un nuovo agente");
                Console.WriteLine("0. Exit");


                int scelta;
                do
                {
                    Console.WriteLine("Scegli cosa fare!");
                } while (!(int.TryParse(Console.ReadLine(), out scelta) && scelta >= 0 && scelta <= 4));

                switch (scelta)
                {
                    case 1:
                        ViewAll();
                        break;
                    case 2:
                        ViewForGeographicArea();
                        break;
                    case 3:
                        ViewForYearsOfService();
                        break;
                    case 4:
                        InsertNewAgent();
                        break;
                    case 0:
                        continua = false;
                        break;
                }


            }
        }

        private static void ViewForYearsOfService()
        {
            Console.WriteLine("Inserisci il numero di anni di servizio che un agente deve avere per essere visualizzato in elenco\n");
            int anniServizioInput = int.Parse(Console.ReadLine());
            int anno = 2021;
            int anniDiServizio = anno - anniServizioInput;
            dbAgenti.GetByYearOFService(anniDiServizio);
        }

        private static void InsertNewAgent()
        {

            Console.WriteLine("Inserisci il  Codice fiscale dell'agente");
            string cf = Console.ReadLine();
            bool addAgente = dbAgenti.GetByCF(cf);

            if (addAgente == false)
            {
                Console.WriteLine("Inserisci il nome dell'agente da inserire:");
                string nome = Console.ReadLine();
                Console.WriteLine("Inserisci il cognome dell'agente da inserire:");
                string cognome = Console.ReadLine();
                Console.WriteLine("Inserisci l'area geografica dell'agente:");
                string areaGeografica = Console.ReadLine();
                Console.WriteLine("Inserisci l'anno di inizio servizio dell'agente:");
                int annoInizioAttività = int.Parse(Console.ReadLine());
                dbAgenti.AddAgente(nome,cognome,cf, areaGeografica,annoInizioAttività);
            }
            else
            {
                Console.WriteLine("L'agente è già presente nel database!");
            }



        }






            

















private static void ViewForGeographicArea()
        {
            Console.WriteLine("Inserisci l'area geografica d'interesse:\n");
            string areaDaRicercare = Console.ReadLine();
            var a1 = dbAgenti.GetByGeographicArea(areaDaRicercare);
            List<Agente> agentiDiPolizia = new List<Agente>();
            agentiDiPolizia.Add(a1);
            Console.WriteLine("Ecco gli agenti di polizia per area geografica desiderata:");
            foreach (var item in agentiDiPolizia)
            {
                Console.WriteLine(item);
            }
        }

        private static void ViewAll()
        {
            Console.WriteLine("Tutti igli Agenti di Polizia presenti sono:\n");
            List<Agente> agentiDiPolizia = dbAgenti.GetAll();
            int numElenco = 1;

            foreach (var item in agentiDiPolizia)
            {
                Console.WriteLine($"{numElenco++}. {item.ToString()}");
            }

        }
    }
}









  


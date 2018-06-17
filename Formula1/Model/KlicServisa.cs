using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace Formula1.Model
{
  public class KlicServisa
    {
        public static async Task PopulateDrivers(ObservableCollection<Driver> ab)
        {
            
            //namestiomo z NuGet package - Microsoft.AspNet.WebApi.Client
            string url = "https://ergast.com/api/f1/2004/1/results.json";
            //zbirka
            
            Mrdata vsa1;
            using (var klient = new HttpClient())
            {
                HttpResponseMessage sp = await klient.GetAsync(url);
                Rootobject ro1;
                ro1 = await sp.Content.ReadAsAsync<Rootobject>();
                vsa1 = ro1.MRData;
            }
            foreach (var x in vsa1.RaceTable.Races)
            {
                foreach (var y in x.Results)
                {
                Driver a = new Driver();
                    a.givenName = y.Driver.givenName;
                    a.familyName = y.Driver.familyName;
                    a.dateOfBirth = y.Driver.dateOfBirth;
                    a.nationality = y.Driver.nationality;
                    a.url = y.Driver.url;
                    ab.Add(a);
                }
            }
        }
        public static async Task PopulateKonstruktor(ObservableCollection<Constructor> ab)
        {

            //namestiomo z NuGet package - Microsoft.AspNet.WebApi.Client
            string url = "https://ergast.com/api/f1/2004/1/results.json";
            //zbirka

            Mrdata vsa1;
            using (var klient = new HttpClient())
            {
                HttpResponseMessage sp = await klient.GetAsync(url);
                Rootobject ro1;
                ro1 = await sp.Content.ReadAsAsync<Rootobject>();
                vsa1 = ro1.MRData;
            }
            foreach (var x in vsa1.RaceTable.Races)
            {
                foreach (var y in x.Results)
                {
                    Constructor a = new Constructor();
                    a.name = y.Constructor.name;
                    a.nationality = y.Constructor.nationality;
                    ab.Add(a);
                }
            }
        }
        public static async Task PopulateRezultati(ObservableCollection<Result> ab, ObservableCollection<Race> ra, ObservableCollection<Driver> dri, ObservableCollection<Constructor> con)
        {

            //namestiomo z NuGet package - Microsoft.AspNet.WebApi.Client
            string url = "https://ergast.com/api/f1/2004/1/results.json";
            //zbirka

            Mrdata vsa1;
            using (var klient = new HttpClient())
            {
                HttpResponseMessage sp = await klient.GetAsync(url);
                Rootobject ro1;
                ro1 = await sp.Content.ReadAsAsync<Rootobject>();
                vsa1 = ro1.MRData;
            }
            foreach (var x in vsa1.RaceTable.Races)
            {
                Race a = new Race();
                a.season = x.season;
                a.raceName = x.raceName;
                ra.Add(a);
                foreach (var y in x.Results)
                {
                    Result b = new Result();
                    b.position = y.position;
                    b.points = y.points;
                    ab.Add(b);
                    Driver d = new Driver();
                    d.familyName = y.Driver.familyName;
                    d.givenName = y.Driver.givenName;
                    dri.Add(d);
                    Constructor c = new Constructor();
                    c.name = y.Constructor.name;
                    con.Add(c);
                }
            }
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace rezervacije
{
    internal class rezklasa
    {
            
        public int ID { get; set; }
        public int KlijentID { get; set; }
        public int UslugaID { get; set; }
        public DateTime Datum { get; set; }
        public TimeSpan Vrijeme { get; set; }

        public rezklasa(int id, int klijentID, int uslugaID, DateTime datum, TimeSpan vrijeme)
        {
            ID = id;
            KlijentID = klijentID;
            UslugaID = uslugaID;
            Datum = datum;
            Vrijeme = vrijeme;
        }

        public string ToCsv()
        {
            return $"{ID},{KlijentID},{UslugaID},{Datum:yyyy-MM-dd},{Vrijeme}";
        }

        public static rezklasa FromCsv(string csvLine)
        {
            var values = csvLine.Split(',');
            return new rezklasa(
                int.Parse(values[0]),
                int.Parse(values[1]),
                int.Parse(values[2]),
                DateTime.Parse(values[3]),
                TimeSpan.Parse(values[4])
            );
        }
    }
}

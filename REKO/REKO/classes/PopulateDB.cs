using System;
using System.Diagnostics;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MongoDB.Bson;
using MongoDB.Driver;

namespace REKO
{
    public class PopulateDB
    {
        public PopulateDB()
        {
        }


        public void Populate()
        {
            PopulateRings();
        }

        private void PopulateRings()
        {
            List<RekoRing> checkList = DatabaseFacade.Instance.GetRekoRings();

            if (!checkList.Any())
            {
                List<RekoRing> ringList = new List<RekoRing>();
                ringList.Add(new RekoRing("Göteborg"));
                ringList.Add(new RekoRing("Borås"));
                ringList.Add(new RekoRing("Partille"));
                ringList.Add(new RekoRing("Stenungsund"));
                ringList.Add(new RekoRing("Mölndal"));
                ringList.Add(new RekoRing("Hästveda"));

                ringList.ForEach(RekoRing => DatabaseFacade.Instance.AddRekoRing(RekoRing));
             }

        }
    }
}

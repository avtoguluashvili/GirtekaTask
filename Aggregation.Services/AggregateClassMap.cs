using Aggregation.Domain;
using CsvHelper.Configuration;

namespace Aggregation.Services
{
    public class AggregateClassMap : ClassMap<AggregateData>
    {
        public AggregateClassMap()
        {
            Map(m => m.Id).Ignore();
            Map(m => m.Name).Name("TINKLAS");
            Map(m => m.OBT).Name("OBT_PAVADINIMAS");
            Map(m => m.Type).Name("OBJ_GV_TIPAS"); ;
            Map(m => m.ObjectNumber).Name("OBJ_NUMERIS");
            Map(m => m.PPlus).Name("P+");
            Map(m => m.PLTime).Name("PL_T");
            Map(m => m.PMinus).Name("P-");
        }
    }
}

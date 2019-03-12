using System.Collections.Generic;

namespace C4S.Model
{
    public class PortfolioElement
    {
        public int Id { get; set; }
        public string Bezeichnung { get; set; }

        public override string ToString()
        {
            return Bezeichnung;
        }
    }
}
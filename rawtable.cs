using System;


namespace datagridview_and_database
{
    public class rawtable : IEquatable<rawtable>
    {
        public string table { get; set; }

        public string cell { get; set; }

        public override string ToString()
        {
            return table + cell;
        }

        public bool Equals(rawtable other)
        {
            if (other == null) return false;
            return (this.cell.Equals(other.cell));
        }
    }
}

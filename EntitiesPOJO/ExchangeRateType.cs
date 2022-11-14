using System;

namespace EntitiesPOJO
{
    public class ExchangeRateType : BaseEntity, IEquatable<ExchangeRateType>
    {
        public int Id { get; set; }
        public double Value { get; set; }
        public DateTime Day { get; set; }
        public Country OriginCountry { get; set; }
        public Country DestinationCountry { get; set; }
        public bool Equals(ExchangeRateType other)
        {
            if (other == null) return false;
            else return this.Day.Equals(other.Day);
        }

        public override int GetHashCode()
        {
            return this.Value.GetHashCode();
        }
    }
}

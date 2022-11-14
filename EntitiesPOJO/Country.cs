using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntitiesPOJO
{
    public class Country : BaseEntity, IEquatable<Country>
    {
        private string _value;
        private bool _convert;

        public Country(bool convert = false)
        {
            _convert = convert;
        }

        public string Value
        {
            get
            {
                var text = _value;
                if (_convert)
                {
                    text = Base64Decode(_value);
                }

                return text;
            }
            set => _value = value;
        }

        public bool Equals(Country other)
        {
            if (other == null) return false;
            else return this.Value.Equals(other.Value);
        }

        public override int GetHashCode()
        {
            return this.Value.GetHashCode();
        }
        public string Base64Decode(string base64EncodedData)
        {
            var base64EncodedBytes = System.Convert.FromBase64String(base64EncodedData);
            return System.Text.Encoding.UTF8.GetString(base64EncodedBytes);
        }
    }
}

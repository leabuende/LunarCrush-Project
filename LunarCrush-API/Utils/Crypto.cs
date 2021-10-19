using System;

namespace Frequency
{
    public class Crypto
    {
        public Crypto(int frequency, string name)
        {
            this.frequency = frequency;
            this.name = name;
        }

        public int frequency { get; set; }
        public string name { get; set; }
    }
}
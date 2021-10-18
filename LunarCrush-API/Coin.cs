using System;

namespace LunarCrush_API
{
    public class Coin
    {
        private string symbol;
        private int cotd;

        public Coin(string symbol, int cotd)
        {
            this.symbol = symbol;
            this.cotd = cotd;
        }

        public string Symbol
        {
            get { return symbol; }
        }

        public int Cotd
        {
            get { return cotd; }
        }
    }

}

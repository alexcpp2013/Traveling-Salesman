using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Security.Cryptography;

namespace aiGenetic
{
    class Rand : RandomNumberGenerator
    {
        RNGCryptoServiceProvider rng = new RNGCryptoServiceProvider();

        public override void GetBytes(byte[] data)
        {
            rng.GetBytes(data);
        }

        public override void GetNonZeroBytes(byte[] data)
        {
            rng.GetNonZeroBytes(data);
        }

        public int Next(int Max)
        {
            byte[] d = new byte[4];
            int v = 0;
            int i = 0;
            rng.GetBytes(d);

            foreach (byte b in d)
                v |= (int)(b << i++);

            return v % Max;
        }
    }
}

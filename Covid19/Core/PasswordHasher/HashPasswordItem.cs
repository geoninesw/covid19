using System;
using System.Collections.Generic;
using System.Text;

namespace Covid19.Core.PasswordHasher
{
    public class HashPasswordItem
    {
        public byte[] SaltByte { get; set; }
        public string SaltString { get; set; }
        public byte[] HashPasswordByte { get; set; }
        public string HashPasswordString { get; set; }

        public string CombineHash { get; set; }
    }
}

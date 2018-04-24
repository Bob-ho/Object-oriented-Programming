using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project1_Asignment
{
    static class Utility
    {
        #region Byte Calculators
        public const ulong KILOBYTE = 1000;
        public const ulong MEGABYTE = 1000 * KILOBYTE;
        public const ulong GIGABYTE = 1000 * MEGABYTE;
        public const ulong TERABYTE = 1000 * GIGABYTE;

        public const ulong KIBIBYTE = 1024;
        public const ulong MEBIBYTE = 1024 * KIBIBYTE;
        public const ulong GIBIBYTE = 1024 * MEBIBYTE;
        public const ulong TEBIBYTE = 1024 * GIBIBYTE;

        struct DataBreakdown
        {
            public ulong DecimalBytes;
            public ulong Kilobytes;
            public ulong Megabytes;
            public ulong Gigabytes;
            public ulong Terabytes;

            public ulong BinaryBytes;
            public ulong Kibibytes;
            public ulong Mebibytes;
            public ulong Gibibytes;
            public ulong Tebibytes;
        }

        private static DataBreakdown Breakdown(ulong dataVolume)
        {
            return new DataBreakdown
            {
                DecimalBytes = dataVolume % KILOBYTE,
                Kilobytes = (dataVolume % MEGABYTE) / KILOBYTE,
                Megabytes = (dataVolume % GIGABYTE) / MEGABYTE,
                Gigabytes = (dataVolume % TERABYTE) / GIGABYTE,
                Terabytes = dataVolume / TERABYTE,

                BinaryBytes = dataVolume % KIBIBYTE,
                Kibibytes = (dataVolume % MEBIBYTE) / KIBIBYTE,
                Mebibytes = (dataVolume % GIBIBYTE) / MEBIBYTE,
                Gibibytes = (dataVolume % TEBIBYTE) / GIBIBYTE,
                Tebibytes = dataVolume / TEBIBYTE
            };
        }

        public static string DecimalBreakdown(ulong dataVolume)
        {
            DataBreakdown db = Breakdown(dataVolume);
            StringBuilder sb = new StringBuilder();

            if (db.Terabytes > 0)
                sb.AppendFormat("{0} TB", db.Terabytes);
            if (db.Gigabytes > 0)
                sb.AppendFormat("{0}{1} GB", sb.Length > 0 ? ", " : "", db.Gigabytes);
            if (db.Megabytes > 0)
                sb.AppendFormat("{0}{1} MB", sb.Length > 0 ? ", " : "", db.Megabytes);
            if (db.Kilobytes > 0)
                sb.AppendFormat("{0}{1} KB", sb.Length > 0 ? ", " : "", db.Kilobytes);
            if (db.DecimalBytes > 0)
                sb.AppendFormat("{0}{1} bytes", sb.Length > 0 ? ", " : "", db.DecimalBytes);

            return sb.ToString();
        }

        public static string BinaryBreakdown(ulong dataVolume)
        {
            DataBreakdown db = Breakdown(dataVolume);
            StringBuilder sb = new StringBuilder();

            if (db.Tebibytes > 0)
                sb.AppendFormat("{0} TiB", db.Terabytes);
            if (db.Gibibytes > 0)
                sb.AppendFormat("{0}{1} GiB", sb.Length > 0 ? ", " : "", db.Gibibytes);
            if (db.Mebibytes > 0)
                sb.AppendFormat("{0}{1} MiB", sb.Length > 0 ? ", " : "", db.Mebibytes);
            if (db.Kibibytes > 0)
                sb.AppendFormat("{0}{1} KiB", sb.Length > 0 ? ", " : "", db.Kibibytes);
            if (db.BinaryBytes > 0)
                sb.AppendFormat("{0}{1} bytes", sb.Length > 0 ? ", " : "", db.BinaryBytes);

            return sb.ToString();
        }
        #endregion
        #region Phone Numbers
        private static Random _RandomNumber = new Random();
        private static string GenerateNumber()
        {
            return string.Format("+61-4{0:00}-{1:000}-{2:000}", _RandomNumber.Next(0, 100), _RandomNumber.Next(0, 1000), _RandomNumber.Next(0, 1000));
        }

        private static List<string> _UsedPhoneNumbers = new List<string>();
        public static string AllocatePhoneNumber()
        {
            string number = GenerateNumber();
            while (_UsedPhoneNumbers.Contains(number))
                number = GenerateNumber();
            _UsedPhoneNumbers.Add(number);
            return number;
        }
        #endregion
    }
}

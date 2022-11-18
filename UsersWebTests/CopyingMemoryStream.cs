using System;
using System.IO;
using System.Linq;
using System.Text;

namespace UsersWebTests
{
    public class CopyingMemoryStream : MemoryStream
    {
        private readonly Func<byte[], char[]> _convertToChars;
        private readonly StringBuilder sb = new();
        public CopyingMemoryStream(Func<byte[], char[]> convertToChars = null)
        {
            _convertToChars = convertToChars ?? (b => Encoding.UTF8.GetChars(b));
        }

        public override void Write(byte[] buffer, int offset, int count)
        {
            sb.Append(_convertToChars(buffer.Take(count).ToArray()));
            base.Write(buffer, offset, count);
        }

        public string Written => sb.ToString();
    }
}

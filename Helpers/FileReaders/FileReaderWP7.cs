using System.Collections.Generic;
using System.IO;
using Microsoft.Xna.Framework;

namespace FarseerPhysicsBaseFramework.Helpers.FileReaders
{
    public class FileReaderWP7 : IFileReader
    {
        public IEnumerable<string> Read(string filePath)
        {
            using (var file = TitleContainer.OpenStream(filePath))
            {
                using (var sr = new StreamReader(file))
                {
                    string line;
                    while ((line = sr.ReadLine()) != null)
                    {
                        yield return line;
                    }
                }
            }
        }
    }
}

using System.Collections.Generic;

namespace FarseerPhysicsBaseFramework.Helpers.FileReaders
{
    public interface IFileReader
    {
        IEnumerable<string> Read(string filePath);
    }
}

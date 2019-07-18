using System;

namespace IteratorForFileAndFolderTree
{
    class FilterByDirectoryValue
    {
        public bool ShowResultAfterFilter(Func<string, bool> filter, string inputUser)
        {
            if (filter(inputUser))
            {
                Console.WriteLine($"Директория {inputUser} соответствует фильтру");
                return true;
            }
            else
            {
                Console.WriteLine("Фильтр говорит иди в жопень!");
                return false;
            }
        }
    }
}

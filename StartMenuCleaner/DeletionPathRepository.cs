using System.Collections.Generic;
using System.Linq;
using DotNet.Globbing;

namespace StartMenuCleaner {

    public interface DeletionPathRepository {

        IEnumerable<Glob> patternsToDelete { get; }

        static DeletionPathRepository defaultInstance => new DeletionPathRepositoryImpl();

    }

    internal class DeletionPathRepositoryImpl: DeletionPathRepository {

        public IEnumerable<Glob> patternsToDelete { get; } = new List<string> {
            @"Programs\Adobe After Effects *.lnk",
            @"Programs\Adobe Audition *.lnk",
            @"Programs\Adobe Media Encoder *.lnk",
            @"Programs\Adobe Premiere Pro *.lnk",
            @"Programs\JetBrains",
            @"Programs\Logi",
            @"Programs\Visual Studio *.lnk",
        }.Select(Glob.Parse).ToList();

    }

}
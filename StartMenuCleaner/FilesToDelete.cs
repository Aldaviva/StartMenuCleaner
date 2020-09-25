using System.Collections.Generic;
using System.Linq;
using DotNet.Globbing;

namespace StartMenuCleaner {

    internal static class FilesToDelete {

        public static IEnumerable<Glob> patterns { get; } = new List<string> {
            @"Programs\Adobe Acrobat *.lnk",
            @"Programs\Adobe Audition *.lnk",
            @"Programs\Adobe Media Encoder *.lnk",
            @"Programs\Adobe Premiere Pro *.lnk",
            @"Programs\JetBrains",
            @"Programs\Logi",
            @"Programs\Visual Studio *.lnk",
        }.Select(Glob.Parse).ToList();

    }

}
using System.Collections.Generic;
using System.Linq;
using DotNet.Globbing;

namespace StartMenuCleaner {

    internal static class FilesToDelete {

        public static IEnumerable<Glob> patterns { get; } = new List<string> {
            @"Programs\Accessories",
            @"Programs\Adobe Acrobat *.lnk",
            @"Programs\Adobe Audition *.lnk",
            @"Programs\Adobe Creative Cloud.lnk",
            @"Programs\Adobe Lightroom Classic.lnk",
            @"Programs\Adobe Media Encoder *.lnk",
            @"Programs\Adobe Photoshop *.lnk",
            @"Programs\Adobe Premiere Pro *.lnk",
            @"Programs\JetBrains",
            @"Programs\Logi",
            @"Programs\Microsoft Office Tools",
            @"Programs\TagScanner",
            @"Programs\Visual Studio *.lnk",
            @"Programs\WinSCP.lnk",
        }.Select(Glob.Parse).ToList();

    }

}
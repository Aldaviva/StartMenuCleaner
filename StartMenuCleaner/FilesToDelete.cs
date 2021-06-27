using System.Collections.Generic;
using System.Linq;
using DotNet.Globbing;

namespace StartMenuCleaner {

    internal static class FilesToDelete {

        public static IEnumerable<Glob> patterns { get; } = new List<string> {
            @"Programs\Accessories",
            @"Programs\Accessibility",
            @"Programs\Administrative Tools",
            @"Programs\Adobe Acrobat *.lnk",
            @"Programs\Adobe After Effects *.lnk",
            @"Programs\Adobe Audition *.lnk",
            @"Programs\Adobe Bridge *.lnk",
            @"Programs\Adobe Creative Cloud.lnk",
            @"Programs\Adobe Dreamweaver *.lnk",
            @"Programs\Adobe Illustrator *.lnk",
            @"Programs\Adobe InDesign *.lnk",
            @"Programs\Adobe Lightroom Classic.lnk",
            @"Programs\Adobe Media Encoder *.lnk",
            @"Programs\Adobe Photoshop *.lnk",
            @"Programs\Adobe Premiere Pro *.lnk",
            @"Programs\Canon Utilities",
            @"Programs\Fiddler 4.lnk",
            @"Programs\Fiddler ScriptEditor.lnk",
            @"Programs\Git",
            @"Programs\Hex Workshop v*",
            @"Programs\JetBrains",
            @"Programs\KeePass 2.lnk",
            @"Programs\Launchy",
            @"Programs\Logi",
            @"Programs\Microsoft Office Tools",
            @"Programs\Outlook.lnk",
            @"Programs\Progress",
            @"Programs\System Tools",
            @"Programs\Steam",
            @"Programs\TagScanner",
            @"Programs\VideoLAN",
            @"Programs\Visual Studio *",
            @"Programs\Winaero Tweaker",
            @"Programs\WinSCP.lnk",
        }.Select(Glob.Parse).ToList();

    }

}
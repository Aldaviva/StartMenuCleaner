using DotNet.Globbing;

namespace StartMenuCleaner;

internal static class FilesToDelete {

    public static IEnumerable<Glob> patterns { get; } = new List<string> {
        @"Programs\7+ Taskbar Tweaker.lnk",
        @"Programs\Accessibility",
        @"Programs\Accessories",
        @"Programs\Administrative Tools",
        @"Programs\Adobe Acrobat*.lnk",
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
        @"Programs\Avidemux *",
        @"Programs\Canon Utilities",
        @"Programs\EVGA",
        @"Programs\Fiddler *.lnk",
        @"Programs\Git Extensions.lnk",
        @"Programs\Git",
        @"Programs\Hex Workshop v*",
        @"Programs\JetBrains",
        @"Programs\KeePass 2.lnk",
        @"Programs\Launchy",
        @"Programs\Logi",
        @"Programs\Maxon",
        @"Programs\Microsoft Edge.lnk",
        @"Programs\Microsoft Office Tools",
        @"Programs\Outlook.lnk",
        @"Programs\Progress",
        @"Programs\Steam",
        @"Programs\System Tools",
        @"Programs\TagScanner",
        @"Programs\VideoLAN",
        @"Programs\Visual Studio *",
        @"Programs\Vivaldi.lnk",
        @"Programs\Winaero Tweaker",
        @"Programs\WinSCP.lnk",
    }.Select(Glob.Parse).ToList();

}
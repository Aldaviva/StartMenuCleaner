namespace StartMenuCleaner;

internal readonly struct FoundStartMenuPath {

    internal readonly string relativePath;
    internal readonly string absolutePath;

    internal FoundStartMenuPath(string absolutePath, string baseDirectory) {
        this.absolutePath = absolutePath;
        relativePath      = Path.GetRelativePath(baseDirectory, absolutePath);
    }

}
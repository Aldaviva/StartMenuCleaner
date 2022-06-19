using static System.Environment.SpecialFolder;

namespace StartMenuCleaner;

public static class Cleaner {

    private static readonly string MACHINE_START_DIRECTORY = getStartMenuDirectory(false);
    private static readonly string USER_START_DIRECTORY    = getStartMenuDirectory(true);

    private static void Main() {
        cleanStartMenu();
    }

    private static void cleanStartMenu() {
        IEnumerable<string> pathsToDelete = from startMenuFileOrDirectory in findFilesAndDirectories(MACHINE_START_DIRECTORY).Concat(findFilesAndDirectories(USER_START_DIRECTORY))
            where FilesToDelete.patterns.Any(glob => glob.IsMatch(startMenuFileOrDirectory.relativePath))
            select startMenuFileOrDirectory.absolutePath;

        foreach (string pathToDelete in pathsToDelete) {
            deleteDirectoryOrFile(pathToDelete);
        }
    }

    private static string getStartMenuDirectory(bool isUser) {
        return Path.Combine(Environment.GetFolderPath(isUser ? ApplicationData : CommonApplicationData), @"Microsoft\Windows\Start Menu");
    }

    private static IEnumerable<FoundStartMenuPath> findFilesAndDirectories(string baseDirectory) {
        return Directory.EnumerateFileSystemEntries(baseDirectory, "*", SearchOption.AllDirectories)
            .Select(path => new FoundStartMenuPath(path, baseDirectory));
    }

    private static void deleteDirectoryOrFile(string pathToDelete) {
        try {
            Directory.Delete(pathToDelete, true);
        } catch (DirectoryNotFoundException) {
            // it doesn't exist, which is what we want, so return successfully
        } catch (IOException) {
            // path may actually be a file, not a directory
            try {
                File.Delete(pathToDelete);
            } catch (UnauthorizedAccessException) {
                try {
                    File.SetAttributes(pathToDelete, FileAttributes.Normal);
                    File.Delete(pathToDelete);
                } catch (UnauthorizedAccessException e2) {
                    Console.WriteLine($"Unable to delete {pathToDelete} due to insufficient permissions: {e2.Message}");
                }
            }
        } catch (Exception e) {
            Console.WriteLine($"Unable to delete {pathToDelete} due to error {e.Message}");
        }
    }

}
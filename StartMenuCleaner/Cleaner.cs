using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using static System.Environment.SpecialFolder;

namespace StartMenuCleaner {

    public static partial class Cleaner {

        private static readonly string MACHINE_START_DIRECTORY = getStartMenuDirectory(false);
        private static readonly string USER_START_DIRECTORY    = getStartMenuDirectory(true);

        private static void Main() {
            cleanStartMenu();
        }

        private static void cleanStartMenu() {
            foreach (string pathToDelete in from startMenuFileOrDirectory in findFilesAndDirectories(MACHINE_START_DIRECTORY).Concat(findFilesAndDirectories(USER_START_DIRECTORY))
                                            where FilesToDelete.patterns.Any(glob => glob.IsMatch(startMenuFileOrDirectory.relativePath))
                                            select startMenuFileOrDirectory.absolutePath) {
                deleteDirectoryOrFile(pathToDelete);
            }
        }

        private static string getStartMenuDirectory(bool isUser) => Path.Combine(Environment.GetFolderPath(isUser ? ApplicationData : CommonApplicationData), @"Microsoft\Windows\Start Menu");

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
                File.Delete(pathToDelete);
            }
        }

    }

}
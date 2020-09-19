using System;
using System.Collections.Generic;
using System.IO;

namespace StartMenuCleaner {

    public static class Cleaner {

        private const string START_DIRECTORY_RELATIVE_TO_APP_DATA = @"Microsoft\Windows\Start Menu";

        private static readonly string USER_START_DIRECTORY    = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData), START_DIRECTORY_RELATIVE_TO_APP_DATA);
        private static readonly string MACHINE_START_DIRECTORY = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.CommonApplicationData), START_DIRECTORY_RELATIVE_TO_APP_DATA);

        private static readonly IReadOnlyCollection<string> PATHS_TO_DELETE = new HashSet<string> {
            @"Programs\Adobe After Effects 2020.lnk",
            @"Programs\Adobe Audition 2020.lnk",
            @"Programs\Adobe Media Encoder 2020.lnk",
            @"Programs\Adobe Premiere Pro 2020.lnk",
            @"Programs\JetBrains",
        };

        private static void Main() {
            cleanStartMenu();
        }

        public static void cleanStartMenu() {
            foreach (string pathToDelete in PATHS_TO_DELETE) {
                deletePathFromStartMenu(pathToDelete);
            }
        }

        private static void deletePathFromStartMenu(string relativePathToDelete) {
            string machineFileToDelete = Path.Combine(MACHINE_START_DIRECTORY, relativePathToDelete);
            string userFileToDelete = Path.Combine(USER_START_DIRECTORY, relativePathToDelete);

            deleteDirectoryOrFile(machineFileToDelete);
            deleteDirectoryOrFile(userFileToDelete);
        }

        private static void deleteDirectoryOrFile(string pathToDelete) {
            try {
                Directory.Delete(pathToDelete, true);
            } catch (DirectoryNotFoundException) {
                // return successfully
            } catch (IOException) {
                // path may actually be a file, not a directory
                File.Delete(pathToDelete);
            }
        }

    }

}
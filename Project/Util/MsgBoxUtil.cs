using System;
using System.Windows;

namespace Universal_Game_Configurator {

    public static class MsgBoxUtil {

        /// <summary>
        ///     Shows message box with error configurations
        /// </summary>
        /// <param name="owner">Parent window</param>
        /// <param name="message">Error message inside message box</param>
        /// <returns></returns>
        public static MessageBoxResult showError(Window owner, String message) {
            return MessageBox.Show(owner, message, "Error", MessageBoxButton.OK, MessageBoxImage.Error);
        }

        /// <summary>
        ///     Shows message box with warning configurations
        /// </summary>
        /// <param name="owner">Parent window</param>
        /// <param name="message">Warning message inside message box</param>
        /// <returns></returns>
        public static MessageBoxResult showWarning(Window owner, String message) {
            return MessageBox.Show(owner, message, "Warning", MessageBoxButton.OK, MessageBoxImage.Warning);
        }

        /// <summary>
        ///     Shows message box with information configurations
        /// </summary>
        /// <param name="owner">Parent window</param>
        /// <param name="message">Message inside message box</param>
        /// <returns></returns>
        public static MessageBoxResult showMessage(Window owner, String message, String title) {
            return MessageBox.Show(owner, message, title, MessageBoxButton.OK, MessageBoxImage.Information);
        }

        /// <summary>
        ///     Shows message box with question configurations
        /// </summary>
        /// <param name="owner">Parent window</param>
        /// <param name="message">Question inside message box</param>
        /// <returns></returns>
        public static MessageBoxResult showConfirmation(Window owner, String message, String title) {
            return MessageBox.Show(owner, message, title, MessageBoxButton.YesNo, MessageBoxImage.Question);
        }

    }
}

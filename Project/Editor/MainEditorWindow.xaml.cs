using System.Windows;
using Universal_Game_Configurator.Editor.ViewModels;

namespace Universal_Game_Configurator.Editor {

    public partial class MainEditorWindow : Window {

        public MainEditorWindow() {
            InitializeComponent();
        }

        public void SetupContext() {
            MainEditorViewModel vm = new MainEditorViewModel();
            this.DataContext = vm;
        }

    }
}

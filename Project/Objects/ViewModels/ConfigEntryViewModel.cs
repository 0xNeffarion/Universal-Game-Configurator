using System;
using System.Collections.Generic;
using System.Windows.Input;

namespace Universal_Game_Configurator {
    public class ConfigEntryViewModel : BaseViewModel {

        private String Initial_Value { get; set; }

        public ConfigEntryViewModel(ConfigEntry entry, Game game) {
            Initialize(entry.Id, entry.Variable, entry.FileIndex, entry.Section, entry.Value, entry.Name, entry.Group,
                game.ConfigFiles, game.Configurator, entry.Description);
        }

        public int Id { get; set; }

        public String Variable { get; set; }

        public int FileIndex { get; set; }

        public String Section { get; set; }

        public Description Description { get; set; }

        public String Value { get; set; }

        public String Name { get; set; }

        public Group Group { get; set; }

        public List<String> Files { get; set; }

        public Configurator Configurator { get; set; }

        public Boolean IsChanged {
            get {
                return !this.Value.Equals(this.Initial_Value);
            }
        }

        public ICommand SaveEntryCommand { get; set; }

        public ConfigEntry ToConfigEntry() {
            return new ConfigEntry(this);
        }

        private void SaveEntry() {
            Configurator.WriteValue(this.ToConfigEntry());
        }

        private void Initialize(int id, string variable, int fileIndex, string section, string value,
                                string name, Group group, List<string> files, Configurator configurator, int descriptionId) {
            this.Id = id;
            this.Variable = variable;
            this.FileIndex = fileIndex;
            this.Section = section;
            this.Value = value;
            this.Name = name;
            this.Group = group;
            this.Files = files;
            this.Initial_Value = value;
            this.Configurator = configurator;
            this.Description = DescriptionUtil.FromId(descriptionId);
            this.SaveEntryCommand = new BaseCommand(SaveEntry);
        }

    }
}

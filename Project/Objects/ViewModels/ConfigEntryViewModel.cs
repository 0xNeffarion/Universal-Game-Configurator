using System;
using System.Collections.Generic;
using System.Text.RegularExpressions;
using System.Windows.Input;
using Universal_Game_Configurator.Configurators;
using Universal_Game_Configurator.Objects.Commands.Base;
using Universal_Game_Configurator.Objects.Data;
using Universal_Game_Configurator.Objects.Data.Helpers;
using Universal_Game_Configurator.Objects.ViewModels.Base;

namespace Universal_Game_Configurator.Objects.ViewModels {
    public class ConfigEntryViewModel : BaseViewModel {

        private String Initial_Value { get; set; }

        public ConfigEntryViewModel(ConfigEntry entry, Game game) {

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


        private void SaveEntry() {
            //Configurator.WriteValue(this.ToConfigEntry());
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

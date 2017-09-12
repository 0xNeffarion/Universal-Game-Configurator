namespace Universal_Game_Configurator.Controls {

    public static class EntryUtil {

        public static EntryType getEntryFromId(int id) {
            switch (id) {
                case 0: return EntryType.IntegerUpDown;
                case 1: return EntryType.StringTextBox;
                case 2: return EntryType.DoubleUpDown;
                case 3: return EntryType.BooleanNormalComboBox;
                case 4: return EntryType.BooleanYesNoComboBox;
                case 5: return EntryType.BooleanBinaryComboBox;
                case 6: return EntryType.DoubleSlider;
                case 7: return EntryType.IntegerSlider;
                case 8: return EntryType.ComboWithDescriptions;
                default: return EntryType.StringTextBox;
            }
        }

    }

    public enum EntryType {
        IntegerUpDown = 0,
        StringTextBox = 1,
        DoubleUpDown = 2,
        BooleanNormalComboBox = 3,
        BooleanYesNoComboBox = 4,
        BooleanBinaryComboBox = 5,
        DoubleSlider = 6,
        IntegerSlider = 7,
        ComboWithDescriptions = 8
    }



}

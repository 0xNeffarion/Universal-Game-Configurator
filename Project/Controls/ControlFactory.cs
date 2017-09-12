using System;
using System.Collections.Generic;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Controls.Primitives;
using Xceed.Wpf.Toolkit;
using Universal_Game_Configurator;
using Universal_Game_Configurator.Objects.Data;

namespace Universal_Game_Configurator.Controls {
    public class ControlFactory {

        private const Decimal RANGE_PH = -999;
        private Grid parentGrid;
        private ListView settingsList;

        public ControlFactory(ref Grid parentGridRef) {
            this.parentGrid = parentGridRef;
        }

        private void ClearGrid() {
            this.parentGrid.Children.Clear();
            GC.Collect();
        }

        private void AddToGrid(ref UIElement element) {
            this.parentGrid.Children.Add(element);
        }

        public UIElement CreateElement(ConfigEntry cfgEntry) {
            UIElement MyElement = null;
            /*
                        switch (cfgEntry.Type) {
                            case EntryType.IntegerUpDown:
                                MyElement = MakeIntegerUpDown(cfgEntry.Default, cfgEntry.Range);
                                break;
                            case EntryType.DoubleUpDown:
                                MyElement = MakeDoubleUpDown(cfgEntry.Default, cfgEntry.Range);
                                break;
                            case EntryType.StringTextBox:
                                MyElement = MakeTextBox(cfgEntry.Default);
                                break;
                            case EntryType.DoubleSlider:
                                MyElement = MakeDoubleSlider(cfgEntry.Default, cfgEntry.Range, cfgEntry.Interval);
                                break;
                            case EntryType.IntegerSlider:
                                MyElement = MakeIntegerSlider(cfgEntry.Default, cfgEntry.Range, cfgEntry.Interval);
                                break;
                            case EntryType.BooleanNormalComboBox:
                                MyElement = MakeNormalBoolCombo(cfgEntry.Default);
                                break;
                            case EntryType.BooleanYesNoComboBox:
                                MyElement = MakeYesNoCombo(cfgEntry.Default);
                                break;
                            case EntryType.BooleanBinaryComboBox:
                                MyElement = MakeBinaryBoolCombo(cfgEntry.Default);
                                break;
                            case EntryType.ComboWithDescriptions:
                                MyElement = MakeComboWithValueDesc(cfgEntry.ValueDesc, cfgEntry.Default);
                                break;
                        }*/

            return MyElement;
        }

        private void ElementValueChanged(object sender, RoutedEventArgs e) {

        }

        private UIElement MakeIntegerUpDown(Object defaultValue = null, Decimal[] ranges = null) {
            IntegerUpDown IntElement = new IntegerUpDown();

            // Create element value limits if they exist
            if (ranges != null) {
                if (ranges.Length > 0) {
                    if (ranges[0] != RANGE_PH) {
                        IntElement.Minimum = Convert.ToInt32(ranges[0]);
                    } else {
                        IntElement.Minimum = Int32.MinValue;
                    }

                    if (ranges.Length > 1) {
                        if (ranges[1] != RANGE_PH) {
                            IntElement.Maximum = Convert.ToInt32(ranges[1]);
                        } else {
                            IntElement.Maximum = Int32.MaxValue;
                        }
                    }
                }
            }

            // Set default value if it exists
            if (defaultValue != null) {
                int val = (int)defaultValue;
                IntElement.Value = val;
            }

            IntElement.ValueChanged += ElementValueChanged;
            return IntElement;
        }

        private UIElement MakeDoubleUpDown(Object defaultValue = null, Decimal[] ranges = null) {
            DoubleUpDown DoubleElement = new DoubleUpDown();

            // Create element value limits if they exist
            if (ranges != null) {
                if (ranges.Length > 0) {
                    if (ranges[0] != RANGE_PH) {
                        DoubleElement.Minimum = Convert.ToDouble(ranges[0]);
                    } else {
                        DoubleElement.Minimum = Double.MinValue;
                    }

                    if (ranges.Length > 1) {
                        if (ranges[1] != RANGE_PH) {
                            DoubleElement.Maximum = Convert.ToDouble(ranges[1]);
                        } else {
                            DoubleElement.Maximum = Double.MaxValue;
                        }
                    }
                }
            }

            // Set default value if it exists
            if (defaultValue != null) {
                Double val = (Double)defaultValue;
                DoubleElement.Value = val;
            }

            DoubleElement.ValueChanged += ElementValueChanged;
            return DoubleElement;
        }

        private UIElement MakeTextBox(Object defaultValue = null) {
            TextBox textElement = new TextBox();

            // Set default value if it exists
            if (defaultValue != null) {
                String val = (String)defaultValue;
                textElement.Text = val;
            }

            textElement.TextChanged += ElementValueChanged;
            return textElement;
        }

        private UIElement MakeNormalBoolCombo(Object defaultValue = null) {
            ComboBox comboElement = new ComboBox();
            ComboBoxItem cb1 = new ComboBoxItem();
            ComboBoxItem cb2 = new ComboBoxItem();

            comboElement.Tag = "BoolNormal";

            cb1.Content = "Disabled";
            cb2.Content = "Enabled";

            comboElement.Items.Add(cb1);
            comboElement.Items.Add(cb2);
            comboElement.SelectedIndex = 0;

            // Set default value if it exists
            if (defaultValue != null) {
                comboElement.SelectedIndex = ((bool)defaultValue) ? 1 : 0;
            }

            comboElement.SelectionChanged += ElementValueChanged;
            return comboElement;
        }

        private UIElement MakeYesNoCombo(Object defaultValue = null) {
            ComboBox comboElement = new ComboBox();
            ComboBoxItem cb1 = new ComboBoxItem();
            ComboBoxItem cb2 = new ComboBoxItem();

            comboElement.Tag = "BoolYesNo";

            cb1.Content = "Disabled";
            cb2.Content = "Enabled";

            comboElement.Items.Add(cb1);
            comboElement.Items.Add(cb2);
            comboElement.SelectedIndex = 0;

            // Set default value if it exists
            if (defaultValue != null) {
                String v = (String)defaultValue;
                comboElement.SelectedIndex = (v.Equals("Yes")) ? 1 : 0;
            }

            comboElement.SelectionChanged += ElementValueChanged;
            return comboElement;
        }

        private UIElement MakeBinaryBoolCombo(Object defaultValue = null) {
            ComboBox comboElement = new ComboBox();
            ComboBoxItem cb1 = new ComboBoxItem();
            ComboBoxItem cb2 = new ComboBoxItem();

            comboElement.Tag = "BoolOneZero";

            cb1.Content = "Disabled";
            cb2.Content = "Enabled";

            comboElement.Items.Add(cb1);
            comboElement.Items.Add(cb2);
            comboElement.SelectedIndex = 0;

            // Set default value if it exists
            if (defaultValue != null) {
                int v = (int)defaultValue;
                comboElement.SelectedIndex = (v == 1) ? 1 : 0;
            }

            comboElement.SelectionChanged += ElementValueChanged;
            return comboElement;
        }

        private UIElement MakeDoubleSlider(Object defaultValue = null, Decimal[] ranges = null, Double interval = -1) {
            Slider sliderElement = new Slider();
            sliderElement.AutoToolTipPrecision = 4;

            // Set value intervals
            if (interval != -1 && interval > 0) {
                sliderElement.TickFrequency = interval;
                sliderElement.IsSnapToTickEnabled = true;
                sliderElement.TickPlacement = TickPlacement.BottomRight;
            }

            sliderElement.Orientation = Orientation.Horizontal;
            sliderElement.AutoToolTipPlacement = AutoToolTipPlacement.TopLeft;

            // Create element value limits if they exist
            if (ranges != null) {
                if (ranges.Length > 0) {
                    if (ranges[0] != RANGE_PH) {
                        sliderElement.Minimum = Convert.ToDouble(ranges[0]);
                    } else {
                        sliderElement.Minimum = Double.MinValue;
                    }

                    if (ranges.Length > 1) {
                        if (ranges[1] != RANGE_PH) {
                            sliderElement.Maximum = Convert.ToDouble(ranges[1]);
                        } else {
                            sliderElement.Maximum = Double.MaxValue;
                        }
                    }
                }
            }

            // Set default value if it exists
            if (defaultValue != null) {
                Double v = (Double)defaultValue;
                sliderElement.Value = v;
            }

            sliderElement.ValueChanged += ElementValueChanged;

            return sliderElement;
        }

        private UIElement MakeIntegerSlider(Object defaultValue = null, Decimal[] ranges = null, Double interval = -1) {
            Slider sliderElement = new Slider();
            sliderElement.AutoToolTipPrecision = 0;

            // Set value intervals
            if (interval != -1 && interval > 0) {
                sliderElement.TickFrequency = Convert.ToInt32(interval);
                sliderElement.IsSnapToTickEnabled = true;
                sliderElement.TickPlacement = TickPlacement.BottomRight;
            }

            sliderElement.Orientation = Orientation.Horizontal;
            sliderElement.AutoToolTipPlacement = AutoToolTipPlacement.TopLeft;

            // Create element value limits if they exist
            if (ranges != null) {
                if (ranges.Length > 0) {
                    if (ranges[0] != RANGE_PH) {
                        sliderElement.Minimum = Convert.ToInt32(ranges[0]);
                    } else {
                        sliderElement.Minimum = Int32.MinValue;
                    }

                    if (ranges.Length > 1) {
                        if (ranges[1] != RANGE_PH) {
                            sliderElement.Maximum = Convert.ToInt32(ranges[1]);
                        } else {
                            sliderElement.Maximum = Int32.MaxValue;
                        }
                    }
                }
            }

            // Set default value if it exists
            if (defaultValue != null) {
                int v = (int)defaultValue;
                sliderElement.Value = v;
            }

            sliderElement.ValueChanged += ElementValueChanged;

            return sliderElement;
        }

        private UIElement MakeComboWithValueDesc(Dictionary<String, String> valDescriptions, Object defaultValue = null) {
            ComboBox comboElement = new ComboBox();

            comboElement.Tag = "ComboValDesc";

            ComboBoxItem cb = null;
            foreach (var val in valDescriptions) {
                cb = new ComboBoxItem();
                cb.Content = val.Value;
                cb.Tag = val.Key;
                comboElement.Items.Add(cb);

                if ((cb.Tag as String).Equals(defaultValue as String)) {
                    comboElement.SelectedItem = cb;
                }
            }

            comboElement.SelectionChanged += ElementValueChanged;
            return comboElement;
        }


    }

}

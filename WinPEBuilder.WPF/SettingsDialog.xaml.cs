﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using MahApps.Metro.Controls;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;
using ControlzEx.Theming;
using System.Text.Json;
using System.Text.Json.Serialization;
using System.IO;
using System.Diagnostics;
using WinPEBuilder.WPF.Configuration.Configuration;
using WinPEBuilder.WPF.Configuration;

namespace WinPEBuilder.WPF
{
    /// <summary>
    /// Interaction logic for SettingsDialog.xaml
    /// </summary>
    public partial class SettingsDialog : MetroWindow
    {
        public static string SettingLocalTheme = Settings.Data.SerialTheme;
        public static string SettingLocalColor = Settings.Data.SerialColor;
        public SettingsDialog()
        {
            InitializeComponent();
            ColorComboBox.SelectedValue = "System.Windows.Controls.ComboBoxItem: " + SettingLocalColor;
            ThemeComboBox.SelectedValue = "System.Windows.Controls.ComboBoxItem: " + SettingLocalTheme;
            //todo fix loading
        }

        private void SaveBtn_Click(object sender, RoutedEventArgs e)
        {
            Settings.Data.SerialColor = SettingLocalColor;
            Settings.Data.SerialTheme = SettingLocalTheme;
            Settings.Save();
            this.DialogResult = true;
        }

        private void ThemeComboBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            ComboBoxItem themeItem = (ComboBoxItem)ThemeComboBox.SelectedItem;
            string Theme = themeItem.Content.ToString();

            switch (Theme)
            {
                case "Dark":
                    MainWindow.Themes = "Dark";
                    SettingLocalTheme = "Dark";
                    break;
                case "Light":
                    MainWindow.Themes = "Light";
                    SettingLocalTheme = "Light";
                    break;
            }
            if (SettingLocalColor == null)
            {
                ThemeManager.Current.ChangeTheme(this, SettingLocalTheme + ".Purple");
            }
            else if (SettingLocalTheme == "Dark" && SettingLocalColor != null)
            {
                ThemeManager.Current.ChangeTheme(this, "Dark." + SettingLocalColor);
            }
            else if (SettingLocalTheme == "Light" && SettingLocalColor != null)
            {
                ThemeManager.Current.ChangeTheme(this, "Light." + SettingLocalColor);
            }
        }

        private void ColorComboBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            string ColorThemeSet = ColorComboBox.SelectedValue.ToString();

            switch (ColorThemeSet)
            {
                case "System.Windows.Controls.ComboBoxItem: Pink":
                    MainWindow.ColorTheme = "Pink";
                    SettingLocalColor = "Pink";
                    break;
                case "System.Windows.Controls.ComboBoxItem: Purple":
                    MainWindow.ColorTheme = "Purple";
                    SettingLocalColor = "Purple";
                    break;
                case "System.Windows.Controls.ComboBoxItem: Blue":
                    MainWindow.ColorTheme = "Blue";
                    SettingLocalColor = "Blue";
                    break;
                case "System.Windows.Controls.ComboBoxItem: Green":
                    MainWindow.ColorTheme = "Green";
                    SettingLocalColor = "Green";
                    break;
                case "System.Windows.Controls.ComboBoxItem: Yellow":
                    MainWindow.ColorTheme = "Yellow";
                    SettingLocalColor = "Yellow";
                    break;
                case "System.Windows.Controls.ComboBoxItem: Orange":
                    MainWindow.ColorTheme = "Orange";
                    SettingLocalColor = "Orange";
                    break;
                case "System.Windows.Controls.ComboBoxItem: Red":
                    MainWindow.ColorTheme = "Red";
                    SettingLocalColor = "Red";
                    break;
            }
            if (SettingLocalTheme == null)
            {
                ThemeManager.Current.ChangeTheme(this, "Dark." + SettingLocalColor);
            }
            else if (SettingLocalColor != null && SettingLocalTheme != null)
            {
                ThemeManager.Current.ChangeTheme(this, SettingLocalTheme + "." + SettingLocalColor);
            }
            else if (SettingLocalColor == null)
            {
                ThemeManager.Current.ChangeTheme(this, SettingLocalTheme + ".Purple");
            }
        }

        private void CancelBtn_Click(object sender, RoutedEventArgs e)
        {
            DialogResult = false;
        }
    }
}

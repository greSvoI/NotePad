﻿using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using System.Windows;

namespace NotePad
{
    /// <summary>
    /// Логика взаимодействия для App.xaml
    /// </summary>
    public partial class App : Application
    {
        private void Application_Startup(object sender, StartupEventArgs e)
        {
                string fileName = e.Args?.FirstOrDefault();
                MainWindow mainWindow;
                if (!string.IsNullOrWhiteSpace(fileName))
                    mainWindow = new MainWindow(fileName);
                else
                    mainWindow = new MainWindow();

                mainWindow.ShowDialog();
            
        }
    }
}

using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using NotePad.Command;

namespace NotePad
{
    class ApplicationView : INotifyPropertyChanged
    {
        Notepad notepad;
        IsRegedit regedit;

        string fileName;
        public bool IsSave { get => notepad.IsSave; set { notepad.IsSave = value;OnPropertyChanged(""); } }
        public string Path { get => notepad.Path; set { notepad.Path = value;OnPropertyChanged(""); } }
        public string Text { get => notepad.Text; set { notepad.Text = value; notepad.IsSave = false;  OnPropertyChanged(""); } }
        public string FileName { get => fileName; set { fileName = value; OnPropertyChanged(""); } }
        public bool AutoRun { get => regedit.autoRun; set { regedit.AutoRun(value); OnPropertyChanged(""); } }

        public ICommand OpenFile => new DelegateCommand(()=>Open());
        public ICommand Create => new DelegateCommand(()=>newNotePad());
        public ICommand SaveFile => new DelegateCommand(()=>notepad.SaveFile());
        public ICommand FormatCS => new DelegateCommand(() => notepad.ChangeRichBox());
        public ICommand SaveAs => new DelegateCommand(() => notepad.SaveAs());
        protected internal void Open()
        {
            OpenFileDialog dialog = new OpenFileDialog();
            if ((bool)dialog.ShowDialog())
            {
                Text = File.ReadAllText(dialog.FileName, Encoding.GetEncoding(1251));
                Path = dialog.FileName;
                FileName = dialog.FileName.Substring(dialog.FileName.LastIndexOf('\\') + 1);
                MainWindow.RichTextBox.Document.Blocks.Clear();

                if (".cs" == FileName.Substring(FileName.LastIndexOf(".")))
                    notepad.OpenCS(dialog.FileName);
                else
                    notepad.OpenTXT(dialog.FileName);
            }
        }

        public ApplicationView()
        {
            notepad = new Notepad();
            regedit = new IsRegedit();
           
        }
        public ApplicationView(string arg)
        {
            notepad = new Notepad();
            Text = File.ReadAllText(arg, Encoding.GetEncoding(1251));
            regedit = new IsRegedit();
            FileName = arg.Substring(arg.LastIndexOf('\\') + 1);
            if (".cs" == FileName.Substring(FileName.LastIndexOf(".")))
                notepad.OpenCS(arg);
            else
                notepad.OpenTXT(arg);
        }
        protected internal void newNotePad()
        {
            try
            {
                string proc = "C:\\Program Files\\NotePadWPF\\NotePadWPF.exe";
                Process process = new Process();
                process.StartInfo.FileName = proc;
                process.Start();

            }
            catch (Exception ex)
            {

                MessageBox.Show(ex.Message);
            }
           
        }

        public event PropertyChangedEventHandler PropertyChanged;
        public void OnPropertyChanged([CallerMemberName]string prop = "")
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(prop));
        }
    }
}

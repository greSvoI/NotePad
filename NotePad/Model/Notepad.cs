using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.IO;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Media;

namespace NotePad
{
    class Notepad:INotifyPropertyChanged
    {
        private string text="";
        private string path;
        private bool isSave;
        public string Text { get => text; set { text = value; OnPropertyChanged(""); } }
        public string Path { get => path; set { path = value; OnPropertyChanged(""); } }
        public bool IsSave { get => isSave;set { isSave = value;OnPropertyChanged(""); } }
        public Notepad()
        {
           
            Run run = new Run();
            Binding binding = new Binding();
            binding.Path = new PropertyPath("Text");
            run.SetBinding(Run.TextProperty, binding);
            MainWindow.RichTextBox.Document.Blocks.Add(new Paragraph(run));
            MainWindow.RichTextBox.Document.LineHeight = 1;
        }
        protected internal void OpenTXT(string path)
        {
            MainWindow.RichTextBox.Document.Blocks.Clear();
            this.path = path;
            Run run = new Run();
            Binding binding = new Binding();
            binding.Path = new PropertyPath("Text");
            run.SetBinding(Run.TextProperty, binding);
            MainWindow.RichTextBox.Document.Blocks.Add(new Paragraph(run));
        }
        protected internal void OpenCS(string path)
        {
            MainWindow.RichTextBox.Document.Blocks.Clear();
            this.path = path;
            MainWindow.RichTextBox.Document.Blocks.Add(new Paragraph(new Run(Text)));
            ChangeRichBox();
        }
        protected internal void SaveFile()
        {
            if (Path != null)
            { File.WriteAllText(Path, Text); IsSave = true; }
        }
        protected internal void SaveAs()
        {
            SaveFileDialog dialog = new SaveFileDialog();
            dialog.Filter = "txt files (*.txt)|*.txt|cs files (*.cs)|*.cs|All files (*.*)|*.*";
            if ((bool)dialog.ShowDialog())
            {
                File.WriteAllText(dialog.FileName, Text);
                IsSave = true;
            }
            else IsSave = false;
        }
        protected internal void ChangeRichBox()
        {
            string temp = File.ReadAllText("syntax.txt");
            string[] word = temp.Split(new string[] { "\r\n" }, StringSplitOptions.RemoveEmptyEntries);
            for (int i = 0; i < word.Length; i++)
            {
                string str = word[i].Trim();
                SetRichBox(MainWindow.RichTextBox.Document.ContentStart, str);
            }
        }
        private void SetRichBox(TextPointer position, string word)
        {
            int indexInRun = 0;
            while (position != null)
            {
                if (position.GetPointerContext(LogicalDirection.Forward) == TextPointerContext.Text)
                {
                    string textRun = position.GetTextInRun(LogicalDirection.Forward);
                    indexInRun = textRun.IndexOf(word);
                    if (indexInRun >= 0)
                    {
                        TextPointer start = position.GetPositionAtOffset(indexInRun);
                        TextPointer end = start.GetPositionAtOffset(word.Length + 1);

                        TextRange range = new TextRange(start, end);
                        string chek = range.Text;
                        if (chek[chek.Length - 1] == ' ' || chek[chek.Length - 1] == ';')
                            range.ApplyPropertyValue(RichTextBox.ForegroundProperty, Brushes.Blue);
                    }
                    else if (indexInRun == -1) indexInRun = 0;
                }

                position = position.GetNextContextPosition(LogicalDirection.Forward);
            }
        }
        public event PropertyChangedEventHandler PropertyChanged;
        public void OnPropertyChanged([CallerMemberName] string prop = "")
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(prop));
        }
    }
}

using Microsoft.Win32;
using System;
using System.IO;
using System.Linq;
using System.Security.AccessControl;
using System.Security.Principal;
using System.Windows;

namespace NotePad
{
    class IsRegedit
    {
		RegistryKey key;
		public bool autoRun;
		public IsRegedit()
        {
			IsRegistry();
        }
        protected internal void IsRegistry()
        {
			string[] enlargement = new string[] { ".txt", ".cs" };
			bool flag = false;
			string path = "C:\\Program Files\\NotePadWPF";
			for (int i = 0; i < enlargement.Length; i++)
            {
                flag = false;
                key = Registry.CurrentUser.OpenSubKey($@"SOFTWARE\Microsoft\Windows\CurrentVersion\Explorer\FileExts\{enlargement[i]}\OpenWithList", true);
                var reg = key.GetValueNames().Where(x => x.Length < 2);
                foreach (var item in reg)
                    if (key.GetValue(item).ToString() == "NotePadWPF.exe")
                    { flag = true;}
				
				if (!flag)
                {
                    char s = char.Parse(reg.LastOrDefault());
                    key.SetValue(Convert.ToChar(s + 1).ToString(), "NotePadWPF.exe");

                }
            }

            if (!Directory.Exists(path))
			{

                try
                {
					
					Directory.CreateDirectory(path);
					string temp = Directory.GetCurrentDirectory();
					string[] files = Directory.GetFiles(temp);
					for (int i = 0; i < files.Length; i++)
						File.Copy(files[i], path + files[i].Substring(files[i].LastIndexOf("\\")), true);
				}
                catch (Exception ex)
                {

					MessageBox.Show("Запустите от имени администратора");
                }
				
			}
		}
		protected internal void AutoRun(bool run)
		{
			key = Registry.CurrentUser.OpenSubKey(@"SOFTWARE\Microsoft\Windows\CurrentVersion\Run", true);
			if (run)
			{ key.SetValue("NotePadWPF", "C:\\Program Files\\NotePad\\NotePadWPF.exe"); autoRun = true; }
			else
			{ key.DeleteValue("NotePadWPF"); autoRun = false; }
			key.Close();
		}
	}
}

using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ClassLibrary
{
    public class FileReadAndWrite
    {
        /// <summary>
        /// Parametre olarak dosya yolundan ve listbox içerisini yoldaki verilerle doldurulması sağlanmaktadır. 
        /// </summary>
        /// <param name="filePath"></param>
        /// <param name="listBox1"></param>
        public static void ListBoxFillPersonInformation(string filePath, ListBox listBox1)
        {
            SortedDictionary<string, SortedDictionary<string, string>> sortGuid;
            sortGuid = new SortedDictionary<string, SortedDictionary<string, string>>();

            FileStream fs = new FileStream(filePath, FileMode.Open, FileAccess.Read);
            StreamReader sr = new StreamReader(fs);
            string person = sr.ReadLine();
            #region ListBoxta görünüm ayarlaması yapılyıor ...
            while (person != null)
            {
                string[] personInfo = person.Split('|');

                if (!sortGuid.ContainsKey(personInfo[1].Trim()))
                {
                    sortGuid.Add(personInfo[1].Trim(), new SortedDictionary<string, string>());
                }
                if (!sortGuid[personInfo[1].Trim()].ContainsKey(personInfo[0].Trim()))
                {
                    sortGuid[personInfo[1].Trim()].Add(personInfo[0].Trim(), personInfo[2].Trim());
                }
                person = sr.ReadLine();
            }
            #endregion

            foreach (var item in sortGuid)
            {
                listBox1.Items.Add(item.Key + " : ");
                foreach (var itemSecond in item.Value)
                {
                    listBox1.Items.Add("        " + itemSecond.Key + "     -   " + itemSecond.Value);
                }
            }

            sr.Close();
            fs.Close();
        }

        /// <summary>
        /// Gerekli bilgilerin alınması ile Guid text dosyasına bilgiler eklenmektedir. 
        /// </summary>
        /// <param name="name"></param>
        /// <param name="phoneNumber"></param>
        /// <param name="city"></param>
        /// <param name="filePath"></param>
        public static void AddGuidInformation(string name, string phoneNumber, string city, string filePath)
        {
            if (File.Exists(filePath))
            {
                FileStream fs = new FileStream(filePath, FileMode.Append, FileAccess.Write);
                StreamWriter sw = new StreamWriter(fs);

                Dictionaries dictionaries = new Dictionaries();
                dictionaries.Name = name;
                dictionaries.PhoneNumber = phoneNumber;
                dictionaries.City = city;

                sw.WriteLine(dictionaries.Name + " | " + dictionaries.City + " | " + dictionaries.PhoneNumber, Environment.NewLine);
                sw.Flush();
                sw.Close();
                fs.Close();
            }
        }
    }
}

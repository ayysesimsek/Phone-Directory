using ClassLibrary;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PhoneDirectory
{
    public partial class Form1 : Form
    {
        #region Text dosyaları yolları tanımlanmıştır. 
        public static string GuidTextFile = "../../Guid.txt";
        public static string CityTextFile = "../../City.txt";
        #endregion

        #region CONSTRUCTOR
        public Form1()
        {
            InitializeComponent();
        }
        #endregion

        #region EVENT

        /// <summary>
        /// Rehbere kişi bilgileri eklenmektedir. 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void button1_Click(object sender, EventArgs e)
        {
            #region Boş kontrolü yapılıyor ... 
            if (String.IsNullOrEmpty(txtName.Text) ||
                String.IsNullOrEmpty(txtPhoneNumber.Text.Trim()) ||
                String.IsNullOrEmpty(cmbCity.Text))
            {
                MessageBox.Show("Lütfen tüm alanları doldurunuz");
            }
            #endregion

            #region Bilgiler eksizsiz ise ekleme işlemi gerçekleşiyor .. 
            else
            {
                FileReadAndWrite.AddGuidInformation(txtName.Text, txtPhoneNumber.Text, cmbCity.Text, GuidTextFile);
                DialogResult result = new DialogResult();
                result = MessageBox.Show("Rehberinize kayıt başarılı bir şekilde gerçekleşmiştir.\nEklenen kaydı rehber listelemede görmek istiyor musunuz ? \nGörmek için 'Yes' - Programı kapatmak için 'No' ya basınız. ","Listeleme Onayı", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if(result == DialogResult.Yes)
                {
                    listBox1.Items.Clear();
                    Application.Restart();
                }
                else
                {
                    Application.Exit();
                }
                
            }
            #endregion

        }

        /// <summary>
        /// Combobox içerisi şehir isimleri ile dolduruluyor.
        /// </summary>
        public void ComboboxFilled()
        {
            if (File.Exists(CityTextFile))
            {
                string[] lines = File.ReadAllLines(CityTextFile);
                for (int i = 0; i < lines.Length; i++)
                {
                    cmbCity.Items.Add(lines[i]);
                }
            }
        }

        /// <summary>
        /// FormLoad ekran ilk açıldığında gerçekleşecek olaylar tanımlanmaktadır. 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Form1_Load(object sender, EventArgs e)
        {
            FileReadAndWrite.ListBoxFillPersonInformation(GuidTextFile, listBox1);
            ComboboxFilled();
        }

        #region İsim girme alanına rakam yazamama kontrolü yapılmaktadır. 
        private void txtName_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = !char.IsLetter(e.KeyChar) && !char.IsControl(e.KeyChar)
                && !char.IsSeparator(e.KeyChar);
        }
        #endregion

        #region Şehir combobox alanına rakam yazamama kontrolü yapılmaktadır. 
        private void cmbCity_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = !char.IsLetter(e.KeyChar) && !char.IsControl(e.KeyChar)
                && !char.IsSeparator(e.KeyChar);
        }
        #endregion


        #endregion
    }
}

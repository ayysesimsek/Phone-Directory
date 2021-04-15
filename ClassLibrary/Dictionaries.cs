using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClassLibrary
{
    public class Dictionaries
    {
        #region Private Members

        /// <summary>
        /// guidId private
        /// </summary>
        private Guid guidID;
        /// <summary>
        /// city private
        /// </summary>
        private string city;
        /// <summary>
        /// name private
        /// </summary>
        private string name;
        /// <summary>
        /// phoneNumber private
        /// </summary>
        private string phoneNumber;

        #endregion

        #region Public Members

        /// <summary>
        /// GuidID gets or sets
        /// </summary>
        public Guid GuidID
        {
            get { return guidID; }
            set { guidID = value; }
        }
        /// <summary>
        /// City gets or sets
        /// </summary>
        public string City
        {
            get { return city; }
            set { city = value; }
        }
        /// <summary>
        /// Name gets or sets
        /// </summary>
        public string Name
        {
            get { return name; }
            set { name = value; }
        }
        /// <summary>
        /// Phone Number gets or sets
        /// </summary>
        public string PhoneNumber
        {
            get { return phoneNumber; }
            set { phoneNumber = value; }
        }

        #endregion

        #region Constructor
        public Dictionaries()
        {
            this.GuidID = Guid.NewGuid();
        }
        #endregion

        #region Methods
        /// <summary>
        /// Parametre olarak gösnderilen listte tutulan verilerin sıralama işlemi gerçekleşmektedir. 
        /// </summary>
        /// <param name="srt"></param>
        public static void Sort(List<string> srt)
        {
            srt.Sort();
        }
        #endregion
    }
}

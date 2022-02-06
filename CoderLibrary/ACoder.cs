using System;

namespace CoderLibrary
{
    /// <summary>
    /// Кодировщик методом Цезаря
    /// </summary>
    public class ACoder : ICoder
    {
        const string alfabet = "АБВГДЕЁЖЗИКЛМНОПРСТУФХЦЧШЩЪЫЬЭЮЯабвгдеёжзиклмнопрстуфцчшщъыьэюя";
        
       /// <summary>
       /// Текст для кодирования
       /// </summary>
        public string TextForCode { get; set; }
        /// <summary>
        /// Текст для раскодирования
        /// </summary>
        public string TextForDeCode { get; set; }
        public string Decode()
        {
            return Coder(TextForDeCode ,- 1);
        }

        public string Encode()
        {
            return Coder(TextForCode,1);
        }

        /// <summary>
        /// Алгоритм кодирования и раскодирования
        /// </summary>
        /// <param name="text - текст для кодирования//раскодирования"></param>
        /// <param name="key - количество знаков отступа, если минус - раскодирование, в противном случае - кодирование"></param>
        /// <returns></returns>
        private string Coder(string text,int key)
        {
            string newText="";

            for (int i = 0; i < text.Length; i++)
            {
                var ch = text[i];
                var index = alfabet.IndexOf(ch);

                if (index < 0)
                {
                    newText += ch.ToString();
                }
                else
                {
                    var codeIndex = (alfabet.Length + index + key) % alfabet.Length;
                    newText += alfabet[codeIndex];
                }
            }

            return newText;
        }
    }
}

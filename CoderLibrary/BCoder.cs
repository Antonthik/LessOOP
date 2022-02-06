using System;

namespace CoderLibrary
{
    /// <summary>
    /// Кодировщик - берем шифровальный символ
    /// в соответствии с регистром и местом в алфавите исходного символа,
    /// но порядковый номер шифровального символа берем с конца алфавита.
    /// </summary>
    public class BCoder : ICoder
    {
        const string alfabet_up = "АБВГДЕЁЖЗИКЛМНОПРСТУФХЦЧШЩЪЫЬЭЮЯ";
        const string alfabet_low = "абвгдеёжзиклмнопрстуфцчшщъыьэюя";
        int size = alfabet_up.Length;
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
            return Coder(TextForDeCode, -1);
        }

        public string Encode()
        {
            return Coder(TextForCode, 1);
        }

        /// <summary>
        /// Алгоритм кодирования и раскодирования
        /// </summary>
        /// <param name="text - текст для кодирования//раскодирования"></param>
        /// <param name="key - количество знаков отступа, если минус - раскодирование, в противном случае - кодирование"></param>
        /// <returns></returns>
        private string Coder(string text, int key)
        {
            string newText = "";
            var k = key / Math.Abs(key);

            for (int i = 0; i < text.Length; i++)
            {
                var ch = text[i];
                //var index = alfabet.IndexOf(ch);
                TakeIndex(ch, out int index);

                if (index < 0)
                {
                    newText += ch.ToString();
                }
                else
                {
                    if (k < 0) key = -(index);
                    if (k > 0) key = (size - index);

                    var codeIndex = (size + key) % size;
                    //newText += alfabet[codeIndex];
                    //var chh= TakeChar[ch, codeIndex];
                    newText += TakeChar(ch,codeIndex);
                }
            }

            return newText;
        }
        /// <summary>
        /// Находим индекс по регистру символа
        /// </summary>
        /// <param name="c"></param>
        /// <param name="index"></param>
        private void TakeIndex (char c,out int index)
        {
            index = -1;
            if (char.IsUpper(c)) 
            {
                 index = alfabet_up.IndexOf(c);
            }
            else
            {
                index = alfabet_low.IndexOf(c);
            }
        }
        /// <summary>
        /// Ищем символ по регистру и по индексу
        /// </summary>
        /// <param name="c"></param>
        /// <param name="codeIndex"></param>
        /// <returns></returns>
        private char TakeChar(char c,int codeIndex)
        {
            if (char.IsUpper(c))
            {
               return alfabet_up[codeIndex];
            }
            else
            {
               return alfabet_low[codeIndex];
            }
        }
    }
    
}

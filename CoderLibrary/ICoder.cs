using System;


namespace CoderLibrary
{
    interface ICoder
    {
        /// <summary>
        /// Метод кодирования текста
        /// </summary>
        /// <returns></returns>
       abstract string Encode();
        /// <summary>
        /// Метод для раскодирования текста
        /// </summary>
        /// <returns></returns>
       abstract string Decode();

    }
}

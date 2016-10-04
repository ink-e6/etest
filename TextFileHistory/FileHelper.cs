using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TextFileHistory
{
    public class FileHelper
    {
        public void createFile()
        {
            FileInfo file = new FileInfo("history.txt");
            if (file.Exists == false) //Если файл не существует
            {
                file.Create(); //Создаем
            }
        }

        //public void writeFile(string text)
        //{
        //    StreamWriter write_text;  //Класс для записи в файл
        //    FileInfo file = new FileInfo("history.txt");
        //    write_text = file.AppendText(); //Дописываем инфу в файл, если файла не существует он создастся
        //    write_text.WriteLine(textBox1.Text); //Записываем в файл текст из текстового поля
        //    write_text.Close(); // Закрываем файл
        //}
    }
}

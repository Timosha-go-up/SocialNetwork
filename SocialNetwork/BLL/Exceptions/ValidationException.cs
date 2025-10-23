using System;
using System.Collections.Generic;
using System.Linq;

namespace SocialNetwork.BLL.Exceptions
{
    public class ValidationException : Exception
    {
        // Свойство только для чтения для хранения ошибок
        public List<string> Errors { get; }

        // Конструктор принимает список ошибок
        public ValidationException(List<string> errors)
        {
            Errors = errors;
        }
    }


    public static class ValidationExceptions
    {
        public static string GetFormattedErrors(ValidationException exception)
        {
            // Проверка на null и пустые ошибки
            if (exception?.Errors == null || !exception.Errors.Any())
                return "Ошибки не обнаружены";

            // Форматирование списка ошибок в строку
            return string.Join(Environment.NewLine, exception.Errors);
        }
    }


}

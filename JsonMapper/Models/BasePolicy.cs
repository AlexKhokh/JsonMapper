using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JsonMapper.Models
{
    public class BasePolicy
    {
        public DateTime DocumentDate { get; set; }      // Дата создания документа
        public DateTime EffectiveDate { get; set; }       // Начало действия ДС
        public DateTime ExpirationDate { get; set; }    // Окончание действия ДС
        public DateTime AcceptationDate { get; set; }   // Дата акцептации ДС
        public Person Insurer { get; set; }             // Страхователь
        public Vehicle Vehicle { get; set; }            // Данные Автомобиля
    }
}

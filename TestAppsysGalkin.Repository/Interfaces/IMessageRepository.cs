using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TestAppsysGalkin.Data.Model;

namespace TestAppsysGalkin.Repository.Interfaces
{
    public interface IMessageRepository : IDisposable
    {
        /// <summary>
        /// Получить коллекцию полученных сообщений
        /// </summary>
        IEnumerable<Message> ReceivedMessages(int UserId);

        /// <summary>
        /// Получить коллекцию отправленных сообщений
        /// </summary>
        IEnumerable<Message> SentMessages(int UserId);

        /// <summary>
        /// Сохранить изменения
        /// </summary>
        void Save();

        /// <summary>
        /// Отправить сообщение
        /// </summary>
        void CreateMessage(int FromUserId, string ToUserName, string msg);
    }
}

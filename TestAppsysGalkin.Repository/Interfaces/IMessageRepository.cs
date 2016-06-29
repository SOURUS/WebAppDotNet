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
        IEnumerable<Message> ReceivedMessages(string UserId);

        /// <summary>
        /// Получить коллекцию отправленных сообщений
        /// </summary>
        IEnumerable<Message> SentMessages(string UserId);

        /// <summary>
        /// Сохранить изменения
        /// </summary>
        void Save();

        /// <summary>
        /// Отправить сообщение
        /// </summary>
        void CreateMessage(string FromUserId, string ToUserName, string msg);
    }
}

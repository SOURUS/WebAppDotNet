using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TestAppsysGalkin.Data.Context;
using TestAppsysGalkin.Data.Model;
using TestAppsysGalkin.Repository.Interfaces;

namespace TestAppsysGalkin.Repository
{
    public class MessageRepository : IMessageRepository
    {
        private readonly MainContext _context;
        private bool disposed = false;

        public MessageRepository()
        {
            _context = new MainContext();
        }

        public IEnumerable<Message> SentMessages(int UserId)
        {
            return _context.Messages.Where(m => m.FromUserId == UserId).ToList();
        }

        public IEnumerable<Message> ReceivedMessages(int UserId)
        {
            return _context.Messages.Where(m => m.ToUserId == UserId).ToList();
        }

        public void CreateMessage(int FromUserId, string ToUserName, string msg)
        {
            _context.Messages.Add(new Message
            {
                Text = msg,
                ToUser = _context.Users.Single(u => u.Login == ToUserName),
                FromUser = _context.Users.Single(u=>u.UserId == FromUserId)
            });

            Save();
        }

        public void Save()
        {
            _context.SaveChanges();
        }

        public virtual void Dispose(bool disposing)
        {
            if (!this.disposed)
            {
                if (disposing)
                {
                    _context.Dispose();
                }
            }
            this.disposed = true;
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }
    }
}

using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TriagingSystem.Models;

namespace TriagingSystem.Services
{
    public interface IUserService
    {
        IEnumerable<UserInfo> getAllUsers();

        UserInfo getUser(long id);

        Boolean isExist(long id);
        int getAge(long id);
        IEnumerable<TrustedContact> getTrustedContact(long id);
        IEnumerable<UserRecord> getUserRecord(long id);
        UserRecord getRecord(long RID);

    }

    public class UserService : IUserService
    {

        private readonly triagingDBContext _db;

        public UserService(triagingDBContext db)
        {
            _db = db;
        }


        public IEnumerable<UserInfo> getAllUsers()
        {
            return _db.UserInfo.ToList();
        }

        public UserInfo getUser(long id)
        {
            return _db.UserInfo.Where(a => a.Id == id).FirstOrDefault();
        }

        public int getAge(long id)
        {
            if (isExist(id))
            {
                UserInfo user = getUser(id);
                DateTime now = DateTime.Now;
                int currentyear = now.Year;
                DateTime dob = (DateTime)user.DoB;
                int dobyear = dob.Year;
                return (currentyear - dobyear);
            }
            else
            {
                return 0;
            }
        }


        public Boolean isExist(long id)
        {
            if (_db.UserInfo.Any(o => o.Id == id)) return true;
            return false;

        }

        public IEnumerable<TrustedContact> getTrustedContact(long id)
        {
            return _db.TrustedContact.Where(_ => _.IdUser == id).OrderBy(_ => _.ContactOrder).ToList();
        }






        public IEnumerable<UserRecord> getUserRecord(long userID)
        {
            return _db.UserRecord.Where(a => a.UserId == userID).ToList();
            // _db.UserRecord.Where(r => r.UserId.Equals(userID)).ToList();
        }
        public UserRecord getRecord(long RID)
        {
            return _db.UserRecord.Where(_ => _.UserId == RID).ToArray()[0];
        }


    }


}

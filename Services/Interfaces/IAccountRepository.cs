using Entities.Base;
using System;
using System.Collections.Generic;
using System.Text;

namespace Services.Interfaces
{
    public interface IAccountRepository
    {
        AccountBase GetById(Guid id);
        List<AccountBase> GetAll();

        bool Update (AccountBase account);

        bool Delete (Guid id);

        bool Add (AccountBase account);


    }
}

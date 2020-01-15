using System;
using System.Collections.Generic;
using UserManagerDAL.Models;

namespace UserManagerDAL.Storage
{
    public class Storages
    {
        private static Storages userStorages;
        private static readonly object syncRoot = new Object();

        private Storages()
        {
            Users = new List<User>(1);
        }

        public List<User> Users { get; set; }

        public static Storages GetStorages()
        {
            if (userStorages == null)
            {
                lock(syncRoot)
                {
                    if(userStorages == null)
                    {
                        userStorages = new Storages();
                    }
                }                
            }

            return userStorages;
        }
    }
}

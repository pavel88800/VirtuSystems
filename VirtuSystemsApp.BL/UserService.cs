using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Newtonsoft.Json;
using VirtuSystemsApp.DB;
using VirtuSystemsApp.DB.Models;

namespace VirtuSystemsApp.BL
{
    public class UserService
    {
        /// <summary>
        ///     Инициализация данных в БД.
        /// </summary>
        /// <returns></returns>
        public async Task AddDataInDbAsync()
        {
            await Task.Run(() =>
            {
                using (var context = new VirtuSystemsDbContex())
                {
                    var items = context.Users.Count();
                    if (items == 0)
                    {
                        var users = new List<User>();
                        for (var i = 1; i <= 10; i++)
                            users.Add(new User
                                {BirthDay = DateTime.Today.Date, Name = "Test_" + i, Phone = "8 888 888 88 88"});

                        context.AddRange(users);
                        context.SaveChanges();
                    }
                }
            });
        }
        
        /// <summary>
        ///     Получить всех пользователей.
        /// </summary>
        /// <returns>Коллекция пользователей.</returns>
        public async Task<string> GetUsersAsync()
        {
            try
            {
                List<User> users;
                using (var context = new VirtuSystemsDbContex())
                {
                    users = await context.Users.ToListAsync();
                }

                return JsonConvert.SerializeObject(users);
            }
            catch
            {
                return string.Empty;
            }
        }

        /// <summary>
        ///     Редактировать пользователей.
        /// </summary>
        /// <param name="users">Отредактированные пользователи</param>
        /// <returns></returns>
        public async Task<bool> EditUsersAsync(string users)
        {
            try
            {
                await Task.Run(() =>
                {
                    List<User> usersList;
                    usersList = JsonConvert.DeserializeObject<List<User>>(users);

                    using (var context = new VirtuSystemsDbContex())
                    {
                        var usersDb = context.Users.Where(x => usersList.Contains(x)).AsTracking().ToList();
                        usersDb = GetUpdateUserList(usersDb, usersList);

                        foreach (var user in usersList)
                            if (usersDb.All(x => x.Id != user.Id))
                                usersDb.Add(GetNewUser(user));

                        context.UpdateRange(usersDb.Distinct());
                        context.SaveChanges();
                    }
                });
                return true;
            }
            catch
            {
                return false;
            }
        }

        /// <summary>
        ///     Получить нового юзера
        /// </summary>
        /// <param name="user">юзер</param>
        /// <returns></returns>
        private User GetNewUser(User user)
        {
            return new User
            {
                Name = user.Name,
                Phone = user.Phone,
                BirthDay = user.BirthDay
            };
        }

        /// <summary>
        ///     Получить обновленного пользователя.
        /// </summary>
        /// <param name="usersDb">юзер из БД</param>
        /// <param name="usersList">юзер измененный</param>
        /// <returns></returns>
        private List<User> GetUpdateUserList(List<User> usersDb, List<User> usersList)
        {
            if (usersDb.Count == 0)
                foreach (var user in usersList)
                    usersDb.Add(GetNewUser(user));
            else
                foreach (var userdb in usersDb)
                foreach (var user in usersList)
                    if (userdb.Id == user.Id)
                    {
                        userdb.BirthDay = user.BirthDay;
                        userdb.Name = user.Name;
                        userdb.Phone = user.Phone;
                    }

            return usersDb;
        }
    }
}

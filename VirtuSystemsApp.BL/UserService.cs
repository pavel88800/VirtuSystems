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
        public async Task AddDataInDBAsync()
        {
            var users = new List<User>();
            for (var i = 1; i <= 100; i++)
                users.Add(new User {BirthDay = DateTime.Today.Date, Name = "Test_" + i, Phone = "8 888 888 88 88"});

            using (var _context = new VirtuSystemsDbContex())
            {
                await _context.AddRangeAsync(users);
                await _context.SaveChangesAsync();
            }
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

                var json = JsonConvert.SerializeObject(users);
                return json;
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
            await Task.Run(() =>
            {
                List<User> usersList;

                usersList = JsonConvert.DeserializeObject<List<User>>(users);

                using (var context = new VirtuSystemsDbContex())
                {
                    var usersDb = context.Users.Where(x => usersList.Contains(x)).ToList();

                    if (usersDb.Count == 0)
                        foreach (var userslist in usersList)
                            usersDb.Add(new User
                            {
                                Name = userslist.Name,
                                Phone = userslist.Phone,
                                BirthDay = userslist.BirthDay
                            });
                    else
                        foreach (var userdb in usersDb)
                        foreach (var userslist in usersList)
                            if (userdb.Id == userslist.Id)
                            {
                                userdb.BirthDay = userslist.BirthDay;
                                userdb.Name = userslist.Name;
                                userdb.Phone = userslist.Phone;
                            }
                            else
                            {
                                usersDb.Add(new User
                                {
                                    Name = userslist.Name,
                                    Phone = userslist.Phone,
                                    BirthDay = userslist.BirthDay
                                });
                            }

                    context.UpdateRange(usersDb);
                    context.SaveChanges();
                }
            });
            return default;
        }

        /// <summary>
        ///     Удалить пользователей
        /// </summary>
        /// <param name="ids">Список идентификаторов пользователей.</param>
        /// <returns></returns>
        public bool DeleteUsers(List<int> ids)
        {
            return default;
        }
    }
}
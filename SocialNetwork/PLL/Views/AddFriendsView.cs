using SocialNetwork.BLL.Exceptions;
using SocialNetwork.BLL.Models;
using SocialNetwork.BLL.Services;
using SocialNetwork.PLL.Helpers;
using System;
using System.Collections.Generic;
using System.Text;

namespace SocialNetwork.PLL.Views
{
    public class AddFriendView
    {
        private readonly FriendService _friendService;
        private readonly UserService _userService;

        public AddFriendView()
        {
            _friendService = new FriendService();
            _userService = new UserService();
        }

        public void Show(User currentUser)
        {
            Console.Write("Введите email друга для добавления: ");
            string friendEmail = Console.ReadLine();

            try
            {
                _friendService.AddFriend(currentUser.Id, friendEmail);
                SuccessMessage.Show("Друг успешно добавлен!");

                currentUser = _userService.FindById(currentUser.Id);
            }
            catch (UserNotFoundException)
            {
                AlertMessage.Show("Пользователь с таким email не найден!");
            }
            catch (FriendAlreadyExistsException)
            {
                AlertMessage.Show("Этот пользователь уже в друзьях!");
            }
            catch (Exception ex)
            {
                AlertMessage.Show($"Ошибка: {ex.Message}");
            }
        }
    }
}

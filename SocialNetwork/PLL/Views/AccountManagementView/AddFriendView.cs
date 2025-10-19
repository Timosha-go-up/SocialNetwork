using SocialNetwork.BLL.Exceptions;
using SocialNetwork.BLL.Models;
using SocialNetwork.BLL.Services;
using SocialNetwork.BLL.Services.UserServices;
using SocialNetwork.PLL.Helpers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SocialNetwork.PLL.Views.AccountManagementView
{
    public class AddFriendView
    {
        private readonly FriendService _friendService;
        private readonly UserProfileService _userProfileService;

        public AddFriendView(FriendService friendService, UserProfileService userProfileService)
        {
            _friendService = friendService;
            _userProfileService = userProfileService;
        }

        public void Show(User currentUser)
        {
            Console.Write("Введите email друга для добавления: ");
            string friendEmail = Console.ReadLine();

            try
            {
                _friendService.AddFriend(currentUser.Id, friendEmail);
                SuccessMessage.Show("Друг успешно добавлен!");

                // Обновим профиль пользователя (если нужно)
                currentUser = _userProfileService.FindById(currentUser.Id);
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

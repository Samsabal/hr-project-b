using Festivity.AccountRegistration;
using Festivity.Account;
using System;
using System.Collections.Generic;

namespace Festivity
{
    internal class UserRegisterMenu : MenuBuilder
    {
        public List<MenuOption> UserRegisterMenuBuilder(UserModel user, bool newUser)

        {
            int PadRightValue = 30;
            int PadLeftValue = 38;
            //ConsoleHelperFunctions.ClearCurrentConsole();

            List<MenuOption> newMenuOptions = new List<MenuOption>
            {
                    new MenuOption(" First name: ".PadRight(PadRightValue) + $"{user.FirstName}".PadLeft(PadLeftValue), () =>
                    {
                        Console.Clear();
                        Reader.InputFirstName(user);
                    }),
                    new MenuOption(" Last name: ".PadRight(PadRightValue) + $"{user.LastName}".PadLeft(PadLeftValue), () =>
                    {
                        Console.Clear();
                        Reader.InputLastName(user);
                    }),
                    new MenuOption(" Email: ".PadRight(PadRightValue) + $"{user.Email}".PadLeft(PadLeftValue), () =>
                    {
                        Console.Clear();
                        Reader.InputEmail(user);
                    })
            };

            if (newUser)
            {
                newMenuOptions.Add(new MenuOption(" Password: ".PadRight(PadRightValue) + $"{user.Password}".PadLeft(PadLeftValue), () =>
                {
                    Console.Clear();
                    Reader.InputPassword(user);
                }));
            }

            newMenuOptions.Add(new MenuOption(" Address: ".PadRight(PadRightValue-20) + $"{user.userAddress.ToString()}".PadLeft(PadLeftValue+20), () =>
                    {
                        Console.Clear();
                        Reader.InputUserAdress(user);
                    }));

            if (user.AccountType == 1)
            {
                newMenuOptions.Add(new MenuOption(" Contactperson: ".PadRight(PadRightValue) + $"{user.ContactPerson}".PadLeft(PadLeftValue), () =>
                {
                    Console.Clear();
                    Reader.InputCompanyContactperson(user);
                }));
                newMenuOptions.Add(new MenuOption(" Company PhoneNumber: ".PadRight(PadRightValue) + $"{user.CompanyPhoneNumber}".PadLeft(PadLeftValue), () =>
                {
                    Console.Clear();
                    Reader.InputCompanyPhonenumber(user);
                }));
                newMenuOptions.Add(new MenuOption(" Company name: ".PadRight(PadRightValue) + $"{user.CompanyName}".PadLeft(PadLeftValue), () =>
                {
                    Console.Clear();
                    Reader.InputCompanyName(user);
                }));
                newMenuOptions.Add(new MenuOption(" IBAN: ".PadRight(PadRightValue) + $"{user.CompanyIBAN}".PadLeft(PadLeftValue), () =>
                {
                    Console.Clear();
                    Reader.InputIBAN(user);
                }));
            }

            if (user.AccountType == 2)
            {
                newMenuOptions.Add(new MenuOption(" Birthday: ".PadRight(PadRightValue) + $"{user.BirthDate.ToShortDateString().PadLeft(PadLeftValue)}".PadLeft(PadLeftValue), () =>
                {
                    Console.Clear();
                    Reader.InputBirthday(user);
                }));
                newMenuOptions.Add(new MenuOption(" Phonenumber: ".PadRight(PadRightValue) + $"{user.PhoneNumber}".PadLeft(PadLeftValue), () =>
                {
                    Console.Clear();
                    Reader.InputVisitorPhonenumber(user);
                }));
            }

            newMenuOptions.Add(new MenuOption(" Newsletter Preference: ".PadRight(PadRightValue) + $"{(user.NewsLetter ? "Yes" : "No")}".PadLeft(PadLeftValue), () =>
                    {
                        Console.Clear();
                        Reader.InputNewsLetter(user);
                    }));
            newMenuOptions.Add(new MenuOption(newUser ? "\n Save User" : "\n Save Changes".PadLeft(PadLeftValue), () =>
                    {
                        ConsoleHelperFunctions.ClearCurrentConsole();
                        if (newUser)
                        {
                            Menu.OptionReset();
                            ObjectSaver.Save(user);
                        }
                        else
                        {
                            Menu.OptionReset();
                            LoggedInModel.UpdateDatabase();
                            Program.Main();
                        }
                    }));
            newMenuOptions.Add(new MenuOption(newUser ? " Cancel user Registration" : " Cancel".PadLeft(PadLeftValue), () =>
                    {
                        Console.Clear();
                        Menu.OptionReset();
                        Program.Main();
                    }));

            return newMenuOptions;
        }
    }
}
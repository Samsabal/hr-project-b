using Festivity.AccountRegistration;
using Festivity.Account;
using System;
using System.Collections.Generic;

namespace Festivity
{
    internal class UserRegisterMenu : MenuBuilder
    {
        public static List<MenuOption> UserRegisterMenuBuilder(UserModel user, bool newUser)

        {
            int currentValueStartingPoint = 30;
            ConsoleHelperFunctions.ClearCurrentConsole();

            List<MenuOption> newMenuOptions = new List<MenuOption>
            {
                    new MenuOption("First name: ".PadRight(currentValueStartingPoint) + $"{user.FirstName}", () =>
                    {
                        Console.Clear();
                        Reader.InputFirstName(user);
                    }),
                    new MenuOption("Last name: ".PadRight(currentValueStartingPoint) + $"{user.LastName}", () =>
                    {
                        Console.Clear();
                        Reader.InputLastName(user);
                    }),
                    new MenuOption("Email: ".PadRight(currentValueStartingPoint) + $"{user.Email}", () =>
                    {
                        Console.Clear();
                        Reader.InputEmail(user);
                    })
            };

            if (newUser)
            {
                newMenuOptions.Add(new MenuOption("Password: ".PadRight(currentValueStartingPoint) + $"{user.Password}", () =>
                {
                    Console.Clear();
                    Reader.InputPassword(user);
                }));
            }

            newMenuOptions.Add(new MenuOption("Address: ".PadRight(currentValueStartingPoint) + $"{user.userAddress.ToString()}", () =>
                    {
                        Console.Clear();
                        Reader.InputUserAdress(user);
                    }));

            if (user.AccountType == 1)
            {
                newMenuOptions.Add(new MenuOption("Contactperson: ".PadRight(currentValueStartingPoint) + $"{user.ContactPerson}", () =>
                {
                    Console.Clear();
                    Reader.InputCompanyContactperson(user);
                }));
                newMenuOptions.Add(new MenuOption("Company PhoneNumber: ".PadRight(currentValueStartingPoint) + $"{user.CompanyPhoneNumber}", () =>
                {
                    Console.Clear();
                    Reader.InputCompanyPhonenumber(user);
                }));
                newMenuOptions.Add(new MenuOption("Company name: ".PadRight(currentValueStartingPoint) + $"{user.CompanyName}", () =>
                {
                    Console.Clear();
                    Reader.InputCompanyName(user);
                }));
                newMenuOptions.Add(new MenuOption("IBAN: ".PadRight(currentValueStartingPoint) + $"{user.CompanyIBAN}", () =>
                {
                    Console.Clear();
                    Reader.InputIBAN(user);
                }));
            }

            if (user.AccountType == 2)
            {
                newMenuOptions.Add(new MenuOption("Birthday: ".PadRight(currentValueStartingPoint) + $"{user.BirthDate.ToShortDateString()}", () =>
                {
                    Console.Clear();
                    Reader.InputBirthday(user);
                }));
                newMenuOptions.Add(new MenuOption("Phonenumber: ".PadRight(currentValueStartingPoint) + $"{user.PhoneNumber}", () =>
                {
                    Console.Clear();
                    Reader.InputVisitorPhonenumber(user);
                }));
            }

            newMenuOptions.Add(new MenuOption("Newsletter Preference: ".PadRight(currentValueStartingPoint) + $"{(user.NewsLetter ? "Yes" : "No")}", () =>
                    {
                        Console.Clear();
                        Reader.InputNewsLetter(user);
                    }));
            newMenuOptions.Add(new MenuOption(newUser ? "Save User" : "Save Changes", () =>
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
            newMenuOptions.Add(new MenuOption("Cancel user Registration", () =>
                    {
                        Console.Clear();
                        Menu.OptionReset();
                        Program.Main();
                    }));

            return newMenuOptions;
        }
    }
}
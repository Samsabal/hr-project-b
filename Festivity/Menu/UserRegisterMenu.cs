using Festivity.AccountRegistration;
using System;
using System.Collections.Generic;

namespace Festivity
{
    class UserRegisterMenu : MenuBuilder
    {
        public static List<MenuOption> UserOrganisatorRegisterMenuBuilder(UserModel user)
        {
            int currentValueStartingPoint = 30;
            ConsoleHelperFunctions.ClearCurrentConsole();

            List<MenuOption> newMenuOptions = new List<MenuOption>
                {
                    new MenuOption("First name: ".PadRight(currentValueStartingPoint) + $"{user.FirstName}", () =>
                    {
                        Console.Clear();
                        UserModifier.InputFirstName(user);
                    }),
                    new MenuOption("Last name: ".PadRight(currentValueStartingPoint) + $"{user.LastName}", () =>
                    {
                        Console.Clear();
                        UserModifier.InputLastName(user);
                    }),
                    new MenuOption("Email: ".PadRight(currentValueStartingPoint) + $"{user.Email}", () =>
                    {
                        Console.Clear();
                        UserModifier.InputEmail(user);
                    }),
                    new MenuOption("Password: ".PadRight(currentValueStartingPoint) + $"{user.Password}", () =>
                    {
                        Console.Clear();
                        UserModifier.InputPassword(user);
                    }),
                    new MenuOption("Address: ".PadRight(currentValueStartingPoint) + $"{user.userAddress.ToString()}", () =>
                    {
                        Console.Clear();
                        UserModifier.InputUserAdress(user);
                    }),
                    new MenuOption("Contactperson: ".PadRight(currentValueStartingPoint) + $"{user.ContactPerson}", () =>
                    {
                        Console.Clear();
                        UserModifier.InputCompanyContactperson(user);
                    }),
                    new MenuOption("Company PhoneNumber: ".PadRight(currentValueStartingPoint) + $"{user.CompanyPhoneNumber}", () =>
                    {
                        Console.Clear();
                        UserModifier.InputCompanyPhonenumber(user);
                    }),
                    new MenuOption("Company name: ".PadRight(currentValueStartingPoint) + $"{user.CompanyName}", () =>
                    {
                        Console.Clear();
                        UserModifier.InputCompanyName(user);
                    }),
                    new MenuOption("IBAN: ".PadRight(currentValueStartingPoint) + $"{user.CompanyIBAN}", () =>
                    {
                        Console.Clear();
                        UserModifier.InputIBAN(user);
                    }),
                    new MenuOption("Newsletter Preference: ".PadRight(currentValueStartingPoint) + $"{(user.NewsLetter == true ? "Yes" : "No")}", () =>
                    {
                        Console.Clear();
                        UserModifier.InputNewsLetter(user);
                    }),
                    new MenuOption("Save User", () =>
                    {
                        ConsoleHelperFunctions.ClearCurrentConsole();
                        //Menu.OptionReset();
                        ObjectSaver.Save(user);                      
                    }),
                    new MenuOption("Cancel user Registration", () =>
                    {
                        Console.Clear();
                        Menu.OptionReset();
                        Program.Main();
                    })
                };
            return newMenuOptions;
        }

        public static List<MenuOption> UserVisitorRegisterMenuBuilder(UserModel user)
        {
            int currentValueStartingPoint = 30;
            ConsoleHelperFunctions.ClearCurrentConsole();

            List<MenuOption> newMenuOptions = new List<MenuOption>
                {
                    new MenuOption("First name: ".PadRight(currentValueStartingPoint) + $"{user.FirstName}", () =>
                    {
                        Console.Clear();
                        UserModifier.InputFirstName(user);
                    }),
                    new MenuOption("Last name: ".PadRight(currentValueStartingPoint) + $"{user.LastName}", () =>
                    {
                        Console.Clear();
                        UserModifier.InputLastName(user);
                    }),
                    new MenuOption("Email: ".PadRight(currentValueStartingPoint) + $"{user.Email}", () =>
                    {
                        Console.Clear();
                        UserModifier.InputEmail(user);
                    }),
                    new MenuOption("Password: ".PadRight(currentValueStartingPoint) + $"{user.Password}", () =>
                    {
                        Console.Clear();
                        UserModifier.InputPassword(user);
                    }),
                    new MenuOption("Address: ".PadRight(currentValueStartingPoint) + $"{user.userAddress.ToString()}", () =>
                    {
                        Console.Clear();
                        UserModifier.InputUserAdress(user);
                    }),
                    new MenuOption("Birthday: ".PadRight(currentValueStartingPoint) + $"{user.BirthDate.ToShortDateString()}", () =>
                    {
                        Console.Clear();
                        UserModifier.InputBirthday(user);
                    }),
                    new MenuOption("Phonenumber: ".PadRight(currentValueStartingPoint) + $"{user.PhoneNumber}", () =>
                    {
                        Console.Clear();
                        UserModifier.InputVisitorPhonenumber(user);
                    }),
                    new MenuOption("Newsletter Preference: ".PadRight(currentValueStartingPoint) + $"{(user.NewsLetter == true ? "Yes" : "No")}", () =>
                    {
                        Console.Clear();
                        UserModifier.InputNewsLetter(user);
                    }),
                    new MenuOption("Save User", () =>
                    {
                        ConsoleHelperFunctions.ClearCurrentConsole();
                        //Menu.OptionReset();
                        ObjectSaver.Save(user);                      
                    }),
                    new MenuOption("Cancel user Registration", () =>
                    {
                        Console.Clear();
                        Menu.OptionReset();
                        Program.Main();
                    })
                };
            return newMenuOptions;
        }
    }

}

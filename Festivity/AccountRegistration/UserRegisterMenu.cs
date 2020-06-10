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

            List<MenuOption> newMenuOptions = new List<MenuOption>
            {
                    new MenuOption(" First name: ".PadRight(PadRightValue) + $"{user.FirstName}".PadLeft(PadLeftValue), () =>
                    {
                        Reader.InputFirstName(user);
                        Console.Clear();
                    }),
                    new MenuOption(" Last name: ".PadRight(PadRightValue) + $"{user.LastName}".PadLeft(PadLeftValue), () =>
                    {
                        Reader.InputLastName(user);
                        Console.Clear();
                    }),
                    new MenuOption(" Email: ".PadRight(PadRightValue) + $"{user.Email}".PadLeft(PadLeftValue), () =>
                    {                
                        Reader.InputEmail(user);
                        Console.Clear();
                    })
            };

            if (newUser)
            {
                newMenuOptions.Add(new MenuOption(" Password: ".PadRight(PadRightValue) + $"{user.Password}".PadLeft(PadLeftValue), () =>
                {                 
                    Reader.InputPassword(user);
                    Console.Clear();
                }));
            }

            newMenuOptions.Add(new MenuOption(" Address: ".PadRight(PadRightValue-20) + $"{user.userAddress.ToString()}".PadLeft(PadLeftValue+20), () =>
                    {                     
                        Reader.InputUserAdress(user);
                        Console.Clear();
                    }));

            if (user.AccountType == 1)
            {
                newMenuOptions.Add(new MenuOption(" Contactperson: ".PadRight(PadRightValue) + $"{user.ContactPerson}".PadLeft(PadLeftValue), () =>
                {                   
                    Reader.InputCompanyContactperson(user);
                    Console.Clear();
                }));
                newMenuOptions.Add(new MenuOption(" Company PhoneNumber: ".PadRight(PadRightValue) + $"{user.CompanyPhoneNumber}".PadLeft(PadLeftValue), () =>
                {                   
                    Reader.InputCompanyPhonenumber(user);
                    Console.Clear();
                }));
                newMenuOptions.Add(new MenuOption(" Company name: ".PadRight(PadRightValue) + $"{user.CompanyName}".PadLeft(PadLeftValue), () =>
                {                   
                    Reader.InputCompanyName(user);
                    Console.Clear();
                }));
                newMenuOptions.Add(new MenuOption(" IBAN: ".PadRight(PadRightValue) + $"{user.CompanyIBAN}".PadLeft(PadLeftValue), () =>
                {                    
                    Reader.InputIBAN(user);
                    Console.Clear();
                }));
            }

            if (user.AccountType == 2)
            {
                newMenuOptions.Add(new MenuOption(" Birthday: ".PadRight(PadRightValue) + $"{user.BirthDate.ToShortDateString().PadLeft(PadLeftValue)}".PadLeft(PadLeftValue), () =>
                {                  
                    Reader.InputBirthday(user);
                    Console.Clear();
                }));
                newMenuOptions.Add(new MenuOption(" Phonenumber: ".PadRight(PadRightValue) + $"{user.PhoneNumber}".PadLeft(PadLeftValue), () =>
                {                   
                    Reader.InputVisitorPhonenumber(user);
                    Console.Clear();
                }));
            }

            newMenuOptions.Add(new MenuOption(" Newsletter Preference: ".PadRight(PadRightValue) + $"{(user.NewsLetter ? "Yes" : "No")}".PadLeft(PadLeftValue), () =>
                    {                     
                        Reader.InputNewsLetter(user);
                        Console.Clear();
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
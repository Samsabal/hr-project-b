using BetterConsoleTables;
using System;
using System.Collections.Generic;
using System.Text;

namespace Festivity.Festival
{
    class FestivalTableBuilder
    {
        //private static List<List<string>> FestivalTableList = new List<List<string>>();

        public static List<List<string>> BuildTableList()
        {
            JSONFestivalList festivals = JSONFunctionality.GetFestivals();
            List<List<string>> FestivalTableList = new List<List<string>>();

            foreach (var festival in festivals.Festivals)
            {
                if (LoggedInAccount.GetID() == festival.FestivalOrganiserID)
                {
                    List<string> tempList = new List<string>();
                    tempList.Add(festival.FestivalID.ToString());
                    tempList.Add(festival.FestivalName);
                    tempList.Add(festival.FestivalDate.ToShortDateString());
                    tempList.Add(festival.FestivalLocation.City);
                    tempList.Add(festival.GetTickets().Count.ToString());
                    FestivalTableList.Add(tempList);
                }
            }
            return FestivalTableList;
        }

        public static string ConvertToString(List<List<string>> festivalTableList)
        {
            Table festivalTable = new Table();
            festivalTable = new Table("ID", 
                                      "Festival name", 
                                      "Festival date", 
                                      "City", 
                                      "Ticket amount");

            for (int i = 0; i < festivalTableList.Count; i++){
            festivalTable.AddRow($"{festivalTableList[i][0]}", $"{festivalTableList[i][1]}", $"{festivalTableList[i][2]}",
                                 $"{festivalTableList[i][3]}", $"{festivalTableList[i][4]}");}

            festivalTable.Config = TableConfiguration.Markdown(); //Ticket Table Themes (See Link)-(Markdown, Unicode, MySqlSimple, MySql, Markdown)
            return festivalTable.ToString();
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;

namespace Banyan_Batcher_network
{
    class Program
    {
        static void Main(string[] args)
        {
            int iInputCount;
            Console.WriteLine("Enter the count :");
            iInputCount = Convert.ToInt32(Console.ReadLine());
            var r = new Random();
            //var myValues = new int[] { 0, 1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 11, 12, 13, 14, 15 }; 
            List<int> listNumbers = new List<int>();
            int number;
            for (int i = 0; i < iInputCount; i++)
            {
                do
                {
                    number = r.Next(0, 15);
                } while (listNumbers.Contains(number));
                listNumbers.Add(number);
            }
            Console.WriteLine("Random selection: ");
            Console.WriteLine(String.Join("\n", listNumbers));
            listNumbers.Sort();
            Console.WriteLine("Afer sort: ");
            Console.WriteLine(String.Join("\n", listNumbers));
            List<string> listBinary = new List<string>();
            for (int i = 0; i < iInputCount; i++)
            {
                string res = Convert.ToString(listNumbers[i], 2);
                res = res.PadLeft(4, '0');
                listBinary.Add(res);
            }
            Dictionary<int, string> dicKeyValues = new Dictionary<int, string>() { { 0, "A1"},{1 ,"A2" },{2, "A3" },{3, "A4"},{ 4, "A5"},{ 5, "A6"},
                { 6, "A7"},{7, "A8"},{ 8, "A1"},{ 9, "A2"},{ 10, "A3"},{11, "A4"},{ 12, "A5"},{ 13, "A6"},{ 14, "A7"},{ 15, "A8"} };
            List<string> listSwitch = new List<string>();
            for (int j = 0; j < iInputCount; j++)
            {
                listSwitch.Add(dicKeyValues[listNumbers[j]]);
            }
            for(int k=0; k<iInputCount; k++)
            {
                BanyanBatcher(listSwitch[k], listBinary[k]);
            }
           
        }

        public static void BanyanBatcher(string pinitial, string pBinary)
        {
            try
            {
                Dictionary<string, List<string>> dicSwich1 = new Dictionary<string, List<string>>() { { "A1", new List<string> { "B1", "B5" } }, { "A2", new List<string> { "B2", "B6" } }
                ,{"A3", new List<string> { "B3", "B7" } }, {"A4" , new List<string> {"B4", "B8" } },{"A5",  new List<string> {"B1", "B5" } }, { "A6", new List<string> { "B2", "B6" } },
                {"A7", new List<string> {"B3", "B7" }}, { "A8", new List<string> {"B4", "B8" } }};
                Dictionary<string, List<string>> dicSwich2 = new Dictionary<string, List<string>>() { {"B1", new List<string> {"C1", "C5"}},{
        "B2", new List<string> {"C2", "C6"}},{"B3", new List<string> {"C3", "C7"}},{"B4", new List<string> {"C4", "C8"}},{"B5", new List<string> {"C1", "C5"}},{
        "B6", new List<string> {"C2", "C6"}},{    "B7", new List<string> {"C3", "C7"}},{ "B8", new List<string> {"C4", "C8"}} };
                Dictionary<string, List<string>> dicSwich3 = new Dictionary<string, List<string>>() { {"C1", new List<string> {"D1", "D5"}},{"C2", new List<string> {"D2", "D6"}},{"C3", new List<string> {"D3", "D7"}},{"C4", new List<string> {"D4", "D8"}},{
        "C5", new List<string> {"D1", "D5"}},{"C6", new List<string> {"D2", "D6"}},{ "C7", new List<string> {"D3", "D7"}},{ "C8", new List<string> {"D4", "D8"}} };
                Dictionary<string, List<string>> dicSwich4 = new Dictionary<string, List<string>>() { {   "D1", new List<string> {"OUT0", "OUT1"}},{"D2", new List<string> {"OUT2", "OUT3"}},{"D3", new List<string> {"OUT4", "OUT5"}},{"D4", new List<string> {"OUT6", "OUT7"}},{
        "D5", new List<string> {"OUT8", "OUT9"}},{"D6", new List<string> {"OUT10", "OUT11"}},{"D7", new List<string> {"OUT12", "OUT13"}},
        {"D8", new List<string> {"OUT14", "OUT15"}} };
                if (pBinary.Length != 4)
                {
                    throw new NullReferenceException("doesnot contain four elements");
                }
                if (!dicSwich1.ContainsKey(pinitial))
                {
                    throw new NullReferenceException("not valid input");
                }

                string strFinal = pinitial;
                List<Dictionary<string, List<string>>> LstDict = new List<Dictionary<string, List<string>>> ();
                LstDict.Add(dicSwich1);
                LstDict.Add(dicSwich2);
                LstDict.Add(dicSwich3);
                LstDict.Add(dicSwich4);
                
                List<string> datalist = new List<string>(pBinary.Select(c => c.ToString()));

                Console.Write("\n" + strFinal);

                for (int iIndex = 0; iIndex < pBinary.Length; iIndex++)
                {
                    int iVal = Int32.Parse(datalist[iIndex]);
                    
                    strFinal = LstDict[iIndex][strFinal][iVal];

                    Console.Write(" -> " + strFinal );
                }
                
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message.ToString());
            }


        }


    }
}

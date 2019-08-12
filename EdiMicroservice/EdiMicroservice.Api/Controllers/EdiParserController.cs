using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;



namespace EdiMicroservice.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EdiParserController : ControllerBase
    {


        // GET api/values/5
        [HttpGet("{id}")]
        public ActionResult<string> Get(int id)
        {
            string ediX12 = "ISA*00*          *00*          *09*001288364I     *01*1498253538     *190117*1649*U*00401*000000112*0*P*" +
                         ":!GS*PO*001288364I*1498253538*20190117*1649*112*X*004010" +
                         "!ST*850*0232" +
                         "!BEG*00*SA*1103408478**20190117" +
                         "!CUR*BY*USD" +
                         "!ITD*01***********BN03" +
                         "!TD5*B***ZZ*Contact buyer for shipping ins" +
                         "!TD5*B***ZZ*tructions" +
                         "!N9*L1**MSG SEGMENT REPLACES NTE" +
                         "!MSG*FOB -          FCA            FREIGHT TRMS - FCA" +

                         "!N1*ST*COLUMBIA, MO PLANT*9*001288364US64" +
                         "!N3*PARIS ROAD*COLUMBIA, MO        65202" +

                         "!N1*BT*SCHNEIDER ELECTRIC USA" +
                         "!N3*1215 SAN DARIO*AVE STE 4-960 LAREDO,TX 78040" +

                         "!N1*BY**9*001288364US64!N1*VN*OHE INDUSTRIES, L.L.C.*92*10100000" +
                         "!N3*4480 8TH AVE*MARION              52302382" +

                         "!PO1*00010*250*PC*0.92**BP*48185-064-01*VP*48185-064-01" +
                         "!PID*F****WIRE, MITOP/TU" +
                         "!PID*F****Need Material Certs with each order" +
                         "!DTM*002*20190131" +
                         "!CTT*1*250" +
                         "!AMT*TT*230" +
                         "!SE*22*0232" +
                         
                         "!GE*1*112" +

                         "!IEA*1*000000112!";


            //int startIndex = ediX12.IndexOf("!GS");
            //int endIndex = ediX12.IndexOf("!GE");

            //string a = ediX12.Split("!GE")[0];

            string a = ediX12;




            IList<string> segments = ediX12.Replace("!", "x1000!!").Split("x1000!");

            List<string> details = new List<string>();

            bool startDetails = false;
            foreach(var s in segments)
            {
                if (s.Contains("!PO"))
                {
                    startDetails = true;
                    var po = s.Split("*");
                    string ProductId = po[1];
                    string Quantity = po[2];
                    string UnitOfMeasurmentCode = po[3];
                    string UnitPrice = po[4];
                    string UnitPriceCode = po[5];
                    string ServiceIdQualifier = po[6];
                    string ServiceId = po[7];
                    string ServiceIdQualifier2 = po[8];
                    string ServiceId2 = po[9];

                }

                if (startDetails)
                {
                     details.Add(s);

                    if (s.Contains("PID"))
                    {
                        var pid = s.Split("*");
                        string ItemDescriptionType = pid[1];
                        string ProcessCharateristicCode = pid[2];
                        string AgencyQualifierCode = pid[3];
                        string Description = pid[4];


                    }
                }

                if (s.Contains("!GE"))
                {
                    break;
                }
                
            }

            System.Console.WriteLine(details.ToString());






            //string gg = "";

            //Get ISA
            IList<string> ISA = a.Replace("!", "___!").Split("___").Where(e => e.Contains("ISA")).ToList();;

            //Get GS
            IList<string> GS = a.Replace("!", "___!").Split("___").Where(e => e.Contains("!GS")).ToList();;

            //Get ST
            IList<string> ST = a.Replace("!", "___!").Split("___").Where(e => e.Contains("!ST")).ToList();

            //Get BEG
            IList<string> BEG = a.Replace("!", "___!").Split("___").Where(e => e.Contains("!BEG")).ToList();


            //Get CUR
            IList<string> CUR = a.Replace("!", "___!").Split("___").Where(e => e.Contains("!CUR")).ToList();


            //GET ITD
            IList<string> ITD = a.Replace("!", "___!").Split("___").Where(e => e.Contains("!ITD")).ToList();

            //GET TD5
            //Carrier Details
            //"!TD5*B***ZZ*Contact buyer for shipping ins" +
            //"!TD5*B***ZZ*tructions" +



            IList<string> TD5 = a.Replace("!", "___!").Split("___").Where(e => e.Contains("!TD5")).ToList();

            //GET N9
            IList<string> N9 = a.Replace("!", "___!").Split("___").Where(e => e.Contains("!N9")).ToList();

            //Get MSG
            IList<string> MSG = a.Replace("!", "___!").Split("___").Where(e => e.Contains("!MSG")).ToList();

            //Get all N1's with child n2 and n3
            //you can extract each n1's children using this query
            //IList<string> N1 = a.Replace("!", "___!").Split("___").Where(e => e.Contains("!N")  ).ToArray().Join("").Replace("!N1", "__!N1").Split("__").ToList();

            //GET all N1's only
            //IList<string> N1root = a.Replace("!", "___!").Split("___").Where(e => e.Contains("!N")).ToArray().Join("").Replace("!N1", "__!N1").Split("__").Where(n => n.Contains("N1")).ToList();


            //GET ALL PO1
            IList<string> PO1 = a.Replace("!", "___!").Split("___").Where(e => e.Contains("!PO1")).ToList();

            //GET ALL PID
            IList<string> PID = a.Replace("!", "___!").Split("___").Where(e => e.Contains("!PID")).ToList();

            //GET ALL DTM
            IList<string> DTM = a.Replace("!", "___!").Split("___").Where(e => e.Contains("!DTM")).ToList();


            //GET ALL CTT
            IList<string> CTT = a.Replace("!", "___!").Split("___").Where(e => e.Contains("!CTT")).ToList();

            //GET ALL AMT
            IList<string> AMT = a.Replace("!", "___!").Split("___").Where(e => e.Contains("!AMT")).ToList();

            //GET ALL SE
            IList<string> SE = a.Replace("!", "___!").Split("___").Where(e => e.Contains("!SE")).ToList();

            //GET ALL IEA
            IList<string> IEA = a.Replace("!", "___!").Split("___").Where(e => e.Contains("!IEA")).ToList();





































            return a;

        }


    }
}


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
            string a = "ISA*00*          *00*          *09*001288364I     *01*1498253538     *190117*1649*U*00401*000000112*0*P*" +
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
                         "!SE*22*0232!GE*1*112" +
                         "!IEA*1*000000112!";


            IList<string> z = a.Split("!");
            string gg = "";


            return gg;

        }


    }
}
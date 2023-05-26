using L2;
using Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FuXinTLL.Table
{
    public class L25API
    {
        private static DBL25Handler L25dbHand;
        public L25API(DBL25Handler p)
        {
            L25dbHand = p;
        }

        public bool Insert_L25CoilMap(L2L25_CoilMap l25_CoilMap)
        {
            return L25dbHand.InsertOnly(l25_CoilMap);
        }

        public bool Insert_L25Utility(L2L25_Utility l2L25_Utility)
        {
            return L25dbHand.InsertOnly(l2L25_Utility);
        }

        public  bool Insert_L25DownTime(L2L25_DownTime l2L25_DownTime)
        {
            return L25dbHand.InsertOnly(l2L25_DownTime);
        }

        public bool Insert_L25PDI(L2L25_CoilPDI l2L25_CoilPDI)
        {          
            return L25dbHand.InsertOnly(l2L25_CoilPDI);
        }

        public bool Insert_L25PDO(L2L25_CoilPDO l2L25_CoilPDO)
        {
            return L25dbHand.InsertOnly(l2L25_CoilPDO);
        }

        public bool Insert_L25Alive(L2L25_Alive l2L25_Alive)
        {
            return L25dbHand.InsertOnly(l2L25_Alive);
        }

        public bool Insert_UNCTensionCT(L2L25_UNCTensionCT l25_UNCTensionCT)
        {
            return L25dbHand.InsertOnly(l25_UNCTensionCT);
        }

        //public bool Insert_SideTrimmerCT(L2L25_SideTrimmerCT l2L25_SideTrimmerCT)
        //{
        //    return L25dbHand.InsertOnly(l2L25_SideTrimmerCT);
        //}

        public bool Insert_RECTensionCT(L2L25_RECTensionCT l2L25_RECTensionCT)
        {
            return L25dbHand.InsertOnly(l2L25_RECTensionCT);
        }

        public bool Insert_L25DisConnection()
        {
            L2L25_DisConnection l2L25_DisConnection = new L2L25_DisConnection();
            var constates = DBService.SysAPI.Query_ConnectStatus();
            if(constates != null)
            {
                l2L25_DisConnection.Message_Id = "109";
                l2L25_DisConnection.Message_Length = "33";
                l2L25_DisConnection.Date = DateTime.Now.ToString("yyyyMMdd");
                l2L25_DisConnection.Time = DateTime.Now.ToString("HHmmssfff");
                l2L25_DisConnection.SystemID_1 = (constates.Where(x => (x.ConnectionFrom == "MMS" && x.ConnectionTo == "Level2") || (x.ConnectionFrom == "Level2" && x.ConnectionTo == "MMS")).Select(x => x.ConnectionStatus.Contains("0"))).FirstOrDefault() == true ? "0" : "1";
                l2L25_DisConnection.SystemID_2 = "1";
                l2L25_DisConnection.SystemID_3 = (constates.Where(x => (x.ConnectionFrom == "Level1" && x.ConnectionTo == "Level2") || (x.ConnectionFrom == "Level2" && x.ConnectionTo == "Level1")).Select(x => x.ConnectionStatus.Contains("0"))).FirstOrDefault() == true ? "0" : "1";
                l2L25_DisConnection.SystemID_6 = (constates.Where(x => (x.ConnectionFrom == "WMS" && x.ConnectionTo == "Level2") || (x.ConnectionFrom == "Level2" && x.ConnectionTo == "WMS")).Select(x => x.ConnectionStatus.Contains("0"))).FirstOrDefault() == true ? "0" : "1";
            }
            return L25dbHand.InsertOnly(l2L25_DisConnection);
        }

        public bool Insert_L25L2APStatus(L2L25_L2APStatus l2L25_L2APStatus)
        {
            return L25dbHand.InsertOnly(l2L25_L2APStatus);
        }
    }
}

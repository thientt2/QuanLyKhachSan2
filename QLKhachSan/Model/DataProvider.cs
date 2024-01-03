using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QLKhachSan.Model
{

    public class DataProvider
    {
        private static DataProvider _ins;
        public static DataProvider Ins
        {
            get
            {
                if (_ins == null)
                    _ins = new DataProvider();
                return _ins;
            }
            set
            {
                _ins = value;
            }
        }

        //public LA_OPERA_HOTELEntities1 DB { get; set; }

        //private DataProvider()
        //{
        //    DB = new LA_OPERA_HOTELEntities1();
        //}
        ////TangThanhThien
        public QLKS_TTT DB { get; set; }

        private DataProvider()
        {
            DB = new QLKS_TTT();
        }
    }
}



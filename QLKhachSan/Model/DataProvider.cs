﻿using System;
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

        public QLKS_HT DB { get; set; }

        private DataProvider()
        {
            DB = new QLKS_HT();
        }
        ////TangThanhThien
        //public QLKS_TTT DB { get; set; }

        //private DataProvider()
        //{
        //    DB = new QLKS_TTT();
        //}
    }
}



using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Assets.Code._2_Model
{
    public class M_SimpleUnit
    {
        string _name;
        int _lv;
        int _hp;
        int _mp;
        int _geniusIndex;
        int _str;
        int _dex;
        int _int;
        int _lucky;

        #region 封装

        public string Name
        {
            get
            {
                return _name;
            }

            set
            {
                _name = value;
            }
        }
        public int Str
        {
            get
            {
                return _str;
            }

            set
            {
                _str = value;
            }
        }
        public int Dex
        {
            get
            {
                return _dex;
            }

            set
            {
                _dex = value;
            }
        }
        public int Int
        {
            get
            {
                return _int;
            }

            set
            {
                _int = value;
            }
        }
        public int Lucky
        {
            get
            {
                return _lucky;
            }

            set
            {
                _lucky = value;
            }
        }
        public int GeniusIndex
        {
            get
            {
                return _geniusIndex;
            }

            set
            {
                _geniusIndex = value;
            }
        }

        #endregion
    }
}

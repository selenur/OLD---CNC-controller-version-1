namespace CNC_Assist
{
    /// <summary>
    /// Класс для работы с байтом, со спец. возможностями
    /// </summary>
    public class SuperByte
    {
        /// <summary>
        /// Содержит значение байта
        /// </summary>
        private byte _valueByte;

        /// <summary>
        /// Содержит значения битов
        /// </summary>
        private readonly bool[] _valueBit = new bool[8];


        /// <summary>
        /// обновление сотояния битов, после изменения байта
        /// </summary>
        private void RefreshBitsFromByte()
        {
            _valueBit[0] = (_valueByte & (1 << 0)) != 0;
            _valueBit[1] = (_valueByte & (1 << 1)) != 0;
            _valueBit[2] = (_valueByte & (1 << 2)) != 0;
            _valueBit[3] = (_valueByte & (1 << 3)) != 0;
            _valueBit[4] = (_valueByte & (1 << 4)) != 0;
            _valueBit[5] = (_valueByte & (1 << 5)) != 0;
            _valueBit[6] = (_valueByte & (1 << 6)) != 0;
            _valueBit[7] = (_valueByte & (1 << 7)) != 0;
        }

        /// <summary>
        /// Обновление значения байта, после изменения битов
        /// </summary>
        private void RefreshByteFromBits()
        {
            byte res = 0x00;
            if (_valueBit[7]) res += 0x80;
            if (_valueBit[6]) res += 0x40;
            if (_valueBit[5]) res += 0x20;
            if (_valueBit[4]) res += 0x10;
            if (_valueBit[3]) res += 0x08;
            if (_valueBit[2]) res += 0x04;
            if (_valueBit[1]) res += 0x02;
            if (_valueBit[0]) res += 0x01;
            _valueByte = res;
        }

        /// <summary>
        /// Свойство, для работы с байтом
        /// </summary>
        public byte ValueByte
        {
            get
            {
                return _valueByte;
            }
            // ReSharper disable once UnusedMember.Global
            set
            {
                _valueByte = value;
                RefreshBitsFromByte();
            }
        }


        /// <summary>
        /// Получить значение 1-го бита
        /// </summary>
        public bool GetBit(int index)
        {
            if (index > 7) return false;
            return _valueBit[index];
        }

        /// <summary>
        /// Установка значения у 1-го бита
        /// </summary>
        public void SetBit(int index, bool value)
        {
            if (index > 7) return;

            _valueBit[index] = value;
            RefreshByteFromBits();
        }

        public string ValueString
        {
            get
            {
                return _valueByte.ToString("X2");
            }
            //set
            //{
            //    ValueByte = tByte(value.ToString());
            //    RefreshBitsFromByte();
            //}
        }

        /// <summary>
        /// Бит 7
        /// </summary>
        // ReSharper disable once UnusedMember.Global
        public bool Bit7
        {
            get
            {
                return _valueBit[7];
            }
            set
            {
                _valueBit[7] = value;
                RefreshByteFromBits();
            }
        }

        /// <summary>
        /// Бит 6
        /// </summary>
        // ReSharper disable once UnusedMember.Global
        public bool Bit6
        {
            get
            {
                return _valueBit[6];
            }
            set
            {
                _valueBit[6] = value;
                RefreshByteFromBits();
            }
        }

        /// <summary>
        /// Бит 5
        /// </summary>
        // ReSharper disable once UnusedMember.Global
        public bool Bit5
        {
            get
            {
                return _valueBit[5];
            }
            set
            {
                _valueBit[5] = value;
                RefreshByteFromBits();
            }
        }

        /// <summary>
        /// Бит 4
        /// </summary>
        // ReSharper disable once UnusedMember.Global
        public bool Bit4
        {
            get
            {
                return _valueBit[4];
            }
            set
            {
                _valueBit[4] = value;
                RefreshByteFromBits();
            }
        }

        /// <summary>
        /// Бит 3
        /// </summary>
        // ReSharper disable once UnusedMember.Global
        public bool Bit3
        {
            get
            {
                return _valueBit[3];
            }
            set
            {
                _valueBit[3] = value;
                RefreshByteFromBits();
            }
        }

        /// <summary>
        /// Бит 2
        /// </summary>
        // ReSharper disable once UnusedMember.Global
        public bool Bit2
        {
            get
            {
                return _valueBit[2];
            }
            set
            {
                _valueBit[2] = value;
                RefreshByteFromBits();
            }
        }

        /// <summary>
        /// Бит 1
        /// </summary>
        // ReSharper disable once UnusedMember.Global
        public bool Bit1
        {
            get
            {
                return _valueBit[1];
            }
            set
            {
                _valueBit[1] = value;
                RefreshByteFromBits();
            }
        }

        /// <summary>
        /// Бит 0
        /// </summary>
        // ReSharper disable once UnusedMember.Global
        public bool Bit0
        {
            get
            {
                return _valueBit[0];
            }
            set
            {
                _valueBit[0] = value;
                RefreshByteFromBits();
            }
        }

        /// <summary>
        /// Конструктор из байта
        /// </summary>
        /// <param name="inValue"></param>
        public SuperByte(byte inValue)
        {
            _valueByte = inValue;
            RefreshBitsFromByte();
        }

        /// <summary>
        /// Конструктор из битов
        /// </summary>
        /// <param name="bit7"></param>
        /// <param name="bit6"></param>
        /// <param name="bit5"></param>
        /// <param name="bit4"></param>
        /// <param name="bit3"></param>
        /// <param name="bit2"></param>
        /// <param name="bit1"></param>
        /// <param name="bit0"></param>
        public SuperByte(bool bit7, bool bit6, bool bit5, bool bit4, bool bit3, bool bit2, bool bit1, bool bit0)
        {
            _valueBit[0] = bit0;
            _valueBit[1] = bit1;
            _valueBit[2] = bit2;
            _valueBit[3] = bit3;
            _valueBit[4] = bit4;
            _valueBit[5] = bit5;
            _valueBit[6] = bit6;
            _valueBit[7] = bit7;
            RefreshByteFromBits();
        }


        /// <summary>
        /// Конструктор из битов
        /// </summary>
        /// <param name="bit7"></param>
        /// <param name="bit6"></param>
        /// <param name="bit5"></param>
        /// <param name="bit4"></param>
        /// <param name="bit3"></param>
        /// <param name="bit2"></param>
        /// <param name="bit1"></param>
        /// <param name="bit0"></param>
        public SuperByte(int bit7, int bit6, int bit5, int bit4, int bit3, int bit2, int bit1, int bit0)
        {
            _valueBit[0] = (bit0 == 1);
            _valueBit[1] = (bit1 == 1);
            _valueBit[2] = (bit2 == 1);
            _valueBit[3] = (bit3 == 1);
            _valueBit[4] = (bit4 == 1);
            _valueBit[5] = (bit5 == 1);
            _valueBit[6] = (bit6 == 1);
            _valueBit[7] = (bit7 == 1);
            RefreshByteFromBits();
        }

        /// <summary>
        /// Конструктор из строки
        /// </summary>
        /// <param name="inValue"></param>
        public SuperByte(string inValue)
        {
            byte b1 = 0x00;
            byte b2 = 0x00;

            if (inValue.Substring(0, 1) == "1") b1 = 0x01;
            if (inValue.Substring(0, 1) == "2") b1 = 0x02;
            if (inValue.Substring(0, 1) == "3") b1 = 0x03;
            if (inValue.Substring(0, 1) == "4") b1 = 0x04;
            if (inValue.Substring(0, 1) == "5") b1 = 0x05;
            if (inValue.Substring(0, 1) == "6") b1 = 0x06;
            if (inValue.Substring(0, 1) == "7") b1 = 0x07;
            if (inValue.Substring(0, 1) == "8") b1 = 0x08;
            if (inValue.Substring(0, 1) == "9") b1 = 0x09;
            if (inValue.Substring(0, 1) == "A") b1 = 0x0A;
            if (inValue.Substring(0, 1) == "a") b1 = 0x0A;
            if (inValue.Substring(0, 1) == "B") b1 = 0x0B;
            if (inValue.Substring(0, 1) == "b") b1 = 0x0B;
            if (inValue.Substring(0, 1) == "C") b1 = 0x0C;
            if (inValue.Substring(0, 1) == "c") b1 = 0x0C;
            if (inValue.Substring(0, 1) == "D") b1 = 0x0D;
            if (inValue.Substring(0, 1) == "d") b1 = 0x0D;
            if (inValue.Substring(0, 1) == "E") b1 = 0x0E;
            if (inValue.Substring(0, 1) == "e") b1 = 0x0E;
            if (inValue.Substring(0, 1) == "F") b1 = 0x0F;
            if (inValue.Substring(0, 1) == "f") b1 = 0x0F;


            if (inValue.Substring(1, 1) == "1") b2 = 0x01;
            if (inValue.Substring(1, 1) == "2") b2 = 0x02;
            if (inValue.Substring(1, 1) == "3") b2 = 0x03;
            if (inValue.Substring(1, 1) == "4") b2 = 0x04;
            if (inValue.Substring(1, 1) == "5") b2 = 0x05;
            if (inValue.Substring(1, 1) == "6") b2 = 0x06;
            if (inValue.Substring(1, 1) == "7") b2 = 0x07;
            if (inValue.Substring(1, 1) == "8") b2 = 0x08;
            if (inValue.Substring(1, 1) == "9") b2 = 0x09;
            if (inValue.Substring(1, 1) == "A") b2 = 0x0A;
            if (inValue.Substring(1, 1) == "a") b2 = 0x0A;
            if (inValue.Substring(1, 1) == "B") b2 = 0x0B;
            if (inValue.Substring(1, 1) == "b") b2 = 0x0B;
            if (inValue.Substring(1, 1) == "C") b2 = 0x0C;
            if (inValue.Substring(1, 1) == "c") b2 = 0x0C;
            if (inValue.Substring(1, 1) == "D") b2 = 0x0D;
            if (inValue.Substring(1, 1) == "d") b2 = 0x0D;
            if (inValue.Substring(1, 1) == "E") b2 = 0x0E;
            if (inValue.Substring(1, 1) == "e") b2 = 0x0E;
            if (inValue.Substring(1, 1) == "F") b2 = 0x0F;
            if (inValue.Substring(1, 1) == "f") b2 = 0x0F;

            _valueByte = (byte)((b1 * 0x10) + b2);
            RefreshBitsFromByte();
        }
    }
}
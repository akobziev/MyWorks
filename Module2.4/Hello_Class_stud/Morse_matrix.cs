using System;
using System.Text;
using System.Threading;

namespace Hello_Class_stud
{
    //Implement class Morse_matrix derived from String_matrix, which realize IMorse_crypt
    class Morse_matrix : String_matrix, IMorse_crypt
    {
        public const int Size_2 = Alphabet.Size;
        private int offset_key;// = 0; ноль тут необязателен, инт по дефолту ноль, и в конструкторе Вы ему значение присваиваете


        //Implement Morse_matrix constructor with the int parameter for offset
        //Use fd(Alphabet.Dictionary_arr) and sd() methods

        public Morse_matrix(){}
        public Morse_matrix(int offset)
        {
            offset_key = offset;
        }

        //Implement Morse_matrix constructor with the string [,] Dict_arr and int parameter for offset
        //Use fd(Dict_arr) and sd() methods
        public Morse_matrix(string [,] dict_arr, int offset)
        {
            offset_key = offset;
            fd(dict_arr);
            sd();
        }

        //Implement Morse_matrix operator +

        //Realize crypt() with string parameter
        //Use indexers        
        public string Crypt(string stringToCrypt)
        {            
            var sb = new StringBuilder();
            foreach (var c in stringToCrypt)
            {
                for (int i = 0; i < Alphabet.Size; i++)
                {
                    if (c == Alphabet.Dictionary_arr[0, i].ToCharArray()[0])
                    {
                        sb.Append(Alphabet.Dictionary_arr[1, i]);
                        break;
                    }
                }
            }
            return sb.ToString();
        }
        
        //Realize decrypt() with string array parameter
        //Use indexers
        public string Decrypt(string[] stringsToDecrypt)
        {
            var sb = new StringBuilder();
            foreach (var str in stringsToDecrypt)
            {
                for (int i = 0; i < Alphabet.Size; i++)
                {
                    if (str == Alphabet.Dictionary_arr[1, i])
                    {
                        sb.Append(Alphabet.Dictionary_arr[0, i]);
                        break;
                    }
                }
            }
            return sb.ToString();
        }


        //Implement Res_beep() method with string parameter to beep the string
        public void Res_beep(string result)
        {
            foreach (var c in result)
            {
                if (c == '.')
                {
                    Console.Beep(650, 100);
                    Thread.Sleep(200);
                }
                else if (c == '-')
                {
                    Console.Beep(650, 400);
                    Thread.Sleep(200);
                }
            }
        }


        private void fd(string[,] Dict_arr)
        {
            for (int ii = 0; ii < Size_2; ii++)
            {
                for (int jj = 0; jj < Size_2; jj++)
                {
                    this[ii, jj] = Dict_arr[ii, jj];
                }
            }
        }


        private  void sd()
        {
            int off = Size_2 - offset_key;
            for (int jj = 0; jj < off; jj++)
            {
                this[1, jj] = this[1, jj + offset_key];

            }
            for (int jj = off; jj < Size_2; jj++)
            {
                this[1, jj] = this[1, jj - off];

            }
        }


    }
}


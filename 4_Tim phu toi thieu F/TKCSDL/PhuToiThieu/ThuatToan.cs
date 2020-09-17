using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PhuToiThieu
{
    struct S_PhuToiThieu
    {
        public List<string> VT;

        public List<string> VP;
    }
    class ThuatToan
    {
        /// <summary>
        /// So sánh chuỗi A có nằm trong chuỗi B không
        /// </summary>
        /// <param name="con">A</param>
        /// <param name="cha">B</param>
        /// <returns>true nếu nằm trong, ngược lại trả về false</returns>
        private bool soSanhChuoi(string con, string cha)
        {
            int ChuoiCon = 0;

            if (cha.Length < con.Length)
                return false;

            for (int i = 0; i < con.Length; i++)
                for (int j = 0; j < cha.Length; j++)
                {
                    if (con[i] == cha[j])
                    {
                        ChuoiCon++;
                        break;
                    }
                }

            if (ChuoiCon == con.Length)
                return true;

            return false;
        }
        /// <summary>
        /// Tìm bao đóng
        /// </summary>
        /// <param name="baoDong">Bao đóng cần tìm</param>
        /// <param name="VT">tập phục thuộc hàm bên trái</param>
        /// <param name="VP">tập phục thuộc hàm bên phải</param>
        /// <param name="n">số phục thuộc hàm</param>
        /// <returns>Bao đóng</returns>
        public string timBaoDong(string baoDong, List<string> VT, List<string> VP)
        {
            int doDaiBaoDong = baoDong.Length - 1;

            while (doDaiBaoDong != baoDong.Length)
            {
                doDaiBaoDong = baoDong.Length;

                for (int i = 0; i < VT.Count; i++)
                {
                    if (soSanhChuoi(VT[i], baoDong))
                    {
                        for (int j = 0; j < VP[i].Length; j++)
                            if (!soSanhChuoi(VP[i][j].ToString(), baoDong))
                                baoDong += VP[i][j].ToString();
                    }
                }

            }

            return baoDong;
        }

        public string CatKiTu(string str, int vitri)
        {
            string ok = "";
            for (int i = 0; i < str.Length; i++)
            {
                if (vitri != i)
                    ok += str[i].ToString();
            }

            return ok;
        }

        public S_PhuToiThieu timPhuToiThieu(List<string> VT, List<string> VP)
        {
            S_PhuToiThieu ptt = new S_PhuToiThieu();

            int n = VP.Count;
            //tách phụ thuộc hàm vế phải có hơn 1 thuộc tính
            for (int i = 0; i < n; i++)
            {
                if (VP[i].Length > 1)
                {
                    string tempVP = VP[i];
                    string temVT = VT[i];

                    VT.Remove(VT[i]);
                    VP.Remove(VP[i]);

                    for (int j = 0; j < tempVP.Length; j++)
                    {
                        VT.Add(temVT);
                        VP.Add(tempVP[j].ToString());
                    }

                    i--;
                }
            }

            //loại bỏ thuộc tính dư thừa bên vế trái có hơn 1 thuộc tính
            for (int i = 0; i < VT.Count; i++)
            {
                if (VT[i].Length > 1)
                {

                    for (int j = 0; j < VT[i].Length; j++)
                    {
                        if (VT[i].Length > 1)
                        {
                            string temp = VT[i];
                            temp = CatKiTu(temp, j);

                            if (soSanhChuoi(VP[i], timBaoDong(temp, VT, VP)))
                            {
                                VT[i] = temp;
                                j--;
                            }

                        }
                    }
                }
            }

            //loại bỏ thuộc tính dư thừa
            List<string> TempVT = new List<string>();
            List<string> TempVP = new List<string>();

            for (int i = 0; i < VT.Count; i++)
            {
                TempVT.Add(VT[i]);
                TempVP.Add(VP[i]);
            }

            for (int i = 0; i < VT.Count; i++)
            {

                TempVT.RemoveAt(i);
                TempVP.RemoveAt(i);

                if (soSanhChuoi(VP[i], timBaoDong(VT[i], TempVT, TempVP)))
                {
                    VT.Clear();
                    VP.Clear();

                    for (int t = 0; t < TempVT.Count; t++)
                    {
                        VT.Add(TempVT[t]);
                        VP.Add(TempVP[t]);
                    }

                    i--;
                }
                else
                {
                    TempVT.Clear();
                    TempVP.Clear();

                    for (int t = 0; t < VT.Count; t++)
                    {
                        TempVT.Add(VT[t]);
                        TempVP.Add(VP[t]);
                    }
                }
            }

            ptt.VT = VT;
            ptt.VP = VP;

            return ptt;
        }

    }
}

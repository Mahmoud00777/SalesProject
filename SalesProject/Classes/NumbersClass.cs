using System;


namespace SalesProject
{
    class NumbersClass
    {
        public static string NoToTxt(double TheNo, string MyCur, string MySubCur, bool Dec3Digit = false)
        {
            // ======================
            if (Dec3Digit)
            {
                if (TheNo > 999999999999.999d)
                    return null;
            }
            else if (TheNo > 999999999999.99d)
                return null;
            // ======================
            if (TheNo == 0)
                return "صفر";
            // ======================

            string MyNoToTxt;
            string MyNo, GetNo, RdNo, GetTxt, ReMark = default;
            string My100, My10, My1, My11 = default, My12 = default;
            string Mybillion = default, MyMillion = default;
            string MyThou = default, MyHun = default, MyFraction = default;
            var MyArry1 = new string[] { "", "واحد", "إثنان", "ثلاثة", "أربعة", "خمسة", "ستة", "سبعة", "ثمانية", "تسعة" };
            var MyArry2 = new string[] { "", " عشر", "عشرون", "ثلاثون", "أربعون", "خمسون", "ستون", "سبعون", "ثمانون", "تسعون" };
            var MyArry3 = new string[] { "", "مئة", "مئتان", "ثلاثمائة", "اربعمائة", "خمسمائة", "ستمائة", "سبعمائة", "ثمانمائة", "تسعمائة" };
            string MyAnd = " و";

            // ======================
            if (Dec3Digit)
            {
                GetNo = TheNo.ToString("000000000000.000");
            }
            else
            {
                GetNo = TheNo.ToString("000000000000.00");
            }
            // ======================
            for (int i = 0; i <= 14; i += 3)
            {
                if (i < 12)
                {
                    MyNo = GetNo.Substring( i , 3);
                }
                else if (Dec3Digit)
                {
                    MyNo = GetNo.Substring( i + 1, 3);
                }
                else
                {
                    MyNo = "0" + GetNo.Substring( i + 1, 3);
                }

                if (Convert.ToDouble(MyNo.Substring(0, 3)) > 0)
                {
                    RdNo = MyNo.Substring( 0, 1);
                    My100 = MyArry3[Convert.ToInt32( RdNo)];
                    RdNo = MyNo.Substring( 2, 1);
                    My1 = MyArry1[Convert.ToInt32(RdNo)];
                    RdNo = MyNo.Substring( 1, 1);
                    My10 = MyArry2[Convert.ToInt32(RdNo)];

                    if (Convert.ToDouble(MyNo.Substring( 1, 2)) == 11)
                        My11 = "أحد عشر";
                    if (Convert.ToDouble(MyNo.Substring( 1, 2)) == 12)
                        My12 = "أثنا عشر";
                    if (Convert.ToDouble(MyNo.Substring( 1, 2)) == 10)
                        My10 = "عشرة";




                    if (Convert.ToDouble(MyNo.Substring( 0, 1)) > 0 & Convert.ToDouble(MyNo.Substring( 1, 2)) > 0)
                        My100 = My100 + MyAnd;
                    if (Convert.ToDouble(MyNo.Substring( 2, 1)) > 0 & Convert.ToDouble(MyNo.Substring( 1, 1)) > 1)
                        My1 = My1 + MyAnd;


                    GetTxt = My100 + My1 + My10;
                    if (Convert.ToDouble(MyNo.Substring( 2, 1)) == 1 & Convert.ToDouble(MyNo.Substring( 1, 1)) == 1)
                    {
                        GetTxt = My100 + My11;
                        if (Convert.ToDouble(MyNo.Substring( 0, 1)) == 0)
                            GetTxt = My11;
                    }

                    if (Convert.ToDouble(MyNo.Substring( 2, 1)) == 2d & Convert.ToDouble(MyNo.Substring( 1, 1)) == 1)
                    {
                        GetTxt = My100 + My12;
                        if (Convert.ToDouble(MyNo.Substring( 0, 1)) == 0)
                            GetTxt = My12;
                    }


                    if (i == 0 & GetTxt != "")
                    {
                        if (Convert.ToDouble(MyNo.Substring( 0, 3)) > 10)
                        {
                            Mybillion = GetTxt + " مليون";
                        }
                        else
                        {
                            Mybillion = GetTxt + " مليون";
                            if (Convert.ToDouble(MyNo.Substring( 0, 3)) == 2)
                                Mybillion = " مليون";
                            if (Convert.ToDouble(MyNo.Substring( 0, 3)) == 2)
                                Mybillion = " ملايين";
                        }
                    }

                    if (i == 3 & GetTxt != "")
                    {
                        if (Convert.ToDouble(MyNo.Substring( 0, 3)) > 10)
                        {
                            MyMillion = GetTxt + " مليون";
                        }
                        else
                        {
                            MyMillion = GetTxt + " ملايين";
                            if (Convert.ToDouble(MyNo.Substring( 0, 3)) == 1)
                                MyMillion = " مليون";
                            if (Convert.ToDouble(MyNo.Substring( 0, 3)) == 2)
                                MyMillion = " اتنان مليون";
                        }
                    }

                    if (i == 6 & GetTxt != "")
                    {
                        if (Convert.ToDouble(MyNo.Substring( 0, 3)) > 10)
                        {
                            MyThou = GetTxt + " ألف";
                        }
                        else
                        {
                            MyThou = GetTxt + " آلاف";
                            if (Convert.ToDouble(MyNo.Substring( 2, 1)) == 1)
                                MyThou = " ألف";
                            if (Convert.ToDouble(MyNo.Substring( 2, 1)) == 2)
                                MyThou = " ألفين";
                        }
                    }

                    if (i == 9 & GetTxt != "")
                        MyHun = GetTxt;
                    if (i == 12 & GetTxt != "")
                        MyFraction = GetTxt;

                }
          
            }

            if (!string.IsNullOrEmpty(Mybillion))
            {
                if (!string.IsNullOrEmpty(MyMillion) | !string.IsNullOrEmpty(MyThou) | !string.IsNullOrEmpty(MyHun))
                    Mybillion = Mybillion + MyAnd;
            }

            if (!string.IsNullOrEmpty(MyMillion))
            {
                if (!string.IsNullOrEmpty(MyThou) | !string.IsNullOrEmpty(MyHun))
                    MyMillion = MyMillion + MyAnd;
            }

            if (!string.IsNullOrEmpty(MyThou))
            {
                if (!string.IsNullOrEmpty(MyHun))
                    MyThou = MyThou + MyAnd;
            }

            if (!string.IsNullOrEmpty(MyFraction))
            {
                if (!string.IsNullOrEmpty(Mybillion) | !string.IsNullOrEmpty(MyMillion) | !string.IsNullOrEmpty(MyThou) | !string.IsNullOrEmpty(MyHun))
                {
                    MyNoToTxt = ReMark + Mybillion + MyMillion + MyThou + MyHun + " " + MyCur + MyAnd + MyFraction + " " + MySubCur;
                }
                else
                {
                    MyNoToTxt = ReMark + MyFraction + " " + MySubCur;
                }
            }
            else
            {
                MyNoToTxt = ReMark + Mybillion + MyMillion + MyThou + MyHun + " " + MyCur;
            }

            return MyNoToTxt;
        }

    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace sample_mvc7.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            return View();
        }
        #region Index post method
        [HttpPost]
        public JsonResult Index(string calcValues)
        {
            //for checking weather given string is >2 or not ,then only we can do any operation
            if (calcValues.Count() > 2)
            {

                var result = GetResult(calcValues);
                ViewBag.flag = 1;
                return Json(result, JsonRequestBehavior.AllowGet);
            }

            else
            {
                ViewBag.flag = 2;
                string noresult = "Wrong input";
                return Json(noresult, JsonRequestBehavior.AllowGet);
            }
        }
        #endregion

        #region GetResult method
        public string GetResult(string str)
        {
            //declaring below arrays globally

            List<char> symboll = new List<char>();
            char[] charsym = { '+', '-', '*', '/' };
            string[] numm = str.Split(charsym);
            for (int i = 0; i < str.Length; i++)
            {
                if (str[i] == '+' || str[i] == '-' || str[i] == '*' || str[i] == '/')
                {
                    symboll.Add(str[i]);
                }
            }

            //checking for initial array value
            if (str[0] == '+' || str[0] == '-' || str[0] == '*' || str[0] == '/')
            {
                if (str[0] == '+' || str[0] == '-')
                {
                    if (str[0] == '+')
                    {
                        double result = Convert.ToDouble(numm[1]);
                        //from above you may ask initial array is numm[0] then why we use numm[1] instead of numm[0] 
                        //it is because string [] is stored from [1], ex--if you enter 2,3,4 then numm[1]= 2 and so on.

                        for (int i = 2; i < numm.Length; i++)
                        {
                            double num = Convert.ToDouble(numm[i]);
                            int j = i - 1;
                            switch (symboll[j])
                            {
                                case '+':
                                    result = result + num;
                                    break;
                                case '-':
                                    result = result - num;
                                    break;
                                case '*':
                                    result = result * num;
                                    break;
                                case '/':
                                    result = result / num;
                                    break;
                                default:
                                    result = 0.0;
                                    break;
                            }
                        }
                        return result.ToString();
                    }
                    else
                    {

                        double resulte = Convert.ToInt32(numm[1]);

                        //as First symbol is minus first time only we do correction 
                        //1 time loop 

                        for (int a = 2; a < 3; a++)
                        {
                            resulte = Convert.ToInt32(numm[a - 1]);
                            double nume = Convert.ToInt32(numm[a]);

                            int v = a - 1;
                            switch (symboll[v])
                            {
                                case '+':
                                    if (nume > resulte)
                                    { resulte = nume - resulte; }
                                    else { resulte = -(resulte - nume); }
                                    break;
                                case '-':
                                    resulte = -(resulte + nume);
                                    break;
                                case '*':
                                    resulte = -(resulte * nume);
                                    break;
                                case '/':
                                    resulte = -(resulte / nume);
                                    break;
                                default:
                                    resulte = 0.0;
                                    break;
                            }
                        }

                        //for the further numbers and symbols we do normal opertion
                        for (int a = 3; a < numm.Length; a++)
                        {
                            double nume = Convert.ToInt32(numm[a]);

                            int v = a - 1;
                            switch (symboll[v])
                            {
                                case '+':
                                    resulte = resulte + nume;
                                    break;
                                case '-':
                                    resulte = resulte - nume;
                                    break;
                                case '*':
                                    resulte = resulte * nume;
                                    break;
                                case '/':
                                    resulte = resulte / nume;
                                    break;
                                default:
                                    resulte = 0.0;
                                    break;
                            }
                        }
                        return resulte.ToString();
                    }
                }
                else
                {
                    ViewBag.fla = 2;
                    return Request["txt"];
                }
            }
            else
            {
                double result = Convert.ToDouble(numm[1]);

                for (int i = 1; i < numm.Length; i++)
                {
                    double num = Convert.ToDouble(numm[i]);
                    int j = i - 1;
                    switch (symboll[j])
                    {
                        case '+':
                            result = result + num;
                            break;
                        case '-':
                            result = result - num;
                            break;
                        case '*':
                            result = result * num;
                            break;
                        case '/':
                            result = result / num;
                            break;

                        default:
                            result = 0.0;
                            break;
                    }
                }
                return result.ToString();
            }
        }
        #endregion

    }

}
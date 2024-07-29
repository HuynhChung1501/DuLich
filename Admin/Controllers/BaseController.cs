using Microsoft.AspNetCore.Mvc;
using System.Collections;
using Travel.Application.Contansts;
using Travel.Domain.Models;
using static System.Runtime.InteropServices.JavaScript.JSType;


namespace Travel.API.Controllers
{
    public class BaseController : Controller
    {
        /// <summary>
        /// Trả về JSon Code Success
        /// </summary>
        /// <param name="msg"></param>
        /// <returns></returns>
        protected IActionResult JSSuccessResult(string msg)
        {
            var a = new JsonData()
            {
                Status = CommonConst.Success,
                Message = msg
            };
            return Json(a);
        }
        /// <summary>
        /// Trả về JSon Code Success
        /// trả thêm data dạng Hashtable
        /// </summary>
        /// <param name="msg"></param>
        /// <returns></returns>
        protected IActionResult JSSuccessResult(string msg, Hashtable val)
        {
            var a = new JsonData()
            {
                Status = CommonConst.Success,
                Message = msg,
                Data = val
            };
            return Json(a);
        }


        /// <summary>
        /// Trả về JSon Code Error
        /// </summary>
        /// <param name="msg"></param>
        /// <returns></returns>
        protected IActionResult JSErrorResult(string msg)
        {
            var a = new JsonData()
            {
                Status = CommonConst.error,
                Message = msg
            };
            return Json(a);
        }
        /// <summary>
        /// Trả về JSon Code Error,
        /// Trả cả data dạng hashtable
        /// </summary>
        /// <param name="msg"></param>
        /// <returns></returns>
        protected IActionResult JSErrorResult(string msg, Hashtable val)
        {
            var a = new JsonData()
            {
                Status = CommonConst.error,
                Message = msg,
                Data = val
            };
            return Json(a);
        }
        /// <summary>
        /// Trả về JSon Code Warning
        /// </summary>
        /// <param name="msg"></param>
        /// <returns></returns>
        protected IActionResult JSWarningResult(string msg)
        {
            var a = new JsonData()
            {
                Status = CommonConst.warning,
                Message = msg
            };
            return Json(a);
        }
        /// <summary>
        /// Trả về JSon Code Warning,
        /// Trả cả data dạng hashtable
        /// </summary>
        /// <param name="msg"></param>
        /// <returns></returns>
        protected IActionResult JSWarningResult(string msg, Hashtable val)
        {
            var a = new JsonData()
            {
                Status = CommonConst.warning,
                Message = msg,
                Data = val
            };
            return Json(a);
        }
    }
}

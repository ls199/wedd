﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WebApplication1.ViewModels;
using WebApplication1.Models;

namespace WebApplication1.Controllers
{
    public class EmployeeController : Controller
    {
        // GET: Employee
        public ActionResult Index()
        {
            EmployeeListViewModel empListModel = new EmployeeListViewModel();
            EmployeeBusinessLayer empBL = new EmployeeBusinessLayer();
            var listEmp = empBL.GetEmployeeList();
            empListModel.EmployeeViewList = getEmpVmList(listEmp);
            //获取将处理过的数据列表
           // empListModel.EmployeeViewList =getEmpVmList();
            // 获取问候语
            empListModel.Greeting = getGreeting();
            //获取用户名
            empListModel.UserName = getUserName();
            //将数据送往视图
            return View(empListModel);
        }

        public ActionResult AddNew() {
            return View("CreateEmployee");
        }


        public ActionResult Save(Employee emp)
        {
            EmployeeBusinessLayer lay = new EmployeeBusinessLayer();
            lay.Add(emp);
            return new RedirectResult("index");
        }
        public ActionResult Delete(int id)
        {
            EmployeeBusinessLayer hht = new EmployeeBusinessLayer();
            //Employee emp = new Employee();
            hht.Delete(id);
           return  RedirectToAction("index");
        }

        public ActionResult CreateEmployee(Employee emp)
        {
            EmployeeBusinessLayer ebl = new EmployeeBusinessLayer();
            ebl.Add(emp);
            return RedirectToAction("index");
        }
        public ActionResult CreateEmployee()
        {
            return View();
        }
        public ActionResult Edit(int id)
        {
            EmployeeBusinessLayer ebl = new EmployeeBusinessLayer();
            Employee emp = ebl.Query(id);
            return View(emp);
        }
        [HttpPost]
        public ActionResult Edit(Employee emp)
        {
            EmployeeBusinessLayer ebl = new EmployeeBusinessLayer();
            ebl.Update(emp);
            return RedirectToAction("index");
        }

        public ActionResult Search(string searchString)
        {         
            EmployeeBusinessLayer ebl = new EmployeeBusinessLayer();
            var queryResult = ebl.Search(searchString);
            EmployeeListViewModel empListModel = new EmployeeListViewModel();
            empListModel.EmployeeViewList = getEmpVmList(queryResult.ToList());
            empListModel.Greeting = getGreeting();
            empListModel.UserName = getGreeting();
            return View("index",empListModel);

        }
      

        [NonAction]
        List<EmployeeViewModel> getEmpVmList(List<Employee>listEmp)
        {
            var listEmpVm = new List<EmployeeViewModel>();
            ////实例化员工信息业务层
            //EmployeeBusinessLayer empBL = new EmployeeBusinessLayer();
            ////员工原始数据列表，获取来自业务层类的数据
            //var listEmp = empBL.GetEmployeeList();
            ////员工原始数据加工后的视图数据列表，当前状态是空的
            //var listEmpVm = new List<EmployeeViewModel>();

            //通过循环遍历员工原始数据数组，将数据一个一个的转换，并加入listEmpVm
            foreach (var item in listEmp)
            {
                EmployeeViewModel empVmObj = new EmployeeViewModel();
                empVmObj.EmployeeId = item.EmployeeID;
                empVmObj.EmployeeName = item.Name;
                empVmObj.EmployeeSalary = item.Salary.ToString("C");
                if (item.Salary > 10000)
                {
                    empVmObj.EmployeeGrade = "土豪";
                }
                else
                {
                    empVmObj.EmployeeGrade = "qiong";
                }

                listEmpVm.Add(empVmObj);
            }

            return listEmpVm;

        }


        [NonAction]
        string getGreeting()
        {
            string greeting;
            //获取当前时间
            DateTime dt = DateTime.Now;
            //获取当前小时数
            int hour = dt.Hour;
            //根据小时数判断需要返回哪个视图，<12 返回myview 否则返回 yourview
            if (hour < 12)
            {
                greeting = "早上好";
            }
            else
            {
                greeting = "下午好";
            }
            return greeting;
        }


        [NonAction]
        string getUserName()
        {
            return "Admin";
        }
    }
}
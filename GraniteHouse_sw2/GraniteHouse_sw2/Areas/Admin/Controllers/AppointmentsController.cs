﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;
using GraniteHouse_sw2.Data;
using GraniteHouse_sw2.Models;
using GraniteHouse_sw2.Models.ViewModel;
using GraniteHouse_sw2.Utility;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace GraniteHouse_sw2.Areas.Admin.Controllers
{
    [Authorize(Roles = SD.SuperAdminEndUser + "," + SD.SuperAdminEndUser)]
    [Area("Admin")]
    public class AppointmentsController : Controller
    {

        private readonly ApplicationDbContext _db;
        private int PageSize = 3;

        public AppointmentsController(ApplicationDbContext db)
        {
            _db = db;
        }
        public async Task<IActionResult> Index(int productPage=1,string searchName = null, string searchEmail = null, string searchPhone = null, string searchDate = null)
        {

            System.Security.Claims.ClaimsPrincipal currentUser = this.User;
            var claimsIdentity = (ClaimsIdentity)this.User.Identity;
            var claim = claimsIdentity.FindFirst(ClaimTypes.NameIdentifier);

            AppointmentViewModel appointmentVM = new AppointmentViewModel()
            {
                Appointments = new List<Models.Appointments>()
            };


            //u have a search criteria &u filter that ???4
            StringBuilder param = new StringBuilder();
            param.Append("/Admin/Appointments?productPage=:");
            param.Append("&searchName");
            if(searchName!=null)
            {
                param.Append(searchName);
            }

            param.Append("&searchEmail");
            if(searchName!=null)
            {
                param.Append(searchEmail);
            }

            param.Append("&searchPhone");
            if(searchName!=null)
            {
                param.Append(searchPhone);
            }

            param.Append("&searchDate");
            if(searchName!=null)
            {
                param.Append(searchDate);
            }


            appointmentVM.Appointments = _db.Appointments.Include(a => a.SalesPerson).ToList();

            if (User.IsInRole(SD.AdminEndUser))
            {
                appointmentVM.Appointments = appointmentVM.Appointments.Where(a => a.SalesPersonId == claim.Value).ToList();
            }


            if (searchName != null)
            {
                appointmentVM.Appointments = appointmentVM.Appointments.Where(a => a.CustomerName.ToLower().Contains(searchName.ToLower())).ToList();

            }

            if (searchEmail != null)
            {
                appointmentVM.Appointments = appointmentVM.Appointments.Where(a => a.CustomerEmail.ToLower().Contains(searchEmail.ToLower())).ToList();

            }

            if (searchPhone != null)
            {
                appointmentVM.Appointments = appointmentVM.Appointments.Where(a => a.CustomerPhoneNumber.ToLower().Contains(searchPhone.ToLower())).ToList();

            }

            if (searchDate != null)
            {
                try
                {
                    DateTime appDate = Convert.ToDateTime(searchDate);
                    appointmentVM.Appointments = appointmentVM.Appointments.Where(a => a.AppointmentDate.ToShortDateString().Equals(appDate.ToShortDateString())).ToList();
                }
                catch (Exception ex)
                {

                }

            }



            var count = appointmentVM.Appointments.Count;

            appointmentVM.Appointments = appointmentVM.Appointments.OrderBy(p => p.AppointmentDate)
                .Skip((productPage - 1) * PageSize)
                .Take(PageSize).ToList();


            appointmentVM.PagingInfo = new PagingInfo
            {
                CurrentPage = productPage,
                ItemsPerPage = PageSize,
                TotalItems = count,
                urlParam = param.ToString()
            };


            return View(appointmentVM);
        }



        //  GET EDIT 
        public async Task<IActionResult> Edit (int? id)
        {
            if(id==null)
            {
                return NotFound();
            }

            var productList = (IEnumerable<Products>)(from p in _db.Products
                                                   join a in _db.ProductsSelectedForAppointment
                                                   on p.Id equals a.ProductId
                                                   where a.AppointmentId == id
                                                   select p).Include("ProductTypes");
            AppointmentDetailsViewModel objAppointmentVM = new AppointmentDetailsViewModel()
            {
                Appointment = _db.Appointments.Include(a => a.SalesPerson).Where(a => a.Id == id).FirstOrDefault(),
                SalesPerson = _db.ApplicationUser.ToList(),
                Products = productList.ToList()
            };

            return View(objAppointmentVM);

        }



        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit (int id , AppointmentDetailsViewModel objAppointmentVM)
        {
            if(ModelState.IsValid)
            {
                objAppointmentVM.Appointment.AppointmentDate = objAppointmentVM.Appointment.AppointmentDate
                    .AddHours(objAppointmentVM.Appointment.AppointmentTime.Hour)
                    .AddMinutes(objAppointmentVM.Appointment.AppointmentTime.Minute);
                var appointmentFromDb = _db.Appointments.Where(a => a.Id == objAppointmentVM.Appointment.Id).FirstOrDefault();

                appointmentFromDb.CustomerName = objAppointmentVM.Appointment.CustomerName;
                appointmentFromDb.CustomerEmail = objAppointmentVM.Appointment.CustomerEmail;
                appointmentFromDb.CustomerPhoneNumber = objAppointmentVM.Appointment.CustomerPhoneNumber;
                appointmentFromDb.AppointmentDate = objAppointmentVM.Appointment.AppointmentDate;
                appointmentFromDb.isConfirmed = objAppointmentVM.Appointment.isConfirmed;
                if(User.IsInRole(SD.SuperAdminEndUser))
                {
                    appointmentFromDb.SalesPersonId = objAppointmentVM.Appointment.SalesPersonId;
                }
                _db.SaveChanges();

                return RedirectToAction(nameof(Index));

            }
            return View(objAppointmentVM);
        }






        //  GET Details  
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var productList = (IEnumerable<Products>)(from p in _db.Products
                                                      join a in _db.ProductsSelectedForAppointment
                                                      on p.Id equals a.ProductId
                                                      where a.AppointmentId == id
                                                      select p).Include("ProductTypes");
            AppointmentDetailsViewModel objAppointmentVM = new AppointmentDetailsViewModel()
            {
                Appointment = _db.Appointments.Include(a => a.SalesPerson).Where(a => a.Id == id).FirstOrDefault(),
                SalesPerson = _db.ApplicationUser.ToList(),
                Products = productList.ToList()
            };

            return View(objAppointmentVM);

        }


         //  GET Delete  
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var productList = (IEnumerable<Products>)(from p in _db.Products
                                                      join a in _db.ProductsSelectedForAppointment
                                                      on p.Id equals a.ProductId
                                                      where a.AppointmentId == id
                                                      select p).Include("ProductTypes");
            AppointmentDetailsViewModel objAppointmentVM = new AppointmentDetailsViewModel()
            {
                Appointment = _db.Appointments.Include(a => a.SalesPerson).Where(a => a.Id == id).FirstOrDefault(),
                SalesPerson = _db.ApplicationUser.ToList(),
                Products = productList.ToList()
            };

            return View(objAppointmentVM);

        }


        [HttpPost,ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed  (int id )
        {

            var appointment = await _db.Appointments.FindAsync(id);
            _db.Appointments.Remove(appointment);
            await _db.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }
        



    }

}
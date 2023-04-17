using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Perdice.Data.IDataModel;
using Perdice.IServices;
using Perdice.Models;
using Perdice.Services;
using System;
using System.Data;
using System.Threading.Tasks;

namespace Perdice.Controllers
{
    public class BrandController : Controller
    {
        private readonly IBrandData _data;
        private readonly ILogger<BrandController> _logger;

        public BrandController(IBrandData data, ILogger<BrandController> logger)
        {
            _data = data;
            _logger = logger;
        }

        [HttpGet]
        //[Authorize(Roles = "Admin")]
        public async Task<ActionResult> Index()
        {
            try
            {
                _logger.LogInformation("Getting all data...");
                var data = await _data.GetAll();
                return View(data);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error getting all data");
                return View("Error");
            }
        }

        [HttpGet]
        [AllowAnonymous]
        public async Task<ActionResult> Details(int id)
        {
            try
            {
                _logger.LogInformation("Getting data by ID...");
                var result = await _data.GetById(id);
                //if (result == null) return new Brand();
                return View(result);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error getting data by ID");
                return View("Error");
            }
        }

        [HttpGet]
        [AllowAnonymous]
        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [AllowAnonymous]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create(Brand model)
        {
            try
            {
                _logger.LogInformation("Saving data...");
                await _data.SaveData(model);
                return RedirectToAction("Index");
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error saving data");
                return View("Error");
            }
        }

        [HttpGet]
        [AllowAnonymous]
        public async Task<ActionResult> Edit(int id)
        {
            try
            {
                _logger.LogInformation("Getting data by ID...");
                var result = await _data.GetById(id);
                //if (result == null) return HttpNotFound();
                return View(result);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error getting data by ID");
                return View("Error");
            }
        }

        [HttpPost]
        [AllowAnonymous]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Edit(Brand model)
        {
            try
            {
                _logger.LogInformation("Updating data...");
                await _data.UpdateData(model);
                return RedirectToAction("Index");
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error updating data");
                return View("Error");
            }
        }

        [HttpGet]
        [AllowAnonymous]
        public async Task<ActionResult> Delete(int id)
        {
            try
            {
                _logger.LogInformation("Getting data by ID...");
                var result = await _data.GetById(id);
                //if (result == null) return HttpNotFound();
                return View(result);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error getting data by ID");
                return View("Error");
            }
        }

        [HttpPost]
        [AllowAnonymous]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> DeleteConfirmed(int id)
        {
            try
            {
                _logger.LogInformation("Deleting data...");
                await _data.DeleteData(id);
                return RedirectToAction("Index");
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error deleting data");
                return View("Error");
            }
        }
    }
}

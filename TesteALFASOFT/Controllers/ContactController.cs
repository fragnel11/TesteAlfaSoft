using Microsoft.AspNetCore.Mvc;
using TesteALFASOFT.Models;
using TesteALFASOFT.Repositories;

namespace TesteALFASOFT.Controllers
{
    public class ContactController : Controller
    {
        private readonly IContactRepository _contactRepository;

        public ContactController(IContactRepository contactRepository)
        {
            _contactRepository = contactRepository;
        }

        // GET: Contact
        public async Task<IActionResult> Index()
        {
            return View(await _contactRepository.GetAllContactsAsync());
        }
        public async Task<IActionResult> Edit(int id)
        {
            var contact =await _contactRepository.GetConatactByIdAsync(id);
            return View(contact);
        }
        public async Task<IActionResult> Details(int id)
        {
            var contact = await _contactRepository.GetConatactByIdAsync(id);

            if (contact is null)
            {
                return null;
            }
            return View(contact);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(Contact contact)
        {
            if (ModelState.IsValid)
            {
                await _contactRepository.UpdateAsync(contact);
                return RedirectToAction("Index");
            }
            return View(contact);
        }
        [HttpGet]
        public async Task<IActionResult> Delete(int? id)
        {
            var contact = await _contactRepository.GetConatactByIdAsync(id.Value);
            return View(contact);
        }
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            await _contactRepository.Delete(id);
            return RedirectToAction(nameof(Index));
        }
        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Create(Contact contact)
        {
            try
            {
                await _contactRepository.CreateAsync(contact);

                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }
    }
}

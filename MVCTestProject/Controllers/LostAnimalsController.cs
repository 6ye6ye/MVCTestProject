using Microsoft.AspNet.Identity;
using System.Collections.Generic;
using System.ComponentModel;

namespace AnimalFinder.Controllers;

[AllowAnonymous]
public class LostAnimalsController : Controller
{
    private readonly IUnitOfWork _unitOfWork;
    private readonly IRepository<LostAnimal> _repository;
    private readonly IMapper _mapper;

    public LostAnimalsController(IUnitOfWork unitOfWork, IMapper mapper)
    {
        _unitOfWork = unitOfWork;
        _repository = unitOfWork.LostAnimals;
        _mapper = mapper;
    }

    // GET: LostAnimals
    [AllowAnonymous]
    [HttpGet]
    public IActionResult Index()
    {
        var lostAnimals = _repository.GetAll(null, c => c.CreateDate,
            ListSortDirection.Descending,
            (int)ItemsCountPerPage.Twenty)
            .AsEnumerable();

        var lostAnimalsDto = lostAnimals.Count() != 0 ? 
            _mapper.Map<IEnumerable<LostAnimalDtoGetShort>>(lostAnimals):
            null;

        var viewModel = new LostAnimalListViewModel()
        {
            LostAnimals = lostAnimalsDto,
        };

        return View(viewModel);
    }

    // GET: LostAnimals/Details/5
    [AllowAnonymous]
    public async Task<IActionResult> Details(Guid id)
    {
        if (id == null)
        {
            return NotFound();
        }

        var lostAnimal = _repository.GetById(id);
        if (lostAnimal == null)
        {
            return NotFound();
        }

        var viewModel = new LostAnimalViewModelGetFull(_mapper.Map<LostAnimalDtoGetFull>(lostAnimal));
        return View(viewModel);
    }

    // GET: LostAnimals/Create
    [Authorize]
    public ActionResult Create()
    {
        var districtList = _unitOfWork.Districts.GetAll();
        var viewModel = new LostAnimalViewModelAdd()
        {
            DistrictList = new SelectList(districtList, "Id", "Name")
        };

        return View(viewModel);
    }

    // POST: LostAnimals/Create
    // To protect from overposting attacks, enable the specific properties you want to bind to.
    // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
    [HttpPost]
    [ValidateAntiForgeryToken]
    [Authorize]
    public async Task<IActionResult> Create(LostAnimalViewModelAdd lostAnimalViewModel)
    {
        var lostAnimal = _mapper.Map<LostAnimal>(lostAnimalViewModel.LostAnimal);
        if (ModelState.IsValid)
        {
            lostAnimal.Id = Guid.NewGuid();
            lostAnimal.CreateDate = DateTime.Now;
            lostAnimal.CreatorId = new Guid(User.Identity.GetUserId());

            _repository.Create(lostAnimal);
            await _unitOfWork.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        return View(lostAnimalViewModel);
    }

    // GET: LostAnimals/Edit/5
    [Authorize]
    public async Task<IActionResult> Edit(Guid? id)
    {
        if (id == null) return NotFound();

        var lostAnimal = _repository.GetById((Guid)id);
        if (lostAnimal == null) return NotFound();

        var districtList = _unitOfWork.Districts.GetAll();
 
        var viewModel = new LostAnimalViewModelAdd()
        {
            DistrictList = new SelectList(districtList, "Id", "Name"),
            LostAnimal = _mapper.Map<LostAnimalDtoAdd>(lostAnimal)
        };

        return View(viewModel);
    }

    // POST: LostAnimals/Edit/5
    // To protect from overposting attacks, enable the specific properties you want to bind to.
    // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
    [HttpPost]
    [ValidateAntiForgeryToken]
    [Authorize]
    public async Task<IActionResult> Edit(Guid id, LostAnimalViewModelAdd lostAnimalViewModel)
    {
        if (id != lostAnimalViewModel.LostAnimal.Id)
        {
            return NotFound();
        }

        var lostAnimal = new LostAnimal();
        if (ModelState.IsValid)
        {
            try
            {
                _repository.Update(_mapper.Map<LostAnimal>(lostAnimalViewModel.LostAnimal));
                await _unitOfWork.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!LostAnimalExists(lostAnimalViewModel.LostAnimal.Id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return RedirectToAction(nameof(Index));
        }

        return View(lostAnimalViewModel);
    }


    // GET: LostAnimals/Delete/5
    [Authorize]
    public async Task<IActionResult> Delete(Guid? id)
    {
        if (id == null) return NotFound();

        var lostAnimal = _repository.GetById((Guid)id);
        if (lostAnimal == null) return NotFound();

        return View(lostAnimal);
    }

    // POST: LostAnimals/Delete/5
    [HttpPost, ActionName("Delete")]
    [ValidateAntiForgeryToken]
    [Authorize]
    public async Task<IActionResult> DeleteConfirmed(Guid id)
    {
        var lostAnimal = _repository.GetById(id);
        if (lostAnimal != null)
        {
            _repository.Delete(lostAnimal.Id);
            await _unitOfWork.SaveChangesAsync();
        }

        return RedirectToAction(nameof(Index));
    }

    private bool LostAnimalExists(Guid id)
    {
        return _repository.Any(e => e.Id == id);
    }

    [HttpGet]
    [AllowAnonymous]
    public IActionResult GetAllWithFilter(LostAnimalsFilterParam filter)
    {
        var filterExpresstion = FilterService.GetFilterExpression(filter);
        var sortingStruct = FilterService.GetSortingStruct(filter.Sort);

        var animals = _repository.GetAll(filterExpresstion, sortingStruct.Expression, sortingStruct.Direction, (int)filter.ItemsCount).AsEnumerable();
        var lostAnimals = _mapper.Map<IEnumerable<LostAnimalDtoGetShort>>(animals);
        return PartialView("LostAnimalsListPartial", lostAnimals);
    }
}
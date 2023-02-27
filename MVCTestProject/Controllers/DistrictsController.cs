namespace AnimalFinder.Controllers;

[Auth(UserRoleEnum.Admin)]
public class DistrictsController : Controller
{
    private readonly IUnitOfWork _unitOfWork;
    private readonly IRepository<District> _repository;
    private readonly IMapper _mapper;
    private readonly ILogger<DistrictsController> _logger;

    public DistrictsController(IUnitOfWork unitOfWork, IMapper mapper, ILogger<DistrictsController> logger)
    { 
        _unitOfWork = unitOfWork;
        _repository = unitOfWork.Districts;
        _mapper = mapper;
        _logger = logger;
    }

    // GET: Districts
    public IActionResult Index()
    {
        var viewModel = new DistrictListViewModel()
        {
            Districts = _repository.GetAll()
        };
        return View(viewModel);
    }

    // GET: Districts/Details/5
    public async Task<IActionResult> Details(Guid? id)
    {
        if (id == null)
        {
            return NotFound();
        }

        var district = _repository.GetById((Guid) id);
        if (district == null)
        {
            return NotFound();
        }

        return View(district);
    }

    // GET: Districts/Create
    public IActionResult Create()
    {
        return View();
    }

    // POST: Districts/Create
    // To protect from overposting attacks, enable the specific properties you want to bind to.
    // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
    [HttpPost]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> Create(DistrictViewModel districtViewModel)
    {
        if (ModelState.IsValid)
        {
            districtViewModel.Id = Guid.NewGuid();

            _repository.Create(_mapper.Map<District>(districtViewModel));
            await _unitOfWork.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        return View(districtViewModel);
    }

    // GET: Districts/Edit/5
    public async Task<IActionResult> Edit(Guid? id)
    {
        if (id == null)
        {
            return NotFound();
        }

        var district = _repository.GetById((Guid)id);
        if (district == null)
        {
            return NotFound();
        }

        return View(district);
    }

    // POST: Districts/Edit/5
    // To protect from overposting attacks, enable the specific properties you want to bind to.
    // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
    [HttpPost]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> Edit(Guid id, District district)
    {
        if (id != district.Id)
        {
            return NotFound();
        }

        if (ModelState.IsValid)
        {
            try
            {
                _repository.Update(district);
                await _unitOfWork.SaveChangesAsync();

            }
            catch (DbUpdateConcurrencyException)
            {
                if (!DistrictExists(district.Id))
                {
                    return NotFound();
                }
                throw;
            }

            return RedirectToAction(nameof(Index));
        }

        return View(district);
    }

    // POST: Districts/Delete/5
    [HttpPost, ActionName("Delete")]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> DeleteConfirmed(Guid id)
    {
        var district = _repository.GetById(id);
        if (district != null)
        {
            _repository.Delete(district.Id);
            await _unitOfWork.SaveChangesAsync();
        }

        return RedirectToAction(nameof(Index));
    }

    private bool DistrictExists(Guid id)
    {
        return _repository.Any(e => e.Id == id);
    }
}
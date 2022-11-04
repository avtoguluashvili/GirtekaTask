using Aggregation.Domain;
using Aggregation.Dto;
using Aggregation.Interfaces;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;

namespace AggregateAPI.Controllers;

[Route("api/aggregate")]
[ApiController]
public class AggregationController : ControllerBase
{
    #region Constructor
    private readonly ILogger<AggregationController> _logger;
    private readonly ICsvData _csvData;
    private readonly IMapper _mapper;

    public AggregationController(ICsvData csvData, ILogger<AggregationController> logger, IMapper mapper)
    {
        _csvData = csvData;
        _logger = logger;
        _mapper = mapper;
    }
    #endregion

    [HttpGet("getCsvData")]
    public async Task<IActionResult> GetCsvData()
    {
        _logger.LogInformation("Data retreiving proccess..");
        var data = _csvData.GetCsvDataAsync<List<AggregateDataDto>>();

        return Ok(data);
    }

    [HttpPost("saveCsvData")]
    public async Task<IActionResult> SaveCsvData()
    {
        var data = _csvData.SaveCsvData<AggregateData>();

        if (data)
        {
            _logger.LogInformation("Data Saving process..");
        }
        else
        {
            _logger.LogInformation("Bad Request");
            return BadRequest(data);

        }
        return Ok(data);
    }

}
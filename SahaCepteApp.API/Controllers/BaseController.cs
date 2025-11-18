using Microsoft.AspNetCore.Mvc;
using SahaCepteApp.Application.Helpers;

namespace SahaCepteApp.API.Controllers;

public abstract class BaseController(LogHelper logger) : ControllerBase
{
    protected readonly LogHelper Logger = logger;
}
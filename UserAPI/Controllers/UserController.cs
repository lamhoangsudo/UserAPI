using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.JsonPatch;
using Microsoft.AspNetCore.Mvc;
using UserAPI.Data_View_Model;
using UserAPI.Repository.IRepository;

namespace UserAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly IUserRepository _userRepository;

        public UserController(IUserRepository userRepository)
        {
            _userRepository = userRepository;
        }
        [HttpGet]
        public IActionResult GetAll()
        {
            try
            {
                var list = _userRepository.GetAll();
                if (list == null || list.Count == 0)
                {
                    return StatusCode(StatusCodes.Status404NotFound);
                }else
                {
                    return Ok(list);
                }
            }catch
            {
                return StatusCode(StatusCodes.Status500InternalServerError);
            }
        }
        [HttpGet("{id}")]
        public IActionResult GetByID(string id)
        {
            try
            {
                UserVM user = _userRepository.GetById(id);
                if (user == null)
                {
                    return StatusCode(StatusCodes.Status404NotFound);
                }
                else
                {
                    return Ok(user);
                }
            }
            catch
            {
                return StatusCode(StatusCodes.Status500InternalServerError);
            }
        }
        [HttpGet("/E{email}")]
        public IActionResult GetByEmail(string email)
        {
            try
            {
                var listResult = _userRepository.GetByEmail(email);
                if (listResult == null || listResult.Count == 0)
                {
                    return StatusCode(StatusCodes.Status404NotFound);
                }
                else
                {
                    return Ok(listResult);
                }
            }
            catch
            {
                return StatusCode(StatusCodes.Status500InternalServerError);
            }
        }
        [HttpGet("/F{name}")]
        public IActionResult GetByFirstName(string name)
        {
            try
            {
                var listResult = _userRepository.GetByFirstName(name);
                if (listResult == null || listResult.Count == 0)
                {
                    return StatusCode(StatusCodes.Status404NotFound);
                }
                else
                {
                    return Ok(listResult);
                }
            }
            catch
            {
                return StatusCode(StatusCodes.Status500InternalServerError);
            }
        }
        [HttpGet("/L{name}")]
        public IActionResult GetByLastName(string name)
        {
            try
            {
                var listResult = _userRepository.GetByLastName(name);
                if (listResult == null || listResult.Count == 0)
                {
                    return StatusCode(StatusCodes.Status404NotFound);
                }
                else
                {
                    return Ok(listResult);
                }
            }
            catch
            {
                return StatusCode(StatusCodes.Status500InternalServerError);
            }
        }
        [HttpGet("/P{phone}")]
        public IActionResult GetByPhone(string phone)
        {
            try
            {
                var listResult = _userRepository.GetByPhone(phone);
                if (listResult == null || listResult.Count == 0)
                {
                    return StatusCode(StatusCodes.Status404NotFound);
                }
                else
                {
                    return Ok(listResult);
                }
            }
            catch
            {
                return StatusCode(StatusCodes.Status500InternalServerError);
            }
        }
        [HttpGet("/S{status}")]
        public IActionResult GetByStatus(bool status)
        {
            try
            {
                var listResult = _userRepository.GetByStatus(status);
                if (listResult == null || listResult.Count == 0)
                {
                    return StatusCode(StatusCodes.Status404NotFound);
                }
                else
                {
                    return Ok(listResult);
                }
            }
            catch
            {
                return StatusCode(StatusCodes.Status500InternalServerError);
            }
        }
        [HttpPut("/U{id}")]
        public IActionResult UpdateUser(string id, string phone, string address, string firstName, string lastName)
        {
            try
            {
                var user = _userRepository.GetById(id);
                if (user == null || user.Status == false)
                {
                    return StatusCode(StatusCodes.Status404NotFound);
                }
                else
                {
                    bool check = _userRepository.UpdateUser(id, phone, address, firstName, lastName);
                    if (check == true)
                    {
                        return Ok(check);
                    }
                    else
                    {
                        return StatusCode(StatusCodes.Status400BadRequest);
                    }
                }
            }
            catch
            {
                return StatusCode(StatusCodes.Status500InternalServerError);
            }
        }
        [HttpPut("/D{id}")]
        public IActionResult DeleteUser(string id)
        {
            try
            {
                var user = _userRepository.GetById(id);
                if (user == null || user.Status == false)
                {
                    return StatusCode(StatusCodes.Status404NotFound);
                }
                else
                {
                    bool check = _userRepository.DeleteUser(id);
                    if (check == true)
                    {
                        return Ok(check);
                    }
                    else
                    {
                        return StatusCode(StatusCodes.Status400BadRequest);
                    }
                }
            }
            catch
            {
                return StatusCode(StatusCodes.Status500InternalServerError);
            }
        }
        [HttpPost] 
        public IActionResult CreateUser(int roleId, string email)
        {
            try
            {
                bool check = _userRepository.CreateUser(roleId, email);
                if (check == true)
                {
                    return Ok(check);
                }
                else
                {
                    return StatusCode(StatusCodes.Status400BadRequest);
                }
            }
            catch
            {
                return StatusCode(StatusCodes.Status500InternalServerError);
            }
        }
    }
}

using Microsoft.EntityFrameworkCore;
using UserAPI.Data_View_Model;

namespace UserAPI.Repository.IRepository
{
    public class UserRepository : IUserRepository
    {
        private readonly APIDbContext _context;

        public UserRepository(APIDbContext context)
        {
            _context = context;
        }

        public bool CreateUser(int roleId, string email)
        {
            string userId = Guid.NewGuid().ToString();
            var checkRole = _context.Roles.FromSqlInterpolated($"EXEC GetUserRole {roleId}").ToList().SingleOrDefault();
            if (checkRole == null || email == null || email.Equals(""))
            {
                return false;
            }
            else
            {
                var checkCreate = _context.Database.ExecuteSqlInterpolated($"EXEC CREATEUSER {userId}, {roleId}, {email}");
                if (checkCreate != 0)
                {
                    _context.SaveChanges();
                    return true;
                }
                else
                {
                    return false;
                }
            }
        }

        public bool DeleteUser(string id)
        {
            var check = _context.Database.ExecuteSqlInterpolated($"EXEC DeleteUser {id}");
            if (check != 0)
            {
                _context.SaveChanges();
                return true;
            }
            else
            {
                return false;
            }
        }
        public List<UserVM> GetAll()
        {
            var listUser = _context.Users.FromSqlRaw("EXEC GetALL").ToList().Select(user => new UserVM
            {
                Id = user.UserId,
                Email = user.Email,
                Phone = user.Phone,
                Address = user.Address,
                FirstName = user.FirstName,
                LastName = user.LastName,
                Status = user.Status
            });
            return listUser.ToList();
        }

        public List<UserVM> GetByEmail(string email)
        {
            var listUserResult = _context.Users.FromSqlInterpolated($"EXEC GetByEmail {email}").ToList().Select(user => new UserVM
            {
                Id = user.UserId,
                Email = user.Email,
                Phone = user.Phone,
                Address = user.Address,
                FirstName = user.FirstName,
                LastName = user.LastName,
                Status = user.Status
            });
            return listUserResult.ToList();
        }

        public List<UserVM> GetByFirstName(string name)
        {
            var listUserResult = _context.Users.FromSqlInterpolated($"EXEC GetByFirstName {name}").ToList().Select(user => new UserVM
            {
                Id = user.UserId,
                Email = user.Email,
                Phone = user.Phone,
                Address = user.Address,
                FirstName = user.FirstName,
                LastName = user.LastName,
                Status = user.Status
            });
            return listUserResult.ToList();
        }

        public UserVM GetById(string id)
        {
            var user = _context.Users.FromSqlInterpolated($"EXEC GetById {id}").ToList().SingleOrDefault();
            return new UserVM
            {
                Id = user.UserId,
                Email = user.Email,
                Phone = user.Phone,
                Address = user.Address,
                FirstName = user.FirstName,
                LastName = user.LastName,
                Status = user.Status
            };
        }

        public List<UserVM> GetByLastName(string name)
        {
            var listUserResult = _context.Users.FromSqlInterpolated($"EXEC GetByLastName {name}").ToList().Select(user => new UserVM
            {
                Id = user.UserId,
                Email = user.Email,
                Phone = user.Phone,
                Address = user.Address,
                FirstName = user.FirstName,
                LastName = user.LastName,
                Status = user.Status
            });
            return listUserResult.ToList();
        }

        public List<UserVM> GetByPhone(string phone)
        {
            var listUserResult = _context.Users.FromSqlInterpolated($"EXEC GetByPhone {phone}").ToList().Select(user => new UserVM
            {
                Id = user.UserId,
                Email = user.Email,
                Phone = user.Phone,
                Address = user.Address,
                FirstName = user.FirstName,
                LastName = user.LastName,
                Status = user.Status
            });
            return listUserResult.ToList();
        }

        public List<UserVM> GetByStatus(bool status)
        {
            var listUserResult = _context.Users.FromSqlInterpolated($"EXEC GetByStatus {status}").ToList().Select(user => new UserVM
            {
                Id = user.UserId,
                Email = user.Email,
                Phone = user.Phone,
                Address = user.Address,
                FirstName = user.FirstName,
                LastName = user.LastName,
                Status = user.Status
            });
            return listUserResult.ToList();
        }

        public bool UpdateUser(string id, string phone, string address, string firstName, string lastName)
        {
            var check = _context.Database.ExecuteSqlInterpolated($"EXEC UpdateUser {id},{phone},{address},{firstName},{lastName}");
            if (check != 0)
            {
                _context.SaveChanges();
                return true;
            }
            else
            {
                return false;
            }
        }
    }
}

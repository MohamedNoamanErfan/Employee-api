using Core.Entities;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Data
{
    public class EmployeeContextSeed
    {
        public static async Task SeedEmployeeAsync(EmployeeContext context, ILoggerFactory loggerFactory)
        {
            try
            {
                var employee = new Employee();
                if (!context.Employees.Any())
                {
                    employee = new Employee
                    {
                        CreatedON = DateTime.Now,
                        UpdatedON = DateTime.Now,
                        Name = "Omar",
                        Email = "Omar.noaman@gmail.com",
                        PhoneNo = "01140254125"
                    };
                    context.Employees.Add(employee);
                    await context.SaveChangesAsync();
                }
                if (!context.EmployeeAttendances.Any())
                {

                    var employeeAttendancelst = new List<EmployeeAttendance>()
                    {
                        new EmployeeAttendance
                        {
                            UpdatedON = DateTime.UtcNow,
                            CreatedON = DateTime.UtcNow,
                            SRVDT = DateTime.Parse("2023-01-02 08:32:52.0000000"),
                            DEVDT = 1672633967,
                            DEVUID = 939265762,
                           EmployeeId = employee.Id
                        },
                        new EmployeeAttendance
                        {
                             UpdatedON = DateTime.UtcNow,
                            CreatedON = DateTime.UtcNow,
                            SRVDT = DateTime.Parse("2023-01-02 16:29:51.0000000"),
                            DEVDT = 1672662587,
                            DEVUID = 939265762,
                            EmployeeId = employee.Id
                        }
                        ,
                        new EmployeeAttendance
                        {
                             UpdatedON = DateTime.UtcNow,
                            CreatedON = DateTime.UtcNow,
                            SRVDT = DateTime.Parse("2023-01-03 07:27:59.0000000"),
                            DEVDT = 1672716474,
                            DEVUID = 939265762,
                            EmployeeId = employee.Id
                        }
                        ,
                        new EmployeeAttendance
                        {
                             UpdatedON = DateTime.UtcNow,
                            CreatedON = DateTime.UtcNow,
                            SRVDT = DateTime.Parse("2023-01-03 15:28:01.0000000"),
                            DEVDT = 1672745281,
                            DEVUID = 939265762,
                            EmployeeId = employee.Id
                        }
                        ,
                        new EmployeeAttendance
                        {
                             UpdatedON = DateTime.UtcNow,
                            CreatedON = DateTime.UtcNow,
                            SRVDT = DateTime.Parse("2023-01-04 10:14:40.0000000"),
                            DEVDT = 1672805230,
                            DEVUID = 939265762,
                            EmployeeId = employee.Id
                        }
                        ,
                        new EmployeeAttendance
                        {
                             UpdatedON = DateTime.UtcNow,
                            CreatedON = DateTime.UtcNow,
                            SRVDT = DateTime.Parse("2023-01-04 10:14:40.0000000"),
                            DEVDT = 1672805230,
                            DEVUID = 939265762,
                            EmployeeId = employee.Id
                        }
                        ,
                        new EmployeeAttendance
                        {
                             UpdatedON = DateTime.UtcNow,
                            CreatedON = DateTime.UtcNow,
                            SRVDT = DateTime.Parse("2023-01-04 16:45:48.0000000"),
                            DEVDT = 1672836346,
                            DEVUID = 939265762,
                            EmployeeId = employee.Id
                        }
                        ,
                        new EmployeeAttendance
                        {
                             UpdatedON = DateTime.UtcNow,
                            CreatedON = DateTime.UtcNow,
                            SRVDT = DateTime.Parse("2023-01-05 08:28:25.0000000"),
                            DEVDT = 1672892904,
                            DEVUID = 939265762,
                            EmployeeId = employee.Id
                        },
                        new EmployeeAttendance
                        {
                             UpdatedON = DateTime.UtcNow,
                            CreatedON = DateTime.UtcNow,
                            SRVDT = DateTime.Parse("2023-01-05 16:28:09.0000000"),
                            DEVDT = 1672921687,
                            DEVUID = 939265762,
                            EmployeeId = employee.Id
                        },
                        new EmployeeAttendance
                        {
                             UpdatedON = DateTime.UtcNow,
                            CreatedON = DateTime.UtcNow,
                            SRVDT = DateTime.Parse("2023-01-09 08:33:13.0000000"),
                            DEVDT = 1673238788,
                            DEVUID = 939265762,
                            EmployeeId = employee.Id
                        },
                        new EmployeeAttendance
                        {
                             UpdatedON = DateTime.UtcNow,
                            CreatedON = DateTime.UtcNow,
                            SRVDT = DateTime.Parse("2023-01-09 16:31:26.0000000"),
                            DEVDT = 1673267481,
                            DEVUID = 939265762,
                            EmployeeId = employee.Id
                        },
                        new EmployeeAttendance
                        {
                             UpdatedON = DateTime.UtcNow,
                            CreatedON = DateTime.UtcNow,
                            SRVDT = DateTime.Parse("2023-01-10 08:38:06.0000000"),
                            DEVDT = 1673325481,
                            DEVUID = 939265762,
                            EmployeeId = employee.Id
                        },
                        new EmployeeAttendance
                        {
                             UpdatedON = DateTime.UtcNow,
                            CreatedON = DateTime.UtcNow,
                            SRVDT = DateTime.Parse("2023-01-10 10:21:06.0000000"),
                            DEVDT = 1673331966,
                            DEVUID = 939265762,
                            EmployeeId = employee.Id
                        },
                        new EmployeeAttendance
                        {
                             UpdatedON = DateTime.UtcNow,
                            CreatedON = DateTime.UtcNow,
                            SRVDT = DateTime.Parse("2023-01-10 11:15:16.0000000"),
                            DEVDT = 1673334916,
                            DEVUID = 939265762,
                            EmployeeId = employee.Id
                        }
                         ,
                        new EmployeeAttendance
                        {
                             UpdatedON = DateTime.UtcNow,
                            CreatedON = DateTime.UtcNow,
                            SRVDT = DateTime.Parse("2023-01-10 13:45:46.0000000"),
                            DEVDT = 1673343946,
                            DEVUID = 939265762,
                            EmployeeId = employee.Id
                        },
                        new EmployeeAttendance
                        {
                             UpdatedON = DateTime.UtcNow,
                            CreatedON = DateTime.UtcNow,
                            SRVDT = DateTime.Parse("2023-01-10 16:38:38.0000000"),
                            DEVDT = 1673527118,
                            DEVUID = 939265762,
                            EmployeeId = employee.Id
                        }
                    };
                    context.EmployeeAttendances.AddRange(employeeAttendancelst);
                    await context.SaveChangesAsync();
                }
            }
            catch (Exception ex)
            {
                var logger = loggerFactory.CreateLogger<EmployeeContextSeed>();
                logger.LogError(ex.Message);
            }

        }
    }
}

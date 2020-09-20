using System;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using CrudLondrisoft.Models;

namespace CrudLondrisoft.Data
{
    public static class SeedData
    {
        public static void Initialize(CrudLondrisoftContext context)
        {
            if (!context.Student.Any())
            {
                context.Student.AddRange(
                    new Student
                    {   
                        StundentId  = 1,
                        Name = "Fabricio Docema de Oliveira",
                        RegistrationCode = "1",
                        DateBirthday = new DateTime(1991,11,25),
                        ZipCode = "13870-000",
                        Street = "Av Carolina Malheiros",
                        Number = "10",
                        Complement = "Ap 1",
                        Neighborhood = "Vila Conrado",
                        City = "São João da Boa Vista",
                        State = "SP", 
                        Email = "fa.docema@gmail.com"
                    }
                );
                context.SaveChanges();
            }
        }
    }
}
using Xunit;
using PhonebookAPI.Data;
using PhonebookAPI.Models;
using PhonebookAPI.Services;
using System;
using System.Linq;
using System.Collections.Generic;
using Moq;
using Microsoft.EntityFrameworkCore;

namespace phonebook_api.tests.PhonebookServicesTests
{
    public class ServiceTests
    {
        [Theory]
        [InlineData(1)]
        public async void ReturnPersonById_GivenValidIdShoulReturnPersonRecord(int id)
        {

            var mock = new Mock<PhonebookContext>();
            mock.Setup(x => x.People)
                .Returns(TranformingListToDbSet(MockedListOfPeople()));
            var serviceMock = new PhonebookServices(mock.Object);
            
            var expected = MockedMethodToReturnByIdInMockedList(id);
            Console.WriteLine(expected.Name);
            var actual = await serviceMock.ReturnPersonById(id);
            Console.WriteLine(actual.Name);
            Assert.Equal(expected, actual);
        }

        private DbSet<Person> TranformingListToDbSet(List<Person> list)
        {
            var dbSet = new Mock<DbSet<Person>>();
            foreach (var person in list)
                dbSet.Setup(x => x.Add(person));
            return dbSet.Object;
        }
        private List<Person> MockedListOfPeople()
        {
            return new List<Person>
            {
                new Person()
                {
                    Id = 1,
                    CPF = "42954877081",
                    Name = "Tulio",
                    LastName = "Palhares",
                    BirthDate = DateTime.Parse("01/01/1990")
                },
                new Person()
                {
                    Id = 2,
                    CPF = "68178946033",
                    Name = "David",
                    LastName = "Camilo",
                    BirthDate = DateTime.Parse("11/09/1985")
                },
                new Person()
                {
                    Id = 3,
                    CPF = "71698041071",
                    Name = "Simão",
                    LastName = "Pimenta",
                    BirthDate = DateTime.Parse("14/04/1999")
                }
            };
        }
        private Person MockedMethodToReturnByIdInMockedList(int id)
        {
            var listToGetPersonById = MockedListOfPeople();
            return listToGetPersonById.FirstOrDefault(x => x.Id == id);
        }
    }
}
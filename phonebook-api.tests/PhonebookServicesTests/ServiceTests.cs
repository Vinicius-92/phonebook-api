using Xunit;
using phonebook_api;
using PhonebookAPI.Data;
using PhonebookAPI.Models;
using PhonebookAPI.Services;
using System;
using System.Threading.Tasks;

namespace phonebook_api.tests.PhonebookServicesTests
{
    // public class ServiceTests
    // {
        // [Theory]
        // [InlineData(1)]
        // public void ReturnPersonById_ShoudReturnPersonWhenInsertedValidIdAsync(int id)
        // {
        //     using (var mock = AutoMock.GetLoose())
        //     {
        //         mock.Mock<IPhonebookService>()
        //             .Setup(x => x.ReturnPersonById(id))
        //             .Returns(SampleOfOnePersonToReturn(id));

        //         var phoneBookService = mock.Create<PhonebookServices>();
        //         var expected = SampleOfOnePersonToReturn(id);
        //         var actual = phoneBookService.ReturnPersonById(id);
        //         Console.WriteLine(actual.ToString());
        //         Console.WriteLine(expected.ToString());
        //         Assert.True(actual != null);
        //         Assert.Equal(expected, actual);
        //     }
        // }

        // private Task<Person> SampleOfOnePersonToReturn(int id)
        // {
        //     var person = new Person
        //     {
        //         Id = id,
        //         Name = "Vinicius",
        //         LastName = "Augusto",
        //         BirthDate = DateTime.Parse("14/02/1992"),
        //         CPF = "41496861817"
        //     };
        //     return Task.FromResult(person);
        // }
        
    // }
}
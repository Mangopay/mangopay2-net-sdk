using System;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using MangoPay.SDK.Core.Enumerations;
using MangoPay.SDK.Entities;
using MangoPay.SDK.Entities.GET;
using MangoPay.SDK.Entities.POST;
using MangoPay.SDK.Entities.PUT;
using NUnit.Framework;

namespace MangoPay.SDK.Tests
{
    [TestFixture]
    public class ApiUboDeclarationTests : BaseTest
    {
        [SetUp]
        public void SetUp()
        {
            _mangopayApi = BuildNewMangoPayApi();
        }

        private MangoPayApi _mangopayApi;

        private static List<UboPostDTO> UboPostDtoCollection
        {
            get
            {
                var address = new Address
                {
                    AddressLine1 = "Address line Natural1 1",
                    AddressLine2 = "Address line Natural1 2",
                    City = "CityNatural1",
                    Country = CountryIso.PL,
                    PostalCode = "11222",
                    Region = "RegionNatural1"
                };
                var birthDate = new DateTime(1985, 12, 21, 0, 0, 0);
                var birthPlace = new Birthplace
                {
                    City = "CityNatural1",
                    Country = CountryIso.PL
                };

                return new List<UboPostDTO>
                {
                    new UboPostDTO("JohnNatural1", "DoeNatural1", address, CountryIso.DE, birthDate, birthPlace),
                    new UboPostDTO("JohnNatural2", "DoeNatural2", address, CountryIso.DE, birthDate, birthPlace)
                };
            }
        }

        //Ubo tests

        [Test]
        public void ApiUbo_Create_Ubo_Valid()
        {
            var userLegal = Api.Users.Create(CreateUserLegalPost());
            var uboDeclaration = Api.UboDeclarations.CreateUboDeclaration(null, userLegal.Id);
            var uboDto = UboPostDtoCollection[0];
            UboDTO result = null;
            Assert.DoesNotThrow(() => result = Api.UboDeclarations.CreateUbo(uboDto, userLegal.Id, uboDeclaration.Id));
            Assert.NotNull(result);
        }

        [Test]
        public void ApiUbo_Update_Ubo_Valid()
        {
            var userLegal = Api.Users.Create(CreateUserLegalPost());
            var uboDeclaration = Api.UboDeclarations.CreateUboDeclaration(null, userLegal.Id);
            var uboDto = UboPostDtoCollection[1];
            var ubo = Api.UboDeclarations.CreateUbo(uboDto, userLegal.Id, uboDeclaration.Id);
            var address = new Address
            {
                AddressLine1 = "Address line Natural1 1",
                AddressLine2 = "Address line Natural1 2",
                City = "CityNatural1",
                Country = CountryIso.PL,
                PostalCode = "11222",
                Region = "RegionNatural1"
            };
            var birthDate = new DateTime(1985, 12, 21, 0, 0, 0);
            var birthPlace = new Birthplace
            {
                City = "CityNatural1",
                Country = CountryIso.PL
            };
            var uboPutDto = new UboPutDTO("JohnNatural1", "DoeNatural1", address, CountryIso.DE, birthDate, birthPlace);
            UboDTO result = null;
            Assert.DoesNotThrow(() =>
                result = Api.UboDeclarations.UpdateUbo(uboPutDto, userLegal.Id, uboDeclaration.Id, ubo.Id));
            Assert.NotNull(result);
            Assert.AreEqual(ubo.Id, result.Id);
            Assert.AreEqual(uboPutDto.FirstName, result.FirstName);
        }

        [Test]
        public void ApiUboDeclaration_Create_UboDeclaration_Valid()
        {
            var userLegal = Api.Users.Create(CreateUserLegalPost());

            UboDeclarationDTO result = null;

            Assert.DoesNotThrow(() => result = Api.UboDeclarations.CreateUboDeclaration(null, userLegal.Id));
            Assert.That(result.Status == UboDeclarationType.CREATED);
            Assert.That(result.CreationDate != DateTime.MinValue);
        }

        [Test]
        public void ApiUboDeclaration_Get_UboDeclaration_Valid()
        {
            var userLegal = Api.Users.Create(CreateUserLegalPost());

            UboDeclarationDTO uboDeclaration = null;
            Assert.DoesNotThrow(() => uboDeclaration = Api.UboDeclarations.Create(userLegal.Id));
            UboDeclarationDTO result = null;
            Assert.DoesNotThrow(() =>
                result = Api.UboDeclarations.GetUboDeclarationById(userLegal.Id, uboDeclaration.Id));
            Assert.NotNull(result);
            Assert.AreEqual(uboDeclaration.Id, result.Id);
        }

        [Test]
        public void ApiUboDeclaration_GetById_UboDeclaration_Valid()
        {
            var userLegal = Api.Users.Create(CreateUserLegalPost());

            UboDeclarationDTO uboDeclaration = null;
            Assert.DoesNotThrow(() => uboDeclaration = Api.UboDeclarations.Create(userLegal.Id));

            UboDeclarationDTO result = null;
            Assert.DoesNotThrow(() => result = Api.UboDeclarations.GetUboDeclarationById(uboDeclaration.Id));
            Assert.NotNull(result);
            Assert.AreEqual(uboDeclaration.Id, result.Id);
        }

        //UboDeclarations test
        [Test]
        public void ApiUboDeclaration_GetAll_UboDeclaration_Valid()
        {
            var userLegal = Api.Users.Create(CreateUserLegalPost());
            var uboDeclarationDto = Api.UboDeclarations.Create(userLegal.Id);

            ListPaginated<UboDeclarationDTO> result = null;
            Pagination pagination = new Pagination(1, 1);
            Assert.DoesNotThrow(() => result = Api.UboDeclarations.GetUboDeclarationByUserId(userLegal.Id, pagination));
            Assert.NotNull(result);
            Assert.IsTrue(result.Count > 0);
            Assert.AreEqual(uboDeclarationDto.Id, result[0].Id);
        }

        [Test]
        public void ApiUboDeclaration_Update_UboDeclaration_Valid()
        {
            var userLegal = Api.Users.Create(CreateUserLegalPost());

            var uboDeclaration = Api.UboDeclarations.CreateUboDeclaration(null, userLegal.Id);

            List<UboPostDTO> ubopostDtos = UboPostDtoCollection;
            List<UboDTO> uboDtos = new List<UboDTO>();

            foreach (var uboPost in ubopostDtos)
            {
                var ubo = Api.UboDeclarations.CreateUbo(null, uboPost, userLegal.Id, uboDeclaration.Id);
                uboDtos.Add(ubo);
            }

            UboDeclarationPutDTO ubodeclarationPut =
                new UboDeclarationPutDTO(uboDtos.ToArray(), UboDeclarationType.VALIDATION_ASKED);

            UboDeclarationDTO result = null;

            Assert.DoesNotThrow(() =>
                result = Api.UboDeclarations.UpdateUboDeclaration(ubodeclarationPut, userLegal.Id, uboDeclaration.Id));
            Assert.That(result != null);
            Assert.AreEqual(uboDeclaration.Id, result.Id);
            Assert.That(result.Status == UboDeclarationType.VALIDATION_ASKED);
            Assert.That(result.CreationDate != DateTime.MinValue);
        }
    }
}
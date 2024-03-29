﻿using System;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using System.Threading.Tasks;
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

        [Test]
        public async Task ApiUbo_Create_Ubo_Valid()
        {
            var userLegal = await Api.Users.CreateOwnerAsync(CreateUserLegalPost());
            var uboDeclaration = await Api.UboDeclarations.CreateUboDeclarationAsync(userLegal.Id);
            var uboDto = UboPostDtoCollection[0];
            UboDTO result = null;
            Assert.DoesNotThrowAsync(async () => result = await Api.UboDeclarations.CreateUboAsync(uboDto, userLegal.Id, uboDeclaration.Id));
            Assert.NotNull(result);
        }

        [Test]
        public async Task ApiUbo_Update_Ubo_Valid()
        {
            var userLegal = await Api.Users.CreateOwnerAsync(CreateUserLegalPost());
            var uboDeclaration = await Api.UboDeclarations.CreateUboDeclarationAsync(userLegal.Id);
            var uboDto = UboPostDtoCollection[1];
            var ubo = await Api.UboDeclarations.CreateUboAsync(uboDto, userLegal.Id, uboDeclaration.Id);
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
            var uboPutDto = new UboPutDTO("JohnNatural1", "DoeNatural1", address, CountryIso.DE, birthDate, birthPlace)
                {
                    IsActive = true
                };
            UboDTO result = null;
            Assert.DoesNotThrowAsync(async () =>
                result = await Api.UboDeclarations.UpdateUboAsync(uboPutDto, userLegal.Id, uboDeclaration.Id, ubo.Id));
            Assert.NotNull(result);
            Assert.AreEqual(ubo.Id, result.Id);
            Assert.AreEqual(uboPutDto.FirstName, result.FirstName);
            Assert.AreEqual(uboPutDto.IsActive, result.IsActive);
        }

        [Test]
        public async Task ApiUboDeclaration_Create_UboDeclaration_Valid()
        {
            var userLegal = await Api.Users.CreateOwnerAsync(CreateUserLegalPost());

            UboDeclarationDTO result = null;

            Assert.DoesNotThrowAsync(async () => result = await Api.UboDeclarations.CreateUboDeclarationAsync(userLegal.Id));
            Assert.That(result.Status == UboDeclarationType.CREATED);
            Assert.That(result.CreationDate != DateTime.MinValue);
        }

        [Test]
        public async Task ApiUboDeclaration_Get_UboDeclaration_Valid()
        {
            var userLegal = await Api.Users.CreateOwnerAsync(CreateUserLegalPost());

            UboDeclarationDTO uboDeclaration = null;
            Assert.DoesNotThrowAsync(async () => uboDeclaration = await Api.UboDeclarations.CreateUboDeclarationAsync(userLegal.Id));
            UboDeclarationDTO result = null;
            Assert.DoesNotThrowAsync(async () =>
                result = await Api.UboDeclarations.GetUboDeclarationByIdAsync(userLegal.Id, uboDeclaration.Id));
            Assert.NotNull(result);
            Assert.AreEqual(uboDeclaration.Id, result.Id);
        }

        [Test]
        public async Task ApiUboDeclaration_GetById_UboDeclaration_Valid()
        {
            var userLegal = await Api.Users.CreateOwnerAsync(CreateUserLegalPost());

            UboDeclarationDTO uboDeclaration = null;
            Assert.DoesNotThrowAsync(async () => uboDeclaration = await Api.UboDeclarations.CreateUboDeclarationAsync(userLegal.Id));

            UboDeclarationDTO result = null;
            Assert.DoesNotThrowAsync(async () => result = await Api.UboDeclarations.GetUboDeclarationByIdAsync(uboDeclaration.Id));
            Assert.NotNull(result);
            Assert.AreEqual(uboDeclaration.Id, result.Id);
        }

        [Test]
        public async Task ApiUboDeclaration_GetAll_UboDeclaration_Valid()
        {
            var userLegal = await Api.Users.CreateOwnerAsync(CreateUserLegalPost());
            var uboDeclarationDto = await Api.UboDeclarations.CreateUboDeclarationAsync(userLegal.Id);

            ListPaginated<UboDeclarationDTO> result = null;
            var pagination = new Pagination(1, 1);
            Assert.DoesNotThrowAsync(async () => result = await Api.UboDeclarations.GetUboDeclarationByUserIdAsync(userLegal.Id, pagination));
            Assert.NotNull(result);
            Assert.IsTrue(result.Count > 0);
            Assert.AreEqual(uboDeclarationDto.Id, result[0].Id);
        }

        [Test]
        public async Task ApiUboDeclaration_Update_UboDeclaration_Valid()
        {
            var userLegal = await Api.Users.CreateOwnerAsync(CreateUserLegalPost());

            var uboDeclaration = await Api.UboDeclarations.CreateUboDeclarationAsync(userLegal.Id);

            var ubopostDtos = UboPostDtoCollection;
            var uboDtos = new List<UboDTO>();

            foreach (var uboPost in ubopostDtos)
            {
                var ubo = await Api.UboDeclarations.CreateUboAsync(uboPost, userLegal.Id, uboDeclaration.Id);
                uboDtos.Add(ubo);
            }

            var ubodeclarationPut =
                new UboDeclarationPutDTO(uboDtos.ToArray(), UboDeclarationType.VALIDATION_ASKED);

            UboDeclarationDTO result = null;

            Assert.DoesNotThrowAsync(async () =>
                result = await Api.UboDeclarations.UpdateUboDeclarationAsync(ubodeclarationPut, userLegal.Id, uboDeclaration.Id));
            Assert.That(result != null);
            Assert.AreEqual(uboDeclaration.Id, result.Id);
            Assert.That(result.Status == UboDeclarationType.VALIDATION_ASKED);
            Assert.That(result.CreationDate != DateTime.MinValue);
        }
    }
}